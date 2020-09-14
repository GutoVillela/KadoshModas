using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.INF;
using KadoshModas.Properties;
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
    public partial class VisaoGeral : Form
    {
        public VisaoGeral()
        {
            InitializeComponent();
            this._cancelarProcessamento = new CancellationTokenSource();
        }

        #region Atributos
        /// <summary>
        /// Token de Cancelamento responsável pelo cancelamento da tarefa caso o usuário clique no botão Cancelar
        /// </summary>
        private CancellationTokenSource _cancelarProcessamento;
        #endregion

        #region Métodos
        /// <summary>
        /// Monta o Ambiente Inicial de forma assíncrona
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            //Acompanhar progresso da tarefa
            Progress<ProgressoDaTarefa> progressoDaTarefa = new Progress<ProgressoDaTarefa>();
            progressoDaTarefa.ProgressChanged += ProgressoDaTarefa_ProgressChanged;
            var assitirProgresso = System.Diagnostics.Stopwatch.StartNew();
            pgbProgresso.Visible = true;

            try
            {
                //Iniciar processamento da Tarefa
                await BuscarEstatísticasDaLojaAsync(progressoDaTarefa, _cancelarProcessamento.Token);
            }
            catch (OperationCanceledException)
            {
                this.UseWaitCursor = false;
                _cancelarProcessamento = new CancellationTokenSource();
                pgbProgresso.Value = 0;
            }
            catch (Exception erro)
            {
                this.UseWaitCursor = false;
                MessageBox.Show("Aconteceu um erro ao carregar as estatísticas da loja. Por favor contacte o administrador do sistema. Mensagem original: " + erro.Message, "Erro ao carregar estatísticas da loja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pgbProgresso.Value = 0;
            }

            assitirProgresso.Stop();
        }

        /// <summary>
        /// Método que busca estatísticas da Loja e preenche na tela.
        /// </summary>
        /// <param name="pProgresso">Objeto para acompanhar progresso da tarefa.</param>
        /// <param name="pCancelarTarefa">Token de cancelamento para cancelar tarefa.</param>
        /// <returns></returns>
        private async Task BuscarEstatísticasDaLojaAsync(IProgress<ProgressoDaTarefa> pProgresso, CancellationToken pCancelarTarefa)
        {
            // Objeto para acompanhar progresso da tarefa
            ProgressoDaTarefa reportarProgresso = new ProgressoDaTarefa();
            reportarProgresso.Progresso = 10;
            reportarProgresso.EtapaAtual = "Buscando estatísticas da loja...";
            pProgresso.Report(reportarProgresso);

            // Realizar consulta dos dados
            List<DmoVenda> vendas = await new BoVenda().ConsultarAsync(pCancelarTarefa, pSituacoesVendas : new List<SituacaoVenda> { SituacaoVenda.EmAberto });
            reportarProgresso.Progresso = 40;
            pProgresso.Report(reportarProgresso);

            #region Vendas da Semana
            int diaDaSemana = (int)DateTime.Today.DayOfWeek;
            int vendasDaSemana = vendas.FindAll(v => v.DataVenda > DateTime.Today.AddDays(-Convert.ToDouble(diaDaSemana))).Count();

            btnVendasDaSemana.Text = vendasDaSemana.ToString().PadLeft(3, '0');
            reportarProgresso.Progresso = 60;
            pProgresso.Report(reportarProgresso);
            #endregion

            #region Vendas Em Aberto
            int vendasEmAberto = vendas.FindAll(v => v.Situacao == SituacaoVenda.EmAberto).Count();

            btnVendasEmAberto.Text = vendasEmAberto.ToString().PadLeft(3, '0');
            reportarProgresso.Progresso = 70;
            pProgresso.Report(reportarProgresso);
            #endregion

            #region Clientes Inadimplentes
            #region Inadimplência de Compras Parceladas (por data de vencimento das parcelas)
            List<int?> idClientesInadimplentes = new List<int?>();
            foreach (DmoVenda venda in vendas)
            {
                if (venda.ParcelasDaVenda != null && venda.ParcelasDaVenda.Any(p => p.SituacaoParcela == SituacaoParcela.EmAberto))
                {
                    if (venda.ParcelasDaVenda.First().Vencimento < DateTime.Today)
                    {
                        if (!idClientesInadimplentes.Any(c => c == venda.Cliente.IdCliente))
                            idClientesInadimplentes.Add(venda.Cliente.IdCliente);
                    }
                }
            }

            reportarProgresso.Progresso = 80;
            pProgresso.Report(reportarProgresso);
            #endregion

            #region Inadimplência por dias sem movimentar compras com pagamento Fiado

            #endregion

            btnClientesInadimplentes.Text = idClientesInadimplentes.Count().ToString().PadLeft(3, '0');

            if (idClientesInadimplentes.Any())
            {
                pnlClientesInadimplentes.BackgroundImage = Resources.retangulo_vermelho_claro;
                btnRotuloClientesInadimplentes.ForeColor = Color.FromArgb(192, 0, 0);
                btnClientesInadimplentes.ForeColor = Color.FromArgb(192, 0, 0);
                picClientesInadimplentes.IconChar = FontAwesome.Sharp.IconChar.Frown;
                picClientesInadimplentes.IconColor = Color.FromArgb(192, 0, 0);
            }
            else
            {
                pnlClientesInadimplentes.BackgroundImage = Resources.retangulo_verde_claro;
                btnRotuloClientesInadimplentes.ForeColor = Color.DarkGreen;
                btnClientesInadimplentes.ForeColor = Color.DarkGreen;
                picClientesInadimplentes.IconChar = FontAwesome.Sharp.IconChar.Smile;
                picClientesInadimplentes.IconColor = Color.DarkGreen;
            }
            #endregion

            reportarProgresso.Progresso = 100;
            pProgresso.Report(reportarProgresso);
        }

        /// <summary>
        /// Abre um Formulário na Tela Principal
        /// </summary>
        /// <param name="pFormulario">Formulário a ser aberto</param>
        private void AbrirFormulario(Form pFormulario)
        {
            pFormulario.TopLevel = false;
            pFormulario.FormBorderStyle = FormBorderStyle.None;
            pFormulario.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(pFormulario);
            this.Parent.Tag = pFormulario;
            pFormulario.BringToFront();
            pFormulario.Show();
            this.Close();
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Evento trigado quando o progresso de uma tarefa em execução é alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressoDaTarefa_ProgressChanged(object sender, ProgressoDaTarefa e)
        {
            pgbProgresso.Value = e.Progresso;

            if (e.Progresso < 100)
            {
                this.UseWaitCursor = true;
            }
            else
            {
                this.UseWaitCursor = false;
                pgbProgresso.Visible = false;
            }
        }

        private async void VisaoGeral_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync();
        }

        private void btnAtalhoCadVenda_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new CadVenda());
        }

        private void btnAtalhoConCliente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ConCliente());
        }

        private void btnAtalhoConProd_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new ConProduto());
        }

        private void VisaoGeral_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar processamento caso o formulário esteja sendo fechado
            _cancelarProcessamento.Cancel();
        }
        #endregion

    }
}
