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
    /// Classe DAL para Produto
    /// </summary>
    class DaoProduto
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoProduto()
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
        /// Nome da tabela de Produtos no banco de dados
        /// </summary>
        private const string NOME_TABELA = "TB_PRODUTOS";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Produto
        /// </summary>
        /// <param name="pDmoProduto">Objeto DmoProduto preenchido</param>
        /// <returns>Retorna o Id do Produto cadastrado. Em caso de erro retorna null</returns>
        public int? Cadastrar(DmoProduto pDmoProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME, PRECO, URL_FOTO, CATEGORIA, MARCA) VALUES (@NOME, @PRECO, @URL_FOTO, @CATEGORIA, @MARCA);", conexao.Conectar());
                cmd.Parameters.AddWithValue("@NOME", pDmoProduto.Nome).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@PRECO", pDmoProduto.Preco).SqlDbType = SqlDbType.SmallMoney;

                if (string.IsNullOrEmpty(pDmoProduto.UrlFoto))
                    cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
                else
                    cmd.Parameters.AddWithValue("@URL_FOTO", pDmoProduto.UrlFoto).SqlDbType = SqlDbType.VarChar;

                if (pDmoProduto.Categoria == null || pDmoProduto.Categoria.IdCategoria == null)
                    cmd.Parameters.AddWithValue("@CATEGORIA", DBNull.Value).SqlDbType = SqlDbType.Int;
                else
                    cmd.Parameters.AddWithValue("@CATEGORIA", pDmoProduto.Categoria.IdCategoria).SqlDbType = SqlDbType.Int;

                if (pDmoProduto.Marca == null || pDmoProduto.Marca.IdMarca == null)
                    cmd.Parameters.AddWithValue("@MARCA", DBNull.Value).SqlDbType = SqlDbType.Int;
                else
                    cmd.Parameters.AddWithValue("@MARCA", pDmoProduto.Marca.IdMarca).SqlDbType = SqlDbType.Int;

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
        /// Consulta todos os Produtos
        /// </summary>
        /// <returns>Retorna uma lista de DmoProduto com todos os Produtos cadastrados na base de dados</returns>
        public List<DmoProduto> Consultar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<DmoProduto> listaDeProdutos = new List<DmoProduto>();

                while (dataReader.Read())
                {
                    DmoProduto produto = new DmoProduto
                    {
                        IdProduto = int.Parse(dataReader["ID_PRODUTO"].ToString()),
                        Nome = dataReader["NOME"].ToString(),
                        Preco = float.Parse(dataReader["PRECO"].ToString()),
                        UrlFoto = dataReader["URL_FOTO"].ToString(),
                        DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                        DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                    };

                    if (int.TryParse(dataReader["CATEGORIA"].ToString(), out int idCategoria))
                        produto.Categoria = new DmoCategoria { IdCategoria = idCategoria };

                    if (int.TryParse(dataReader["MARCA"].ToString(), out int idMarca))
                        produto.Marca = new DmoMarca { IdMarca = idMarca };

                    listaDeProdutos.Add(produto);
                }

                conexao.Desconectar();

                return listaDeProdutos;
            }
            catch (Exception erro)
            {
                return null;
            }
        }

        /// <summary>
        /// Consulta o último Id de Produto cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de Produto cadastrado na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_PRODUTO) AS ID FROM " + NOME_TABELA, conexao.Conectar());

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                return int.Parse(dr[0].ToString());

            }
            catch
            {
                return 0;
            }
        }

        //// <summary>
        /// Atualiza a Url da Foto do Produto na base de dados
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdProduto">Id do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool AtualizarFoto(string pNovaUrlFoto, int? pIdProduto)
        {
            if (string.IsNullOrEmpty(pNovaUrlFoto) || pIdProduto == null)
                throw new ArgumentException("Os parâmetros pNovaUrlFoto e pIdProduto não podem ser nulos");
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET URL_FOTO = @URL_FOTO WHERE ID_PRODUTO = @ID_PRODUTO", conexao.Conectar());
                cmd.Parameters.AddWithValue("@URL_FOTO", pNovaUrlFoto).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@ID_PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

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
        /// Cadastra um Fornecedor para o Produto
        /// </summary>
        /// <param name="pIdFornecedor">ID do Fornecedor</param>
        /// <param name="IdProduto">ID do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public bool CadastrarFornecedorDoProduto(int pIdFornecedor, int pIdProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO TB_FORNECEDORES_DO_PRODUTO (FORNECEDOR, PRODUTO) VALUES (@FORNECEDOR, @PRODUTO);", conexao.Conectar());
                cmd.Parameters.AddWithValue("@FORNECEDOR", pIdFornecedor).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

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