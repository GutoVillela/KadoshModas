using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.DML;
using KadoshModas.DAL;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Fornecedor
    /// </summary>
    class BoFornecedor
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Fornecedor na base de dados
        /// </summary>
        /// <param name="pFornecedor">Objeto DmoFornecedor preenchido com pelo menos o Nome do Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor cadastrado.</returns>
        public int? Cadastrar(DmoFornecedor pFornecedor)
        {
            #region Cadastro do Endereço
            if (pFornecedor.Endereco != null)
            {
                pFornecedor.Endereco.IdEndereco = new BoEndereco().Cadastrar(pFornecedor.Endereco);
            }
            #endregion

            #region Cadastro do Cliente
            pFornecedor.IdFornecedor = new DaoFornecedor().Cadastrar(pFornecedor);
            #endregion

            if (pFornecedor.IdFornecedor != null)
            {
                #region Cadastro de telefones
                if (pFornecedor.Telefones != null && pFornecedor.Telefones.Any())
                {
                    #region Remover Telefones duplicados da lista
                    List<DmoTelefoneDoFornecedor> listaAux = new List<DmoTelefoneDoFornecedor>();

                    foreach (DmoTelefoneDoFornecedor telefone in pFornecedor.Telefones)
                    {
                        if (!listaAux.Any(t => t.DDD == telefone.DDD && t.Numero == telefone.Numero))
                        {
                            listaAux.Add(telefone);
                        }
                    }

                    pFornecedor.Telefones = listaAux;
                    #endregion

                    foreach (DmoTelefoneDoFornecedor telefone in pFornecedor.Telefones)
                    {
                        telefone.Fornecedor = new DmoFornecedor { IdFornecedor = pFornecedor.IdFornecedor };
                        new BoTelefoneDoFornecedor().Cadastrar(telefone);
                    }
                }
                #endregion
            }

            return pFornecedor.IdFornecedor;
        }

        /// <summary>
        /// Consulta todos os Fornecedores cadastrados na base de dados
        /// </summary>
        /// <param name="pNomeFornecedor">Se fornecido, busca os fornecedores cujos nomes iniciam com a string fornecida</param>
        /// <param name="pBuscaInativos">Define se busca incluirá nos resultados registros de fornecedores inativos</param>
        /// <returns>Retorna uma lista de DmoFornecedor com todos os Fornecedores encontrados</returns>
        public List<DmoFornecedor> Consultar(string pNomeFornecedor = null, bool pBuscaInativos = false)
        {
            List<DmoFornecedor> fornecedores = new DaoFornecedor().Consultar(pNomeFornecedor, pBuscaInativos );

            #region Busca Endereços para cada Fornecedor
            foreach (DmoFornecedor fornecedor in fornecedores)
            {
                if(fornecedor.Endereco != null && fornecedor.Endereco.IdEndereco != null)
                {
                    fornecedor.Endereco = new BoEndereco().ConsultarEnderecoPorId(Convert.ToInt32(fornecedor.Endereco.IdEndereco));
                }
            }
            #endregion

            #region Busca os Telefones dos Fornecedores
            #endregion

            return fornecedores;
        }
        #endregion
    }
}
