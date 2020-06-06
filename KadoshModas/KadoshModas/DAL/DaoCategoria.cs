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
    /// Classe DAL para Categoria
    /// </summary>
    class DaoCategoria
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoCategoria()
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
        /// Nome da tabela de Categorias no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_CATEGORIAS";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra uma nova Categoria
        /// </summary>
        /// <param name="pDmoCategoria">Objeto DmoCategoria preenchido</param>
        /// <returns>Retorna o Id da Categoria cadastrada.</returns>
        public void Cadastrar(DmoCategoria pDmoCategoria)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME) VALUES (@NOME);", conexao.Conectar());
            cmd.Parameters.AddWithValue("@NOME", pDmoCategoria.Nome).SqlDbType = SqlDbType.VarChar;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        /// <summary>
        /// Consulta todas as Categorias cadastradas na base
        /// </summary>
        /// <param name="pNomeCategoria">Se fornecido, busca somente as Categorias com nomes que iniciam com o valor fornecido</param>
        /// <returns>Retorna uma lista de DmoCategoria com todas os Categorias cadastradas na base de dados</returns>
        public List<DmoCategoria> Consultar(string pNomeCategoria = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());

            if (!string.IsNullOrEmpty(pNomeCategoria))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNomeCategoria + "%").SqlDbType = SqlDbType.VarChar;
            }

            SqlDataReader dataReader = cmd.ExecuteReader();

            List<DmoCategoria> listaDeCategorias = new List<DmoCategoria>();

            while (dataReader.Read())
            {
                DmoCategoria categoria = new DmoCategoria
                {
                    Nome = dataReader["NOME"].ToString(),
                    Ativo = bool.Parse(dataReader["ATIVO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                listaDeCategorias.Add(categoria);
            }

            conexao.Desconectar();

            return listaDeCategorias;
        }

        /// <summary>
        /// Atualiza a Categoria
        /// </summary>
        /// <param name="pCategoria">Objeto DmoCategoria com as novas informações da Categoria</param>
        /// <param name="pNomeCategoria">Nome original da Categoria antes da edição</param>
        public void Atualizar(DmoCategoria pCategoria, string pNomeCategoria)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET NOME = @NOME, ATIVO = @ATIVO, DT_ATUALIZACAO = GETDATE() WHERE NOME = @NOME_ORIGINAL", conexao.Conectar());

            cmd.Parameters.AddWithValue("@NOME", pCategoria.Nome).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@ATIVO", pCategoria.Ativo).SqlDbType = SqlDbType.Bit;
            cmd.Parameters.AddWithValue("@NOME_ORIGINAL", pNomeCategoria).SqlDbType = SqlDbType.VarChar;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        #endregion

    }
}
