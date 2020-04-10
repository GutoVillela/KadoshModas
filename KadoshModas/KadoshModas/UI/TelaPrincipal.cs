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
    public partial class TelaPrincipal : Form
    {
        #region Construtor
        public TelaPrincipal()
        {
            InitializeComponent();
            MontarAmbienteInicial();
        }
        #endregion

        #region Atributos
        private Form formularioAtual;
        #endregion

        #region Métodos
        private void MontarAmbienteInicial()
        {
            EsconderSubmenus();
        }

        private void EsconderSubmenus()
        {
            pnlSubmenuClientes.Visible = false;
            pnlSubmenuVendas.Visible = false;
            pnlSubmenuProdutos.Visible = false;
            pnlSubmenuOpcoesAvancadas.Visible = false;
        }

        private void ExibirSubmenu(Panel submenu)
        {
            if (!submenu.Visible)
            {
                EsconderSubmenus();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void AbrirFormulario(Form formulario)
        {
            if (this.formularioAtual != null)
                formularioAtual.Close();

            formularioAtual = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnlForms.Controls.Add(formulario);
            pnlForms.Tag = formulario;
            formulario.BringToFront();
            formulario.Show();
        }
        #endregion

        #region Eventos
        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void TelaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ExibirSubmenu(pnlSubmenuClientes);
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            ExibirSubmenu(pnlSubmenuVendas);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            ExibirSubmenu(pnlSubmenuProdutos);
        }

        private void btnVisaoGeral_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
            AbrirFormulario(new CadMarca());
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
            AbrirFormulario(new CadProduto());
        }

        private void btnConCLiente_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
            AbrirFormulario(new ConCliente());
        }

        private void btnNovoCliente_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
            AbrirFormulario(new CadCliente());
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            EsconderSubmenus();
            AbrirFormulario(new CadCategoria());
        }
        #endregion
    }
}
