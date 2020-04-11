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
    public partial class ConCliente : Form
    {
        public ConCliente()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Carrega DataGridView com dados fornecidos
        /// </summary>
        /// <param name="pDataSource">Lista de Clientes a serem carregados na tela</param>
        private void CarregarGrid(List<DML.DmoCliente> pDataSource)
        {
            //Limpar DataGridView
            dgvClientes.Rows.Clear();

            foreach (DML.DmoCliente cliente in pDataSource)
            {
                dgvClientes.Rows.Add(
                    cliente.IdCliente.ToString(),
                    string.IsNullOrEmpty(cliente.UrlFoto) ? Properties.Resources.usuario_perfil_padrao : Image.FromFile(cliente.UrlFoto),
                    cliente.Nome,
                    cliente.Sexo.ToString(),
                    cliente.CPF
                    );

                dgvClientes.Rows[dgvClientes.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = cliente;
            }
        }
        #endregion

        private void ConCliente_Load(object sender, EventArgs e)
        {
            CarregarGrid(new BLL.BoCliente().Consultar());
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConsulta.Text.Trim()))
            {
                CarregarGrid(new BLL.BoCliente().Consultar());
            }
            else
            {
                if (rbtNome.Checked)
                {
                    CarregarGrid(new BLL.BoCliente().Consultar(txtConsulta.Text.Trim()));
                }
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvClientes.Columns[e.ColumnIndex].Name == "VerFicha")
            {
                int idCliente = int.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());
                new FichaCliente((DML.DmoCliente)dgvClientes.Rows[e.RowIndex].Tag).ShowDialog();
            }
            
        }
    }
}
