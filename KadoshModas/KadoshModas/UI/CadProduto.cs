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
        #region Construtor
        public CadProduto()
        {
            InitializeComponent();
            produto = new DmoProduto();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Produto utilizado para cadastro
        /// </summary>
        private DmoProduto produto;

        /// <summary>
        /// Verifica se usuário já definiu foto do produto (utilize a propriedade UsuarioEscolheuFotoProduto para acessar este dado)
        /// </summary>
        private bool _usuarioEscolheuFotoProduto;

        /// <summary>
        /// Verifica se usuário já definiu os fornecedores para o produto (utilize a propriedade FornecedoresDefinidos para acessar este dado)
        /// </summary>
        private bool _fornecedoresDefinidos;
        #endregion

        #region Propriedades

        /// <summary>
        /// Define se usuário já escolheu uma foto para o produto
        /// </summary>
        private bool UsuarioEscolheuFotoProduto
        {
            get { return _usuarioEscolheuFotoProduto; }
            set
            {
                _usuarioEscolheuFotoProduto = value;
                btnRemoverFoto.Visible = btnRemoverFoto.Enabled = value;
            }
        }

        /// <summary>
        /// Verifica se usuário já definiu os Fornecedores para o Produto
        /// </summary>
        private bool FornecedoresDefinidos
        {
            get { return _fornecedoresDefinidos; }
            set
            {
                if (value)
                {
                    btnDefinirFornecedores.BackColor = Color.Green;
                    btnDefinirFornecedores.IconChar = FontAwesome.Sharp.IconChar.Check;
                    btnDefinirFornecedores.IconColor = Color.LightGreen;
                    btnDefinirFornecedores.Text = "Definido";
                }
                else
                {
                    btnDefinirFornecedores.BackColor = Color.DarkRed;
                    btnDefinirFornecedores.IconChar = FontAwesome.Sharp.IconChar.Times;
                    btnDefinirFornecedores.IconColor = Color.LightPink;
                    btnDefinirFornecedores.Text = "Não Definido";
                }
                _fornecedoresDefinidos = value;
            }
        }
        #endregion

        #region Eventos
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
            produto.Nome = txtNomeProduto.Text.Trim();
            produto.Preco = float.Parse(txtPrecoUnidade.Text.Trim());
            produto.Categoria = new DmoCategoria { IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString()) };
            produto.Marca = new DmoMarca { IdMarca = int.Parse(cboMarca.SelectedValue.ToString()) };

            if (_usuarioEscolheuFotoProduto)
                produto.UrlFoto = openFileDialogFoto.FileName;

            DmoAtributosDoProduto cor = new DmoAtributosDoProduto
            {
                Atributo = new DmoAtributo { IdAtributo = 1 },
                Valor = txtCor.Text.Trim()
            };

            DmoAtributosDoProduto tamanho = new DmoAtributosDoProduto
            {
                Atributo = new DmoAtributo { IdAtributo = 3 },
                Valor = txtTamanho.Text.Trim()
            };

            List<DmoAtributosDoProduto> atributosDoProduto = new List<DmoAtributosDoProduto>();
            atributosDoProduto.Add(cor);
            atributosDoProduto.Add(tamanho);

            produto.Atributos = atributosDoProduto;

            //Efetuar cadastro do produto
            produto.IdProduto = new BoProduto().Cadastrar(produto);

            if (produto.IdProduto != null)
            {
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Estoque
                DmoEstoque estoque = new DmoEstoque
                {
                    Produto = produto,
                    Quantidade = string.IsNullOrEmpty(txtEstoque.Text.Trim()) ? 0 : int.Parse(txtEstoque.Text.Trim()),
                    Minimo = 0
                };

                if(new BoEstoque().Cadastrar(estoque) != null)
                {
                    MessageBox.Show("Estoque cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Erro ao cadastrar um estoque para o produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Erro ao cadastrar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEscolherFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                picFotoProduto.Image = new Bitmap(openFileDialogFoto.FileName);
                UsuarioEscolheuFotoProduto = true;
            }
        }

        private void btnRemoverFoto_Click(object sender, EventArgs e)
        {
            picFotoProduto.Image = Properties.Resources.usuario_perfil_padrao;
            UsuarioEscolheuFotoProduto = false;
        }

        private void btnDefinirFornecedores_Click(object sender, EventArgs e)
        {
            new DefinirFornecedores().ShowDialog();
            produto.Fornecedores = DefinirFornecedores.listaDeFornecedoresDefinidos;

            if(produto.Fornecedores == null || !produto.Fornecedores.Any())
                FornecedoresDefinidos = false;
            else
                FornecedoresDefinidos = true;
        }
        #endregion


    }
}
