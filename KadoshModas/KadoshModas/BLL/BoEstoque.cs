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
        /// Cadastra um novo Estoque na Base de Dados de forma assíncrona
        /// </summary>
        /// <param name="pDmoEstoque"></param>
        /// <returns></returns>
        public async Task<int?> CadastrarAsync(DmoEstoque pDmoEstoque)
        {
            return await new DAL.DaoEstoque().CadastrarAsync(pDmoEstoque);
        }
        #endregion
    }
}
