using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Romaneios de Venda (utilizado na RDLC para Romaneio)
    /// </summary>
    public class DmoRomaneioVenda
    {
        #region Propriedades
        /// <summary>
        /// Nome do Produto do Romaneio.
        /// </summary>
        public string Produto { get; set; }

        /// <summary>
        /// Quantidade do Produto.
        /// </summary>
        public uint Quantidade { get; set; }

        /// <summary>
        /// Valor Unitário do Produto.
        /// </summary>
        public float ValorUnitario { get; set; }

        /// <summary>
        /// Subtotal da Venda.
        /// </summary>
        public float Subtotal { get; set; }

        /// <summary>
        /// Indica se item está pago ou não.
        /// </summary>
        public bool Pago { get; set; }
        #endregion
    }
}
