using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Parcelas da Venda
    /// </summary>
    public class DmoParcela : DmoBase
    {
        #region Propriedades de Parcela
        /// <summary>
        /// Venda da Parcela
        /// </summary>
        public DmoVenda Venda { get; set; }

        /// <summary>
        /// Número da Parcela
        /// </summary>
        public int Parcela { get; set; }

        /// <summary>
        /// Valor da Parcela
        /// </summary>
        public float ValorParcela { get; set; }

        /// <summary>
        /// Desconto da Parcela
        /// </summary>
        public float Desconto { get; set; }

        /// <summary>
        /// Vencimento da Parcela
        /// </summary>
        public DateTime Vencimento { get; set; }

        /// <summary>
        /// Situação da Parcela
        /// </summary>
        public SituacoesParcela SituacaoParcela { get; set; }

        /// <summary>
        /// Data do Pagamento da Parcela
        /// </summary>
        public DateTime? DataDoPagamento { get; set; }
        #endregion

        public enum SituacoesParcela
        {
            [Description("Em aberto")]
            EmAberto,

            [Description("Parcela Paga Sem Atraso")]
            PagoSemAtraso,

            [Description("Parcela Paga Com Atraso")]
            PagoComAtraso,

            [Description("Parcela Cancelada")]
            Cancelado,
        }
    }
}
