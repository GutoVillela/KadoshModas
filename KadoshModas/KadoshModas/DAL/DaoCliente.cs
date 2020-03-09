using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KadoshModas.DAL
{
    class DaoCliente
    {
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoCliente()
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
        /// Cadastra um novo Cliente somente com o campo Nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de falha</returns>
        public bool Cadastrar(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_CLIENTES (NOME) VALUES (@NOME)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", nome).SqlDbType = SqlDbType.VarChar;

                cmd.ExecuteNonQuery();

                conexao.Desconectar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cadastra um novo cliente com Nome e E-mail
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de falha</returns>
        public bool Cadastrar(string nome, string email)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_CLIENTES (NOME, EMAIL) VALUES (@NOME, @EMAIL)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", nome).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EMAIL", email).SqlDbType = SqlDbType.VarChar;

                cmd.ExecuteNonQuery();

                conexao.Desconectar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cadastra um novo cliente com Nome, E-mail e CPF
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="cpf">CPF do cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de falha</returns>
        public bool Cadastrar(string nome, string email, string cpf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_CLIENTES (NOME, EMAIL, CPF) VALUES (@NOME, @EMAIL, @CPF)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", nome).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EMAIL", email).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@CPF", cpf).SqlDbType = SqlDbType.Char;

                cmd.ExecuteNonQuery();

                conexao.Desconectar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="nome">Nome do cliente</param>
        /// <param name="email">E-mail do cliente</param>
        /// <param name="cpf">CPF do cliente</param>
        /// <param name="dmoTelefones">Lista de Telefones</param>
        /// <returns></returns>
        public bool Cadastrar(string nome, string email, string cpf, List<DmoTelefone> dmoTelefones)
        {
            try
            {
                if (dmoTelefones == null || dmoTelefones.Count == 0)
                    return false;

                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_CLIENTES (NOME, EMAIL, CPF) VALUES (@NOME, @EMAIL, @CPF)", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", nome).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@EMAIL", email).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@CPF", cpf).SqlDbType = SqlDbType.Char;

                cmd.ExecuteNonQuery();

                conexao.Desconectar();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta o último Id de cliente cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de cliente cadastrado na base</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_CLIENTE) AS ID FROM TB_CLIENTES", conexao.Conectar());

            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
