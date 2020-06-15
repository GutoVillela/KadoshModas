using KadoshModas.BLL;
using KadoshModas.DML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            this._funcaoFormulario = FuncaoFormulario.Cadastrar;
        }

        public CadCliente(DmoCliente pDmoCliente)
        {
            InitializeComponent();
            this.cliente = pDmoCliente;
            this._funcaoFormulario = FuncaoFormulario.Alterar;
            PreencherCampos(cliente);
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

        /// <summary>
        /// Enum que define as etapas para o cadastro do Cliente
        /// </summary>
        private enum EtapaDeCadastro
        {
            InformacoesPessoais = 1,

            InformacoesDeContato = 2,

            Foto = 3
        }
        #endregion

        #region Atributos
        /// <summary>
        /// Objeto DmoCliente base para cadastro de cliente
        /// </summary>
        private DmoCliente cliente;

        private FuncaoFormulario _funcaoFormulario;

        private EtapaDeCadastro _etapaAtual;

        private bool _usuarioEscolheuFotoCliente;

        private bool cadastroFinalizado = false;
        #endregion

        #region Propriedades
        /// <summary>
        /// Representa a etapa de cadastro atual
        /// </summary>
        private EtapaDeCadastro EtapaAtual 
        {
            get { return _etapaAtual; }
            set
            {
                if(value == EtapaDeCadastro.Foto)
                {
                    btnCadastrarCliente.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
                    btnCadastrarCliente.BackColor = Color.Green;
                    if (_funcaoFormulario == FuncaoFormulario.Cadastrar)
                        btnCadastrarCliente.Text = "Cadastrar Cliente";
                    else if (_funcaoFormulario == FuncaoFormulario.Alterar)
                        btnCadastrarCliente.Text = "Alterar Cliente";
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
        private async Task MontarAmbienteInicialAsync()
        {
            //Formulário
            this.Size = INF.ParametrosDoSistema.TAMANHO_FORMULARIOS;

            //Panels das etapas e de conteúdo
            pnlConteudo.Location = new Point { X = 0, Y = 0 };
            //pnlConteudo.Dock = DockStyle.Top;
            pnlConteudo.Controls.Add(pnlCadCliEtapa1);
            pnlConteudo.Controls.Add(pnlCadCliEtapa2);
            pnlConteudo.Controls.Add(pnlCadCliEtapa3);
            pnlCadCliEtapa1.Dock = DockStyle.Top;
            pnlCadCliEtapa2.Dock = DockStyle.Top;
            pnlCadCliEtapa3.Dock = DockStyle.Top;
            
            //ComboBox de Estados
            List<DmoEstado> estados = await new BoEstado().ConsultarAsync();
            cboEstado.DataSource = estados;
            cboEstado.DisplayMember = "Nome";
            cboEstado.ValueMember = "IdEstado";
            cboEstado.SelectedItem = estados.Find(estado => estado.Nome == "São Paulo");

            //ComboBox de Tipo de Telefone
            cboTipoTelefone.DataSource = new BindingSource(DmoTelefone.DescricoesEnum<DmoTelefone.TiposDeTelefone>().OrderBy(key => key.Value), null);
            cboTipoTelefone.DisplayMember = "Key";

            MudarParaEtapa(EtapaDeCadastro.InformacoesPessoais);
        }

        /// <summary>
        /// Preenche os campos com as informações do Cliente
        /// </summary>
        /// <param name="pDmoCliente">Objeto DmoCliente preenchido com as informações do Cliente</param>
        private void PreencherCampos(DmoCliente pDmoCliente)
        {
            //Informações pessoais
            txtNomeCliente.Text = pDmoCliente.Nome;
            txtCpf.Text = pDmoCliente.CPF;

            if (pDmoCliente.Sexo == Sexo.Feminino)
                rdbSexoFeminino.Checked = true;
            else if(pDmoCliente.Sexo == Sexo.Masculino)
                rdbSexoMasculino.Checked = true;

            //Endereço
            if(pDmoCliente.Endereco != null)
            {
                txtRua.Text = pDmoCliente.Endereco.Rua;
                txtBairro.Text = pDmoCliente.Endereco.Bairro;
                txtCep.Text = pDmoCliente.Endereco.CEP;
                txtNumero.Text = pDmoCliente.Endereco.Numero;
                cboEstado.SelectedText = pDmoCliente.Endereco.Cidade.Estado.Nome;
                cboCidade.SelectedText = pDmoCliente.Endereco.Cidade.Nome;
                txtComplemento.Text = pDmoCliente.Endereco.Complemento;
            }

            //Informações de contato
            txtEmail.Text = pDmoCliente.Email;

            if(pDmoCliente.Telefones != null && pDmoCliente.Telefones.Any())
            {
                if(pDmoCliente.Telefones.Count > 1)
                {
                    chkMaisNumeros.Checked = true;

                    foreach (DmoTelefone telefone in pDmoCliente.Telefones)
                    {
                        lstTelefones.Items.Add("(" + telefone.DDD + ")" + telefone.Numero + " - " + DmoTelefone.DescricaoEnum<DmoTelefone.TiposDeTelefone>(telefone.TipoDeTelefone) + " - Falar com: " + (string.IsNullOrEmpty(telefone.FalarCom) ? " O próprio cliente" : telefone.FalarCom));
                    }
                }
                else
                {
                    txtTelefone.Text = pDmoCliente.Telefones[0].DDD + pDmoCliente.Telefones[0].Numero;
                }
            }

            // Foto
            if (!string.IsNullOrEmpty(pDmoCliente.UrlFoto))
                picFotoCliente.Image = new Bitmap(pDmoCliente.UrlFoto);

        }

        /// <summary>
        /// Altera o formulário para configura o ambiente para nova etapa de cadastro
        /// </summary>
        /// <param name="pNumEtapa">Etapa de Cadastro desejada</param>
        private void MudarParaEtapa(EtapaDeCadastro pNumEtapa)
        {
            if (EtapaAtual == EtapaDeCadastro.InformacoesPessoais)
            {
                if (!ConcluirEtapa1())
                    return;
            }
            else if (EtapaAtual == EtapaDeCadastro.InformacoesDeContato)
                if (!ConcluirEtapa2())
                    return;

            //Mudar para Etapa
            switch (pNumEtapa)
            {
                case EtapaDeCadastro.InformacoesPessoais:
                    pnlCadCliEtapa1.BringToFront();
                    pnlCadCliEtapa1.Visible = true;

                    pnlCadCliEtapa2.Visible = false;
                    pnlCadCliEtapa3.Visible = false;

                    picEtapa1.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
                    picEtapa2.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa3.IconChar = FontAwesome.Sharp.IconChar.Circle;

                    break;
                case EtapaDeCadastro.InformacoesDeContato:
                    pnlCadCliEtapa2.BringToFront();
                    pnlCadCliEtapa2.Visible = true;

                    pnlCadCliEtapa1.Visible = false;
                    pnlCadCliEtapa3.Visible = false;

                    picEtapa1.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    picEtapa2.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
                    picEtapa3.IconChar = FontAwesome.Sharp.IconChar.Circle;
                    break;
                case EtapaDeCadastro.Foto:
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
                if (!cliente.Telefones.Any(t => t.DDD == telefone.DDD && t.Numero == telefone.Numero))
                {
                    cliente.Telefones.Add(telefone);
                }

                
                string numLista = "(" + telefone.DDD + ")" + telefone.Numero + " - " + DmoTelefone.DescricaoEnum<DmoTelefone.TiposDeTelefone>(telefone.TipoDeTelefone) + " - Falar com: " + (string.IsNullOrEmpty(telefone.FalarCom) ? " O próprio cliente" : telefone.FalarCom);

                if(!lstTelefones.Items.Contains(numLista))
                    lstTelefones.Items.Add(numLista);
                
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
                cliente.Sexo = Sexo.Feminino;
            else if (rdbSexoMasculino.Checked)
                cliente.Sexo = Sexo.Masculino;

            //Endereço
            if (!string.IsNullOrEmpty(txtRua.Text.Trim()))
            {
                if (string.IsNullOrEmpty(txtNumero.Text.Trim()))
                {
                    MessageBox.Show("Preencha o campo NÚMERO para cadastrar o endereço.", "Informações obrigatórias necessárias", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (cliente.Endereco == null)
                    cliente.Endereco = new DmoEndereco();

                cliente.Endereco.Rua = txtRua.Text.Trim();
                cliente.Endereco.Numero = txtNumero.Text.Trim();
                cliente.Endereco.Cidade = (DmoCidade)cboCidade.SelectedItem;

                if (!string.IsNullOrEmpty(txtBairro.Text.Trim()))
                    cliente.Endereco.Bairro = txtBairro.Text.Trim();

                if (!string.IsNullOrEmpty(txtCep.Text.Replace("-", "").Trim()))
                    cliente.Endereco.CEP = txtCep.Text.Trim();

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
        private async Task CadastrarClienteAsync()
        {
            if (await new BoCliente().CadastrarAsync(cliente))
            {
                MessageBox.Show("Cliente cadastrado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cadastroFinalizado = true;

                if (_funcaoFormulario == FuncaoFormulario.Alterar)
                    this.Close();
                else
                    AbrirFormulario(new VisaoGeral());
            }
            else
                MessageBox.Show("Aconteceu um erro ao cadastrar o novo cliente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        /// <summary>
        /// Altera o Cliente com as informações preenchidas nas etapas de cadastro
        /// </summary>
        private async Task AlterarClienteAsync()
        {
            try
            {
                await new BoCliente().AtualizarAsync(cliente);
                MessageBox.Show("Cliente alterado com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cadastroFinalizado = true;
                if (_funcaoFormulario == FuncaoFormulario.Alterar)
                    this.Close();
                else
                    AbrirFormulario(new VisaoGeral());
            }
            catch (Exception erro)
            {
                MessageBox.Show("Aconteceu um erro ao alterar o cliente. Mensagem original: " + erro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        /// Abre um Formulário na Tela Principal e fecha este formulário
        /// </summary>
        /// <param name="pFormulario">Formulário a ser aberto</param>
        private void AbrirFormulario(Form pFormulario)
        {
            pFormulario.TopLevel = false;
            pFormulario.FormBorderStyle = FormBorderStyle.None;
            pFormulario.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(pFormulario);
            this.Parent.Tag = pFormulario;
            pFormulario.BringToFront();
            pFormulario.Show();
            this.Close();
        }
        #endregion

        #region Eventos
        private void chkMaisNumeros_CheckedChanged(object sender, EventArgs e)
        {
            btnAddNumero.Visible = btnAddNumero.Enabled = chkMaisNumeros.Checked;
            lstTelefones.Visible = chkMaisNumeros.Checked;
        }

        private async void btnCadastrarCliente_Click(object sender, EventArgs e)
        {
            if(EtapaAtual == EtapaDeCadastro.Foto)
            {
                if (this._funcaoFormulario == FuncaoFormulario.Cadastrar)
                {
                    await CadastrarClienteAsync();
                }
                else if (this._funcaoFormulario == FuncaoFormulario.Alterar)
                {
                    await AlterarClienteAsync();
                }
            }
            else
                MudarParaEtapa((EtapaDeCadastro) ((int)EtapaAtual + 1));
            
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

        private async void CadCliente_Load(object sender, EventArgs e)
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
                    if(!await new BoCliente().VerificaCPFExistenteAsync(cpfInformado) || cpfInformado == cliente.CPF)
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
            MudarParaEtapa(EtapaDeCadastro.InformacoesPessoais);
        }

        private void picEtapa2_Click(object sender, EventArgs e)
        {
            MudarParaEtapa(EtapaDeCadastro.InformacoesDeContato);
        }

        private void picEtapa3_Click(object sender, EventArgs e)
        {
            MudarParaEtapa(EtapaDeCadastro.Foto);
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
