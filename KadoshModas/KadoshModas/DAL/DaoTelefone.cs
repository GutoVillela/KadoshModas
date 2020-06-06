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
        /// Cadastra um novo Telefone na base de dados
        /// </summary>
        /// <param name="dmoTelefone">Objeto DmoTelefone preenchido</param>
        /// <returns></returns>
        public int? Cadastrar(DmoTelefone dmoTelefone)
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

        /// <summary>
        /// Consulta o ID de um Telefone na base de dados.
        /// </summary>
        /// <param name="pDDD">DDD do Telefone</param>
        /// <param name="pNumero">Número do Telefone</param>
        /// <returns>Retorna o ID do Telefone. Caso o Telefone não exista, retorna null.</returns>
        public int? ConsultaIdTelefone(string pDDD, string pNumero)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT ID_TELEFONE FROM " + NOME_TABELA + " WHERE DDD = @DDD AND NUMERO = @NUMERO", conexao.Conectar());
                cmd.Parameters.AddWithValue("@DDD", pDDD).SqlDbType = SqlDbType.Char;
                cmd.Parameters.AddWithValue("@NUMERO", pNumero).SqlDbType = SqlDbType.Char;

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                return int.Parse(dr[0].ToString());
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Exlcuir o Telefone especificado
        /// </summary>
        /// <param name="pIdTelefone">Id do Telefone</param>
        public void Excluir(int pIdTelefone)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM " + NOME_TABELA + " WHERE ID_TELEFONE = @ID_TELEFONE;", conexao.Conectar());
            cmd.Parameters.AddWithValue("@ID_TELEFONE", pIdTelefone).SqlDbType = SqlDbType.Int;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        /// <summary>
        /// Excluir todos os Telefones relacionados ao Cliente
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        public void ExcluirTelefonesDoCliente(int pIdCliente)
        {
            SqlCommand cmd = new SqlCommand(@"DELETE FROM " + NOME_TABELA + " WHERE ID_TELEFONE IN (SELECT TELEFONE FROM TB_TELEFONES_DO_CLIENTE WHERE CLIENTE = @CLIENTE)", conexao.Conectar());
            cmd.Parameters.AddWithValue("@CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

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
