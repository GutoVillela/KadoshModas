namespace KadoshModas.UI
{
    partial class DetalhesVenda
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
            this.tbcDetalhesVenda = new System.Windows.Forms.TabControl();
            this.tbpDetalhesVenda = new System.Windows.Forms.TabPage();
            this.lblNomeDoCliente = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFormaDePagamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstItensDaVenda = new System.Windows.Forms.ListView();
            this.chQuantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPreco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDesconto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSituacaoVenda = new System.Windows.Forms.Panel();
            this.lblSituacaoVenda = new System.Windows.Forms.Label();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.tbpParcelas = new System.Windows.Forms.TabPage();
            this.btnQuitarParcelas = new FontAwesome.Sharp.IconButton();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblNumeroDeParcelas = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlParcelas = new System.Windows.Forms.FlowLayoutPanel();
            this.tbcDetalhesVenda.SuspendLayout();
            this.tbpDetalhesVenda.SuspendLayout();
            this.pnlSituacaoVenda.SuspendLayout();
            this.tbpParcelas.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcDetalhesVenda
            // 
            this.tbcDetalhesVenda.Controls.Add(this.tbpDetalhesVenda);
            this.tbcDetalhesVenda.Controls.Add(this.tbpParcelas);
            this.tbcDetalhesVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcDetalhesVenda.Location = new System.Drawing.Point(0, 0);
            this.tbcDetalhesVenda.Name = "tbcDetalhesVenda";
            this.tbcDetalhesVenda.SelectedIndex = 0;
            this.tbcDetalhesVenda.Size = new System.Drawing.Size(634, 541);
            this.tbcDetalhesVenda.TabIndex = 0;
            // 
            // tbpDetalhesVenda
            // 
            this.tbpDetalhesVenda.Controls.Add(this.lblNomeDoCliente);
            this.tbpDetalhesVenda.Controls.Add(this.label5);
            this.tbpDetalhesVenda.Controls.Add(this.label3);
            this.tbpDetalhesVenda.Controls.Add(this.label4);
            this.tbpDetalhesVenda.Controls.Add(this.lblFormaDePagamento);
            this.tbpDetalhesVenda.Controls.Add(this.label1);
            this.tbpDetalhesVenda.Controls.Add(this.label2);
            this.tbpDetalhesVenda.Controls.Add(this.lstItensDaVenda);
            this.tbpDetalhesVenda.Controls.Add(this.pnlSituacaoVenda);
            this.tbpDetalhesVenda.Location = new System.Drawing.Point(4, 28);
            this.tbpDetalhesVenda.Name = "tbpDetalhesVenda";
            this.tbpDetalhesVenda.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetalhesVenda.Size = new System.Drawing.Size(626, 509);
            this.tbpDetalhesVenda.TabIndex = 0;
            this.tbpDetalhesVenda.Text = "Detalhes da Venda";
            this.tbpDetalhesVenda.UseVisualStyleBackColor = true;
            // 
            // lblNomeDoCliente
            // 
            this.lblNomeDoCliente.AutoSize = true;
            this.lblNomeDoCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNomeDoCliente.Location = new System.Drawing.Point(4, 113);
            this.lblNomeDoCliente.Name = "lblNomeDoCliente";
            this.lblNomeDoCliente.Size = new System.Drawing.Size(122, 19);
            this.lblNomeDoCliente.TabIndex = 8;
            this.lblNomeDoCliente.Text = "Nome do Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 27);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(421, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "0%";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(416, 445);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Desconto na Venda";
            // 
            // lblFormaDePagamento
            // 
            this.lblFormaDePagamento.AutoSize = true;
            this.lblFormaDePagamento.Location = new System.Drawing.Point(9, 472);
            this.lblFormaDePagamento.Name = "lblFormaDePagamento";
            this.lblFormaDePagamento.Size = new System.Drawing.Size(152, 19);
            this.lblFormaDePagamento.TabIndex = 4;
            this.lblFormaDePagamento.Text = "Forma de Pagamento";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 445);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Forma de Pagamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Itens da Venda";
            // 
            // lstItensDaVenda
            // 
            this.lstItensDaVenda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chQuantidade,
            this.chProduto,
            this.chPreco,
            this.chDesconto});
            this.lstItensDaVenda.FullRowSelect = true;
            this.lstItensDaVenda.HideSelection = false;
            this.lstItensDaVenda.Location = new System.Drawing.Point(7, 171);
            this.lstItensDaVenda.Name = "lstItensDaVenda";
            this.lstItensDaVenda.Size = new System.Drawing.Size(613, 258);
            this.lstItensDaVenda.TabIndex = 1;
            this.lstItensDaVenda.UseCompatibleStateImageBehavior = false;
            this.lstItensDaVenda.View = System.Windows.Forms.View.Details;
            // 
            // chQuantidade
            // 
            this.chQuantidade.Text = "Quantidade";
            this.chQuantidade.Width = 100;
            // 
            // chProduto
            // 
            this.chProduto.Text = "Produto";
            this.chProduto.Width = 300;
            // 
            // chPreco
            // 
            this.chPreco.Text = "Preço";
            this.chPreco.Width = 100;
            // 
            // chDesconto
            // 
            this.chDesconto.Text = "Desconto";
            this.chDesconto.Width = 100;
            // 
            // pnlSituacaoVenda
            // 
            this.pnlSituacaoVenda.BackColor = System.Drawing.Color.DarkGreen;
            this.pnlSituacaoVenda.Controls.Add(this.lblSituacaoVenda);
            this.pnlSituacaoVenda.Controls.Add(this.lblTotalVenda);
            this.pnlSituacaoVenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSituacaoVenda.Location = new System.Drawing.Point(3, 3);
            this.pnlSituacaoVenda.Name = "pnlSituacaoVenda";
            this.pnlSituacaoVenda.Size = new System.Drawing.Size(620, 80);
            this.pnlSituacaoVenda.TabIndex = 0;
            // 
            // lblSituacaoVenda
            // 
            this.lblSituacaoVenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSituacaoVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSituacaoVenda.ForeColor = System.Drawing.Color.White;
            this.lblSituacaoVenda.Location = new System.Drawing.Point(0, 0);
            this.lblSituacaoVenda.Name = "lblSituacaoVenda";
            this.lblSituacaoVenda.Size = new System.Drawing.Size(620, 44);
            this.lblSituacaoVenda.TabIndex = 1;
            this.lblSituacaoVenda.Text = "Situação da Venda";
            this.lblSituacaoVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotalVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenda.ForeColor = System.Drawing.Color.White;
            this.lblTotalVenda.Location = new System.Drawing.Point(0, 43);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(620, 37);
            this.lblTotalVenda.TabIndex = 0;
            this.lblTotalVenda.Text = "R$ 100,00";
            this.lblTotalVenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbpParcelas
            // 
            this.tbpParcelas.Controls.Add(this.btnQuitarParcelas);
            this.tbpParcelas.Controls.Add(this.lblEntrada);
            this.tbpParcelas.Controls.Add(this.label8);
            this.tbpParcelas.Controls.Add(this.lblNumeroDeParcelas);
            this.tbpParcelas.Controls.Add(this.label6);
            this.tbpParcelas.Controls.Add(this.pnlParcelas);
            this.tbpParcelas.Location = new System.Drawing.Point(4, 22);
            this.tbpParcelas.Name = "tbpParcelas";
            this.tbpParcelas.Padding = new System.Windows.Forms.Padding(3);
            this.tbpParcelas.Size = new System.Drawing.Size(626, 515);
            this.tbpParcelas.TabIndex = 1;
            this.tbpParcelas.Text = "Parcelas";
            this.tbpParcelas.UseVisualStyleBackColor = true;
            // 
            // btnQuitarParcelas
            // 
            this.btnQuitarParcelas.BackColor = System.Drawing.Color.DarkGreen;
            this.btnQuitarParcelas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarParcelas.FlatAppearance.BorderSize = 0;
            this.btnQuitarParcelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarParcelas.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnQuitarParcelas.ForeColor = System.Drawing.Color.White;
            this.btnQuitarParcelas.IconChar = FontAwesome.Sharp.IconChar.HandHoldingUsd;
            this.btnQuitarParcelas.IconColor = System.Drawing.Color.GreenYellow;
            this.btnQuitarParcelas.IconSize = 20;
            this.btnQuitarParcelas.Location = new System.Drawing.Point(400, 84);
            this.btnQuitarParcelas.Name = "btnQuitarParcelas";
            this.btnQuitarParcelas.Rotation = 0D;
            this.btnQuitarParcelas.Size = new System.Drawing.Size(218, 27);
            this.btnQuitarParcelas.TabIndex = 9;
            this.btnQuitarParcelas.Text = "Quitar todas as Parcelas";
            this.btnQuitarParcelas.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnQuitarParcelas.UseVisualStyleBackColor = false;
            this.btnQuitarParcelas.Click += new System.EventHandler(this.btnQuitarParcelas_Click);
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Location = new System.Drawing.Point(9, 95);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(73, 19);
            this.lblEntrada.TabIndex = 8;
            this.lblEntrada.Text = "R$ 100,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 27);
            this.label8.TabIndex = 7;
            this.label8.Text = "Entrada";
            // 
            // lblNumeroDeParcelas
            // 
            this.lblNumeroDeParcelas.AutoSize = true;
            this.lblNumeroDeParcelas.Location = new System.Drawing.Point(9, 39);
            this.lblNumeroDeParcelas.Name = "lblNumeroDeParcelas";
            this.lblNumeroDeParcelas.Size = new System.Drawing.Size(501, 19);
            this.lblNumeroDeParcelas.TabIndex = 6;
            this.lblNumeroDeParcelas.Text = "10 (2 Pagas Sem Atraso, 2 Pagas com Atraso, 2 Em Aberto e 2 Canceladas)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 27);
            this.label6.TabIndex = 5;
            this.label6.Text = "Parcelas";
            // 
            // pnlParcelas
            // 
            this.pnlParcelas.AutoScroll = true;
            this.pnlParcelas.BackColor = System.Drawing.Color.Transparent;
            this.pnlParcelas.Location = new System.Drawing.Point(8, 117);
            this.pnlParcelas.Name = "pnlParcelas";
            this.pnlParcelas.Padding = new System.Windows.Forms.Padding(10);
            this.pnlParcelas.Size = new System.Drawing.Size(610, 384);
            this.pnlParcelas.TabIndex = 0;
            // 
            // DetalhesVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 541);
            this.Controls.Add(this.tbcDetalhesVenda);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DetalhesVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalhes da Venda";
            this.tbcDetalhesVenda.ResumeLayout(false);
            this.tbpDetalhesVenda.ResumeLayout(false);
            this.tbpDetalhesVenda.PerformLayout();
            this.pnlSituacaoVenda.ResumeLayout(false);
            this.tbpParcelas.ResumeLayout(false);
            this.tbpParcelas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcDetalhesVenda;
        private System.Windows.Forms.TabPage tbpDetalhesVenda;
        private System.Windows.Forms.TabPage tbpParcelas;
        private System.Windows.Forms.Panel pnlSituacaoVenda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lstItensDaVenda;
        private System.Windows.Forms.ColumnHeader chQuantidade;
        private System.Windows.Forms.ColumnHeader chProduto;
        private System.Windows.Forms.ColumnHeader chPreco;
        private System.Windows.Forms.ColumnHeader chDesconto;
        private System.Windows.Forms.Label lblSituacaoVenda;
        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.Label lblFormaDePagamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblNumeroDeParcelas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel pnlParcelas;
        private FontAwesome.Sharp.IconButton btnQuitarParcelas;
        private System.Windows.Forms.Label lblNomeDoCliente;
        private System.Windows.Forms.Label label5;
    }
}