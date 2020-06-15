namespace KadoshModas.UI.Util
{
    partial class ConfigStringDeConexao
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new FontAwesome.Sharp.IconButton();
            this.txtBancoDeDados = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor: ";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(167, 43);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(192, 28);
            this.txtServidor.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnConfirmar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnConfirmar.IconColor = System.Drawing.Color.Black;
            this.btnConfirmar.IconSize = 16;
            this.btnConfirmar.Location = new System.Drawing.Point(220, 146);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Rotation = 0D;
            this.btnConfirmar.Size = new System.Drawing.Size(139, 51);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.Text = "Confirmar configuração";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtBancoDeDados
            // 
            this.txtBancoDeDados.Location = new System.Drawing.Point(167, 90);
            this.txtBancoDeDados.Name = "txtBancoDeDados";
            this.txtBancoDeDados.Size = new System.Drawing.Size(192, 28);
            this.txtBancoDeDados.TabIndex = 3;
            this.txtBancoDeDados.Text = "BD_KADOSH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Banco de Dados: ";
            // 
            // ConfigStringDeConexao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(404, 238);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtBancoDeDados);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigStringDeConexao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurar String de Conexão";
            this.Load += new System.EventHandler(this.ConfigStringDeConexao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServidor;
        private FontAwesome.Sharp.IconButton btnConfirmar;
        private System.Windows.Forms.TextBox txtBancoDeDados;
        private System.Windows.Forms.Label label2;
    }
}