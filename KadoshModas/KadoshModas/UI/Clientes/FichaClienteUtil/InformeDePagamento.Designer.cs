namespace KadoshModas.UI.FichaClienteUtil
{
    partial class InformeDePagamento
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
            this.btnOK = new FontAwesome.Sharp.IconButton();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.chkQuitarVenda = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picIconeDialogo = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).BeginInit();
            this.SuspendLayout();
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
            this.btnOK.Location = new System.Drawing.Point(132, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Rotation = 0D;
            this.btnOK.Size = new System.Drawing.Size(116, 33);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtValorPago
            // 
            this.txtValorPago.Location = new System.Drawing.Point(72, 54);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(285, 28);
            this.txtValorPago.TabIndex = 8;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtValorPago_TextChanged);
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            // 
            // chkQuitarVenda
            // 
            this.chkQuitarVenda.AutoSize = true;
            this.chkQuitarVenda.Location = new System.Drawing.Point(72, 91);
            this.chkQuitarVenda.Name = "chkQuitarVenda";
            this.chkQuitarVenda.Size = new System.Drawing.Size(119, 25);
            this.chkQuitarVenda.TabIndex = 7;
            this.chkQuitarVenda.Text = "Quitar dívida";
            this.chkQuitarVenda.UseVisualStyleBackColor = true;
            this.chkQuitarVenda.CheckedChanged += new System.EventHandler(this.chkQuitarVenda_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Qual o Valor pago?";
            // 
            // picIconeDialogo
            // 
            this.picIconeDialogo.BackColor = System.Drawing.SystemColors.Control;
            this.picIconeDialogo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            this.picIconeDialogo.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconSize = 50;
            this.picIconeDialogo.Location = new System.Drawing.Point(12, 30);
            this.picIconeDialogo.Name = "picIconeDialogo";
            this.picIconeDialogo.Size = new System.Drawing.Size(50, 50);
            this.picIconeDialogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIconeDialogo.TabIndex = 5;
            this.picIconeDialogo.TabStop = false;
            // 
            // InformeDePagamento
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValorPago);
            this.Controls.Add(this.chkQuitarVenda);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picIconeDialogo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformeDePagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Informar pagamento da ficha";
            this.Load += new System.EventHandler(this.InformeDePagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnOK;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.CheckBox chkQuitarVenda;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox picIconeDialogo;
    }
}