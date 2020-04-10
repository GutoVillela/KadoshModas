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
    /// Classe BLL para Endereço
    /// </summary>
    class BoEndereco
    {
        #region Métodos
        /// <summary>
        /// Busca o Endereço por ID
        /// </summary>
        /// <param name="pIdEndereco">ID do Endereço</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Retorna null em caso de erro.</returns>
        public DmoEndereco ConsultarEnderecoPorId(int pIdEndereco)
        {
            return new DaoEndereco().ConsultarEnderecoPorId(pIdEndereco);
        }
        #endregion
    }
}
