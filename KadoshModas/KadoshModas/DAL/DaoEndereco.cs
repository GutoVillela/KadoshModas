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
    /// Classe DAO para Endereço
    /// </summary>
    class DaoEndereco
    {
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoEndereco()
        {
            this.conexao = new Conexao();
        }

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;

        /// <summary>
        /// Nome da tabela de Endereços no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_ENDERECOS";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Endereço 
        /// </summary>
        /// <param name="dmoCliente">Objeto DmoEndereco preenchido</param>
        /// <returns>Retorna o Id do Endereço cadastrado</returns>
        public int? Cadastrar(DmoEndereco dmoEndereco)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (RUA, BAIRRO, NUMERO, COMPLEMENTO, CEP, CIDADE) VALUES (@RUA, @BAIRRO, @NUMERO, @COMPLEMENTO, @CEP, @CIDADE);", conexao.Conectar());
                
                if(dmoEndereco.Rua == null)
                    cmd.Parameters.AddWithValue("@RUA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@RUA", dmoEndereco.Rua).SqlDbType = SqlDbType.VarChar;

                if (dmoEndereco.Bairro == null)
                    cmd.Parameters.AddWithValue("@BAIRRO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@BAIRRO", dmoEndereco.Rua).SqlDbType = SqlDbType.VarChar;

                if (dmoEndereco.Numero == null)
                    cmd.Parameters.AddWithValue("@NUMERO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@NUMERO", dmoEndereco.Numero).SqlDbType = SqlDbType.VarChar;

                if(dmoEndereco.Complemento == null)
                    cmd.Parameters.AddWithValue("@COMPLEMENTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@COMPLEMENTO", dmoEndereco.Complemento).SqlDbType = SqlDbType.VarChar;

                if(dmoEndereco.CEP == null)
                    cmd.Parameters.AddWithValue("@CEP", DBNull.Value).SqlDbType = SqlDbType.Char;
                else
                    cmd.Parameters.AddWithValue("@CEP", dmoEndereco.CEP).SqlDbType = SqlDbType.Char;

                if(dmoEndereco.Cidade == null)
                    cmd.Parameters.AddWithValue("@CIDADE", DBNull.Value).SqlDbType = SqlDbType.Int;
                else
                    cmd.Parameters.AddWithValue("@CIDADE", dmoEndereco.Cidade.IdCidade).SqlDbType = SqlDbType.Int;

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
        /// Busca o Endereço por ID
        /// </summary>
        /// <param name="pIdEndereco">ID do Endereço</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Retorna null em caso de erro.</returns>
        public DmoEndereco ConsultarEnderecoPorId(int pIdEndereco)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE ID_ENDERECO = @ID_ENDERECO;", conexao.Conectar());
                cmd.Parameters.AddWithValue("@ID_ENDERECO", pIdEndereco).SqlDbType = SqlDbType.Int;

                SqlDataReader dataReader = cmd.ExecuteReader();

                dataReader.Read();

                DmoEndereco endereco = new DmoEndereco
                {
                    IdEndereco = int.Parse(dataReader["ID_ENDERECO"].ToString()),
                    Rua = dataReader["RUA"].ToString(),
                    Bairro = dataReader["BAIRRO"].ToString(),
                    Numero = dataReader["NUMERO"].ToString(),
                    Complemento = dataReader["COMPLEMENTO"].ToString(),
                    CEP = dataReader["CEP"].ToString(),
                    Cidade = string.IsNullOrEmpty(dataReader["CIDADE"].ToString()) ? null : new DmoCidade { IdCidade = int.Parse(dataReader["CIDADE"].ToString()) },
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                return endereco;
            }
            catch(Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta o último Id de Endereço cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de Endereço cadastrado na base</returns>
        private int ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_ENDERECO) AS ID FROM " + NOME_TABELA, conexao.Conectar());
                
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
