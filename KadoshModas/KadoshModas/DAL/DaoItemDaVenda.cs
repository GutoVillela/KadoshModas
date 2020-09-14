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
    /// Classe DAL para Item da Venda
    /// </summary>
    class DaoItemDaVenda : DaoBase
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoItemDaVenda()
        {
            this.Conexao = new Conexao();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Nome da tabela de Itens da Venda no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_ITENS_DA_VENDA";
        #endregion

        #region Propriedades
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        protected override Conexao Conexao { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Item Da Venda de forma assíncrona
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public async Task CadastrarAsync(DmoItemDaVenda pItemDaVenda)
        {

            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (VENDA, PRODUTO, QUANTIDADE, VALOR_ITEM, DESCONTO, SITUACAO_ITEM, DESCRICAO_SITUACAO_ITEM) VALUES (@VENDA, @PRODUTO, @QUANTIDADE, @VALOR_ITEM, @DESCONTO, @SITUACAO_ITEM, @DESCRICAO_SITUACAO_ITEM);", await Conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@VENDA", pItemDaVenda.Venda.IdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PRODUTO", pItemDaVenda.Produto.IdProduto).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@QUANTIDADE", pItemDaVenda.Quantidade).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@VALOR_ITEM", pItemDaVenda.Valor).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@DESCONTO", pItemDaVenda.Desconto).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@SITUACAO_ITEM", (int)pItemDaVenda.Situacao).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@DESCRICAO_SITUACAO_ITEM", TratarValorNulo(pItemDaVenda.DescricaoSituacao)).SqlDbType = SqlDbType.VarChar;

            await cmd.ExecuteNonQueryAsync();
            Conexao.Desconectar();
        }

        /// <summary>
        /// Consulta todos os Itens da Venda de uma Venda específica de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">Id da Venda</param>
        /// <returns>Lista de Itens da Venda</returns>
        public async Task<List<DmoItemDaVenda>> ConsultarItensDaVendaAsync(int pIdVenda)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE VENDA = @VENDA", await Conexao.ConectarAsync());
            cmd.Parameters.AddWithValue("@VENDA", pIdVenda).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = await cmd.ExecuteReaderAsync();

            List<DmoItemDaVenda> listaDeItensDaVenda = new List<DmoItemDaVenda>();

            while (await dataReader.ReadAsync())
            {
                DmoItemDaVenda itemDaVenda = new DmoItemDaVenda
                {
                    Venda = new DmoVenda() { IdVenda = int.Parse(dataReader["VENDA"].ToString()) },
                    Produto = new DmoProduto() { IdProduto = int.Parse(dataReader["PRODUTO"].ToString()) },
                    Quantidade = uint.Parse(dataReader["QUANTIDADE"].ToString()),
                    Valor = float.Parse(dataReader["VALOR_ITEM"].ToString()),
                    Desconto = string.IsNullOrEmpty(dataReader["DESCONTO"].ToString()) ? 0 : float.Parse(dataReader["DESCONTO"].ToString()),
                    Situacao = (SituacaoItemDaVenda)Convert.ToInt32(dataReader["SITUACAO_ITEM"]),
                    DescricaoSituacao = string.IsNullOrEmpty(dataReader["DESCRICAO_SITUACAO_ITEM"].ToString()) ? null : dataReader["DESCRICAO_SITUACAO_ITEM"].ToString(),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                listaDeItensDaVenda.Add(itemDaVenda);
            }

            dataReader.Close();
            Conexao.Desconectar();

            return listaDeItensDaVenda;
        }

        /// <summary>
        /// Atualiza o Item Da Venda de forma assíncrona
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public async Task AtualizarAsync(DmoItemDaVenda pItemDaVenda)
        {

            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET QUANTIDADE = @QUANTIDADE, VALOR_ITEM = @VALOR_ITEM, DESCONTO = @DESCONTO, DESCRICAO_SITUACAO_ITEM = @DESCRICAO_SITUACAO_ITEM WHERE VENDA = @VENDA AND PRODUTO = @PRODUTO AND SITUACAO_ITEM = @SITUACAO_ITEM", await Conexao.ConectarAsync());

            cmd.Parameters.AddWithValue("@QUANTIDADE", pItemDaVenda.Quantidade).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@VALOR_ITEM", pItemDaVenda.Valor).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@DESCONTO", pItemDaVenda.Desconto).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@SITUACAO_ITEM", (int)pItemDaVenda.Situacao).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@DESCRICAO_SITUACAO_ITEM", TratarValorNulo(pItemDaVenda.DescricaoSituacao)).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@VENDA", pItemDaVenda.Venda.IdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PRODUTO", pItemDaVenda.Produto.IdProduto).SqlDbType = SqlDbType.Int;

            await cmd.ExecuteNonQueryAsync();
            Conexao.Desconectar();
        }

        /// <summary>
        /// Apaga o Item Da Venda de forma assíncrona
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public async Task ApagarAsync(DmoItemDaVenda pItemDaVenda)
        {

            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            SqlCommand cmd = new SqlCommand(@"DELETE FROM " + NOME_TABELA + " WHERE VENDA = @VENDA AND PRODUTO = @PRODUTO AND SITUACAO_ITEM = @SITUACAO_ITEM", await Conexao.ConectarAsync());
            
            cmd.Parameters.AddWithValue("@VENDA", pItemDaVenda.Venda.IdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PRODUTO", pItemDaVenda.Produto.IdProduto).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@SITUACAO_ITEM", (int)pItemDaVenda.Situacao).SqlDbType = SqlDbType.Int;

            await cmd.ExecuteNonQueryAsync();
            Conexao.Desconectar();
        }
        #endregion
    }
}
