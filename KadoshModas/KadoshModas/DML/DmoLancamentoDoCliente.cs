using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    /// <summary>
    /// Classe DML para Lançamento do Cliente
    /// </summary>
    [NomeDaTabelaBD("TB_LANCAMENTOS_DO_CLIENTE")]
    class DmoLancamentoDoCliente : DmoBase
    {
        #region Propriedades
        /// <summary>
        /// ID do Lançamento do Cliente
        /// </summary>
        [CampoBD("ID_LANCAMENTO_DO_CLIENTE", ChavePrimaria = true)]
        public int? IdLancamentoDoCliente { get; set; }

        /// <summary>
        /// Cliente do Lançamento
        /// </summary>
        [CampoBD("CLIENTE")]
        public DmoCliente Cliente { get; set; }

        /// <summary>
        /// Tipo do Lançamento do Cliente
        /// </summary>
        [CampoBD("TIPO_LANCAMENTO_DO_CLIENTE")]
        public TipoLancamentoDoCliente TipoLancamentoDoCliente { get; set; }

        /// <summary>
        /// Valor do Lançamento
        /// </summary>
        [CampoBD("VALOR_LANCAMENTO")]
        public double ValorLancamento { get; set; }

        /// <summary>
        /// Venda associada ao Lançamento do Cliente
        /// </summary>
        [CampoBD("VENDA")]
        public DmoVenda Venda { get; set; }

        /// <summary>
        /// Data do Lançamento
        /// </summary>
        [CampoBD("DT_LANCAMENTO")]
        public DateTime DataDoLancamento { get; set; }

        /// <summary>
        /// Obtém o nome da tabela no banco de dados atribuído à esta classe DML
        /// </summary>
        public static string NomeTabela 
        { 
            get 
            {
                Type tipo = typeof(DmoLancamentoDoCliente);
                if (!Attribute.IsDefined(tipo, typeof(NomeDaTabelaBDAttribute), false))
                    throw new Exception("O atributo NomeDaTabela não está definido para o objeto DMO fornecido.");

                return (tipo.GetCustomAttributes(typeof(NomeDaTabelaBDAttribute), false).FirstOrDefault() as NomeDaTabelaBDAttribute).NomeTabelaBD;
            } 
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Recupera o nome do campo no banco de dados para a propriedade especificada. Uso: NomeDoCampo(() => instanciaDmo.Propriedade);
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pPropriedade"></param>
        /// <returns>Retorna o valor do atributo CampoBD associado à propriedade.</returns>
        public static string NomeDoCampo<T>(Expression<Func<T>> pPropriedade)
        {
            string nomePropriedade = (pPropriedade.Body as MemberExpression).Member.Name;
            PropertyInfo propertyInfo = typeof(DmoLancamentoDoCliente).GetProperty(nomePropriedade);
            return (propertyInfo.GetCustomAttribute(typeof(CampoBDAttribute), false) as CampoBDAttribute).NomeCampoBD;
        }

        /// <summary>
        /// Verifica se o enum do tipo TipoLancamentoDoCliente é do tipo Entrada.
        /// </summary>
        /// <param name="pTipoLancamento">Enum</param>
        /// <returns>Se item for do tipo Entrada retorna true, senão retorna false.</returns>
        public static bool TipoEntrada(TipoLancamentoDoCliente pTipoLancamento)
        {
            return pTipoLancamento == TipoLancamentoDoCliente.CompraAVista || pTipoLancamento == TipoLancamentoDoCliente.Pagamento || pTipoLancamento == TipoLancamentoDoCliente.Entrada;
        }
        #endregion
    }

    /// <summary>
    /// Enum que define os Tipos de Lançamento do Cliente
    /// </summary>
    public enum TipoLancamentoDoCliente
    {
        [Description("Compra à vista")]
        CompraAVista,

        [Description("Pagamento de conta")]
        Pagamento,

        [Description("Entrada")]
        Entrada,

        [Description("Estorno de pagamento")]
        Estorno,

        [Description("Devolução de item da compra")]
        DevolucaoDeItemDaCompra
    }
}
