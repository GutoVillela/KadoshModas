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
        /// Cadastra um Fornecedor para o Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdFornecedor">ID do Fornecedor</param>
        /// <param name="pIdProduto">ID do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> CadastrarFornecedorDoProdutoAsync(int pIdFornecedor, int pIdProduto)
        {
            return await new DaoFornecedorDoProduto().CadastrarFornecedorDoProdutoAsync(pIdFornecedor, pIdProduto);
        }

        /// <summary>
        /// Exclui todos os Fornecedores do Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public async Task ExcluirFornecedoresDoProdutoAsync(int pIdProduto)
        {
            await new DaoFornecedorDoProduto().ExcluirFornecedoresDoProdutoAsync(pIdProduto);
        }
        #endregion
    }
}
