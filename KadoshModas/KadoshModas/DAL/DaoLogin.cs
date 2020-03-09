﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.BLL;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace KadoshModas.DAL
{
    /// <summary>
    /// Classe responsável por realizar o acesso a dados referente à tabela de Login
    /// </summary>
    class DaoLogin
    {
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoLogin()
        {
            this.conexao = new Conexao();
        }

        #region Atributos
        /// <summary>
        /// Objeto de conexão utilizado no acesso à base de dados
        /// </summary>
        private Conexao conexao;
        #endregion

        #region Métodos

        /// <summary>
        /// Veririca se usuário e senha existem na tabela TB_LOGIN na base de dados
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <param name="senha">Senha</param>
        /// <returns>Retorna true caso usuário e senha existam na base, ou false caso não exista</returns>
        public bool ValidarLogin(string usuario, string senha)
        {
            bool loginValido = false;
            SqlCommand cmd = new SqlCommand("SELECT * FROM TB_LOGIN WHERE USUARIO = @USUARIO AND SENHA = @SENHA", conexao.Conectar());
            cmd.Parameters.AddWithValue("@USUARIO", usuario).SqlDbType = SqlDbType.VarChar;
            cmd.Parameters.AddWithValue("@SENHA", senha).SqlDbType = SqlDbType.VarChar;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
                loginValido = true;

            dr.Close();
            conexao.Desconectar();
            return loginValido;
        }
        #endregion
    }
}