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
using KadoshModas.UI.UserControls;
using KadoshModas.BLL;
using System.Reflection;

namespace KadoshModas.UI
{
    public partial class FichaCliente : Form
    {
        #region Construtor
        public FichaCliente(DmoCliente pCliente)
        {
            InitializeComponent();
            this.Cliente = pCliente;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade com informações do Cliente manipuladas na tela
        /// </summary>
        private DmoCliente Cliente { get; set; }
        #endregion

        #region Métodos
        /// <summary>
        /// Preenche a tela com as informações do Cliente
        /// </summary>
        /// <param name="pCliente">Objeto DmoCliente Preenchido com as informações do Cliente</param>
        /// <returns></returns>
        private async Task CarregarClienteAsync(DmoCliente pCliente)
        {
            if (!string.IsNullOrEmpty(pCliente.UrlFoto))
                picFotoCliente.Image = Image.FromFile(pCliente.UrlFoto);

            if(pCliente.IdCliente == DmoCliente.IdClienteIndefinido)
            {
                btnEditarCliente.Visible = false;
                btnApagarCliente.Visible = false;
            }

            txtNomeCliente.Text = pCliente.Nome;
            txtCPF.Text = string.IsNullOrEmpty(pCliente.CPF) ? "Não definido" : pCliente.CPF;
            txtSexo.Text = DmoCliente.DescricaoEnum<Sexo>(pCliente.Sexo);
            txtRua.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.Rua)) ? pCliente.Endereco.Rua : "Não cadastrado";
            txtBairro.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.Bairro)) ? pCliente.Endereco.Bairro : "Não cadastrado";
            txtCidade.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.Cidade.Nome)) ? pCliente.Endereco.Cidade.Nome : "Não cadastrado";
            txtCEP.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.CEP)) ? pCliente.Endereco.CEP : "00000-000";
            txtNumero.Text = (pCliente.Endereco != null && !string.IsNullOrEmpty(pCliente.Endereco.CEP)) ? pCliente.Endereco.Numero : "Não cadastrado";

            //Telefones do Cliente
            if (pCliente.Telefones != null && pCliente.Telefones.Any())
            {
                pnlTelefones.Controls.Clear();

                foreach(DmoTelefone telefone in pCliente.Telefones)
                {
                    ucTelefone ucTelefone = new ucTelefone
                    {
                        Telefone = telefone
                    };
                    pnlTelefones.Controls.Add(ucTelefone);
                }
            }

            //Compras do Cliente
            List<DmoVenda> comprasDoCliente = await new BoVenda().ConsultarComprasDoClienteAsync(pCliente.IdCliente);

            if (comprasDoCliente.Any())
            {
                pnlCompras.Controls.Clear();

                foreach (DmoVenda compra in comprasDoCliente)
                {
                    ucCompraListItem ucCompra = new ucCompraListItem
                    {
                        Venda = compra
                    };

                    pnlCompras.Controls.Add(ucCompra);
                }
            }
        }
        #endregion

        #region Eventos
        private async void FichaCliente_Load(object sender, EventArgs e)
        {
            //Formulário
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            this.Size = INF.ParametrosDoSistema.TAMANHO_FORMULARIOS;

            await CarregarClienteAsync(this.Cliente);
        }

        private void tbcFichaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aba de Compras
            if (tbcFichaCliente.SelectedTab == tbcFichaCliente.TabPages[1])
            {

            }
        }

        private async void btnEditarCliente_Click(object sender, EventArgs e)
        {
            new CadCliente(this.Cliente).ShowDialog();
            await CarregarClienteAsync(Cliente);
        }

        private async void btnApagarCliente_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ATENÇÃO! Tem certeza que deseja excluir o Cliente?", "Confirmação de Exclusão de Cliente", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await new BoCliente().DesativarClienteAsync(int.Parse(Cliente.IdCliente.ToString()));
                }
                catch(Exception erro)
                {
                    MessageBox.Show("Aconteceu um erro ao tentar Apagar o Cliente! Mensagem original: " + erro.Message, "Erro ao Apagar o Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion


    }
}
