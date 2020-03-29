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
        /// <returns>Retorna o Id da Categoria cadastrada. Em caso de erro retorna null</returns>
        public int? Cadastrar(DmoCategoria pDmoCategoria)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME) VALUES (@NOME);", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", pDmoCategoria.Nome).SqlDbType = SqlDbType.VarChar;

                cmd.ExecuteNonQuery();
                conexao.Desconectar();

                return ConsultarUltimoId();
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta todas as Categorias cadastradas na base
        /// </summary>
        /// <returns>Retorna uma lista de DmoCategoria com todas os Categorias cadastradas na base de dados</returns>
        public List<DmoCategoria> Consultar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoCategoria> listaDeCategorias = new List<DmoCategoria>();

                while (dataReader.Read())
                {
                    DmoCategoria categoria = new DmoCategoria
                    {
                        IdCategoria = int.Parse(dataReader["ID_CATEGORIA"].ToString()),
                        Nome = dataReader["NOME"].ToString(),
                        DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                        DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                    };

                    listaDeCategorias.Add(categoria);
                }

                conexao.Desconectar();

                return listaDeCategorias;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta o último Id de Categoria cadastrada na base
        /// </summary>
        /// <returns>Retorno último Id de Categoria cadastrada na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_CATEGORIA) AS ID FROM " + NOME_TABELA, conexao.Conectar());

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                return int.Parse(dr[0].ToString());

            }
            catch
            {
                return 0;
            }
        }
        #endregion

    }
}
