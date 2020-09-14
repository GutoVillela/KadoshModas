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
using System.Threading;
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

        #region Paginação
        /// <summary>
        /// Indica quantos registros correspondem ao critério de busca
        /// </summary>
        private int _qtdRegistrosBusca;

        /// <summary>
        /// Indica a partir de qual registro a busca de clientes será feita
        /// </summary>
        private uint _buscarAPartirDoRegistro = 0;
        #endregion

        #region Filtros
        /// <summary>
        /// Define o filtro de Data Inicial a ser aplicado na busca das Vendas
        /// </summary>
        private DateTime? _filtroDataInicial;

        /// <summary>
        /// Define o filtro de Data Final a ser aplicado na busca das Vendas
        /// </summary>
        private DateTime? _filtroDataFinal;

        /// <summary>
        /// Define o filtro de Situação da Venda a ser aplicado na busca das Vendas
        /// </summary>
        private List<SituacaoVenda> _filtroSituacoes;
        #endregion
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

            lblRegistros.Text = $"Exibindo {pVendas.Count} de {this._qtdRegistrosBusca}";
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
                cklSituacoesVenda.Items.Add(situacao.DescricaoEnum());
                cklSituacoesVenda.SetItemChecked(cklSituacoesVenda.Items.Count - 1, true);
            }
            #endregion

            await BuscarTodos();
            //_qtdRegistrosBusca = await new BoVenda().ContarVendasAsync(null, null, null, null);
            //CarregarComprasNoPanel(await new BoVenda().ConsultarAsync(null, null, null, null, _buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda));
        }

        /// <summary>
        /// Aplica os filtros definidos pelo usuário e carrega os resultado no Panel
        /// </summary>
        private async Task AplicarFiltrosAsync()
        {
            _qtdRegistrosBusca = await new BoVenda().ContarVendasAsync(null, _filtroSituacoes, _filtroDataInicial, _filtroDataFinal);
            CarregarComprasNoPanel(await new BoVenda().ConsultarAsync(new CancellationToken(), pSituacoesVendas: _filtroSituacoes, pDataInicial: _filtroDataInicial, pDataFinal: _filtroDataFinal, pAPartirDoRegistro: _buscarAPartirDoRegistro, pAteORegistro: ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda));

            #region Definir visibilidade da paginação
            pnlPaginacaoBusca.Visible = INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente <= _qtdRegistrosBusca;

            btnAnteriorPaginacao.Enabled = btnInicioPaginacao.Enabled = _buscarAPartirDoRegistro != 0;

            btnProximoPaginacao.Enabled = btnUltimoPaginacao.Enabled = (_buscarAPartirDoRegistro + ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente) < _qtdRegistrosBusca;
            #endregion
        }

        /// <summary>
        /// Reseta os filtros e busca todas as Vendas
        /// </summary>
        /// <returns></returns>
        private async Task BuscarTodos()
        {
            #region Resetar Atributos de Filtro
            _buscarAPartirDoRegistro = 0;
            _filtroDataInicial = null;
            _filtroDataFinal = null;
            _filtroSituacoes = null;
            #endregion

            await AplicarFiltrosAsync();
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
                            if(situacao.DescricaoEnum() == cklSituacoesVenda.Items[i].ToString())
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
            await BuscarTodos();
        }

        private async void btnInicioPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = 0;
            await AplicarFiltrosAsync();
        }

        private async void btnAnteriorPaginacao_Click(object sender, EventArgs e)
        {
            if (this._buscarAPartirDoRegistro >= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda)
                this._buscarAPartirDoRegistro -= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda;

            await AplicarFiltrosAsync();
        }

        private async void btnProximoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro += INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda;
            await AplicarFiltrosAsync();
        }

        private async void btnUltimoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = Convert.ToUInt32(Math.Floor(Convert.ToDecimal(this._qtdRegistrosBusca / INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto)) * INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeVenda);
            await AplicarFiltrosAsync();
        }
        #endregion
    }
}
