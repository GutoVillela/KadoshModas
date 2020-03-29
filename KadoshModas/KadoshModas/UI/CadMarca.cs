using KadoshModas.BLL;
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
        public CadMarca()
        {
            InitializeComponent();
        }

        private void btnCadCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMarca.Text.Trim()))
            {
                MessageBox.Show("Preencha o nome da Marca", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (new BoMarca().Cadastrar(new DML.DmoMarca() { Nome = txtMarca.Text.Trim() }))
                    {
                        MessageBox.Show("Marca Cadastrada com Sucesso", "Marca cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Cadastrar Marca", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao Cadastrar Marca.\nMensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
