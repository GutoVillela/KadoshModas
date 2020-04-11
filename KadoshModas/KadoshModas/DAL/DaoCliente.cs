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
        const string NOME_TABELA = "TB_CLIENTES";
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
                    cliente.Sexo = (DmoCliente.Sexos) int.Parse(dataReader["SEXO"].ToString());
                    cliente.Endereco = string.IsNullOrEmpty(dataReader["ENDERECO"].ToString()) ? null : new DmoEndereco { IdEndereco = int.Parse(dataReader["ENDERECO"].ToString()) };
                    cliente.UrlFoto = dataReader["URL_FOTO"].ToString();
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
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " C WHERE C.NOME LIKE @NOME;", conexao.Conectar());
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
                    cliente.Sexo = (DmoCliente.Sexos)int.Parse(dataReader["SEXO"].ToString());
                    cliente.Endereco = string.IsNullOrEmpty(dataReader["ENDERECO"].ToString()) ? null : new DmoEndereco { IdEndereco = int.Parse(dataReader["ENDERECO"].ToString()) };
                    cliente.UrlFoto = dataReader["URL_FOTO"].ToString();
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
        /// Busca o Endereço de um determinado Cliente
        /// </summary>
        /// <param name="pIdCliente">ID do Cliente</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Caso o Cliente especificado não possua Endereço cadastrado o valor null é retornado.</returns>
        public DmoEndereco ConsultarEnderecoDoCliente(int pIdCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + DaoEndereco.NOME_TABELA + " E JOIN " + NOME_TABELA + " C ON C.ENDERECO = E.ID_ENDERECO WHERE ID_CLIENTE = @ID_CLIENTE;", conexao.Conectar());
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

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
                    DataDeCriacao = DateTime.Parse(""),
                    DataDeAtualizacao = DateTime.Parse("")
                };

                return endereco;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Busca os Telefones de um determinado Cliente
        /// </summary>
        /// <param name="pIdCliente">Id co Cliente</param>
        /// <returns>Retorna uma lista de Telefones do Cliente. Retorna null em caso de erro.</returns>
        public List<DmoTelefoneDoCliente> ConsultarTelefonesDoCliente(int pIdCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + DaoTelefoneDoCliente.NOME_TABELA + " T JOIN " + NOME_TABELA + " C ON C.ID_CLIENTE = T.CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE;", conexao.Conectar());
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoTelefoneDoCliente> listaDeTelefones = new List<DmoTelefoneDoCliente>();

                while (dataReader.Read())
                {
                    DmoTelefoneDoCliente telefone = new DmoTelefoneDoCliente
                    {
                        Cliente = new DmoCliente { IdCliente = pIdCliente },
                        DDD = dataReader["DDD"].ToString(),
                        Numero = dataReader["NUMERO"].ToString(),
                        TipoDeTelefone = (DmoTelefone.TiposDeTelefone)int.Parse(dataReader["TIPO_TELEFONE"].ToString()),
                        FalarCom = dataReader["FALAR_COM"].ToString(),
                        DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                        DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                    };

                    listaDeTelefones.Add(telefone);
                }

                return listaDeTelefones;
            }
            catch
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

        /// <summary>
        /// Atualiza a Url da Foto do Cliente na base de dados
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool AtualizarFoto(string pNovaUrlFoto, int? pIdCliente)
        {
            if (string.IsNullOrEmpty(pNovaUrlFoto) || pIdCliente == null)
                throw new ArgumentException("Os parâmetros pNovaUrlFoto e pIdCliente não podem ser nulos");
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET URL_FOTO = @URL_FOTO WHERE ID_CLIENTE = @ID_CLIENTE", conexao.Conectar());
                cmd.Parameters.AddWithValue("@URL_FOTO", pNovaUrlFoto).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

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
