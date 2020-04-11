using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Telefone do Fornecedor
    /// </summary>
    class DmoTelefoneDoFornecedor : DmoTelefone
    {
        #region Propriedades
        /// <summary>
        /// Fornecedor dono do Telefone
        /// </summary>
        public DmoFornecedor Fornecedor { get; set; }
        #endregion
    }
}
