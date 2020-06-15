using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace KadoshModas.DAL
{
    /// <summary>
    /// Classe responsável por realizar a conexão com o banco de dados
    /// </summary>
    class Conexao
    {
        /// <summary>
        /// Inicializa uma conexão com o banco de dados
        /// </summary>
        public Conexao()
        {
            string stringDeConexao = Properties.Settings.Default.StringDeConexaoKadosh;
            
            if(string.IsNullOrEmpty(stringDeConexao))
                stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["BD_KADOSH"].ConnectionString;

            this._conexao = new SqlConnection(stringDeConexao);
        }

        private SqlConnection _conexao;

        /// <summary>
        /// Abre a conexão com o Banco de Dados de forma assícrona
        /// </summary>
        /// <returns>Retorna conexão aberta. Retorna null em caso de erro</returns>
        public async Task<SqlConnection> ConectarAsync()
        {
            try
            {
                if (this._conexao.State != ConnectionState.Open)
                    await this._conexao.OpenAsync();

                return this._conexao;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Fecha a conexão com o Banco de Dados
        /// </summary>
        /// <returns>Retorna uma conexão fechada. Retorna null em caso de erro</returns>
        public SqlConnection Desconectar()
        {
            try
            {
                if (this._conexao.State != ConnectionState.Closed)
                    this._conexao.Close();

                return this._conexao;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verifica se o Banco de Dados já existe
        /// </summary>
        /// <returns>Retorna true caso banco de dados exista e false caso não exista</returns>
        public bool VerificaSeBancoJaExiste()
        {
            bool retorno = false;

            string stringDeConexao = System.Configuration.ConfigurationManager.ConnectionStrings["master"].ConnectionString;
            using (var conn = new SqlConnection(stringDeConexao))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT 1 FROM SYS.DATABASES WHERE NAME LIKE 'BD_KADOSH'";

                    var valor = cmd.ExecuteScalar();

                    if (valor != null && valor != DBNull.Value && Convert.ToInt32(valor).Equals(1))
                    {
                        retorno = true;
                    }
                }
            }

            return retorno;
        }
    }
}
