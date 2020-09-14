namespace KadoshModas.UI
{
    partial class CadCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.chkMaisNumeros = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbSexoFeminino = new System.Windows.Forms.RadioButton();
            this.rdbSexoMasculino = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.pcbLoaderCPF = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstTelefones = new System.Windows.Forms.ListBox();
            this.btnAddNumero = new FontAwesome.Sharp.IconButton();
            this.txtFalarCom = new System.Windows.Forms.TextBox();
            this.lblFalarCom = new System.Windows.Forms.Label();
            this.cboTipoTelefone = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCep = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCidade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoverFoto = new FontAwesome.Sharp.IconButton();
            this.btnEscolherFotoDoPc = new FontAwesome.Sharp.IconButton();
            this.btnTirarFoto = new FontAwesome.Sharp.IconButton();
            this.picFotoCliente = new System.Windows.Forms.PictureBox();
            this.pnlCadCliEtapa1 = new System.Windows.Forms.Panel();
            this.pnlCadCliEtapa2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picEtapa3 = new FontAwesome.Sharp.IconPictureBox();
            this.picEtapa2 = new FontAwesome.Sharp.IconPictureBox();
            this.picEtapa1 = new FontAwesome.Sharp.IconPictureBox();
            this.pnlCadCliEtapa3 = new System.Windows.Forms.Panel();
            this.pnlConteudo = new System.Windows.Forms.Panel();
            this.btnCadastrarCliente = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoaderCPF)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).BeginInit();
            this.pnlCadCliEtapa1.SuspendLayout();
            this.pnlCadCliEtapa2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa1)).BeginInit();
            this.pnlCadCliEtapa3.SuspendLayout();
            this.pnlConteudo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtNomeCliente
            // 
            resources.ApplyResources(this.txtNomeCliente, "txtNomeCliente");
            this.txtNomeCliente.Name = "txtNomeCliente";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.txtEmail.Name = "txtEmail";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtCpf
            // 
            resources.ApplyResources(this.txtCpf, "txtCpf");
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Click += new System.EventHandler(this.txtCpf_Click);
            this.txtCpf.TextChanged += new System.EventHandler(this.txtCpf_TextChanged);
            this.txtCpf.Enter += new System.EventHandler(this.txtCpf_Enter);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtTelefone
            // 
            resources.ApplyResources(this.txtTelefone, "txtTelefone");
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Click += new System.EventHandler(this.txtTelefone_Click);
            this.txtTelefone.Enter += new System.EventHandler(this.txtTelefone_Enter);
            // 
            // chkMaisNumeros
            // 
            resources.ApplyResources(this.chkMaisNumeros, "chkMaisNumeros");
            this.chkMaisNumeros.Name = "chkMaisNumeros";
            this.chkMaisNumeros.UseVisualStyleBackColor = true;
            this.chkMaisNumeros.CheckedChanged += new System.EventHandler(this.chkMaisNumeros_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.rdbSexoFeminino);
            this.groupBox1.Controls.Add(this.rdbSexoMasculino);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.pcbLoaderCPF);
            this.groupBox1.Controls.Add(this.txtNomeCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCpf);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // rdbSexoFeminino
            // 
            resources.ApplyResources(this.rdbSexoFeminino, "rdbSexoFeminino");
            this.rdbSexoFeminino.Checked = true;
            this.rdbSexoFeminino.Name = "rdbSexoFeminino";
            this.rdbSexoFeminino.TabStop = true;
            this.rdbSexoFeminino.UseVisualStyleBackColor = true;
            // 
            // rdbSexoMasculino
            // 
            resources.ApplyResources(this.rdbSexoMasculino, "rdbSexoMasculino");
            this.rdbSexoMasculino.Name = "rdbSexoMasculino";
            this.rdbSexoMasculino.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // pcbLoaderCPF
            // 
            resources.ApplyResources(this.pcbLoaderCPF, "pcbLoaderCPF");
            this.pcbLoaderCPF.Image = global::KadoshModas.Properties.Resources.transparent_loading_gif;
            this.pcbLoaderCPF.Name = "pcbLoaderCPF";
            this.pcbLoaderCPF.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.lstTelefones);
            this.groupBox2.Controls.Add(this.btnAddNumero);
            this.groupBox2.Controls.Add(this.txtFalarCom);
            this.groupBox2.Controls.Add(this.lblFalarCom);
            this.groupBox2.Controls.Add(this.cboTipoTelefone);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkMaisNumeros);
            this.groupBox2.Controls.Add(this.txtTelefone);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lstTelefones
            // 
            resources.ApplyResources(this.lstTelefones, "lstTelefones");
            this.lstTelefones.FormattingEnabled = true;
            this.lstTelefones.Name = "lstTelefones";
            // 
            // btnAddNumero
            // 
            resources.ApplyResources(this.btnAddNumero, "btnAddNumero");
            this.btnAddNumero.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNumero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNumero.FlatAppearance.BorderSize = 0;
            this.btnAddNumero.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAddNumero.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAddNumero.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.btnAddNumero.IconColor = System.Drawing.Color.LimeGreen;
            this.btnAddNumero.IconSize = 40;
            this.btnAddNumero.Name = "btnAddNumero";
            this.btnAddNumero.Rotation = 0D;
            this.btnAddNumero.UseVisualStyleBackColor = false;
            this.btnAddNumero.Click += new System.EventHandler(this.btnAddNumero_Click);
            // 
            // txtFalarCom
            // 
            resources.ApplyResources(this.txtFalarCom, "txtFalarCom");
            this.txtFalarCom.Name = "txtFalarCom";
            // 
            // lblFalarCom
            // 
            resources.ApplyResources(this.lblFalarCom, "lblFalarCom");
            this.lblFalarCom.Name = "lblFalarCom";
            // 
            // cboTipoTelefone
            // 
            resources.ApplyResources(this.cboTipoTelefone, "cboTipoTelefone");
            this.cboTipoTelefone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoTelefone.FormattingEnabled = true;
            this.cboTipoTelefone.Name = "cboTipoTelefone";
            this.cboTipoTelefone.SelectedIndexChanged += new System.EventHandler(this.cboTipoTelefone_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.txtBairro);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txtComplemento);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtCep);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cboCidade);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.cboEstado);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNumero);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtRua);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txtBairro
            // 
            resources.ApplyResources(this.txtBairro, "txtBairro");
            this.txtBairro.Name = "txtBairro";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // txtComplemento
            // 
            resources.ApplyResources(this.txtComplemento, "txtComplemento");
            this.txtComplemento.Name = "txtComplemento";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtCep
            // 
            resources.ApplyResources(this.txtCep, "txtCep");
            this.txtCep.Name = "txtCep";
            this.txtCep.Click += new System.EventHandler(this.txtCep_Click);
            this.txtCep.Enter += new System.EventHandler(this.txtCep_Enter);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // cboCidade
            // 
            resources.ApplyResources(this.cboCidade, "cboCidade");
            this.cboCidade.FormattingEnabled = true;
            this.cboCidade.Name = "cboCidade";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cboEstado
            // 
            resources.ApplyResources(this.cboEstado, "cboEstado");
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtNumero
            // 
            resources.ApplyResources(this.txtNumero, "txtNumero");
            this.txtNumero.Name = "txtNumero";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtRua
            // 
            resources.ApplyResources(this.txtRua, "txtRua");
            this.txtRua.Name = "txtRua";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.btnRemoverFoto);
            this.panel2.Controls.Add(this.btnEscolherFotoDoPc);
            this.panel2.Controls.Add(this.btnTirarFoto);
            this.panel2.Controls.Add(this.picFotoCliente);
            this.panel2.Name = "panel2";
            // 
            // btnRemoverFoto
            // 
            this.btnRemoverFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoverFoto.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnRemoverFoto, "btnRemoverFoto");
            this.btnRemoverFoto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRemoverFoto.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnRemoverFoto.IconColor = System.Drawing.Color.DarkRed;
            this.btnRemoverFoto.IconSize = 30;
            this.btnRemoverFoto.Name = "btnRemoverFoto";
            this.btnRemoverFoto.Rotation = 0D;
            this.btnRemoverFoto.UseVisualStyleBackColor = true;
            this.btnRemoverFoto.Click += new System.EventHandler(this.btnRemoverFoto_Click);
            // 
            // btnEscolherFotoDoPc
            // 
            this.btnEscolherFotoDoPc.BackColor = System.Drawing.Color.DimGray;
            this.btnEscolherFotoDoPc.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnEscolherFotoDoPc, "btnEscolherFotoDoPc");
            this.btnEscolherFotoDoPc.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEscolherFotoDoPc.ForeColor = System.Drawing.Color.White;
            this.btnEscolherFotoDoPc.IconChar = FontAwesome.Sharp.IconChar.Laptop;
            this.btnEscolherFotoDoPc.IconColor = System.Drawing.Color.White;
            this.btnEscolherFotoDoPc.IconSize = 30;
            this.btnEscolherFotoDoPc.Name = "btnEscolherFotoDoPc";
            this.btnEscolherFotoDoPc.Rotation = 0D;
            this.btnEscolherFotoDoPc.UseVisualStyleBackColor = false;
            this.btnEscolherFotoDoPc.Click += new System.EventHandler(this.btnEscolherFotoDoPc_Click);
            // 
            // btnTirarFoto
            // 
            this.btnTirarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTirarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTirarFoto.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnTirarFoto, "btnTirarFoto");
            this.btnTirarFoto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTirarFoto.ForeColor = System.Drawing.Color.White;
            this.btnTirarFoto.IconChar = FontAwesome.Sharp.IconChar.Camera;
            this.btnTirarFoto.IconColor = System.Drawing.Color.White;
            this.btnTirarFoto.IconSize = 30;
            this.btnTirarFoto.Name = "btnTirarFoto";
            this.btnTirarFoto.Rotation = 0D;
            this.btnTirarFoto.UseVisualStyleBackColor = false;
            this.btnTirarFoto.Click += new System.EventHandler(this.btnTirarFoto_Click);
            // 
            // picFotoCliente
            // 
            this.picFotoCliente.Image = global::KadoshModas.Properties.Resources.usuario_perfil_padrao;
            resources.ApplyResources(this.picFotoCliente, "picFotoCliente");
            this.picFotoCliente.Name = "picFotoCliente";
            this.picFotoCliente.TabStop = false;
            // 
            // pnlCadCliEtapa1
            // 
            resources.ApplyResources(this.pnlCadCliEtapa1, "pnlCadCliEtapa1");
            this.pnlCadCliEtapa1.Controls.Add(this.groupBox1);
            this.pnlCadCliEtapa1.Controls.Add(this.groupBox3);
            this.pnlCadCliEtapa1.Name = "pnlCadCliEtapa1";
            // 
            // pnlCadCliEtapa2
            // 
            resources.ApplyResources(this.pnlCadCliEtapa2, "pnlCadCliEtapa2");
            this.pnlCadCliEtapa2.Controls.Add(this.groupBox2);
            this.pnlCadCliEtapa2.Name = "pnlCadCliEtapa2";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.picEtapa3);
            this.panel1.Controls.Add(this.picEtapa2);
            this.panel1.Controls.Add(this.picEtapa1);
            this.panel1.Name = "panel1";
            // 
            // picEtapa3
            // 
            resources.ApplyResources(this.picEtapa3, "picEtapa3");
            this.picEtapa3.BackColor = System.Drawing.Color.Transparent;
            this.picEtapa3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEtapa3.ForeColor = System.Drawing.Color.Black;
            this.picEtapa3.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.picEtapa3.IconColor = System.Drawing.Color.Black;
            this.picEtapa3.IconSize = 20;
            this.picEtapa3.Name = "picEtapa3";
            this.picEtapa3.TabStop = false;
            this.picEtapa3.Click += new System.EventHandler(this.picEtapa3_Click);
            // 
            // picEtapa2
            // 
            resources.ApplyResources(this.picEtapa2, "picEtapa2");
            this.picEtapa2.BackColor = System.Drawing.Color.Transparent;
            this.picEtapa2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEtapa2.ForeColor = System.Drawing.Color.Black;
            this.picEtapa2.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.picEtapa2.IconColor = System.Drawing.Color.Black;
            this.picEtapa2.IconSize = 20;
            this.picEtapa2.Name = "picEtapa2";
            this.picEtapa2.TabStop = false;
            this.picEtapa2.Click += new System.EventHandler(this.picEtapa2_Click);
            // 
            // picEtapa1
            // 
            resources.ApplyResources(this.picEtapa1, "picEtapa1");
            this.picEtapa1.BackColor = System.Drawing.Color.Transparent;
            this.picEtapa1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEtapa1.ForeColor = System.Drawing.Color.Black;
            this.picEtapa1.IconChar = FontAwesome.Sharp.IconChar.DotCircle;
            this.picEtapa1.IconColor = System.Drawing.Color.Black;
            this.picEtapa1.IconSize = 20;
            this.picEtapa1.Name = "picEtapa1";
            this.picEtapa1.TabStop = false;
            this.picEtapa1.Click += new System.EventHandler(this.picEtapa1_Click);
            // 
            // pnlCadCliEtapa3
            // 
            resources.ApplyResources(this.pnlCadCliEtapa3, "pnlCadCliEtapa3");
            this.pnlCadCliEtapa3.Controls.Add(this.panel2);
            this.pnlCadCliEtapa3.Name = "pnlCadCliEtapa3";
            // 
            // pnlConteudo
            // 
            resources.ApplyResources(this.pnlConteudo, "pnlConteudo");
            this.pnlConteudo.BackColor = System.Drawing.Color.Transparent;
            this.pnlConteudo.Controls.Add(this.panel1);
            this.pnlConteudo.Controls.Add(this.btnCadastrarCliente);
            this.pnlConteudo.Controls.Add(this.btnCancelar);
            this.pnlConteudo.Name = "pnlConteudo";
            // 
            // btnCadastrarCliente
            // 
            resources.ApplyResources(this.btnCadastrarCliente, "btnCadastrarCliente");
            this.btnCadastrarCliente.BackColor = System.Drawing.Color.Black;
            this.btnCadastrarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarCliente.FlatAppearance.BorderSize = 0;
            this.btnCadastrarCliente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCadastrarCliente.ForeColor = System.Drawing.Color.White;
            this.btnCadastrarCliente.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleRight;
            this.btnCadastrarCliente.IconColor = System.Drawing.Color.White;
            this.btnCadastrarCliente.IconSize = 24;
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Rotation = 0D;
            this.btnCadastrarCliente.UseVisualStyleBackColor = false;
            this.btnCadastrarCliente.Click += new System.EventHandler(this.btnCadastrarCliente_Click);
            // 
            // btnCancelar
            // 
            resources.ApplyResources(this.btnCancelar, "btnCancelar");
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCancelar.IconColor = System.Drawing.Color.DarkRed;
            this.btnCancelar.IconSize = 24;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Rotation = 0D;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // openFileDialogFoto
            // 
            this.openFileDialogFoto.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialogFoto, "openFileDialogFoto");
            // 
            // CadCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.pnlConteudo);
            this.Controls.Add(this.pnlCadCliEtapa3);
            this.Controls.Add(this.pnlCadCliEtapa2);
            this.Controls.Add(this.pnlCadCliEtapa1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadCliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CadCliente_FormClosing);
            this.Load += new System.EventHandler(this.CadCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLoaderCPF)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).EndInit();
            this.pnlCadCliEtapa1.ResumeLayout(false);
            this.pnlCadCliEtapa2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEtapa1)).EndInit();
            this.pnlCadCliEtapa3.ResumeLayout(false);
            this.pnlConteudo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.CheckBox chkMaisNumeros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cboCidade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtCep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTipoTelefone;
        private System.Windows.Forms.TextBox txtFalarCom;
        private System.Windows.Forms.Label lblFalarCom;
        private System.Windows.Forms.PictureBox pcbLoaderCPF;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picFotoCliente;
        private System.Windows.Forms.RadioButton rdbSexoFeminino;
        private System.Windows.Forms.RadioButton rdbSexoMasculino;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlCadCliEtapa1;
        private FontAwesome.Sharp.IconButton btnAddNumero;
        private System.Windows.Forms.Panel pnlCadCliEtapa2;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconPictureBox picEtapa1;
        private System.Windows.Forms.Panel pnlCadCliEtapa3;
        private FontAwesome.Sharp.IconPictureBox picEtapa3;
        private FontAwesome.Sharp.IconPictureBox picEtapa2;
        private FontAwesome.Sharp.IconButton btnCadastrarCliente;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.Panel pnlConteudo;
        private System.Windows.Forms.ListBox lstTelefones;
        private FontAwesome.Sharp.IconButton btnTirarFoto;
        private FontAwesome.Sharp.IconButton btnEscolherFotoDoPc;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private FontAwesome.Sharp.IconButton btnRemoverFoto;
    }
}