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
    public partial class fHoaDon : Form
    {
        public fHoaDon()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            TimMaHoaDon();
            TimTenKhachHang();
            LoadcbxTenNhanVien();
            LoadDanhSachHoaDon();
        }
        void LoadDanhSachHoaDon()
        {
            dtgvHoaDon.DataSource = HoaDonDAO.Instance.LayDanhSachHoaDon();
        }
        private void TimTenKhachHang()
        {
            List<BenhNhan> danhsachbenhnhan = BenhNhanDAO.Instance.TimDanhSachBenhNhan();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (BenhNhan item in danhsachbenhnhan)
            {
                auto.Add(item.Tenbn.ToString());
            }

            txtTenKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenKhachHang.AutoCompleteCustomSource = auto;
        }
        private void TimMaHoaDon()
        {
            List<HoaDon> danhsachmahoadon = HoaDonDAO.Instance.TimDanhSachMaHoaDon();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (HoaDon item in danhsachmahoadon)
            {
                auto.Add(item.IdHoaDon.ToString());
            }

            txtIDHoaDon.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtIDHoaDon.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtIDHoaDon.AutoCompleteCustomSource = auto;
        }
        void LoadcbxTenNhanVien()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi();
            cbxTenNhanVien.DataSource = danhsachnhanvien;
            cbxTenNhanVien.ValueMember = "idnhanvien";
            cbxTenNhanVien.DisplayMember = "tennv";
        }
        #endregion

        #region Event
        private void dtpkTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvHoaDon.DataSource = HoaDonDAO.Instance.DanhSachHoaDonTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
        }

        private void dtpkDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvHoaDon.DataSource = HoaDonDAO.Instance.DanhSachHoaDonTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
        }

        private void txtTenKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvHoaDon.DataSource = HoaDonDAO.Instance.TimKiemDanhSachHoaDonTheoTen(txtTenKhachHang.Text);
            }
        }

        private void txtIDHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvHoaDon.DataSource = HoaDonDAO.Instance.TimKiemDanhSachHoaDonTheoID(Convert.ToInt32(txtIDHoaDon.Text));
            }
        }

        private void cbxTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvHoaDon.DataSource = HoaDonDAO.Instance.TimKiemDanhSachHoaDonTheoNhanVien(cbxTenNhanVien.Text);
        }

        private void dtgvHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fThongTinHoaDon f = new fThongTinHoaDon();
            f.txtIDHoaDon.Text = this.dtgvHoaDon.CurrentRow.Cells[0].Value.ToString();
            f.txtIDBenhNhan.Text = this.dtgvHoaDon.CurrentRow.Cells[1].Value.ToString();
            f.cbxNhanVien.Text = this.dtgvHoaDon.CurrentRow.Cells[2].Value.ToString();
            f.txtHoTen.Text = this.dtgvHoaDon.CurrentRow.Cells[3].Value.ToString();
            f.txtNamSinh.Text = this.dtgvHoaDon.CurrentRow.Cells[4].Value.ToString();
            f.txtGioiTinh.Text = this.dtgvHoaDon.CurrentRow.Cells[5].Value.ToString();
            f.txtDiaChi.Text = this.dtgvHoaDon.CurrentRow.Cells[6].Value.ToString();
            f.txtSDT.Text = this.dtgvHoaDon.CurrentRow.Cells[7].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fThongTinHoaDon f = new fThongTinHoaDon();
            f.btnThanhToan.Enabled = true;
            f.btnChonBenhNhan.Enabled = true;
            f.btnThemVaoToa.Enabled = true;
            f.btnLamMoi.Enabled = true;
            f.ShowDialog();
            load();
        }
        #endregion
    }
}
