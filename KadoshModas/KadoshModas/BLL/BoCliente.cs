using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KadoshModas.DAL;
using KadoshModas.DML;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe responsáve pela lógica de negócios de todo objeto Cliente
    /// </summary>
    class BoCliente
    {
        /// <summary>
        /// Cadastra um cliente na base de dados
        /// </summary>
        /// <param name="cliente">Objeto DmoCliente preenchido com pelo menos o Nome do cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false caso algum erro tenha ocorrido</returns>
        public bool Cadastrar(DmoCliente dmoCliente)
        {
            int? idClienteCadastrado;

            if(dmoCliente.Endereco != null)
            {
                dmoCliente.Endereco.IdEndereco = new DaoEndereco().Cadastrar(dmoCliente.Endereco);
            }

            idClienteCadastrado = new DaoCliente().Cadastrar(dmoCliente);

            if (idClienteCadastrado != null)
            {
                //Copiar imagem para pasta e recuperar nova URL
                if (!string.IsNullOrEmpty(dmoCliente.UrlFoto))
                    AtualizarFoto(SalvarFotoERecuperarUrl(dmoCliente.UrlFoto, "FC_" + idClienteCadastrado + ".jpg"), idClienteCadastrado);

                //Cadastro de telefones
                if (dmoCliente.Telefones != null && dmoCliente.Telefones.Count > 0)
                {
                    foreach (DmoTelefoneDoCliente telefone in dmoCliente.Telefones)
                    {
                        telefone.Cliente = new DmoCliente { IdCliente = idClienteCadastrado };
                        new BoTelefoneDoCliente().Cadastrar(telefone);
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta todos os clientes na base de dados
        /// </summary>
        /// <returns>Retorna uma lista de objetos DmoCliente com todos os clientes da base</returns>
        public List<DmoCliente> Consultar()
        {
            List <DmoCliente> listaDeClientes = new DaoCliente().Consultar();

            for(int i = 0; i < listaDeClientes.Count; i++)
            {
                //Buscar Endereço do Cliente
                if (listaDeClientes[i].Endereco != null)
                    listaDeClientes[i].Endereco = new BoEndereco().ConsultarEnderecoPorId(int.Parse(listaDeClientes[i].Endereco.IdEndereco.ToString()));

                //Buscar Lista de Telefones do Cliente
                listaDeClientes[i].Telefones = new DaoCliente().ConsultarTelefonesDoCliente(int.Parse(listaDeClientes[i].IdCliente.ToString()));
            }

            return listaDeClientes;
        }

        /// <summary>
        /// Consulta todos os clientes cujo nomes iniciam com o termo informado
        /// </summary>
        /// <param name="nome">Nome a ser buscado</param>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public List<DmoCliente> Consultar(string nome)
        {
            return new DaoCliente().Consultar(nome);
        }

        /// <summary>
        /// Salva a foto passada por parâmetro na pasta de Fotos de Clientes e recupera a nova URL
        /// </summary>
        /// <param name="pUrlFoto">URL da foto de origem</param>
        /// <param name="pNomeNovaFoto">Novo do novo arquivo com extensão</param>
        /// <returns>Retorna uma string com nova URL da Foto do Cliente</returns>
        private string SalvarFotoERecuperarUrl(string pUrlFoto, string pNomeNovaFoto)
        {
            
            string diretorioImagem = INF.DiretoriosDoSistema.DIR_FOTOS_CLIENTES + "\\" + pNomeNovaFoto;
            File.Copy(pUrlFoto, diretorioImagem, true);

            return diretorioImagem;
        }

        /// <summary>
        /// Atualiza a Url da Foto do Cliente na base de dados
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool AtualizarFoto(string pNovaUrlFoto, int? pIdCliente)
        {
            return new DaoCliente().AtualizarFoto(pNovaUrlFoto, pIdCliente);
        }

        /// <summary>
        /// Valida o CPF
        /// </summary>
        /// <param name="pCPF">CPF para ser validado</param>
        /// <returns>Retorna true se o CPF for válido e false caso não seja</returns>
        public bool ValidarCPF(string pCPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            pCPF = pCPF.Trim();
            pCPF = pCPF.Replace(".", "").Replace("-", "");
            if (pCPF.Length != 11)
                return false;
            tempCpf = pCPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return pCPF.EndsWith(digito);
        }

        /// <summary>
        /// Valida o E-mail
        /// </summary>
        /// <param name="pEmail">String com E-mail para validar</param>
        /// <returns>Retorna true caso o e-mail seja válido ou false caso não seja</returns>
        public bool ValidarEmail(string pEmail)
        {
            const string padraoRegex = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

            Regex regex = new Regex(padraoRegex);
            
            try
            {
                return regex.IsMatch(pEmail);
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> VerificaCPFExistenteAsync(string pCPF)
        {
            return await new DaoCliente().VerificaCPFExistenteAsync(pCPF);
        }
    }
}
