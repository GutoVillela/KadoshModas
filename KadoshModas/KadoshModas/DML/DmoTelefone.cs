using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    public class DmoTelefone : DmoBase
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
    }
}
