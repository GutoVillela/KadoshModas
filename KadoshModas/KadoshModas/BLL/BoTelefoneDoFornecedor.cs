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
    /// Classe BLL para Telefone do Fornecedor
    /// </summary>
    class BoTelefoneDoFornecedor
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Telefone na base de dados e o associa como um Telefone do Cliente
        /// </summary>
        /// <param name="pDmoTelefoneDoCliente">Objeto DmoTelefoneDoCliente preenchido</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool Cadastrar(DmoTelefoneDoFornecedor pTelefoneDoFornecedor)
        {
            pTelefoneDoFornecedor.IdTelefone = new BoTelefone().ConsultaIdTelefone(pTelefoneDoFornecedor.DDD, pTelefoneDoFornecedor.Numero);

            if (pTelefoneDoFornecedor.IdTelefone == null)
                pTelefoneDoFornecedor.IdTelefone = new BoTelefone().Cadastrar(pTelefoneDoFornecedor);

            if (pTelefoneDoFornecedor.IdTelefone == null)
                return false;

            return new DaoTelefoneDoFornecedor().Cadastrar(pTelefoneDoFornecedor);
        }
        #endregion
    }
}
