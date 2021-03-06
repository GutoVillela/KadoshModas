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
    /// Classe DAL para Telefones do Cliente
    /// </summary>
    class DaoTelefoneDoCliente
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoTelefoneDoCliente()
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
        /// Nome da tabela de Telefones do Cliente no banco de dados
        /// </summary>
        public static readonly string NOME_TABELA = "TB_TELEFONES_DO_CLIENTE";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra o Telefone do Cliente de forma assíncrona.
        /// </summary>
        /// <param name="pDmoTelefoneDoCliente">Ojeto DmoTelefoneDoCliente preenchido</param>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoTelefoneDoCliente pDmoTelefoneDoCliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (CLIENTE, TELEFONE) VALUES (@CLIENTE, @TELEFONE)", await conexao.ConectarAsync());
                cmd.Parameters.AddWithValue("@CLIENTE", pDmoTelefoneDoCliente.Cliente.IdCliente).SqlDbType = SqlDbType.Int;
                cmd.Parameters.AddWithValue("@TELEFONE", pDmoTelefoneDoCliente.IdTelefone).SqlDbType = SqlDbType.Int;

                await cmd.ExecuteNonQueryAsync();
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
