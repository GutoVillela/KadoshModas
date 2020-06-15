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
    /// Classe BLL para Endereço
    /// </summary>
    class BoEndereco
    {
        #region Métodos
        /// <summary>
        /// Cadastra um novo Endereço de forma assíncrona
        /// </summary>
        /// <param name="pEndereco">Objeto DmoEndereco preenchido</param>
        /// <returns>Retorna o Id do Endereço cadastrado</returns>
        public async Task<int?> CadastrarAsync(DmoEndereco pEndereco)
        {
            return await new DaoEndereco().CadastrarAsync(pEndereco);
        }

        /// <summary>
        /// Busca o Endereço por ID de forma assíncrona
        /// </summary>
        /// <param name="pIdEndereco">ID do Endereço</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Retorna null em caso de erro.</returns>
        public async Task<DmoEndereco> ConsultarEnderecoPorIdAsync(int pIdEndereco)
        {
            return await new DaoEndereco().ConsultarEnderecoPorIdAsync(pIdEndereco);
        }

        /// <summary>
        /// Atualiza o Endereço de forma assíncrona
        /// </summary>
        /// <param name="pDmoEndereco">Objeto DmoEndereco preenchido e com ID válido</param>
        public async Task AtualizarAsync(DmoEndereco pDmoEndereco)
        {
            if (pDmoEndereco == null || pDmoEndereco.IdEndereco == null)
                throw new ArgumentException("O parâmetro pDmoEndereco não pode ser nulo e deve contar um ID de Endereço válido.");

            await new DaoEndereco().AtualizarAsync(pDmoEndereco);
        }
        #endregion
    }
}
