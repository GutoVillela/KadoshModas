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
        /// Cadastra um Produto na base de dados
        /// </summary>
        /// <param name="pDmoProduto">Objeto DmoProduto preenchido com pelo menos o Nome e Preço do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool Cadastrar(DmoProduto pDmoProduto)
        {
            //Críticas
            if (string.IsNullOrEmpty(pDmoProduto.Nome) || pDmoProduto.Preco < 0)
                throw new Exception("As propriedades Nome e Preço do Produto são obrigatórios");

            //Cadastro do Produto
            int? idProduto = new DaoProduto().Cadastrar(pDmoProduto);

            if (idProduto == null)
                return false;

            //Copiar imagem para pasta e recuperar nova URL
            if (!string.IsNullOrEmpty(pDmoProduto.UrlFoto))
                AtualizarFoto(SalvarFotoERecuperarUrl(pDmoProduto.UrlFoto, "FP_" + idProduto + ".jpg"), idProduto);

            //Cadastro dos Atributos do Produto
            if (pDmoProduto.Atributos != null && pDmoProduto.Atributos.Any())
            {
                foreach (DmoAtributosDoProduto atributoDoProduto in pDmoProduto.Atributos)
                {
                    atributoDoProduto.Produto = new DmoProduto { IdProduto = idProduto };
                    new DaoAtributosDoProduto().Cadastrar(atributoDoProduto);
                }
            }

            return true;
        }

        /// <summary>
        /// Salva a foto passada por parâmetro na pasta de Fotos de Produtos e recupera a nova URL
        /// </summary>
        /// <param name="pUrlFoto">URL da foto de origem</param>
        /// <param name="pNomeNovaFoto">Novo do novo arquivo com extensão</param>
        /// <returns>Retorna uma string com nova URL da Foto do Cliente</returns>
        private string SalvarFotoERecuperarUrl(string pUrlFoto, string pNomeNovaFoto)
        {

            string diretorioImagem = INF.DiretoriosDoSistema.DIR_FOTOS_PRODUTOS + "\\" + pNomeNovaFoto;
            File.Copy(pUrlFoto, diretorioImagem, true);

            return diretorioImagem;
        }

        /// <summary>
        /// Atualiza a Url da Foto do Produto na base de dados
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdProduto">Id do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool AtualizarFoto(string pNovaUrlFoto, int? pIdProduto)
        {
            return new DaoProduto().AtualizarFoto(pNovaUrlFoto, pIdProduto);
        }
        #endregion
    }
}
