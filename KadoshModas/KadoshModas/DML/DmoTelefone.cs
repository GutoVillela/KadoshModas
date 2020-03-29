using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoTelefone
    {
        #region Propriedades de Telefone
        /// <summary>
        /// Cliente dono do número de telefone
        /// </summary>
        public DmoCliente Cliente { get; set; }

        /// <summary>
        /// DDD
        /// </summary>
        public string DDD { get; set; }

        /// <summary>
        /// Número de telefone
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Tipo de telefone cadastrado para esta instância de Telefone
        /// </summary>
        public TiposDeTelefone TipoDeTelefone { get; set; }

        /// <summary>
        /// Nome da pessoa a quem chamar quando ligar para este número
        /// </summary>
        public string FalarCom { get; set; }

        /// <summary>
        /// Data de criação do registro na base de dados
        /// </summary>
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }
        #endregion

        /// <summary>
        /// Tipos de telefone
        /// </summary>
        public enum TiposDeTelefone
        {
            [Description("Residencial")]
            Residencial,

            [Description("Comercial")]
            Comercial,

            [Description("WhatsApp")]
            WhatsApp,

            [Description("Número de parente")]
            NumeroDeParente,

            [Description("Número de conhecido")]
            NumeroDeConhecido,

            [Description("Outro")]
            Outro
        }

        /// <summary>
        /// Busca as descrições e os valores do Enum
        /// </summary>
        /// <returns>Retorna um dicionário de pares de valor com Descrição e Valor do Enum</returns>
        public SortedDictionary<string, int> DescricaoEnum()
        {
            SortedDictionary<string, int> paresDeValor = new SortedDictionary<string, int>();

            foreach (TiposDeTelefone tipo in Enum.GetValues(TiposDeTelefone.Comercial.GetType()))
            {
                paresDeValor.Add(DescricaoEnum(tipo), (int)tipo);
            }

            return paresDeValor;
        }

        /// <summary>
        /// Busca o atributo Description de um item do Enum
        /// </summary>
        /// <param name="pTipoTelefone">Enum</param>
        /// <returns>Retorna descrição do Enum</returns>
        public string DescricaoEnum(TiposDeTelefone pTipoTelefone)
        {
            return (pTipoTelefone.GetType().GetMember(pTipoTelefone.GetType().GetEnumName((int)pTipoTelefone))[0].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute).Description;
        }
    }
}
