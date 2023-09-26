
namespace QLPK.GUI
{
    partial class fKhoHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxNhanVien = new System.Windows.Forms.ComboBox();
            this.cbxNhaSanXuat = new System.Windows.Forms.ComboBox();
            this.lblLoaiThuoc = new System.Windows.Forms.Label();
            this.lblTenThuoc = new System.Windows.Forms.Label();
            this.txtIDHoaDonNhapHang = new System.Windows.Forms.TextBox();
            this.dtpkDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dtpkTuNgay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvKhoHang = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxNhanVien);
            this.groupBox1.Controls.Add(this.cbxNhaSanXuat);
            this.groupBox1.Controls.Add(this.lblLoaiThuoc);
            this.groupBox1.Controls.Add(this.lblTenThuoc);
            this.groupBox1.Controls.Add(this.txtIDHoaDonNhapHang);
            this.groupBox1.Controls.Add(this.dtpkDenNgay);
            this.groupBox1.Controls.Add(this.dtpkTuNgay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(170, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // cbxNhanVien
            // 
            this.cbxNhanVien.FormattingEnabled = true;
            this.cbxNhanVien.Location = new System.Drawing.Point(418, 45);
            this.cbxNhanVien.Name = "cbxNhanVien";
            this.cbxNhanVien.Size = new System.Drawing.Size(163, 23);
            this.cbxNhanVien.TabIndex = 13;
            this.cbxNhanVien.SelectedIndexChanged += new System.EventHandler(this.cbxNhanVien_SelectedIndexChanged);
            // 
            // cbxNhaSanXuat
            // 
            this.cbxNhaSanXuat.FormattingEnabled = true;
            this.cbxNhaSanXuat.Location = new System.Drawing.Point(740, 45);
            this.cbxNhaSanXuat.Name = "cbxNhaSanXuat";
            this.cbxNhaSanXuat.Size = new System.Drawing.Size(250, 23);
            this.cbxNhaSanXuat.TabIndex = 12;
            this.cbxNhaSanXuat.SelectedIndexChanged += new System.EventHandler(this.cbxNhaSanXuat_SelectedIndexChanged);
            // 
            // lblLoaiThuoc
            // 
            this.lblLoaiThuoc.AutoSize = true;
            this.lblLoaiThuoc.Location = new System.Drawing.Point(737, 19);
            this.lblLoaiThuoc.Name = "lblLoaiThuoc";
            this.lblLoaiThuoc.Size = new System.Drawing.Size(89, 15);
            this.lblLoaiThuoc.TabIndex = 11;
            this.lblLoaiThuoc.Text = "Nhà Sản Xuất :";
            // 
            // lblTenThuoc
            // 
            this.lblTenThuoc.AutoSize = true;
            this.lblTenThuoc.Location = new System.Drawing.Point(584, 19);
            this.lblTenThuoc.Name = "lblTenThuoc";
            this.lblTenThuoc.Size = new System.Drawing.Size(141, 15);
            this.lblTenThuoc.TabIndex = 10;
            this.lblTenThuoc.Text = "Mã Hóa Đơn Nhập Hàng:";
            // 
            // txtIDHoaDonNhapHang
            // 
            this.txtIDHoaDonNhapHang.Location = new System.Drawing.Point(587, 46);
            this.txtIDHoaDonNhapHang.Name = "txtIDHoaDonNhapHang";
            this.txtIDHoaDonNhapHang.Size = new System.Drawing.Size(147, 22);
            this.txtIDHoaDonNhapHang.TabIndex = 9;
            this.txtIDHoaDonNhapHang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenThuoc_KeyDown);
            // 
            // dtpkDenNgay
            // 
            this.dtpkDenNgay.Location = new System.Drawing.Point(212, 46);
            this.dtpkDenNgay.Name = "dtpkDenNgay";
            this.dtpkDenNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpkDenNgay.TabIndex = 8;
            this.dtpkDenNgay.ValueChanged += new System.EventHandler(this.dtpkDenNgay_ValueChanged);
            // 
            // dtpkTuNgay
            // 
            this.dtpkTuNgay.Location = new System.Drawing.Point(6, 47);
            this.dtpkTuNgay.Name = "dtpkTuNgay";
            this.dtpkTuNgay.Size = new System.Drawing.Size(200, 22);
            this.dtpkTuNgay.TabIndex = 7;
            this.dtpkTuNgay.ValueChanged += new System.EventHandler(this.dtpkTuNgay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhân Viên :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvKhoHang);
            this.panel1.Location = new System.Drawing.Point(12, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1335, 564);
            this.panel1.TabIndex = 5;
            // 
            // dtgvKhoHang
            // 
            this.dtgvKhoHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKhoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvKhoHang.Location = new System.Drawing.Point(0, 0);
            this.dtgvKhoHang.Name = "dtgvKhoHang";
            this.dtgvKhoHang.Size = new System.Drawing.Size(1335, 564);
            this.dtgvKhoHang.TabIndex = 0;
            this.dtgvKhoHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKhoHang_CellDoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1180, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 70);
            this.button1.TabIndex = 4;
            this.button1.Text = "Thêm Mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "fKhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho Hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKhoHang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpkDenNgay;
        private System.Windows.Forms.DateTimePicker dtpkTuNgay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvKhoHang;
        private System.Windows.Forms.ComboBox cbxNhaSanXuat;
        private System.Windows.Forms.Label lblLoaiThuoc;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.TextBox txtIDHoaDonNhapHang;
        private System.Windows.Forms.ComboBox cbxNhanVien;
        protected System.Windows.Forms.Button button1;
    }
}