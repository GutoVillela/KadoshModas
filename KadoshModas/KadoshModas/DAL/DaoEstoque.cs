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
    class DaoEstoque
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoEstoque()
        {
            this.conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;

        /// <summary>
        /// Nome da tabela de Estoque no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_ESTOQUE";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Estoque de forma assíncrona
        /// </summary>
        /// <param name="pDmoEstoque">Objeto DmoEstoque preenchido</param>
        /// <returns>Retorna o Id do Estoque cadastrado. Em caso de erro retorna null</returns>
        public async Task<int?> CadastrarAsync(DmoEstoque pDmoEstoque)
        {
            if(pDmoEstoque.Produto == null || pDmoEstoque.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pDmoEstoque deve estar preenchida com um ID de Produto");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (PRODUTO, QUANTIDADE, MINIMO) VALUES (@PRODUTO, @QUANTIDADE, @MINIMO);", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@PRODUTO", pDmoEstoque.Produto.IdProduto).SqlDbType = SqlDbType.Int;

            if (pDmoEstoque.Quantidade <= 0)
                cmd.Parameters.AddWithValue("@QUANTIDADE", 0).SqlDbType = SqlDbType.Int;
            else
                cmd.Parameters.AddWithValue("@QUANTIDADE", pDmoEstoque.Quantidade).SqlDbType = SqlDbType.Int;

            if (pDmoEstoque.Minimo <= 0)
                cmd.Parameters.AddWithValue("@MINIMO", 0).SqlDbType = SqlDbType.Int;
            else
                cmd.Parameters.AddWithValue("@MINIMO", pDmoEstoque.Minimo).SqlDbType = SqlDbType.Int;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();

            return await ConsultarUltimoIdAsync();
        }

        

        /// <summary>
        /// Consulta o último Id de Estoque cadastrado na base de forma assíncrona
        /// </summary>
        /// <returns>Retorno último Id de Estoque cadastrado na base. Em caso de erro retorna null</returns>
        private async Task<int?> ConsultarUltimoIdAsync()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_ESTOQUE) AS ID FROM " + NOME_TABELA, await conexao.ConectarAsync());

                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                await dr.ReadAsync();

                int id = int.Parse(dr[0].ToString());

                dr.Close();
                conexao.Desconectar();

                return id;

            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
