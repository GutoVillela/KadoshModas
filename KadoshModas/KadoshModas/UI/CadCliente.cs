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
    public partial class CadCliente : Form
    {
        public CadCliente()
        {
            InitializeComponent();
        }

        private void chkMaisNumeros_CheckedChanged(object sender, EventArgs e)
        {
            btnAddNumero.Visible = btnAddNumero.Enabled = lstNumeros.Visible = lstNumeros.Enabled = chkMaisNumeros.Checked;
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeCliente.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo NOME para cadastrar o cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DmoCliente dmoCliente = new DmoCliente();
                dmoCliente.Nome = txtNomeCliente.Text.Trim();

                if(new BoCliente().Cadastrar(dmoCliente))
                    MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Aconteceu um erro ao cadastrar o novo cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
