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
    public partial class CadFornecedor : Form
    {
        public CadFornecedor()
        {
            InitializeComponent();
        }

        #region Métodos
        /// <summary>
        /// Monta o ambiente inicial da tela
        /// </summary>
        private async Task MontarAmbienteInicialAsync()
        {
            //Formulário
            this.Size = INF.ParametrosDoSistema.TAMANHO_FORMULARIOS;

            //ComboBox de Estados
            List<DmoEstado> estados = await new BoEstado().ConsultarAsync();
            cboEstado.DataSource = estados;
            cboEstado.DisplayMember = "Nome";
            cboEstado.ValueMember = "IdEstado";
            cboEstado.SelectedItem = estados.Find(estado => estado.Nome == "São Paulo");
        }

        /// <summary>
        /// Define o comportamento da Masked TextBox
        /// </summary>
        /// <param name="pMaskedTextBox">MaskedTextBox alvo</param>
        private void ComportamentoMaskedTextBox(MaskedTextBox pMaskedTextBox)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                int ultimoCaractereNumerico = pMaskedTextBox.Text.LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
                pMaskedTextBox.Select(ultimoCaractereNumerico < 0 ? 0 : ultimoCaractereNumerico + 1, 0);
            });
        }

        /// <summary>
        /// Efetua o Cadastro do Fornecedor
        /// </summary>
        private async Task CadastrarFornecedorAsync()
        {
            if (string.IsNullOrEmpty(txtNomeFornecedor.Text.Trim()))
            {
                MessageBox.Show("O campo Fornecedor é obrigatório.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Informações pessoais
                DmoFornecedor fornecedor = new DmoFornecedor()
                {
                    Nome = txtNomeFornecedor.Text.Trim(),
                    CNPJ = string.IsNullOrEmpty(txtCNPJ.Text.Replace(".", "").Replace("/", "").Replace("/", "").Replace("-", "").Trim()) ? null : txtCNPJ.Text
                };

                // Telefone
                string numTelefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();

                if (!string.IsNullOrEmpty(numTelefone))
                {
                    if(numTelefone.Length < 10)
                    {
                        MessageBox.Show("Telefone não preenchido corretamente.", "Informações obrigatórias necessárias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    DmoTelefoneDoFornecedor telefoneDoFornecedor = new DmoTelefoneDoFornecedor()
                    {
                        DDD = numTelefone.Substring(0, 2),
                        Numero = numTelefone.Substring(2, numTelefone.Length == 11 ? 9 : 8),
                        TipoDeTelefone = DmoTelefone.TiposDeTelefone.Comercial
                    };

                    fornecedor.Telefones = new List<DmoTelefoneDoFornecedor>();
                    fornecedor.Telefones.Add(telefoneDoFornecedor);
                }

                //Endereço
                if (!string.IsNullOrEmpty(txtRua.Text.Trim()))
                {
                    if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
                    {
                        MessageBox.Show("Preencha o campo NÚMERO para cadastrar o endereço.", "Informações obrigatórias necessárias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (fornecedor.Endereco == null)
                        fornecedor.Endereco = new DmoEndereco();

                    fornecedor.Endereco.Rua = txtRua.Text.Trim();
                    fornecedor.Endereco.Numero = txtNumero.Text.Trim();
                    fornecedor.Endereco.Cidade = (DmoCidade)cboCidade.SelectedItem;

                    if (!string.IsNullOrEmpty(txtBairro.Text.Trim()))
                        fornecedor.Endereco.Bairro = txtBairro.Text.Trim();

                    if (!string.IsNullOrEmpty(txtCep.Text.Replace("-", "").Trim()))
                        fornecedor.Endereco.CEP = txtCep.Text.Trim();

                    if (!string.IsNullOrEmpty(txtComplemento.Text.Trim()))
                        fornecedor.Endereco.Complemento = txtComplemento.Text.Trim();
                }

                // Efetuar cadastro
                try
                {
                    fornecedor.IdFornecedor = await new BoFornecedor().CadastrarAsync(fornecedor);

                    if (fornecedor.IdFornecedor == null)
                        throw new Exception("Não foi possível cadastrar o Fornecedor! Tente novamente mais tarde.");

                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Fornecedor cadastrado com sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception erro)
                {
                    MessageBox.Show("Aconteceu um erro ao cadastrar fornecedor! Mensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
        }
        #endregion

        #region Eventos
        private async void CadFornecedor_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.ICONE_KADOSH_128X128;
            await MontarAmbienteInicialAsync();
        }

        private async void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DmoCidade> cidades = await new BoCidade().ConsultarDoEstadoAsync(((DmoEstado)cboEstado.SelectedItem).IdEstado);
            cboCidade.DataSource = cidades;
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "IdCidade";

            if (((DmoEstado)cboEstado.SelectedItem).Nome == "São Paulo")
                cboCidade.SelectedItem = cidades.Find(c => c.Nome == "São Paulo");
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            await CadastrarFornecedorAsync();
        }

        private void txtCNPJ_Enter(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtCNPJ_Click(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtTelefone_Click(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }
        #endregion
    }
}
