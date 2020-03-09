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
            string stringDeConexao = "Data Source="+ this.dataSource +";Initial Catalog=" + this.nomeBD + ";Integrated Security=true";
            this.conexao = new SqlConnection(stringDeConexao);
        }

        #region Atributos para Conexão
        /// <summary>
        /// Data Source do banco de dados
        /// </summary>
        private readonly string dataSource = "(localdb)\\MSSQLLocalDb";

        /// <summary>
        /// Nome do banco de dados
        /// </summary>
        private readonly string nomeBD = "BD_KADOSH";
        #endregion

        private SqlConnection conexao;

        /// <summary>
        /// Abre a conexão com o Banco de Dados
        /// </summary>
        /// <returns>Retorna conexão aberta. Retorna null em caso de erro</returns>
        public SqlConnection Conectar()
        {
            try
            {
                if (this.conexao.State != ConnectionState.Open)
                    this.conexao.Open();

                return this.conexao;
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
                if (this.conexao.State != ConnectionState.Closed)
                    this.conexao.Close();

                return this.conexao;
            }
            catch
            {
                return null;
            }
        }
    }
}
