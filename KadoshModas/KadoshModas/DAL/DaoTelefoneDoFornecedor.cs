using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    /// <summary>
    /// Classe DAL para Telefone do Fornecedor
    /// </summary>
    class DaoTelefoneDoFornecedor
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoTelefoneDoFornecedor()
        {
            this._conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private readonly Conexao _conexao;

        /// <summary>
        /// Nome da tabela de Telefones do Cliente no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_TELEFONES_DO_FORNECEDOR";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um Telefone de Fornecedor na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pTelefoneDoFornecedor">Objeto DmoTelefoneDoFornecedor preenchido com Id do Fornecedor e Id do Telefone</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoTelefoneDoFornecedor pTelefoneDoFornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (FORNECEDOR, TELEFONE) VALUES (@FORNECEDOR, @TELEFONE)", await _conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@FORNECEDOR", pTelefoneDoFornecedor.Fornecedor.IdFornecedor).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@TELEFONE", pTelefoneDoFornecedor.IdTelefone).SqlDbType = SqlDbType.Int;

                await cmd.ExecuteNonQueryAsync();
                _conexao.Desconectar();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
