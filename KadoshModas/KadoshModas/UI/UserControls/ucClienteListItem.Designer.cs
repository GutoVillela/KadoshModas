namespace KadoshModas.UI.UserControls
{
    partial class ucClienteListItem
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
            this.picFotoCliente = new System.Windows.Forms.PictureBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerFicha = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picFotoCliente
            // 
            this.picFotoCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFotoCliente.Image = global::KadoshModas.Properties.Resources.usuario_perfil_padrao;
            this.picFotoCliente.Location = new System.Drawing.Point(0, 0);
            this.picFotoCliente.Name = "picFotoCliente";
            this.picFotoCliente.Size = new System.Drawing.Size(100, 100);
            this.picFotoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFotoCliente.TabIndex = 0;
            this.picFotoCliente.TabStop = false;
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(106, 5);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(231, 34);
            this.lblNomeCliente.TabIndex = 1;
            this.lblNomeCliente.Text = "Nome do Cliente";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picFotoCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnVerFicha
            // 
            this.btnVerFicha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerFicha.BackColor = System.Drawing.Color.Cornsilk;
            this.btnVerFicha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerFicha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerFicha.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnVerFicha.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerFicha.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.btnVerFicha.IconColor = System.Drawing.Color.Black;
            this.btnVerFicha.IconSize = 30;
            this.btnVerFicha.Location = new System.Drawing.Point(532, 5);
            this.btnVerFicha.Name = "btnVerFicha";
            this.btnVerFicha.Rotation = 0D;
            this.btnVerFicha.Size = new System.Drawing.Size(75, 92);
            this.btnVerFicha.TabIndex = 3;
            this.btnVerFicha.Text = "Ver Ficha";
            this.btnVerFicha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerFicha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVerFicha.UseVisualStyleBackColor = false;
            this.btnVerFicha.Click += new System.EventHandler(this.btnVerFicha_Click);
            // 
            // ucClienteListItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.btnVerFicha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNomeCliente);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucClienteListItem";
            this.Size = new System.Drawing.Size(610, 100);
            this.Load += new System.EventHandler(this.ucClienteListItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoCliente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFotoCliente;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnVerFicha;
    }
}
