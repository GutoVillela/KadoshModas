namespace KadoshModas.UI
{
    partial class CadCliente
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
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.chkMaisNumeros = new System.Windows.Forms.CheckBox();
            this.lstNumeros = new System.Windows.Forms.ListBox();
            this.btnCadastrarCliente = new System.Windows.Forms.Button();
            this.btnAddNumero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome: ";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(96, 33);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(375, 20);
            this.txtNomeCliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "E-mail: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(96, 72);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(375, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "CPF: ";
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(96, 107);
            this.txtCpf.Mask = "000,000,000-00";
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(375, 20);
            this.txtCpf.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefone: ";
            // 
            // txtTelefone
            // 
            this.txtTelefone.Location = new System.Drawing.Point(96, 150);
            this.txtTelefone.Mask = "(99) 00000-0000";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(132, 20);
            this.txtTelefone.TabIndex = 7;
            // 
            // chkMaisNumeros
            // 
            this.chkMaisNumeros.AutoSize = true;
            this.chkMaisNumeros.Location = new System.Drawing.Point(286, 152);
            this.chkMaisNumeros.Name = "chkMaisNumeros";
            this.chkMaisNumeros.Size = new System.Drawing.Size(185, 17);
            this.chkMaisNumeros.TabIndex = 8;
            this.chkMaisNumeros.Text = "Cliente possui mais de um número";
            this.chkMaisNumeros.UseVisualStyleBackColor = true;
            this.chkMaisNumeros.CheckedChanged += new System.EventHandler(this.chkMaisNumeros_CheckedChanged);
            // 
            // lstNumeros
            // 
            this.lstNumeros.Enabled = false;
            this.lstNumeros.FormattingEnabled = true;
            this.lstNumeros.Location = new System.Drawing.Point(96, 200);
            this.lstNumeros.Name = "lstNumeros";
            this.lstNumeros.Size = new System.Drawing.Size(323, 95);
            this.lstNumeros.TabIndex = 9;
            this.lstNumeros.Visible = false;
            // 
            // btnCadastrarCliente
            // 
            this.btnCadastrarCliente.Location = new System.Drawing.Point(306, 329);
            this.btnCadastrarCliente.Name = "btnCadastrarCliente";
            this.btnCadastrarCliente.Size = new System.Drawing.Size(113, 54);
            this.btnCadastrarCliente.TabIndex = 10;
            this.btnCadastrarCliente.Text = "CADASTRAR";
            this.btnCadastrarCliente.UseVisualStyleBackColor = true;
            this.btnCadastrarCliente.Click += new System.EventHandler(this.btnCadastrarCliente_Click);
            // 
            // btnAddNumero
            // 
            this.btnAddNumero.Location = new System.Drawing.Point(234, 148);
            this.btnAddNumero.Name = "btnAddNumero";
            this.btnAddNumero.Size = new System.Drawing.Size(46, 23);
            this.btnAddNumero.TabIndex = 11;
            this.btnAddNumero.Text = "+";
            this.btnAddNumero.UseVisualStyleBackColor = true;
            this.btnAddNumero.Visible = false;
            // 
            // CadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.btnAddNumero);
            this.Controls.Add(this.btnCadastrarCliente);
            this.Controls.Add(this.lstNumeros);
            this.Controls.Add(this.chkMaisNumeros);
            this.Controls.Add(this.txtTelefone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNomeCliente);
            this.Controls.Add(this.label1);
            this.Name = "CadCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastrar novo cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtCpf;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.CheckBox chkMaisNumeros;
        private System.Windows.Forms.ListBox lstNumeros;
        private System.Windows.Forms.Button btnCadastrarCliente;
        private System.Windows.Forms.Button btnAddNumero;
    }
}