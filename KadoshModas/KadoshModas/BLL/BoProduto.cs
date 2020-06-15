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
        /// <param name="pMarcas">Se fornecido, busca os Produtos DENTRO das Marcas fornecidas</param>
        /// <param name="pBuscaInativos">Define se a busca retornará Produtos Inativos</param>
        /// <returns>Retorna uma lista de objetos DmoProduto com todos os Produtos da base</returns>
        public async Task<List<DmoProduto>> ConsultarAsync(string pNome = null, float? pPrecoMax = null, string pCodBarras = null, List<DmoCategoria> pCategorias = null, List<DmoMarca> pMarcas = null, bool pBuscaInativos = false)
        {
            return await new DaoProduto().ConsultarAsync(pNome, pPrecoMax, pCodBarras, pCategorias, pMarcas, pBuscaInativos);
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
        #endregion
    }
}
