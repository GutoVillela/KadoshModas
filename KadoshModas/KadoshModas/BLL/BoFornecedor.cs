using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.DML;
using KadoshModas.DAL;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Fornecedor
    /// </summary>
    class BoFornecedor
    {
        #region Métodos
        /// <summary>
        /// Consulta todos os Fornecedores cadastrados na base de dados
        /// </summary>
        /// <returns>Retorna uma lista de DmoFornecedor com todos os Fornecedores encontrados</returns>
        public List<DmoFornecedor> Consultar()
        {
            return new DaoFornecedor().Consultar();
        }
        #endregion
    }
}
