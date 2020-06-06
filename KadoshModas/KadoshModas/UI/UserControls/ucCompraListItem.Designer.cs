namespace KadoshModas.UI.UserControls
{
    partial class ucCompraListItem
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
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.btnDetalhesVenda = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.White;
            this.iconPictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconSize = 100;
            this.iconPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.iconPictureBox1.TabIndex = 0;
            this.iconPictureBox1.TabStop = false;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(105, 13);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(128, 31);
            this.lblValor.TabIndex = 1;
            this.lblValor.Text = "R$ 100,00";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.Location = new System.Drawing.Point(106, 47);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(94, 21);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "01/01/0001";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacao.Location = new System.Drawing.Point(106, 73);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(81, 21);
            this.lblSituacao.TabIndex = 3;
            this.lblSituacao.Text = "Em aberto";
            // 
            // btnDetalhesVenda
            // 
            this.btnDetalhesVenda.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDetalhesVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalhesVenda.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDetalhesVenda.FlatAppearance.BorderSize = 0;
            this.btnDetalhesVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalhesVenda.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDetalhesVenda.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnDetalhesVenda.IconColor = System.Drawing.Color.White;
            this.btnDetalhesVenda.IconSize = 50;
            this.btnDetalhesVenda.Location = new System.Drawing.Point(523, 0);
            this.btnDetalhesVenda.Name = "btnDetalhesVenda";
            this.btnDetalhesVenda.Rotation = 0D;
            this.btnDetalhesVenda.Size = new System.Drawing.Size(50, 100);
            this.btnDetalhesVenda.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnDetalhesVenda, "Ver detalhes da Compra");
            this.btnDetalhesVenda.UseVisualStyleBackColor = false;
            this.btnDetalhesVenda.Click += new System.EventHandler(this.btnDetalhesVenda_Click);
            // 
            // ucCompraListItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnDetalhesVenda);
            this.Controls.Add(this.lblSituacao);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.iconPictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucCompraListItem";
            this.Size = new System.Drawing.Size(573, 100);
            this.Load += new System.EventHandler(this.ucCompraListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblSituacao;
        private FontAwesome.Sharp.IconButton btnDetalhesVenda;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
