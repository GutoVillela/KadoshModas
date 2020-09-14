namespace KadoshModas.UI.OpcoesAvancadas
{
    partial class OpcoesAvancadasDoCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiasInadimplencia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvarConfiguracoes = new FontAwesome.Sharp.IconButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDiasInadimplencia);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parâmetros do Cliente";
            // 
            // txtDiasInadimplencia
            // 
            this.txtDiasInadimplencia.Location = new System.Drawing.Point(32, 72);
            this.txtDiasInadimplencia.Name = "txtDiasInadimplencia";
            this.txtDiasInadimplencia.Size = new System.Drawing.Size(464, 28);
            this.txtDiasInadimplencia.TabIndex = 1;
            this.txtDiasInadimplencia.TextChanged += new System.EventHandler(this.txtDiasInadimplencia_TextChanged);
            this.txtDiasInadimplencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiasInadimplencia_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tempo (em dias) até que o Cliente seja considerado Inadimplente: ";
            // 
            // btnSalvarConfiguracoes
            // 
            this.btnSalvarConfiguracoes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarConfiguracoes.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSalvarConfiguracoes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvarConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarConfiguracoes.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSalvarConfiguracoes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.btnSalvarConfiguracoes.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSalvarConfiguracoes.IconColor = System.Drawing.Color.DarkGreen;
            this.btnSalvarConfiguracoes.IconSize = 30;
            this.btnSalvarConfiguracoes.Location = new System.Drawing.Point(285, 174);
            this.btnSalvarConfiguracoes.Name = "btnSalvarConfiguracoes";
            this.btnSalvarConfiguracoes.Padding = new System.Windows.Forms.Padding(10);
            this.btnSalvarConfiguracoes.Rotation = 0D;
            this.btnSalvarConfiguracoes.Size = new System.Drawing.Size(280, 50);
            this.btnSalvarConfiguracoes.TabIndex = 27;
            this.btnSalvarConfiguracoes.Text = "SALVAR CONFIGURAÇÕES";
            this.btnSalvarConfiguracoes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvarConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSalvarConfiguracoes.UseVisualStyleBackColor = false;
            this.btnSalvarConfiguracoes.Click += new System.EventHandler(this.btnSalvarConfiguracoes_Click);
            // 
            // OpcoesAvancadasDoCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(577, 236);
            this.Controls.Add(this.btnSalvarConfiguracoes);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OpcoesAvancadasDoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opções Avançadas do Cliente";
            this.Load += new System.EventHandler(this.OpcoesAvancadasDoCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDiasInadimplencia;
        private FontAwesome.Sharp.IconButton btnSalvarConfiguracoes;
    }
}