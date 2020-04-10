using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoLogin : DmoBase
    {
        #region Propriedades
        /// <summary>
        /// Nome de usuário
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Nível de acesso
        /// </summary>
        public NiveisAcesso NivelDeAcesso { get; set; }
        #endregion

        public enum NiveisAcesso
        {
            Administrador,

            [Description("Usuário")]
            Usuario
        }
    }
}
