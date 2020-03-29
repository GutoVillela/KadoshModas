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
    public partial class CadCategoria : Form
    {
        public CadCategoria()
        {
            InitializeComponent();
        }

        private void btnCadCategoria_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCategoria.Text.Trim()))
            {
                MessageBox.Show("Preencha o nome da categoria", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (new BoCategoria().Cadastrar(new DML.DmoCategoria() { Nome = txtCategoria.Text.Trim() }))
                    {
                        MessageBox.Show("Categoria Cadastrada com Sucesso", "Categoria cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao Cadastrar Categoria", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao Cadastrar Categoria.\nMensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
