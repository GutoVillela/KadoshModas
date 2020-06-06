using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Telefone
    /// </summary>
    class BoTelefone
    {
        #region Métodos
        /// <summary>
        /// Cadastra um novo telefone
        /// </summary>
        /// <param name="dmoTelefone">Objeto DmoTelefone preenchido</param>
        /// <returns></returns>
        public int? Cadastrar(DmoTelefone pTelefone)
        {
            return new DaoTelefone().Cadastrar(pTelefone);
        }

        /// <summary>
        /// Consulta o ID de um Telefone na base de dados.
        /// </summary>
        /// <param name="pDDD">DDD do Telefone</param>
        /// <param name="pNumero">Número do Telefone</param>
        /// <returns>Retorna o ID do Telefone. Caso o Telefone não exista, retorna null.</returns>
        public int? ConsultaIdTelefone(string pDDD, string pNumero)
        {
            return new DaoTelefone().ConsultaIdTelefone(pDDD, pNumero);
        }
        #endregion
    }
}
