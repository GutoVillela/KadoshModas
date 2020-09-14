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

namespace KadoshModas.UI
{
    public partial class OpcoesAvancadasDaVenda : Form
    {
        #region Construtor(es)
        public OpcoesAvancadasDaVenda()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Calcula e atualiza o total de todas as Vendas
        /// </summary>
        private async Task CalcularEAtualizarTotalVendas()
        {
            #region Informar processamento ao usuário
            this.Cursor = Cursors.WaitCursor;
            pnlStatusExecucao.Visible = true;
            pnlStatusExecucao.BackColor = Color.LightBlue;
            lblStatusExecucao.Text = "Atualizando total. Aguarde um momento...";
            TravarOuDestravarInterface(true);
            #endregion

            try
            {
                List<DmoVenda> vendas = await new BoVenda().ConsultarAsync(new System.Threading.CancellationToken());

                foreach (DmoVenda venda in vendas)
                {
                    if(venda.ItensDaVenda != null && venda.ItensDaVenda.Any())
                        await new BoVenda().CalcularEAtualizarTotalAsync(venda);
                }

                pnlStatusExecucao.BackColor = Color.LightGreen;
                lblStatusExecucao.Text = "Sucesso!";
                new AlertaPersonalizado().MostrarAlerta("Total das vendas atualizados.", TipoAlerta.Sucesso);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro inesperado ao tentar calcular total de todas as Vendas. Mensagem original: " + erro.Message, "Aconteceu um erro inesperado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pnlStatusExecucao.BackColor = Color.LightPink;
                lblStatusExecucao.Text = "Erro!";
                new AlertaPersonalizado().MostrarAlerta("Aconteu um erro!", TipoAlerta.Erro);
            }
            finally
            {
                #region Informar final de processamento ao usuário
                this.Cursor = Cursors.Default;
                TravarOuDestravarInterface(false);
                #endregion
            }
        }

        /// <summary>
        /// Trava ou destrava todos os controles na interface deste formulário.
        /// </summary>
        /// <param name="pTravar">Se true, TRAVA os controles, se false, DESTRAVA os controles</param>
        private void TravarOuDestravarInterface(bool pTravar)
        {
            btnCalcularTotalVendas.Enabled = !pTravar;
        }
        #endregion

        #region Eventos
        private void OpcoesAvancadasDaVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private async void btnCalcularTotalVendas_Click(object sender, EventArgs e)
        {
            await CalcularEAtualizarTotalVendas();
        }
        #endregion
    }
}
