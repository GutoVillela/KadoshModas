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
    /// Classe DAL para Marca
    /// </summary>
    class DaoMarca
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoMarca()
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
        /// Nome da tabela de Marcas no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_MARCAS";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra uma nova Marca de forma assíncrona
        /// </summary>
        /// <param name="pDmoMarca">Objeto DmoMarca preenchido</param>
        /// <returns>Retorna a Marca cadastrada.</returns>
        public async Task CadastrarAsync(DmoMarca pDmoMarca)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME) VALUES (@NOME);", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@NOME", pDmoMarca.Nome).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }

        /// <summary>
        /// Consulta todas as Marcas de forma assíncrona
        /// </summary>
        /// <param name="pNomeMarca">Se fornecido, busca somente as Marcas com nomes que iniciam com o valor fornecido</param>
        /// <returns>Retorna uma lista de DmoMarca com todas os Marcas cadastradas na base de dados</returns>
        public async Task<List<DmoMarca>> ConsultarAsync(string pNomeMarca = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, await conexao.ConectarAsync());

            if (!string.IsNullOrEmpty(pNomeMarca))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNomeMarca + "%").SqlDbType = SqlDbType.VarChar;
            }

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoMarca> listaDeMarcas = new List<DmoMarca>();

            while (await dataReader.ReadAsync())
            {
                DmoMarca marca = new DmoMarca
                {
                    Nome = dataReader["NOME"].ToString(),
                    Ativo = bool.Parse(dataReader["ATIVO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                listaDeMarcas.Add(marca);
            }

            conexao.Desconectar();

            return listaDeMarcas;
        }

        /// <summary>
        /// Atualiza a Marca de forma assíncrona
        /// </summary>
        /// <param name="pMarca">Objeto DmoMarca com as novas informações da Marca</param>
        /// <param name="pNomeMarca">Nome original da Marca antes da edição</param>
        public async Task AtualizarAsync(DmoMarca pMarca, string pNomeMarca)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET NOME = @NOME, ATIVO = @ATIVO, DT_ATUALIZACAO = GETDATE() WHERE NOME = @NOME_ORIGINAL", await conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@NOME", pMarca.Nome).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@ATIVO", pMarca.Ativo).SqlDbType = SqlDbType.Bit;
            cmd.Parameters.AddWithValue("@NOME_ORIGINAL", pNomeMarca).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }
        #endregion
    }
}
