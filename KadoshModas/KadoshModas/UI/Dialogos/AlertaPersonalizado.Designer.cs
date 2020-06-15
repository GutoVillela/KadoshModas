namespace KadoshModas.UI.Dialogos
{
    partial class AlertaPersonalizado
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
            this.lblMensagemAlerta = new System.Windows.Forms.Label();
            this.picIcone = new FontAwesome.Sharp.IconPictureBox();
            this.trmTemporizador = new System.Windows.Forms.Timer(this.components);
            this.btnFechar = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picIcone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensagemAlerta
            // 
            this.lblMensagemAlerta.AutoSize = true;
            this.lblMensagemAlerta.ForeColor = System.Drawing.Color.White;
            this.lblMensagemAlerta.Location = new System.Drawing.Point(63, 28);
            this.lblMensagemAlerta.Name = "lblMensagemAlerta";
            this.lblMensagemAlerta.Size = new System.Drawing.Size(174, 21);
            this.lblMensagemAlerta.TabIndex = 0;
            this.lblMensagemAlerta.Text = "Mensagem do alerta";
            // 
            // picIcone
            // 
            this.picIcone.BackColor = System.Drawing.Color.Transparent;
            this.picIcone.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.picIcone.IconColor = System.Drawing.Color.White;
            this.picIcone.IconSize = 45;
            this.picIcone.Location = new System.Drawing.Point(12, 14);
            this.picIcone.Name = "picIcone";
            this.picIcone.Size = new System.Drawing.Size(45, 45);
            this.picIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIcone.TabIndex = 2;
            this.picIcone.TabStop = false;
            // 
            // trmTemporizador
            // 
            this.trmTemporizador.Tick += new System.EventHandler(this.trmTemporizador_Tick);
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.btnFechar.IconColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(326, 22);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(32, 32);
            this.btnFechar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnFechar.TabIndex = 3;
            this.btnFechar.TabStop = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // AlertaPersonalizado
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(367, 70);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.picIcone);
            this.Controls.Add(this.lblMensagemAlerta);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlertaPersonalizado";
            this.Text = "AlertaPersonalizado";
            this.Load += new System.EventHandler(this.AlertaPersonalizado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFechar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensagemAlerta;
        private FontAwesome.Sharp.IconPictureBox picIcone;
        private System.Windows.Forms.Timer trmTemporizador;
        private FontAwesome.Sharp.IconPictureBox btnFechar;
    }
}