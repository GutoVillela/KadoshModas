namespace KadoshModas.UI
{
    partial class ConCliente
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
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.rbtCPF = new System.Windows.Forms.RadioButton();
            this.rbtNome = new System.Windows.Forms.RadioButton();
            this.pnlConCliente = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Location = new System.Drawing.Point(12, 45);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(610, 28);
            this.txtConsulta.TabIndex = 1;
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            // 
            // rbtCPF
            // 
            this.rbtCPF.AutoSize = true;
            this.rbtCPF.Location = new System.Drawing.Point(89, 79);
            this.rbtCPF.Name = "rbtCPF";
            this.rbtCPF.Size = new System.Drawing.Size(55, 25);
            this.rbtCPF.TabIndex = 1;
            this.rbtCPF.TabStop = true;
            this.rbtCPF.Text = "CPF";
            this.rbtCPF.UseVisualStyleBackColor = true;
            this.rbtCPF.Visible = false;
            this.rbtCPF.CheckedChanged += new System.EventHandler(this.rbtCPF_CheckedChanged);
            // 
            // rbtNome
            // 
            this.rbtNome.AutoSize = true;
            this.rbtNome.Checked = true;
            this.rbtNome.Location = new System.Drawing.Point(12, 79);
            this.rbtNome.Name = "rbtNome";
            this.rbtNome.Size = new System.Drawing.Size(71, 25);
            this.rbtNome.TabIndex = 0;
            this.rbtNome.TabStop = true;
            this.rbtNome.Text = "Nome";
            this.rbtNome.UseVisualStyleBackColor = true;
            this.rbtNome.Visible = false;
            this.rbtNome.CheckedChanged += new System.EventHandler(this.rbtNome_CheckedChanged);
            // 
            // pnlConCliente
            // 
            this.pnlConCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlConCliente.AutoScroll = true;
            this.pnlConCliente.Location = new System.Drawing.Point(12, 129);
            this.pnlConCliente.Name = "pnlConCliente";
            this.pnlConCliente.Size = new System.Drawing.Size(610, 370);
            this.pnlConCliente.TabIndex = 3;
            // 
            // ConCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.rbtCPF);
            this.Controls.Add(this.pnlConCliente);
            this.Controls.Add(this.rbtNome);
            this.Controls.Add(this.txtConsulta);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Consulta de Clientes";
            this.Load += new System.EventHandler(this.ConCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.RadioButton rbtCPF;
        private System.Windows.Forms.RadioButton rbtNome;
        private System.Windows.Forms.FlowLayoutPanel pnlConCliente;
    }
}