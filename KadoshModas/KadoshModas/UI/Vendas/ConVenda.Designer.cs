namespace KadoshModas.UI
{
    partial class ConVenda
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
            this.pnlVendas = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlNenhumaVenda = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.cdrFiltroData = new System.Windows.Forms.MonthCalendar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarTodos = new FontAwesome.Sharp.IconButton();
            this.cklSituacoesVenda = new System.Windows.Forms.CheckedListBox();
            this.chkAPrazo = new System.Windows.Forms.CheckBox();
            this.chkAVista = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlPaginacaoBusca = new System.Windows.Forms.Panel();
            this.btnUltimoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnProximoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnAnteriorPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnInicioPaginacao = new FontAwesome.Sharp.IconButton();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.tipConVendas = new System.Windows.Forms.ToolTip(this.components);
            this.pnlVendas.SuspendLayout();
            this.pnlNenhumaVenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.pnlPaginacaoBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVendas
            // 
            this.pnlVendas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlVendas.AutoScroll = true;
            this.pnlVendas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlVendas.Controls.Add(this.pnlNenhumaVenda);
            this.pnlVendas.Location = new System.Drawing.Point(246, 4);
            this.pnlVendas.Name = "pnlVendas";
            this.pnlVendas.Size = new System.Drawing.Size(671, 552);
            this.pnlVendas.TabIndex = 0;
            // 
            // pnlNenhumaVenda
            // 
            this.pnlNenhumaVenda.Controls.Add(this.label10);
            this.pnlNenhumaVenda.Controls.Add(this.label9);
            this.pnlNenhumaVenda.Controls.Add(this.iconPictureBox1);
            this.pnlNenhumaVenda.Location = new System.Drawing.Point(3, 3);
            this.pnlNenhumaVenda.Name = "pnlNenhumaVenda";
            this.pnlNenhumaVenda.Size = new System.Drawing.Size(657, 530);
            this.pnlNenhumaVenda.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(110, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(260, 87);
            this.label10.TabIndex = 5;
            this.label10.Text = "Parece que não existe nenhuma Venda cadastrada no sistema.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(109, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 31);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ops...";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ShoppingBasket;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlDarkDark;
            this.iconPictureBox1.IconSize = 100;
            this.iconPictureBox1.Location = new System.Drawing.Point(3, 203);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(100, 100);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox1.TabIndex = 3;
            this.iconPictureBox1.TabStop = false;
            // 
            // cdrFiltroData
            // 
            this.cdrFiltroData.Location = new System.Drawing.Point(9, 52);
            this.cdrFiltroData.MaxSelectionCount = 366;
            this.cdrFiltroData.Name = "cdrFiltroData";
            this.cdrFiltroData.SelectionRange = new System.Windows.Forms.SelectionRange(new System.DateTime(2020, 5, 24, 0, 0, 0, 0), new System.DateTime(2020, 5, 25, 0, 0, 0, 0));
            this.cdrFiltroData.TabIndex = 3;
            this.cdrFiltroData.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.cdrFiltroData_DateSelected);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btnBuscarTodos);
            this.panel1.Controls.Add(this.cklSituacoesVenda);
            this.panel1.Controls.Add(this.chkAPrazo);
            this.panel1.Controls.Add(this.chkAVista);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cdrFiltroData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 622);
            this.panel1.TabIndex = 20;
            // 
            // btnBuscarTodos
            // 
            this.btnBuscarTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuscarTodos.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBuscarTodos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarTodos.FlatAppearance.BorderSize = 0;
            this.btnBuscarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarTodos.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBuscarTodos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarTodos.ForeColor = System.Drawing.Color.White;
            this.btnBuscarTodos.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarTodos.IconColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarTodos.IconSize = 30;
            this.btnBuscarTodos.Location = new System.Drawing.Point(12, 542);
            this.btnBuscarTodos.Name = "btnBuscarTodos";
            this.btnBuscarTodos.Rotation = 0D;
            this.btnBuscarTodos.Size = new System.Drawing.Size(211, 50);
            this.btnBuscarTodos.TabIndex = 28;
            this.btnBuscarTodos.Text = "Buscar Todas as Vendas";
            this.btnBuscarTodos.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscarTodos.UseVisualStyleBackColor = false;
            this.btnBuscarTodos.Click += new System.EventHandler(this.btnBuscarTodos_Click);
            // 
            // cklSituacoesVenda
            // 
            this.cklSituacoesVenda.CheckOnClick = true;
            this.cklSituacoesVenda.FormattingEnabled = true;
            this.cklSituacoesVenda.Items.AddRange(new object[] {
            "Em Aberto",
            "Concluído",
            "Cancelado"});
            this.cklSituacoesVenda.Location = new System.Drawing.Point(9, 249);
            this.cklSituacoesVenda.Name = "cklSituacoesVenda";
            this.cklSituacoesVenda.Size = new System.Drawing.Size(227, 73);
            this.cklSituacoesVenda.TabIndex = 27;
            this.cklSituacoesVenda.SelectedValueChanged += new System.EventHandler(this.cklSituacoesVenda_SelectedValueChanged);
            // 
            // chkAPrazo
            // 
            this.chkAPrazo.AutoSize = true;
            this.chkAPrazo.Checked = true;
            this.chkAPrazo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAPrazo.Location = new System.Drawing.Point(92, 328);
            this.chkAPrazo.Name = "chkAPrazo";
            this.chkAPrazo.Size = new System.Drawing.Size(82, 25);
            this.chkAPrazo.TabIndex = 26;
            this.chkAPrazo.Text = "A Prazo";
            this.chkAPrazo.UseVisualStyleBackColor = true;
            // 
            // chkAVista
            // 
            this.chkAVista.AutoSize = true;
            this.chkAVista.Checked = true;
            this.chkAVista.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAVista.Location = new System.Drawing.Point(9, 328);
            this.chkAVista.Name = "chkAVista";
            this.chkAVista.Size = new System.Drawing.Size(77, 25);
            this.chkAVista.TabIndex = 25;
            this.chkAVista.Text = "À Vista";
            this.chkAVista.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 21);
            this.label3.TabIndex = 21;
            this.label3.Text = "Situação da Venda:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Controls.Add(this.iconPictureBox2);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 49);
            this.panel4.TabIndex = 20;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.DimGray;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Filter;
            this.iconPictureBox2.IconColor = System.Drawing.Color.White;
            this.iconPictureBox2.Location = new System.Drawing.Point(103, 8);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 3;
            this.iconPictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filtros";
            // 
            // pnlPaginacaoBusca
            // 
            this.pnlPaginacaoBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaginacaoBusca.Controls.Add(this.btnUltimoPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnProximoPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnAnteriorPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.btnInicioPaginacao);
            this.pnlPaginacaoBusca.Controls.Add(this.lblRegistros);
            this.pnlPaginacaoBusca.Location = new System.Drawing.Point(246, 562);
            this.pnlPaginacaoBusca.Name = "pnlPaginacaoBusca";
            this.pnlPaginacaoBusca.Size = new System.Drawing.Size(660, 30);
            this.pnlPaginacaoBusca.TabIndex = 21;
            // 
            // btnUltimoPaginacao
            // 
            this.btnUltimoPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltimoPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUltimoPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnUltimoPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnUltimoPaginacao.IconSize = 20;
            this.btnUltimoPaginacao.Location = new System.Drawing.Point(550, 3);
            this.btnUltimoPaginacao.Name = "btnUltimoPaginacao";
            this.btnUltimoPaginacao.Rotation = 0D;
            this.btnUltimoPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnUltimoPaginacao.TabIndex = 4;
            this.btnUltimoPaginacao.Text = "Último";
            this.btnUltimoPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUltimoPaginacao.UseVisualStyleBackColor = true;
            this.btnUltimoPaginacao.Click += new System.EventHandler(this.btnUltimoPaginacao_Click);
            // 
            // btnProximoPaginacao
            // 
            this.btnProximoPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProximoPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnProximoPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnProximoPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnProximoPaginacao.IconSize = 20;
            this.btnProximoPaginacao.Location = new System.Drawing.Point(444, 3);
            this.btnProximoPaginacao.Name = "btnProximoPaginacao";
            this.btnProximoPaginacao.Rotation = 0D;
            this.btnProximoPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnProximoPaginacao.TabIndex = 3;
            this.btnProximoPaginacao.Text = "Próximo";
            this.btnProximoPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProximoPaginacao.UseVisualStyleBackColor = true;
            this.btnProximoPaginacao.Click += new System.EventHandler(this.btnProximoPaginacao_Click);
            // 
            // btnAnteriorPaginacao
            // 
            this.btnAnteriorPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnteriorPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAnteriorPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnAnteriorPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnAnteriorPaginacao.IconSize = 20;
            this.btnAnteriorPaginacao.Location = new System.Drawing.Point(338, 3);
            this.btnAnteriorPaginacao.Name = "btnAnteriorPaginacao";
            this.btnAnteriorPaginacao.Rotation = 0D;
            this.btnAnteriorPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnAnteriorPaginacao.TabIndex = 2;
            this.btnAnteriorPaginacao.Text = "Anterior";
            this.btnAnteriorPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnteriorPaginacao.UseVisualStyleBackColor = true;
            this.btnAnteriorPaginacao.Click += new System.EventHandler(this.btnAnteriorPaginacao_Click);
            // 
            // btnInicioPaginacao
            // 
            this.btnInicioPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicioPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnInicioPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnInicioPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnInicioPaginacao.IconSize = 20;
            this.btnInicioPaginacao.Location = new System.Drawing.Point(232, 3);
            this.btnInicioPaginacao.Name = "btnInicioPaginacao";
            this.btnInicioPaginacao.Rotation = 0D;
            this.btnInicioPaginacao.Size = new System.Drawing.Size(100, 23);
            this.btnInicioPaginacao.TabIndex = 1;
            this.btnInicioPaginacao.Text = "Início";
            this.btnInicioPaginacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInicioPaginacao.UseVisualStyleBackColor = true;
            this.btnInicioPaginacao.Click += new System.EventHandler(this.btnInicioPaginacao_Click);
            // 
            // lblRegistros
            // 
            this.lblRegistros.AutoSize = true;
            this.lblRegistros.Location = new System.Drawing.Point(3, 4);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(202, 21);
            this.lblRegistros.TabIndex = 0;
            this.lblRegistros.Text = "Exibindo registros de 0 a 10";
            // 
            // ConVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.pnlPaginacaoBusca);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlVendas);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ConVenda";
            this.Load += new System.EventHandler(this.ConVenda_Load);
            this.pnlVendas.ResumeLayout(false);
            this.pnlNenhumaVenda.ResumeLayout(false);
            this.pnlNenhumaVenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.pnlPaginacaoBusca.ResumeLayout(false);
            this.pnlPaginacaoBusca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlVendas;
        private System.Windows.Forms.MonthCalendar cdrFiltroData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlNenhumaVenda;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkAPrazo;
        private System.Windows.Forms.CheckBox chkAVista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox cklSituacoesVenda;
        private FontAwesome.Sharp.IconButton btnBuscarTodos;
        private System.Windows.Forms.Panel pnlPaginacaoBusca;
        private FontAwesome.Sharp.IconButton btnUltimoPaginacao;
        private FontAwesome.Sharp.IconButton btnProximoPaginacao;
        private FontAwesome.Sharp.IconButton btnAnteriorPaginacao;
        private FontAwesome.Sharp.IconButton btnInicioPaginacao;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.ToolTip tipConVendas;
    }
}