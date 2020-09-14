using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        /// <summary>
        /// Situação deste Item da Venda
        /// </summary>
        public SituacaoItemDaVenda Situacao { get; set; }

        /// <summary>
        /// Descrição com motivo da Situação deste Item
        /// </summary>
        public string DescricaoSituacao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Converte uma lista de objetos DmoItemDaVenda para uma lista de objetos DmoRomaneioVenda, para impressão de relatório.
        /// </summary>
        /// <param name="pItensDaVenda">Lista de objetos DmoItemDaVenda.</param>
        /// <returns></returns>
        public static List<DmoRomaneioVenda> ConverterItensParaRomaneio(List<DmoItemDaVenda> pItensDaVenda)
        {
            List<DmoRomaneioVenda> romaneios = new List<DmoRomaneioVenda>();

            foreach(var item in pItensDaVenda)
            {
                romaneios.Add(new DmoRomaneioVenda
                {
                    Produto = item.Produto.Nome,
                    Quantidade = item.Quantidade,
                    ValorUnitario = item.Valor,
                    Subtotal = item.Quantidade * item.Valor,
                    Pago = false
                });
            }

            return romaneios;
        }
        #endregion Métodos
    }

    #region Enum
    public enum SituacaoItemDaVenda
    {
        [Description("Item adquirido pelo cliente no momento da compra.")]
        AdquiridoNaCompra,

        [Description("Item adquirido pelo cliente em troca de outro produto.")]
        AdquiridoNaTroca,

        [Description("Item cancelado.")]
        Cancelado,

        [Description("Item trocado por outro produto.")]
        Trocado
    }
    #endregion
}
