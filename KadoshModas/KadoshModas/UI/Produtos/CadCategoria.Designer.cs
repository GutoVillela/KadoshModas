namespace KadoshModas.UI
{
    partial class CadCategoria
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFiltroCategoria = new System.Windows.Forms.TextBox();
            this.dgvCategorias = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsGridCategoria = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apagarCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCadCategoria = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
            this.cmsGridCategoria.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 511);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFiltroCategoria);
            this.groupBox2.Controls.Add(this.dgvCategorias);
            this.groupBox2.Location = new System.Drawing.Point(12, 140);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(610, 342);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Categorias cadastradas";
            // 
            // txtFiltroCategoria
            // 
            this.txtFiltroCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.txtFiltroCategoria.Location = new System.Drawing.Point(22, 40);
            this.txtFiltroCategoria.Name = "txtFiltroCategoria";
            this.txtFiltroCategoria.Size = new System.Drawing.Size(570, 28);
            this.txtFiltroCategoria.TabIndex = 4;
            this.txtFiltroCategoria.TextChanged += new System.EventHandler(this.txtFiltroCategoria_TextChanged);
            // 
            // dgvCategorias
            // 
            this.dgvCategorias.AllowUserToAddRows = false;
            this.dgvCategorias.AllowUserToDeleteRows = false;
            this.dgvCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvCategorias.ContextMenuStrip = this.cmsGridCategoria;
            this.dgvCategorias.Location = new System.Drawing.Point(22, 74);
            this.dgvCategorias.Name = "dgvCategorias";
            this.dgvCategorias.RowHeadersVisible = false;
            this.dgvCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategorias.Size = new System.Drawing.Size(570, 249);
            this.dgvCategorias.TabIndex = 0;
            this.dgvCategorias.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategorias_CellEndEdit);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Categoria";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "Ativo";
            this.Column2.Name = "Column2";
            // 
            // cmsGridCategoria
            // 
            this.cmsGridCategoria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apagarCategoriaToolStripMenuItem});
            this.cmsGridCategoria.Name = "cmsGridCategoria";
            this.cmsGridCategoria.Size = new System.Drawing.Size(167, 26);
            // 
            // apagarCategoriaToolStripMenuItem
            // 
            this.apagarCategoriaToolStripMenuItem.Name = "apagarCategoriaToolStripMenuItem";
            this.apagarCategoriaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.apagarCategoriaToolStripMenuItem.Text = "Apagar Categoria";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCadCategoria);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCategoria);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 107);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastrar nova categoria";
            // 
            // btnCadCategoria
            // 
            this.btnCadCategoria.BackColor = System.Drawing.Color.Green;
            this.btnCadCategoria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadCategoria.FlatAppearance.BorderSize = 0;
            this.btnCadCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCadCategoria.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCadCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadCategoria.ForeColor = System.Drawing.Color.White;
            this.btnCadCategoria.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnCadCategoria.IconColor = System.Drawing.Color.SpringGreen;
            this.btnCadCategoria.IconSize = 20;
            this.btnCadCategoria.Location = new System.Drawing.Point(472, 46);
            this.btnCadCategoria.Name = "btnCadCategoria";
            this.btnCadCategoria.Rotation = 0D;
            this.btnCadCategoria.Size = new System.Drawing.Size(120, 28);
            this.btnCadCategoria.TabIndex = 3;
            this.btnCadCategoria.Text = "Cadastrar";
            this.btnCadCategoria.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCadCategoria.UseVisualStyleBackColor = false;
            this.btnCadCategoria.Click += new System.EventHandler(this.btnCadCategoria_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoria: ";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.txtCategoria.Location = new System.Drawing.Point(124, 46);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(342, 28);
            this.txtCategoria.TabIndex = 1;
            // 
            // CadCategoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "CadCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CadCategoria";
            this.Load += new System.EventHandler(this.CadCategoria_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
            this.cmsGridCategoria.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private FontAwesome.Sharp.IconButton btnCadCategoria;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFiltroCategoria;
        private System.Windows.Forms.DataGridView dgvCategorias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.ContextMenuStrip cmsGridCategoria;
        private System.Windows.Forms.ToolStripMenuItem apagarCategoriaToolStripMenuItem;
    }
}