using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    /// <summary>
    /// Classe base para todo objeto DAO. Esta classe contém propriedades comuns a todo objeto DAO.
    /// </summary>
    public abstract class DaoBase
    {
        #region Propriedades
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        protected abstract Conexao Conexao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Verifica se objeto é nulo e retorna valor apropriado para inserção no banco de dados.
        /// </summary>
        /// <param name="pValor">Atributo com valor a ser tratado</param>
        /// <returns>retorna um DBNull.Value caso o valor esteja nulo ou vazio, senão retorna o próprio valor do objeto. </returns>
        public object TratarValorNulo(object pValor)
        {
            if (pValor == null || string.IsNullOrEmpty(Convert.ToString(pValor)))
                return DBNull.Value;
            else if(DateTime.TryParse(pValor.ToString(), out DateTime data))
            {
                if (data == DateTime.MinValue)
                    return DBNull.Value;
                else
                    return pValor;
            }
            else
                return pValor;
        }
        #endregion
    }
}
