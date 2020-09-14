namespace KadoshModas.UI
{
    partial class OpcoesAvancadasDaVenda
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
            this.btnCalcularTotalVendas = new FontAwesome.Sharp.IconButton();
            this.pnlStatusExecucao = new System.Windows.Forms.Panel();
            this.lblStatusExecucao = new System.Windows.Forms.Label();
            this.pnlStatusExecucao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCalcularTotalVendas
            // 
            this.btnCalcularTotalVendas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalcularTotalVendas.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnCalcularTotalVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalcularTotalVendas.FlatAppearance.BorderSize = 0;
            this.btnCalcularTotalVendas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularTotalVendas.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCalcularTotalVendas.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularTotalVendas.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnCalcularTotalVendas.IconColor = System.Drawing.Color.LightGreen;
            this.btnCalcularTotalVendas.IconSize = 50;
            this.btnCalcularTotalVendas.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCalcularTotalVendas.Location = new System.Drawing.Point(12, 11);
            this.btnCalcularTotalVendas.Name = "btnCalcularTotalVendas";
            this.btnCalcularTotalVendas.Rotation = 0D;
            this.btnCalcularTotalVendas.Size = new System.Drawing.Size(460, 50);
            this.btnCalcularTotalVendas.TabIndex = 0;
            this.btnCalcularTotalVendas.Text = "Calcular e corrigir total de todas as vendas";
            this.btnCalcularTotalVendas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCalcularTotalVendas.UseVisualStyleBackColor = false;
            this.btnCalcularTotalVendas.Click += new System.EventHandler(this.btnCalcularTotalVendas_Click);
            // 
            // pnlStatusExecucao
            // 
            this.pnlStatusExecucao.Controls.Add(this.lblStatusExecucao);
            this.pnlStatusExecucao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusExecucao.Location = new System.Drawing.Point(0, 67);
            this.pnlStatusExecucao.Name = "pnlStatusExecucao";
            this.pnlStatusExecucao.Size = new System.Drawing.Size(484, 28);
            this.pnlStatusExecucao.TabIndex = 1;
            this.pnlStatusExecucao.Visible = false;
            // 
            // lblStatusExecucao
            // 
            this.lblStatusExecucao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusExecucao.Location = new System.Drawing.Point(0, 8);
            this.lblStatusExecucao.Name = "lblStatusExecucao";
            this.lblStatusExecucao.Size = new System.Drawing.Size(484, 20);
            this.lblStatusExecucao.TabIndex = 0;
            this.lblStatusExecucao.Text = "label1";
            this.lblStatusExecucao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpcoesAvancadasDaVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(484, 95);
            this.Controls.Add(this.pnlStatusExecucao);
            this.Controls.Add(this.btnCalcularTotalVendas);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "OpcoesAvancadasDaVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opções Avançadas da Venda";
            this.Load += new System.EventHandler(this.OpcoesAvancadasDaVenda_Load);
            this.pnlStatusExecucao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCalcularTotalVendas;
        private System.Windows.Forms.Panel pnlStatusExecucao;
        private System.Windows.Forms.Label lblStatusExecucao;
    }
}