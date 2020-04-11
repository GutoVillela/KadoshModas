using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Estoque
    /// </summary>
    class DmoEstoque
    {
        #region Propriedades para Estoque
        /// <summary>
        /// ID do Estoque
        /// </summary>
        public int? IdEstoque { get; set; }

        /// <summary>
        /// Produto do Estoque
        /// </summary>
        public DmoProduto Produto { get; set; }

        /// <summary>
        /// Quantidade do Produto no Estoque
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Quantidade mínima aceitável do Produto no Estoque
        /// </summary>
        public int Minimo { get; set; }
        #endregion
    }
}
