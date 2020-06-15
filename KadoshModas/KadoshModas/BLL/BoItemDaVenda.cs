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
        /// Cadastra um Item Da Venda na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pItemDaVenda">Objeto DmoItemDaVenda preenchido</param>
        public async Task CadastrarAsync(DmoItemDaVenda pItemDaVenda)
        {
            if (pItemDaVenda == null)
                throw new ArgumentNullException("O parâmetro pItemDaVenda é obrigatório e não pode ser nulo.");

            if (pItemDaVenda.Venda == null || pItemDaVenda.Venda.IdVenda == null)
                throw new ArgumentException("A propriedade Venda de pItemDaVenda é obrigatória e deve conter um Id de Venda associado.");

            if (pItemDaVenda.Produto == null || pItemDaVenda.Produto.IdProduto == null)
                throw new ArgumentException("A propriedade Produto de pItemDaVenda é obrigatória e deve conter um Id de Produto associado.");

            await new DaoItemDaVenda().CadastrarAsync(pItemDaVenda);
        }

        /// <summary>
        /// Consulta todos os Itens da Venda de uma Venda específica de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">Id da Venda</param>
        /// <returns>Lista de Itens da Venda</returns>
        public async Task<List<DmoItemDaVenda>> ConsultarItensDaVendaAsync(int? pIdVenda)
        {
            if (pIdVenda == null)
                throw new ArgumentNullException("O parâmetro pIdVenda é obrigatório e não pode ser nulo.");

            List <DmoItemDaVenda> itensDaVenda = await new DaoItemDaVenda().ConsultarItensDaVendaAsync(pIdVenda);
            
            foreach(DmoItemDaVenda item in itensDaVenda)
            {
                item.Produto = await new BoProduto().ConsultarAsync(int.Parse(item.Produto.IdProduto.ToString()));
            }

            return itensDaVenda;
        }
        #endregion
    }
}
