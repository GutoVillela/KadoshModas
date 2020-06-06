using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (CLIENTE, FORMA_DE_PAGAMENTO, QTD_PARCELAS, DESCONTO, ENTRADA, JUROS_A_PRAZO, SITUACAO, DT_VENDA) VALUES (@CLIENTE, @FORMA_DE_PAGAMENTO, @QTD_PARCELAS, @DESCONTO, @ENTRADA, @JUROS_A_PRAZO, @SITUACAO, @DT_VENDA);", conexao.Conectar());

            cmd.Parameters.AddWithValue("@CLIENTE", pVenda.Cliente.IdCliente).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@FORMA_DE_PAGAMENTO", (int) pVenda.FormaDePagamento).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@QTD_PARCELAS", pVenda.QtdParcelas).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@DESCONTO", pVenda.Desconto).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@ENTRADA", pVenda.Entrada).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@JUROS_A_PRAZO", pVenda.JurosAPrazo).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@SITUACAO", (int) pVenda.Situacao).SqlDbType = SqlDbType.Int;

            if(pVenda.DataVenda == null || pVenda.DataVenda == DateTime.MinValue)
                cmd.Parameters.AddWithValue("@DT_VENDA", DateTime.Now).SqlDbType = SqlDbType.DateTime;
            else
                cmd.Parameters.AddWithValue("@DT_VENDA", pVenda.DataVenda).SqlDbType = SqlDbType.DateTime;


            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return ConsultarUltimoId();
        }

        /// <summary>
        /// Consulta todas as Vendas Cadastradas
        /// </summary>
        /// <param name="pClientes">Se fornecido, retorna somente Vendas dos Clientes fornecidos</param>
        /// <param name="pSituacoesVendas">Se fornecido, retorna somente Vendas COM as Situações fornecidas</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Vendas A PARTIR da Data Inicial fornecida</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Vendas ATÉ a Data Final fornecida</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public List<DmoVenda> Consultar(List<DmoCliente> pClientes = null, List<DmoVenda.SituacoesVenda> pSituacoesVendas = null, DateTime ? pDataInicial = null, DateTime? pDataFinal = null)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());

            #region Filtros
            if(pClientes != null && pClientes.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " CLIENTE IN (";

                for (int i = 0; i < pClientes.Count; i++)
                {
                    if (i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@CLIENTE" + i;
                    cmd.Parameters.AddWithValue("@CLIENTE" + i, pClientes[i].IdCliente).SqlDbType = SqlDbType.Int;
                }

                cmd.CommandText += ")";
            }

            if (pSituacoesVendas != null && pSituacoesVendas.Any())
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " SITUACAO IN (";

                for (int i = 0; i < pSituacoesVendas.Count; i++)
                {
                    if (i != 0)
                        cmd.CommandText += ", ";

                    cmd.CommandText += "@SITUACAO" + i;
                    cmd.Parameters.AddWithValue("@SITUACAO" + i, (int) pSituacoesVendas[i]).SqlDbType = SqlDbType.Int;
                }

                cmd.CommandText += ")";
            }

            if (pDataInicial != null)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " DT_VENDA >= @DT_INICIAL";
                cmd.Parameters.AddWithValue("@DT_INICIAL", pDataInicial).SqlDbType = SqlDbType.DateTime;
            }

            if (pDataFinal != null)
            {
                if (pDataInicial != null && pDataInicial == pDataFinal)
                    pDataFinal = pDataInicial.Value.AddDays(1);
                else
                    pDataFinal = pDataFinal.Value.AddDays(1);// Adicionar um dia para condição incluir até meia noite do dia seguinte, ou seja, incluir todo o dia da pDataFinal

                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " DT_VENDA <= @DT_FINAL";
                cmd.Parameters.AddWithValue("@DT_FINAL", pDataFinal).SqlDbType = SqlDbType.DateTime;
            }
            #endregion

            SqlDataReader dataReader = cmd.ExecuteReader();

            List<DmoVenda> listaDeVendasDoCliente = new List<DmoVenda>();

            while (dataReader.Read())
            {
                DmoVenda vendaDoCliente = new DmoVenda
                {
                    IdVenda = int.Parse(dataReader["ID_VENDA"].ToString()),
                    Cliente = new DmoCliente() { IdCliente = int.Parse(dataReader["CLIENTE"].ToString()) },
                    FormaDePagamento = (DmoVenda.FormasDePagamento)int.Parse(dataReader["FORMA_DE_PAGAMENTO"].ToString()),
                    QtdParcelas = uint.Parse(dataReader["QTD_PARCELAS"].ToString()),
                    Desconto = float.Parse(dataReader["DESCONTO"].ToString()),
                    Entrada = float.Parse(dataReader["ENTRADA"].ToString()),
                    JurosAPrazo = float.Parse(dataReader["JUROS_A_PRAZO"].ToString()),
                    Situacao = (DmoVenda.SituacoesVenda)int.Parse(dataReader["SITUACAO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                if (!string.IsNullOrEmpty(dataReader["DT_VENDA"].ToString()))
                    vendaDoCliente.DataVenda = DateTime.Parse(dataReader["DT_VENDA"].ToString());
                
                if (!string.IsNullOrEmpty(dataReader["DT_QUITACAO"].ToString()))
                    vendaDoCliente.DataQuitacaoVenda = DateTime.Parse(dataReader["DT_QUITACAO"].ToString());

                listaDeVendasDoCliente.Add(vendaDoCliente);
            }

            dataReader.Close();
            conexao.Desconectar();

            return listaDeVendasDoCliente;
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

        /// <summary>
        /// Consulta todas as Compras do Cliente
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public List<DmoVenda> ConsultarComprasDoCliente(int? pIdCliente)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE CLIENTE = @CLIENTE;", conexao.Conectar());
            cmd.Parameters.AddWithValue("@CLIENTE", pIdCliente).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = cmd.ExecuteReader();

            List<DmoVenda> listaDeVendasDoCliente = new List<DmoVenda>();

            while (dataReader.Read())
            {
                DmoVenda vendaDoCliente = new DmoVenda
                {
                    IdVenda = int.Parse(dataReader["ID_VENDA"].ToString()),
                    Cliente = new DmoCliente() { IdCliente = int.Parse(dataReader["CLIENTE"].ToString()) },
                    FormaDePagamento = (DmoVenda.FormasDePagamento)int.Parse(dataReader["FORMA_DE_PAGAMENTO"].ToString()),
                    QtdParcelas = uint.Parse(dataReader["QTD_PARCELAS"].ToString()),
                    Desconto = float.Parse(dataReader["DESCONTO"].ToString()),
                    Entrada = float.Parse(dataReader["ENTRADA"].ToString()),
                    JurosAPrazo = float.Parse(dataReader["JUROS_A_PRAZO"].ToString()),
                    Situacao = (DmoVenda.SituacoesVenda)int.Parse(dataReader["SITUACAO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())
                };

                if (!string.IsNullOrEmpty(dataReader["DT_VENDA"].ToString()))
                    vendaDoCliente.DataVenda = DateTime.Parse(dataReader["DT_VENDA"].ToString());

                if (!string.IsNullOrEmpty(dataReader["DT_QUITACAO"].ToString()))
                    vendaDoCliente.DataQuitacaoVenda = DateTime.Parse(dataReader["DT_QUITACAO"].ToString());

                listaDeVendasDoCliente.Add(vendaDoCliente);
            }

            conexao.Desconectar();

            return listaDeVendasDoCliente;
        }

        /// <summary>
        /// Atualiza a Situação da Venda. Caso a nova Situação da Venda seja Concluído, insere a Data de Quitação da Venda
        /// </summary>
        /// <param name="pIdVenda">ID da Venda para Atualizar</param>
        /// <param name="pNovaSituacaoVenda">Nova Situação da Venda</param>
        public void AtualizarSituacaoVenda(int pIdVenda, DmoVenda.SituacoesVenda pNovaSituacaoVenda)
        {
            SqlCommand cmd = new SqlCommand();

            if (pNovaSituacaoVenda == DmoVenda.SituacoesVenda.Concluido)
                cmd.CommandText = @"UPDATE " + NOME_TABELA + " SET SITUACAO = @SITUACAO, DT_QUITACAO = GETDATE(), DT_ATUALIZACAO = GETDATE() WHERE ID_VENDA = @ID_VENDA";
            else
                cmd.CommandText = @"UPDATE " + NOME_TABELA + " SET SITUACAO = @SITUACAO, DT_ATUALIZACAO = GETDATE() WHERE ID_VENDA = @ID_VENDA";


            cmd.Parameters.AddWithValue("SITUACAO", (int)pNovaSituacaoVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("ID_VENDA", pIdVenda).SqlDbType = SqlDbType.Int;

            cmd.Connection = conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        /// <summary>
        /// Busca quantas Vendas existem atualmente cadastradas
        /// </summary>
        /// <returns>Retorna quantidade de Vendas cadastradas</returns>
        public int ContarVendas()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(ID_VENDA) FROM " + NOME_TABELA, conexao.Conectar());

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            return int.Parse(dr[0].ToString());
        }
        #endregion
    }
}
