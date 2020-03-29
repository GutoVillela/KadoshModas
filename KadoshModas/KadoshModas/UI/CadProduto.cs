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
    public partial class CadProduto : Form
    {
        public CadProduto()
        {
            InitializeComponent();
        }

        private void CadProduto_Load(object sender, EventArgs e)
        {
            //ComboBox de Marcas
            List<DmoMarca> marcas = new BoMarca().Consultar();
            cboMarca.DataSource = marcas;
            cboMarca.DisplayMember = "Nome";
            cboMarca.ValueMember = "IdMarca";

            //ComboBox de Categorias
            List<DmoCategoria> categorias = new BoCategoria().Consultar();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nome";
            cboCategoria.ValueMember = "IdCategoria";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            DmoProduto produto = new DmoProduto
            {
                Nome = txtNomeProduto.Text.Trim(),
                Preco = float.Parse(txtPrecoUnidade.Text.Trim()),
                Categoria = new DmoCategoria { IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString()) },
                Marca = new DmoMarca { IdMarca = int.Parse(cboMarca.SelectedValue.ToString()) }
            };

            if(new BoProduto().Cadastrar(produto))
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Erro ao cadastrar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
