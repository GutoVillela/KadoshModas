using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoCliente
    {
        #region Propriedades de Cliente

        /// <summary>
        /// Id do cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// E-mail do cliente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// CPF do cliente
        /// </summary>
        public string CPF { get; set; }

        /// <summary>
        /// Lista de telefones do cliente
        /// </summary>
        public List<DmoTelefone> Telefones { get; set; }
        #endregion
    }
}
