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
        /// Cadastra um Fornecedor na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pFornecedor">Objeto DmoFornecedor preenchido com pelo menos o Nome do Fornecedor</param>
        /// <returns>Retorna o Id do Fornecedor cadastrado.</returns>
        public async Task<int?> CadastrarAsync(DmoFornecedor pFornecedor)
        {
            #region Cadastro do Endereço
            if (pFornecedor.Endereco != null)
            {
                pFornecedor.Endereco.IdEndereco = await new BoEndereco().CadastrarAsync(pFornecedor.Endereco);
            }
            #endregion

            #region Cadastro do Cliente
            pFornecedor.IdFornecedor = await new DaoFornecedor().CadastrarAsync(pFornecedor);
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
                        await new BoTelefoneDoFornecedor().CadastrarAsync(telefone);
                    }
                }
                #endregion
            }

            return pFornecedor.IdFornecedor;
        }

        /// <summary>
        /// Consulta todos os Fornecedores cadastrados na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pNomeFornecedor">Se fornecido, busca os fornecedores cujos nomes iniciam com a string fornecida</param>
        /// <param name="pBuscaInativos">Define se busca incluirá nos resultados registros de fornecedores inativos</param>
        /// <returns>Retorna uma lista de DmoFornecedor com todos os Fornecedores encontrados</returns>
        public async Task<List<DmoFornecedor>> ConsultarAsync(string pNomeFornecedor = null, bool pBuscaInativos = false)
        {
            List<DmoFornecedor> fornecedores = await new DaoFornecedor().ConsultarAsync(pNomeFornecedor, pBuscaInativos );

            #region Busca Endereços para cada Fornecedor
            foreach (DmoFornecedor fornecedor in fornecedores)
            {
                if(fornecedor.Endereco != null && fornecedor.Endereco.IdEndereco != null)
                {
                    fornecedor.Endereco = await new BoEndereco().ConsultarEnderecoPorIdAsync(Convert.ToInt32(fornecedor.Endereco.IdEndereco));
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
