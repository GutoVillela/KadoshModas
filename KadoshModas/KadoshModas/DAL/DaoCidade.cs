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
    /// Classe DAO para Cidade
    /// </summary>
    class DaoCidade
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoCidade()
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
        /// Nome da tabela de Cidades no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_CIDADES";
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta todas as Cidades de um determinado Estado
        /// </summary>
        /// <returns>Retorna uma lista de DmoCidade com todas as Cidades do Estado especificado</returns>
        public List<DmoCidade> ConsultarDoEstado(int pIdEstado)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " C WHERE C.UF = @ESTADO", conexao.Conectar());
                cmd.Parameters.AddWithValue("@ESTADO", pIdEstado).SqlDbType = SqlDbType.Int;

                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoCidade> listaDeCidades = new List<DmoCidade>();

                while (dataReader.Read())
                {
                    DmoCidade cidade = new DmoCidade
                    {
                        IdCidade = int.Parse(dataReader["ID_CIDADE"].ToString()),
                        Nome = dataReader["NOME"].ToString(),
                        Estado = new DmoEstado { IdEstado = int.Parse(dataReader["UF"].ToString()) },
                        IBGE = int.Parse(dataReader["IBGE"].ToString())
                    };

                    listaDeCidades.Add(cidade);
                }

                dataReader.Close();
                conexao.Desconectar();

                return listaDeCidades;
            }
            catch (Exception erro)
            {
                return null;
            }
        }
        #endregion
    }
}
