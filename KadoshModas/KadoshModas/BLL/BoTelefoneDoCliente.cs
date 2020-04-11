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
    /// Classe BLL para Telefone do Cliente
    /// </summary>
    class BoTelefoneDoCliente
    {
        #region Métodos]
        /// <summary>
        /// Cadastra um Telefone na base de dados e o associa como um Telefone do Cliente
        /// </summary>
        /// <param name="pDmoTelefoneDoCliente">Objeto DmoTelefoneDoCliente preenchido</param>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        public bool Cadastrar(DmoTelefoneDoCliente pDmoTelefoneDoCliente)
        {
            pDmoTelefoneDoCliente.IdTelefone = new DaoTelefone().Cadastrar(pDmoTelefoneDoCliente);

            if (pDmoTelefoneDoCliente.IdTelefone == null)
                return false;

            return new DaoTelefoneDoCliente().Cadastrar(pDmoTelefoneDoCliente);
        }
        #endregion
    }
}
