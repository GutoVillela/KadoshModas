using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Telefone do CLiente
    /// </summary>
    public class DmoTelefoneDoCliente : DmoTelefone
    {
        #region Propriedades
        /// <summary>
        /// Cliente dono do Telefone
        /// </summary>
        public DmoCliente Cliente { get; set; }
        #endregion
    }
}
