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
    /// Classe BLL para Categoria
    /// </summary>
    class BoCategoria
    {
        /// <summary>
        /// Cadastra uma Categoria na base de dados
        /// </summary>
        /// <param name="pDmoCategoria">Objeto DmoCategoria preenchido com pelo menos o Nome da Categoria</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public void Cadastrar(DmoCategoria pDmoCategoria)
        {
            if (string.IsNullOrEmpty(pDmoCategoria.Nome))
                throw new Exception("O atributo Nome da Categoria é obrigatório");

            new DaoCategoria().Cadastrar(pDmoCategoria);
        }

        /// <summary>
        /// Consulta todas as Categorias
        /// </summary>
        /// <param name="pNomeCategoria">Se fornecido, busca somente as Categorias com nomes que iniciam com o valor fornecido</param>
        /// <returns>Retorna uma lista de DmoCategoria com todas os Categorias cadastradas na base de dados</returns>
        public List<DmoCategoria> Consultar(string pNomeCategoria = null)
        {
            return new DaoCategoria().Consultar(pNomeCategoria);
        }

        /// <summary>
        /// Atualiza a Categoria
        /// </summary>
        /// <param name="pCategoria">Objeto DmoCategoria com as novas informações da Categoria e o ID da Categoria</param>
        /// <param name="pNomeCategoria">Nome original da Categoria antes da edição</param>
        public void Atualizar(DmoCategoria pCategoria, string pNomeCategoria)
        {
            new DaoCategoria().Atualizar(pCategoria, pNomeCategoria);
        }
    }
}
