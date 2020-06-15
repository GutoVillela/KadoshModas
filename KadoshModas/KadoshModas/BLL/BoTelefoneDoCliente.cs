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
        #region Métodos
        /// <summary>
        /// Cadastra um Telefone na base de dados e o associa como um Telefone do Cliente de forma assíncrona
        /// </summary>
        /// <param name="pDmoTelefoneDoCliente">Objeto DmoTelefoneDoCliente preenchido</param>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoTelefoneDoCliente pDmoTelefoneDoCliente)
        {
            pDmoTelefoneDoCliente.IdTelefone = await new BoTelefone().ConsultaIdTelefoneAsync(pDmoTelefoneDoCliente.DDD, pDmoTelefoneDoCliente.Numero);

            if(pDmoTelefoneDoCliente.IdTelefone == null)
                pDmoTelefoneDoCliente.IdTelefone = await new DaoTelefone().CadastrarAsync(pDmoTelefoneDoCliente);

            if (pDmoTelefoneDoCliente.IdTelefone == null)
                return false;

            return await new DaoTelefoneDoCliente().CadastrarAsync(pDmoTelefoneDoCliente);
        }
        #endregion
    }
}
