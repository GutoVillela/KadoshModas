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
    /// Classe DAL para Venda
    /// </summary>
    class DaoVenda
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoVenda()
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
        /// Nome da tabela de Vendas no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_VENDAS";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra uma nova Venda 
        /// </summary>
        /// <param name="pVenda">Objeto DmoVenda preenchido</param>
        /// <returns>Retorna o Id da Venda cadastrada</returns>
        public int? Cadastrar(DmoVenda pVenda)
        {
            
            if (pVenda == null)
                throw new ArgumentNullException("O parâmetro pVenda é obrigatório e não pode ser nulo.");

            if (pVenda.Cliente == null || pVenda.Cliente.IdCliente == null)
                throw new ArgumentException("A propriedade Cliente de pVenda é obrigatória e deve conter um Id de Cliente associado.");

            if(pVenda.ItensDaVenda == null || pVenda.ItensDaVenda.Count <= 0)
                throw new ArgumentException("É obrigatório pelo menos um Item da Venda associado à propriedade ItensDaVenda para cadastrar esta Venda.");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (CLIENTE, FORMA_DE_PAGAMENTO, QTD_PARCELAS, DESCONTO, ENTRADA, JUROS_A_PRAZO) VALUES (@CLIENTE, @FORMA_DE_PAGAMENTO, @QTD_PARCELAS, @DESCONTO, @ENTRADA, @JUROS_A_PRAZO);", conexao.Conectar());

            cmd.Parameters.AddWithValue("@CLIENTE", pVenda.Cliente.IdCliente).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@FORMA_DE_PAGAMENTO", (int)pVenda.FormaDePagamento).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@QTD_PARCELAS", pVenda.QtdParcelas).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@DESCONTO", pVenda.Desconto).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@ENTRADA", pVenda.Entrada).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@JUROS_A_PRAZO", pVenda.JurosAPrazo).SqlDbType = SqlDbType.Float;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return ConsultarUltimoId();
        }

        /// <summary>
        /// Consulta o último Id de Venda cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de Venda cadastrado na base</returns>
        private int? ConsultarUltimoId()
        {
            SqlCommand cmd = new SqlCommand("SELECT MAX(ID_VENDA) AS ID FROM " + NOME_TABELA, conexao.Conectar());

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            return int.Parse(dr[0].ToString());
        }
        #endregion
    }
}
