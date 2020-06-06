using KadoshModas.BLL;
using KadoshModas.DAL;
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

        #region Eventos
        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DmoLogin login = new DmoLogin()
            {
                Usuario = txtUsuario.Text.Trim(),
                Senha = txtSenha.Text
            };

            try
            {
                if (new BoLogin().ValidarLogin(login))
                {
                    TelaPrincipal telaPrincipal = new TelaPrincipal();
                    this.Hide();
                    telaPrincipal.Show();
                }
                else
                    MessageBox.Show("Login inválido");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao tentar acessar o sistema! Por favor entre em contato com o Administrador! Mensagem original: " + erro.Message, "Erro ao acessar o sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                btnEntrar_Click(sender, e);
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEntrar_Click(sender, e);
        }
        #endregion
    }
}
