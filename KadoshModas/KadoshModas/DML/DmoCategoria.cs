using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoCategoria : DmoBase
    {
        #region Propriedades de Categoria
        /// <summary>
        /// ID da Categoria
        /// </summary>
        public int? IdCategoria { get; set; }

        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string Nome { get; set; }
        #endregion
    }
}
