using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KadoshModas.UI.UserControls;

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
            //Limpar Panel da Consulta
            pnlConCliente.Controls.Clear();

            foreach (DML.DmoCliente cliente in pDataSource)
            {
                ucClienteListItem clienteListItem = new UserControls.ucClienteListItem();
                clienteListItem.Cliente = cliente;
                pnlConCliente.Controls.Add(clienteListItem);
            }
        }
        #endregion

        #region Eventos
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
        #endregion

        private void rbtNome_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbtCPF_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
