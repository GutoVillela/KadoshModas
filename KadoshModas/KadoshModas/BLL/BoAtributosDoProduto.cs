using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Atributos do Produto
    /// </summary>
    class BoAtributosDoProduto
    {
        #region Métodos
        /// <summary>
        /// Cadastrar um Atributo do Produto na base de dados
        /// </summary>
        /// <param name="pDmoValoresAtributos">Objeto DmoValoresAtributos preenchido</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool Cadastrar(DmoAtributosDoProduto pDmoValoresAtributos)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Exclui todos os Atributos do Produto
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public void ExcluirAtributosDoProduto(int pIdProduto)
        {
            new DaoAtributosDoProduto().ExcluirAtributosDoProduto(pIdProduto);
        }
        #endregion
    }
}
