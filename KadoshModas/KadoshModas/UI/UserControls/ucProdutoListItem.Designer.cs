namespace KadoshModas.UI.UserControls
{
    partial class ucProdutoListItem
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picFotoProduto = new System.Windows.Forms.PictureBox();
            this.lblNomeProduto = new System.Windows.Forms.Label();
            this.lblValorProduto = new System.Windows.Forms.Label();
            this.btnDetalhesProduto = new FontAwesome.Sharp.IconButton();
            this.tipProduto = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoProduto)).BeginInit();
            this.SuspendLayout();
            // 
            // picFotoProduto
            // 
            this.picFotoProduto.Dock = System.Windows.Forms.DockStyle.Left;
            this.picFotoProduto.Image = global::KadoshModas.Properties.Resources.icone_produto;
            this.picFotoProduto.Location = new System.Drawing.Point(0, 0);
            this.picFotoProduto.Name = "picFotoProduto";
            this.picFotoProduto.Size = new System.Drawing.Size(80, 80);
            this.picFotoProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoProduto.TabIndex = 0;
            this.picFotoProduto.TabStop = false;
            // 
            // lblNomeProduto
            // 
            this.lblNomeProduto.AutoSize = true;
            this.lblNomeProduto.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeProduto.Location = new System.Drawing.Point(84, 12);
            this.lblNomeProduto.Name = "lblNomeProduto";
            this.lblNomeProduto.Size = new System.Drawing.Size(221, 31);
            this.lblNomeProduto.TabIndex = 1;
            this.lblNomeProduto.Text = "Nome do Produto";
            // 
            // lblValorProduto
            // 
            this.lblValorProduto.AutoSize = true;
            this.lblValorProduto.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorProduto.Location = new System.Drawing.Point(86, 43);
            this.lblValorProduto.Name = "lblValorProduto";
            this.lblValorProduto.Size = new System.Drawing.Size(90, 23);
            this.lblValorProduto.TabIndex = 2;
            this.lblValorProduto.Text = "R$ 100,00";
            // 
            // btnDetalhesProduto
            // 
            this.btnDetalhesProduto.BackColor = System.Drawing.Color.Silver;
            this.btnDetalhesProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalhesProduto.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDetalhesProduto.FlatAppearance.BorderSize = 0;
            this.btnDetalhesProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalhesProduto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDetalhesProduto.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnDetalhesProduto.IconColor = System.Drawing.Color.Black;
            this.btnDetalhesProduto.IconSize = 50;
            this.btnDetalhesProduto.Location = new System.Drawing.Point(392, 0);
            this.btnDetalhesProduto.Name = "btnDetalhesProduto";
            this.btnDetalhesProduto.Rotation = 0D;
            this.btnDetalhesProduto.Size = new System.Drawing.Size(60, 80);
            this.btnDetalhesProduto.TabIndex = 3;
            this.tipProduto.SetToolTip(this.btnDetalhesProduto, "Detalhes do Produto");
            this.btnDetalhesProduto.UseVisualStyleBackColor = false;
            this.btnDetalhesProduto.Click += new System.EventHandler(this.btnDetalhesProduto_Click);
            // 
            // ucProdutoListItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDetalhesProduto);
            this.Controls.Add(this.lblValorProduto);
            this.Controls.Add(this.lblNomeProduto);
            this.Controls.Add(this.picFotoProduto);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucProdutoListItem";
            this.Size = new System.Drawing.Size(452, 80);
            this.Load += new System.EventHandler(this.ucProdutoListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoProduto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFotoProduto;
        private System.Windows.Forms.Label lblNomeProduto;
        private System.Windows.Forms.Label lblValorProduto;
        private FontAwesome.Sharp.IconButton btnDetalhesProduto;
        private System.Windows.Forms.ToolTip tipProduto;
    }
}
