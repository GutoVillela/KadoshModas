using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    class DaoEstado
    {
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoEstado()
        {
            this.conexao = new Conexao();
        }

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;

        /// <summary>
        /// Nome da tabela de Estados no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_ESTADOS";
        #endregion

        #region Métodos
        /// <summary>
        /// Consulta todos os Estados de forma assíncrona
        /// </summary>
        /// <returns>Retorna uma lista de DmoEstado com todos os Estados da base</returns>
        public async Task<List<DmoEstado>> ConsultarAsync()
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, await conexao.ConectarAsync());
            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoEstado> listaDeEstados = new List<DmoEstado>();

            while (await dataReader.ReadAsync())
            {
                DmoEstado estado = new DmoEstado
                {
                    IdEstado = int.Parse(dataReader["ID_ESTADO"].ToString()),
                    Nome = dataReader["NOME"].ToString(),
                    UF = dataReader["UF"].ToString(),
                    IBGE = int.Parse(dataReader["IBGE"].ToString()),
                    DDD = dataReader["DDD"].ToString()
                };

                int idPais;
                if (int.TryParse(dataReader["PAIS"].ToString(), out idPais))
                    estado.Pais = new DmoPais { IdPais = idPais };

                listaDeEstados.Add(estado);
            }

            conexao.Desconectar();

            return listaDeEstados;
        }
        #endregion
    }
}
