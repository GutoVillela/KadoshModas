using KadoshModas.BLL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KadoshModas.UI
{
    public partial class CadCliente : Form
    {
        #region Construtor
        public CadCliente()
        {
            InitializeComponent();
            this.cliente = new DmoCliente();
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto DmoCliente base para cadastro de cliente
        /// </summary>
        private DmoCliente cliente;

        private int _etapaAtual;

        private bool _usuarioEscolheuFotoCliente;

        private bool cadastroFinalizado = false;
        #endregion

        #region Propriedades
        /// <summary>
        /// Representa a etapa de cadastro atual
        /// </summary>
        private int EtapaAtual 
        {
            get { return _etapaAtual; }
            set
            {
                if(value == 3)
                {
                    btnCadastrarCliente.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    btnCadastrarCliente.BackColor = Color.Green;
                    btnCadastrarCliente.Text = "Cadastrar Cliente";
                }
                else
                {
                    btnCadastrarCliente.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight;
                    btnCadastrarCliente.BackColor = Color.Black;
                    btnCadastrarCliente.Text = "Próxima Etapa";
                }

                this._etapaAtual = value;
            }
        }

        private bool UsuarioEscolheuFotoCliente
        {
            get { return _usuarioEscolheuFotoCliente; }
            set 
            { 
                _usuarioEscolheuFotoCliente = value;
                btnRemoverFoto.Visible = btnRemoverFoto.Enabled = value;
            }
        }
        #endregion

        #region Métodos
        private void MontarAmbienteInicial()
        {
            //Formulário
            this.Size = INF.ParametrosDoSistema.TAMANHO_FORMULARIOS;

            //Panels das etapas e de conteúdo
            pnlConteudo.Location = new Point { X = 0, Y = 0 };
            pnlConteudo.Dock = DockStyle.Fill;
            pnlConteudo.Controls.Add(pnlCadCliEtapa1);
            pnlConteudo.Controls.Add(pnlCadCliEtapa2);
            pnlConteudo.Controls.Add(pnlCadCliEtapa3);
            pnlCadCliEtapa1.Dock = DockStyle.Top;
            pnlCadCliEtapa2.Dock = DockStyle.Top;
            pnlCadCliEtapa3.Dock = DockStyle.Top;
            
            //ComboBox de Estados
            List<DmoEstado> estados = new BoEstado().Consultar();
            cboEstado.DataSource = estados;
            cboEstado.DisplayMember = "Nome";
            cboEstado.ValueMember = "IdEstado";
            cboEstado.SelectedItem = estados.Find(estado => estado.Nome == "São Paulo");

            //ComboBox de Tipo de Telefone
            cboTipoTelefone.DataSource = new BindingSource(new DmoTelefone().DescricoesEnum<DmoTelefone.TiposDeTelefone>().OrderBy(key => key.Value), null);
            cboTipoTelefone.DisplayMember = "Key";

            MudarParaEtapa(1);
        }

        /// <summary>
        /// Altera o formulário para configura o ambiente para nova etapa de cadastro
        /// </summary>
        /// <param name="pNumEtapa">Número da Etapa de Cadastro desejada</param>
        private void MudarParaEtapa(int pNumEtapa)
        {
            if (EtapaAtual == 1)
            {
                if (!ConcluirEtapa1())
                    return;
            }
            else if (EtapaAtual == 2)
                if (!ConcluirEtapa2())
                    return;

            //Mudar para Etapa
            switch (pNumEtapa)
            {
                case 1:
                    pnlCadCliEtapa1.BringToFront();
                    pnlCadCliEtapa1.Visible = true;

                    pnlCadCliEtapa2.Visible = false;
                    pnlCadCliEtapa3.Visible = false;

                    picEtapa1.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
                    picEtapa2.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa3.IconChar = FontAwesome.Sharp.IconChar.Circle;

                    break;
                case 2:
                    pnlCadCliEtapa2.BringToFront();
                    pnlCadCliEtapa2.Visible = true;

                    pnlCadCliEtapa1.Visible = false;
                    pnlCadCliEtapa3.Visible = false;

                    picEtapa1.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa2.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
                    picEtapa3.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    break;
                case 3:
                    pnlCadCliEtapa3.BringToFront();
                    pnlCadCliEtapa3.Visible = true;

                    pnlCadCliEtapa1.Visible = false;
                    pnlCadCliEtapa2.Visible = false;

                    picEtapa1.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa2.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa3.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
                    break;
                default:
                    throw new Exception("O número de etapas precisa estar entre 1 e 3");
            }

            this.EtapaAtual = pNumEtapa;
        }

        /// <summary>
        /// Adiciona um Telefone à lista de Telefones do Cliente
        /// </summary>
        /// <returns>Retorna true em caso de sucesso e false em caso de erro</returns>
        private bool AdicionarTelefone()
        {
            string numTelefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
            if (!string.IsNullOrEmpty(numTelefone) && numTelefone.Length >= 10)
            {
                DmoTelefoneDoCliente telefone = new DmoTelefoneDoCliente
                {
                    DDD = numTelefone.Substring(0, 2),
                    Numero = numTelefone.Substring(2, numTelefone.Length == 11 ? 9 : 8),
                    TipoDeTelefone = (DmoTelefone.TiposDeTelefone)((KeyValuePair<string, int>)cboTipoTelefone.SelectedValue).Value
                };

                if (!string.IsNullOrEmpty(txtFalarCom.Text.Trim()))
                    telefone.FalarCom = txtFalarCom.Text.Trim();

                if (this.cliente.Telefones == null)
                    this.cliente.Telefones = new List<DmoTelefoneDoCliente>();

                //Verificar se telefone já foi adicionado na lista
                if (cliente.Telefones.Any(t => t.DDD == telefone.DDD && t.Numero == telefone.Numero))
                {
                    MessageBox.Show("Este número já foi adicionado na lista de telefones. Se você deseja CORRIGI-LO, exclua-o da lista de telefones e depois tente novamente.", "Telefone já adicionado na lista", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }

                cliente.Telefones.Add(telefone);
                lstTelefones.Items.Add("(" + telefone.DDD + ")" + telefone.Numero + " - " + telefone.DescricaoEnum<DmoTelefone.TiposDeTelefone>(telefone.TipoDeTelefone) + " - Falar com: " + (string.IsNullOrEmpty(telefone.FalarCom) ? " O próprio cliente" : telefone.FalarCom));
                
                return true;

            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Concluir e registra informações inseridas na Etapa 1 no objeto DmoCliente de cadastro
        /// </summary>
        /// <returns>Retorna true em caso de sucesso e false em caso de falha</returns>
        private bool ConcluirEtapa1()
        {
            //Informações pessoais
            if (string.IsNullOrEmpty(txtNomeCliente.Text.Trim())){
                MessageBox.Show("O campo NOME do cliente é obrigatório. Por favor insira o NOME do cliente.", "Informações obrigatórias necessárias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            cliente.Nome = txtNomeCliente.Text.Trim();

            if (!string.IsNullOrEmpty(txtCpf.Text.Replace(".", "").Replace("-", "").Trim()))
            {
                if(!new BoCliente().ValidarCPF(txtCpf.Text.Replace(".", "").Replace("-", "").Trim()))
                {
                    MessageBox.Show("Insira um CPF válido para cadastro ou deixe o campo CPF em branco.", "CPF inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                cliente.CPF = txtCpf.Text.Trim();
            }

            if (rdbSexoFeminino.Checked)
                cliente.Sexo = DmoCliente.Sexos.Feminino;
            else if (rdbSexoMasculino.Checked)
                cliente.Sexo = DmoCliente.Sexos.Masculino;

            //Endereço
            if (!string.IsNullOrEmpty(txtRua.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo NÚMERO para cadastrar o endereço.", "Informações obrigatórias necessárias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                cliente.Endereco = new DmoEndereco
                {
                    Rua = txtRua.Text.Trim(),
                    Numero = txtNumero.Text.Trim(),
                    Cidade = (DmoCidade)cboCidade.SelectedItem
                };
                if (!string.IsNullOrEmpty(txtBairro.Text.Trim()))
                    cliente.Endereco.Bairro = txtBairro.Text.Trim();

                if (!string.IsNullOrEmpty(txtCep.Text.Replace("-", "").Trim()))
                    cliente.Endereco.CEP = txtCep.Text.Replace("-", "").Trim();

                if (!string.IsNullOrEmpty(txtComplemento.Text.Trim()))
                    cliente.Endereco.Complemento = txtComplemento.Text.Trim();

            }

            return true;
        }

        /// <summary>
        /// Concluir e registra informações inseridas na Etapa 2 no objeto DmoCliente de cadastro
        /// </summary>
        /// <returns>Retorna true em caso de sucesso e false em caso de falha</returns>
        private bool ConcluirEtapa2()
        {
            //E-mail
            if (!string.IsNullOrEmpty(txtEmail.Text.Trim()))
            {
                if(!new BoCliente().ValidarEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Insira um E-MAIL válido para cadastrar ou deixe o campo de E-MAIL em branco.", "E-mail inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                cliente.Email = txtEmail.Text.Trim();
            }

            //Cadastro de telefone
            if(!string.IsNullOrEmpty(txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim()) && !chkMaisNumeros.Checked)
            {
                if (!AdicionarTelefone())
                {
                    MessageBox.Show("Preencha corretamente o número de telefone", "Informações de telefone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }

        /// <summary>
        /// Cadastra o Cliente com as informações preenchidas nas etapas de cadastro
        /// </summary>
        private void CadastrarCliente()
        {
            if (new BoCliente().Cadastrar(cliente))
            {
                MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cadastroFinalizado = true;
                this.Close();
            }
            else
                MessageBox.Show("Aconteceu um erro ao cadastrar o novo cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
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

        private async Task<bool> VerificaCPFExistenteAsync(string pCPF)
        {
            return true;
        }
        #endregion

        #region Eventos
        private void chkMaisNumeros_CheckedChanged(object sender, EventArgs e)
        {
            btnAddNumero.Visible = btnAddNumero.Enabled = chkMaisNumeros.Checked;
            lstTelefones.Visible = chkMaisNumeros.Checked;
        }

        private void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            if(EtapaAtual == 3)
                CadastrarCliente();
            else
                MudarParaEtapa(EtapaAtual + 1);
            
        }

        private void CadCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cadastroFinalizado)
            {
                if (MessageBox.Show("Cancelar cadastro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CadCliente_Load(object sender, EventArgs e)
        {
            MontarAmbienteInicial();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DmoCidade> cidades = new BoCidade().ConsultarDoEstado(((DmoEstado)cboEstado.SelectedItem).IdEstado);
            cboCidade.DataSource = cidades;
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "IdCidade";

            if (((DmoEstado)cboEstado.SelectedItem).Nome == "São Paulo")
                cboCidade.SelectedItem = cidades.Find(c => c.Nome == "São Paulo");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboTipoTelefone_SelectedIndexChanged(object sender, EventArgs e)
        {
            var itemSelecionado = (KeyValuePair<string, int>)cboTipoTelefone.SelectedValue;
            lblFalarCom.Visible = txtFalarCom.Visible = itemSelecionado.Value == (int)DmoTelefone.TiposDeTelefone.NumeroDeParente
                || itemSelecionado.Value == (int)DmoTelefone.TiposDeTelefone.NumeroDeConhecido
                || itemSelecionado.Value == (int)DmoTelefone.TiposDeTelefone.Outro;

            txtFalarCom.Clear();
        }

        private void btnAddNumero_Click(object sender, EventArgs e)
        {
            if(!AdicionarTelefone())
                MessageBox.Show("Preencha corretamente o número de telefone", "Erro telefone", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async void txtCpf_TextChanged(object sender, EventArgs e)
        {
            string cpfInformado = txtCpf.Text.Trim();

            if (cpfInformado.Length == 1 || cpfInformado.Length == 10)
            {
                pcbLoaderCPF.Image = Properties.Resources.transparent_loading_gif;
            }

            if (cpfInformado.Length == 14)
            {
                if (new BoCliente().ValidarCPF(cpfInformado))
                {
                    if(!await new BoCliente().VerificaCPFExistenteAsync(cpfInformado))
                        pcbLoaderCPF.Image = Properties.Resources.icone_valido;
                    else
                        pcbLoaderCPF.Image = Properties.Resources.icone_invalido;
                }
                else
                    pcbLoaderCPF.Image = Properties.Resources.icone_invalido;

            }

            pcbLoaderCPF.Visible = txtCpf.Text.Replace(".", "").Replace("-", "").Trim().Length > 0;
        }

        private void picEtapa1_Click(object sender, EventArgs e)
        {
            MudarParaEtapa(1);
        }

        private void picEtapa2_Click(object sender, EventArgs e)
        {
            MudarParaEtapa(2);
        }

        private void picEtapa3_Click(object sender, EventArgs e)
        {
            MudarParaEtapa(3);
        }

        private void btnTirarFoto_Click(object sender, EventArgs e)
        {

        }

        private void btnEscolherFotoDoPc_Click(object sender, EventArgs e)
        {
            if(openFileDialogFoto.ShowDialog() == DialogResult.OK)
            {
                picFotoCliente.Image = new Bitmap(openFileDialogFoto.FileName);
                cliente.UrlFoto = openFileDialogFoto.FileName;
                UsuarioEscolheuFotoCliente = true;
            }
        }

        private void btnRemoverFoto_Click(object sender, EventArgs e)
        {
            picFotoCliente.Image = Properties.Resources.usuario_perfil_padrao;
            cliente.UrlFoto = string.Empty;
            UsuarioEscolheuFotoCliente = false;
        }

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtCpf_Click(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtCep_Enter(object sender, EventArgs e)
        {
            ComportamentoMaskedTextBox((MaskedTextBox)sender);
        }

        private void txtCep_Click(object sender, EventArgs e)
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
