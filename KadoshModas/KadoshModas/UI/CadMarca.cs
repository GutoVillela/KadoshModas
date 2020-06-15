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
    public partial class CadMarca : Form
    {
        #region Construtor
        public CadMarca()
        {
            InitializeComponent();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega as Marcas na Grid
        /// </summary>
        /// <param name="pMarcas">Lista de Marcas</param>
        private void CarregarMarcasNaGrid(List<DmoMarca> pMarcas)
        {
            dgvMarcas.Rows.Clear();

            foreach (DmoMarca marca in pMarcas)
            {
                dgvMarcas.Rows.Add(
                    marca.Nome,
                    marca.Ativo
                    );

                dgvMarcas.Rows[dgvMarcas.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = marca;
            }
        }
        #endregion

        #region Eventos
        private async void CadMarca_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            CarregarMarcasNaGrid(await new BoMarca().ConsultarAsync());
        }

        private async void btnCadMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                MessageBox.Show("Preencha o nome da Marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    await new BoMarca().CadastrarAsync(new DML.DmoMarca() { Nome = txtMarca.Text.Trim() });
                    MessageBox.Show("Marca Cadastrada com Sucesso", "Marca cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarMarcasNaGrid(await new BoMarca().ConsultarAsync());
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao Cadastrar Marca.\nMensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private async void txtFiltroMarca_TextChanged(object sender, EventArgs e)
        {
            CarregarMarcasNaGrid(await new BoMarca().ConsultarAsync(txtFiltroMarca.Text.Trim()));
        }

        private async void dgvMarcas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DmoMarca marcaAntesDaEdicao = (DmoMarca) dgvMarcas.Rows[e.RowIndex].Tag;
            DmoMarca marcaEditada = (DmoMarca) marcaAntesDaEdicao.Clone();

            marcaEditada.Nome = dgvMarcas.Rows[e.RowIndex].Cells[0].Value.ToString();
            marcaEditada.Ativo = Convert.ToBoolean((dgvMarcas.Rows[e.RowIndex].Cells[1] as DataGridViewCheckBoxCell).Value);

            if (marcaAntesDaEdicao.Nome == marcaEditada.Nome && marcaAntesDaEdicao.Ativo == marcaEditada.Ativo)
                return;

            if (MessageBox.Show($"Confirma edição da marca { marcaAntesDaEdicao.Nome }?", "Confirmar edição", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await new BoMarca().AtualizarAsync(marcaEditada, marcaAntesDaEdicao.Nome);
                    MessageBox.Show("Categoria atualizada com sucesso!", "Categoria atualizada com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvMarcas.Rows[e.RowIndex].Tag = marcaEditada;
                }
                catch (Exception erro)
                {
                    MessageBox.Show($"Um erro inesperado acoteceu ao tentar editar a marca { marcaAntesDaEdicao.Nome }. Mensagem original: " + erro.Message, "Um erro inesperado aconteceu!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
