
namespace QLPK.GUI
{
    partial class fTaiKhoan
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
            this.panel16 = new System.Windows.Forms.Panel();
            this.cbxTenNhanVien = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.btnDatLaiMatKhau = new System.Windows.Forms.Button();
            this.panel35 = new System.Windows.Forms.Panel();
            this.nmLoaiTaiKhoan = new System.Windows.Forms.NumericUpDown();
            this.label44 = new System.Windows.Forms.Label();
            this.panel37 = new System.Windows.Forms.Panel();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.btnResetMatKhau = new System.Windows.Forms.Button();
            this.btnSuaTaiKhoan = new System.Windows.Forms.Button();
            this.btnXoaTaiKhoan = new System.Windows.Forms.Button();
            this.btnThemTaiKhoan = new System.Windows.Forms.Button();
            this.panel39 = new System.Windows.Forms.Panel();
            this.dtgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panel16.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel35.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmLoaiTaiKhoan)).BeginInit();
            this.panel37.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.cbxTenNhanVien);
            this.panel16.Controls.Add(this.label16);
            this.panel16.Location = new System.Drawing.Point(578, 171);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(343, 42);
            this.panel16.TabIndex = 18;
            // 
            // cbxTenNhanVien
            // 
            this.cbxTenNhanVien.FormattingEnabled = true;
            this.cbxTenNhanVien.Location = new System.Drawing.Point(131, 5);
            this.cbxTenNhanVien.Name = "cbxTenNhanVien";
            this.cbxTenNhanVien.Size = new System.Drawing.Size(205, 23);
            this.cbxTenNhanVien.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(3, 4);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 19);
            this.label16.TabIndex = 0;
            this.label16.Text = "Tên Nhân Viên:";
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.btnDatLaiMatKhau);
            this.panel23.Controls.Add(this.panel35);
            this.panel23.Controls.Add(this.panel37);
            this.panel23.Location = new System.Drawing.Point(578, 62);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(343, 103);
            this.panel23.TabIndex = 17;
            // 
            // btnDatLaiMatKhau
            // 
            this.btnDatLaiMatKhau.BackColor = System.Drawing.Color.White;
            this.btnDatLaiMatKhau.Location = new System.Drawing.Point(242, 157);
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new System.Drawing.Size(98, 40);
            this.btnDatLaiMatKhau.TabIndex = 4;
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.UseVisualStyleBackColor = false;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.nmLoaiTaiKhoan);
            this.panel35.Controls.Add(this.label44);
            this.panel35.Location = new System.Drawing.Point(4, 54);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(336, 45);
            this.panel35.TabIndex = 3;
            // 
            // nmLoaiTaiKhoan
            // 
            this.nmLoaiTaiKhoan.Location = new System.Drawing.Point(127, 13);
            this.nmLoaiTaiKhoan.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmLoaiTaiKhoan.Name = "nmLoaiTaiKhoan";
            this.nmLoaiTaiKhoan.Size = new System.Drawing.Size(38, 22);
            this.nmLoaiTaiKhoan.TabIndex = 1;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(3, 14);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(118, 19);
            this.label44.TabIndex = 0;
            this.label44.Text = "Loại Tài Khoản:";
            // 
            // panel37
            // 
            this.panel37.Controls.Add(this.txtTaiKhoan);
            this.panel37.Controls.Add(this.label46);
            this.panel37.Location = new System.Drawing.Point(4, 3);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(336, 45);
            this.panel37.TabIndex = 1;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(127, 14);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(194, 22);
            this.txtTaiKhoan.TabIndex = 1;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.Location = new System.Drawing.Point(3, 14);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(114, 19);
            this.label46.TabIndex = 0;
            this.label46.Text = "Tên Tài Khoản:";
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.btnResetMatKhau);
            this.panel38.Controls.Add(this.btnSuaTaiKhoan);
            this.panel38.Controls.Add(this.btnXoaTaiKhoan);
            this.panel38.Controls.Add(this.btnThemTaiKhoan);
            this.panel38.Location = new System.Drawing.Point(12, 10);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(423, 46);
            this.panel38.TabIndex = 16;
            // 
            // btnResetMatKhau
            // 
            this.btnResetMatKhau.BackColor = System.Drawing.Color.White;
            this.btnResetMatKhau.Location = new System.Drawing.Point(316, 3);
            this.btnResetMatKhau.Name = "btnResetMatKhau";
            this.btnResetMatKhau.Size = new System.Drawing.Size(98, 40);
            this.btnResetMatKhau.TabIndex = 3;
            this.btnResetMatKhau.Text = "Đặt Lại Mật Khẩu";
            this.btnResetMatKhau.UseVisualStyleBackColor = false;
            this.btnResetMatKhau.Click += new System.EventHandler(this.btnResetMatKhau_Click);
            // 
            // btnSuaTaiKhoan
            // 
            this.btnSuaTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btnSuaTaiKhoan.Location = new System.Drawing.Point(212, 3);
            this.btnSuaTaiKhoan.Name = "btnSuaTaiKhoan";
            this.btnSuaTaiKhoan.Size = new System.Drawing.Size(98, 40);
            this.btnSuaTaiKhoan.TabIndex = 2;
            this.btnSuaTaiKhoan.Text = "Sửa Tài Khoản";
            this.btnSuaTaiKhoan.UseVisualStyleBackColor = false;
            this.btnSuaTaiKhoan.Click += new System.EventHandler(this.btnSuaTaiKhoan_Click);
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(108, 3);
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(98, 40);
            this.btnXoaTaiKhoan.TabIndex = 1;
            this.btnXoaTaiKhoan.Text = "Xóa Tài Khoản";
            this.btnXoaTaiKhoan.UseVisualStyleBackColor = false;
            this.btnXoaTaiKhoan.Click += new System.EventHandler(this.btnXoaTaiKhoan_Click);
            // 
            // btnThemTaiKhoan
            // 
            this.btnThemTaiKhoan.BackColor = System.Drawing.Color.White;
            this.btnThemTaiKhoan.Location = new System.Drawing.Point(4, 3);
            this.btnThemTaiKhoan.Name = "btnThemTaiKhoan";
            this.btnThemTaiKhoan.Size = new System.Drawing.Size(98, 40);
            this.btnThemTaiKhoan.TabIndex = 0;
            this.btnThemTaiKhoan.Text = "Thêm Tài Khoản";
            this.btnThemTaiKhoan.UseVisualStyleBackColor = false;
            this.btnThemTaiKhoan.Click += new System.EventHandler(this.btnThemTaiKhoan_Click);
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.dtgvTaiKhoan);
            this.panel39.Location = new System.Drawing.Point(12, 62);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(558, 446);
            this.panel39.TabIndex = 15;
            // 
            // dtgvTaiKhoan
            // 
            this.dtgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTaiKhoan.Location = new System.Drawing.Point(4, 4);
            this.dtgvTaiKhoan.Name = "dtgvTaiKhoan";
            this.dtgvTaiKhoan.Size = new System.Drawing.Size(551, 439);
            this.dtgvTaiKhoan.TabIndex = 0;
            this.dtgvTaiKhoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvTaiKhoan_CellDoubleClick);
            // 
            // fTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel23);
            this.Controls.Add(this.panel38);
            this.Controls.Add(this.panel39);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "fTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài Khoản";
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel23.ResumeLayout(false);
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmLoaiTaiKhoan)).EndInit();
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            this.panel38.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTaiKhoan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.ComboBox cbxTenNhanVien;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.Button btnDatLaiMatKhau;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.NumericUpDown nmLoaiTaiKhoan;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Button btnResetMatKhau;
        private System.Windows.Forms.Button btnSuaTaiKhoan;
        private System.Windows.Forms.Button btnXoaTaiKhoan;
        private System.Windows.Forms.Button btnThemTaiKhoan;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.DataGridView dtgvTaiKhoan;
    }
}