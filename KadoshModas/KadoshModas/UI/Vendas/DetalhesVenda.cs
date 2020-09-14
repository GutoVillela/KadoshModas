using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.UI.DetalhesVendaUtil;
using KadoshModas.UI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI
{
    public partial class DetalhesVenda : Form
    {
        #region Construtor
        public DetalhesVenda()
        {
            InitializeComponent();
            _cancelarProcessamento = new CancellationTokenSource();
        }

        /// <summary>
        /// Inicializar o formulário de Detalhes da Venda com as informações da Venda enviados
        /// </summary>
        /// <param name="pDmoVenda"></param>
        public DetalhesVenda(DmoVenda pDmoVenda)
        {
            InitializeComponent();
            Venda = pDmoVenda;
            _cancelarProcessamento = new CancellationTokenSource();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Token de Cancelamento responsável pelo cancelamento da tarefa caso o usuário feche o formulário antes do término do processamento.
        /// </summary>
        private CancellationTokenSource _cancelarProcessamento;
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade com todas as informações da Venda manipuladas nesta tela
        /// </summary>
        private DmoVenda Venda { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Monta o ambiente inicial utilizando as informações fornecidas
        /// </summary>
        /// <param name="pDmoVenda">Objeto DmoVenda preenchido com informações da Venda</param>
        private void MontarAmbienteInicial(DmoVenda pDmoVenda)
        {
            //Informações da Venda
            lblSituacaoVenda.Text = pDmoVenda.Situacao.DescricaoEnum();

            lblNrVenda.Text = pDmoVenda.IdVenda.ToString();

            if (pDmoVenda.ItensDaVenda == null || !pDmoVenda.ItensDaVenda.Any())
                lblTotalVenda.Text = pDmoVenda.Total.ToString("C");
            else
                lblTotalVenda.Text = pDmoVenda.TotalDaVenda().ToString("C");

            if (pDmoVenda.Situacao == SituacaoVenda.EmAberto)
            {
                pnlSituacaoVenda.BackColor = Color.DarkBlue;
                lblDetalhesPagamento.Text = $"Total da Venda: {pDmoVenda.Total:C} - Pago até agora: {pDmoVenda.Pago:C} - Falta pagar: {pDmoVenda.FaltaPagar():C}";
            }
            else if (pDmoVenda.Situacao == SituacaoVenda.Concluido)
            {
                btnPagarValor.Visible = false;
                pnlSituacaoVenda.BackColor = Color.DarkGreen;
                lblDetalhesPagamento.Text = $"Total da Venda: {pDmoVenda.Total:C} - Forma de pagamento: " + pDmoVenda.FormaDePagamento.DescricaoEnum() + " " + pDmoVenda.TipoPagamento.DescricaoEnum();
            }

            if(pDmoVenda.Cliente != null)
                lblNomeDoCliente.Text = pDmoVenda.Cliente.Nome;
            else
                lblNomeDoCliente.Text = "Cliente Indefinido";

            // Itens da Venda
            lstItensDaVenda.Items.Clear();
            foreach(DmoItemDaVenda item in pDmoVenda.ItensDaVenda)
            {
                if(item.Situacao != SituacaoItemDaVenda.Cancelado)
                {
                    lstItensDaVenda.Items.Add(new ListViewItem(new string[] { 
                        item.Quantidade.ToString(), 
                        item.Produto.Nome, 
                        item.Valor.ToString("C"),
                        item.Desconto + "%", 
                        item.DescricaoSituacao }));

                    lstItensDaVenda.Items[lstItensDaVenda.Items.Count - 1].Tag = item;
                }
            }

            lblFormaDePagamento.Text = pDmoVenda.FormaDePagamento.DescricaoEnum() + " " + pDmoVenda.TipoPagamento.DescricaoEnum();

            if (pDmoVenda.ParcelasDaVenda.Any())
            {
                lblFormaDePagamento.Text += $" em {pDmoVenda.ParcelasDaVenda.Count}x";
                lblEntrada.Text = pDmoVenda.Entrada.ToString("C");
                CarregarParcelas(pDmoVenda.ParcelasDaVenda);
            }
            else
            {
                tbcDetalhesVenda.TabPages.Remove(tbpParcelas);
            }

            if (pDmoVenda.Situacao == SituacaoVenda.Concluido)
                btnQuitarParcelas.Visible = false;
        }

        /// <summary>
        /// Carrega as Parcelas da Venda na Grid de Parcelas
        /// </summary>
        /// <param name="pListaDeParcelas">Lista de Parcelas da Venda</param>
        private void CarregarParcelas(List<DmoParcela> pListaDeParcelas)
        {
            pnlParcelas.Controls.Clear();
            int parcelasEmAberto = pListaDeParcelas.FindAll(p => p.SituacaoParcela == SituacaoParcela.EmAberto).Count();
            int parcelasPagasSemAtraso = pListaDeParcelas.FindAll(p => p.SituacaoParcela == SituacaoParcela.PagoSemAtraso).Count();
            int parcelasPagasComAtraso = pListaDeParcelas.FindAll(p => p.SituacaoParcela == SituacaoParcela.PagoComAtraso).Count();
            int parcelasCanceladas = pListaDeParcelas.FindAll(p => p.SituacaoParcela == SituacaoParcela.Cancelado).Count();

            lblNumeroDeParcelas.Text = pListaDeParcelas.Count + " (";

            if (parcelasEmAberto > 0)
                lblNumeroDeParcelas.Text += $" - { parcelasEmAberto } Em Aberto";
            if(parcelasPagasSemAtraso > 0)
                lblNumeroDeParcelas.Text += $" - { parcelasPagasSemAtraso } Pagas Sem Atraso";
            if (parcelasPagasComAtraso > 0)
                lblNumeroDeParcelas.Text += $" - { parcelasPagasComAtraso } Pagas Com Atraso";
            if (parcelasCanceladas > 0)
                lblNumeroDeParcelas.Text += $" - { parcelasCanceladas } Canceladas";

            lblNumeroDeParcelas.Text += ")";

            foreach (DmoParcela parcela in pListaDeParcelas)
            {
                ucParcelaVenda parcelaVenda = new ucParcelaVenda()
                {
                    Parcela = parcela
                };
                pnlParcelas.Controls.Add(parcelaVenda);
            }

            if (!pListaDeParcelas.Any(p => p.SituacaoParcela == SituacaoParcela.EmAberto))
                btnQuitarParcelas.Visible = false;
        }
        
        /// <summary>
        /// Carrega os Lançamentos da Venda na Grid de Lançamentos.
        /// </summary>
        /// <param name="pListaLancamentos">Lista de Lançamentos a ser carregada.</param>
        private void CarregarLancamentosDaVenda(List<DmoLancamentoDoCliente> pListaLancamentos)
        {
            lstLancamentos.Items.Clear();
            foreach (var item in pListaLancamentos.OrderBy(i => i.TipoLancamentoDoCliente))
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { 
                    item.DataDoLancamento.ToString("dd/MM/yyyy"),
                    item.ValorLancamento.ToString("C"),
                    item.TipoLancamentoDoCliente.DescricaoEnum()
                });

                if (
                    // Identificar Lançamentos de Entrada
                    item.TipoLancamentoDoCliente == TipoLancamentoDoCliente.Entrada ||
                    item.TipoLancamentoDoCliente == TipoLancamentoDoCliente.CompraAVista ||
                    item.TipoLancamentoDoCliente == TipoLancamentoDoCliente.Pagamento
                    )
                    listViewItem.BackColor = Color.LightGreen;
                else
                    listViewItem.BackColor = Color.LightSalmon;
                lstLancamentos.Items.Add(listViewItem);
            }
        }
        #endregion

        #region Eventos
        private void btnPagarValor_Click(object sender, EventArgs e)
        {
            new InformarPagamento(Venda).ShowDialog();
            MontarAmbienteInicial(Venda);
        }

        private void DetalhesVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            MontarAmbienteInicial(Venda);
        }

        private async void btnQuitarParcelas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Confirmar pagamento de todas as parcelas Em Aberto da Venda no valor de { Venda.TotalParcelasEmAberto():C}", "Confirma Quitar Todas as Parcelas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DmoParcela parcela in Venda.ParcelasDaVenda)
                {
                    if (parcela.SituacaoParcela == SituacaoParcela.EmAberto)
                    {
                        if (DateTime.Now > parcela.Vencimento)
                            await new BoParcela().AtualizarSituacaoParcelaAsync(int.Parse(Venda.IdVenda.ToString()), parcela.Parcela, SituacaoParcela.PagoComAtraso, DateTime.Now);
                        else
                            await new BoParcela().AtualizarSituacaoParcelaAsync(int.Parse(Venda.IdVenda.ToString()), parcela.Parcela, SituacaoParcela.PagoSemAtraso, DateTime.Now);
                    }
                }

                Venda.ParcelasDaVenda = await new BoParcela().ConsultarParcelasDaVendaAsync(Venda.IdVenda);
                Venda.Situacao = SituacaoVenda.Concluido;

                MontarAmbienteInicial(Venda);
            }
        }
        private async void apagarItemDaVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstItensDaVenda.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um item da venda para apagar.", "Selecione um item da venda para continuar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DmoItemDaVenda itemDaVenda = (DmoItemDaVenda)lstItensDaVenda.SelectedItems[0].Tag;

            if (MessageBox.Show($"Tem certeza que deseja remover o item {itemDaVenda.Produto.Nome} desta venda?", "Tem certeza disso?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new CancelarItemDaVenda(itemDaVenda, Venda).ShowDialog();
                Venda = await new BoVenda().ConsultarVendaPorIdAsync(Convert.ToInt32(Venda.IdVenda));
                MontarAmbienteInicial(Venda);
            }
        }

        private async void tbcDetalhesVenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcDetalhesVenda.SelectedTab == tbpLancamentos)
            {
                CarregarLancamentosDaVenda(await new BoLancamentoDoCliente().ConsultarLancamentosAgrupadosPorClienteETipoDeLancamento(_cancelarProcessamento.Token, pVenda: Venda.IdVenda, pBuscaClientes: false));
            }
        }

        private void DetalhesVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar processamento caso o formulário esteja sendo fechado
            _cancelarProcessamento.Cancel();
        }
        #endregion
    }
}
