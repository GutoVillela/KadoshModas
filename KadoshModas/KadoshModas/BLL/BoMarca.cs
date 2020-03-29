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
        public bool Cadastrar(DmoMarca pDmoMarca)
        {
            if (string.IsNullOrEmpty(pDmoMarca.Nome))
                throw new Exception("O atributo Nome da Marca é obrigatório");

            return new DaoMarca().Cadastrar(pDmoMarca) != null;
        }

        /// <summary>
        /// Consulta todas as Marcas
        /// </summary>
        /// <returns>Retorna uma lista de DmoMarca com todas os Marcas cadastradas na base de dados</returns>
        public List<DmoMarca> Consultar()
        {
            return new DaoMarca().Consultar();
        }
    }
}
