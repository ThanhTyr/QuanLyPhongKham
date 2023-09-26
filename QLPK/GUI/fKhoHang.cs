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
    public partial class fKhoHang : Form
    {
        public fKhoHang()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            TimTenThuoc();
            LoadcbxNhaSanXuat();
            LoadcbxBacSi();
            LoadDanhSachKhoHang();
        }
        void LoadDanhSachKhoHang()
        {
            dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.LayDanhSachKhoHang();
        }
        private void TimTenThuoc()
        {
            List<Thuoc> danhsachthuoc = ThuocDAO.Instance.TimDanhSachThuoc();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Thuoc item in danhsachthuoc)
            {
                auto.Add(item.TenThuoc.ToString());
            }

            txtIDHoaDonNhapHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtIDHoaDonNhapHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtIDHoaDonNhapHang.AutoCompleteCustomSource = auto;
        }
        void LoadcbxNhaSanXuat()
        {
            List<NhaSanXuat> danhsachloai = NhaSanXuatDAO.Instance.LayDanhSachNhaSanXuat();
            cbxNhaSanXuat.DataSource = danhsachloai;
            cbxNhaSanXuat.DisplayMember = "tennhasanxuat";
            cbxNhaSanXuat.ValueMember = "idNhaSanXuat";
        }
        void LoadcbxBacSi()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi2();
            cbxNhanVien.DataSource = danhsachnhanvien;
            cbxNhanVien.ValueMember = "idnhanvien";
            cbxNhanVien.DisplayMember = "tennv";
        }
        #endregion

        #region Event
        private void txtTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.TimKiemDanhSachKhoHang(Convert.ToInt32(txtIDHoaDonNhapHang.Text));
            }
        }

        private void dtpkTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachNhapHangTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
            txtIDHoaDonNhapHang.Text = "";
        }

        private void dtpkDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachNhapHangTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
            txtIDHoaDonNhapHang.Text = "";
        }

        private void cbxNhaSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachNhapHangTheoNhaSanXuat(cbxNhaSanXuat.Text);
            txtIDHoaDonNhapHang.Text = "";
        }
        private void cbxNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvKhoHang.DataSource = HoaDonNhapKhoDAO.Instance.TimKiemNhanVienNhapKhoHang(cbxNhanVien.Text);
            txtIDHoaDonNhapHang.Text = "";
        }

        private void dtgvKhoHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fNhapKho f = new fNhapKho();
            f.dtpkNgayLap.Text = this.dtgvKhoHang.CurrentRow.Cells[0].Value.ToString();
            f.txtIDHoaDonNhapHang.Text = this.dtgvKhoHang.CurrentRow.Cells[1].Value.ToString();
            f.cbxNhanVien.Text = this.dtgvKhoHang.CurrentRow.Cells[2].Value.ToString();
            f.cbxNhaSanXuat.Text = this.dtgvKhoHang.CurrentRow.Cells[4].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fNhapKho f = new fNhapKho();
            f.btnThemVaoToa.Enabled = true;
            f.btnThanhToan.Enabled = true;
            f.btnLamMoi.Enabled = true;
            f.ShowDialog();
            load();
        }
        #endregion
    }
}
