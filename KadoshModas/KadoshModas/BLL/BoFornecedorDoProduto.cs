using KadoshModas.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Fornecedor do Produto
    /// </summary>
    class BoFornecedorDoProduto
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Fornecedor para o Produto
        /// </summary>
        /// <param name="pIdFornecedor">ID do Fornecedor</param>
        /// <param name="pIdProduto">ID do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool CadastrarFornecedorDoProduto(int pIdFornecedor, int pIdProduto)
        {
            return new DaoFornecedorDoProduto().CadastrarFornecedorDoProduto(pIdFornecedor, pIdProduto);
        }

        /// <summary>
        /// Exclui todos os Fornecedores do Produto
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public void ExcluirFornecedoresDoProduto(int pIdProduto)
        {
            new DaoFornecedorDoProduto().ExcluirFornecedoresDoProduto(pIdProduto);
        }
        #endregion
    }
}
