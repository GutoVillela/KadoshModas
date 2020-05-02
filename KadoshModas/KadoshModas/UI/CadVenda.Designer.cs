namespace KadoshModas.UI
{
    partial class CadVenda
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItensDaVenda = new System.Windows.Forms.DataGridView();
            this.lblTotalVenda = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAddProduto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddProduto = new FontAwesome.Sharp.IconButton();
            this.btnCancelarVenda = new FontAwesome.Sharp.IconButton();
            this.btnFecharVenda = new FontAwesome.Sharp.IconButton();
            this.btnDefinirCliente = new FontAwesome.Sharp.IconButton();
            this.btnRemoverCliente = new FontAwesome.Sharp.IconButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dmoItemDaVendaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDaVenda)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dmoItemDaVendaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente: ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(83, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(332, 28);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(464, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "Venda Nº:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(550, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 27);
            this.label4.TabIndex = 28;
            this.label4.Text = "00001";
            // 
            // dgvItensDaVenda
            // 
            this.dgvItensDaVenda.AllowUserToAddRows = false;
            this.dgvItensDaVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItensDaVenda.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvItensDaVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensDaVenda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Produto,
            this.Quantidade,
            this.Preco,
            this.Subtotal});
            this.dgvItensDaVenda.Location = new System.Drawing.Point(6, 59);
            this.dgvItensDaVenda.Name = "dgvItensDaVenda";
            this.dgvItensDaVenda.RowHeadersVisible = false;
            this.dgvItensDaVenda.Size = new System.Drawing.Size(594, 198);
            this.dgvItensDaVenda.TabIndex = 29;
            // 
            // lblTotalVenda
            // 
            this.lblTotalVenda.AutoSize = true;
            this.lblTotalVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenda.Location = new System.Drawing.Point(511, 379);
            this.lblTotalVenda.Name = "lblTotalVenda";
            this.lblTotalVenda.Size = new System.Drawing.Size(111, 34);
            this.lblTotalVenda.TabIndex = 32;
            this.lblTotalVenda.Text = "R$ 0,00";
            this.lblTotalVenda.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(370, 382);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 30);
            this.label6.TabIndex = 31;
            this.label6.Text = "Total:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAddProduto);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnAddProduto);
            this.groupBox1.Controls.Add(this.dgvItensDaVenda);
            this.groupBox1.Location = new System.Drawing.Point(16, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 267);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Itens da Venda";
            // 
            // txtAddProduto
            // 
            this.txtAddProduto.Location = new System.Drawing.Point(160, 25);
            this.txtAddProduto.Name = "txtAddProduto";
            this.txtAddProduto.Size = new System.Drawing.Size(286, 28);
            this.txtAddProduto.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 21);
            this.label7.TabIndex = 34;
            this.label7.Text = "Código do Produto:";
            // 
            // btnAddProduto
            // 
            this.btnAddProduto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduto.FlatAppearance.BorderSize = 0;
            this.btnAddProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduto.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnAddProduto.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduto.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.btnAddProduto.IconColor = System.Drawing.Color.MidnightBlue;
            this.btnAddProduto.IconSize = 16;
            this.btnAddProduto.Location = new System.Drawing.Point(452, 25);
            this.btnAddProduto.Name = "btnAddProduto";
            this.btnAddProduto.Rotation = 0D;
            this.btnAddProduto.Size = new System.Drawing.Size(148, 28);
            this.btnAddProduto.TabIndex = 33;
            this.btnAddProduto.Text = "Adicionar produto";
            this.btnAddProduto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAddProduto.UseVisualStyleBackColor = false;
            this.btnAddProduto.Click += new System.EventHandler(this.btnAddProduto_Click);
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.Red;
            this.btnCancelarVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenda.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCancelarVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenda.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenda.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnCancelarVenda.IconColor = System.Drawing.Color.DarkRed;
            this.btnCancelarVenda.IconSize = 30;
            this.btnCancelarVenda.Location = new System.Drawing.Point(16, 429);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Padding = new System.Windows.Forms.Padding(10);
            this.btnCancelarVenda.Rotation = 0D;
            this.btnCancelarVenda.Size = new System.Drawing.Size(215, 70);
            this.btnCancelarVenda.TabIndex = 30;
            this.btnCancelarVenda.Text = "CANCELAR VENDA";
            this.btnCancelarVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            // 
            // btnFecharVenda
            // 
            this.btnFecharVenda.BackColor = System.Drawing.Color.ForestGreen;
            this.btnFecharVenda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFecharVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharVenda.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnFecharVenda.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharVenda.ForeColor = System.Drawing.Color.White;
            this.btnFecharVenda.IconChar = FontAwesome.Sharp.IconChar.DollarSign;
            this.btnFecharVenda.IconColor = System.Drawing.Color.DarkGreen;
            this.btnFecharVenda.IconSize = 30;
            this.btnFecharVenda.Location = new System.Drawing.Point(407, 429);
            this.btnFecharVenda.Name = "btnFecharVenda";
            this.btnFecharVenda.Padding = new System.Windows.Forms.Padding(10);
            this.btnFecharVenda.Rotation = 0D;
            this.btnFecharVenda.Size = new System.Drawing.Size(215, 70);
            this.btnFecharVenda.TabIndex = 26;
            this.btnFecharVenda.Text = "FECHAR VENDA";
            this.btnFecharVenda.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFecharVenda.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnFecharVenda.UseVisualStyleBackColor = false;
            // 
            // btnDefinirCliente
            // 
            this.btnDefinirCliente.BackColor = System.Drawing.Color.DarkRed;
            this.btnDefinirCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDefinirCliente.FlatAppearance.BorderSize = 0;
            this.btnDefinirCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinirCliente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnDefinirCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefinirCliente.ForeColor = System.Drawing.Color.White;
            this.btnDefinirCliente.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnDefinirCliente.IconColor = System.Drawing.Color.LightPink;
            this.btnDefinirCliente.IconSize = 24;
            this.btnDefinirCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDefinirCliente.Location = new System.Drawing.Point(83, 65);
            this.btnDefinirCliente.Name = "btnDefinirCliente";
            this.btnDefinirCliente.Rotation = 0D;
            this.btnDefinirCliente.Size = new System.Drawing.Size(492, 29);
            this.btnDefinirCliente.TabIndex = 19;
            this.btnDefinirCliente.Text = "Não definido";
            this.btnDefinirCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolTip1.SetToolTip(this.btnDefinirCliente, "Definir Cliente");
            this.btnDefinirCliente.UseVisualStyleBackColor = false;
            this.btnDefinirCliente.Click += new System.EventHandler(this.btnDefinirCliente_Click);
            // 
            // btnRemoverCliente
            // 
            this.btnRemoverCliente.BackColor = System.Drawing.Color.DarkRed;
            this.btnRemoverCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoverCliente.FlatAppearance.BorderSize = 0;
            this.btnRemoverCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoverCliente.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnRemoverCliente.IconChar = FontAwesome.Sharp.IconChar.UserSlash;
            this.btnRemoverCliente.IconColor = System.Drawing.Color.White;
            this.btnRemoverCliente.IconSize = 20;
            this.btnRemoverCliente.Location = new System.Drawing.Point(581, 65);
            this.btnRemoverCliente.Name = "btnRemoverCliente";
            this.btnRemoverCliente.Rotation = 0D;
            this.btnRemoverCliente.Size = new System.Drawing.Size(40, 29);
            this.btnRemoverCliente.TabIndex = 35;
            this.toolTip1.SetToolTip(this.btnRemoverCliente, "Remover cliente");
            this.btnRemoverCliente.UseVisualStyleBackColor = false;
            this.btnRemoverCliente.Click += new System.EventHandler(this.btnRemoverCliente_Click);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Produto
            // 
            this.Produto.HeaderText = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.ReadOnly = true;
            // 
            // Quantidade
            // 
            this.Quantidade.HeaderText = "Quantidade";
            this.Quantidade.Name = "Quantidade";
            // 
            // Preco
            // 
            this.Preco.HeaderText = "Preço (R$)";
            this.Preco.Name = "Preco";
            this.Preco.ReadOnly = true;
            // 
            // Subtotal
            // 
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            // 
            // dmoItemDaVendaBindingSource
            // 
            this.dmoItemDaVendaBindingSource.DataSource = typeof(KadoshModas.DML.DmoItemDaVenda);
            // 
            // CadVenda
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.btnRemoverCliente);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalVenda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelarVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFecharVenda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnDefinirCliente);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "CadVenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Vendas";
            this.Load += new System.EventHandler(this.CadVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensDaVenda)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dmoItemDaVendaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnDefinirCliente;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnFecharVenda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvItensDaVenda;
        private FontAwesome.Sharp.IconButton btnCancelarVenda;
        private System.Windows.Forms.BindingSource dmoItemDaVendaBindingSource;
        private System.Windows.Forms.Label lblTotalVenda;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnAddProduto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAddProduto;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btnRemoverCliente;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
    }
}