using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DML
{
    class DmoLogin
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
        /// Data de criação do registro na base de dados
        /// </summary>
        public DateTime DataDeCriacao { get; set; }

        /// <summary>
        /// Data da última atualização do registro na base de dados
        /// </summary>
        public DateTime DataDeAtualizacao { get; set; }
        #endregion
    }
}
