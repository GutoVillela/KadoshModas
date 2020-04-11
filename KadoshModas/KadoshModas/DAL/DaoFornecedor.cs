using KadoshModas.DML;
using System;
using System.Collections.Generic;
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
        /// Consulta todos os Fornecedores cadastrados na base de dados
        /// </summary>
        /// <returns>Retorna uma lista de DmoFornecedor com todos os Fornecedores encontrados</returns>
        public List<DmoFornecedor> Consultar()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM " + NOME_TABELA + " WHERE ATIVO = 1;", conexao.Conectar());
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
            catch (Exception erro)
            {
                return null;
            }
        }
        #endregion
    }
}
