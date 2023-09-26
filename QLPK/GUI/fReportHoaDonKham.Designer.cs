
namespace QLPK.GUI
{
    partial class fReportHoaDonKham
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rvrHoaDonKham = new Microsoft.Reporting.WinForms.ReportViewer();
            this.quanLyPhongKhamDataSet1 = new QLPK.QuanLyPhongKhamDataSet1();
            this.quanLyPhongKhamDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSPHoaDonKhamCuaBenhNhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_HoaDonKhamCuaBenhNhanTableAdapter = new QLPK.QuanLyPhongKhamDataSet1TableAdapters.USP_HoaDonKhamCuaBenhNhanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPHoaDonKhamCuaBenhNhanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvrHoaDonKham
            // 
            this.rvrHoaDonKham.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetHoaDonKham";
            reportDataSource1.Value = this.uSPHoaDonKhamCuaBenhNhanBindingSource;
            this.rvrHoaDonKham.LocalReport.DataSources.Add(reportDataSource1);
            this.rvrHoaDonKham.LocalReport.ReportEmbeddedResource = "QLPK.GUI.ReportHoaDonKham.rdlc";
            this.rvrHoaDonKham.Location = new System.Drawing.Point(0, 0);
            this.rvrHoaDonKham.Name = "rvrHoaDonKham";
            this.rvrHoaDonKham.ServerReport.BearerToken = null;
            this.rvrHoaDonKham.Size = new System.Drawing.Size(747, 450);
            this.rvrHoaDonKham.TabIndex = 0;
            // 
            // quanLyPhongKhamDataSet1
            // 
            this.quanLyPhongKhamDataSet1.DataSetName = "QuanLyPhongKhamDataSet1";
            this.quanLyPhongKhamDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quanLyPhongKhamDataSet1BindingSource
            // 
            this.quanLyPhongKhamDataSet1BindingSource.DataSource = this.quanLyPhongKhamDataSet1;
            this.quanLyPhongKhamDataSet1BindingSource.Position = 0;
            // 
            // uSPHoaDonKhamCuaBenhNhanBindingSource
            // 
            this.uSPHoaDonKhamCuaBenhNhanBindingSource.DataMember = "USP_HoaDonKhamCuaBenhNhan";
            this.uSPHoaDonKhamCuaBenhNhanBindingSource.DataSource = this.quanLyPhongKhamDataSet1BindingSource;
            // 
            // uSP_HoaDonKhamCuaBenhNhanTableAdapter
            // 
            this.uSP_HoaDonKhamCuaBenhNhanTableAdapter.ClearBeforeFill = true;
            // 
            // fReportHoaDonKham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 450);
            this.Controls.Add(this.rvrHoaDonKham);
            this.Name = "fReportHoaDonKham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hóa Đơn Khám";
            this.Load += new System.EventHandler(this.fReportHoaDonKham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPHoaDonKhamCuaBenhNhanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvrHoaDonKham;
        private System.Windows.Forms.BindingSource quanLyPhongKhamDataSet1BindingSource;
        private QuanLyPhongKhamDataSet1 quanLyPhongKhamDataSet1;
        private System.Windows.Forms.BindingSource uSPHoaDonKhamCuaBenhNhanBindingSource;
        private QuanLyPhongKhamDataSet1TableAdapters.USP_HoaDonKhamCuaBenhNhanTableAdapter uSP_HoaDonKhamCuaBenhNhanTableAdapter;
    }
}