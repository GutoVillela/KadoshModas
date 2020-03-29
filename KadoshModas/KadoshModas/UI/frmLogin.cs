using KadoshModas.BLL;
using KadoshModas.DML;
using KadoshModas.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DmoLogin login = new DmoLogin()
            {
                Usuario = txtUsuario.Text.Trim(),
                Senha = txtSenha.Text
            };

            if(new BoLogin().ValidarLogin(login))
            {
                TelaPrincipal telaPrincipal = new TelaPrincipal();
                this.Hide();
                telaPrincipal.Show();
            }
            else
                MessageBox.Show("Login inválido");

            this.Cursor = Cursors.Default;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
