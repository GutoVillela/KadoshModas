using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para atributos
    /// </summary>
    class DmoAtributo : DmoBase
    {
        #region Propriedades de Atributo
        /// <summary>
        /// ID do Atributo
        /// </summary>
        public int? IdAtributo { get; set; }

        /// <summary>
        /// Nome do Atributo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Tipo do atributo
        /// </summary>
        public TiposAtributo TipoAtributo { get; set; }

        /// <summary>
        /// Valores possíveis do atributo (somente para atributos do tipo Lista)
        /// </summary>
        public List<DmoValoresAtributos> ValoresDoAtributo { get; set; }
        #endregion

        public enum TiposAtributo
        {
            [Description("Descrição (texto)")]
            Descricao,

            [Description("Numérico")]
            Numerico,

            [Description("Cor")]
            Cor,

            [Description("Lista de valores")]
            Lista
        }
    }

    /// <summary>
    /// Classe DML para Valores do Atributo
    /// </summary>
    class DmoValoresAtributos : DmoBase
    {
        #region Propriedades de Valores do Atributo
        /// <summary>
        /// Atributo
        /// </summary>
        public DmoAtributo Atributo { get; set; }

        /// <summary>
        /// Valor do atributo
        /// </summary>
        public string Valor { get; set; }
        #endregion
    }

    /// <summary>
    /// Classe DML para Atributos do Produto
    /// </summary>
    class DmoAtributosDoProduto : DmoBase
    {
        #region Propriedades de Atributos do Produto
        /// <summary>
        /// Produto
        /// </summary>
        public DmoProduto Produto { get; set; }

        /// <summary>
        /// Atributo
        /// </summary>
        public DmoAtributo Atributo { get; set; }

        /// <summary>
        /// Valor do Atributo
        /// </summary>
        public string Valor { get; set; }
        #endregion
    }
}
