namespace KadoshModas.UI
{
    partial class ConProdutosVenda
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
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtCodigo = new System.Windows.Forms.RadioButton();
            this.rbtProduto = new System.Windows.Forms.RadioButton();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.pnlPaginacaoBusca = new System.Windows.Forms.Panel();
            this.btnUltimoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnProximoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnAnteriorPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnInicioPaginacao = new FontAwesome.Sharp.IconButton();
            this.lblRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.pnlPaginacaoBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProdutos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Produto,
            this.Preco});
            this.dgvProdutos.Location = new System.Drawing.Point(18, 142);
            this.dgvProdutos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.RowHeadersVisible = false;
            this.dgvProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutos.Size = new System.Drawing.Size(651, 353);
            this.dgvProdutos.TabIndex = 0;
            this.dgvProdutos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellContentDoubleClick);
            this.dgvProdutos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProdutos_CellDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 50F;
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // Preco
            // 
            this.Preco.FillWeight = 50F;
            this.Preco.HeaderText = "Preço (R$)";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            // 
            // rbtCodigo
            // 
            this.rbtCodigo.AutoSize = true;
            this.rbtCodigo.Location = new System.Drawing.Point(108, 70);
            this.rbtCodigo.Name = "rbtCodigo";
            this.rbtCodigo.Size = new System.Drawing.Size(78, 25);
            this.rbtCodigo.TabIndex = 6;
            this.rbtCodigo.TabStop = true;
            this.rbtCodigo.Text = "Código";
            this.rbtCodigo.UseVisualStyleBackColor = true;
            // 
            // rbtProduto
            // 
            this.rbtProduto.AutoSize = true;
            this.rbtProduto.Checked = true;
            this.rbtProduto.Location = new System.Drawing.Point(18, 70);
            this.rbtProduto.Name = "rbtProduto";
            this.rbtProduto.Size = new System.Drawing.Size(84, 25);
            this.rbtProduto.TabIndex = 5;
            this.rbtProduto.TabStop = true;
            this.rbtProduto.Text = "Produto";
            this.rbtProduto.UseVisualStyleBackColor = true;
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Location = new System.Drawing.Point(18, 36);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(496, 28);
            this.txtConsulta.TabIndex = 7;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(520, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Rotation = 0D;
            this.btnBuscar.Size = new System.Drawing.Size(149, 28);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // pnlPaginacaoBusca
            // 
            this.pnlPaginacaoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaginacaoBusca.Controls.Add(this.btnUltimoPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnProximoPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnAnteriorPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnInicioPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.lblRegistros);
            this.pnlPaginacaoBusca.Location = new System.Drawing.Point(9, 503);
            this.pnlPaginacaoBusca.Name = "pnlPaginacaoBusca";
            this.pnlPaginacaoBusca.Size = new System.Drawing.Size(660, 30);
            this.pnlPaginacaoBusca.TabIndex = 22;
            // 
            // btnUltimoPaginacao
            // 
            this.btnUltimoPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltimoPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUltimoPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnUltimoPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnUltimoPaginacao.IconSize = 20;
            this.btnUltimoPaginacao.Location = new System.Drawing.Point(550, 3);
            this.btnUltimoPaginacao.Name = "btnUltimoPaginacao";
            this.btnUltimoPaginacao.Rotation = 0D;
            this.btnUltimoPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnUltimoPaginacao.TabIndex = 4;
            this.btnUltimoPaginacao.Text = "Último";
            this.btnUltimoPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimoPaginacao.UseVisualStyleBackColor = true;
            this.btnUltimoPaginacao.Click += new System.EventHandler(this.btnUltimoPaginacao_Click);
            // 
            // btnProximoPaginacao
            // 
            this.btnProximoPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProximoPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnProximoPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnProximoPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnProximoPaginacao.IconSize = 20;
            this.btnProximoPaginacao.Location = new System.Drawing.Point(444, 3);
            this.btnProximoPaginacao.Name = "btnProximoPaginacao";
            this.btnProximoPaginacao.Rotation = 0D;
            this.btnProximoPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnProximoPaginacao.TabIndex = 3;
            this.btnProximoPaginacao.Text = "Próximo";
            this.btnProximoPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProximoPaginacao.UseVisualStyleBackColor = true;
            this.btnProximoPaginacao.Click += new System.EventHandler(this.btnProximoPaginacao_Click);
            // 
            // btnAnteriorPaginacao
            // 
            this.btnAnteriorPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnteriorPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAnteriorPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnAnteriorPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnAnteriorPaginacao.IconSize = 20;
            this.btnAnteriorPaginacao.Location = new System.Drawing.Point(338, 3);
            this.btnAnteriorPaginacao.Name = "btnAnteriorPaginacao";
            this.btnAnteriorPaginacao.Rotation = 0D;
            this.btnAnteriorPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnAnteriorPaginacao.TabIndex = 2;
            this.btnAnteriorPaginacao.Text = "Anterior";
            this.btnAnteriorPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnteriorPaginacao.UseVisualStyleBackColor = true;
            this.btnAnteriorPaginacao.Click += new System.EventHandler(this.btnAnteriorPaginacao_Click);
            // 
            // btnInicioPaginacao
            // 
            this.btnInicioPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicioPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnInicioPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnInicioPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnInicioPaginacao.IconSize = 20;
            this.btnInicioPaginacao.Location = new System.Drawing.Point(232, 3);
            this.btnInicioPaginacao.Name = "btnInicioPaginacao";
            this.btnInicioPaginacao.Rotation = 0D;
            this.btnInicioPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnInicioPaginacao.TabIndex = 1;
            this.btnInicioPaginacao.Text = "Início";
            this.btnInicioPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicioPaginacao.UseVisualStyleBackColor = true;
            this.btnInicioPaginacao.Click += new System.EventHandler(this.btnInicioPaginacao_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(3, 4);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(202, 21);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Exibindo registros de 0 a 10";
            // 
            // ConProdutosVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 545);
            this.Controls.Add(this.pnlPaginacaoBusca);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.rbtCodigo);
            this.Controls.Add(this.rbtProduto);
            this.Controls.Add(this.txtConsulta);
            this.Controls.Add(this.dgvProdutos);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConProdutosVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de Produtos";
            this.Load += new System.EventHandler(this.ConProdutosVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.pnlPaginacaoBusca.ResumeLayout(false);
            this.pnlPaginacaoBusca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.RadioButton rbtCodigo;
        private System.Windows.Forms.RadioButton rbtProduto;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Panel pnlPaginacaoBusca;
        private FontAwesome.Sharp.IconButton btnUltimoPaginacao;
        private FontAwesome.Sharp.IconButton btnProximoPaginacao;
        private FontAwesome.Sharp.IconButton btnAnteriorPaginacao;
        private FontAwesome.Sharp.IconButton btnInicioPaginacao;
        private System.Windows.Forms.Label lblRegistros;
    }
}