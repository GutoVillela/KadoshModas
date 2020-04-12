using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.DML;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Estoque
    /// </summary>
    class BoEstoque
    {
        #region Métodos
        /// <summary>
        /// Cadastra um novo Estoque na Base de Dados
        /// </summary>
        /// <param name="pDmoEstoque"></param>
        /// <returns></returns>
        public int? Cadastrar(DmoEstoque pDmoEstoque)
        {
            return new DAL.DaoEstoque().Cadastrar(pDmoEstoque);
        }
        #endregion
    }
}
