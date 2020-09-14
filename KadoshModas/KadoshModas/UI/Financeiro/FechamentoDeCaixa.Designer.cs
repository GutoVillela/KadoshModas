namespace KadoshModas.UI
{
    partial class FechamentoDeCaixa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFecharCaixa = new FontAwesome.Sharp.IconButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cdrDataFechamento = new System.Windows.Forms.MonthCalendar();
            this.lstLancamentos = new System.Windows.Forms.ListView();
            this.chNomeCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTipoLancamento = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chValor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblValorSaidaCaixa = new System.Windows.Forms.Label();
            this.lblValorEntradaCaixa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnFecharCaixa);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cdrDataFechamento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 622);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 21);
            this.label1.TabIndex = 22;
            this.label1.Text = "Data para fechar caixa:";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFecharCaixa.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnFecharCaixa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharCaixa.FlatAppearance.BorderSize = 0;
            this.btnFecharCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCaixa.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnFecharCaixa.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharCaixa.ForeColor = System.Drawing.Color.White;
            this.btnFecharCaixa.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnFecharCaixa.IconColor = System.Drawing.SystemColors.ControlDark;
            this.btnFecharCaixa.IconSize = 30;
            this.btnFecharCaixa.Location = new System.Drawing.Point(12, 542);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Rotation = 0D;
            this.btnFecharCaixa.Size = new System.Drawing.Size(211, 50);
            this.btnFecharCaixa.TabIndex = 28;
            this.btnFecharCaixa.Text = "Fechar caixa do dia selecionado";
            this.btnFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFecharCaixa.UseVisualStyleBackColor = false;
            this.btnFecharCaixa.Click += new System.EventHandler(this.btnFecharCaixa_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 77);
            this.panel4.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 62);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fechamento\r\nde Caixa";
            // 
            // cdrDataFechamento
            // 
            this.cdrDataFechamento.Location = new System.Drawing.Point(9, 128);
            this.cdrDataFechamento.MaxSelectionCount = 1;
            this.cdrDataFechamento.Name = "cdrDataFechamento";
            this.cdrDataFechamento.TabIndex = 3;
            this.cdrDataFechamento.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cdrDataFechamento_DateSelected);
            // 
            // lstLancamentos
            // 
            this.lstLancamentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstLancamentos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chNomeCliente,
            this.chTipoLancamento,
            this.chValor});
            this.lstLancamentos.FullRowSelect = true;
            this.lstLancamentos.HideSelection = false;
            this.lstLancamentos.Location = new System.Drawing.Point(248, 21);
            this.lstLancamentos.Name = "lstLancamentos";
            this.lstLancamentos.Size = new System.Drawing.Size(658, 421);
            this.lstLancamentos.TabIndex = 22;
            this.lstLancamentos.UseCompatibleStateImageBehavior = false;
            this.lstLancamentos.View = System.Windows.Forms.View.Details;
            // 
            // chNomeCliente
            // 
            this.chNomeCliente.Text = "Nome Cliente";
            this.chNomeCliente.Width = 281;
            // 
            // chTipoLancamento
            // 
            this.chTipoLancamento.Text = "Tipo de Lançamento";
            this.chTipoLancamento.Width = 199;
            // 
            // chValor
            // 
            this.chValor.Text = "Valor do Lançamento";
            this.chValor.Width = 172;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblValorSaidaCaixa);
            this.panel2.Controls.Add(this.lblValorEntradaCaixa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(240, 452);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(678, 170);
            this.panel2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(84, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 37);
            this.label5.TabIndex = 4;
            this.label5.Text = "Saída: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 37);
            this.label4.TabIndex = 3;
            this.label4.Text = "Entrada: ";
            // 
            // lblValorSaidaCaixa
            // 
            this.lblValorSaidaCaixa.AutoSize = true;
            this.lblValorSaidaCaixa.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorSaidaCaixa.ForeColor = System.Drawing.Color.Red;
            this.lblValorSaidaCaixa.Location = new System.Drawing.Point(199, 97);
            this.lblValorSaidaCaixa.Name = "lblValorSaidaCaixa";
            this.lblValorSaidaCaixa.Size = new System.Drawing.Size(71, 37);
            this.lblValorSaidaCaixa.TabIndex = 2;
            this.lblValorSaidaCaixa.Text = "R$ ?";
            // 
            // lblValorEntradaCaixa
            // 
            this.lblValorEntradaCaixa.AutoSize = true;
            this.lblValorEntradaCaixa.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorEntradaCaixa.Location = new System.Drawing.Point(199, 48);
            this.lblValorEntradaCaixa.Name = "lblValorEntradaCaixa";
            this.lblValorEntradaCaixa.Size = new System.Drawing.Size(71, 37);
            this.lblValorEntradaCaixa.TabIndex = 1;
            this.lblValorEntradaCaixa.Text = "R$ ?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Resumo do caixa:";
            // 
            // FechamentoDeCaixa
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lstLancamentos);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FechamentoDeCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fechamento de Caixa";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FechamentoDeCaixa_FormClosing);
            this.Load += new System.EventHandler(this.FechamentoDeCaixa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnFecharCaixa;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MonthCalendar cdrDataFechamento;
        private System.Windows.Forms.ListView lstLancamentos;
        private System.Windows.Forms.ColumnHeader chNomeCliente;
        private System.Windows.Forms.ColumnHeader chTipoLancamento;
        private System.Windows.Forms.ColumnHeader chValor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValorEntradaCaixa;
        private System.Windows.Forms.Label lblValorSaidaCaixa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}