using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Item da Venda
    /// </summary>
    public class DmoItemDaVenda : DmoBase
    {
        #region Propriedades
        /// <summary>
        /// Venda deste Item da Venda
        /// </summary>
        public DmoVenda Venda { get; set; }

        /// <summary>
        /// Produto deste Item da Venda
        /// </summary>
        public DmoProduto Produto { get; set; }

        /// <summary>
        /// Quantidade deste Item da Venda
        /// </summary>
        public uint Quantidade { get; set; }

        /// <summary>
        /// Valor deste Item da Venda
        /// </summary>
        public float Valor { get; set; }

        /// <summary>
        /// Desconto aplicado para o Item da Venda (seguindo lógica de promoção, entre 0 e 100)
        /// </summary>
        public float Desconto { get; set; }
        #endregion
    }
}
