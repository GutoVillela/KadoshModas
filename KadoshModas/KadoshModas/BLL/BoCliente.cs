using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KadoshModas.DAL;
using KadoshModas.DML;

namespace KadoshModas.BLL
{
    /// <summary>
    /// Classe responsáve pela lógica de negócios de todo objeto Cliente
    /// </summary>
    class BoCliente
    {
        /// <summary>
        /// Cadastra um cliente na base de dados
        /// </summary>
        /// <param name="cliente">Objeto DmoCliente preenchido com pelo menos o Nome do cliente</param>
        /// <returns>Retorna true em caso de sucesso ou false caso algum erro tenha ocorrido</returns>
        public bool Cadastrar(DmoCliente dmoCliente)
        {
            return new DaoCliente().Cadastrar(dmoCliente.Nome);
        }
    }
}
