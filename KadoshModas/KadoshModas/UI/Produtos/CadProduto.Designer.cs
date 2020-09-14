namespace KadoshModas.UI
{
    partial class CadProduto
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGerarCodigo = new FontAwesome.Sharp.IconButton();
            this.txtCodigoDeBarras = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDefinirFornecedores = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.lblEstoqueRotulo = new System.Windows.Forms.Label();
            this.txtTamanho = new System.Windows.Forms.TextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecoUnidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picCodBarras = new FontAwesome.Sharp.IconPictureBox();
            this.btnRemoverFoto = new FontAwesome.Sharp.IconButton();
            this.btnEscolherFoto = new FontAwesome.Sharp.IconButton();
            this.btnTirarFoto = new FontAwesome.Sharp.IconButton();
            this.btnDesativarProduto = new FontAwesome.Sharp.IconButton();
            this.picFotoProduto = new System.Windows.Forms.PictureBox();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.tipCadProduto = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCodBarras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGerarCodigo);
            this.panel1.Controls.Add(this.txtCodigoDeBarras);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnDefinirFornecedores);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtEstoque);
            this.panel1.Controls.Add(this.lblEstoqueRotulo);
            this.panel1.Controls.Add(this.txtTamanho);
            this.panel1.Controls.Add(this.txtCor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.cboMarca);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboCategoria);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrecoUnidade);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNomeProduto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(268, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 622);
            this.panel1.TabIndex = 0;
            // 
            // btnGerarCodigo
            // 
            this.btnGerarCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGerarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarCodigo.FlatAppearance.BorderSize = 0;
            this.btnGerarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarCodigo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnGerarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnGerarCodigo.IconChar = FontAwesome.Sharp.IconChar.Barcode;
            this.btnGerarCodigo.IconColor = System.Drawing.Color.White;
            this.btnGerarCodigo.IconSize = 35;
            this.btnGerarCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnGerarCodigo.Location = new System.Drawing.Point(576, 53);
            this.btnGerarCodigo.Name = "btnGerarCodigo";
            this.btnGerarCodigo.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnGerarCodigo.Rotation = 0D;
            this.btnGerarCodigo.Size = new System.Drawing.Size(50, 30);
            this.btnGerarCodigo.TabIndex = 20;
            this.tipCadProduto.SetToolTip(this.btnGerarCodigo, "Gerar código de barras");
            this.btnGerarCodigo.UseVisualStyleBackColor = false;
            this.btnGerarCodigo.Click += new System.EventHandler(this.btnGerarCodigo_Click);
            // 
            // txtCodigoDeBarras
            // 
            this.txtCodigoDeBarras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodigoDeBarras.Location = new System.Drawing.Point(155, 55);
            this.txtCodigoDeBarras.MaxLength = 13;
            this.txtCodigoDeBarras.Name = "txtCodigoDeBarras";
            this.txtCodigoDeBarras.Size = new System.Drawing.Size(415, 28);
            this.txtCodigoDeBarras.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 21);
            this.label10.TabIndex = 19;
            this.label10.Text = "Código de Barras:";
            // 
            // btnDefinirFornecedores
            // 
            this.btnDefinirFornecedores.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefinirFornecedores.BackColor = System.Drawing.Color.DarkRed;
            this.btnDefinirFornecedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefinirFornecedores.FlatAppearance.BorderSize = 0;
            this.btnDefinirFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirFornecedores.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDefinirFornecedores.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinirFornecedores.ForeColor = System.Drawing.Color.White;
            this.btnDefinirFornecedores.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnDefinirFornecedores.IconColor = System.Drawing.Color.LightPink;
            this.btnDefinirFornecedores.IconSize = 24;
            this.btnDefinirFornecedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefinirFornecedores.Location = new System.Drawing.Point(159, 458);
            this.btnDefinirFornecedores.Name = "btnDefinirFornecedores";
            this.btnDefinirFornecedores.Rotation = 0D;
            this.btnDefinirFornecedores.Size = new System.Drawing.Size(467, 29);
            this.btnDefinirFornecedores.TabIndex = 9;
            this.btnDefinirFornecedores.Text = "Não definido";
            this.btnDefinirFornecedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDefinirFornecedores.UseVisualStyleBackColor = false;
            this.btnDefinirFornecedores.Visible = false;
            this.btnDefinirFornecedores.Click += new System.EventHandler(this.btnDefinirFornecedores_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(46, 462);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fornecedores:";
            this.label9.Visible = false;
            // 
            // txtEstoque
            // 
            this.txtEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoque.Location = new System.Drawing.Point(155, 403);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(471, 28);
            this.txtEstoque.TabIndex = 8;
            this.txtEstoque.Visible = false;
            // 
            // lblEstoqueRotulo
            // 
            this.lblEstoqueRotulo.AutoSize = true;
            this.lblEstoqueRotulo.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstoqueRotulo.Location = new System.Drawing.Point(81, 406);
            this.lblEstoqueRotulo.Name = "lblEstoqueRotulo";
            this.lblEstoqueRotulo.Size = new System.Drawing.Size(68, 21);
            this.lblEstoqueRotulo.TabIndex = 16;
            this.lblEstoqueRotulo.Text = "Estoque:";
            this.lblEstoqueRotulo.Visible = false;
            // 
            // txtTamanho
            // 
            this.txtTamanho.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTamanho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTamanho.Location = new System.Drawing.Point(155, 310);
            this.txtTamanho.Name = "txtTamanho";
            this.txtTamanho.Size = new System.Drawing.Size(471, 28);
            this.txtTamanho.TabIndex = 6;
            this.txtTamanho.Visible = false;
            // 
            // txtCor
            // 
            this.txtCor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCor.Location = new System.Drawing.Point(155, 360);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(471, 28);
            this.txtCor.TabIndex = 7;
            this.txtCor.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(111, 359);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cor:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tamanho/Número:";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Atributos";
            this.label5.Visible = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.Location = new System.Drawing.Point(422, 530);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(204, 54);
            this.btnCadastrar.TabIndex = 10;
            this.btnCadastrar.Text = "Cadastrar produto";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // cboMarca
            // 
            this.cboMarca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(155, 146);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(471, 29);
            this.cboMarca.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Marca: ";
            // 
            // cboCategoria
            // 
            this.cboCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(155, 189);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(471, 29);
            this.cboCategoria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categoria: ";
            // 
            // txtPrecoUnidade
            // 
            this.txtPrecoUnidade.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecoUnidade.Location = new System.Drawing.Point(155, 101);
            this.txtPrecoUnidade.Name = "txtPrecoUnidade";
            this.txtPrecoUnidade.Size = new System.Drawing.Size(471, 28);
            this.txtPrecoUnidade.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Preço por unidade:";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeProduto.Location = new System.Drawing.Point(155, 12);
            this.txtNomeProduto.MaxLength = 50;
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(471, 28);
            this.txtNomeProduto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do produto:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.picCodBarras);
            this.panel2.Controls.Add(this.btnRemoverFoto);
            this.panel2.Controls.Add(this.btnEscolherFoto);
            this.panel2.Controls.Add(this.btnTirarFoto);
            this.panel2.Controls.Add(this.btnDesativarProduto);
            this.panel2.Controls.Add(this.picFotoProduto);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 622);
            this.panel2.TabIndex = 8;
            // 
            // picCodBarras
            // 
            this.picCodBarras.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCodBarras.BackColor = System.Drawing.SystemColors.ControlLight;
            this.picCodBarras.ForeColor = System.Drawing.SystemColors.ControlText;
            this.picCodBarras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.picCodBarras.IconColor = System.Drawing.SystemColors.ControlText;
            this.picCodBarras.IconSize = 115;
            this.picCodBarras.Location = new System.Drawing.Point(12, 462);
            this.picCodBarras.Name = "picCodBarras";
            this.picCodBarras.Size = new System.Drawing.Size(238, 115);
            this.picCodBarras.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCodBarras.TabIndex = 21;
            this.picCodBarras.TabStop = false;
            // 
            // btnRemoverFoto
            // 
            this.btnRemoverFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoverFoto.FlatAppearance.BorderSize = 0;
            this.btnRemoverFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverFoto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRemoverFoto.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnRemoverFoto.IconColor = System.Drawing.Color.DarkRed;
            this.btnRemoverFoto.IconSize = 30;
            this.btnRemoverFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRemoverFoto.Location = new System.Drawing.Point(12, 371);
            this.btnRemoverFoto.Name = "btnRemoverFoto";
            this.btnRemoverFoto.Rotation = 0D;
            this.btnRemoverFoto.Size = new System.Drawing.Size(238, 30);
            this.btnRemoverFoto.TabIndex = 17;
            this.btnRemoverFoto.UseVisualStyleBackColor = true;
            this.btnRemoverFoto.Visible = false;
            this.btnRemoverFoto.Click += new System.EventHandler(this.btnRemoverFoto_Click);
            // 
            // btnEscolherFoto
            // 
            this.btnEscolherFoto.BackColor = System.Drawing.Color.DimGray;
            this.btnEscolherFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEscolherFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEscolherFoto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEscolherFoto.ForeColor = System.Drawing.Color.White;
            this.btnEscolherFoto.IconChar = FontAwesome.Sharp.IconChar.Laptop;
            this.btnEscolherFoto.IconColor = System.Drawing.Color.White;
            this.btnEscolherFoto.IconSize = 30;
            this.btnEscolherFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEscolherFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEscolherFoto.Location = new System.Drawing.Point(12, 335);
            this.btnEscolherFoto.Name = "btnEscolherFoto";
            this.btnEscolherFoto.Rotation = 0D;
            this.btnEscolherFoto.Size = new System.Drawing.Size(238, 30);
            this.btnEscolherFoto.TabIndex = 16;
            this.btnEscolherFoto.Text = "Escolher do computador";
            this.btnEscolherFoto.UseVisualStyleBackColor = false;
            this.btnEscolherFoto.Click += new System.EventHandler(this.btnEscolherFoto_Click);
            // 
            // btnTirarFoto
            // 
            this.btnTirarFoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTirarFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTirarFoto.FlatAppearance.BorderSize = 0;
            this.btnTirarFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTirarFoto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnTirarFoto.ForeColor = System.Drawing.Color.White;
            this.btnTirarFoto.IconChar = FontAwesome.Sharp.IconChar.Camera;
            this.btnTirarFoto.IconColor = System.Drawing.Color.White;
            this.btnTirarFoto.IconSize = 30;
            this.btnTirarFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTirarFoto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnTirarFoto.Location = new System.Drawing.Point(12, 299);
            this.btnTirarFoto.Name = "btnTirarFoto";
            this.btnTirarFoto.Rotation = 0D;
            this.btnTirarFoto.Size = new System.Drawing.Size(238, 30);
            this.btnTirarFoto.TabIndex = 15;
            this.btnTirarFoto.Text = "Tirar foto";
            this.btnTirarFoto.UseVisualStyleBackColor = false;
            this.btnTirarFoto.Visible = false;
            // 
            // btnDesativarProduto
            // 
            this.btnDesativarProduto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDesativarProduto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnDesativarProduto.IconColor = System.Drawing.Color.Black;
            this.btnDesativarProduto.IconSize = 16;
            this.btnDesativarProduto.Location = new System.Drawing.Point(46, 407);
            this.btnDesativarProduto.Name = "btnDesativarProduto";
            this.btnDesativarProduto.Rotation = 0D;
            this.btnDesativarProduto.Size = new System.Drawing.Size(173, 40);
            this.btnDesativarProduto.TabIndex = 14;
            this.btnDesativarProduto.Text = "Desativar Produto";
            this.btnDesativarProduto.UseVisualStyleBackColor = true;
            this.btnDesativarProduto.Visible = false;
            this.btnDesativarProduto.Click += new System.EventHandler(this.btnDesativarProduto_Click);
            // 
            // picFotoProduto
            // 
            this.picFotoProduto.Image = global::KadoshModas.Properties.Resources.icone_produto;
            this.picFotoProduto.Location = new System.Drawing.Point(12, 12);
            this.picFotoProduto.Name = "picFotoProduto";
            this.picFotoProduto.Size = new System.Drawing.Size(238, 268);
            this.picFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFotoProduto.TabIndex = 9;
            this.picFotoProduto.TabStop = false;
            // 
            // openFileDialogFoto
            // 
            this.openFileDialogFoto.FileName = "openFileDialog1";
            this.openFileDialogFoto.Filter = "Arquivos de Imagem(*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gi" +
    "f; *.bmp";
            // 
            // CadProduto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "CadProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CadProduto";
            this.Load += new System.EventHandler(this.CadProduto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCodBarras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoProduto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecoUnidade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picFotoProduto;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTamanho;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label lblEstoqueRotulo;
        private FontAwesome.Sharp.IconButton btnDefinirFornecedores;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoDeBarras;
        private System.Windows.Forms.Label label10;
        private FontAwesome.Sharp.IconButton btnDesativarProduto;
        private FontAwesome.Sharp.IconButton btnRemoverFoto;
        private FontAwesome.Sharp.IconButton btnEscolherFoto;
        private FontAwesome.Sharp.IconButton btnTirarFoto;
        private FontAwesome.Sharp.IconButton btnGerarCodigo;
        private System.Windows.Forms.ToolTip tipCadProduto;
        private FontAwesome.Sharp.IconPictureBox picCodBarras;
    }
}