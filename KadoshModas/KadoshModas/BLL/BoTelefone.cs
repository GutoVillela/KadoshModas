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
        /// Cadastra um novo telefone de forma assíncrona
        /// </summary>
        /// <param name="dmoTelefone">Objeto DmoTelefone preenchido</param>
        /// <returns></returns>
        public async Task<int?> CadastrarAsync(DmoTelefone pTelefone)
        {
            return await new DaoTelefone().CadastrarAsync(pTelefone);
        }

        /// <summary>
        /// Consulta o ID de um Telefone na base de dados de forma assíncrona.
        /// </summary>
        /// <param name="pDDD">DDD do Telefone</param>
        /// <param name="pNumero">Número do Telefone</param>
        /// <returns>Retorna o ID do Telefone. Caso o Telefone não exista, retorna null.</returns>
        public async Task<int?> ConsultaIdTelefoneAsync(string pDDD, string pNumero)
        {
            return await new DaoTelefone().ConsultaIdTelefoneAsync(pDDD, pNumero);
        }
        #endregion
    }
}
