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
        public void Cadastrar(DmoVenda pVenda)
        {
            #region Cadastro da Venda
            if (pVenda == null)
                throw new ArgumentNullException("O parâmetro pVenda é obrigatório e não pode ser nulo.");

            if (pVenda.Cliente == null || pVenda.Cliente.IdCliente == null)
                throw new ArgumentException("A propriedade Cliente de pVenda é obrigatória e deve conter um Id de Cliente associado.");

            if (pVenda.ItensDaVenda == null || pVenda.ItensDaVenda.Count <= 0)
                throw new ArgumentException("É obrigatório pelo menos um Item da Venda associado à propriedade ItensDaVenda para cadastrar esta Venda.");

            
            pVenda.IdVenda = new DaoVenda().Cadastrar(pVenda);
            #endregion

            #region Cadastro dos Itens da Venda
            foreach (DmoItemDaVenda itemDaVenda in pVenda.ItensDaVenda)
            {
                itemDaVenda.Venda = pVenda;
                new BoItemDaVenda().Cadastrar(itemDaVenda);
            }
            #endregion

            #region Cadastro das Parcelas, caso haja
            if(pVenda.ParcelasDaVenda.Any())
            {
                foreach(DmoParcela parcela in pVenda.ParcelasDaVenda)
                {
                    parcela.Venda = pVenda;
                    new BoParcela().Cadastrar(parcela);
                }
            }
            #endregion
        }

        /// <summary>
        /// Consulta todas as Vendas Cadastradas
        /// </summary>
        /// <param name="pClientes">Se fornecido, retorna somente Vendas dos Clientes fornecidos</param>
        /// <param name="pSituacoesVendas">Se fornecido, retorna somente Vendas COM as Situações fornecidas</param>
        /// <param name="pDataInicial">Se fornecido, retorna somente Vendas A PARTIR da Data Inicial fornecida</param>
        /// <param name="pDataFinal">Se fornecido, retorna somente Vendas ATÉ a Data Final fornecida</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public List<DmoVenda> Consultar(List<DmoCliente> pClientes = null, List<DmoVenda.SituacoesVenda> pSituacoesVendas = null, DateTime? pDataInicial = null, DateTime? pDataFinal = null)
        {
            List<DmoVenda> vendas = new DaoVenda().Consultar(pClientes, pSituacoesVendas, pDataInicial, pDataFinal);

            foreach (DmoVenda compra in vendas)
            {
                compra.Cliente = new BoCliente().ConsultarClientePorId(int.Parse(compra.Cliente.IdCliente.ToString()));

                compra.ItensDaVenda = new BoItemDaVenda().ConsultarItensDaVenda(compra.IdVenda);

                if (compra.QtdParcelas > 0)
                {
                    compra.ParcelasDaVenda = new BoParcela().ConsultarParcelasDaVenda(compra.IdVenda);
                }

            }

            return vendas;
        }

        /// <summary>
        /// Consulta todas as Vendas associadas ao Cliente
        /// </summary>
        /// <param name="pIdCliente">Id do Cliente</param>
        /// <returns>Retorna uma lista de Vendas</returns>
        public List<DmoVenda> ConsultarComprasDoCliente(int? pIdCliente)
        {
            if (pIdCliente == null)
                throw new ArgumentException("O parâmetro pIdCliente é obrigatório e deve ser preenchido com um ID de Cliente válido.");

            List<DmoVenda> comprasDoCliente = new DaoVenda().ConsultarComprasDoCliente(pIdCliente);

            foreach(DmoVenda compra in comprasDoCliente)
            {
                compra.Cliente = new BoCliente().ConsultarClientePorId(int.Parse(compra.Cliente.IdCliente.ToString()));

                compra.ItensDaVenda = new BoItemDaVenda().ConsultarItensDaVenda(compra.IdVenda);
                
                if(compra.QtdParcelas > 0)
                {
                    compra.ParcelasDaVenda = new BoParcela().ConsultarParcelasDaVenda(compra.IdVenda);
                }
            }

            return comprasDoCliente;
        }

        /// <summary>
        /// Atualiza a Situação da Venda
        /// </summary>
        /// <param name="pIdVenda">ID da Venda para Atualizar</param>
        /// <param name="pNovaSituacaoVenda">Nova Situação da Venda</param>
        public void AtualizarSituacaoVenda(int pIdVenda, DmoVenda.SituacoesVenda pNovaSituacaoVenda)
        {
            new DaoVenda().AtualizarSituacaoVenda(pIdVenda, pNovaSituacaoVenda);
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
        /// Busca quantas Vendas existem atualmente cadastradas
        /// </summary>
        /// <returns>Retorna quantidade de Vendas cadastradas</returns>
        public int ContarVendas()
        {
            return new DaoVenda().ContarVendas();
        }
        #endregion
    }
}
