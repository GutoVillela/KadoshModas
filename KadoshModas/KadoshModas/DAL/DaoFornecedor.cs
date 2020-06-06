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
    /// Classe DAL para Fornecedor
    /// </summary>
    class DaoFornecedor
    {
        #region Construtor
        /// <summary>
        /// Inicializa um objeto de conexão com o banco de dados
        /// </summary>
        public DaoFornecedor()
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
        /// Nome da tabela de Fornecedores no banco de dados
        /// </summary>
        const string NOME_TABELA = "TB_FORNECEDORES";
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra um Fornecedor na base de dados
        /// </summary>
        /// <param name="pFornecedor">Objeto DmoFornecedor preenchido com pelo menos o Nome do Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor cadastrado.</returns>
        public int? Cadastrar(DmoFornecedor pFornecedor)
        {
            SqlCommand cmd = new SqlCommand(@"INSERT INTO " + NOME_TABELA + " (NOME, CNPJ, ENDERECO) VALUES (@NOME, @CNPJ, @ENDERECO)", conexao.Conectar());
            cmd.Parameters.AddWithValue("@NOME", pFornecedor.Nome).SqlDbType = SqlDbType.VarChar;

            if (string.IsNullOrEmpty(pFornecedor.CNPJ))
                cmd.Parameters.AddWithValue("@CNPJ", DBNull.Value).SqlDbType = SqlDbType.Char;
            else
                cmd.Parameters.AddWithValue("@CNPJ", pFornecedor.CNPJ).SqlDbType = SqlDbType.Char;

            if (pFornecedor.Endereco != null && pFornecedor.Endereco.IdEndereco != null)
                cmd.Parameters.AddWithValue("@ENDERECO", pFornecedor.Endereco.IdEndereco).SqlDbType = SqlDbType.Int;
            else
                cmd.Parameters.AddWithValue("@ENDERECO", DBNull.Value).SqlDbType = SqlDbType.Int;

            cmd.ExecuteNonQuery();
            conexao.Desconectar();

            return ConsultarUltimoId();
        }

        /// <summary>
        /// Consulta todos os Fornecedores cadastrados na base de dados
        /// </summary>
        /// <param name="pNomeFornecedor">Se fornecido, busca os fornecedores cujos nomes iniciam com a string fornecida</param>
        /// <param name="pBuscaInativos">Define se busca incluirá nos resultados registros de fornecedores inativos</param>
        /// <returns>Retorna uma lista de DmoFornecedor com todos os Fornecedores encontrados</returns>
        public List<DmoFornecedor> Consultar(string pNomeFornecedor = null, bool pBuscaInativos = false)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA, conexao.Conectar());

            if (!string.IsNullOrEmpty(pNomeFornecedor))
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";

                cmd.CommandText += " NOME LIKE @NOME";
                cmd.Parameters.AddWithValue("@NOME", pNomeFornecedor + "%").SqlDbType = SqlDbType.VarChar;
            }

            if (!pBuscaInativos)
            {
                if (!cmd.CommandText.Contains("WHERE"))
                    cmd.CommandText += " WHERE";
                else
                    cmd.CommandText += " AND";

                cmd.CommandText += " ATIVO = 1";
            }

            SqlDataReader dataReader = cmd.ExecuteReader();

            List<DmoFornecedor> listaDeFornecedores = new List<DmoFornecedor>();

            while (dataReader.Read())
            {
                DmoFornecedor fornecedor = new DmoFornecedor();
                fornecedor.IdFornecedor = int.Parse(dataReader["ID_FORNECEDOR"].ToString());
                fornecedor.Nome = dataReader["NOME"].ToString();
                fornecedor.CNPJ = dataReader["CNPJ"].ToString();
                fornecedor.Endereco = string.IsNullOrEmpty(dataReader["ENDERECO"].ToString()) ? null : new DaoEndereco().ConsultarEnderecoPorId(int.Parse(dataReader["ENDERECO"].ToString()));
                fornecedor.Ativo = bool.Parse(dataReader["ATIVO"].ToString());
                fornecedor.DataDeCriacao = DateTime.Parse(dataReader["DT_CRIACAO"].ToString());
                fornecedor.DataDeAtualizacao = DateTime.Parse(dataReader["DT_ATUALIZACAO"].ToString());

                listaDeFornecedores.Add(fornecedor);
            }

            conexao.Desconectar();

            return listaDeFornecedores;
        }

        /// <summary>
        /// Consulta o último Id de Fornecedor cadastrado na base
        /// </summary>
        /// <returns>Retorno último Id de Fornecedor cadastrado na base. Em caso de erro retorna null</returns>
        private int? ConsultarUltimoId()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(ID_FORNECEDOR) AS ID FROM " + NOME_TABELA, conexao.Conectar());

                SqlDataReader dr = cmd.ExecuteReader();

                dr.Read();

                return int.Parse(dr[0].ToString());

            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
}
