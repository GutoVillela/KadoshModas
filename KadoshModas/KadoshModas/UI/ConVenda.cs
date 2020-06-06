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

        private List<DmoVenda.SituacoesVenda> _filtroSituacoes;
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

        private void MontarAmbienteInicial()
        {
            #region Carregas Situacoes da Venda
            cklSituacoesVenda.Items.Clear();
            foreach (DmoVenda.SituacoesVenda situacao in Enum.GetValues(typeof(DmoVenda.SituacoesVenda)))
            {
                cklSituacoesVenda.Items.Add(DmoBase.DescricaoEnum<DmoVenda.SituacoesVenda>(situacao));
                cklSituacoesVenda.SetItemChecked(cklSituacoesVenda.Items.Count - 1, true);
            }
            #endregion

            CarregarComprasNoPanel(new BoVenda().Consultar());
        }

        /// <summary>
        /// Aplica os filtros definidos pelo usuário e carrega os resultado no Panel
        /// </summary>
        private void AplicarFiltros()
        {
            CarregarComprasNoPanel(new BoVenda().Consultar(null, _filtroSituacoes, _filtroDataInicial, _filtroDataFinal));
        }
        #endregion

        #region Eventos
        private void ConVenda_Load(object sender, EventArgs e)
        {
            this.Size = ParametrosDoSistema.TAMANHO_FORMULARIOS;
            MontarAmbienteInicial();
        }

        private void cdrFiltroData_DateSelected(object sender, DateRangeEventArgs e)
        {
            _filtroDataInicial = cdrFiltroData.SelectionRange.Start;
            _filtroDataFinal = cdrFiltroData.SelectionRange.End;
            AplicarFiltros();
        }

        private void cklSituacoesVenda_SelectedValueChanged(object sender, EventArgs e)
        {
            _filtroSituacoes = new List<DmoVenda.SituacoesVenda>();

            if (cklSituacoesVenda.CheckedItems.Count > 0)
            {
                for (int i = 0; i < cklSituacoesVenda.Items.Count; i++)
                {
                    if (cklSituacoesVenda.GetItemChecked(i))
                    {
                        foreach (DmoVenda.SituacoesVenda situacao in Enum.GetValues(typeof(DmoVenda.SituacoesVenda)))
                        {
                            if(DmoBase.DescricaoEnum<DmoVenda.SituacoesVenda>(situacao) == cklSituacoesVenda.Items[i].ToString())
                            {
                                _filtroSituacoes.Add(situacao);
                                break;
                            }
                        }
                    }
                }
            }

            AplicarFiltros();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            CarregarComprasNoPanel(new BoVenda().Consultar());
        }
        #endregion
    }
}
