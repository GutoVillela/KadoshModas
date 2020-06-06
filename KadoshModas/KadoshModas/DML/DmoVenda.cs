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
            Situacao = SituacoesVenda.EmAberto;
            
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
        /// Forma de pagamento para esta Venda
        /// </summary>
        public FormasDePagamento FormaDePagamento { get; set; }

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
        public float Entrada { get; set; }

        /// <summary>
        /// Juros aplicado no Total da compra em caso de pagamento a prazo para esta Venda
        /// </summary>
        public float JurosAPrazo { get; set; }

        /// <summary>
        /// Situação da Venda
        /// </summary>
        public SituacoesVenda Situacao { get; set; }

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

        #region Enum
        /// <summary>
        /// Enum que define as formas de pagamento para Venda
        /// </summary>
        public enum FormasDePagamento
        {
            [Description("Dinheiro")]
            Dinheiro,

            [Description("Cartão de Débito")]
            CartaoDeDebito,

            [Description("Cartão de Crédito")]
            CartaoDeCredito
        }

        /// <summary>
        /// Enum que define as situações da Venda
        /// </summary>
        public enum SituacoesVenda
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
}
