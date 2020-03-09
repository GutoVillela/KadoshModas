using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    class DaoTelefone
    {
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoTelefone()
        {
            this.conexao = new Conexao();
        }

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo telefone e associa a um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="telefone">Número de telefone</param>
        /// <returns></returns>
        public bool Cadastrar(int idCliente, string telefone)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_TELEFONES (CLIENTE, NUMERO) VALUES (@CLIENTE, @NUMERO)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@CLIENTE", idCliente).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@NUMERO", telefone).SqlDbType = SqlDbType.Char;

                cmd.ExecuteNonQuery();
                conexao.Desconectar();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
