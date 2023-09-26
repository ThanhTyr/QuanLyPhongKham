
namespace QLPK.GUI
{
    partial class fChonBenhNhan
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
            this.dtgvBenhNhan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimBenhNhan = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBenhNhan)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvBenhNhan
            // 
            this.dtgvBenhNhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBenhNhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBenhNhan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvBenhNhan.Location = new System.Drawing.Point(0, 0);
            this.dtgvBenhNhan.Name = "dtgvBenhNhan";
            this.dtgvBenhNhan.Size = new System.Drawing.Size(1014, 398);
            this.dtgvBenhNhan.TabIndex = 0;
            this.dtgvBenhNhan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvBenhNhan_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTimBenhNhan);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 28);
            this.panel1.TabIndex = 1;
            // 
            // txtTimBenhNhan
            // 
            this.txtTimBenhNhan.Location = new System.Drawing.Point(3, 3);
            this.txtTimBenhNhan.Name = "txtTimBenhNhan";
            this.txtTimBenhNhan.Size = new System.Drawing.Size(1009, 20);
            this.txtTimBenhNhan.TabIndex = 0;
            this.txtTimBenhNhan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimBenhNhan_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvBenhNhan);
            this.panel2.Location = new System.Drawing.Point(13, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 398);
            this.panel2.TabIndex = 2;
            // 
            // fChonBenhNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fChonBenhNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Bệnh Nhân";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBenhNhan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvBenhNhan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimBenhNhan;
        private System.Windows.Forms.Panel panel2;
    }
}