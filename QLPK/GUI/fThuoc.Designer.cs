
namespace QLPK.GUI
{
    partial class fThuoc
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
            this.cbxLoaiThuoc = new System.Windows.Forms.ComboBox();
            this.lblLoaiThuoc = new System.Windows.Forms.Label();
            this.lblTenThuoc = new System.Windows.Forms.Label();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvThuoc = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxLoaiThuoc);
            this.groupBox1.Controls.Add(this.lblLoaiThuoc);
            this.groupBox1.Controls.Add(this.lblTenThuoc);
            this.groupBox1.Controls.Add(this.txtTenThuoc);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Tìm Kiếm";
            // 
            // cbxLoaiThuoc
            // 
            this.cbxLoaiThuoc.FormattingEnabled = true;
            this.cbxLoaiThuoc.Location = new System.Drawing.Point(623, 29);
            this.cbxLoaiThuoc.Name = "cbxLoaiThuoc";
            this.cbxLoaiThuoc.Size = new System.Drawing.Size(330, 23);
            this.cbxLoaiThuoc.TabIndex = 5;
            this.cbxLoaiThuoc.TextChanged += new System.EventHandler(this.cbxLoaiThuoc_TextChanged);
            // 
            // lblLoaiThuoc
            // 
            this.lblLoaiThuoc.AutoSize = true;
            this.lblLoaiThuoc.Location = new System.Drawing.Point(545, 32);
            this.lblLoaiThuoc.Name = "lblLoaiThuoc";
            this.lblLoaiThuoc.Size = new System.Drawing.Size(72, 15);
            this.lblLoaiThuoc.TabIndex = 3;
            this.lblLoaiThuoc.Text = "Loại Thuốc:";
            // 
            // lblTenThuoc
            // 
            this.lblTenThuoc.AutoSize = true;
            this.lblTenThuoc.Location = new System.Drawing.Point(10, 32);
            this.lblTenThuoc.Name = "lblTenThuoc";
            this.lblTenThuoc.Size = new System.Drawing.Size(69, 15);
            this.lblTenThuoc.TabIndex = 2;
            this.lblTenThuoc.Text = "Tên Thuốc:";
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.Location = new System.Drawing.Point(85, 29);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(454, 22);
            this.txtTenThuoc.TabIndex = 0;
            this.txtTenThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenThuoc_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(977, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 74);
            this.panel1.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(2, 13);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(168, 52);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvThuoc);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1141, 483);
            this.panel2.TabIndex = 1;
            // 
            // dtgvThuoc
            // 
            this.dtgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgvThuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThuoc.Location = new System.Drawing.Point(0, 0);
            this.dtgvThuoc.Name = "dtgvThuoc";
            this.dtgvThuoc.Size = new System.Drawing.Size(1141, 483);
            this.dtgvThuoc.TabIndex = 0;
            this.dtgvThuoc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThuoc_CellDoubleClick);
            // 
            // fThuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 587);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "fThuoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Thuốc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThuoc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView dtgvThuoc;
        private System.Windows.Forms.ComboBox cbxLoaiThuoc;
        private System.Windows.Forms.Label lblLoaiThuoc;
        private System.Windows.Forms.Label lblTenThuoc;
        private System.Windows.Forms.TextBox txtTenThuoc;
        private System.Windows.Forms.Button btnThem;
    }
}