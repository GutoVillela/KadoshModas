using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.DML;
using KadoshModas.DAL;

namespace KadoshModas.BLL
{
    class BoLogin
    {
        #region Métodos
        public bool Cadastrar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica se o usuário e senha informados são válidos e existem na base de dados de forma assíncrona.
        /// </summary>
        /// <param name="login">Objeto DmlLogin preenchido com Usuário e Senha</param>
        /// <returns>Retorna true caso o login seja válido e false caso não seja</returns>
        public async Task<bool> ValidarLogin(DmoLogin login)
        {
            return await new DaoLogin().ValidarLoginAsync(login.Usuario, login.Senha);
        }

        /// <summary>
        /// Verifica se o usuário e senha informados são válidos e existem na base de dados de forma assíncrona.
        /// </summary>
        /// <param name="login">Objeto DmlLogin preenchido com Usuário e Senha</param>
        /// <returns>Retorna true caso o login seja válido e false caso não seja</returns>
        public async Task<bool> ValidarLoginAsync(DmoLogin pLogin)
        {
            return await new DaoLogin().ValidarLoginAsync(pLogin.Usuario, pLogin.Senha);
        }
        #endregion
    }
}
