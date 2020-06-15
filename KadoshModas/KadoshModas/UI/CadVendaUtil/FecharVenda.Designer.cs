namespace KadoshModas.UI
{
    partial class FecharVenda
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFormaDePagamento = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtAVista = new System.Windows.Forms.RadioButton();
            this.rbtAPrazo = new System.Windows.Forms.RadioButton();
            this.lblPrazoEm = new System.Windows.Forms.Label();
            this.cboQtdParcelas = new System.Windows.Forms.ComboBox();
            this.lblPrazoVezes = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trbDesconto = new System.Windows.Forms.TrackBar();
            this.lblDesconto = new System.Windows.Forms.Label();
            this.lblEntradaRotulo = new System.Windows.Forms.Label();
            this.lblEntrada = new System.Windows.Forms.Label();
            this.lblParcelasRotulo = new System.Windows.Forms.Label();
            this.lblParcelas = new System.Windows.Forms.Label();
            this.btnFecharVenda = new FontAwesome.Sharp.IconButton();
            this.btnCancelarFechamento = new FontAwesome.Sharp.IconButton();
            this.lblValorPagoRotulo = new System.Windows.Forms.Label();
            this.txtValorPago = new System.Windows.Forms.TextBox();
            this.lblTrocoRotulo = new System.Windows.Forms.Label();
            this.lblTroco = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.rbtFiado = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesconto)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(258, 13);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(120, 37);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "R$ 0,00";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 63);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Forma de pagamento:";
            // 
            // cboFormaDePagamento
            // 
            this.cboFormaDePagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormaDePagamento.FormattingEnabled = true;
            this.cboFormaDePagamento.Location = new System.Drawing.Point(201, 97);
            this.cboFormaDePagamento.Name = "cboFormaDePagamento";
            this.cboFormaDePagamento.Size = new System.Drawing.Size(443, 29);
            this.cboFormaDePagamento.TabIndex = 4;
            this.cboFormaDePagamento.SelectedIndexChanged += new System.EventHandler(this.cboFormaDePagamento_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Forma de pagamento:";
            // 
            // rbtAVista
            // 
            this.rbtAVista.AutoSize = true;
            this.rbtAVista.Checked = true;
            this.rbtAVista.Location = new System.Drawing.Point(201, 148);
            this.rbtAVista.Name = "rbtAVista";
            this.rbtAVista.Size = new System.Drawing.Size(76, 25);
            this.rbtAVista.TabIndex = 6;
            this.rbtAVista.TabStop = true;
            this.rbtAVista.Text = "À Vista";
            this.rbtAVista.UseVisualStyleBackColor = true;
            this.rbtAVista.CheckedChanged += new System.EventHandler(this.rbtAVista_CheckedChanged);
            // 
            // rbtAPrazo
            // 
            this.rbtAPrazo.AutoSize = true;
            this.rbtAPrazo.Location = new System.Drawing.Point(384, 148);
            this.rbtAPrazo.Name = "rbtAPrazo";
            this.rbtAPrazo.Size = new System.Drawing.Size(96, 25);
            this.rbtAPrazo.TabIndex = 7;
            this.rbtAPrazo.Text = "Parcelado";
            this.rbtAPrazo.UseVisualStyleBackColor = true;
            this.rbtAPrazo.CheckedChanged += new System.EventHandler(this.rbtAPrazo_CheckedChanged);
            // 
            // lblPrazoEm
            // 
            this.lblPrazoEm.AutoSize = true;
            this.lblPrazoEm.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrazoEm.Location = new System.Drawing.Point(486, 150);
            this.lblPrazoEm.Name = "lblPrazoEm";
            this.lblPrazoEm.Size = new System.Drawing.Size(34, 21);
            this.lblPrazoEm.TabIndex = 8;
            this.lblPrazoEm.Text = "Em";
            this.lblPrazoEm.Visible = false;
            // 
            // cboQtdParcelas
            // 
            this.cboQtdParcelas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQtdParcelas.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQtdParcelas.FormattingEnabled = true;
            this.cboQtdParcelas.Items.AddRange(new object[] {
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboQtdParcelas.Location = new System.Drawing.Point(526, 147);
            this.cboQtdParcelas.Name = "cboQtdParcelas";
            this.cboQtdParcelas.Size = new System.Drawing.Size(60, 29);
            this.cboQtdParcelas.TabIndex = 9;
            this.cboQtdParcelas.Visible = false;
            this.cboQtdParcelas.SelectedIndexChanged += new System.EventHandler(this.cboQtdParcelas_SelectedIndexChanged);
            // 
            // lblPrazoVezes
            // 
            this.lblPrazoVezes.AutoSize = true;
            this.lblPrazoVezes.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrazoVezes.Location = new System.Drawing.Point(592, 150);
            this.lblPrazoVezes.Name = "lblPrazoVezes";
            this.lblPrazoVezes.Size = new System.Drawing.Size(52, 21);
            this.lblPrazoVezes.TabIndex = 10;
            this.lblPrazoVezes.Text = "vezes";
            this.lblPrazoVezes.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "Desconto:";
            // 
            // trbDesconto
            // 
            this.trbDesconto.Location = new System.Drawing.Point(201, 200);
            this.trbDesconto.Maximum = 100;
            this.trbDesconto.Name = "trbDesconto";
            this.trbDesconto.Size = new System.Drawing.Size(404, 45);
            this.trbDesconto.TabIndex = 12;
            this.trbDesconto.ValueChanged += new System.EventHandler(this.trbDesconto_ValueChanged);
            // 
            // lblDesconto
            // 
            this.lblDesconto.AutoSize = true;
            this.lblDesconto.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesconto.Location = new System.Drawing.Point(611, 200);
            this.lblDesconto.Name = "lblDesconto";
            this.lblDesconto.Size = new System.Drawing.Size(33, 21);
            this.lblDesconto.TabIndex = 13;
            this.lblDesconto.Text = "0%";
            this.lblDesconto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntradaRotulo
            // 
            this.lblEntradaRotulo.AutoSize = true;
            this.lblEntradaRotulo.Location = new System.Drawing.Point(129, 250);
            this.lblEntradaRotulo.Name = "lblEntradaRotulo";
            this.lblEntradaRotulo.Size = new System.Drawing.Size(66, 21);
            this.lblEntradaRotulo.TabIndex = 14;
            this.lblEntradaRotulo.Text = "Entrada:";
            this.lblEntradaRotulo.Visible = false;
            // 
            // lblEntrada
            // 
            this.lblEntrada.AutoSize = true;
            this.lblEntrada.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntrada.Location = new System.Drawing.Point(393, 250);
            this.lblEntrada.Name = "lblEntrada";
            this.lblEntrada.Size = new System.Drawing.Size(64, 21);
            this.lblEntrada.TabIndex = 16;
            this.lblEntrada.Text = "R$ 0,00";
            this.lblEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEntrada.Visible = false;
            // 
            // lblParcelasRotulo
            // 
            this.lblParcelasRotulo.AutoSize = true;
            this.lblParcelasRotulo.Location = new System.Drawing.Point(125, 310);
            this.lblParcelasRotulo.Name = "lblParcelasRotulo";
            this.lblParcelasRotulo.Size = new System.Drawing.Size(70, 21);
            this.lblParcelasRotulo.TabIndex = 17;
            this.lblParcelasRotulo.Text = "Parcelas:";
            this.lblParcelasRotulo.Visible = false;
            // 
            // lblParcelas
            // 
            this.lblParcelas.AutoSize = true;
            this.lblParcelas.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParcelas.Location = new System.Drawing.Point(201, 300);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(229, 34);
            this.lblParcelas.TabIndex = 18;
            this.lblParcelas.Text = "12x de R$100,00";
            this.lblParcelas.Visible = false;
            // 
            // btnFecharVenda
            // 
            this.btnFecharVenda.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFecharVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharVenda.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFecharVenda.FlatAppearance.BorderSize = 0;
            this.btnFecharVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharVenda.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnFecharVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharVenda.ForeColor = System.Drawing.Color.White;
            this.btnFecharVenda.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnFecharVenda.IconColor = System.Drawing.Color.DarkGreen;
            this.btnFecharVenda.IconSize = 30;
            this.btnFecharVenda.Location = new System.Drawing.Point(425, 10);
            this.btnFecharVenda.Name = "btnFecharVenda";
            this.btnFecharVenda.Rotation = 0D;
            this.btnFecharVenda.Size = new System.Drawing.Size(232, 55);
            this.btnFecharVenda.TabIndex = 19;
            this.btnFecharVenda.Text = "Fechar Venda";
            this.btnFecharVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFecharVenda.UseVisualStyleBackColor = false;
            this.btnFecharVenda.Click += new System.EventHandler(this.btnFecharVenda_Click);
            // 
            // btnCancelarFechamento
            // 
            this.btnCancelarFechamento.BackColor = System.Drawing.Color.Red;
            this.btnCancelarFechamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarFechamento.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancelarFechamento.FlatAppearance.BorderSize = 0;
            this.btnCancelarFechamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarFechamento.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancelarFechamento.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarFechamento.ForeColor = System.Drawing.Color.White;
            this.btnCancelarFechamento.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnCancelarFechamento.IconColor = System.Drawing.Color.Maroon;
            this.btnCancelarFechamento.IconSize = 30;
            this.btnCancelarFechamento.Location = new System.Drawing.Point(10, 10);
            this.btnCancelarFechamento.Name = "btnCancelarFechamento";
            this.btnCancelarFechamento.Rotation = 0D;
            this.btnCancelarFechamento.Size = new System.Drawing.Size(232, 55);
            this.btnCancelarFechamento.TabIndex = 20;
            this.btnCancelarFechamento.Text = "Cancelar Fechamento";
            this.btnCancelarFechamento.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelarFechamento.UseVisualStyleBackColor = false;
            this.btnCancelarFechamento.Click += new System.EventHandler(this.btnCancelarFechamento_Click);
            // 
            // lblValorPagoRotulo
            // 
            this.lblValorPagoRotulo.AutoSize = true;
            this.lblValorPagoRotulo.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorPagoRotulo.Location = new System.Drawing.Point(34, 29);
            this.lblValorPagoRotulo.Name = "lblValorPagoRotulo";
            this.lblValorPagoRotulo.Size = new System.Drawing.Size(107, 23);
            this.lblValorPagoRotulo.TabIndex = 21;
            this.lblValorPagoRotulo.Text = "Valor Pago:";
            this.lblValorPagoRotulo.Visible = false;
            // 
            // txtValorPago
            // 
            this.txtValorPago.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorPago.Location = new System.Drawing.Point(147, 26);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Size = new System.Drawing.Size(137, 32);
            this.txtValorPago.TabIndex = 22;
            this.txtValorPago.TextChanged += new System.EventHandler(this.txtValorPago_TextChanged);
            this.txtValorPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorPago_KeyPress);
            // 
            // lblTrocoRotulo
            // 
            this.lblTrocoRotulo.AutoSize = true;
            this.lblTrocoRotulo.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrocoRotulo.Location = new System.Drawing.Point(309, 29);
            this.lblTrocoRotulo.Name = "lblTrocoRotulo";
            this.lblTrocoRotulo.Size = new System.Drawing.Size(62, 23);
            this.lblTrocoRotulo.TabIndex = 23;
            this.lblTrocoRotulo.Text = "Troco:";
            this.lblTrocoRotulo.Visible = false;
            // 
            // lblTroco
            // 
            this.lblTroco.AutoSize = true;
            this.lblTroco.Font = new System.Drawing.Font("Microsoft Tai Le", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTroco.Location = new System.Drawing.Point(377, 19);
            this.lblTroco.Name = "lblTroco";
            this.lblTroco.Size = new System.Drawing.Size(120, 37);
            this.lblTroco.TabIndex = 2;
            this.lblTroco.Text = "R$ 0,00";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.btnFecharVenda);
            this.panel2.Controls.Add(this.btnCancelarFechamento);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 492);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(667, 75);
            this.panel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.txtValorPago);
            this.panel3.Controls.Add(this.lblValorPagoRotulo);
            this.panel3.Controls.Add(this.lblTroco);
            this.panel3.Controls.Add(this.lblTrocoRotulo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 412);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 80);
            this.panel3.TabIndex = 25;
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(201, 247);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(186, 28);
            this.txtEntrada.TabIndex = 26;
            this.txtEntrada.Visible = false;
            this.txtEntrada.TextChanged += new System.EventHandler(this.txtEntrada_TextChanged);
            this.txtEntrada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEntrada_KeyPress);
            // 
            // rbtFiado
            // 
            this.rbtFiado.AutoSize = true;
            this.rbtFiado.Location = new System.Drawing.Point(293, 148);
            this.rbtFiado.Name = "rbtFiado";
            this.rbtFiado.Size = new System.Drawing.Size(66, 25);
            this.rbtFiado.TabIndex = 27;
            this.rbtFiado.Text = "Fiado";
            this.rbtFiado.UseVisualStyleBackColor = true;
            this.rbtFiado.CheckedChanged += new System.EventHandler(this.rbtFiado_CheckedChanged);
            // 
            // FecharVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 567);
            this.Controls.Add(this.rbtFiado);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.lblParcelasRotulo);
            this.Controls.Add(this.lblEntrada);
            this.Controls.Add(this.lblEntradaRotulo);
            this.Controls.Add(this.lblDesconto);
            this.Controls.Add(this.trbDesconto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPrazoVezes);
            this.Controls.Add(this.cboQtdParcelas);
            this.Controls.Add(this.lblPrazoEm);
            this.Controls.Add(this.rbtAPrazo);
            this.Controls.Add(this.rbtAVista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboFormaDePagamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FecharVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kadosh Modas - Fechar Venda";
            this.Load += new System.EventHandler(this.FecharVenda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbDesconto)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFormaDePagamento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtAVista;
        private System.Windows.Forms.RadioButton rbtAPrazo;
        private System.Windows.Forms.Label lblPrazoEm;
        private System.Windows.Forms.ComboBox cboQtdParcelas;
        private System.Windows.Forms.Label lblPrazoVezes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trbDesconto;
        private System.Windows.Forms.Label lblDesconto;
        private System.Windows.Forms.Label lblEntradaRotulo;
        private System.Windows.Forms.Label lblEntrada;
        private System.Windows.Forms.Label lblParcelasRotulo;
        private System.Windows.Forms.Label lblParcelas;
        private FontAwesome.Sharp.IconButton btnFecharVenda;
        private FontAwesome.Sharp.IconButton btnCancelarFechamento;
        private System.Windows.Forms.Label lblValorPagoRotulo;
        private System.Windows.Forms.TextBox txtValorPago;
        private System.Windows.Forms.Label lblTrocoRotulo;
        private System.Windows.Forms.Label lblTroco;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.RadioButton rbtFiado;
    }
}