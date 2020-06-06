using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe BLL para Marca
    /// </summary>
    class BoMarca
    {
        /// <summary>
        /// Cadastra uma Marca na base de dados
        /// </summary>
        /// <param name="pDmoMarca">Objeto DmoMarca preenchido com pelo menos o Nome da Marca</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public void Cadastrar(DmoMarca pDmoMarca)
        {
            if (string.IsNullOrEmpty(pDmoMarca.Nome))
                throw new Exception("O atributo Nome da Marca é obrigatório");

            new DaoMarca().Cadastrar(pDmoMarca);
        }

        /// <summary>
        /// Consulta todas as Marcas
        /// </summary>
        /// <param name="pNomeMarca">Se fornecido, busca somente as Marcas com nomes que iniciam com o valor fornecido</param>
        /// <returns>Retorna uma lista de DmoMarca com todas os Marcas cadastradas na base de dados</returns>
        public List<DmoMarca> Consultar(string pNomeMarca = null)
        {
            return new DaoMarca().Consultar(pNomeMarca);
        }

        /// <summary>
        /// Atualiza a Marca
        /// </summary>
        /// <param name="pMarca">Objeto DmoMarca com as novas informações da Marca</param>
        /// <param name="pNomeMarca">Nome original da Marca antes da edição</param>
        public void Atualizar(DmoMarca pMarca, string pNomeMarca)
        {
            new DaoMarca().Atualizar(pMarca, pNomeMarca);
        }
    }
}
