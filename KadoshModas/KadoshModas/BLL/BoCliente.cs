using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// Cadastra um cliente na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pDmoCliente">Objeto DmoCliente preenchido com pelo menos o Nome do cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false caso algum erro tenha ocorrido</returns>
        public async Task<bool> CadastrarAsync(DmoCliente pDmoCliente)
        {
            int? idClienteCadastrado;

            #region Cadastro do Endereço
            if (pDmoCliente.Endereco != null)
            {
                pDmoCliente.Endereco.IdEndereco = await new BoEndereco().CadastrarAsync(pDmoCliente.Endereco);
            }
            #endregion

            #region Cadastro do Cliente
            idClienteCadastrado = await new DaoCliente().CadastrarAsync(pDmoCliente);
            #endregion

            if (idClienteCadastrado != null)
            {
                //Copiar imagem para pasta e recuperar nova URL
                if (!string.IsNullOrEmpty(pDmoCliente.UrlFoto))
                    await AtualizarFotoAsync(await SalvarFotoERecuperarUrlAsync(pDmoCliente.UrlFoto, "FC_" + idClienteCadastrado + ".jpg"), idClienteCadastrado);

                #region Cadastro de telefones
                if (pDmoCliente.Telefones != null && pDmoCliente.Telefones.Any())
                {
                    #region Remover Telefones duplicados da lista
                    List<DmoTelefoneDoCliente> listaAux = new List<DmoTelefoneDoCliente>();

                    foreach (DmoTelefoneDoCliente telefone in pDmoCliente.Telefones)
                    {
                        if (!listaAux.Any(t => t.DDD == telefone.DDD && t.Numero == telefone.Numero))
                        {
                            listaAux.Add(telefone);
                        }
                    }

                    pDmoCliente.Telefones = listaAux;
                    #endregion

                    foreach (DmoTelefoneDoCliente telefone in pDmoCliente.Telefones)
                    {
                        telefone.Cliente = new DmoCliente { IdCliente = idClienteCadastrado };
                        await new BoTelefoneDoCliente().CadastrarAsync(telefone);
                    }
                }
                #endregion

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta todos os clientes de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Se informado busca o Cliente exato pelo Id</param>
        /// <param name="pNome">Se informado, filtra a busca por Nome do Cliente que inicia com os caracteres informados</param>
        /// <param name="pEmail">Se informado, filtra a busca pelo Email que inicia com os caracteres informados</param>
        /// <param name="pCpf">Se informado, filtra a busca pelo CPF que inicia com os caracteres informados</param>
        /// <param name="pSexo">Se informado, filtra a busca pelo Sexo informado</param>
        /// <param name="pBuscarClienteIndefinido">Define se busca retornará o Cliente Indefinido</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes desativados</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido</param>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public async Task<List<DmoCliente>> ConsultarAsync(int? pIdCliente = null, string pNome = null, string pEmail = null, string pCpf = null, Sexo? pSexo = null, bool pBuscarClienteIndefinido = true, bool pBuscaClientesDesativados = false, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            List<DmoCliente> listaDeClientes = await new DaoCliente().ConsultarAsync(pIdCliente, pNome, pEmail, pCpf, pSexo, pBuscarClienteIndefinido, pBuscaClientesDesativados, pAPartirDoRegistro, pAteORegistro);

            for(int i = 0; i < listaDeClientes.Count; i++)
            {
                //Buscar Endereço do Cliente
                if (listaDeClientes[i].Endereco != null)
                    listaDeClientes[i].Endereco = await new BoEndereco().ConsultarEnderecoPorIdAsync(int.Parse(listaDeClientes[i].Endereco.IdEndereco.ToString()));

                //Buscar Lista de Telefones do Cliente
                listaDeClientes[i].Telefones = await new DaoCliente().ConsultarTelefonesDoClienteAsync(int.Parse(listaDeClientes[i].IdCliente.ToString()));
            }

            return listaDeClientes;
        }

        /// <summary>
        /// Consulta um Cliente específico por ID de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">ID do Cliente</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes Desativados</param>
        /// <returns>Retorna um Cliente específico</returns>
        public async Task<DmoCliente> ConsultarClientePorIdAsync(int pIdCliente, bool pBuscaClientesDesativados = false)
        {
            List<DmoCliente> clientes = await new DaoCliente().ConsultarAsync(pIdCliente, null, null, null, null, true, pBuscaClientesDesativados);
            DmoCliente cliente = clientes.FirstOrDefault();

            if (cliente == null)
                return null;

            //Buscar Endereço do Cliente
            if (cliente.Endereco != null)
                cliente.Endereco = await new BoEndereco().ConsultarEnderecoPorIdAsync(int.Parse(cliente.Endereco.IdEndereco.ToString()));

            //Buscar Lista de Telefones do Cliente
            cliente.Telefones = await new DaoCliente().ConsultarTelefonesDoClienteAsync(int.Parse(cliente.IdCliente.ToString()));

            return cliente;
        }

        /// <summary>
        /// Consulta todos os clientes cujo nomes iniciam com o termo informado de forma assíncrona
        /// </summary>
        /// <param name="pNome">Nome a ser buscado</param>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public async Task<List<DmoCliente>> ConsultarAsync(string pNome)
        {
            return await new DaoCliente().ConsultarAsync(null, pNome);
        }

        /// <summary>
        /// Salva a foto passada por parâmetro na pasta de Fotos de Clientes e recupera a nova URL de forma assíncrona
        /// </summary>
        /// <param name="pUrlFoto">URL da foto de origem</param>
        /// <param name="pNomeNovaFoto">Novo do novo arquivo com extensão</param>
        /// <returns>Retorna uma string com nova URL da Foto do Cliente</returns>
        private async Task<string> SalvarFotoERecuperarUrlAsync(string pUrlFoto, string pNomeNovaFoto)
        {
            string diretorioDestinoImagem = INF.DiretoriosDoSistema.DIR_FOTOS_CLIENTES + "\\" + pNomeNovaFoto;

            try
            {
                using (Stream fotoOrigem = File.Open(pUrlFoto, FileMode.Open))
                {
                    using (Stream fotoDestino = File.Create(diretorioDestinoImagem))
                    {
                        await fotoOrigem.CopyToAsync(fotoDestino);
                    }
                }
            }
            catch
            {
                diretorioDestinoImagem = INF.DiretoriosDoSistema.DIR_FOTOS_CLIENTES + "\\F" + pNomeNovaFoto;
                
                using (Stream fotoOrigem = File.Open(pUrlFoto, FileMode.Open))
                {
                    using (Stream fotoDestino = File.Create(diretorioDestinoImagem))
                    {
                        await fotoOrigem.CopyToAsync(fotoDestino);
                    }
                }
            }

            return diretorioDestinoImagem;
        }

        /// <summary>
        /// Atualiza a Url da Foto do Cliente na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> AtualizarFotoAsync(string pNovaUrlFoto, int? pIdCliente)
        {
            return await new DaoCliente().AtualizarFotoAsync(pNovaUrlFoto, pIdCliente);
        }

        /// <summary>
        /// Atualiza o Cliente de forma assíncrona
        /// </summary>
        /// <param name="cliente">Objeto DmoCliente preenchido com pelo menos o Nome e ID do Cliente</param>
        public async Task AtualizarAsync(DmoCliente pDmoCliente)
        {
            if (pDmoCliente == null || pDmoCliente.IdCliente == null)
                throw new ArgumentException("O parâmetro pDmoCliente não pode ser nulo e deve conter um ID do Cliente válido.");

            if (pDmoCliente.Endereco != null)
            {
                if(pDmoCliente.Endereco.IdEndereco != null)
                    await new BoEndereco().AtualizarAsync(pDmoCliente.Endereco);
                else
                    pDmoCliente.Endereco.IdEndereco = await new BoEndereco().CadastrarAsync(pDmoCliente.Endereco);
            }

            await new DaoCliente().AtualizarAsync(pDmoCliente);


            //Copiar imagem para pasta e recuperar nova URL
            if (!string.IsNullOrEmpty(pDmoCliente.UrlFoto))
                await AtualizarFotoAsync(await SalvarFotoERecuperarUrlAsync(pDmoCliente.UrlFoto, "FC_" + pDmoCliente.IdCliente + ".jpg"), pDmoCliente.IdCliente);


            // Excluir e recadastrar Telefones
            await ExcluirTelefonesDoClienteAsync(int.Parse(pDmoCliente.IdCliente.ToString()));

            if (pDmoCliente.Telefones != null && pDmoCliente.Telefones.Any())
            {
                // Remover Telefones duplicados da lista
                List<DmoTelefoneDoCliente> listaAux = new List<DmoTelefoneDoCliente>();

                foreach (DmoTelefoneDoCliente telefone in pDmoCliente.Telefones)
                {
                    if (!listaAux.Any(t => t.DDD == telefone.DDD && t.Numero == telefone.Numero))
                    {
                        listaAux.Add(telefone);
                    }
                }

                pDmoCliente.Telefones = listaAux;

                foreach (DmoTelefoneDoCliente telefone in pDmoCliente.Telefones)
                {
                    telefone.Cliente = pDmoCliente;
                    await new BoTelefoneDoCliente().CadastrarAsync(telefone);
                }
            }

        }

        /// <summary>
        /// Excluir todos os Telefones relacionados ao Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        private async Task ExcluirTelefonesDoClienteAsync(int pIdCliente)
        {
            await new DaoTelefone().ExcluirTelefonesDoClienteAsync(pIdCliente);
        }

        /// <summary>
        /// Desativa o Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        public async Task DesativarClienteAsync(int pIdCliente)
        {
            await new DaoCliente().DesativarClienteAsync(pIdCliente);
        }

        /// <summary>
        /// Conta a quantidade de Clientes que correspondem à busca no banco de dados de Forma assíncrona
        /// <param name="pNome">Se informado, filtra a busca por Nome do Cliente que inicia com os caracteres informados</param>
        /// <param name="pEmail">Se informado, filtra a busca pelo Email que inicia com os caracteres informados</param>
        /// <param name="pCpf">Se informado, filtra a busca pelo CPF que inicia com os caracteres informados</param>
        /// <param name="pSexo">Se informado, filtra a busca pelo Sexo informado</param>
        /// <param name="pBuscarClienteIndefinido">Define se busca retornará o Cliente Indefinido</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes desativados</param>
        /// </summary>
        /// <returns>Retorno a quantidade de clientes encontrados que atendem aos critérios de busca</returns>
        public async Task<int> ContarClientesAsync(string pNome = null, string pEmail = null, string pCpf = null, Sexo? pSexo = null, bool pBuscarClienteIndefinido = true, bool pBuscaClientesDesativados = false)
        {
            return await new DaoCliente().ContarClientesAsync(pNome, pEmail, pCpf, pSexo, pBuscarClienteIndefinido, pBuscaClientesDesativados);
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
