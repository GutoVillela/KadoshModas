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
    public partial class CadCategoria : Form
    {
        #region Construtor
        public CadCategoria()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega as Categorias na Grid
        /// </summary>
        /// <param name="pCategorias">Lista de Categorias</param>
        private void CarregarCategoriasNaGrid(List<DmoCategoria> pCategorias)
        {
            dgvCategorias.Rows.Clear();

            foreach (DmoCategoria categoria in pCategorias)
            {
                dgvCategorias.Rows.Add(
                    categoria.Nome,
                    categoria.Ativo
                    );

                dgvCategorias.Rows[dgvCategorias.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = categoria;
            }
        }
        #endregion

        #region Eventos
        private void btnCadCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoria.Text.Trim()))
            {
                MessageBox.Show("Preencha o nome da categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    new BoCategoria().Cadastrar(new DML.DmoCategoria() { Nome = txtCategoria.Text.Trim() });
                    MessageBox.Show("Categoria Cadastrada com Sucesso", "Categoria cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarCategoriasNaGrid(new BoCategoria().Consultar());
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao Cadastrar Categoria.\nMensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void CadCategoria_Load(object sender, EventArgs e)
        {
            CarregarCategoriasNaGrid(new BoCategoria().Consultar());
        }

        private void txtFiltroCategoria_TextChanged(object sender, EventArgs e)
        {
            CarregarCategoriasNaGrid(new BoCategoria().Consultar(txtFiltroCategoria.Text.Trim()));
        }

        private void dgvCategorias_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DmoCategoria categoriaAntesDaEdicao = (DmoCategoria)dgvCategorias.Rows[e.RowIndex].Tag;
            DmoCategoria categoriaEditada = (DmoCategoria) categoriaAntesDaEdicao.Clone();

            categoriaEditada.Nome = dgvCategorias.Rows[e.RowIndex].Cells[0].Value.ToString();
            categoriaEditada.Ativo = Convert.ToBoolean((dgvCategorias.Rows[e.RowIndex].Cells[1] as DataGridViewCheckBoxCell).Value);

            if (categoriaAntesDaEdicao.Nome == categoriaEditada.Nome && categoriaAntesDaEdicao.Ativo == categoriaEditada.Ativo)
                return;

            if (MessageBox.Show($"Confirma edição da categoria { categoriaAntesDaEdicao.Nome }?", "Confirmar edição", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    new BoCategoria().Atualizar(categoriaEditada, categoriaAntesDaEdicao.Nome);
                    MessageBox.Show("Categoria atualizada com sucesso!", "Categoria atualizada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvCategorias.Rows[e.RowIndex].Tag = categoriaEditada;
                }
                catch(Exception erro)
                {
                    MessageBox.Show($"Um erro inesperado acoteceu ao tentar editar a categoria { categoriaAntesDaEdicao.Nome }. Mensagem original: " + erro.Message, "Um erro inesperado aconteceu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
