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

        /// <summary>
        /// Nome da tabela de Clientes no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_CLIENTES";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Cliente 
        /// </summary>
        /// <param name="dmoCliente">Objeto DmoCliente preenchido</param>
        /// <returns>Retorna o Id do Cliente cadastrado. Em caso de erro retorna null</returns>
        public int? Cadastrar(DmoCliente dmoCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME, EMAIL, CPF, SEXO, ENDERECO, URL_FOTO) VALUES (@NOME, @EMAIL, @CPF, @SEXO, @ENDERECO, @URL_FOTO);", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", dmoCliente.Nome).SqlDbType = SqlDbType.VarChar;

                if(string.IsNullOrEmpty(dmoCliente.Email))
                    cmd.Parameters.AddWithValue("@EMAIL", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@EMAIL", dmoCliente.Email).SqlDbType = SqlDbType.VarChar;

                if(string.IsNullOrEmpty(dmoCliente.CPF))
                    cmd.Parameters.AddWithValue("@CPF", DBNull.Value).SqlDbType = SqlDbType.Char;
                else
                    cmd.Parameters.AddWithValue("@CPF", dmoCliente.CPF).SqlDbType = SqlDbType.Char;

                cmd.Parameters.AddWithValue("@SEXO", (int) dmoCliente.Sexo).SqlDbType = SqlDbType.Int;


                if (dmoCliente.Endereco == null)
                    cmd.Parameters.AddWithValue("@ENDERECO", DBNull.Value).SqlDbType = SqlDbType.Int;
                else
                    cmd.Parameters.AddWithValue("@ENDERECO", dmoCliente.Endereco.IdEndereco).SqlDbType = SqlDbType.Int;

                if (string.IsNullOrEmpty(dmoCliente.UrlFoto))
                    cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@URL_FOTO", dmoCliente.UrlFoto).SqlDbType = SqlDbType.VarChar;

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
        /// Consulta todos os clientes
        /// </summary>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public List<DmoCliente> Consultar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoCliente> listaDeClientes = new List<DmoCliente>();

                while (dataReader.Read())
                {
                    DmoCliente cliente = new DmoCliente();
                    cliente.IdCliente = int.Parse(dataReader["ID_CLIENTE"].ToString());
                    cliente.Nome = dataReader["NOME"].ToString();
                    cliente.Email = dataReader["EMAIL"].ToString();
                    cliente.CPF = dataReader["CPF"].ToString();
                    cliente.DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString());
                    cliente.DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString());

                    listaDeClientes.Add(cliente);
                }

                conexao.Desconectar();

                return listaDeClientes;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta todos os clientes cujo nomes iniciam com o termo informado
        /// </summary>
        /// <param name="pNome">Nome a ser buscado</param>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public List<DmoCliente> Consultar(string pNome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " C JOIN TB_TELEFONES T ON C.ID_CLIENTE = T.CLIENTE WHERE C.NOME LIKE @NOME;", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", pNome + "%").SqlDbType = SqlDbType.VarChar;
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoCliente> listaDeClientes = new List<DmoCliente>();

                while (dataReader.Read())
                {
                    DmoCliente cliente = new DmoCliente();
                    cliente.IdCliente = int.Parse(dataReader["ID_CLIENTE"].ToString());
                    cliente.Nome = dataReader["NOME"].ToString();
                    cliente.Email = dataReader["EMAIL"].ToString();
                    cliente.CPF = dataReader["CPF"].ToString();
                    cliente.DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString());
                    cliente.DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString());

                    listaDeClientes.Add(cliente);
                }

                conexao.Desconectar();

                return listaDeClientes;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta o último Id de Cliente cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de cliente cadastrado na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_CLIENTE) AS ID FROM " + NOME_TABELA, conexao.Conectar());

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
