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
        #endregion

        #region Eventos
        private void ConProdutosVenda_Load(object sender, EventArgs e)
        {
            CarregarGrid(new BoProduto().Consultar());
        }

        private void dgvProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherItemDaVenda(e.RowIndex);
        }
        #endregion

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherItemDaVenda(e.RowIndex);
        }
    }
}
