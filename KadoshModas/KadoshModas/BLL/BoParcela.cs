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
        /// Cadastra uma nova Parcela
        /// </summary>
        /// <param name="pDmoParcela">Objeto DmoParcela preenchido</param>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        public bool Cadastrar(DmoParcela pDmoParcela)
        {
            try
            {
                if (pDmoParcela.Venda == null || pDmoParcela.Venda.IdVenda == null)
                    throw new ArgumentException("A propriedade Venda de pDmoParcela é obrigatória e deve conter um Id de Venda associado.");

                new DaoParcela().Cadastrar(pDmoParcela);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Consulta todas as Parcelas de uma Venda específica
        /// </summary>
        /// <param name="pIdVenda">Id da Venda</param>
        /// <returns>Lista de Parcelas da Venda</returns>
        public List<DmoParcela> ConsultarParcelasDaVenda(int? pIdVenda)
        {
            return new DaoParcela().ConsultarParcelasDaVenda(pIdVenda);
        }

        /// <summary>
        /// Atualiza a Situação da Parcela de uma determinada Venda
        /// </summary>
        /// <param name="pIdVenda">ID da Venda</param>
        /// <param name="pNumParcela">Número da Parcela</param>
        /// <param name="pNovaSituacaoParcela">Nova Situação da Venda</param>
        public void AtualizarSituacaoParcela(int pIdVenda, int pNumParcela, DmoParcela.SituacoesParcela pNovaSituacaoParcela, DateTime? pDataPagamento = null)
        {
            if(pDataPagamento.HasValue)
                new DaoParcela().AtualizarSituacaoParcela(pIdVenda, pNumParcela, pNovaSituacaoParcela, pDataPagamento);
            else
                new DaoParcela().AtualizarSituacaoParcela(pIdVenda, pNumParcela, pNovaSituacaoParcela);

            // Quitar Venda em caso de todas as Parcelas terem sido pagas
            if(pNovaSituacaoParcela == DmoParcela.SituacoesParcela.PagoComAtraso || pNovaSituacaoParcela == DmoParcela.SituacoesParcela.PagoSemAtraso)
            {
                List<DmoParcela> parcelasDaVenda = new BoParcela().ConsultarParcelasDaVenda(pIdVenda);

                if(!parcelasDaVenda.Any(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.EmAberto))
                {
                    new BoVenda().AtualizarSituacaoVenda(pIdVenda, DmoVenda.SituacoesVenda.Concluido);
                }
            }
        }
    }
}
