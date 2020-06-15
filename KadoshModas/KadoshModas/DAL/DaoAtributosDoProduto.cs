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
    /// Classe DAL para Atributos do Produto
    /// </summary>
    class DaoAtributosDoProduto
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoAtributosDoProduto()
        {
            this.conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private readonly Conexao conexao;

        /// <summary>
        /// Nome da tabela de Produtos no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_ATRIBUTOS_DO_PRODUTO";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Atributo de Produto
        /// </summary>
        /// <param name="pDmoAtributosDoProduto">Objeto DmoAtributosDoProduto preenchido</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoAtributosDoProduto pDmoAtributosDoProduto)
        {
            if (pDmoAtributosDoProduto.Atributo == null || pDmoAtributosDoProduto.Produto == null)
                throw new ArgumentNullException("As propriedades Atributo e Produto em pDmoAtributosDoProduto não podem ser nulas");

            if (pDmoAtributosDoProduto.Atributo.IdAtributo == null || pDmoAtributosDoProduto.Produto.IdProduto == null)
                throw new ArgumentNullException("É obrigatório fornecer os IDs das propriedades Atributo e Produto em pDmoAtributosDoProduto");

            if (string.IsNullOrEmpty(pDmoAtributosDoProduto.Valor))
                throw new ArgumentException("É obrigatório fornecer um Valor para pDmoAtributosDoProduto");

            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (PRODUTO, ATRIBUTO, VALOR) VALUES (@PRODUTO, @ATRIBUTO, @VALOR);", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@PRODUTO", pDmoAtributosDoProduto.Produto.IdProduto).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@ATRIBUTO", pDmoAtributosDoProduto.Atributo.IdAtributo).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@VALOR", pDmoAtributosDoProduto.Valor).SqlDbType = SqlDbType.VarChar;

                await cmd.ExecuteNonQueryAsync();
                conexao.Desconectar();

                return true;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// Exclui todos os Atributos do Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public async Task ExcluirAtributosDoProdutoAsync(int pIdProduto)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM " + NOME_TABELA + " WHERE PRODUTO = @PRODUTO", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }
        #endregion
    }
}
