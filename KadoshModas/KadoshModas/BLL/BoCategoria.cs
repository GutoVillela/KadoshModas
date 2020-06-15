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
        /// Cadastra uma Categoria na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pDmoCategoria">Objeto DmoCategoria preenchido com pelo menos o Nome da Categoria</param>
        /// <returns>Retorna true em caso de sucesso ou false em caso de erro</returns>
        public async Task CadastrarAsync(DmoCategoria pDmoCategoria)
        {
            if (string.IsNullOrEmpty(pDmoCategoria.Nome))
                throw new Exception("O atributo Nome da Categoria é obrigatório");

            await new DaoCategoria().CadastrarAsync(pDmoCategoria);
        }

        /// <summary>
        /// Consulta todas as Categorias de forma assíncrona de forma assíncrona
        /// </summary>
        /// <param name="pNomeCategoria">Se fornecido, busca somente as Categorias com nomes que iniciam com o valor fornecido</param>
        /// <returns>Retorna uma lista de DmoCategoria com todas os Categorias cadastradas na base de dados</returns>
        public async Task<List<DmoCategoria>> ConsultarAsync(string pNomeCategoria = null)
        {
            return await new DaoCategoria().ConsultarAsync(pNomeCategoria);
        }

        /// <summary>
        /// Atualiza a Categoria de forma assíncrona
        /// </summary>
        /// <param name="pCategoria">Objeto DmoCategoria com as novas informações da Categoria e o ID da Categoria</param>
        /// <param name="pNomeCategoria">Nome original da Categoria antes da edição</param>
        public async Task AtualizarAsync(DmoCategoria pCategoria, string pNomeCategoria)
        {
            await new DaoCategoria().AtualizarAsync(pCategoria, pNomeCategoria);
        }
    }
}
