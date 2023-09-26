
namespace QLPK.GUI
{
    partial class fReportHoaDonThuoc
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
            this.rvrHoaDonThuoc = new Microsoft.Reporting.WinForms.ReportViewer();
            this.quanLyPhongKhamDataSet2 = new QLPK.QuanLyPhongKhamDataSet2();
            this.uSPHoaDonThuocCuaBenhNhanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_HoaDonThuocCuaBenhNhanTableAdapter = new QLPK.QuanLyPhongKhamDataSet2TableAdapters.USP_HoaDonThuocCuaBenhNhanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPHoaDonThuocCuaBenhNhanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvrHoaDonThuoc
            // 
            this.rvrHoaDonThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetHoaDonThuoc";
            reportDataSource1.Value = this.uSPHoaDonThuocCuaBenhNhanBindingSource;
            this.rvrHoaDonThuoc.LocalReport.DataSources.Add(reportDataSource1);
            this.rvrHoaDonThuoc.LocalReport.ReportEmbeddedResource = "QLPK.GUI.ReportHoaDonThuoc.rdlc";
            this.rvrHoaDonThuoc.Location = new System.Drawing.Point(0, 0);
            this.rvrHoaDonThuoc.Name = "rvrHoaDonThuoc";
            this.rvrHoaDonThuoc.ServerReport.BearerToken = null;
            this.rvrHoaDonThuoc.Size = new System.Drawing.Size(747, 450);
            this.rvrHoaDonThuoc.TabIndex = 0;
            // 
            // quanLyPhongKhamDataSet2
            // 
            this.quanLyPhongKhamDataSet2.DataSetName = "QuanLyPhongKhamDataSet2";
            this.quanLyPhongKhamDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSPHoaDonThuocCuaBenhNhanBindingSource
            // 
            this.uSPHoaDonThuocCuaBenhNhanBindingSource.DataMember = "USP_HoaDonThuocCuaBenhNhan";
            this.uSPHoaDonThuocCuaBenhNhanBindingSource.DataSource = this.quanLyPhongKhamDataSet2;
            // 
            // uSP_HoaDonThuocCuaBenhNhanTableAdapter
            // 
            this.uSP_HoaDonThuocCuaBenhNhanTableAdapter.ClearBeforeFill = true;
            // 
            // fReportHoaDonThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 450);
            this.Controls.Add(this.rvrHoaDonThuoc);
            this.Name = "fReportHoaDonThuoc";
            this.Text = "Hóa Đơn Thuốc";
            this.Load += new System.EventHandler(this.fReportHoaDonThuoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quanLyPhongKhamDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPHoaDonThuocCuaBenhNhanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvrHoaDonThuoc;
        private QuanLyPhongKhamDataSet2 quanLyPhongKhamDataSet2;
        private System.Windows.Forms.BindingSource uSPHoaDonThuocCuaBenhNhanBindingSource;
        private QuanLyPhongKhamDataSet2TableAdapters.USP_HoaDonThuocCuaBenhNhanTableAdapter uSP_HoaDonThuocCuaBenhNhanTableAdapter;
    }
}