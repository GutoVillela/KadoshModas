using KadoshModas.DAL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KadoshModas.BLL
{
    class BoLancamentoDoCliente
    {
        #region Métodos
        /// <summary>
        /// Cadastra um Lançamento do Cliente
        /// </summary>
        /// <param name="pLancamentoDoCliente">Objeto DmoLancamentoDoCliente preenchido.</param>
        public async Task CadastrarAsync(DmoLancamentoDoCliente pLancamentoDoCliente)
        {
            await new DaoLancamentoDoCliente().CadastrarAsync(pLancamentoDoCliente);
        }

        /// <summary>
        /// Consulta todos os Lançamentos do Cliente de forma assíncrona.
        /// </summary>
        /// <param name="pIdLancamentoDoCliente">Se fornecido, filtra a busca pelo Id do Lançamento do Cliente.</param>
        /// <param name="pCliente">Se fornecido, filtra a busca pelo ID do Cliente.</param>
        /// <param name="pTipoLancamento">Se fornecido, filtra a busca pelo Tipo de Lançamento.</param>
        /// <param name="pValorLancamento">Se fornecido, filtra a busca pelo Valor do Lançamento.</param>
        /// <param name="pVenda">Se fornecido, filtra a busca pelo ID da Venda.</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Lançamentos A PARTIR da Data Inicial fornecida.</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Lançamentos ATÉ a Data Final fornecida.</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido.</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido.</param>
        /// <returns>Retorna lista com Lançamentos encontrados</returns>
        public async Task<List<DmoLancamentoDoCliente>> ConsultarAsync(int? pIdLancamentoDoCliente = null, int? pCliente = null, TipoLancamentoDoCliente? pTipoLancamento = null, double? pValorLancamento = null, int? pVenda = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null, bool pBuscaClientes = true, bool pBuscaVendas = false)
        {
            List<DmoLancamentoDoCliente> lancamentosDoClientes = await new DaoLancamentoDoCliente().ConsultarAsync(pIdLancamentoDoCliente, pCliente, pTipoLancamento, pValorLancamento, pVenda, pDataInicial, pDataFinal, pAPartirDoRegistro, pAteORegistro);

            if (pBuscaClientes)
            {
                foreach(DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    item.Cliente = await new BoCliente().ConsultarClientePorIdAsync(Convert.ToInt32(item.Cliente.IdCliente), true, false, false);
                }
            }

            if (pBuscaVendas)
            {
                foreach (DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    item.Venda = await new BoVenda().ConsultarVendaPorIdAsync(Convert.ToInt32(item.Venda.IdVenda), false, false, false);
                }
            }

            return lancamentosDoClientes;
        }

        /// <summary>
        /// Busca os Lançamentos do Cliente por intervalo de Data do Lançamento.
        /// </summary>
        /// <param name="pDataInicial">Data Inicial da Busca</param>
        /// <param name="pDataFinal">Data Final da Busca</param>
        /// <param name="pBuscaClientes">Indica se a busca deverá incluir todas as informações do Cliente</param>
        /// <param name="pBuscaVendas">Indica se a busca deverá incluir todas as informações da Venda</param>
        /// <returns></returns>
        public async Task<List<DmoLancamentoDoCliente>> ConsultarPorIntervaloDeDataAsync(DateTime pDataInicial, DateTime pDataFinal, bool pBuscaClientes = true, bool pBuscaVendas = false)
        {
            List<DmoLancamentoDoCliente> lancamentosDoClientes = await new DaoLancamentoDoCliente().ConsultarAsync(null, null, null, null, null, pDataInicial, pDataFinal);

            if (pBuscaClientes)
            {
                foreach (DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    item.Cliente = await new BoCliente().ConsultarClientePorIdAsync(Convert.ToInt32(item.Cliente.IdCliente), true);
                }
            }

            if (pBuscaVendas)
            {
                foreach (DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    item.Venda = await new BoVenda().ConsultarVendaPorIdAsync(Convert.ToInt32(item.Venda.IdVenda), false, false, false);
                }
            }

            return lancamentosDoClientes;
        }


        /// <summary>
        /// Consulta os Lançamentos agrupados por Cliente e Tipo de Lançamento.
        /// </summary>
        /// <param name="pCancelarTarefa">Token de Cancelamento da Tarefa</param>
        /// <param name="pVenda">Se fornecido, filtra a busca pelo ID da Venda.</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Lançamentos A PARTIR da Data Inicial fornecida.</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Lançamentos ATÉ a Data Final fornecida.</param>
        /// <param name="pAPartirDoRegistro">Se fornecido, inicia  a busca a partir do registro fornecido.</param>
        /// <param name="pAteORegistro">Se fornecido, busca até o registro fornecido.</param>
        /// <param name="pBuscaClientes">Indica se a busca deverá incluir todas as informações do Cliente</param>
        /// <param name="pBuscaVendas">Indica se a busca deverá incluir todas as informações da Venda</param>
        /// <returns>Retorna lista de Lançamentos do Cliente agrupada por Cliente e Tipo de Lançamento.</returns>
        public async Task<List<DmoLancamentoDoCliente>> ConsultarLancamentosAgrupadosPorClienteETipoDeLancamento(CancellationToken pCancelarTarefa, int? pVenda = null, DateTime ? pDataInicial = null, DateTime? pDataFinal = null, uint? pAPartirDoRegistro = null, uint? pAteORegistro = null, bool pBuscaClientes = true, bool pBuscaVendas = false)
        {
            List<DmoLancamentoDoCliente> lancamentosDoClientes = await new DaoLancamentoDoCliente().ConsultarLancamentosAgrupadosPorClienteETipoDeLancamento(
                pCancelarTarefa, 
                pVenda: pVenda,
                pDataInicial: pDataInicial, 
                pDataFinal: pDataFinal, 
                pAPartirDoRegistro: pAPartirDoRegistro, 
                pAteORegistro: pAteORegistro
                );

            if (pBuscaClientes)
            {
                foreach (DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    //Cancelar tarefa caso solicitado
                    pCancelarTarefa.ThrowIfCancellationRequested();

                    item.Cliente = await new BoCliente().ConsultarClientePorIdAsync(Convert.ToInt32(item.Cliente.IdCliente), true);
                }
            }

            if (pBuscaVendas)
            {
                foreach (DmoLancamentoDoCliente item in lancamentosDoClientes)
                {
                    //Cancelar tarefa caso solicitado
                    pCancelarTarefa.ThrowIfCancellationRequested();

                    item.Venda = await new BoVenda().ConsultarVendaPorIdAsync(Convert.ToInt32(item.Venda.IdVenda), false, false, false);
                }
            }

            return lancamentosDoClientes;
        }

        /// <summary>
        /// Calcula o valor total de todos os Lançamentos do Cliente do tipo Entrada.
        /// </summary>
        /// <param name="pLancamentosDoCliente">Lista de Lançamentos do Cliente</param>
        /// <returns>Total de todos os Lançamentos do tipo Entrada</returns>
        public double CalcularTotalEntrada(List<DmoLancamentoDoCliente> pLancamentosDoCliente)
        {
            double total = 0;

            foreach(DmoLancamentoDoCliente item in pLancamentosDoCliente)
            {
                if(DmoLancamentoDoCliente.TipoEntrada(item.TipoLancamentoDoCliente))
                    total += item.ValorLancamento;
            }

            return total;
        }

        /// <summary>
        /// Calcula o valor total de todos os Lançamentos do Cliente do tipo Saída.
        /// </summary>
        /// <param name="pLancamentosDoCliente">Lista de Lançamentos do Cliente</param>
        /// <returns>Total de todos os Lançamentos do tipo Saída.</returns>
        public double CalcularTotalSaida(List<DmoLancamentoDoCliente> pLancamentosDoCliente)
        {
            double total = 0;

            foreach (DmoLancamentoDoCliente item in pLancamentosDoCliente)
            {
                if (!DmoLancamentoDoCliente.TipoEntrada(item.TipoLancamentoDoCliente))
                    total += item.ValorLancamento;
            }

            return total;
        }
        #endregion
    }
}
