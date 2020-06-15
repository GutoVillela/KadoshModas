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
        /// Consulta todas as Cidades de um determinado Estado de forma assíncrona
        /// </summary>
        /// <param name="pIdEstado">Id do Estado</param>
        /// <returns>Retorna uma lista de DmoCidade com todas as Cidades do Estado especificado</returns>
        public async Task<List<DmoCidade>> ConsultarDoEstadoAsync(int pIdEstado)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " C WHERE C.UF = @ESTADO", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@ESTADO", pIdEstado).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoCidade> listaDeCidades = new List<DmoCidade>();

            while (await dataReader.ReadAsync())
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

        /// <summary>
        /// Consulta uma Cidade específica de forma assíncrona
        /// </summary>
        /// <param name="pIdCidade">Id da Cidade</param>
        /// <returns>Retorna Cidade Preenchida</returns>
        public async Task<DmoCidade> ConsultarCidadeAsync(int pIdCidade)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " C WHERE C.ID_CIDADE = @ID_CIDADE", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@ID_CIDADE", pIdCidade).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            await dataReader.ReadAsync();

            DmoCidade cidade = new DmoCidade
            {
                IdCidade = int.Parse(dataReader["ID_CIDADE"].ToString()),
                Nome = dataReader["NOME"].ToString(),
                Estado = new DmoEstado { IdEstado = int.Parse(dataReader["UF"].ToString()) },
                IBGE = int.Parse(dataReader["IBGE"].ToString())
            };

            dataReader.Close();
            conexao.Desconectar();

            return cidade;
        }
        #endregion
    }
}
