using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI.OpcoesAvancadas
{
    public partial class OpcoesAvancadasDoCliente : Form
    {
        public OpcoesAvancadasDoCliente()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Carrega as configurações definidas pelo usuário e preenche os campos correspondentes na tela.
        /// </summary>
        private void CarregarConfiguracoes()
        {
            int diasInadimplenciaCliente = Properties.Settings.Default.ConfClienteDiasInadimplencia;
            
            if (diasInadimplenciaCliente > 0) 
                txtDiasInadimplencia.Text = diasInadimplenciaCliente.ToString();
            else
                txtDiasInadimplencia.Text = INF.ParametrosDoSistema.ConfClienteValorPadraoDiasParaInadimplencia.ToString();
        }
        #endregion

        #region Eventos
        private void OpcoesAvancadasDoCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            CarregarConfiguracoes();
        }

        private void txtDiasInadimplencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtDiasInadimplencia_TextChanged(object sender, EventArgs e)
        {
            string valorInserido = txtDiasInadimplencia.Text.Trim();

            if (string.IsNullOrEmpty(valorInserido))
            {
                txtDiasInadimplencia.Text = INF.ParametrosDoSistema.ConfClienteValorPadraoDiasParaInadimplencia.ToString();
                return;
            }

            int novaConfiguracao = Convert.ToInt32(valorInserido);

            if (novaConfiguracao <= 0)
                txtDiasInadimplencia.Text = INF.ParametrosDoSistema.ConfClienteValorPadraoDiasParaInadimplencia.ToString();
        }

        #endregion

        private void btnSalvarConfiguracoes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDiasInadimplencia.Text.Trim()))
            {
                int novaConfiguracao = Convert.ToInt32(txtDiasInadimplencia.Text.Trim());
                Properties.Settings.Default.ConfClienteDiasInadimplencia = novaConfiguracao;
            }
            
        }
    }
}
