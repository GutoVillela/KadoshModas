﻿namespace KadoshModas.UI
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCadCategoria = new System.Windows.Forms.Button();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCadCategoria);
            this.panel1.Controls.Add(this.txtCategoria);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 432);
            this.panel1.TabIndex = 0;
            // 
            // btnCadCategoria
            // 
            this.btnCadCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btnCadCategoria.Location = new System.Drawing.Point(335, 178);
            this.btnCadCategoria.Name = "btnCadCategoria";
            this.btnCadCategoria.Size = new System.Drawing.Size(103, 38);
            this.btnCadCategoria.TabIndex = 2;
            this.btnCadCategoria.Text = "Cadastrar";
            this.btnCadCategoria.UseVisualStyleBackColor = true;
            this.btnCadCategoria.Click += new System.EventHandler(this.btnCadCategoria_Click);
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.txtCategoria.Location = new System.Drawing.Point(161, 129);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(277, 28);
            this.txtCategoria.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Categoria: ";
            // 
            // CadCategoria
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(659, 432);
            this.Controls.Add(this.panel1);
            this.Name = "CadCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CadCategoria";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCadCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label1;
    }
}