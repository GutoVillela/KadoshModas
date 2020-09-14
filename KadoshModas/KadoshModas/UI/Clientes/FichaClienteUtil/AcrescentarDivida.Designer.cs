namespace KadoshModas.UI.FichaClienteUtil
{
    partial class AcrescentarDivida
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
            this.txtValorDivida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picIconeDialogo = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoNao = new System.Windows.Forms.RadioButton();
            this.rdoSim = new System.Windows.Forms.RadioButton();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblEntradaRotulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnOK.IconColor = System.Drawing.Color.Black;
            this.btnOK.IconSize = 16;
            this.btnOK.Location = new System.Drawing.Point(130, 210);
            this.btnOK.Name = "btnOK";
            this.btnOK.Rotation = 0D;
            this.btnOK.Size = new System.Drawing.Size(203, 33);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtValorDivida
            // 
            this.txtValorDivida.Location = new System.Drawing.Point(72, 47);
            this.txtValorDivida.Name = "txtValorDivida";
            this.txtValorDivida.Size = new System.Drawing.Size(352, 28);
            this.txtValorDivida.TabIndex = 12;
            this.txtValorDivida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorDivida_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Qual o Valor para acrescentar na conta do cliente?";
            // 
            // picIconeDialogo
            // 
            this.picIconeDialogo.BackColor = System.Drawing.SystemColors.Control;
            this.picIconeDialogo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconChar = FontAwesome.Sharp.IconChar.CommentDollar;
            this.picIconeDialogo.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.picIconeDialogo.IconSize = 50;
            this.picIconeDialogo.Location = new System.Drawing.Point(12, 23);
            this.picIconeDialogo.Name = "picIconeDialogo";
            this.picIconeDialogo.Size = new System.Drawing.Size(50, 50);
            this.picIconeDialogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIconeDialogo.TabIndex = 10;
            this.picIconeDialogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 21);
            this.label2.TabIndex = 14;
            this.label2.Text = "Dívida possui valor de entrada?";
            // 
            // rdoNao
            // 
            this.rdoNao.AutoSize = true;
            this.rdoNao.Checked = true;
            this.rdoNao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoNao.Location = new System.Drawing.Point(72, 120);
            this.rdoNao.Name = "rdoNao";
            this.rdoNao.Size = new System.Drawing.Size(57, 25);
            this.rdoNao.TabIndex = 15;
            this.rdoNao.Text = "Não";
            this.rdoNao.UseVisualStyleBackColor = true;
            this.rdoNao.CheckedChanged += new System.EventHandler(this.rdoNao_CheckedChanged);
            // 
            // rdoSim
            // 
            this.rdoSim.AutoSize = true;
            this.rdoSim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdoSim.Location = new System.Drawing.Point(135, 120);
            this.rdoSim.Name = "rdoSim";
            this.rdoSim.Size = new System.Drawing.Size(55, 25);
            this.rdoSim.TabIndex = 16;
            this.rdoSim.Text = "Sim";
            this.rdoSim.UseVisualStyleBackColor = true;
            this.rdoSim.CheckedChanged += new System.EventHandler(this.rdoSim_CheckedChanged);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(140, 154);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(186, 28);
            this.txtEntrada.TabIndex = 29;
            this.txtEntrada.Visible = false;
            this.txtEntrada.TextChanged += new System.EventHandler(this.txtEntrada_TextChanged);
            this.txtEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntrada_KeyPress);
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.Location = new System.Drawing.Point(332, 157);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(64, 21);
            this.lblEntrada.TabIndex = 28;
            this.lblEntrada.Text = "R$ 0,00";
            this.lblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEntrada.Visible = false;
            // 
            // lblEntradaRotulo
            // 
            this.lblEntradaRotulo.AutoSize = true;
            this.lblEntradaRotulo.Location = new System.Drawing.Point(68, 157);
            this.lblEntradaRotulo.Name = "lblEntradaRotulo";
            this.lblEntradaRotulo.Size = new System.Drawing.Size(66, 21);
            this.lblEntradaRotulo.TabIndex = 27;
            this.lblEntradaRotulo.Text = "Entrada:";
            this.lblEntradaRotulo.Visible = false;
            // 
            // AcrescentarDivida
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(461, 255);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.lblEntradaRotulo);
            this.Controls.Add(this.rdoSim);
            this.Controls.Add(this.rdoNao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtValorDivida);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picIconeDialogo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcrescentarDivida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acrescentar dívida do cliente";
            this.Load += new System.EventHandler(this.AcrescentarDivida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIconeDialogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnOK;
        private System.Windows.Forms.TextBox txtValorDivida;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox picIconeDialogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoNao;
        private System.Windows.Forms.RadioButton rdoSim;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblEntradaRotulo;
    }
}