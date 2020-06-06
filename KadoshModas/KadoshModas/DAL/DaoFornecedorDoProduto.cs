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
    /// Classe DAL para Fornecedor do Produto
    /// </summary>
    class DaoFornecedorDoProduto
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoFornecedorDoProduto()
        {
            this._conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao _conexao;

        /// <summary>
        /// Nome da tabela de Fornecedor do Produto no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_FORNECEDORES_DO_PRODUTO";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um Fornecedor para o Produto
        /// </summary>
        /// <param name="pIdFornecedor">ID do Fornecedor</param>
        /// <param name="pIdProduto">ID do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool CadastrarFornecedorDoProduto(int pIdFornecedor, int pIdProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (FORNECEDOR, PRODUTO) VALUES (@FORNECEDOR, @PRODUTO);", _conexao.Conectar());
                cmd.Parameters.AddWithValue("@FORNECEDOR", pIdFornecedor).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

                cmd.ExecuteNonQuery();
                _conexao.Desconectar();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Exclui todos os Fornecedores do Produto
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public void ExcluirFornecedoresDoProduto(int pIdProduto)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM " + NOME_TABELA + " WHERE PRODUTO = @PRODUTO", _conexao.Conectar());
            cmd.Parameters.AddWithValue("@PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

            cmd.ExecuteNonQuery();
            _conexao.Desconectar();
        }
        #endregion
    }
}
