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
        /// Cadastra uma Venda na base de dados de forma assíncrona
        /// </summary>
        /// <param name="pVenda">Objeto DmoVenda preenchido</param>
        public async Task CadastrarAsync(DmoVenda pVenda)
        {
            #region Cadastro da Venda
            if (pVenda == null)
                throw new ArgumentNullException("O parâmetro pVenda é obrigatório e não pode ser nulo.");

            if (pVenda.Cliente == null || pVenda.Cliente.IdCliente == null)
                throw new ArgumentException("A propriedade Cliente de pVenda é obrigatória e deve conter um Id de Cliente associado.");

            if (pVenda.ItensDaVenda == null || pVenda.ItensDaVenda.Count <= 0)
                throw new ArgumentException("É obrigatório pelo menos um Item da Venda associado à propriedade ItensDaVenda para cadastrar esta Venda.");

            
            pVenda.IdVenda = await new DaoVenda().CadastrarAsync(pVenda);
            #endregion

            #region Cadastro dos Itens da Venda
            foreach (DmoItemDaVenda itemDaVenda in pVenda.ItensDaVenda)
            {
                itemDaVenda.Venda = pVenda;
                await new BoItemDaVenda().CadastrarAsync(itemDaVenda);
            }
            #endregion

            #region Cadastro das Parcelas, caso haja
            if(pVenda.ParcelasDaVenda.Any())
            {
                foreach(DmoParcela parcela in pVenda.ParcelasDaVenda)
                {
                    parcela.Venda = pVenda;
                    await new BoParcela().CadastrarAsync(parcela);
                }
            }
            #endregion
        }

        /// <summary>
        /// Consulta todas as Vendas Cadastradas de forma assíncrona
        /// </summary>
        /// <param name="pClientes">Se fornecido, retorna somente Vendas dos Clientes fornecidos</param>
        /// <param name="pSituacoesVendas">Se fornecido, retorna somente Vendas COM as Situações fornecidas</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Vendas A PARTIR da Data Inicial fornecida</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Vendas ATÉ a Data Final fornecida</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public async Task<List<DmoVenda>> ConsultarAsync(List<DmoCliente> pClientes = null, List<SituacaoVenda> pSituacoesVendas = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null)
        {
            List<DmoVenda> vendas = await new DaoVenda().ConsultarAsync(pClientes, pSituacoesVendas, pDataInicial, pDataFinal);

            foreach (DmoVenda compra in vendas)
            {
                compra.Cliente = await new BoCliente().ConsultarClientePorIdAsync(int.Parse(compra.Cliente.IdCliente.ToString()));

                compra.ItensDaVenda = await new BoItemDaVenda().ConsultarItensDaVendaAsync(compra.IdVenda);

                if (compra.QtdParcelas > 0)
                {
                    compra.ParcelasDaVenda = await new BoParcela().ConsultarParcelasDaVendaAsync(compra.IdVenda);
                }

            }

            return vendas;
        }

        /// <summary>
        /// Consulta todas as Vendas associadas ao Cliente de forma assíncrona
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public async Task<List<DmoVenda>> ConsultarComprasDoClienteAsync(int? pIdCliente)
        {
            if (pIdCliente == null)
                throw new ArgumentException("O parâmetro pIdCliente é obrigatório e deve ser preenchido com um ID de Cliente válido.");


            List<DmoVenda> comprasDoCliente = await ConsultarAsync(new List<DmoCliente>() { new DmoCliente() { IdCliente = pIdCliente } });

            return comprasDoCliente;
        }

        /// <summary>
        /// Atualiza a Situação da Venda de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">ID da Venda para Atualizar</param>
        /// <param name="pNovaSituacaoVenda">Nova Situação da Venda</param>
        public async Task AtualizarSituacaoVendaAsync(int pIdVenda, SituacaoVenda pNovaSituacaoVenda)
        {
            await new DaoVenda().AtualizarSituacaoVendaAsync(pIdVenda, pNovaSituacaoVenda);
        }

        /// <summary>
        /// Atualiza o Valor Pago da Venda de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">ID da Venda válido</param>
        /// <param name="pPago">Novo valor Pago</param>
        public async Task AtualizarValorPagoAsync(int pIdVenda, double pPago)
        {
            await new DaoVenda().AtualizarValorPagoAsync(pIdVenda, pPago);
        }

        /// <summary>
        /// Calcula o Total da Venda
        /// </summary>
        /// <param name="pDmoVenda">Objeto DmoVenda com todas as informações da Venda</param>
        /// <returns>Retorna o Total da Venda</returns>
        public float TotalDaVenda(DmoVenda pDmoVenda)
        {
            float totalVenda = 0f;

            foreach (DmoItemDaVenda item in pDmoVenda.ItensDaVenda)
            {
                totalVenda += (item.Valor - item.Valor * item.Desconto) * item.Quantidade;
            }

            totalVenda -= totalVenda * (pDmoVenda.Desconto / 100);

            return totalVenda;
        }

        /// <summary>
        /// Busca quantas Vendas existem atualmente cadastradas de forma assíncrona
        /// </summary>
        /// <returns>Retorna quantidade de Vendas cadastradas</returns>
        public async Task<int> ContarVendasAsync()
        {
            return await new DaoVenda().ContarVendasAsync();
        }
        #endregion
    }
}
