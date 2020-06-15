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
        }

        /// <summary>
        /// Inicializar o formulário de Detalhes da Venda com as informações da Venda enviados
        /// </summary>
        /// <param name="pDmoVenda"></param>
        public DetalhesVenda(DmoVenda pDmoVenda)
        {
            InitializeComponent();
            Venda = pDmoVenda;
        }
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
        private async Task MontarAmbienteInicialAsync(DmoVenda pDmoVenda)
        {
            //Informações da Venda
            lblSituacaoVenda.Text = DmoVenda.DescricaoEnum<SituacaoVenda>(pDmoVenda.Situacao);
            lblTotalVenda.Text = new BoVenda().TotalDaVenda(pDmoVenda).ToString("C");

            if (pDmoVenda.Situacao == SituacaoVenda.EmAberto)
            {
                pnlSituacaoVenda.BackColor = Color.DarkBlue;
                lblDetalhesPagamento.Text = $"Total da Venda: {pDmoVenda.Total:C} - Pago até agora: {pDmoVenda.Pago:C} - Falta pagar: {pDmoVenda.Total - pDmoVenda.Pago:C}";
            }
            else if (pDmoVenda.Situacao == SituacaoVenda.Concluido)
            {
                btnPagarValor.Visible = false;
                pnlSituacaoVenda.BackColor = Color.DarkGreen;
                lblDetalhesPagamento.Text = $"Total da Venda: {pDmoVenda.Total:C} - Forma de pagamento: " + DmoBase.DescricaoEnum<FormaDePagamento>(pDmoVenda.FormaDePagamento) + " " + DmoBase.DescricaoEnum<TipoPagamento>(pDmoVenda.TipoPagamento);
            }

            if(pDmoVenda.Cliente != null)
                lblNomeDoCliente.Text = pDmoVenda.Cliente.Nome;
            else
                lblNomeDoCliente.Text = "Cliente Indefinido";

            // Itens da Venda
            lstItensDaVenda.Items.Clear();
            foreach(DmoItemDaVenda item in pDmoVenda.ItensDaVenda)
            {
                lstItensDaVenda.Items.Add(new ListViewItem(new string[] { item.Quantidade.ToString(), item.Produto.Nome, item.Valor.ToString("C"), item.Desconto + "%" }));
            }

            lblFormaDePagamento.Text = DmoBase.DescricaoEnum<FormaDePagamento>(pDmoVenda.FormaDePagamento) + " " + DmoBase.DescricaoEnum<TipoPagamento>(pDmoVenda.TipoPagamento);

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

        private double TotalParcelasEmAberto (List<DmoParcela> pListaDeParcelas)
        {
            double totalParcelas = 0;

            foreach (DmoParcela parcela in pListaDeParcelas)
            {
                if (parcela.SituacaoParcela == SituacaoParcela.EmAberto)
                    totalParcelas += parcela.ValorParcela;
            }

            return totalParcelas;
        }
        #endregion

        #region Eventos
        private async void btnPagarValor_Click(object sender, EventArgs e)
        {
            new InformarPagamento(Venda).ShowDialog();
            await MontarAmbienteInicialAsync(Venda);
        }

        private async void DetalhesVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync(Venda);
        }

        private async void btnQuitarParcelas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Confirmar pagamento de todas as parcelas Em Aberto da Venda no valor de { TotalParcelasEmAberto(Venda.ParcelasDaVenda):C}", "Confirma Quitar Todas as Parcelas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
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

                await MontarAmbienteInicialAsync(Venda);
            }
        }
        #endregion
    }
}
