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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDefinirFornecedores = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTamanho = new System.Windows.Forms.TextBox();
            this.txtCor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoverFoto = new System.Windows.Forms.Button();
            this.btnTirarFoto = new System.Windows.Forms.Button();
            this.btnEscolherFoto = new System.Windows.Forms.Button();
            this.picFotoProduto = new System.Windows.Forms.PictureBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecoUnidade = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialogFoto = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDefinirFornecedores);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtEstoque);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTamanho);
            this.panel1.Controls.Add(this.txtCor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnCadastrar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cboMarca);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboCategoria);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtPrecoUnidade);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNomeProduto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 511);
            this.panel1.TabIndex = 0;
            // 
            // btnDefinirFornecedores
            // 
            this.btnDefinirFornecedores.BackColor = System.Drawing.Color.DarkRed;
            this.btnDefinirFornecedores.FlatAppearance.BorderSize = 0;
            this.btnDefinirFornecedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirFornecedores.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDefinirFornecedores.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinirFornecedores.ForeColor = System.Drawing.Color.White;
            this.btnDefinirFornecedores.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnDefinirFornecedores.IconColor = System.Drawing.Color.LightPink;
            this.btnDefinirFornecedores.IconSize = 24;
            this.btnDefinirFornecedores.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefinirFornecedores.Location = new System.Drawing.Point(402, 376);
            this.btnDefinirFornecedores.Name = "btnDefinirFornecedores";
            this.btnDefinirFornecedores.Rotation = 0D;
            this.btnDefinirFornecedores.Size = new System.Drawing.Size(204, 29);
            this.btnDefinirFornecedores.TabIndex = 18;
            this.btnDefinirFornecedores.Text = "Não definido";
            this.btnDefinirFornecedores.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDefinirFornecedores.UseVisualStyleBackColor = false;
            this.btnDefinirFornecedores.Click += new System.EventHandler(this.btnDefinirFornecedores_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(289, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 21);
            this.label9.TabIndex = 17;
            this.label9.Text = "Fornecedores:";
            // 
            // txtEstoque
            // 
            this.txtEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEstoque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEstoque.Location = new System.Drawing.Point(402, 333);
            this.txtEstoque.Name = "txtEstoque";
            this.txtEstoque.Size = new System.Drawing.Size(204, 28);
            this.txtEstoque.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(328, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "Estoque:";
            // 
            // txtTamanho
            // 
            this.txtTamanho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTamanho.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTamanho.Location = new System.Drawing.Point(402, 242);
            this.txtTamanho.Name = "txtTamanho";
            this.txtTamanho.Size = new System.Drawing.Size(204, 28);
            this.txtTamanho.TabIndex = 14;
            // 
            // txtCor
            // 
            this.txtCor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCor.Location = new System.Drawing.Point(402, 290);
            this.txtCor.Name = "txtCor";
            this.txtCor.Size = new System.Drawing.Size(204, 28);
            this.txtCor.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(358, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cor:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(254, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tamanho/Número:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(258, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Atributos";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCadastrar.Location = new System.Drawing.Point(402, 426);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(204, 54);
            this.btnCadastrar.TabIndex = 9;
            this.btnCadastrar.Text = "Cadastrar produto";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btnRemoverFoto);
            this.panel2.Controls.Add(this.btnTirarFoto);
            this.panel2.Controls.Add(this.btnEscolherFoto);
            this.panel2.Controls.Add(this.picFotoProduto);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 511);
            this.panel2.TabIndex = 8;
            // 
            // btnRemoverFoto
            // 
            this.btnRemoverFoto.Location = new System.Drawing.Point(73, 392);
            this.btnRemoverFoto.Name = "btnRemoverFoto";
            this.btnRemoverFoto.Size = new System.Drawing.Size(75, 28);
            this.btnRemoverFoto.TabIndex = 1;
            this.btnRemoverFoto.UseVisualStyleBackColor = true;
            this.btnRemoverFoto.Visible = false;
            this.btnRemoverFoto.Click += new System.EventHandler(this.btnRemoverFoto_Click);
            // 
            // btnTirarFoto
            // 
            this.btnTirarFoto.Location = new System.Drawing.Point(12, 344);
            this.btnTirarFoto.Name = "btnTirarFoto";
            this.btnTirarFoto.Size = new System.Drawing.Size(222, 42);
            this.btnTirarFoto.TabIndex = 10;
            this.btnTirarFoto.Text = "Tirar Foto Agora";
            this.btnTirarFoto.UseVisualStyleBackColor = true;
            // 
            // btnEscolherFoto
            // 
            this.btnEscolherFoto.Location = new System.Drawing.Point(12, 296);
            this.btnEscolherFoto.Name = "btnEscolherFoto";
            this.btnEscolherFoto.Size = new System.Drawing.Size(222, 42);
            this.btnEscolherFoto.TabIndex = 9;
            this.btnEscolherFoto.Text = "Escolher foto do Computador";
            this.btnEscolherFoto.UseVisualStyleBackColor = true;
            this.btnEscolherFoto.Click += new System.EventHandler(this.btnEscolherFoto_Click);
            // 
            // picFotoProduto
            // 
            this.picFotoProduto.Image = global::KadoshModas.Properties.Resources.icone_produto;
            this.picFotoProduto.Location = new System.Drawing.Point(12, 12);
            this.picFotoProduto.Name = "picFotoProduto";
            this.picFotoProduto.Size = new System.Drawing.Size(222, 268);
            this.picFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFotoProduto.TabIndex = 9;
            this.picFotoProduto.TabStop = false;
            // 
            // cboMarca
            // 
            this.cboMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(402, 119);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(204, 29);
            this.cboMarca.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Marca: ";
            // 
            // cboCategoria
            // 
            this.cboCategoria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(402, 162);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(204, 29);
            this.cboCategoria.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categoria: ";
            // 
            // txtPrecoUnidade
            // 
            this.txtPrecoUnidade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecoUnidade.Location = new System.Drawing.Point(402, 74);
            this.txtPrecoUnidade.Name = "txtPrecoUnidade";
            this.txtPrecoUnidade.Size = new System.Drawing.Size(204, 28);
            this.txtPrecoUnidade.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Preço por unidade:";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeProduto.Location = new System.Drawing.Point(402, 31);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(204, 28);
            this.txtNomeProduto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do produto:";
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
            this.ClientSize = new System.Drawing.Size(1367, 511);
            this.Controls.Add(this.panel1);
            this.Name = "CadProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CadProduto";
            this.Load += new System.EventHandler(this.CadProduto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnTirarFoto;
        private System.Windows.Forms.Button btnEscolherFoto;
        private System.Windows.Forms.PictureBox picFotoProduto;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTamanho;
        private System.Windows.Forms.OpenFileDialog openFileDialogFoto;
        private System.Windows.Forms.Button btnRemoverFoto;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.Label label8;
        private FontAwesome.Sharp.IconButton btnDefinirFornecedores;
        private System.Windows.Forms.Label label9;
    }
}