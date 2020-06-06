﻿using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.DAL
{
    class DaoParcela
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoParcela()
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
        /// Nome da tabela de Parcelas no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_PARCELAS_DA_VENDA";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra uma nova Parcela
        /// </summary>
        /// <param name="pDmoParcela">Objeto DmoParcela preenchido</param>
        public void Cadastrar(DmoParcela pDmoParcela)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (VENDA, PARCELA, VALOR_PARCELA, DESCONTO, VENCIMENTO, SITUACAO) VALUES (@VENDA, @PARCELA, @VALOR_PARCELA, @DESCONTO, @VENCIMENTO, @SITUACAO);", conexao.Conectar());

            cmd.Parameters.AddWithValue("@VENDA", pDmoParcela.Venda.IdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PARCELA", pDmoParcela.Parcela).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@VALOR_PARCELA", pDmoParcela.ValorParcela).SqlDbType = SqlDbType.SmallMoney;
            cmd.Parameters.AddWithValue("@DESCONTO", pDmoParcela.Desconto).SqlDbType = SqlDbType.Float;
            cmd.Parameters.AddWithValue("@VENCIMENTO", pDmoParcela.Vencimento).SqlDbType = SqlDbType.Date;
            cmd.Parameters.AddWithValue("@SITUACAO", (int)  pDmoParcela.SituacaoParcela).SqlDbType = SqlDbType.Int;            

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        /// <summary>
        /// Consulta todas as Parcelas de uma Venda específica
        /// </summary>
        /// <param name="pIdVenda">Id da Venda</param>
        /// <returns>Lista de Parcelas da Venda</returns>
        public List<DmoParcela> ConsultarParcelasDaVenda(int? pIdVenda)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE VENDA = @VENDA ORDER BY PARCELA DESC", conexao.Conectar());
            cmd.Parameters.AddWithValue("@VENDA", pIdVenda).SqlDbType = SqlDbType.Int;

            SqlDataReader dataReader = cmd.ExecuteReader();

            List<DmoParcela> listaDeParcelas = new List<DmoParcela>();

            while (dataReader.Read())
            {
                DmoParcela parcela = new DmoParcela()
                {
                    Venda = new DmoVenda() { IdVenda = int.Parse(dataReader["VENDA"].ToString()) },
                    Parcela = int.Parse(dataReader["PARCELA"].ToString()),
                    ValorParcela = float.Parse(dataReader["VALOR_PARCELA"].ToString()),
                    Desconto = string.IsNullOrEmpty(dataReader["DESCONTO"].ToString()) ? 0 : float.Parse(dataReader["DESCONTO"].ToString()),
                    Vencimento = DateTime.Parse(dataReader["VENCIMENTO"].ToString()),
                    SituacaoParcela = (DmoParcela.SituacoesParcela)int.Parse(dataReader["SITUACAO"].ToString()),
                    DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString()),
                    DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString())

                };

                if (!string.IsNullOrEmpty(dataReader["DT_PAGAMENTO"].ToString()))
                    parcela.DataDoPagamento = DateTime.Parse(dataReader["DT_PAGAMENTO"].ToString());

                listaDeParcelas.Add(parcela);
            }

            conexao.Desconectar();

            return listaDeParcelas;
        }
        
        /// <summary>
        /// Atualiza a Situação da Parcela de uma determinada Venda
        /// </summary>
        /// <param name="pIdVenda">ID da Venda</param>
        /// <param name="pNumParcela">Número da Parcela</param>
        /// <param name="pNovaSituacaoParcela">Nova Situação da Venda</param>
        public void AtualizarSituacaoParcela (int pIdVenda, int pNumParcela, DmoParcela.SituacoesParcela pNovaSituacaoParcela, DateTime? pDataPagamento = null)
        {
            SqlCommand cmd = new SqlCommand(@"UPDATE " + NOME_TABELA + " SET SITUACAO = @SITUACAO, DT_PAGAMENTO = @DT_PAGAMENTO, DT_ATUALIZACAO = GETDATE() WHERE VENDA = @VENDA AND PARCELA = @PARCELA", conexao.Conectar());

            cmd.Parameters.AddWithValue("@VENDA", pIdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PARCELA", pNumParcela).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@SITUACAO", (int)pNovaSituacaoParcela).SqlDbType = SqlDbType.Int;

            if (pDataPagamento.HasValue)
                cmd.Parameters.AddWithValue("@DT_PAGAMENTO", pDataPagamento).SqlDbType = SqlDbType.DateTime;
            else
                cmd.Parameters.AddWithValue("@DT_PAGAMENTO", DBNull.Value).SqlDbType = SqlDbType.DateTime;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        #endregion
    }
}
