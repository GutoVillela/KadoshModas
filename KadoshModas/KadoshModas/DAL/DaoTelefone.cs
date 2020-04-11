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
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoTelefone()
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
        public int? Cadastrar(DmoTelefone dmoTelefone)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (DDD, NUMERO, TIPO_TELEFONE, FALAR_COM) VALUES (@DDD, @NUMERO, @TIPO_TELEFONE, @FALAR_COM)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@DDD", dmoTelefone.DDD).SqlDbType = SqlDbType.Char;
                cmd.Parameters.AddWithValue("@NUMERO", dmoTelefone.Numero).SqlDbType = SqlDbType.Char;
                cmd.Parameters.AddWithValue("@TIPO_TELEFONE", (int) dmoTelefone.TipoDeTelefone).SqlDbType = SqlDbType.Int;
                
                if(dmoTelefone.FalarCom == null)
                    cmd.Parameters.AddWithValue("@FALAR_COM", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@FALAR_COM", dmoTelefone.FalarCom).SqlDbType = SqlDbType.VarChar;

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
        /// Consulta o último Id de Telefone cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de cliente cadastrado na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_TELEFONE) AS ID FROM " + NOME_TABELA, conexao.Conectar());

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
