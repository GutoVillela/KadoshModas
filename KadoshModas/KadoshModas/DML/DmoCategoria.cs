using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoCategoria
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

        /// <summary>
        /// Data de criação do registro na base de dados
        /// </summary>
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }
        #endregion
    }
}
