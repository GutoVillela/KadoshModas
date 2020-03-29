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
        /// Cadastra uma nova Marca
        /// </summary>
        /// <param name="pDmoMarca">Objeto DmoMarca preenchido</param>
        /// <returns>Retorna o Id da Marca cadastrada. Em caso de erro retorna null</returns>
        public int? Cadastrar(DmoMarca pDmoMarca)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME) VALUES (@NOME);", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", pDmoMarca.Nome).SqlDbType = SqlDbType.VarChar;

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
        /// Consulta todas as Marcas
        /// </summary>
        /// <returns>Retorna uma lista de DmoMarca com todas os Marcas cadastradas na base de dados</returns>
        public List<DmoMarca> Consultar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoMarca> listaDeMarcas = new List<DmoMarca>();

                while (dataReader.Read())
                {
                    DmoMarca marca = new DmoMarca
                    {
                        IdMarca = int.Parse(dataReader["ID_MARCA"].ToString()),
                        Nome = dataReader["NOME"].ToString(),
                        DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                        DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                    };

                    listaDeMarcas.Add(marca);
                }

                conexao.Desconectar();

                return listaDeMarcas;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta o último Id de Marca cadastrada na base
        /// </summary>
        /// <returns>Retorno último Id de Marca cadastrada na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_MARCA) AS ID FROM " + NOME_TABELA, conexao.Conectar());

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
