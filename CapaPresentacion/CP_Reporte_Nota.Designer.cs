namespace CapaPresentacion
{
    partial class CP_Reporte_Nota
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DS_Nota = new CapaPresentacion.DS_Nota();
            this.sp_notaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_notaTableAdapter = new CapaPresentacion.DS_NotaTableAdapters.sp_notaTableAdapter();
            this.sp_nota_productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_nota_productosTableAdapter = new CapaPresentacion.DS_NotaTableAdapters.sp_nota_productosTableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS_Nota)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_notaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_nota_productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 30);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "DS_Nota";
            reportDataSource7.Value = this.sp_notaBindingSource;
            reportDataSource8.Name = "DS_Nota_Productos";
            reportDataSource8.Value = this.sp_nota_productosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Reporte_Nota.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(900, 520);
            this.reportViewer1.TabIndex = 1;
            // 
            // DS_Nota
            // 
            this.DS_Nota.DataSetName = "DS_Nota";
            this.DS_Nota.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sp_notaBindingSource
            // 
            this.sp_notaBindingSource.DataMember = "sp_nota";
            this.sp_notaBindingSource.DataSource = this.DS_Nota;
            // 
            // sp_notaTableAdapter
            // 
            this.sp_notaTableAdapter.ClearBeforeFill = true;
            // 
            // sp_nota_productosBindingSource
            // 
            this.sp_nota_productosBindingSource.DataMember = "sp_nota_productos";
            this.sp_nota_productosBindingSource.DataSource = this.DS_Nota;
            // 
            // sp_nota_productosTableAdapter
            // 
            this.sp_nota_productosTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.cerrar;
            this.pictureBox1.Location = new System.Drawing.Point(869, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // CP_Reporte_Nota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CP_Reporte_Nota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CP_Reporte_Nota";
            this.Load += new System.EventHandler(this.CP_Reporte_Nota_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS_Nota)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_notaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_nota_productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_notaBindingSource;
        private DS_Nota DS_Nota;
        private System.Windows.Forms.BindingSource sp_nota_productosBindingSource;
        private DS_NotaTableAdapters.sp_notaTableAdapter sp_notaTableAdapter;
        private DS_NotaTableAdapters.sp_nota_productosTableAdapter sp_nota_productosTableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}