using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Produto
    /// </summary>
    class BoProduto
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Produto na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pDmoProduto">Objeto DmoProduto preenchido com pelo menos o Nome e Preço do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<int?> CadastrarAsync(DmoProduto pDmoProduto)
        {
            //Críticas
            if (string.IsNullOrEmpty(pDmoProduto.Nome) || pDmoProduto.Preco < 0)
                throw new Exception("As propriedades Nome e Preço do Produto são obrigatórios");

            //Cadastro do Produto
            pDmoProduto.IdProduto = await new DaoProduto().CadastrarAsync(pDmoProduto);

            if (pDmoProduto.IdProduto == null)
                return null;

            //Copiar imagem para pasta e recuperar nova URL
            if (!string.IsNullOrEmpty(pDmoProduto.UrlFoto))
                await AtualizarFotoAsync(await SalvarFotoERecuperarUrlAsync(pDmoProduto.UrlFoto, "FP_" + pDmoProduto.IdProduto + ".jpg"), pDmoProduto.IdProduto);

            //Cadastro dos Atributos do Produto
            if (pDmoProduto.Atributos != null && pDmoProduto.Atributos.Any())
            {
                foreach (DmoAtributosDoProduto atributoDoProduto in pDmoProduto.Atributos)
                {
                    atributoDoProduto.Produto = new DmoProduto { IdProduto = pDmoProduto.IdProduto };
                    await new DaoAtributosDoProduto().CadastrarAsync(atributoDoProduto);
                }
            }

            //Cadastro dos Fornecedores do Produto
            if(pDmoProduto.Fornecedores != null && pDmoProduto.Fornecedores.Any())
            {
                foreach(DmoFornecedor fornecedor in pDmoProduto.Fornecedores)
                {
                    await new BoFornecedorDoProduto().CadastrarFornecedorDoProdutoAsync(Convert.ToInt32(fornecedor.IdFornecedor), Convert.ToInt32(pDmoProduto.IdProduto));
                }
            }

            return pDmoProduto.IdProduto;
        }

        /// <summary>
        /// Consulta todos os Produtos na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNome">Se fornecido, busca os Produtos com Nomes que iniciam com a cadeia de caracteres fornecida</param>
        /// <param name="pPrecoMax">Se fornecido, busca os Produtos com preço ATÉ o valor fornecido</param>
        /// <param name="pCodBarras">Se fornecido, busca os Produtos com o Código de Barras IGUAL ao valor fornecido</param>
        /// <param name="pCategorias">Se fornecido, busca os Produtos DENTRO das Categorias fornecidas</param>
        /// <param name="pBuscaProdutosSemCategoria">Se fornecido, define se busca incluirá Produtos sem Categoria</param>
        /// <param name="pMarcas">Se fornecido, busca os Produtos DENTRO das Marcas fornecidas</param>
        /// <param name="pBuscaProdutosSemMarca">Se fornecido, define se busca incluirá Produtos sem Marca</param>
        /// <param name="pBuscaInativos">Define se a busca retornará Produtos Inativos</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido</param>
        /// <returns>Retorna uma lista de objetos DmoProduto com todos os Produtos da base</returns>
        public async Task<List<DmoProduto>> ConsultarAsync(string pNome = null, float? pPrecoMax = null, string pCodBarras = null, List<DmoCategoria> pCategorias = null, bool pBuscaProdutosSemCategoria = true, List<DmoMarca> pMarcas = null, bool pBuscaProdutosSemMarca = true, bool pBuscaInativos = false, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            return await new DaoProduto().ConsultarAsync(pNome, pPrecoMax, pCodBarras, pCategorias, pBuscaProdutosSemCategoria, pMarcas, pBuscaProdutosSemMarca, pBuscaInativos, pAPartirDoRegistro, pAteORegistro);
        }

        /// <summary>
        /// Conta a quantidade de Produtos que correspondem à busca no banco de dados de Forma assíncrona
        /// </summary>
        /// <param name="pNome">Se fornecido, busca os Produtos com Nomes que iniciam com a cadeia de caracteres fornecida</param>
        /// <param name="pPrecoMax">Se fornecido, busca os Produtos com preço ATÉ o valor fornecido</param>
        /// <param name="pCodBarras">Se fornecido, busca os Produtos com o Código de Barras IGUAL ao valor fornecido</param>
        /// <param name="pCategorias">Se fornecido, busca os Produtos DENTRO das Categorias fornecidas</param>
        /// <param name="pMarcas">Se fornecido, busca os Produtos DENTRO das Marcas fornecidas</param>
        /// <param name="pBuscaInativos">Define se a busca retornará Produtos Inativos</param>
        /// <returns>Retorno a quantidade de Produtos encontrados que atendem aos critérios de busca</returns>
        public async Task<int> ContarProdutosAsync(string pNome = null, float? pPrecoMax = null, string pCodBarras = null, List<DmoCategoria> pCategorias = null, List<DmoMarca> pMarcas = null, bool pBuscaInativos = false)
        {
            return await new DaoProduto().ContarProdutosAsync(pNome, pPrecoMax, pCodBarras, pCategorias, pMarcas, pBuscaInativos);
        }

        /// <summary>
        /// Atualiza o Produto de forma assíncrona
        /// </summary>
        /// <param name="pProduto">Objeto DmoProduto com informações do Produto e ID do Produto a ser atualizado</param>
        public async Task AtualizarAsync(DmoProduto pProduto)
        {
            if (pProduto == null || pProduto.IdProduto == null)
                throw new ArgumentException("O parâmetro pProduto é obrigatório e precisa estar preenchido com um ID de Produto válido.");

            await new DaoProduto().AtualizarAsync(pProduto);

            //Copiar imagem para pasta e recuperar nova URL
            if (!string.IsNullOrEmpty(pProduto.UrlFoto))
                await AtualizarFotoAsync(await SalvarFotoERecuperarUrlAsync(pProduto.UrlFoto, "FP_" + pProduto.IdProduto + ".jpg"), pProduto.IdProduto);

            //Excluir Atributos do Produto
            await ExcluirAtributosDoProdutoAsync(int.Parse(pProduto.IdProduto.ToString()));

            //Recadastrar dos Atributos do Produto
            if (pProduto.Atributos != null && pProduto.Atributos.Any())
            {
                foreach (DmoAtributosDoProduto atributoDoProduto in pProduto.Atributos)
                {
                    atributoDoProduto.Produto = new DmoProduto { IdProduto = pProduto.IdProduto };
                    await new DaoAtributosDoProduto().CadastrarAsync(atributoDoProduto);
                }
            }

            //Excluir Fornecedores do Produto
            await ExcluirFornecedoresDoProdutoAsync(int.Parse(pProduto.IdProduto.ToString()));

            //Cadastro dos Fornecedores do Produto
            if (pProduto.Fornecedores != null && pProduto.Fornecedores.Any())
            {
                foreach (DmoFornecedor fornecedor in pProduto.Fornecedores)
                {
                    await new BoFornecedorDoProduto().CadastrarFornecedorDoProdutoAsync(Convert.ToInt32(fornecedor.IdFornecedor), Convert.ToInt32(pProduto.IdProduto));
                }
            }
        }

        /// <summary>
        /// Desativa o Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public async Task DesativarProdutoAsync(int pIdProduto)
        {
            await new DaoProduto().DesativarProdutoAsync(pIdProduto);
        }

        /// <summary>
        /// Exclui todos os Atributos do Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        private async Task ExcluirAtributosDoProdutoAsync(int pIdProduto)
        {
            await new BoAtributosDoProduto().ExcluirAtributosDoProdutoAsync(pIdProduto);
        }

        /// <summary>
        /// Exclui todos os Fornecedores do Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        private async Task ExcluirFornecedoresDoProdutoAsync(int pIdProduto)
        {
            await new BoFornecedorDoProduto().ExcluirFornecedoresDoProdutoAsync(pIdProduto);
        }

        /// <summary>
        /// Consulta um Produto específico por Id
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        /// <returns>Retorna um Produto específico</returns>
        public async Task<DmoProduto> ConsultarAsync(int pIdProduto)
        {
            return await new DaoProduto().ConsultarAsync(pIdProduto);
        }

        /// <summary>
        /// Salva a foto passada por parâmetro na pasta de Fotos de Produtos e recupera a nova URL de forma assíncrona
        /// </summary>
        /// <param name="pUrlFoto">URL da foto de origem</param>
        /// <param name="pNomeNovaFoto">Novo do novo arquivo com extensão</param>
        /// <returns>Retorna uma string com nova URL da Foto do Cliente</returns>
        private async Task<string> SalvarFotoERecuperarUrlAsync(string pUrlFoto, string pNomeNovaFoto)
        {

            string diretorioDestinoImagem = INF.DiretoriosDoSistema.DIR_FOTOS_PRODUTOS + "\\" + pNomeNovaFoto;

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
        /// Atualiza a Url da Foto do Produto na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdProduto">Id do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> AtualizarFotoAsync(string pNovaUrlFoto, int? pIdProduto)
        {
            return await new DaoProduto().AtualizarFotoAsync(pNovaUrlFoto, pIdProduto);
        }

        /// <summary>
        /// Verifica se código de barras já existe e está associado a um Produto
        /// </summary>
        /// <param name="pCodDeBarras">Código de Barras a consultar</param>
        /// <returns>Retorna true se código de barras já existe e false caso não exista</returns>
        public async Task<bool> VerificarSeCodDeBarrasExisteAsync(string pCodDeBarras)
        {
            if (string.IsNullOrEmpty(pCodDeBarras))
                throw new ArgumentException("O parâmetro pCodDeBarras não pode ser vazio ou nulo", "pCodDeBarras");

            if (pCodDeBarras.Length < 12)
                throw new ArgumentException("O parâmetro pCodDeBarras deve possuir pelo menos 12 caracteres para ser um código de barras válido", "pCodDeBarras");

            return await new DaoProduto().VerificarSeCodDeBarrasExisteAsync(pCodDeBarras);
        }

        /// <summary>
        /// Calcula o dígito verificador do código de barras no formato EAN-13 fornecido.
        /// </summary>
        /// <param name="pCodDeBarras">Código de barras sem o dígito verificador.</param>
        /// <returns>Retorna dígito verificador encontrado.</returns>
        public int CalcularDigitoVerificadorCodDeBarras(string pCodDeBarras)
        {
            if (string.IsNullOrEmpty(pCodDeBarras) || pCodDeBarras.Length != 12)
                throw new ArgumentException("O tamanho do código de barras deve ser de 12 dígitos, excluindo o dígito verificador.");

            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int v;
                if (!int.TryParse(pCodDeBarras[i].ToString(), out v))
                    throw new ArgumentException("Caractere inválido encontrado no código de barras. Todos os dígitos devem ser numéricos.");
                sum += (i % 2 == 0 ? v : v * 3);
            }
            int check = 10 - (sum % 10);
            return check % 10;
        }

        /// <summary>
        /// Consulta e retorna o valor do produto mais caro cadastrado na base de forma assíncrona
        /// </summary>
        /// <param name="pIncluirProdutosInativos">Define se busca incluirá valores de produtos inativos</param>
        /// <returns>Retorna maior valor de Produto encontrado.</returns>
        public async Task<double> ObterMaiorPrecoDeProdutoAsync(bool pIncluirProdutosInativos = false)
        {
            return await new DaoProduto().ObterMaiorPrecoDeProdutoAsync(pIncluirProdutosInativos);
        }
        #endregion
    }
}
