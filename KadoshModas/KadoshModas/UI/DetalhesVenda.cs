using KadoshModas.BLL;
using KadoshModas.DML;
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
            MontarAmbienteInicial(pDmoVenda);
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
        private void MontarAmbienteInicial(DmoVenda pDmoVenda)
        {
            lblSituacaoVenda.Text = DmoVenda.DescricaoEnum<DmoVenda.SituacoesVenda>(pDmoVenda.Situacao);
            lblTotalVenda.Text = new BoVenda().TotalDaVenda(pDmoVenda).ToString("C");

            if(pDmoVenda.Situacao != DmoVenda.SituacoesVenda.Concluido)
            {
                pnlSituacaoVenda.BackColor = Color.DarkBlue;
            }

            lblNomeDoCliente.Text = pDmoVenda.Cliente.Nome;

            foreach(DmoItemDaVenda item in pDmoVenda.ItensDaVenda)
            {
                lstItensDaVenda.Items.Add(new ListViewItem(new string[] { item.Quantidade.ToString(), item.Produto.Nome, item.Valor.ToString("C"), item.Desconto + "%" }));
            }

            lblFormaDePagamento.Text = DmoBase.DescricaoEnum<DmoVenda.FormasDePagamento>(pDmoVenda.FormaDePagamento);
            if (pDmoVenda.ParcelasDaVenda.Any())
            {
                lblFormaDePagamento.Text += $" em {pDmoVenda.ParcelasDaVenda.Count}x";
                lblEntrada.Text = pDmoVenda.Entrada.ToString("C");
                CarregarParcelas(pDmoVenda.ParcelasDaVenda);
            }
            else
            {
                lblFormaDePagamento.Text += " à Vista";
                tbcDetalhesVenda.TabPages.Remove(tbpParcelas);
            }

            if (pDmoVenda.Situacao == DmoVenda.SituacoesVenda.Concluido)
                btnQuitarParcelas.Visible = false;
        }

        /// <summary>
        /// Carrega as Parcelas da Venda na Grid de Parcelas
        /// </summary>
        /// <param name="pListaDeParcelas">Lista de Parcelas da Venda</param>
        private void CarregarParcelas(List<DmoParcela> pListaDeParcelas)
        {
            pnlParcelas.Controls.Clear();
            int parcelasEmAberto = pListaDeParcelas.FindAll(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.EmAberto).Count();
            int parcelasPagasSemAtraso = pListaDeParcelas.FindAll(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.PagoSemAtraso).Count();
            int parcelasPagasComAtraso = pListaDeParcelas.FindAll(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.PagoComAtraso).Count();
            int parcelasCanceladas = pListaDeParcelas.FindAll(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.Cancelado).Count();

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

            if (!pListaDeParcelas.Any(p => p.SituacaoParcela == DmoParcela.SituacoesParcela.EmAberto))
                btnQuitarParcelas.Visible = false;
        }

        private float TotalParcelasEmAberto (List<DmoParcela> pListaDeParcelas)
        {
            float totalParcelas = 0;

            foreach (DmoParcela parcela in pListaDeParcelas)
            {
                if (parcela.SituacaoParcela == DmoParcela.SituacoesParcela.EmAberto)
                    totalParcelas += parcela.ValorParcela;
            }

            return totalParcelas;
        }
        #endregion

        #region Eventos
        private void btnQuitarParcelas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Confirmar pagamento de todas as parcelas Em Aberto da Venda no valor de { TotalParcelasEmAberto(Venda.ParcelasDaVenda):C}", "Confirma Quitar Todas as Parcelas", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DmoParcela parcela in Venda.ParcelasDaVenda)
                {
                    if (parcela.SituacaoParcela == DmoParcela.SituacoesParcela.EmAberto)
                    {
                        if (DateTime.Now > parcela.Vencimento)
                            new BoParcela().AtualizarSituacaoParcela(int.Parse(Venda.IdVenda.ToString()), parcela.Parcela, DmoParcela.SituacoesParcela.PagoComAtraso, DateTime.Now);
                        else
                            new BoParcela().AtualizarSituacaoParcela(int.Parse(Venda.IdVenda.ToString()), parcela.Parcela, DmoParcela.SituacoesParcela.PagoSemAtraso, DateTime.Now);
                    }
                }

                Venda.ParcelasDaVenda = new BoParcela().ConsultarParcelasDaVenda(Venda.IdVenda);
                Venda.Situacao = DmoVenda.SituacoesVenda.Concluido;

                MontarAmbienteInicial(Venda);
            }
        }
        #endregion
    }
}
