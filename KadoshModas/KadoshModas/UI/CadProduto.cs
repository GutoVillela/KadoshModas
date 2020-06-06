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
        /// <summary>
        /// Inicializa o Formulário com função de Cadastrar Produto
        /// </summary>
        public CadProduto()
        {
            InitializeComponent();
            produto = new DmoProduto();
            btnCadastrar.Text = "Cadastrar Produto";
            this._funcaoFormulario = FuncaoFormulario.Cadastrar;
        }

        /// <summary>
        /// Inicializa o Formulário com função de Atualizar Produto
        /// </summary>
        /// <param name="pProduto">Produto a ser atualizado</param>
        public CadProduto(DmoProduto pProduto)
        {
            InitializeComponent();
            produto = pProduto;
            txtEstoque.Visible = lblEstoqueRotulo.Visible = false;
            btnCadastrar.Text = "Alterar Produto";
            PreencherCampos(pProduto);
            this._funcaoFormulario = FuncaoFormulario.Alterar;
        }
        #endregion

        #region Enum
        /// <summary>
        /// Enum que define a funcionalidade exercida pelo formulário
        /// </summary>
        private enum FuncaoFormulario
        {
            Cadastrar,

            Alterar
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

        /// <summary>
        /// Enum que define função atual do Formulário
        /// </summary>
        private FuncaoFormulario _funcaoFormulario;
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

        #region Métodos
        /// <summary>
        /// Preenche os campos com as informações do Cliente
        /// </summary>
        /// <param name="pProduto">Objeto DmoProduto preenchido com as informações do Produto</param>
        private void PreencherCampos(DmoProduto pProduto)
        {
            txtNomeProduto.Text = pProduto.Nome;
            txtCodigoDeBarras.Text = pProduto.CodigoDeBarra;
            txtPrecoUnidade.Text = pProduto.Preco.ToString();

            if(pProduto.Marca != null && !string.IsNullOrEmpty(pProduto.Marca.Nome))
                cboMarca.SelectedValue = pProduto.Marca.Nome;

            if (pProduto.Categoria != null && !string.IsNullOrEmpty(pProduto.Categoria.Nome))
                cboCategoria.SelectedValue = pProduto.Categoria.Nome;

            if(pProduto.Atributos != null && pProduto.Atributos.Any())
            {
                if(pProduto.Atributos.Any(a => a.Atributo.Nome == "COR"))
                {
                    txtCor.Text = pProduto.Atributos.Find(a => a.Atributo.Nome == "COR").Atributo.Nome;
                }

                if (pProduto.Atributos.Any(a => a.Atributo.Nome == "NUMERO"))
                {
                    txtTamanho.Text = pProduto.Atributos.Find(a => a.Atributo.Nome == "NUMERO").Atributo.Nome;
                }

                if (pProduto.Atributos.Any(a => a.Atributo.Nome == "TAMANHO"))
                {
                    txtTamanho.Text = pProduto.Atributos.Find(a => a.Atributo.Nome == "TAMANHO").Atributo.Nome;
                }
            }

            // Foto
            if (!string.IsNullOrEmpty(pProduto.UrlFoto))
                picFotoProduto.Image = new Bitmap(pProduto.UrlFoto);
        }

        /// <summary>
        /// Efetua o Cadastro do Produto
        /// </summary>
        /// <param name="pProduto">Objeto DmoProduto com informações do Produto para Cadastro</param>
        private void CadastrarProduto(DmoProduto pProduto)
        {
            //Efetuar cadastro do produto
            pProduto.IdProduto = new BoProduto().Cadastrar(produto);

            if (pProduto.IdProduto != null)
            {
                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Estoque
                DmoEstoque estoque = new DmoEstoque
                {
                    Produto = produto,
                    Quantidade = string.IsNullOrEmpty(txtEstoque.Text.Trim()) ? 0 : int.Parse(txtEstoque.Text.Trim()),
                    Minimo = 0
                };

                if (new BoEstoque().Cadastrar(estoque) != null)
                {
                    MessageBox.Show("Estoque cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Erro ao cadastrar um estoque para o produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Erro ao cadastrar produto!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Efetua a Atualização do Produto
        /// </summary>
        /// <param name="pProduto">Objeto DmoProduto com informações do Produto para Atualizar</param>
        private void AtualizarProduto(DmoProduto pProduto)
        {
            try
            {
                new BoProduto().Atualizar(pProduto);
                MessageBox.Show("Produto alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar produto! Mensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cboMarca.ValueMember = "Nome";

            //ComboBox de Categorias
            List<DmoCategoria> categorias = new BoCategoria().Consultar();
            cboCategoria.DataSource = categorias;
            cboCategoria.DisplayMember = "Nome";
            cboCategoria.ValueMember = "Nome";
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Críticas
            if (string.IsNullOrEmpty(txtNomeProduto.Text.Trim()))
            {
                MessageBox.Show("O campo Nome do Produto é obrigatório!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtPrecoUnidade.Text.Trim()))
            {
                MessageBox.Show("O campo Preço Por Unidade é obrigatório!", "Campo Obrigatório!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cadastro
            produto.Nome = txtNomeProduto.Text.Trim();
            produto.CodigoDeBarra = txtCodigoDeBarras.Text.Trim();
            produto.Preco = float.Parse(txtPrecoUnidade.Text.Trim());

            if(cboCategoria.SelectedIndex != -1)
                produto.Categoria = new DmoCategoria { Nome = cboCategoria.SelectedValue.ToString() };
            if(cboMarca.SelectedIndex != -1)
                produto.Marca = new DmoMarca { Nome = cboMarca.SelectedValue.ToString() };

            if (UsuarioEscolheuFotoProduto)
                produto.UrlFoto = openFileDialogFoto.FileName;

            #region Atributos do Produto
            List<DmoAtributosDoProduto> atributosDoProduto = new List<DmoAtributosDoProduto>();

            if (!string.IsNullOrWhiteSpace(txtCor.Text))
            {
                DmoAtributosDoProduto cor = new DmoAtributosDoProduto
                {
                    Atributo = new DmoAtributo { IdAtributo = 1 },
                    Valor = txtCor.Text.Trim()
                };

                atributosDoProduto.Add(cor);
            }

            if (!string.IsNullOrEmpty(txtTamanho.Text))
            {
                DmoAtributosDoProduto tamanho = new DmoAtributosDoProduto
                {
                    Atributo = new DmoAtributo { IdAtributo = 3 },
                    Valor = txtTamanho.Text.Trim()
                };
                atributosDoProduto.Add(tamanho);
            }

            if(atributosDoProduto.Any())
                produto.Atributos = atributosDoProduto;
            #endregion

            try
            {
                if (_funcaoFormulario == FuncaoFormulario.Cadastrar)
                    CadastrarProduto(produto);
                else if(_funcaoFormulario == FuncaoFormulario.Alterar)
                    AtualizarProduto(produto);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar produto! Mensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            picFotoProduto.Image = Properties.Resources.icone_produto;
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

        private void btnDesativarProduto_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir o Produto? ", "Confirmar exclusão do produto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new BoProduto().DesativarProduto(int.Parse(produto.IdProduto.ToString()));
                this.Close();
            }
        }
        #endregion
    }
}
