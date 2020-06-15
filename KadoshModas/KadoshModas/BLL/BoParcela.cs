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
    /// Classe responsáve pela lógica de negócios de todo objeto Parcela
    /// </summary>
    class BoParcela
    {
        /// <summary>
        /// Cadastra uma nova Parcela de forma assíncrona
        /// </summary>
        /// <param name="pDmoParcela">Objeto DmoParcela preenchido</param>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        public async Task<bool> CadastrarAsync(DmoParcela pDmoParcela)
        {
            try
            {
                if (pDmoParcela.Venda == null || pDmoParcela.Venda.IdVenda == null)
                    throw new ArgumentException("A propriedade Venda de pDmoParcela é obrigatória e deve conter um Id de Venda associado.");

                await new DaoParcela().CadastrarAsync(pDmoParcela);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta todas as Parcelas de uma Venda específica de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">Id da Venda</param>
        /// <returns>Lista de Parcelas da Venda</returns>
        public async Task<List<DmoParcela>> ConsultarParcelasDaVendaAsync(int? pIdVenda)
        {
            return await new DaoParcela().ConsultarParcelasDaVendaAsync(pIdVenda);
        }

        /// <summary>
        /// Atualiza a Situação da Parcela de uma determinada Venda de forma assíncrona
        /// </summary>
        /// <param name="pIdVenda">ID da Venda</param>
        /// <param name="pNumParcela">Número da Parcela</param>
        /// <param name="pNovaSituacaoParcela">Nova Situação da Venda</param>
        public async Task AtualizarSituacaoParcelaAsync(int pIdVenda, int pNumParcela, SituacaoParcela pNovaSituacaoParcela, DateTime? pDataPagamento = null)
        {
            if (pDataPagamento.HasValue)
            {
                await new DaoParcela().AtualizarSituacaoParcelaAsync(pIdVenda, pNumParcela, pNovaSituacaoParcela, pDataPagamento);
            }
            else
                await new DaoParcela().AtualizarSituacaoParcelaAsync(pIdVenda, pNumParcela, pNovaSituacaoParcela);

            // Quitar Venda em caso de todas as Parcelas terem sido pagas
            if(pNovaSituacaoParcela == SituacaoParcela.PagoComAtraso || pNovaSituacaoParcela == SituacaoParcela.PagoSemAtraso)
            {
                List<DmoParcela> parcelasDaVenda = await new BoParcela().ConsultarParcelasDaVendaAsync(pIdVenda);

                if(!parcelasDaVenda.Any(p => p.SituacaoParcela == SituacaoParcela.EmAberto))
                {
                    await new BoVenda().AtualizarSituacaoVendaAsync(pIdVenda, SituacaoVenda.Concluido);
                }
            }
        }
    }
}
