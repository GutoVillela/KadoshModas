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
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoCliente()
        {
            this.conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;

        /// <summary>
        /// Nome da tabela de Clientes no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_CLIENTES";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Cliente de forma assíncrona
        /// </summary>
        /// <param name="dmoCliente">Objeto DmoCliente preenchido</param>
        /// <returns>Retorna o Id do Cliente cadastrado.</returns>
        public async Task<int?> CadastrarAsync(DmoCliente dmoCliente)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME, EMAIL, CPF, SEXO, ENDERECO, URL_FOTO) VALUES (@NOME, @EMAIL, @CPF, @SEXO, @ENDERECO, @URL_FOTO);", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@NOME", dmoCliente.Nome).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(dmoCliente.Email))
                cmd.Parameters.AddWithValue("@EMAIL", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@EMAIL", dmoCliente.Email).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(dmoCliente.CPF))
                cmd.Parameters.AddWithValue("@CPF", DBNull.Value).SqlDbType = SqlDbType.Char;
            else
                cmd.Parameters.AddWithValue("@CPF", dmoCliente.CPF).SqlDbType = SqlDbType.Char;

            cmd.Parameters.AddWithValue("@SEXO", (int)dmoCliente.Sexo).SqlDbType = SqlDbType.Int;


            if (dmoCliente.Endereco == null)
                cmd.Parameters.AddWithValue("@ENDERECO", DBNull.Value).SqlDbType = SqlDbType.Int;
            else
                cmd.Parameters.AddWithValue("@ENDERECO", dmoCliente.Endereco.IdEndereco).SqlDbType = SqlDbType.Int;

            if (string.IsNullOrEmpty(dmoCliente.UrlFoto))
                cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@URL_FOTO", dmoCliente.UrlFoto).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();

            return await ConsultarUltimoIdAsync();
        }

        /// <summary>
        /// Consulta todos os clientes de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Se informado busca o Cliente exato pelo Id</param>
        /// <param name="pNome">Se informado, filtra a busca por Nome do Cliente que inicia com os caracteres informados</param>
        /// <param name="pEmail">Se informado, filtra a busca pelo Email que inicia com os caracteres informados</param>
        /// <param name="pCpf">Se informado, filtra a busca pelo CPF que inicia com os caracteres informados</param>
        /// <param name="pSexo">Se informado, filtra a busca pelo Sexo informado</param>
        /// <param name="pBuscarClienteIndefinido">Define se busca retornará o Cliente Indefinido</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes desativados</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido</param>
        /// <returns>Retorna uma lista de DmoCliente com todos os clientes da base</returns>
        public async Task<List<DmoCliente>> ConsultarAsync(int? pIdCliente = null, string pNome = null, string pEmail = null, string pCpf = null, Sexo? pSexo = null, bool pBuscarClienteIndefinido = true, bool pBuscaClientesDesativados = false, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, await conexao.ConectarAsync());
            
            

            #region Filtros
            if (pIdCliente != null)
            {
                cmd.CommandText += " WHERE";

                cmd.CommandText += " ID_CLIENTE = @ID_CLIENTE";
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;
            }

            if (!string.IsNullOrEmpty(pNome))
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNome + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (!string.IsNullOrEmpty(pEmail))
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " EMAIL LIKE @EMAIL";
                cmd.Parameters.AddWithValue("@EMAIL", pEmail + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (!string.IsNullOrEmpty(pCpf))
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " CPF LIKE @CPF";
                cmd.Parameters.AddWithValue("@CPF", pCpf + "%").SqlDbType = SqlDbType.VarChar;
            }

            if(pSexo != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " SEXO = @SEXO";
                cmd.Parameters.AddWithValue("@SEXO", (int) pSexo).SqlDbType = SqlDbType.Int;
            }

            if (!pBuscaClientesDesativados)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " ATIVO = 1";
            }

            if (!pBuscarClienteIndefinido)
            {
                if(cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " ID_CLIENTE != @ID_CLIENTE_INDEFINIDO";
                cmd.Parameters.AddWithValue("@ID_CLIENTE_INDEFINIDO", DmoCliente.IdClienteIndefinido).SqlDbType = SqlDbType.Int;
            }
            #endregion

            #region Ordenação
            cmd.CommandText += " ORDER BY NOME";
            #endregion

            #region Paginação
            if (pAPartirDoRegistro != null)
            {
                cmd.CommandText += " OFFSET @A_PARTIR_DO_REGISTRO ROWS";
                cmd.Parameters.AddWithValue("@A_PARTIR_DO_REGISTRO", pAPartirDoRegistro).SqlDbType = SqlDbType.Int;
            }

            if (pAteORegistro != null)
            {
                cmd.CommandText += " FETCH NEXT @ATE_O_REGISTRO ROWS ONLY";
                cmd.Parameters.AddWithValue("@ATE_O_REGISTRO", pAteORegistro).SqlDbType = SqlDbType.Int;
            }
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoCliente> listaDeClientes = new List<DmoCliente>();

            while (await dataReader.ReadAsync())
            {
                DmoCliente cliente = new DmoCliente();
                cliente.IdCliente = int.Parse(dataReader["ID_CLIENTE"].ToString());
                cliente.Nome = dataReader["NOME"].ToString();
                cliente.Email = dataReader["EMAIL"].ToString();
                cliente.CPF = dataReader["CPF"].ToString();
                cliente.Sexo = string.IsNullOrEmpty(dataReader["SEXO"].ToString()) ? Sexo.Masculino : (Sexo) int.Parse(dataReader["SEXO"].ToString());
                cliente.Endereco = string.IsNullOrEmpty(dataReader["ENDERECO"].ToString()) ? null : new DmoEndereco { IdEndereco = int.Parse(dataReader["ENDERECO"].ToString()) };
                cliente.UrlFoto = dataReader["URL_FOTO"].ToString();
                cliente.Ativo = bool.Parse(dataReader["ATIVO"].ToString());
                cliente.DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString());
                cliente.DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString());

                listaDeClientes.Add(cliente);
            }

            dataReader.Close();
            conexao.Desconectar();

            return listaDeClientes;
        }

        /// <summary>
        /// Busca o Endereço de um determinado Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">ID do Cliente</param>
        /// <returns>Retorna um objeto DmoEndereco preenchido. Caso o Cliente especificado não possua Endereço cadastrado o valor null é retornado.</returns>
        public async Task<DmoEndereco> ConsultarEnderecoDoClienteAsync(int pIdCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + DaoEndereco.NOME_TABELA + " E JOIN " + NOME_TABELA + " C ON C.ENDERECO = E.ID_ENDERECO WHERE ID_CLIENTE = @ID_CLIENTE;", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

                await dataReader.ReadAsync();

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

                dataReader.Close();
                conexao.Desconectar();

                return endereco;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza o Cliente de forma assíncrona
        /// </summary>
        /// <param name="dmoCliente">Objeto DmoCliente preenchido e com ID do Cliente válido</param>
        public async Task AtualizarAsync(DmoCliente pDmoCliente)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET NOME = @NOME, EMAIL = @EMAIL, CPF = @CPF, SEXO = @SEXO, ENDERECO = @ENDERECO, URL_FOTO = @URL_FOTO, ATIVO = @ATIVO, DT_ATUALIZACAO = GETDATE() WHERE ID_CLIENTE = @ID_CLIENTE;", await conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@ID_CLIENTE", pDmoCliente.IdCliente).SqlDbType = SqlDbType.Int;

            cmd.Parameters.AddWithValue("@NOME", pDmoCliente.Nome).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(pDmoCliente.Email))
                cmd.Parameters.AddWithValue("@EMAIL", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@EMAIL", pDmoCliente.Email).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(pDmoCliente.CPF))
                cmd.Parameters.AddWithValue("@CPF", DBNull.Value).SqlDbType = SqlDbType.Char;
            else
                cmd.Parameters.AddWithValue("@CPF", pDmoCliente.CPF).SqlDbType = SqlDbType.Char;

            cmd.Parameters.AddWithValue("@SEXO", (int)pDmoCliente.Sexo).SqlDbType = SqlDbType.Int;


            if (pDmoCliente.Endereco == null)
                cmd.Parameters.AddWithValue("@ENDERECO", DBNull.Value).SqlDbType = SqlDbType.Int;
            else
                cmd.Parameters.AddWithValue("@ENDERECO", pDmoCliente.Endereco.IdEndereco).SqlDbType = SqlDbType.Int;

            if (string.IsNullOrEmpty(pDmoCliente.UrlFoto))
                cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@URL_FOTO", pDmoCliente.UrlFoto).SqlDbType = SqlDbType.VarChar;

            cmd.Parameters.AddWithValue("@ATIVO", pDmoCliente.Ativo).SqlDbType = SqlDbType.Bit;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }

        /// <summary>
        /// Busca os Telefones de um determinado Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Id co Cliente</param>
        /// <returns>Retorna uma lista de Telefones do Cliente. Retorna null em caso de erro.</returns>
        public async Task<List<DmoTelefoneDoCliente>> ConsultarTelefonesDoClienteAsync(int pIdCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + DaoTelefoneDoCliente.NOME_TABELA + " TC JOIN " + NOME_TABELA + " C ON C.ID_CLIENTE = TC.CLIENTE JOIN " + DaoTelefone.NOME_TABELA + " T ON T.ID_TELEFONE = TC.TELEFONE WHERE ID_CLIENTE  = @ID_CLIENTE;", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

                SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

                List<DmoTelefoneDoCliente> listaDeTelefones = new List<DmoTelefoneDoCliente>();

                while (await dataReader.ReadAsync())
                {
                    DmoTelefoneDoCliente telefone = new DmoTelefoneDoCliente
                    {
                        Cliente = new DmoCliente { IdCliente = pIdCliente },
                        IdTelefone = int.Parse(dataReader["TELEFONE"].ToString()),
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
        /// Consulta o último Id de Cliente cadastrado na base de forma assíncrona
        /// </summary>
        /// <returns>Retorno último Id de cliente cadastrado na base. Em caso de erro retorna null</returns>
        private async Task<int?> ConsultarUltimoIdAsync()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_CLIENTE) AS ID FROM " + NOME_TABELA, await conexao.ConectarAsync());


                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                await dr.ReadAsync();

                int ultimoId = int.Parse(dr[0].ToString());

                dr.Close();
                conexao.Desconectar();

                return ultimoId;

            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Conta a quantidade de Clientes que correspondem à busca no banco de dados de Forma assíncrona
        /// <param name="pNome">Se informado, filtra a busca por Nome do Cliente que inicia com os caracteres informados</param>
        /// <param name="pEmail">Se informado, filtra a busca pelo Email que inicia com os caracteres informados</param>
        /// <param name="pCpf">Se informado, filtra a busca pelo CPF que inicia com os caracteres informados</param>
        /// <param name="pSexo">Se informado, filtra a busca pelo Sexo informado</param>
        /// <param name="pBuscarClienteIndefinido">Define se busca retornará o Cliente Indefinido</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes desativados</param>
        /// </summary>
        /// <returns>Retorno a quantidade de clientes encontrados que atendem aos critérios de busca</returns>
        public async Task<int> ContarClientesAsync(string pNome = null, string pEmail = null, string pCpf = null, Sexo? pSexo = null, bool pBuscarClienteIndefinido = true, bool pBuscaClientesDesativados = false)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(ID_CLIENTE) FROM " + NOME_TABELA, await conexao.ConectarAsync());

            #region Filtros
            if (!string.IsNullOrEmpty(pNome))
            {
                cmd.CommandText += " WHERE";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNome + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (!string.IsNullOrEmpty(pEmail))
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " EMAIL LIKE @EMAIL";
                cmd.Parameters.AddWithValue("@EMAIL", pEmail + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (!string.IsNullOrEmpty(pCpf))
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " CPF LIKE @CPF";
                cmd.Parameters.AddWithValue("@CPF", pCpf + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (pSexo != null)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " SEXO = @SEXO";
                cmd.Parameters.AddWithValue("@SEXO", (int)pSexo).SqlDbType = SqlDbType.Int;
            }

            if (!pBuscaClientesDesativados)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " ATIVO = 1";
            }

            if (!pBuscarClienteIndefinido)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " ID_CLIENTE != @ID_CLIENTE_INDEFINIDO";
                cmd.Parameters.AddWithValue("@ID_CLIENTE_INDEFINIDO", DmoCliente.IdClienteIndefinido).SqlDbType = SqlDbType.Int;
            }
            #endregion

            SqlDataReader dr = await cmd.ExecuteReaderAsync();

            await dr.ReadAsync();

            int quantidadeCliente = int.Parse(dr[0].ToString());

            dr.Close();
            conexao.Desconectar();

            return quantidadeCliente;
        }

        /// <summary>
        /// Atualiza a Url da Foto do Cliente na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> AtualizarFotoAsync(string pNovaUrlFoto, int? pIdCliente)
        {
            if (string.IsNullOrEmpty(pNovaUrlFoto) || pIdCliente == null)
                throw new ArgumentException("Os parâmetros pNovaUrlFoto e pIdCliente não podem ser nulos");
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET URL_FOTO = @URL_FOTO WHERE ID_CLIENTE = @ID_CLIENTE", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@URL_FOTO", pNovaUrlFoto).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

                await cmd.ExecuteNonQueryAsync();
                conexao.Desconectar();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Desativa o Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        public async Task DesativarClienteAsync(int pIdCliente)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + NOME_TABELA + " SET ATIVO = 0 WHERE ID_CLIENTE = @ID_CLIENTE", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("ID_CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }

        /// <summary>
        /// Verifica se o CPF informado existe na base de dados
        /// </summary>
        /// <param name="pCPF">CPF do Cliente</param>
        /// <returns>Retorna true caso CPF já exista na base de dados e false caso não exista</returns>
        public async Task<bool> VerificaCPFExistenteAsync(string pCPF)
        {
            SqlCommand cmd = new SqlCommand("SELECT CPF FROM " + NOME_TABELA + " WHERE CPF = @CPF", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@CPF", pCPF).SqlDbType = SqlDbType.Char;

            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            bool cpfExiste = dr.HasRows;

            dr.Close();
            conexao.Desconectar();

            return cpfExiste;
        }

        /// <summary>
        /// Conta os Clientes em situação de inadimplência.
        /// </summary>
        /// <param name="pDiasParaInadimplencia">Quantidade de dias sem lançamentos em Vendas em aberto para que Cliente seja considerado como inadimplente.</param>
        /// <param name="pBuscarClienteIndefinido">Define se busca retornará o Cliente Indefinido</param>
        /// <param name="pBuscaClientesDesativados">Define se busca retornará Clientes desativados</param>
        /// <returns></returns>
        public async Task<int> ContarClientesInadimplentesAsync(int pDiasParaInadimplencia, bool pBuscarClienteIndefinido = true, bool pBuscaClientesDesativados = false)
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(ID_CLIENTE) FROM " + NOME_TABELA, await conexao.ConectarAsync());

            #region Filtros
            if (!pBuscaClientesDesativados)
            {
                cmd.CommandText += " WHERE";

                cmd.CommandText += " ATIVO = 1";
            }

            if (!pBuscarClienteIndefinido)
            {
                if (cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " AND";
                else
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " ID_CLIENTE != @ID_CLIENTE_INDEFINIDO";
                cmd.Parameters.AddWithValue("@ID_CLIENTE_INDEFINIDO", DmoCliente.IdClienteIndefinido).SqlDbType = SqlDbType.Int;
            }
            #endregion

            SqlDataReader dr = await cmd.ExecuteReaderAsync();

            await dr.ReadAsync();

            int quantidadeCliente = int.Parse(dr[0].ToString());

            dr.Close();
            conexao.Desconectar();

            return quantidadeCliente;
        }
        #endregion
    }
}