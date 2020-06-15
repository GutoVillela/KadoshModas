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
    public partial class DefinirFornecedores : Form
    {
        #region Construtor
        public DefinirFornecedores()
        {
            InitializeComponent();
        }
        #endregion

        #region Atributos
        public static List<DmoFornecedor> listaDeFornecedoresDefinidos = new List<DmoFornecedor>();
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega DataGridView com dados fornecidos
        /// </summary>
        /// <param name="pDataSource">Lista de Clientes a serem carregados na tela</param>
        private void CarregarGrid(List<DML.DmoFornecedor> pDataSource)
        {
            //Limpar DataGridView
            dgvFornecedores.Rows.Clear();

            foreach (DML.DmoFornecedor fornecedor in pDataSource)
            {
                dgvFornecedores.Rows.Add(
                    listaDeFornecedoresDefinidos.Any(item => item.IdFornecedor == fornecedor.IdFornecedor) ? true : false,
                    fornecedor.Nome,
                    fornecedor.Endereco == null ? "" : fornecedor.Endereco.Rua + " " + fornecedor.Endereco.Numero,
                    string.IsNullOrEmpty(fornecedor.CNPJ) ? "Não Definido" : fornecedor.CNPJ
                    );

                dgvFornecedores.Rows[dgvFornecedores.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = fornecedor;
            }
        }
        #endregion

        #region Eventos
        private async void DefinirFornecedores_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            CarregarGrid(await new BLL.BoFornecedor().ConsultarAsync());
        }

        private void dgvFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFornecedores.Columns[e.ColumnIndex].Name == "SelecionarFornecedor")
            {
                DataGridViewCheckBoxCell chkFornecedor = dgvFornecedores.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;

                if ((bool)chkFornecedor.EditedFormattedValue)
                {
                    DmoFornecedor fornecedor = (DML.DmoFornecedor)dgvFornecedores.Rows[e.RowIndex].Tag;
                    listaDeFornecedoresDefinidos.Add(fornecedor);
                }
                else
                {
                    DmoFornecedor fornecedor = (DML.DmoFornecedor)dgvFornecedores.Rows[e.RowIndex].Tag;
                    listaDeFornecedoresDefinidos.Remove(listaDeFornecedoresDefinidos.Find(item => item.IdFornecedor == fornecedor.IdFornecedor));
                }
            }
        }
        #endregion
    }
}
