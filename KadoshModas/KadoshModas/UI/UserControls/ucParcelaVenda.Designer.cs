namespace KadoshModas.UI.UserControls
{
    partial class ucParcelaVenda
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblValorParcela = new System.Windows.Forms.Label();
            this.pnlSituacaoParcela = new System.Windows.Forms.Panel();
            this.lblSituacaoParcela = new System.Windows.Forms.Label();
            this.pnlNumeroParcela = new System.Windows.Forms.Panel();
            this.lblNumeroParcela = new System.Windows.Forms.Label();
            this.btnMudarSituacaoParcela = new FontAwesome.Sharp.IconButton();
            this.lblVencimentoParcela = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsParcela = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelarParcelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mudarVencimentoDaParcelaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipParcela = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSituacaoParcela.SuspendLayout();
            this.pnlNumeroParcela.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsParcela.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor";
            // 
            // lblValorParcela
            // 
            this.lblValorParcela.AutoSize = true;
            this.lblValorParcela.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorParcela.Location = new System.Drawing.Point(56, 27);
            this.lblValorParcela.Name = "lblValorParcela";
            this.lblValorParcela.Size = new System.Drawing.Size(143, 34);
            this.lblValorParcela.TabIndex = 1;
            this.lblValorParcela.Text = "R$ 100,00";
            // 
            // pnlSituacaoParcela
            // 
            this.pnlSituacaoParcela.BackColor = System.Drawing.Color.Silver;
            this.pnlSituacaoParcela.Controls.Add(this.lblSituacaoParcela);
            this.pnlSituacaoParcela.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSituacaoParcela.Location = new System.Drawing.Point(0, 75);
            this.pnlSituacaoParcela.Name = "pnlSituacaoParcela";
            this.pnlSituacaoParcela.Size = new System.Drawing.Size(523, 25);
            this.pnlSituacaoParcela.TabIndex = 2;
            // 
            // lblSituacaoParcela
            // 
            this.lblSituacaoParcela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSituacaoParcela.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacaoParcela.Location = new System.Drawing.Point(0, 0);
            this.lblSituacaoParcela.Name = "lblSituacaoParcela";
            this.lblSituacaoParcela.Size = new System.Drawing.Size(523, 25);
            this.lblSituacaoParcela.TabIndex = 0;
            this.lblSituacaoParcela.Text = "Situação da Parcela";
            this.lblSituacaoParcela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlNumeroParcela
            // 
            this.pnlNumeroParcela.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlNumeroParcela.Controls.Add(this.lblNumeroParcela);
            this.pnlNumeroParcela.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNumeroParcela.Location = new System.Drawing.Point(0, 0);
            this.pnlNumeroParcela.Name = "pnlNumeroParcela";
            this.pnlNumeroParcela.Size = new System.Drawing.Size(50, 75);
            this.pnlNumeroParcela.TabIndex = 3;
            // 
            // lblNumeroParcela
            // 
            this.lblNumeroParcela.BackColor = System.Drawing.Color.DarkGray;
            this.lblNumeroParcela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroParcela.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroParcela.Location = new System.Drawing.Point(0, 0);
            this.lblNumeroParcela.Name = "lblNumeroParcela";
            this.lblNumeroParcela.Size = new System.Drawing.Size(50, 75);
            this.lblNumeroParcela.TabIndex = 0;
            this.lblNumeroParcela.Text = "00";
            this.lblNumeroParcela.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMudarSituacaoParcela
            // 
            this.btnMudarSituacaoParcela.BackColor = System.Drawing.Color.DarkGreen;
            this.btnMudarSituacaoParcela.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMudarSituacaoParcela.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMudarSituacaoParcela.FlatAppearance.BorderSize = 0;
            this.btnMudarSituacaoParcela.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMudarSituacaoParcela.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnMudarSituacaoParcela.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.btnMudarSituacaoParcela.IconColor = System.Drawing.Color.White;
            this.btnMudarSituacaoParcela.IconSize = 30;
            this.btnMudarSituacaoParcela.Location = new System.Drawing.Point(0, 0);
            this.btnMudarSituacaoParcela.Name = "btnMudarSituacaoParcela";
            this.btnMudarSituacaoParcela.Rotation = 0D;
            this.btnMudarSituacaoParcela.Size = new System.Drawing.Size(30, 75);
            this.btnMudarSituacaoParcela.TabIndex = 4;
            this.tipParcela.SetToolTip(this.btnMudarSituacaoParcela, "Pagar Parcela");
            this.btnMudarSituacaoParcela.UseVisualStyleBackColor = false;
            this.btnMudarSituacaoParcela.Click += new System.EventHandler(this.btnMudarSituacaoParcela_Click);
            // 
            // lblVencimentoParcela
            // 
            this.lblVencimentoParcela.AutoSize = true;
            this.lblVencimentoParcela.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimentoParcela.Location = new System.Drawing.Point(262, 27);
            this.lblVencimentoParcela.Name = "lblVencimentoParcela";
            this.lblVencimentoParcela.Size = new System.Drawing.Size(167, 34);
            this.lblVencimentoParcela.TabIndex = 6;
            this.lblVencimentoParcela.Text = "00/00/0000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Vencimento";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMudarSituacaoParcela);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(493, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 75);
            this.panel1.TabIndex = 7;
            // 
            // cmsParcela
            // 
            this.cmsParcela.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelarParcelaToolStripMenuItem,
            this.mudarVencimentoDaParcelaToolStripMenuItem});
            this.cmsParcela.Name = "cmsParcela";
            this.cmsParcela.Size = new System.Drawing.Size(233, 48);
            // 
            // cancelarParcelaToolStripMenuItem
            // 
            this.cancelarParcelaToolStripMenuItem.Image = global::KadoshModas.Properties.Resources.icone_invalido;
            this.cancelarParcelaToolStripMenuItem.Name = "cancelarParcelaToolStripMenuItem";
            this.cancelarParcelaToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.cancelarParcelaToolStripMenuItem.Text = "Cancelar Parcela";
            // 
            // mudarVencimentoDaParcelaToolStripMenuItem
            // 
            this.mudarVencimentoDaParcelaToolStripMenuItem.Name = "mudarVencimentoDaParcelaToolStripMenuItem";
            this.mudarVencimentoDaParcelaToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.mudarVencimentoDaParcelaToolStripMenuItem.Text = "Mudar Vencimento da Parcela";
            // 
            // ucParcelaVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ContextMenuStrip = this.cmsParcela;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblVencimentoParcela);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnlNumeroParcela);
            this.Controls.Add(this.pnlSituacaoParcela);
            this.Controls.Add(this.lblValorParcela);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucParcelaVenda";
            this.Size = new System.Drawing.Size(523, 100);
            this.Load += new System.EventHandler(this.ucParcelaVenda_Load);
            this.pnlSituacaoParcela.ResumeLayout(false);
            this.pnlNumeroParcela.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.cmsParcela.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValorParcela;
        private System.Windows.Forms.Panel pnlSituacaoParcela;
        private System.Windows.Forms.Label lblSituacaoParcela;
        private System.Windows.Forms.Panel pnlNumeroParcela;
        private System.Windows.Forms.Label lblNumeroParcela;
        private FontAwesome.Sharp.IconButton btnMudarSituacaoParcela;
        private System.Windows.Forms.Label lblVencimentoParcela;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip cmsParcela;
        private System.Windows.Forms.ToolStripMenuItem cancelarParcelaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mudarVencimentoDaParcelaToolStripMenuItem;
        private System.Windows.Forms.ToolTip tipParcela;
    }
}
