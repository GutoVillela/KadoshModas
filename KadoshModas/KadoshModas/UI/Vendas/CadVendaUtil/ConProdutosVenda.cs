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
using KadoshModas.INF;

namespace KadoshModas.UI
{
    public partial class ConProdutosVenda : Form
    {
        public ConProdutosVenda()
        {
            InitializeComponent();
        }

        #region Propriedades
        /// <summary>
        /// Define o Produto escolhido pelo Usuário nesta tela
        /// </summary>
        public static DmoItemDaVenda ProdutoEscolhido { get; set; }
        #endregion

        #region Paginação
        /// <summary>
        /// Indica quantos registros correspondem ao critério de busca
        /// </summary>
        private int _qtdRegistrosBusca;

        /// <summary>
        /// Indica a partir de qual registro a busca de Produtos será feita
        /// </summary>
        private uint _buscarAPartirDoRegistro = 0;
        #endregion

        #region Filtros
        /// <summary>
        /// Define o filtro de Código a ser aplicado na busca de Produtos
        /// </summary>
        private string _filtroCodigo;

        /// <summary>
        /// Define o filtro de Nome a ser aplicado na busca de Produtos
        /// </summary>
        private string _filtroNome;
        
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega a DataGridView com os dados fornecidos
        /// </summary>
        /// <param name="pDataSource">Lista de Produtos</param>
        private void CarregarGrid(List<DML.DmoProduto> pDataSource)
        {
            //Limpar DataGrid
            dgvProdutos.Rows.Clear();

            foreach (DmoProduto produto in pDataSource)
            {
                dgvProdutos.Rows.Add(
                    produto.IdProduto.ToString(),
                    produto.Nome,
                    produto.Preco.ToString("C")
                    );

                dgvProdutos.Rows[dgvProdutos.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = produto;
            }

            lblRegistros.Text = $"Exibindo {pDataSource.Count} de {this._qtdRegistrosBusca}";
        }

        /// <summary>
        /// Define o Item da Venda escolhido e fecha o formulário
        /// </summary>
        /// <param name="pIndexDaLinha">Index da linha escolhida na DataGridView</param>
        private void EscolherItemDaVenda(int pIndexDaLinha)
        {
            ProdutoEscolhido = new DmoItemDaVenda() { Produto = (DmoProduto)dgvProdutos.Rows[pIndexDaLinha].Tag };
            this.Close();
        }

        /// <summary>
        /// Aplica os Filtros definidos em tela e busca os Produtos com base nos filtros definidos
        /// </summary>
        private async Task AplicarFiltrosAsync()
        {
            #region Travando Interface durante processamento
            Cursor.Current = Cursors.WaitCursor;
            TravarOuDestravarInterface(true);
            #endregion

            _qtdRegistrosBusca = await new BoProduto().ContarProdutosAsync(_filtroNome);
            CarregarGrid(await new BoProduto().ConsultarAsync(_filtroNome, null, null, null, true, null, true, false, _buscarAPartirDoRegistro, INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeProduto));

            #region Definir visibilidade da paginação
            pnlPaginacaoBusca.Visible = INF.ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente <= _qtdRegistrosBusca;

            btnAnteriorPaginacao.Enabled = btnInicioPaginacao.Enabled = _buscarAPartirDoRegistro != 0;

            btnProximoPaginacao.Enabled = btnUltimoPaginacao.Enabled = (_buscarAPartirDoRegistro + ParametrosDoSistema.QuantidadeDeItensPorBuscaDeCliente) < _qtdRegistrosBusca;
            #endregion

            #region Destravando Interface após processamento
            Cursor.Current = Cursors.Default;
            TravarOuDestravarInterface(false);
            #endregion
        }

        /// <summary>
        /// Desabilida ou habilita os controles da interface
        /// </summary>
        /// <param name="pTrava">Define se interface deverá ser travada ou destravada</param>
        private void TravarOuDestravarInterface(bool pTrava)
        {
            txtConsulta.Enabled = btnBuscar.Enabled = dgvProdutos.Enabled = pnlPaginacaoBusca.Enabled = !pTrava;
        }
        #endregion

        #region Eventos
        private async void ConProdutosVenda_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await AplicarFiltrosAsync();
        }

        private void dgvProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherItemDaVenda(e.RowIndex);
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherItemDaVenda(e.RowIndex);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            _buscarAPartirDoRegistro = 0;
            await AplicarFiltrosAsync();
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

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            _filtroNome = txtConsulta.Text.Trim();
        }
        #endregion
    }
}
