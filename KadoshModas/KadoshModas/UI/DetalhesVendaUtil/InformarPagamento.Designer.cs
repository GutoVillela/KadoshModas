namespace KadoshModas.UI.DetalhesVendaUtil
{
    partial class InformarPagamento
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
            this.chkQuitarVenda = new System.Windows.Forms.CheckBox();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.btnOK = new FontAwesome.Sharp.IconButton();
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
            this.picIconeDialogo.Location = new System.Drawing.Point(12, 24);
            this.picIconeDialogo.Name = "picIconeDialogo";
            this.picIconeDialogo.Size = new System.Drawing.Size(50, 50);
            this.picIconeDialogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIconeDialogo.TabIndex = 0;
            this.picIconeDialogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Qual o Valor pago?";
            // 
            // chkQuitarVenda
            // 
            this.chkQuitarVenda.AutoSize = true;
            this.chkQuitarVenda.Location = new System.Drawing.Point(72, 82);
            this.chkQuitarVenda.Name = "chkQuitarVenda";
            this.chkQuitarVenda.Size = new System.Drawing.Size(119, 25);
            this.chkQuitarVenda.TabIndex = 2;
            this.chkQuitarVenda.Text = "Quitar venda";
            this.chkQuitarVenda.UseVisualStyleBackColor = true;
            this.chkQuitarVenda.CheckedChanged += new System.EventHandler(this.chkQuitarVenda_CheckedChanged);
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(72, 48);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(252, 28);
            this.txtValorPago.TabIndex = 3;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtValorPago_TextChanged);
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
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
            this.btnOK.Location = new System.Drawing.Point(132, 142);
            this.btnOK.Name = "btnOK";
            this.btnOK.Rotation = 0D;
            this.btnOK.Size = new System.Drawing.Size(132, 33);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // InformarPagamento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(377, 187);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.chkQuitarVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picIconeDialogo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformarPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informar Pagamento";
            this.Load += new System.EventHandler(this.InformarPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox picIconeDialogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkQuitarVenda;
        private System.Windows.Forms.TextBox txtValorPago;
        private FontAwesome.Sharp.IconButton btnOK;
    }
}