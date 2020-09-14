namespace KadoshModas.UI.DetalhesVendaUtil
{
    partial class CancelarItemDaVenda
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
            this.picIconeDialogo = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoClienteDesistiuDoProduto = new System.Windows.Forms.RadioButton();
            this.rdoProdutoComDefeito = new System.Windows.Forms.RadioButton();
            this.rdoProdutoNaoServiu = new System.Windows.Forms.RadioButton();
            this.rdoTrocaItem = new System.Windows.Forms.RadioButton();
            this.btnOK = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQtdItensACancelar = new System.Windows.Forms.TextBox();
            this.chkCancelarTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picIconeDialogo
            // 
            this.picIconeDialogo.BackColor = System.Drawing.SystemColors.Control;
            this.picIconeDialogo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            this.picIconeDialogo.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconSize = 50;
            this.picIconeDialogo.Location = new System.Drawing.Point(12, 12);
            this.picIconeDialogo.Name = "picIconeDialogo";
            this.picIconeDialogo.Size = new System.Drawing.Size(50, 50);
            this.picIconeDialogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIconeDialogo.TabIndex = 1;
            this.picIconeDialogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Qual o motivo do cancelamento do item?";
            // 
            // rdoClienteDesistiuDoProduto
            // 
            this.rdoClienteDesistiuDoProduto.AutoSize = true;
            this.rdoClienteDesistiuDoProduto.Checked = true;
            this.rdoClienteDesistiuDoProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoClienteDesistiuDoProduto.Location = new System.Drawing.Point(68, 46);
            this.rdoClienteDesistiuDoProduto.Name = "rdoClienteDesistiuDoProduto";
            this.rdoClienteDesistiuDoProduto.Size = new System.Drawing.Size(215, 25);
            this.rdoClienteDesistiuDoProduto.TabIndex = 3;
            this.rdoClienteDesistiuDoProduto.TabStop = true;
            this.rdoClienteDesistiuDoProduto.Text = "Cliente desistiu do produto";
            this.rdoClienteDesistiuDoProduto.UseVisualStyleBackColor = true;
            // 
            // rdoProdutoComDefeito
            // 
            this.rdoProdutoComDefeito.AutoSize = true;
            this.rdoProdutoComDefeito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoProdutoComDefeito.Location = new System.Drawing.Point(68, 86);
            this.rdoProdutoComDefeito.Name = "rdoProdutoComDefeito";
            this.rdoProdutoComDefeito.Size = new System.Drawing.Size(170, 25);
            this.rdoProdutoComDefeito.TabIndex = 4;
            this.rdoProdutoComDefeito.Text = "Produto com defeito";
            this.rdoProdutoComDefeito.UseVisualStyleBackColor = true;
            // 
            // rdoProdutoNaoServiu
            // 
            this.rdoProdutoNaoServiu.AutoSize = true;
            this.rdoProdutoNaoServiu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoProdutoNaoServiu.Location = new System.Drawing.Point(68, 126);
            this.rdoProdutoNaoServiu.Name = "rdoProdutoNaoServiu";
            this.rdoProdutoNaoServiu.Size = new System.Drawing.Size(378, 25);
            this.rdoProdutoNaoServiu.TabIndex = 5;
            this.rdoProdutoNaoServiu.Text = "Problemas com o tamanho ou número do produto";
            this.rdoProdutoNaoServiu.UseVisualStyleBackColor = true;
            // 
            // rdoTrocaItem
            // 
            this.rdoTrocaItem.AutoSize = true;
            this.rdoTrocaItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoTrocaItem.Location = new System.Drawing.Point(68, 166);
            this.rdoTrocaItem.Name = "rdoTrocaItem";
            this.rdoTrocaItem.Size = new System.Drawing.Size(196, 25);
            this.rdoTrocaItem.TabIndex = 6;
            this.rdoTrocaItem.Text = "Troca por outro produto";
            this.rdoTrocaItem.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOK.IconColor = System.Drawing.Color.Black;
            this.btnOK.IconSize = 16;
            this.btnOK.Location = new System.Drawing.Point(182, 316);
            this.btnOK.Name = "btnOK";
            this.btnOK.Rotation = 0D;
            this.btnOK.Size = new System.Drawing.Size(132, 33);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Quantos deste produto deseja cancelar?";
            // 
            // txtQtdItensACancelar
            // 
            this.txtQtdItensACancelar.Location = new System.Drawing.Point(68, 241);
            this.txtQtdItensACancelar.Name = "txtQtdItensACancelar";
            this.txtQtdItensACancelar.Size = new System.Drawing.Size(309, 28);
            this.txtQtdItensACancelar.TabIndex = 10;
            this.txtQtdItensACancelar.TextChanged += new System.EventHandler(this.txtQtdItensACancelar_TextChanged);
            this.txtQtdItensACancelar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtdItensACancelar_KeyPress);
            // 
            // chkCancelarTodos
            // 
            this.chkCancelarTodos.AutoSize = true;
            this.chkCancelarTodos.Location = new System.Drawing.Point(68, 275);
            this.chkCancelarTodos.Name = "chkCancelarTodos";
            this.chkCancelarTodos.Size = new System.Drawing.Size(71, 25);
            this.chkCancelarTodos.TabIndex = 9;
            this.chkCancelarTodos.Text = "Todos";
            this.chkCancelarTodos.UseVisualStyleBackColor = true;
            this.chkCancelarTodos.CheckedChanged += new System.EventHandler(this.chkCancelarTodos_CheckedChanged);
            // 
            // CancelarItemDaVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.txtQtdItensACancelar);
            this.Controls.Add(this.chkCancelarTodos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rdoTrocaItem);
            this.Controls.Add(this.rdoProdutoNaoServiu);
            this.Controls.Add(this.rdoProdutoComDefeito);
            this.Controls.Add(this.rdoClienteDesistiuDoProduto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picIconeDialogo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelarItemDaVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CancelarItemDaVenda";
            this.Load += new System.EventHandler(this.CancelarItemDaVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox picIconeDialogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdoClienteDesistiuDoProduto;
        private System.Windows.Forms.RadioButton rdoProdutoComDefeito;
        private System.Windows.Forms.RadioButton rdoProdutoNaoServiu;
        private System.Windows.Forms.RadioButton rdoTrocaItem;
        private FontAwesome.Sharp.IconButton btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQtdItensACancelar;
        private System.Windows.Forms.CheckBox chkCancelarTodos;
    }
}