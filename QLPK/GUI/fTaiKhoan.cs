using QLPK.DAO;
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
    public partial class fTaiKhoan : Form
    {
        public fTaiKhoan()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadTaiKhoan();
            LoadcbxNhanVien();
        }
        void LoadTaiKhoan()
        {
            dtgvTaiKhoan.DataSource = TaiKhoanDAO.Instance.LayDanhSachTaiKhoan();
        }
        void LoadcbxNhanVien()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi2();
            cbxTenNhanVien.DataSource = danhsachnhanvien;
            cbxTenNhanVien.ValueMember = "idnhanvien";
            cbxTenNhanVien.DisplayMember = "tennv";
        }
        #endregion

        #region Event
        private void dtgvTaiKhoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTaiKhoan.Text = this.dtgvTaiKhoan.CurrentRow.Cells[0].Value.ToString();
            nmLoaiTaiKhoan.Text = this.dtgvTaiKhoan.CurrentRow.Cells[1].Value.ToString();
            cbxTenNhanVien.Text = this.dtgvTaiKhoan.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            int idnhanvien = (cbxTenNhanVien.SelectedItem as NhanVien).IdNhanVien;
            int loaitk = Convert.ToInt32(nmLoaiTaiKhoan.Text);

            if (TaiKhoanDAO.Instance.InsertTaiKhoan(taiKhoan, idnhanvien, loaitk))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }

            load();
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;

            if (TaiKhoanDAO.Instance.DeleteTaiKhoan(taiKhoan))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }

            load();
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            int idnhanvien = (cbxTenNhanVien.SelectedItem as NhanVien).IdNhanVien;
            int loaitk = Convert.ToInt32(nmLoaiTaiKhoan.Text);

            if (TaiKhoanDAO.Instance.UpdateTaiKhoan(taiKhoan, idnhanvien, loaitk))
            {
                MessageBox.Show("Cật nhập tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cật nhập tài khoản thất bại");
            }

            load();
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;

            if (TaiKhoanDAO.Instance.ResetMatKhau(taiKhoan))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        #endregion
    }
}
