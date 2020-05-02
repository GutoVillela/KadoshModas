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
    /// <summary>
    /// Classe DAL para Item da Venda
    /// </summary>
    class DaoItemDaVenda
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoItemDaVenda()
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
        /// Nome da tabela de Itens da Venda no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_ITENS_DA_VENDA";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um novo Item Da Venda 
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public void Cadastrar(DmoItemDaVenda pItemDaVenda)
        {

            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (VENDA, PRODUTO, QUANTIDADE, VALOR_ITEM) VALUES (@VENDA, @PRODUTO, @QUANTIDADE, @VALOR_ITEM);", conexao.Conectar());

            cmd.Parameters.AddWithValue("@VENDA", pItemDaVenda.Venda.IdVenda).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@PRODUTO", pItemDaVenda.Produto.IdProduto).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@QUANTIDADE", pItemDaVenda.Quantidade).SqlDbType = SqlDbType.Int;
            cmd.Parameters.AddWithValue("@VALOR_ITEM", pItemDaVenda.Valor).SqlDbType = SqlDbType.SmallMoney;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        #endregion
    }
}
