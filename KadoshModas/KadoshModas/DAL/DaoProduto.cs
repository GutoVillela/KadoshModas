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
        /// Cadastra um novo Produto de forma assíncrona
        /// </summary>
        /// <param name="pDmoProduto">Objeto DmoProduto preenchido</param>
        /// <returns>Retorna o Id do Produto cadastrado. Em caso de erro retorna null</returns>
        public async Task<int?> CadastrarAsync(DmoProduto pDmoProduto)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME, PRECO, CODIGO_DE_BARRA, URL_FOTO, CATEGORIA, MARCA) VALUES (@NOME, @PRECO, @CODIGO_DE_BARRA, @URL_FOTO, @CATEGORIA, @MARCA);", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@NOME", pDmoProduto.Nome).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@PRECO", pDmoProduto.Preco).SqlDbType = SqlDbType.SmallMoney;

            if (string.IsNullOrEmpty(pDmoProduto.CodigoDeBarra))
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", pDmoProduto.CodigoDeBarra).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(pDmoProduto.UrlFoto))
                cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@URL_FOTO", pDmoProduto.UrlFoto).SqlDbType = SqlDbType.VarChar;

            if (pDmoProduto.Categoria == null || pDmoProduto.Categoria.Nome == null)
                cmd.Parameters.AddWithValue("@CATEGORIA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@CATEGORIA", pDmoProduto.Categoria.Nome).SqlDbType = SqlDbType.VarChar;

            if (pDmoProduto.Marca == null || pDmoProduto.Marca.Nome == null)
                cmd.Parameters.AddWithValue("@MARCA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@MARCA", pDmoProduto.Marca.Nome).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();

            return await ConsultarUltimoIdAsync();
        }

        /// <summary>
        /// Consulta todos os Produtos de forma assíncrona
        /// </summary>
        /// <param name="pNome">Se fornecido, busca os Produtos com Nomes que INICIAM com a cadeia de caracteres fornecida</param>
        /// <param name="pPrecoMax">Se fornecido, busca os Produtos com preço ATÉ o valor fornecido</param>
        /// <param name="pCodBarras">Se fornecido, busca os Produtos com o Código de Barras IGUAL ao valor fornecido</param>
        /// <param name="pCategorias">Se fornecido, busca os Produtos DENTRO das Categorias fornecidas</param>
        /// <param name="pBuscaProdutosSemCategoria">Se fornecido, define se busca incluirá Produtos sem Categoria</param>
        /// <param name="pMarcas">Se fornecido, busca os Produtos DENTRO das Marcas fornecidas</param>
        /// <param name="pBuscaProdutosSemMarca">Se fornecido, define se busca incluirá Produtos sem Marca</param>
        /// <param name="pBuscaInativos">Define se a busca retornará Produtos Inativos</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido</param>
        /// <returns>Retorna uma lista de DmoProduto com todos os Produtos cadastrados na base de dados</returns>
        public async Task<List<DmoProduto>> ConsultarAsync(string pNome = null, float? pPrecoMax = null, string pCodBarras = null, List<DmoCategoria> pCategorias = null, bool pBuscaProdutosSemCategoria = true, List<DmoMarca> pMarcas = null, bool pBuscaProdutosSemMarca = true, bool pBuscaInativos = false, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, await conexao.ConectarAsync());

            #region Filtros
            if (!string.IsNullOrEmpty(pNome))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNome + "%").SqlDbType = SqlDbType.VarChar;
            }

            if(pPrecoMax != null)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " PRECO <= @PRECO";
                cmd.Parameters.AddWithValue("@PRECO", pPrecoMax).SqlDbType = SqlDbType.SmallMoney;
            }

            if (!string.IsNullOrEmpty(pCodBarras))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " CODIGO_DE_BARRA = @CODIGO_DE_BARRA";
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", pCodBarras).SqlDbType = SqlDbType.VarChar;
            }

            if (pCategorias != null && pCategorias.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " (CATEGORIA IN (";

                for(int i = 0; i < pCategorias.Count; i++)
                {
                    if(i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@CATEGORIA" + i;
                    cmd.Parameters.AddWithValue("@CATEGORIA" + i, pCategorias[i].Nome).SqlDbType = SqlDbType.VarChar;
                }

                cmd.CommandText += ")";

                if (pBuscaProdutosSemCategoria)
                    cmd.CommandText += " OR CATEGORIA IS NULL";

                cmd.CommandText += ")";
            }

            if (pMarcas != null && pMarcas.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " (MARCA IN (";

                for (int i = 0; i < pMarcas.Count; i++)
                {
                    if (i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@MARCA" + i;
                    cmd.Parameters.AddWithValue("@MARCA" + i, pMarcas[i].Nome).SqlDbType = SqlDbType.VarChar;
                }

                cmd.CommandText += ")";

                if (pBuscaProdutosSemMarca)
                    cmd.CommandText += " OR MARCA IS NULL";

                cmd.CommandText += ")";
            }

            if (!pBuscaInativos)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " ATIVO = 1";
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
            List<DmoProduto> listaDeProdutos = new List<DmoProduto>();

            while (await dataReader.ReadAsync())
            {
                DmoProduto produto = new DmoProduto
                {
                    IdProduto = int.Parse(dataReader["ID_PRODUTO"].ToString()),
                    Nome = dataReader["NOME"].ToString(),
                    Preco = float.Parse(dataReader["PRECO"].ToString()),
                    CodigoDeBarra = dataReader["CODIGO_DE_BARRA"].ToString(),
                    UrlFoto = dataReader["URL_FOTO"].ToString(),
                    Categoria = string.IsNullOrEmpty(dataReader["CATEGORIA"].ToString()) ? null : new DmoCategoria { Nome = dataReader["CATEGORIA"].ToString() },
                    Marca = string.IsNullOrEmpty(dataReader["MARCA"].ToString()) ? null : new DmoMarca { Nome = dataReader["MARCA"].ToString() },
                    Ativo = bool.Parse(dataReader["ATIVO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                listaDeProdutos.Add(produto);
            }

            dataReader.Close();
            conexao.Desconectar();

            return listaDeProdutos;
        }

        /// <summary>
        /// Conta a quantidade de Produtos que correspondem à busca no banco de dados de Forma assíncrona
        /// </summary>
        /// <param name="pNome">Se fornecido, busca os Produtos com Nomes que iniciam com a cadeia de caracteres fornecida</param>
        /// <param name="pPrecoMax">Se fornecido, busca os Produtos com preço ATÉ o valor fornecido</param>
        /// <param name="pCodBarras">Se fornecido, busca os Produtos com o Código de Barras IGUAL ao valor fornecido</param>
        /// <param name="pCategorias">Se fornecido, busca os Produtos DENTRO das Categorias fornecidas</param>
        /// <param name="pMarcas">Se fornecido, busca os Produtos DENTRO das Marcas fornecidas</param>
        /// <param name="pBuscaInativos">Define se a busca retornará Produtos Inativos</param>
        /// <returns>Retorno a quantidade de Produtos encontrados que atendem aos critérios de busca</returns>
        public async Task<int> ContarProdutosAsync(string pNome = null, float? pPrecoMax = null, string pCodBarras = null, List<DmoCategoria> pCategorias = null, List<DmoMarca> pMarcas = null, bool pBuscaInativos = false)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(ID_PRODUTO) FROM " + NOME_TABELA, await conexao.ConectarAsync());

            #region Filtros
            if (!string.IsNullOrEmpty(pNome))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNome + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (pPrecoMax != null)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " PRECO <= @PRECO";
                cmd.Parameters.AddWithValue("@PRECO", pPrecoMax).SqlDbType = SqlDbType.SmallMoney;
            }

            if (!string.IsNullOrEmpty(pCodBarras))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " CODIGO_DE_BARRA = @CODIGO_DE_BARRA";
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", pCodBarras).SqlDbType = SqlDbType.VarChar;
            }

            if (pCategorias != null && pCategorias.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " CATEGORIA IN (";

                for (int i = 0; i < pCategorias.Count; i++)
                {
                    if (i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@CATEGORIA" + i;
                    cmd.Parameters.AddWithValue("@CATEGORIA" + i, pCategorias[i].Nome).SqlDbType = SqlDbType.VarChar;
                }

                cmd.CommandText += ")";
            }

            if (pMarcas != null && pMarcas.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " MARCA IN (";

                for (int i = 0; i < pMarcas.Count; i++)
                {
                    if (i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@MARCA" + i;
                    cmd.Parameters.AddWithValue("@MARCA" + i, pMarcas[i].Nome).SqlDbType = SqlDbType.VarChar;
                }

                cmd.CommandText += ")";
            }

            if (!pBuscaInativos)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " ATIVO = 1";
            }
            #endregion

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            await dataReader.ReadAsync();

            int qtdProdutos = Convert.ToInt32(dataReader[0]);

            dataReader.Close();
            conexao.Desconectar();

            return qtdProdutos;
        }

        /// <summary>
        /// Consulta um Produto específico por Id de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        /// <returns>Retorna um Produto específico</returns>
        public async Task<DmoProduto> ConsultarAsync(int pIdProduto)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE ID_PRODUTO = @ID_PRODUTO;", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@ID_PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            await dataReader.ReadAsync();
            
            DmoProduto produto = new DmoProduto
            {
                IdProduto = int.Parse(dataReader["ID_PRODUTO"].ToString()),
                Nome = dataReader["NOME"].ToString(),
                Preco = float.Parse(dataReader["PRECO"].ToString()),
                UrlFoto = dataReader["URL_FOTO"].ToString(),
                CodigoDeBarra = dataReader["CODIGO_DE_BARRA"].ToString(),
                Categoria = string.IsNullOrEmpty(dataReader["CATEGORIA"].ToString()) ? null : new DmoCategoria { Nome = dataReader["CATEGORIA"].ToString() },
                Marca = string.IsNullOrEmpty(dataReader["MARCA"].ToString()) ? null : new DmoMarca { Nome = dataReader["MARCA"].ToString() },
                Ativo = bool.Parse(dataReader["ATIVO"].ToString()),
                DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
            };

            dataReader.Close();
            conexao.Desconectar();

            return produto;
        }

        /// <summary>
        /// Atualiza o Produto de forma assíncrona
        /// </summary>
        /// <param name="pProduto">Objeto DmoProduto com informações do Produto e ID do Produto a ser atualizado</param>
        public async Task AtualizarAsync(DmoProduto pProduto)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET NOME = @NOME, PRECO = @PRECO, CODIGO_DE_BARRA = @CODIGO_DE_BARRA, URL_FOTO = @URL_FOTO, CATEGORIA = @CATEGORIA, MARCA = @MARCA WHERE ID_PRODUTO = @ID_PRODUTO", await conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@ID_PRODUTO", pProduto.IdProduto).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@NOME", pProduto.Nome).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@PRECO", pProduto.Preco).SqlDbType = SqlDbType.SmallMoney;

            if (string.IsNullOrEmpty(pProduto.CodigoDeBarra))
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", pProduto.CodigoDeBarra).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(pProduto.UrlFoto))
                cmd.Parameters.AddWithValue("@URL_FOTO", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@URL_FOTO", pProduto.UrlFoto).SqlDbType = SqlDbType.VarChar;

            if (pProduto.Categoria == null || pProduto.Categoria.Nome == null)
                cmd.Parameters.AddWithValue("@CATEGORIA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@CATEGORIA", pProduto.Categoria.Nome).SqlDbType = SqlDbType.VarChar;

            if (pProduto.Marca == null || pProduto.Marca.Nome == null)
                cmd.Parameters.AddWithValue("@MARCA", DBNull.Value).SqlDbType = SqlDbType.VarChar;
            else
                cmd.Parameters.AddWithValue("@MARCA", pProduto.Marca.Nome).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }

        /// <summary>
        /// Desativa o Produto de forma assíncrona
        /// </summary>
        /// <param name="pIdProduto">ID do Produto</param>
        public async Task DesativarProdutoAsync(int pIdProduto)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET ATIVO = 0 WHERE ID_PRODUTO = @ID_PRODUTO", await conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@ID_PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;
            
            await cmd.ExecuteNonQueryAsync();
            conexao.Desconectar();
        }

        /// <summary>
        /// Consulta o último Id de Produto cadastrado na base de forma assíncrona
        /// </summary>
        /// <returns>Retorno último Id de Produto cadastrado na base. Em caso de erro retorna null</returns>
        public async Task<int?> ConsultarUltimoIdAsync()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_PRODUTO) AS ID FROM " + NOME_TABELA, await conexao.ConectarAsync());

                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                await dr.ReadAsync();

                int id = int.Parse(dr[0].ToString());

                dr.Close();
                conexao.Desconectar();

                return id;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza a Url da Foto do Produto na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNovaUrlFoto">URL da novo foto</param>
        /// <param name="pIdProduto">Id do Produto</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task<bool> AtualizarFotoAsync(string pNovaUrlFoto, int? pIdProduto)
        {
            if (string.IsNullOrEmpty(pNovaUrlFoto) || pIdProduto == null)
                throw new ArgumentException("Os parâmetros pNovaUrlFoto e pIdProduto não podem ser nulos");
            try
            {
                SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET URL_FOTO = @URL_FOTO WHERE ID_PRODUTO = @ID_PRODUTO", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@URL_FOTO", pNovaUrlFoto).SqlDbType = SqlDbType.VarChar;
                cmd.Parameters.AddWithValue("@ID_PRODUTO", pIdProduto).SqlDbType = SqlDbType.Int;

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
        /// Verifica se código de barras já existe e está associado a um Produto
        /// </summary>
        /// <param name="pCodDeBarras">Código de Barras a consultar</param>
        /// <returns>Retorna true se código de barras já existe e false caso não exista</returns>
        public async Task<bool> VerificarSeCodDeBarrasExisteAsync(string pCodDeBarras)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT CODIGO_DE_BARRA FROM " + NOME_TABELA + " WHERE CODIGO_DE_BARRA = @CODIGO_DE_BARRA", await conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@CODIGO_DE_BARRA", pCodDeBarras).SqlDbType = SqlDbType.VarChar;

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            bool existeCodDeBarras = dataReader.HasRows;

            dataReader.Close();
            conexao.Desconectar();

            return existeCodDeBarras;

        }

        /// <summary>
        /// Consulta e retorna o valor do produto mais caro cadastrado na base de forma assíncrona
        /// </summary>
        /// <param name="pIncluirProdutosInativos">Define se busca incluirá valores de produtos inativos</param>
        /// <returns>Retorna maior valor de Produto encontrado.</returns>
        public async Task<double> ObterMaiorPrecoDeProdutoAsync(bool pIncluirProdutosInativos = false)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT MAX (PRECO) AS MAIOR_PRECO FROM " + NOME_TABELA, await conexao.ConectarAsync());

            if (!pIncluirProdutosInativos)
            {
                cmd.CommandText += " WHERE ATIVO = 1";
            }

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            await dataReader.ReadAsync();

            double maiorPreco;

            try
            {
                maiorPreco = Convert.ToDouble(dataReader["MAIOR_PRECO"]);
            }
            catch
            {
                maiorPreco = 0;
            }

            dataReader.Close();
            conexao.Desconectar();

            return maiorPreco;
        }
        #endregion
    }
}