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
    public partial class ConFornecedor : Form
    {
        public ConFornecedor()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Carrega os Fornecedores na Grid
        /// </summary>
        /// <param name="pFornecedores">Lista de Fornecedores</param>
        private void CarregarFornecedoresNaGrid(List<DmoFornecedor> pFornecedores)
        {
            dgvFornecedores.Rows.Clear();

            foreach (DmoFornecedor fornecedor in pFornecedores)
            {
                dgvFornecedores.Rows.Add(
                    fornecedor.Nome,
                    fornecedor.Endereco != null ? fornecedor.Endereco.Rua + ", " + fornecedor.Endereco.Numero : "",
                    fornecedor.Ativo
                    );

                dgvFornecedores.Rows[dgvFornecedores.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = fornecedor;
            }
        }
        #endregion

        #region Eventos
        private void ConFornecedor_Load(object sender, EventArgs e)
        {
            CarregarFornecedoresNaGrid(new BoFornecedor().Consultar());
        }

        private void txtFiltroFornecedor_TextChanged(object sender, EventArgs e)
        {
            CarregarFornecedoresNaGrid(new BoFornecedor().Consultar(txtFiltroFornecedor.Text.Trim()));
        }
        #endregion
    }
}
