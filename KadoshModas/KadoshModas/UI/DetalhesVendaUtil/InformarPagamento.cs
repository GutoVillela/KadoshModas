using KadoshModas.BLL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.DetalhesVendaUtil
{
    public partial class InformarPagamento : Form
    {
        #region Construtor
        public InformarPagamento()
        {
            InitializeComponent();
        }

        public InformarPagamento(DmoVenda pVenda)
        {
            InitializeComponent();
            this.Venda = pVenda;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Informações da Venda
        /// </summary>
        private DmoVenda Venda { get; set; }

        /// <summary>
        /// Valor Informado em Tela pelo Usuário
        /// </summary>
        private double ValorInformado { get; set; }
        #endregion

        #region Eventos
        private void InformarPagamento_Load(object sender, EventArgs e)
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

        private void chkQuitarVenda_CheckedChanged(object sender, EventArgs e)
        {
            txtValorPago.ReadOnly = chkQuitarVenda.Checked;

            if (chkQuitarVenda.Checked)
            {
                txtValorPago.Text = (Venda.Total - Venda.Pago).ToString("N");
            }

        }

        private void txtValorPago_TextChanged(object sender, EventArgs e)
        {
            double valorInformado = string.IsNullOrEmpty(txtValorPago.Text) ? 0d : double.Parse(txtValorPago.Text);

            if (valorInformado > Venda.Total - Venda.Pago)
            {
                valorInformado = Venda.Total - Venda.Pago;
                MessageBox.Show($"Valor pago não pode ser maior do que a dívida do Cliente! Valor alterado para {valorInformado:C}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtValorPago.Text = valorInformado.ToString("N");
            }

            ValorInformado = valorInformado;
        }

        private async void btnOK_Click(object sender, EventArgs e)
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
                Venda.Pago += ValorInformado;
                await new BoVenda().AtualizarValorPagoAsync(Convert.ToInt32(Venda.IdVenda), Venda.Pago);

                if (Venda.Pago == Venda.Total)
                {
                    Venda.Situacao = SituacaoVenda.Concluido;
                    await new BoVenda().AtualizarSituacaoVendaAsync(Convert.ToInt32(Venda.IdVenda), Venda.Situacao);
                }

                this.Close();
            }
        }
        #endregion
    }
}
