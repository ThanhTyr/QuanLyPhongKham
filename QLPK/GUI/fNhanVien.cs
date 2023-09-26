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
    public partial class fNhanVien : Form
    {
        public fNhanVien()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadDanhSachNhanVien();
            TimTenNhanVien();
        }
        
        void LoadDanhSachNhanVien()
        {
            dtgvDanhSachNhanVien.DataSource = NhanVienDAO.Instance.LayDanhSachNhanVien();
        }

        private void TimTenNhanVien()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.TimDanhSachNhanVien();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (NhanVien item in danhsachnhanvien)
            {
                auto.Add(item.Tennv.ToString());
            }

            txtTenNhanVien.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenNhanVien.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenNhanVien.AutoCompleteCustomSource = auto;
        }
        #endregion

        #region Event
        private void dtgvDanhSachNhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fThongTinNhanVien f = new fThongTinNhanVien();
            f.txtIDNhanVien.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[0].Value.ToString();
            f.txtHoTen.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[1].Value.ToString();
            f.txtNgaySinh.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[2].Value.ToString();
            f.cbxGioiTinh.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[3].Value.ToString();
            f.txtDiaChi.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[4].Value.ToString();
            f.txtSDT.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[5].Value.ToString();
            f.txtEmail.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[6].Value.ToString();
            f.cbxChucVu.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[7].Value.ToString();
            f.cbxViTri.Text = this.dtgvDanhSachNhanVien.CurrentRow.Cells[8].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            fThongTinNhanVien f = new fThongTinNhanVien();
            f.btnThemNhanVien.Enabled = true;
            f.ShowDialog();
            load();
        }

        private void txtTenNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvDanhSachNhanVien.DataSource = NhanVienDAO.Instance.TimKiemDanhSachNhanVien(txtTenNhanVien.Text);
            }
        }
        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.ShowDialog();
            load();
        }
        #endregion
    }
}
