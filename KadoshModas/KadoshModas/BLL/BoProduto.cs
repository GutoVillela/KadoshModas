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
            if (string.IsNullOrEmpty(pDmoProduto.Nome) || pDmoProduto.Preco < 0)
                throw new Exception("O atributo Nome e Preço do Produto são obrigatórios");

            return new DaoProduto().Cadastrar(pDmoProduto) != null;
        }
        #endregion
    }
}
