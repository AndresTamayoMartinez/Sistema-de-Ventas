namespace CapaPresentacion
{
    partial class CP_Seleccion_Proveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProviderName = new System.Windows.Forms.TextBox();
            this.dgvShowProducts = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(222, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(268, 7);
            this.label10.TabIndex = 96;
            this.label10.Text = "---------------------------------------------------------------------------------" +
    "---------------------------------------------------";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(127, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 21);
            this.label7.TabIndex = 92;
            this.label7.Text = "Proveedor:";
            // 
            // txtProviderName
            // 
            this.txtProviderName.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtProviderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProviderName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProviderName.ForeColor = System.Drawing.Color.White;
            this.txtProviderName.Location = new System.Drawing.Point(222, 45);
            this.txtProviderName.Name = "txtProviderName";
            this.txtProviderName.Size = new System.Drawing.Size(200, 16);
            this.txtProviderName.TabIndex = 91;
            this.txtProviderName.TextChanged += new System.EventHandler(this.txtProviderName_TextChanged);
            // 
            // dgvShowProducts
            // 
            this.dgvShowProducts.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.dgvShowProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShowProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShowProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShowProducts.Location = new System.Drawing.Point(12, 86);
            this.dgvShowProducts.Name = "dgvShowProducts";
            this.dgvShowProducts.Size = new System.Drawing.Size(576, 252);
            this.dgvShowProducts.TabIndex = 97;
            this.dgvShowProducts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowProducts_CellContentDoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::CapaPresentacion.Properties.Resources.cerrar;
            this.btnClose.Location = new System.Drawing.Point(568, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 93;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CP_Seleccion_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(600, 350);
            this.Controls.Add(this.dgvShowProducts);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProviderName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CP_Seleccion_Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CP_Seleccion_Proveedor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txtProviderName;
        private System.Windows.Forms.DataGridView dgvShowProducts;
    }
}