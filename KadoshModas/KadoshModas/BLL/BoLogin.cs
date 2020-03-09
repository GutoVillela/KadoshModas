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
        public bool Cadastrar()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica se o usuário e senha informados são válidos e existem na base de dados.
        /// </summary>
        /// <param name="login">Objeto DmlLogin preenchido com Usuário e Senha</param>
        /// <returns>Retorna true caso o login seja válido e false caso não seja</returns>
        public bool ValidarLogin(DmoLogin login)
        {
            return new DaoLogin().ValidarLogin(login.Usuario, login.Senha);
        }
    }
}
