namespace KadoshModas.UI
{
    partial class FichaCliente
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
            this.tbcFichaCliente = new System.Windows.Forms.TabControl();
            this.tbpCompras = new System.Windows.Forms.TabPage();
            this.btnCadNovaConta = new FontAwesome.Sharp.IconButton();
            this.pnlCompras = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.tbpInformacoesPessoais = new System.Windows.Forms.TabPage();
            this.txtSexo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRua = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCEP = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlTelefones = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnApagarCliente = new FontAwesome.Sharp.IconButton();
            this.btnEditarCliente = new FontAwesome.Sharp.IconButton();
            this.picFotoCliente = new System.Windows.Forms.PictureBox();
            this.tbcFichaCliente.SuspendLayout();
            this.tbpCompras.SuspendLayout();
            this.pnlCompras.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.tbpInformacoesPessoais.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcFichaCliente
            // 
            this.tbcFichaCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcFichaCliente.Controls.Add(this.tbpCompras);
            this.tbcFichaCliente.Controls.Add(this.tbpInformacoesPessoais);
            this.tbcFichaCliente.Location = new System.Drawing.Point(186, 65);
            this.tbcFichaCliente.Name = "tbcFichaCliente";
            this.tbcFichaCliente.SelectedIndex = 0;
            this.tbcFichaCliente.Size = new System.Drawing.Size(731, 557);
            this.tbcFichaCliente.TabIndex = 19;
            this.tbcFichaCliente.SelectedIndexChanged += new System.EventHandler(this.tbcFichaCliente_SelectedIndexChanged);
            // 
            // tbpCompras
            // 
            this.tbpCompras.Controls.Add(this.btnCadNovaConta);
            this.tbpCompras.Controls.Add(this.pnlCompras);
            this.tbpCompras.Location = new System.Drawing.Point(4, 25);
            this.tbpCompras.Name = "tbpCompras";
            this.tbpCompras.Padding = new System.Windows.Forms.Padding(3);
            this.tbpCompras.Size = new System.Drawing.Size(723, 528);
            this.tbpCompras.TabIndex = 1;
            this.tbpCompras.Text = "Compras";
            // 
            // btnCadNovaConta
            // 
            this.btnCadNovaConta.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCadNovaConta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadNovaConta.FlatAppearance.BorderSize = 0;
            this.btnCadNovaConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadNovaConta.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCadNovaConta.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadNovaConta.ForeColor = System.Drawing.Color.Black;
            this.btnCadNovaConta.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnCadNovaConta.IconColor = System.Drawing.Color.Black;
            this.btnCadNovaConta.IconSize = 16;
            this.btnCadNovaConta.Location = new System.Drawing.Point(6, 11);
            this.btnCadNovaConta.Name = "btnCadNovaConta";
            this.btnCadNovaConta.Rotation = 0D;
            this.btnCadNovaConta.Size = new System.Drawing.Size(245, 30);
            this.btnCadNovaConta.TabIndex = 3;
            this.btnCadNovaConta.Text = "Adicionar conta na ficha";
            this.btnCadNovaConta.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCadNovaConta.UseVisualStyleBackColor = false;
            // 
            // pnlCompras
            // 
            this.pnlCompras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCompras.AutoScroll = true;
            this.pnlCompras.Controls.Add(this.panel3);
            this.pnlCompras.Location = new System.Drawing.Point(3, 47);
            this.pnlCompras.Name = "pnlCompras";
            this.pnlCompras.Size = new System.Drawing.Size(713, 467);
            this.pnlCompras.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.iconPictureBox1);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(696, 461);
            this.panel3.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(313, 250);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 87);
            this.label10.TabIndex = 2;
            this.label10.Text = "Parece que este cliente ainda não realizou nenhuma compra na loja.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(313, 219);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 31);
            this.label9.TabIndex = 1;
            this.label9.Text = "Ops...";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox1.IconSize = 130;
            this.iconPictureBox1.Location = new System.Drawing.Point(178, 212);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(130, 130);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // tbpInformacoesPessoais
            // 
            this.tbpInformacoesPessoais.Controls.Add(this.txtSexo);
            this.tbpInformacoesPessoais.Controls.Add(this.groupBox2);
            this.tbpInformacoesPessoais.Controls.Add(this.groupBox1);
            this.tbpInformacoesPessoais.Controls.Add(this.label1);
            this.tbpInformacoesPessoais.Controls.Add(this.txtCPF);
            this.tbpInformacoesPessoais.Controls.Add(this.label2);
            this.tbpInformacoesPessoais.Location = new System.Drawing.Point(4, 25);
            this.tbpInformacoesPessoais.Name = "tbpInformacoesPessoais";
            this.tbpInformacoesPessoais.Padding = new System.Windows.Forms.Padding(3);
            this.tbpInformacoesPessoais.Size = new System.Drawing.Size(723, 528);
            this.tbpInformacoesPessoais.TabIndex = 0;
            this.tbpInformacoesPessoais.Text = "Informações Pessoais";
            this.tbpInformacoesPessoais.UseVisualStyleBackColor = true;
            // 
            // txtSexo
            // 
            this.txtSexo.BackColor = System.Drawing.Color.White;
            this.txtSexo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSexo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtSexo.Location = new System.Drawing.Point(261, 44);
            this.txtSexo.Name = "txtSexo";
            this.txtSexo.ReadOnly = true;
            this.txtSexo.Size = new System.Drawing.Size(164, 21);
            this.txtSexo.TabIndex = 21;
            this.txtSexo.Text = "Feminino";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCidade);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtRua);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCEP);
            this.groupBox2.Controls.Add(this.txtBairro);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(11, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 134);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.White;
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCidade.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtCidade.Location = new System.Drawing.Point(84, 76);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.ReadOnly = true;
            this.txtCidade.Size = new System.Drawing.Size(162, 21);
            this.txtCidade.TabIndex = 18;
            this.txtCidade.Text = "Bairro do Endereço";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rua:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(497, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Número:";
            // 
            // txtRua
            // 
            this.txtRua.BackColor = System.Drawing.Color.White;
            this.txtRua.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRua.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtRua.Location = new System.Drawing.Point(63, 20);
            this.txtRua.Name = "txtRua";
            this.txtRua.ReadOnly = true;
            this.txtRua.Size = new System.Drawing.Size(177, 21);
            this.txtRua.TabIndex = 10;
            this.txtRua.Text = "Rua do Endereço";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 21);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cidade:";
            // 
            // txtNumero
            // 
            this.txtNumero.BackColor = System.Drawing.Color.White;
            this.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtNumero.Location = new System.Drawing.Point(574, 20);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(125, 21);
            this.txtNumero.TabIndex = 12;
            this.txtNumero.Text = "Não cadastrado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bairro:";
            // 
            // txtCEP
            // 
            this.txtCEP.BackColor = System.Drawing.Color.White;
            this.txtCEP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCEP.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtCEP.Location = new System.Drawing.Point(543, 47);
            this.txtCEP.Name = "txtCEP";
            this.txtCEP.ReadOnly = true;
            this.txtCEP.Size = new System.Drawing.Size(122, 21);
            this.txtCEP.TabIndex = 16;
            this.txtCEP.Text = "00000-000";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBairro.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold);
            this.txtBairro.Location = new System.Drawing.Point(78, 47);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.ReadOnly = true;
            this.txtBairro.Size = new System.Drawing.Size(162, 21);
            this.txtBairro.TabIndex = 14;
            this.txtBairro.Text = "Bairro do Endereço";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(497, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "CEP:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlTelefones);
            this.groupBox1.Location = new System.Drawing.Point(11, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 291);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Telefones";
            // 
            // pnlTelefones
            // 
            this.pnlTelefones.AutoScroll = true;
            this.pnlTelefones.Location = new System.Drawing.Point(6, 23);
            this.pnlTelefones.Name = "pnlTelefones";
            this.pnlTelefones.Size = new System.Drawing.Size(693, 245);
            this.pnlTelefones.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "CPF:";
            // 
            // txtCPF
            // 
            this.txtCPF.BackColor = System.Drawing.Color.White;
            this.txtCPF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.Location = new System.Drawing.Point(52, 44);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.ReadOnly = true;
            this.txtCPF.Size = new System.Drawing.Size(159, 21);
            this.txtCPF.TabIndex = 3;
            this.txtCPF.Text = "000.000.000-00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sexo:";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.BackColor = System.Drawing.SystemColors.Control;
            this.txtNomeCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNomeCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCliente.Location = new System.Drawing.Point(186, 12);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.ReadOnly = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(720, 35);
            this.txtNomeCliente.TabIndex = 4;
            this.txtNomeCliente.Text = "Nome do Cliente";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.btnApagarCliente);
            this.panel2.Controls.Add(this.btnEditarCliente);
            this.panel2.Controls.Add(this.picFotoCliente);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 622);
            this.panel2.TabIndex = 0;
            // 
            // btnApagarCliente
            // 
            this.btnApagarCliente.BackColor = System.Drawing.Color.Red;
            this.btnApagarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApagarCliente.FlatAppearance.BorderSize = 0;
            this.btnApagarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApagarCliente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnApagarCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApagarCliente.ForeColor = System.Drawing.Color.White;
            this.btnApagarCliente.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnApagarCliente.IconColor = System.Drawing.Color.White;
            this.btnApagarCliente.IconSize = 16;
            this.btnApagarCliente.Location = new System.Drawing.Point(12, 234);
            this.btnApagarCliente.Name = "btnApagarCliente";
            this.btnApagarCliente.Rotation = 0D;
            this.btnApagarCliente.Size = new System.Drawing.Size(153, 30);
            this.btnApagarCliente.TabIndex = 3;
            this.btnApagarCliente.Text = "Apagar Cliente";
            this.btnApagarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnApagarCliente.UseVisualStyleBackColor = false;
            this.btnApagarCliente.Click += new System.EventHandler(this.btnApagarCliente_Click);
            // 
            // btnEditarCliente
            // 
            this.btnEditarCliente.BackColor = System.Drawing.Color.Gold;
            this.btnEditarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditarCliente.FlatAppearance.BorderSize = 0;
            this.btnEditarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarCliente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEditarCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarCliente.ForeColor = System.Drawing.Color.Black;
            this.btnEditarCliente.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btnEditarCliente.IconColor = System.Drawing.Color.Black;
            this.btnEditarCliente.IconSize = 16;
            this.btnEditarCliente.Location = new System.Drawing.Point(12, 198);
            this.btnEditarCliente.Name = "btnEditarCliente";
            this.btnEditarCliente.Rotation = 0D;
            this.btnEditarCliente.Size = new System.Drawing.Size(153, 30);
            this.btnEditarCliente.TabIndex = 2;
            this.btnEditarCliente.Text = "Editar Cliente";
            this.btnEditarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEditarCliente.UseVisualStyleBackColor = false;
            this.btnEditarCliente.Click += new System.EventHandler(this.btnEditarCliente_Click);
            // 
            // picFotoCliente
            // 
            this.picFotoCliente.Image = global::KadoshModas.Properties.Resources.usuario_perfil_padrao;
            this.picFotoCliente.Location = new System.Drawing.Point(9, 12);
            this.picFotoCliente.Name = "picFotoCliente";
            this.picFotoCliente.Size = new System.Drawing.Size(156, 180);
            this.picFotoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFotoCliente.TabIndex = 1;
            this.picFotoCliente.TabStop = false;
            // 
            // FichaCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.tbcFichaCliente);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtNomeCliente);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FichaCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FichaCliente";
            this.Load += new System.EventHandler(this.FichaCliente_Load);
            this.tbcFichaCliente.ResumeLayout(false);
            this.tbpCompras.ResumeLayout(false);
            this.pnlCompras.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.tbpInformacoesPessoais.ResumeLayout(false);
            this.tbpInformacoesPessoais.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox picFotoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCEP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel pnlTelefones;
        private System.Windows.Forms.TabControl tbcFichaCliente;
        private System.Windows.Forms.TabPage tbpInformacoesPessoais;
        private System.Windows.Forms.TabPage tbpCompras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.FlowLayoutPanel pnlCompras;
        private FontAwesome.Sharp.IconButton btnEditarCliente;
        private FontAwesome.Sharp.IconButton btnApagarCliente;
        private System.Windows.Forms.TextBox txtSexo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnCadNovaConta;
    }
}