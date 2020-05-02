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
        /// Itens desta Venda
        /// </summary>
        public List<DmoItemDaVenda> ItensDaVenda { get; set; }
        #endregion

        /// <summary>
        /// Enum que define as formas de pagamento para Venda
        /// </summary>
        public enum FormasDePagamento
        {
            [Description("Residencial")]
            Dinheiro,

            [Description("Cartão de Débito")]
            CartaoDeDebito,

            [Description("Cartão de Crédito")]
            CartaoDeCredito
        }
    }
}
