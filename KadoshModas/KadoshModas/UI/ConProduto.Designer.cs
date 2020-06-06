namespace KadoshModas.UI
{
    partial class ConProduto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConProduto));
            this.pnlMenuFiltros = new System.Windows.Forms.Panel();
            this.btnBuscarTodos = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chkSomenteAtivos = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cklMarcas = new System.Windows.Forms.CheckedListBox();
            this.lblFiltroPrecoMax = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.cklCategorias = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trbFiltroPreco = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlProdutos = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlNenhumProduto = new System.Windows.Forms.Panel();
            this.btnCadProduto = new FontAwesome.Sharp.IconButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.pnlMenuFiltros.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbFiltroPreco)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlProdutos.SuspendLayout();
            this.pnlNenhumProduto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenuFiltros
            // 
            this.pnlMenuFiltros.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlMenuFiltros.Controls.Add(this.btnBuscarTodos);
            this.pnlMenuFiltros.Controls.Add(this.panel4);
            this.pnlMenuFiltros.Controls.Add(this.panel3);
            this.pnlMenuFiltros.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuFiltros.Name = "pnlMenuFiltros";
            this.pnlMenuFiltros.Size = new System.Drawing.Size(256, 511);
            this.pnlMenuFiltros.TabIndex = 0;
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBuscarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarTodos.FlatAppearance.BorderSize = 0;
            this.btnBuscarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTodos.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBuscarTodos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTodos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarTodos.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarTodos.IconColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarTodos.IconSize = 30;
            this.btnBuscarTodos.Location = new System.Drawing.Point(16, 452);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Rotation = 0D;
            this.btnBuscarTodos.Size = new System.Drawing.Size(211, 50);
            this.btnBuscarTodos.TabIndex = 8;
            this.btnBuscarTodos.Text = "Buscar Todos os Produtos";
            this.btnBuscarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscarTodos.UseVisualStyleBackColor = false;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // panel4
            // 
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.chkSomenteAtivos);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.cklMarcas);
            this.panel4.Controls.Add(this.lblFiltroPrecoMax);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.txtNomeProduto);
            this.panel4.Controls.Add(this.cklCategorias);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.trbFiltroPreco);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(256, 394);
            this.panel4.TabIndex = 0;
            // 
            // chkSomenteAtivos
            // 
            this.chkSomenteAtivos.AutoSize = true;
            this.chkSomenteAtivos.Checked = true;
            this.chkSomenteAtivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSomenteAtivos.Location = new System.Drawing.Point(12, 499);
            this.chkSomenteAtivos.Name = "chkSomenteAtivos";
            this.chkSomenteAtivos.Size = new System.Drawing.Size(188, 25);
            this.chkSomenteAtivos.TabIndex = 12;
            this.chkSomenteAtivos.Text = "Buscar Somente Ativos";
            this.chkSomenteAtivos.UseVisualStyleBackColor = true;
            this.chkSomenteAtivos.CheckedChanged += new System.EventHandler(this.chkSomenteAtivos_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Marcas:";
            // 
            // cklMarcas
            // 
            this.cklMarcas.CheckOnClick = true;
            this.cklMarcas.FormattingEnabled = true;
            this.cklMarcas.Location = new System.Drawing.Point(12, 363);
            this.cklMarcas.Name = "cklMarcas";
            this.cklMarcas.Size = new System.Drawing.Size(211, 119);
            this.cklMarcas.TabIndex = 10;
            // 
            // lblFiltroPrecoMax
            // 
            this.lblFiltroPrecoMax.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltroPrecoMax.Location = new System.Drawing.Point(101, 133);
            this.lblFiltroPrecoMax.Name = "lblFiltroPrecoMax";
            this.lblFiltroPrecoMax.Size = new System.Drawing.Size(120, 16);
            this.lblFiltroPrecoMax.TabIndex = 6;
            this.lblFiltroPrecoMax.Text = "R$ 0,00";
            this.lblFiltroPrecoMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "R$ 0,00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 21);
            this.label5.TabIndex = 9;
            this.label5.Text = "Categorias:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Produto:";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(12, 31);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(211, 28);
            this.txtNomeProduto.TabIndex = 2;
            this.txtNomeProduto.TextChanged += new System.EventHandler(this.txtNomeProduto_TextChanged);
            // 
            // cklCategorias
            // 
            this.cklCategorias.CheckOnClick = true;
            this.cklCategorias.FormattingEnabled = true;
            this.cklCategorias.Location = new System.Drawing.Point(12, 203);
            this.cklCategorias.Name = "cklCategorias";
            this.cklCategorias.Size = new System.Drawing.Size(211, 119);
            this.cklCategorias.TabIndex = 7;
            this.cklCategorias.SelectedValueChanged += new System.EventHandler(this.cklCategorias_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Preço:";
            // 
            // trbFiltroPreco
            // 
            this.trbFiltroPreco.Location = new System.Drawing.Point(16, 97);
            this.trbFiltroPreco.Maximum = 0;
            this.trbFiltroPreco.Name = "trbFiltroPreco";
            this.trbFiltroPreco.Size = new System.Drawing.Size(205, 45);
            this.trbFiltroPreco.TabIndex = 4;
            this.trbFiltroPreco.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbFiltroPreco.ValueChanged += new System.EventHandler(this.trbFiltroPreco_ValueChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.iconPictureBox1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(256, 49);
            this.panel3.TabIndex = 1;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.DimGray;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.Location = new System.Drawing.Point(103, 8);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 3;
            this.iconPictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtros";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.pnlProdutos);
            this.panel2.Location = new System.Drawing.Point(262, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 511);
            this.panel2.TabIndex = 1;
            // 
            // pnlProdutos
            // 
            this.pnlProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProdutos.AutoScroll = true;
            this.pnlProdutos.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlProdutos.Controls.Add(this.pnlNenhumProduto);
            this.pnlProdutos.Location = new System.Drawing.Point(3, 3);
            this.pnlProdutos.Name = "pnlProdutos";
            this.pnlProdutos.Size = new System.Drawing.Size(366, 505);
            this.pnlProdutos.TabIndex = 0;
            // 
            // pnlNenhumProduto
            // 
            this.pnlNenhumProduto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNenhumProduto.Controls.Add(this.btnCadProduto);
            this.pnlNenhumProduto.Controls.Add(this.label10);
            this.pnlNenhumProduto.Controls.Add(this.label9);
            this.pnlNenhumProduto.Controls.Add(this.iconPictureBox2);
            this.pnlNenhumProduto.Location = new System.Drawing.Point(3, 3);
            this.pnlNenhumProduto.Name = "pnlNenhumProduto";
            this.pnlNenhumProduto.Size = new System.Drawing.Size(354, 493);
            this.pnlNenhumProduto.TabIndex = 0;
            // 
            // btnCadProduto
            // 
            this.btnCadProduto.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCadProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadProduto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCadProduto.IconChar = FontAwesome.Sharp.IconChar.ThLarge;
            this.btnCadProduto.IconColor = System.Drawing.Color.Black;
            this.btnCadProduto.IconSize = 30;
            this.btnCadProduto.Location = new System.Drawing.Point(115, 311);
            this.btnCadProduto.Name = "btnCadProduto";
            this.btnCadProduto.Rotation = 0D;
            this.btnCadProduto.Size = new System.Drawing.Size(220, 36);
            this.btnCadProduto.TabIndex = 9;
            this.btnCadProduto.Text = "Cadastrar um Produto";
            this.btnCadProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCadProduto.UseVisualStyleBackColor = false;
            this.btnCadProduto.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(110, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(241, 87);
            this.label10.TabIndex = 8;
            this.label10.Text = "Parece que não existe nenhum Produto cadastrado no sistema.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(109, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 31);
            this.label9.TabIndex = 7;
            this.label9.Text = "Ops...";
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.BoxOpen;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox2.IconSize = 100;
            this.iconPictureBox2.Location = new System.Drawing.Point(3, 190);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(100, 100);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox2.TabIndex = 6;
            this.iconPictureBox2.TabStop = false;
            // 
            // ConProduto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMenuFiltros);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "ConProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConProduto";
            this.Load += new System.EventHandler(this.ConProduto_Load);
            this.pnlMenuFiltros.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbFiltroPreco)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlProdutos.ResumeLayout(false);
            this.pnlNenhumProduto.ResumeLayout(false);
            this.pnlNenhumProduto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenuFiltros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel pnlProdutos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cklCategorias;
        private System.Windows.Forms.Label lblFiltroPrecoMax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trbFiltroPreco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private FontAwesome.Sharp.IconButton btnBuscarTodos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox cklMarcas;
        private System.Windows.Forms.Panel pnlNenhumProduto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconButton btnCadProduto;
        private System.Windows.Forms.CheckBox chkSomenteAtivos;
    }
}