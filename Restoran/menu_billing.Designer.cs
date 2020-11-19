namespace Restoran
{
    partial class menu_billing
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataTableBillingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet_Billing = new Restoran.DataSet_Billing();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataTableBillingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Billing)).BeginInit();
            this.SuspendLayout();
            // 
            // DataTableBillingBindingSource
            // 
            this.DataTableBillingBindingSource.DataMember = "DataTableBilling";
            this.DataTableBillingBindingSource.DataSource = this.DataSet_Billing;
            // 
            // DataSet_Billing
            // 
            this.DataSet_Billing.DataSetName = "DataSet_Billing";
            this.DataSet_Billing.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.DataTableBillingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Restoran.Report_Billing.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 66);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(826, 463);
            this.reportViewer1.TabIndex = 12;
            // 
            // menu_billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 529);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "menu_billing";
            this.Text = "menu_billing";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.menu_billing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTableBillingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Billing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTableBillingBindingSource;
        private DataSet_Billing DataSet_Billing;
    }
}