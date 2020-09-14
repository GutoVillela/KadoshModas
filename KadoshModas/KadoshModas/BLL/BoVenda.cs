using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            if (pVenda.DataVenda == DateTime.MinValue)
                pVenda.DataVenda = DateTime.Now;

            if (pVenda.Entrada > 0)
                pVenda.Pago = pVenda.Entrada;

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

            #region Registrar novo lançamento do Cliente em caso de pagamento a vista ou caso exista entrada
            if(pVenda.TipoPagamento == TipoPagamento.AVista || pVenda.Entrada > 0)
            {
                DmoLancamentoDoCliente lancamentoDoCliente = new DmoLancamentoDoCliente
                {
                    Cliente = pVenda.Cliente,
                    TipoLancamentoDoCliente = pVenda.TipoPagamento == TipoPagamento.AVista ? TipoLancamentoDoCliente.CompraAVista : TipoLancamentoDoCliente.Entrada,
                    ValorLancamento = pVenda.TipoPagamento == TipoPagamento.AVista ? pVenda.Total : pVenda.Entrada,
                    Venda = pVenda,
                    DataDoLancamento = pVenda.DataVenda
                };

                await new BoLancamentoDoCliente().CadastrarAsync(lancamentoDoCliente);
            }
            #endregion
        }

        /// <summary>
        /// Consulta todas as Vendas Cadastradas de forma assíncrona.
        /// </summary>
        /// <param name="pCancelarTarefa">Token de Cancelamento da Tarefa</param>
        /// <param name="pClientes">Se fornecido, retorna somente Vendas dos Clientes fornecidos</param>
        /// <param name="pSituacoesVendas">Se fornecido, retorna somente Vendas COM as Situações fornecidas</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Vendas A PARTIR da Data Inicial fornecida</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Vendas ATÉ a Data Final fornecida</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido</param>
        /// <param name="pBuscarClienteDaVenda">Define se busca deverá consultar todas as informações do Cliente da Venda</param>
        /// <param name="pBuscarItensDeCadaVenda">Define se busca deverá incluir todos os Itens da Venda</param>
        /// <param name="pBuscarParcelasDaVenda">Define se busca devería incluir todas as Parcelas da Venda</param>
        /// <returns>Retorna uma lista de Vendas que correspondem aos critérios de busca.</returns>
        public async Task<List<DmoVenda>> ConsultarAsync(CancellationToken pCancelarTarefa, List<DmoCliente> pClientes = null, List<SituacaoVenda> pSituacoesVendas = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null, bool pBuscarClienteDaVenda = true, bool pBuscarItensDeCadaVenda = true, bool pBuscarParcelasDaVenda = true)
        {
            List<DmoVenda> vendas = await new DaoVenda().ConsultarAsync(pCancelarTarefa, pClientes: pClientes, pSituacoesVendas: pSituacoesVendas, pDataInicial: pDataInicial, pDataFinal: pDataFinal, pAPartirDoRegistro: pAPartirDoRegistro, pAteORegistro: pAteORegistro);

            if (pBuscarClienteDaVenda || pBuscarItensDeCadaVenda || pBuscarParcelasDaVenda)
            {
                foreach (DmoVenda compra in vendas)
                {
                    //Cancelar tarefa caso solicitado
                    pCancelarTarefa.ThrowIfCancellationRequested();

                    if (pBuscarClienteDaVenda)
                        compra.Cliente = await new BoCliente().ConsultarClientePorIdAsync(int.Parse(compra.Cliente.IdCliente.ToString()), true);

                    if(pBuscarItensDeCadaVenda)
                        compra.ItensDaVenda = await new BoItemDaVenda().ConsultarItensDaVendaAsync(Convert.ToInt32(compra.IdVenda));

                    if (pBuscarParcelasDaVenda)
                    {
                        if (compra.QtdParcelas > 0)
                        {
                            compra.ParcelasDaVenda = await new BoParcela().ConsultarParcelasDaVendaAsync(compra.IdVenda);
                        }
                    }

                }
            }

            return vendas;
        }

        /// <summary>
        /// Busca uma Venda específica por ID
        /// </summary>
        /// <param name="pIdVenda">ID da Venda</param>
        /// <param name="pBuscarClienteDaVenda">Determina se todas as informações do Cliente serão incluídos na busca</param>
        /// <param name="pBuscarItensDeCadaVenda">Determina se todos os Itens da Venda serão incluídos na busca</param>
        /// <param name="pBuscarParcelasDaVenda">Determina se todas as Parcelas da Venda serão incluídas na busca</param>
        /// <returns>Retorna a Venda correspondente ao ID. Caso nenhuma Venda seja encontrada retorna null.</returns>
        public async Task<DmoVenda> ConsultarVendaPorIdAsync(int pIdVenda, bool pBuscarClienteDaVenda = true, bool pBuscarItensDeCadaVenda = true, bool pBuscarParcelasDaVenda = true)
        {
            List<DmoVenda> vendas = await new DaoVenda().ConsultarAsync(new CancellationToken(), pIdVenda: pIdVenda);

            DmoVenda venda;

            if (vendas.Any())
                venda = vendas.FirstOrDefault();
            else
                return null;

            if (pBuscarClienteDaVenda)
                venda.Cliente = await new BoCliente().ConsultarClientePorIdAsync(int.Parse(venda.Cliente.IdCliente.ToString()));

            if (pBuscarItensDeCadaVenda)
                venda.ItensDaVenda = await new BoItemDaVenda().ConsultarItensDaVendaAsync(Convert.ToInt32(venda.IdVenda));

            if (pBuscarParcelasDaVenda)
            {
                if (venda.QtdParcelas > 0)
                {
                    venda.ParcelasDaVenda = await new BoParcela().ConsultarParcelasDaVendaAsync(venda.IdVenda);
                }
            }

            return venda;
        }

        /// <summary>
        /// Conta a quantidade de Vendas que correspondem à busca no banco de dados de Forma assíncrona
        /// </summary>
        /// <param name="pClientes">Se fornecido, retorna somente Vendas dos Clientes fornecidos</param>
        /// <param name="pSituacoesVendas">Se fornecido, retorna somente Vendas COM as Situações fornecidas</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Vendas A PARTIR da Data Inicial fornecida</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Vendas ATÉ a Data Final fornecida</param>
        /// <returns>Retorno a quantidade de Vendas encontrados que atendem aos critérios de busca</returns>
        public async Task<int> ContarVendasAsync(List<DmoCliente> pClientes = null, List<SituacaoVenda> pSituacoesVendas = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null)
        {
            return await new DaoVenda().ContarVendasAsync(pClientes, pSituacoesVendas, pDataInicial, pDataFinal);
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


            List<DmoVenda> comprasDoCliente = await ConsultarAsync(new CancellationToken(), pClientes : new List<DmoCliente>() { new DmoCliente() { IdCliente = pIdCliente } });

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
        /// <param name="pVenda">ID da Venda válido</param>
        /// <param name="pPago">Novo valor Pago</param>
        public async Task AtualizarValorPagoAsync(DmoVenda pVenda, double pPago)
        {
            await new DaoVenda().AtualizarValorPagoAsync(Convert.ToInt32(pVenda.IdVenda), pPago);
        }

        /// <summary>
        /// Atualiza o Valor Total da Venda de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">ID da Venda válido</param>
        /// <param name="pTotal">Novo valor tOTAL</param>
        public async Task AtualizarTotalDaVendaAsync(int pIdVenda, double pTotal)
        {
            await new DaoVenda().AtualizarTotalDaVendaAsync(pIdVenda, pTotal);
        }

        /// <summary>
        /// Calcula e atualiza novo Total da Venda com base nos itens cadastrados.
        /// </summary>
        /// <param name="pIdVenda">ID da Venda</param>
        /// <returns>Retorna novo Total da Venda.</returns>
        public async Task<double> CalcularEAtualizarTotalAsync(int pIdVenda)
        {
            DmoVenda venda = await ConsultarVendaPorIdAsync(pIdVenda, false, true, false);

            venda.Total = venda.TotalDaVenda();

            await new DaoVenda().AtualizarAsync(venda);

            return venda.Total;
        }

        /// <summary>
        /// Calcula e Atualiza o Valor Total da Venda de forma assíncrona com base nos Itens da Venda associados à Venda
        /// </summary>
        /// <param name="pVenda">Venda contendo ID da Venda e Todos os Itens associados à ela</param>
        /// <returns>Retorna novo Total da Venda.</returns>
        public async Task<double> CalcularEAtualizarTotalAsync(DmoVenda pVenda)
        {
            if (pVenda == null)
                throw new ArgumentNullException("O parâmetro pVenda é obrigatório e não pode ser nulo.");

            if (pVenda.Cliente == null || pVenda.Cliente.IdCliente == null)
                throw new ArgumentException("A propriedade Cliente de pVenda é obrigatória e deve conter um Id de Cliente associado.");

            if (pVenda.ItensDaVenda == null || !pVenda.ItensDaVenda.Any())
                throw new ArgumentException("Para calcular e atualizar o Total da Venda é necessário que pelo menos um Item da Venda esteja associado à Venda.");

            pVenda.Total = pVenda.TotalDaVenda();
            await AtualizarTotalDaVendaAsync(Convert.ToInt32(pVenda.IdVenda), pVenda.Total);

            return pVenda.Total;
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
