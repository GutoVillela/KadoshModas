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
        private readonly Conexao conexao;

        /// <summary>
        /// Nome da tabela de Telefones no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_TELEFONES";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo telefone e associa a um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente</param>
        /// <param name="telefone">Número de telefone</param>
        /// <returns></returns>
        public bool Cadastrar(DmoTelefone dmoTelefone)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (CLIENTE, DDD, NUMERO, TIPO_TELEFONE, FALAR_COM) VALUES (@CLIENTE, @DDD, @NUMERO, @TIPO_TELEFONE, @FALAR_COM)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@CLIENTE", dmoTelefone.Cliente.IdCliente).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@DDD", dmoTelefone.DDD).SqlDbType = SqlDbType.Char;
                cmd.Parameters.AddWithValue("@NUMERO", dmoTelefone.Numero).SqlDbType = SqlDbType.Char;
                cmd.Parameters.AddWithValue("@TIPO_TELEFONE", (int) dmoTelefone.TipoDeTelefone).SqlDbType = SqlDbType.Int;
                
                if(dmoTelefone.FalarCom == null)
                    cmd.Parameters.AddWithValue("@FALAR_COM", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@FALAR_COM", dmoTelefone.FalarCom).SqlDbType = SqlDbType.VarChar;

                cmd.ExecuteNonQuery();
                conexao.Desconectar();
                return true;
            }
            catch (Exception erro)
            {
                return false;
            }
        }
        #endregion
    }
}
