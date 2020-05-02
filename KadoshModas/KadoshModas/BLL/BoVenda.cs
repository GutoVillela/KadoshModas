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
    /// Classe responsáve pela lógica de negócios de todo objeto Venda
    /// </summary>
    class BoVenda
    {
        #region Métodos
        /// <summary>
        /// Cadastra uma Venda na base de dados
        /// </summary>
        /// <param name="pVenda">Objeto DmoVenda preenchido</param>
        /// <returns>Retorna true em caso de sucesso ou false caso algum erro tenha ocorrido</returns>
        public bool Cadastrar(DmoVenda pVenda)
        {
            if (pVenda == null)
                throw new ArgumentNullException("O parâmetro pVenda é obrigatório e não pode ser nulo.");

            if (pVenda.Cliente == null || pVenda.Cliente.IdCliente == null)
                throw new ArgumentException("A propriedade Cliente de pVenda é obrigatória e deve conter um Id de Cliente associado.");

            if (pVenda.ItensDaVenda == null || pVenda.ItensDaVenda.Count <= 0)
                throw new ArgumentException("É obrigatório pelo menos um Item da Venda associado à propriedade ItensDaVenda para cadastrar esta Venda.");

            
            pVenda.IdVenda = new DaoVenda().Cadastrar(pVenda);

            foreach(DmoItemDaVenda itemDaVenda in pVenda.ItensDaVenda)
            {
                new BoItemDaVenda().Cadastrar(itemDaVenda);
            }

            return true;
        }
        #endregion
    }
}
