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
        /// Cadastra um novo Endereço 
        /// </summary>
        /// <param name="pEndereco">Objeto DmoEndereco preenchido</param>
        /// <returns>Retorna o Id do Endereço cadastrado</returns>
        public int? Cadastrar(DmoEndereco pEndereco)
        {
            return new DaoEndereco().Cadastrar(pEndereco);
        }

        /// <summary>
        /// Busca o Endereço por ID
        /// </summary>
        /// <param name="pIdEndereco">ID do Endereço</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Retorna null em caso de erro.</returns>
        public DmoEndereco ConsultarEnderecoPorId(int pIdEndereco)
        {
            return new DaoEndereco().ConsultarEnderecoPorId(pIdEndereco);
        }

        /// <summary>
        /// Atualiza o Endereço
        /// </summary>
        /// <param name="pDmoEndereco">Objeto DmoEndereco preenchido e com ID válido</param>
        public void Atualizar(DmoEndereco pDmoEndereco)
        {
            if (pDmoEndereco == null || pDmoEndereco.IdEndereco == null)
                throw new ArgumentException("O parâmetro pDmoEndereco não pode ser nulo e deve contar um ID de Endereço válido.");

            new DaoEndereco().Atualizar(pDmoEndereco);
        }
        #endregion
    }
}
