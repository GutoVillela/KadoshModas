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
        /// Define o filtro de Marcas a ser aplicado na busca de Produtos
        /// </summary>
        private List<DmoMarca> _filtroMarcas;

        /// <summary>
        /// Define o filtro de Busca Inativos a ser aplicado na busca de Produtos
        /// </summary>
        private bool _filtroBuscaInativos;
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
        }

        /// <summary>
        /// Prepara o Ambiente Inicial do Formulário
        /// </summary>
        private void MontarAmbienteInicial()
        {
            #region Carregas Produtos
            List<DmoProduto> produtos = new BoProduto().Consultar();
            CarregarProdutosNoPanel(produtos);

            if (produtos.Any())
            {
                float maiorPreco = produtos.Max(p => p.Preco);
                trbFiltroPreco.Maximum = int.Parse(Math.Ceiling(maiorPreco).ToString());
                trbFiltroPreco.Value = trbFiltroPreco.Maximum;
            }
            #endregion

            #region Carregar Categorias
            List<DmoCategoria> categorias = new BoCategoria().Consultar();

            if (categorias.Any())
            {
                cklCategorias.Items.Clear();

                foreach (DmoCategoria categoria in categorias)
                {
                    cklCategorias.Items.Add(categoria.Nome, true);
                }
            }
            #endregion

            #region Carregar Marcas
            List<DmoMarca> marcas = new BoMarca().Consultar();

            if (marcas.Any())
            {
                cklMarcas.Items.Clear();

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
        private void AplicarFiltros()
        {
            CarregarProdutosNoPanel(new BoProduto().Consultar(_filtroNome, _filtroPrecoMax, _filtroCodBarras, _filtroCategorias, _filtroMarcas, _filtroBuscaInativos));
        }
        #endregion

        #region Eventos
        private void ConProduto_Load(object sender, EventArgs e)
        {
            MontarAmbienteInicial();
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            MontarAmbienteInicial();
        }

        private void trbFiltroPreco_ValueChanged(object sender, EventArgs e)
        {
            lblFiltroPrecoMax.Text = trbFiltroPreco.Value.ToString("C");
            this._filtroPrecoMax = float.Parse(trbFiltroPreco.Value.ToString());
            AplicarFiltros();
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            _filtroNome = txtNomeProduto.Text.Trim();
            AplicarFiltros();
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

            AplicarFiltros();
        }

        private void chkSomenteAtivos_CheckedChanged(object sender, EventArgs e)
        {
            _filtroBuscaInativos = !chkSomenteAtivos.Checked;
            AplicarFiltros();
        }
        #endregion
    }
}
