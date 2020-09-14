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

namespace KadoshModas.UI.FichaClienteUtil
{
    public partial class AcrescentarDivida : Form
    {
        #region Construtor(es)
        public AcrescentarDivida()
        {
            InitializeComponent();
        }

        public AcrescentarDivida(DmoCliente pCliente)
        {
            InitializeComponent();
            this.Cliente = pCliente;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Cliente para qual a nova Venda será cadastrada
        /// </summary>
        private DmoCliente Cliente { get; set; }
        #endregion

        #region Eventos
        private void AcrescentarDivida_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtValorDivida_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtValorDivida.Text.Trim()))
                {
                    MessageBox.Show("Informe o valor da dívida do Cliente para prosseguir.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!Double.TryParse(txtValorDivida.Text.Trim(), out double valorDivida))
                {
                    MessageBox.Show("Um valor inválido foi inserido no campo Valor da Dívida. Por favor forneça um valor numérico válido e positivo.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region Entrada
                double entrada = 0;

                if (!string.IsNullOrEmpty(txtEntrada.Text.Trim()))
                {
                    if (!Double.TryParse(txtEntrada.Text.Trim(), out entrada))
                    {
                        if (MessageBox.Show("Um valor inválido foi inserido no campo Entrada. Gostaria de prosseguir inclusão de nova dívida para o cliente SEM ENTRADA?", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.No)
                            return;
                        else
                        {
                            rdoNao.Checked = true;
                        }
                    }
                }
                #endregion

                #region Concluir Inclusão da Nova Venda
                if (MessageBox.Show($"Confirma inclusão de nova dívida no valor de {valorDivida:C} para o cliente {Cliente.Nome}? Esta dívida será incluída com a situação EM ABERTO e forma de pagamento FIADO.", "Confirmar inclusão de nova dívida", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await CadastrarNovaVendaComoDivida(valorDivida, entrada);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao incluir nova dívida: " + erro.Message, "Erro inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            #endregion
        }

        private void rdoNao_CheckedChanged(object sender, EventArgs e)
        {
            txtEntrada.Clear();
            lblEntradaRotulo.Visible = txtEntrada.Visible = lblEntrada.Visible = !rdoNao.Checked;
        }

        private void rdoSim_CheckedChanged(object sender, EventArgs e)
        {
            lblEntradaRotulo.Visible = txtEntrada.Visible = lblEntrada.Visible = rdoSim.Checked;
        }

        private void txtEntrada_TextChanged(object sender, EventArgs e)
        {
            double entrada = 0;

            if (!string.IsNullOrEmpty(txtEntrada.Text.Trim()))
            {
                Double.TryParse(txtEntrada.Text.Trim(), out entrada);
            }

            lblEntrada.Text = entrada.ToString("C");
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Cadastra uma nova Venda com a situação EM ABERTO e forma de pagamento FIADO para o Cliente
        /// </summary>
        /// <param name="pValorDivida">Valor do Total da Venda definido em tela</param>
        /// <param name="pEntrada">Valor de Entrada da Venda definido em tela</param>
        private async Task CadastrarNovaVendaComoDivida(double pValorDivida, double pEntrada)
        {
            DmoVenda novaVenda = new DmoVenda
            {
                Cliente = Cliente,
                TipoPagamento = TipoPagamento.Fiado,
                FormaDePagamento = FormaDePagamento.Dinheiro,
                QtdParcelas = 1,
                Desconto = 0,
                Entrada = pEntrada,
                Situacao = SituacaoVenda.EmAberto,
                Total = pValorDivida,
                Pago = pEntrada,
                DataVenda = DateTime.Today,

            };

            await new BoVenda().CadastrarAsync(novaVenda);
            MessageBox.Show($"Dívida no valor de {novaVenda.Total:C} incluída para o cliente {Cliente.Nome} com sucesso!", "Dívida incluída com sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        #endregion
    }
}
