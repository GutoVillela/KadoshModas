namespace KadoshModas.UI
{
    partial class CadMarca
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
            this.btnCadMarca = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCadMarca
            // 
            this.btnCadMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadMarca.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.btnCadMarca.Location = new System.Drawing.Point(334, 288);
            this.btnCadMarca.Name = "btnCadMarca";
            this.btnCadMarca.Size = new System.Drawing.Size(149, 37);
            this.btnCadMarca.TabIndex = 5;
            this.btnCadMarca.Text = "Cadastrar";
            this.btnCadMarca.UseVisualStyleBackColor = true;
            this.btnCadMarca.Click += new System.EventHandler(this.btnCadMarca_Click);
            // 
            // txtMarca
            // 
            this.txtMarca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMarca.Font = new System.Drawing.Font("Microsoft Tai Le", 12F);
            this.txtMarca.Location = new System.Drawing.Point(160, 239);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(323, 28);
            this.txtMarca.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Marca:";
            // 
            // CadMarca
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.btnCadMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.label1);
            this.Name = "CadMarca";
            this.Text = "CadMarca";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label1;
    }
}