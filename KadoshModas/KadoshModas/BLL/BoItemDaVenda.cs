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
    /// Classe responsáve pela lógica de negócios de todo objeto Item da Venda
    /// </summary>
    class BoItemDaVenda
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Item Da Venda na base de dados
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public void Cadastrar(DmoItemDaVenda pItemDaVenda)
        {
            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            new DaoItemDaVenda().Cadastrar(pItemDaVenda);
        }
        #endregion
    }
}
