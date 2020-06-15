using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.INF;
using KadoshModas.UI.UserControls;
using System;
using System.CodeDom;
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
    public partial class ConVenda : Form
    {
        #region Construtor
        public ConVenda()
        {
            InitializeComponent();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Define o filtro de Data Inicial a ser aplicado na busca das Vendas
        /// </summary>
        private DateTime? _filtroDataInicial;

        /// <summary>
        /// Define o filtro de Data Final a ser aplicado na busca das Vendas
        /// </summary>
        private DateTime? _filtroDataFinal;

        private List<SituacaoVenda> _filtroSituacoes;
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega Vendas no Panel para exibição na Interface
        /// </summary>
        /// <param name="pVendas">Lista de Vendas a serem carregadas</param>
        private void CarregarComprasNoPanel(List<DmoVenda> pVendas)
        {
            if(!pnlVendas.Controls.Find("pnlNenhumaVenda", true).Any())
                pnlVendas.Controls.Clear();

            if (pVendas.Any())
            {
                pnlVendas.Controls.Clear();

                foreach (DmoVenda venda in pVendas)
                {
                    ucCompraListItem ucCompra = new ucCompraListItem
                    {
                        Venda = venda
                    };

                    pnlVendas.Controls.Add(ucCompra);
                }
            }
        }

        /// <summary>
        /// Monta o ambiente inicial
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            #region Carregas Situacoes da Venda
            cklSituacoesVenda.Items.Clear();
            foreach (SituacaoVenda situacao in Enum.GetValues(typeof(SituacaoVenda)))
            {
                cklSituacoesVenda.Items.Add(DmoBase.DescricaoEnum<SituacaoVenda>(situacao));
                cklSituacoesVenda.SetItemChecked(cklSituacoesVenda.Items.Count - 1, true);
            }
            #endregion

            CarregarComprasNoPanel(await new BoVenda().ConsultarAsync());
        }

        /// <summary>
        /// Aplica os filtros definidos pelo usuário e carrega os resultado no Panel
        /// </summary>
        private async Task AplicarFiltrosAsync()
        {
            CarregarComprasNoPanel(await new BoVenda().ConsultarAsync(null, _filtroSituacoes, _filtroDataInicial, _filtroDataFinal));
        }
        #endregion

        #region Eventos
        private async void ConVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            this.Size = ParametrosDoSistema.TAMANHO_FORMULARIOS;
            await MontarAmbienteInicialAsync();
        }

        private async void cdrFiltroData_DateSelected(object sender, DateRangeEventArgs e)
        {
            _filtroDataInicial = cdrFiltroData.SelectionRange.Start;
            _filtroDataFinal = cdrFiltroData.SelectionRange.End;
            await AplicarFiltrosAsync();
        }

        private async void cklSituacoesVenda_SelectedValueChanged(object sender, EventArgs e)
        {
            _filtroSituacoes = new List<SituacaoVenda>();

            if (cklSituacoesVenda.CheckedItems.Count > 0)
            {
                for (int i = 0; i < cklSituacoesVenda.Items.Count; i++)
                {
                    if (cklSituacoesVenda.GetItemChecked(i))
                    {
                        foreach (SituacaoVenda situacao in Enum.GetValues(typeof(SituacaoVenda)))
                        {
                            if(DmoBase.DescricaoEnum<SituacaoVenda>(situacao) == cklSituacoesVenda.Items[i].ToString())
                            {
                                _filtroSituacoes.Add(situacao);
                                break;
                            }
                        }
                    }
                }
            }

            await AplicarFiltrosAsync();
        }

        private async void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            CarregarComprasNoPanel(await new BoVenda().ConsultarAsync());
        }
        #endregion
    }
}
