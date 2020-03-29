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
        public bool Cadastrar(DmoCategoria pDmoCategoria)
        {
            if (string.IsNullOrEmpty(pDmoCategoria.Nome))
                throw new Exception("O atributo Nome da Categoria é obrigatório");

            return new DaoCategoria().Cadastrar(pDmoCategoria) != null;
        }

        /// <summary>
        /// Consulta todas as Categorias
        /// </summary>
        /// <returns>Retorna uma lista de DmoCategoria com todas os Categorias cadastradas na base de dados</returns>
        public List<DmoCategoria> Consultar()
        {
            return new DaoCategoria().Consultar();
        }
    }
}
