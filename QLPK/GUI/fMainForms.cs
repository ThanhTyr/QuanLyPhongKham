using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPK.GUI
{
    public partial class fMainForms : Form
    {
        private DangNhap dangnhapTK;
        public DangNhap DangnhapTK { get => dangnhapTK; set { dangnhapTK = value; ChangeAccount(dangnhapTK.Loaitk); } }

        public fMainForms(DangNhap acc)
        {
            InitializeComponent();
            this.DangnhapTK = acc;
        }

        void ChangeAccount(int Loaitk)
        {
            danhMụcToolStripMenuItem.Enabled = Loaitk == 0;
            báoCáoTàiChínhToolStripMenuItem.Enabled = Loaitk == 0;
            khoHàngToolStripMenuItem.Enabled = Loaitk == 0;
        }

        private void addform(Form f)
        {
            this.panel1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panel1.Controls.Add(f);
            f.Show();
        }

        private void fMainForms_Load(object sender, EventArgs e)
        {
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            addform(f);
        }

        private void bệnhNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBenhNhan f = new fBenhNhan();
            addform(f);
        }

        private void dịchVụKhámĐiềuTrịBệnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhamBenh f = new fKhamBenh();
            addform(f);
        }

        private void thuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fThuoc f = new fThuoc();
            addform(f);
        }

        private void hẹnKhámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDanhSachHen f = new fDanhSachHen();
            addform(f);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Thoát Hay Không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                this.Close();
        }

        private void bánThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fHoaDon f = new fHoaDon();
            addform(f);
        }

        private void khoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fKhoHang f = new fKhoHang();
            addform(f);
        }

        private void báoCáoTàiChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBaoCaoTaiChinh f = new fBaoCaoTaiChinh();
            addform(f);
        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTrangChu f = new fTrangChu();
            addform(f);
        }
    }
}
