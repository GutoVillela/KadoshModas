using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.UI.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KadoshModas.INF;

namespace KadoshModas.UI
{
    public partial class ConProduto : Form
    {
        #region Construtor
        public ConProduto()
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
        /// Define o filtro de Nome a ser aplicado na busca de Produtos
        /// </summary>
        private string _filtroNome;

        /// <summary>
        /// Define o filtro de Preço Máximo a ser aplicado na busca de Produtos
        /// </summary>
        private float? _filtroPrecoMax;

        /// <summary>
        /// Define o filtro de Código de Barras a ser aplicado na busca de Produtos
        /// </summary>
        private string _filtroCodBarras;

        /// <summary>
        /// Define o filtro de Categorias a ser aplicado na busca de Produtos
        /// </summary>
        private List<DmoCategoria> _filtroCategorias;

        /// <summary>
        /// Define o filtro de Busca Produtos Sem Categoria a ser aplicado na busca de Produtos
        /// </summary>
        private bool _filtroBuscaProdutosSemCategoria;

        /// <summary>
        /// Define o filtro de Marcas a ser aplicado na busca de Produtos
        /// </summary>
        private List<DmoMarca> _filtroMarcas;

        /// <summary>
        /// Define o filtro de Busca Produtos Sem Marca a ser aplicado na busca de Produtos
        /// </summary>
        private bool _filtroBuscaProdutosSemMarca;

        /// <summary>
        /// Define o filtro de Busca Inativos a ser aplicado na busca de Produtos
        /// </summary>
        private bool _filtroBuscaInativos;
        #endregion
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega os Produtos no Panel de Produtos
        /// </summary>
        /// <param name="pProdutos">Lista de Produtos</param>
        private void CarregarProdutosNoPanel(List<DmoProduto> pProdutos)
        {
            if(!pnlProdutos.Controls.Find("pnlNenhumProduto", true).Any())
                pnlProdutos.Controls.Clear();

            if (pProdutos.Any())
            {
                pnlProdutos.Controls.Clear();

                foreach (DmoProduto produto in pProdutos)
                {
                    ucProdutoListItem ucProduto = new ucProdutoListItem()
                    {
                        Produto = produto,
                        Dock = DockStyle.Top
                    };

                    pnlProdutos.Controls.Add(ucProduto);
                }
            }

            lblRegistros.Text = $"Exibindo {pProdutos.Count} de {this._qtdRegistrosBusca}";
        }

        /// <summary>
        /// Prepara o Ambiente Inicial do Formulário
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            #region Resetar Atributos de Filtro
            _buscarAPartirDoRegistro = 0;
            _filtroNome = null;
            _filtroPrecoMax = null;
            _filtroCodBarras = null;
            _filtroCategorias = null;
            _filtroBuscaProdutosSemCategoria = true;
            _filtroMarcas = null;
            _filtroBuscaProdutosSemMarca = true;
            _filtroBuscaInativos = false;
            #endregion

            #region Carregas Produtos
            _qtdRegistrosBusca = await new BoProduto().ContarProdutosAsync(null, null, null, null, null, false);
                List<DmoProduto> produtos = await new BoProduto().ConsultarAsync(_filtroNome, _filtroPrecoMax, _filtroCodBarras, _filtroCategorias, _filtroBuscaProdutosSemCategoria, _filtroMarcas, _filtroBuscaProdutosSemMarca, _filtroBuscaInativos, _buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto);
                CarregarProdutosNoPanel(produtos);

            if (produtos.Any())
            {
                double maiorPreco = await new BoProduto().ObterMaiorPrecoDeProdutoAsync();
                trbFiltroPreco.Maximum = int.Parse(Math.Ceiling(maiorPreco).ToString());
                trbFiltroPreco.Value = trbFiltroPreco.Maximum;
            }

            btnInicioPaginacao.Enabled = btnAnteriorPaginacao.Enabled = false;
            btnProximoPaginacao.Enabled = btnUltimoPaginacao.Enabled = true;
            pnlPaginacaoBusca.Enabled = pnlPaginacaoBusca.Visible = true;
            #endregion

            #region Carregar Categorias
            List<DmoCategoria> categorias = await new BoCategoria().ConsultarAsync();

            cklCategorias.Items.Clear();

            //Adicionar item para Produtos sem Categoria
            cklCategorias.Items.Add("Sem categoria", true);

            if (categorias.Any())
            {
                foreach (DmoCategoria categoria in categorias)
                {
                    cklCategorias.Items.Add(categoria.Nome, true);
                }
            }
            #endregion

            #region Carregar Marcas
            List<DmoMarca> marcas = await new BoMarca().ConsultarAsync();

            cklMarcas.Items.Clear();

            //Adicionar item para Produtos sem Marca
            cklCategorias.Items.Add("Sem marca", true);

            if (marcas.Any())
            {
                foreach (DmoMarca marca in marcas)
                {
                    cklMarcas.Items.Add(marca.Nome, true);
                }
            }

            
            #endregion

        }

        /// <summary>
        /// Aplica os Filtros definidos em tela e busca os Produtos com base nos filtros definidos
        /// </summary>
        private async Task AplicarFiltrosAsync()
        {
            _qtdRegistrosBusca = await new BoProduto().ContarProdutosAsync(_filtroNome, _filtroPrecoMax, null, _filtroCategorias, _filtroMarcas, _filtroBuscaInativos);

            List<DmoProduto> produtos = await new BoProduto().ConsultarAsync(_filtroNome, _filtroPrecoMax, _filtroCodBarras, _filtroCategorias, _filtroBuscaProdutosSemCategoria, _filtroMarcas, _filtroBuscaProdutosSemMarca, _filtroBuscaInativos, _buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto);
            CarregarProdutosNoPanel(produtos);

            #region Definir visibilidade da paginação
            pnlPaginacaoBusca.Visible = INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente <= _qtdRegistrosBusca;

            btnAnteriorPaginacao.Enabled = btnInicioPaginacao.Enabled = _buscarAPartirDoRegistro != 0;

            btnProximoPaginacao.Enabled = btnUltimoPaginacao.Enabled = (_buscarAPartirDoRegistro + ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente) < _qtdRegistrosBusca;
            #endregion
        }
        #endregion

        #region Eventos
        private async void ConProduto_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync();
        }

        private async void btnAplicarFiltros_Click(object sender, EventArgs e)
        {
            _buscarAPartirDoRegistro = 0;
            await AplicarFiltrosAsync();
        }

        private void trbFiltroPreco_ValueChanged(object sender, EventArgs e)
        {
            lblFiltroPrecoMax.Text = trbFiltroPreco.Value.ToString("C");
            this._filtroPrecoMax = float.Parse(trbFiltroPreco.Value.ToString());
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            _filtroNome = txtNomeProduto.Text.Trim();
            _filtroPrecoMax = null;
        }

        private void cklCategorias_SelectedValueChanged(object sender, EventArgs e)
        {
            _filtroCategorias = new List<DmoCategoria>();

            if(cklCategorias.CheckedItems.Count > 0)
            {
                for (int i = 0; i < cklCategorias.Items.Count; i++)
                {
                    if (cklCategorias.GetItemChecked(i))
                    {
                        _filtroCategorias.Add(new DmoCategoria() { Nome = cklCategorias.Items[i].ToString() });
                    }
                }
            }

            _filtroBuscaProdutosSemCategoria = cklCategorias.CheckedItems.Contains("Sem categoria");
        }

        private void chkSomenteAtivos_CheckedChanged(object sender, EventArgs e)
        {
            _filtroBuscaInativos = !chkSomenteAtivos.Checked;
        }
        private async void btnInicioPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = 0;
            await AplicarFiltrosAsync();
        }

        private async void btnAnteriorPaginacao_Click(object sender, EventArgs e)
        {
            if (this._buscarAPartirDoRegistro >= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto)
                this._buscarAPartirDoRegistro -= INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto;

            await AplicarFiltrosAsync();
        }

        private async void btnProximoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro += INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto;
            await AplicarFiltrosAsync();
        }

        private async void btnUltimoPaginacao_Click(object sender, EventArgs e)
        {
            this._buscarAPartirDoRegistro = Convert.ToUInt32(Math.Floor(Convert.ToDecimal(this._qtdRegistrosBusca / INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto)) * INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto);
            await AplicarFiltrosAsync();
        }
        private async void btnBuscarTodos_Click_1(object sender, EventArgs e)
        {
            await MontarAmbienteInicialAsync();
        }

        #endregion
    }
}
