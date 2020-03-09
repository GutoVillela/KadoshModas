namespace KadoshModas.UI
{
    partial class TelaPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCadCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.pRODUTOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vENDASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.pRODUTOSToolStripMenuItem,
            this.vENDASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCadCliente,
            this.tsmiConCliente});
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.cLIENTESToolStripMenuItem.Text = "CLIENTES";
            // 
            // tsmiCadCliente
            // 
            this.tsmiCadCliente.Name = "tsmiCadCliente";
            this.tsmiCadCliente.Size = new System.Drawing.Size(180, 22);
            this.tsmiCadCliente.Text = "CADASTRAR";
            this.tsmiCadCliente.Click += new System.EventHandler(this.tsmiCadCliente_Click);
            // 
            // tsmiConCliente
            // 
            this.tsmiConCliente.Name = "tsmiConCliente";
            this.tsmiConCliente.Size = new System.Drawing.Size(180, 22);
            this.tsmiConCliente.Text = "CONSULTAR";
            // 
            // pRODUTOSToolStripMenuItem
            // 
            this.pRODUTOSToolStripMenuItem.Name = "pRODUTOSToolStripMenuItem";
            this.pRODUTOSToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.pRODUTOSToolStripMenuItem.Text = "PRODUTOS";
            // 
            // vENDASToolStripMenuItem
            // 
            this.vENDASToolStripMenuItem.Name = "vENDASToolStripMenuItem";
            this.vENDASToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.vENDASToolStripMenuItem.Text = "VENDAS";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 506);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaPrincipal";
            this.Text = "TelaPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCadCliente;
        private System.Windows.Forms.ToolStripMenuItem tsmiConCliente;
        private System.Windows.Forms.ToolStripMenuItem pRODUTOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vENDASToolStripMenuItem;
    }
}