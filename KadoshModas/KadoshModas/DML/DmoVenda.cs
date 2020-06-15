using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Venda
    /// </summary>
    public class DmoVenda : DmoBase
    {
        #region Construtor
        /// <summary>
        /// Inicializa a lista ItensDaVenda
        /// </summary>
        public DmoVenda()
        {
            ItensDaVenda = new List<DmoItemDaVenda>();
            ParcelasDaVenda = new List<DmoParcela>();
            TipoPagamento = TipoPagamento.AVista;
            Situacao = SituacaoVenda.EmAberto;
            
            //Inicializar Venda com Cliente Indefinido
            Cliente = new DmoCliente()
            {
                IdCliente = DmoCliente.IdClienteIndefinido
            };
        }
        #endregion

        #region Propriedades de Venda
        /// <summary>
        /// Id da Venda
        /// </summary>
        public int? IdVenda { get; set; }

        /// <summary>
        /// Cliente da Venda
        /// </summary>
        public DmoCliente Cliente { get; set; }

        /// <summary>
        /// Tipo desta Venda
        /// </summary>
        public TipoPagamento TipoPagamento { get; set; }

        /// <summary>
        /// Forma de pagamento para esta Venda
        /// </summary>
        public FormaDePagamento FormaDePagamento { get; set; }

        /// <summary>
        /// Quantidade de parcelas para esta Venda
        /// </summary>
        public uint QtdParcelas { get; set; }

        /// <summary>
        /// Desconto para esta Venda (em porcentagem entre 0 e 100)
        /// </summary>
        public float Desconto { get; set; }

        /// <summary>
        /// Entrada fornecida para esta Venda
        /// </summary>
        public double Entrada { get; set; }

        /// <summary>
        /// Juros aplicado no Total da compra em caso de pagamento a prazo para esta Venda
        /// </summary>
        public float JurosAPrazo { get; set; }

        /// <summary>
        /// Situação da Venda
        /// </summary>
        public SituacaoVenda Situacao { get; set; }

        /// <summary>
        /// Valor Total da Venda
        /// </summary>
        public double Total { get; set; }

        /// <summary>
        /// Valor Pago até o momento da Venda
        /// </summary>
        public double Pago { get; set; }

        /// <summary>
        /// Data em que a Venda foi realizada
        /// </summary>
        public DateTime DataVenda { get; set; }

        /// <summary>
        /// Data em que a Venda foi quitada
        /// </summary>
        public DateTime DataQuitacaoVenda { get; set; }

        /// <summary>
        /// Itens desta Venda
        /// </summary>
        public List<DmoItemDaVenda> ItensDaVenda { get; set; }

        /// <summary>
        /// Parcelas Desta Venda
        /// </summary>
        public List<DmoParcela> ParcelasDaVenda { get; set; }
        #endregion
    }

    #region Enum
    /// <summary>
    /// Enum que define os tipos de pagamento da Venda
    /// </summary>
    public enum TipoPagamento
    {
        [Description("À Vista")]
        AVista,

        [Description("Fiado")]
        Fiado,

        [Description("Parcelado")]
        Parcelado,
    }

    /// <summary>
    /// Enum que define as formas de pagamento para Venda
    /// </summary>
    public enum FormaDePagamento
    {
        [Description("Dinheiro")]
        Dinheiro,

        [Description("Cartão de Débito")]
        CartaoDeDebito,

        [Description("Cartão de Crédito")]
        CartaoDeCredito,

        [Description("Cheque")]
        Cheque,
    }

    /// <summary>
    /// Enum que define as situações da Venda
    /// </summary>
    public enum SituacaoVenda
    {
        [Description("Em Aberto")]
        EmAberto,

        [Description("Concluído")]
        Concluido,

        [Description("Cancelado")]
        Cancelado
    }
    #endregion
}
