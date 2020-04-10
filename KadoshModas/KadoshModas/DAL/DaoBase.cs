using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    /// <summary>
    /// Classe DAL base para todas as classes DAL
    /// </summary>
    class DaoBase
    {
        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        protected readonly Conexao conexao;

        /// <summary>
        /// Nome da tabela de Produtos no banco de dados
        /// </summary>
        protected const string NOME_TABELA = "TB_PRODUTOS";
        #endregion
    }
}
