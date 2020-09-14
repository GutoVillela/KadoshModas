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
            this.pnlPaginacaoBusca = new System.Windows.Forms.Panel();
            this.btnUltimoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnProximoPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnAnteriorPaginacao = new FontAwesome.Sharp.IconButton();
            this.btnInicioPaginacao = new FontAwesome.Sharp.IconButton();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.pnlPaginacaoBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsulta
            // 
            this.txtConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConsulta.Location = new System.Drawing.Point(12, 45);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(739, 28);
            this.txtConsulta.TabIndex = 1;
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
            this.pnlConCliente.BackColor = System.Drawing.Color.White;
            this.pnlConCliente.Location = new System.Drawing.Point(12, 110);
            this.pnlConCliente.Name = "pnlConCliente";
            this.pnlConCliente.Size = new System.Drawing.Size(894, 446);
            this.pnlConCliente.TabIndex = 3;
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
            this.pnlPaginacaoBusca.Location = new System.Drawing.Point(12, 562);
            this.pnlPaginacaoBusca.Name = "pnlPaginacaoBusca";
            this.pnlPaginacaoBusca.Size = new System.Drawing.Size(894, 30);
            this.pnlPaginacaoBusca.TabIndex = 4;
            // 
            // btnUltimoPaginacao
            // 
            this.btnUltimoPaginacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltimoPaginacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnUltimoPaginacao.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnUltimoPaginacao.IconColor = System.Drawing.Color.Black;
            this.btnUltimoPaginacao.IconSize = 20;
            this.btnUltimoPaginacao.Location = new System.Drawing.Point(570, 3);
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
            this.btnProximoPaginacao.Location = new System.Drawing.Point(464, 3);
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
            this.btnAnteriorPaginacao.Location = new System.Drawing.Point(358, 3);
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
            this.btnInicioPaginacao.Location = new System.Drawing.Point(252, 3);
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
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconSize = 20;
            this.btnBuscar.Location = new System.Drawing.Point(757, 45);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Rotation = 0D;
            this.btnBuscar.Size = new System.Drawing.Size(149, 28);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // ConCliente
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(918, 622);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.pnlPaginacaoBusca);
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
            this.pnlPaginacaoBusca.ResumeLayout(false);
            this.pnlPaginacaoBusca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.RadioButton rbtCPF;
        private System.Windows.Forms.RadioButton rbtNome;
        private System.Windows.Forms.FlowLayoutPanel pnlConCliente;
        private System.Windows.Forms.Panel pnlPaginacaoBusca;
        private System.Windows.Forms.Label lblRegistros;
        private FontAwesome.Sharp.IconButton btnUltimoPaginacao;
        private FontAwesome.Sharp.IconButton btnProximoPaginacao;
        private FontAwesome.Sharp.IconButton btnAnteriorPaginacao;
        private FontAwesome.Sharp.IconButton btnInicioPaginacao;
        private FontAwesome.Sharp.IconButton btnBuscar;
    }
}