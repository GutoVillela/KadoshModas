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
    public partial class ConClienteVenda : Form
    {
        public ConClienteVenda()
        {
            InitializeComponent();
        }

        #region Propriedades
        /// <summary>
        /// Cliente selecionado pelo Usuário
        /// </summary>
        public static DmoCliente ClienteEscolhido { get; set; } = new DmoCliente() { IdCliente = DmoCliente.IdClienteIndefinido };
        #endregion

        #region Métodos
        /// <summary>
        /// Carrega a DataGridView com os dados fornecidos
        /// </summary>
        /// <param name="pDataSource">Lista de Cliente</param>
        private void CarregarGrid(List<DML.DmoCliente> pDataSource)
        {
            //Limpar DataGrid
            dgvConCliente.Rows.Clear();

            foreach (DmoCliente cliente in pDataSource)
            {
                dgvConCliente.Rows.Add(
                    cliente.IdCliente.ToString(),
                    cliente.Nome,
                    cliente.CPF,
                    cliente.Sexo.ToString()
                    );

                dgvConCliente.Rows[dgvConCliente.Rows.GetLastRow(DataGridViewElementStates.None)].Tag = cliente;
            }
        }

        /// <summary>
        /// Define o Cliente escolhido na DataGridView
        /// </summary>
        /// <param name="indexLinha">Index da Linha escolhida</param>
        private void EscolherCliente(int indexLinha)
        {
            ClienteEscolhido = (DML.DmoCliente)dgvConCliente.Rows[indexLinha].Tag;
            this.Close();
        }
        #endregion

        #region Eventos
        private async void ConCliente_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            CarregarGrid(await new BoCliente().ConsultarAsync(null, null, null, null, null, false, false, null, null, false, false));
        }

        private void dgvConCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherCliente(e.RowIndex);
        }

        private void dgvConCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EscolherCliente(e.RowIndex);
        }
        #endregion

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtConsulta.Text.Trim()))
            {
                CarregarGrid(await new BLL.BoCliente().ConsultarAsync(null, null, null, null, null, false, false, null, null, false, false));
            }
            else
            {
                if (rbtNome.Checked)
                {
                    CarregarGrid(await new BLL.BoCliente().ConsultarAsync(null, txtConsulta.Text.Trim(), null, null, null, false, false, null, null, false, false));
                }
            }
        }
    }
}
