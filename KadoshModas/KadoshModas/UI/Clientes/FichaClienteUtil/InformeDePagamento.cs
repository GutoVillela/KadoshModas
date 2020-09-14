using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.UI.Dialogos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.FichaClienteUtil
{
    public partial class InformeDePagamento : Form
    {
        #region Construtor(es)
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public InformeDePagamento()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Construtor que informa lista de Vendas a serem quitadas do Cliente.
        /// </summary>
        /// <param name="pVendasAQuitar">Lista de Vendas a serem quitadas do Cliente.</param>
        public InformeDePagamento(List<DmoVenda> pVendasAQuitar)
        {
            InitializeComponent();
            this.VendasAQuitar = pVendasAQuitar;

            double dividaTotal = 0;
            foreach (DmoVenda venda in VendasAQuitar)
                dividaTotal += venda.FaltaPagar();

            this.DividaTotal = dividaTotal;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Vendas a Quitar do Cliente
        /// </summary>
        private List<DmoVenda> VendasAQuitar { get; set; }

        /// <summary>
        /// Valor total da dívida do Cliente
        /// </summary>
        private double DividaTotal { get; set; }

        /// <summary>
        /// Valor Informado em Tela pelo Usuário
        /// </summary>
        private double ValorInformado { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Informa o pagamento do valor indicado em tela e quita Vendas até o valor indicado de forma assíncrona.
        /// </summary>
        private async Task InformarPagamentoAsync()
        {
            if (ValorInformado <= 0)
            {
                if (MessageBox.Show("Um valor de pagamento válido não foi definido. Caso não informe outro valor o pagamento será cancelado. Gostaria de informar outro valor?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                double valorPago = ValorInformado;

                foreach(var venda in VendasAQuitar.OrderBy(i => i.DataVenda).ToList())
                {
                    double valorALancar = valorPago;

                    if (valorPago <= venda.FaltaPagar())
                    {
                        venda.Pago += valorPago;
                        valorPago = 0;
                    }
                    else
                    {
                        valorPago -= venda.FaltaPagar();
                        venda.Pago += venda.FaltaPagar();
                    }

                    #region Registrar Lançamento do Cliente
                    DmoLancamentoDoCliente lancamentoDoCliente = new DmoLancamentoDoCliente
                    {
                        Cliente = venda.Cliente,
                        TipoLancamentoDoCliente = TipoLancamentoDoCliente.Pagamento,
                        ValorLancamento = valorALancar,
                        Venda = venda,
                        DataDoLancamento = DateTime.Now
                    };

                    await new BoLancamentoDoCliente().CadastrarAsync(lancamentoDoCliente);
                    #endregion

                    await new BoVenda().AtualizarValorPagoAsync(venda, venda.Pago);

                    if (venda.Pago == venda.Total)
                    {
                        venda.Situacao = SituacaoVenda.Concluido;
                        await new BoVenda().AtualizarSituacaoVendaAsync(Convert.ToInt32(venda.IdVenda), venda.Situacao);
                    }

                    if (valorPago <= 0)
                        break;
                }

                new AlertaPersonalizado().MostrarAlerta("Pagamento informado.", TipoAlerta.Sucesso);
                this.Close();
            }
        }
        #endregion

        #region Eventos
        private void InformeDePagamento_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // Permitir somente um caractere decimal
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            double valorInformado = string.IsNullOrEmpty(txtValorPago.Text) ? 0d : double.Parse(txtValorPago.Text);

            if (valorInformado > DividaTotal)
            {
                valorInformado = DividaTotal;
                MessageBox.Show($"Valor pago não pode ser maior do que a dívida do Cliente! Valor alterado para {valorInformado:C}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorPago.Text = valorInformado.ToString("N");
            }

            ValorInformado = valorInformado;
        }

        private void chkQuitarVenda_CheckedChanged(object sender, EventArgs e)
        {
            txtValorPago.ReadOnly = chkQuitarVenda.Checked;

            if (chkQuitarVenda.Checked)
            {
                txtValorPago.Text = DividaTotal.ToString("N");
            }
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            await InformarPagamentoAsync();
        }

        #endregion
    }
}
