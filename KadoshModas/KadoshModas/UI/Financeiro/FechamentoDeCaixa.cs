using KadoshModas.BLL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI
{
    public partial class FechamentoDeCaixa : Form
    {
        #region Construtor
        public FechamentoDeCaixa()
        {
            InitializeComponent();
            _cancelarProcessamento = new CancellationTokenSource();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Token de Cancelamento responsável pelo cancelamento da tarefa caso o usuário feche o formulário antes do término do processamento.
        /// </summary>
        private CancellationTokenSource _cancelarProcessamento;

        #region Filtros
        /// <summary>
        /// Define o filtro de Data Inicial a ser aplicado na busca dos Lançamentos
        /// </summary>
        private DateTime _filtroDataInicial;

        /// <summary>
        /// Define o filtro de Data Final a ser aplicado na busca dos Lançamentos
        /// </summary>
        private DateTime _filtroDataFinal;
        #endregion
        #endregion

        #region Métodos
        /// <summary>
        /// Método responsável por carregar a lista de lançamentos na ListView
        /// </summary>
        /// <param name="pListaDeLancamentos">Lista de Lançamentos do Cliente</param>
        private void CarregarLancamentosNaLista(List<DmoLancamentoDoCliente> pListaDeLancamentos)
        {
            lstLancamentos.Items.Clear();
            foreach (DmoLancamentoDoCliente item in pListaDeLancamentos)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { item.Cliente.Nome, item.TipoLancamentoDoCliente.DescricaoEnum(), item.ValorLancamento.ToString("C") });

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
        private void FechamentoDeCaixa_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
        }

        private void cdrDataFechamento_DateSelected(object sender, DateRangeEventArgs e)
        {
            _filtroDataInicial = _filtroDataFinal = cdrDataFechamento.SelectionRange.Start;

        }

        private async void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            if(_filtroDataInicial == DateTime.MinValue)
                _filtroDataInicial = _filtroDataFinal = DateTime.Today;

            BoLancamentoDoCliente boLancamentoDoCliente = new BoLancamentoDoCliente();
            List<DmoLancamentoDoCliente> lancamentosDoCliente = new List<DmoLancamentoDoCliente>();

            try
            {
                lancamentosDoCliente = await boLancamentoDoCliente.ConsultarLancamentosAgrupadosPorClienteETipoDeLancamento(_cancelarProcessamento.Token, pDataInicial: _filtroDataInicial, pDataFinal: _filtroDataFinal);
            }
            catch (OperationCanceledException)
            {

            }
            //catch (SqlException)
            //{

            //}
            //catch (Exception)
            //{

            //}

            CarregarLancamentosNaLista(lancamentosDoCliente);

            lblValorEntradaCaixa.Text = boLancamentoDoCliente.CalcularTotalEntrada(lancamentosDoCliente).ToString("C");
            lblValorSaidaCaixa.Text = boLancamentoDoCliente.CalcularTotalSaida(lancamentosDoCliente).ToString("C");
        }

        #endregion

        private void FechamentoDeCaixa_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancelar processamento caso o formulário esteja sendo fechado
            _cancelarProcessamento.Cancel();
        }
    }
}
