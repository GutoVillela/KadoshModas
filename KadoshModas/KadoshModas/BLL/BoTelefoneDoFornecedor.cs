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
        /// Cadastra um Telefone na base de dados e o associa como um Telefone do Fornecedor de forma assíncrona 
        /// </summary>
        /// <param name="pTelefoneDoFornecedor">Objeto DmoTelefoneDoFornecedor preenchido</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoTelefoneDoFornecedor pTelefoneDoFornecedor)
        {
            pTelefoneDoFornecedor.IdTelefone = await new BoTelefone().ConsultaIdTelefoneAsync(pTelefoneDoFornecedor.DDD, pTelefoneDoFornecedor.Numero);

            if (pTelefoneDoFornecedor.IdTelefone == null)
                pTelefoneDoFornecedor.IdTelefone = await new BoTelefone().CadastrarAsync(pTelefoneDoFornecedor);

            if (pTelefoneDoFornecedor.IdTelefone == null)
                return false;

            return await new DaoTelefoneDoFornecedor().CadastrarAsync(pTelefoneDoFornecedor);
        }
        #endregion
    }
}
