using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Marca
    /// </summary>
    class DmoMarca
    {
        #region Propriedades de Marca
        /// <summary>
        /// ID da Marca
        /// </summary>
        public int? IdMarca { get; set; }

        /// <summary>
        /// Nome da Marca
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
