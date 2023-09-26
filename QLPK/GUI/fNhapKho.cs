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
    public partial class fNhapKho : Form
    {
        public fNhapKho()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadDanhSachThuoc();
            LoadcbxTenNhanVien();
            TimTenThuoc();
            LoadcbxNhaSanXuat();
            txtIDNSX.Text = cbxNhaSanXuat.SelectedValue.ToString();
            txtIDNhanVien.Text = cbxNhanVien.SelectedValue.ToString();
        }
        void LoadDanhSachThuoc()
        {
            dtgvThuoc.DataSource = ThuocDAO.Instance.LayDanhSachThuoc2();
        }
        void LoadcbxTenNhanVien()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi2();
            cbxNhanVien.DataSource = danhsachnhanvien;
            cbxNhanVien.ValueMember = "idnhanvien";
            cbxNhanVien.DisplayMember = "tennv";
        }
        void LoadcbxNhaSanXuat()
        {
            List<NhaSanXuat> danhsachloai = NhaSanXuatDAO.Instance.LayDanhSachNhaSanXuat();
            cbxNhaSanXuat.DataSource = danhsachloai;
            cbxNhaSanXuat.DisplayMember = "tennhasanxuat";
            cbxNhaSanXuat.ValueMember = "idNhaSanXuat";
        }
        private void TimTenThuoc()
        {
            List<Thuoc> danhsachthuoc = ThuocDAO.Instance.TimDanhSachThuoc();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Thuoc item in danhsachthuoc)
            {
                auto.Add(item.TenThuoc.ToString());
            }

            txtTimThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTimThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimThuoc.AutoCompleteCustomSource = auto;
        }
        void TinhThanhTien()
        {
            if (txtDonGia.Text != "")
            {
                int sum;
                sum = Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(numSoLuong.Value);
                txtThanhTien.Text = sum.ToString();
            }
        }
        void ShowToaThuoc(int idhdnh)
        {
            lsvNhapKho.Items.Clear();
            List<DonHangNhapKho> danhsachchitiethoadon = ChiTietHoaDonNhapKhoDAO.Instance.DanhSachNhapKhoTheoIDHoaDonNhapKho(idhdnh);
            float tongtien = 0;

            foreach (DonHangNhapKho item in danhsachchitiethoadon)
            {
                ListViewItem lsvItem = new ListViewItem(item.Tenthuoc.ToString());
                lsvItem.SubItems.Add(item.Chucnang.ToString());
                lsvItem.SubItems.Add(item.Tendonvi.ToString());
                lsvItem.SubItems.Add(item.Gianhap.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                tongtien += item.Thanhtien;
                lsvNhapKho.Items.Add(lsvItem);
            }
            txtTienHoaDon.Text = tongtien.ToString();
            int VAT = Convert.ToInt32(txtTienVAT.Text);
            double GiaSauKhiGiam = tongtien - (tongtien / 100) * VAT;
            txtTongTien.Text = GiaSauKhiGiam.ToString();
        }
        #endregion

        #region Event
        private void txtTimThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvThuoc.DataSource = ThuocDAO.Instance.TimKiemDanhSachThuoc2(txtTimThuoc.Text);
            }
        }

        private void btnThêm_Click(object sender, EventArgs e)
        {
            fChiTietThuoc f = new fChiTietThuoc();
            f.btnThemThuoc.Enabled = true;
            f.btnLamMoi.Enabled = true;
            f.ShowDialog();
            load();
        }

        private void dtgvThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDThuoc.Text = this.dtgvThuoc.CurrentRow.Cells[0].Value.ToString();
            txtTenThuoc.Text = this.dtgvThuoc.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = this.dtgvThuoc.CurrentRow.Cells[2].Value.ToString();
            txtCachDung.Text = this.dtgvThuoc.CurrentRow.Cells[3].Value.ToString();
            txtDonViTinh.Text = this.dtgvThuoc.CurrentRow.Cells[4].Value.ToString();
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtIDHoaDonNhapHang_TextChanged(object sender, EventArgs e)
        {
            ShowToaThuoc(Convert.ToInt32(txtIDHoaDonNhapHang.Text));
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);
        }

        private void txtGiamGia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int PhamTramGiamGia = Convert.ToInt32(txtGiamGia.Text);
                    double GiaGoc = Convert.ToDouble(txtTongTien.Text);
                    double GiaSauKhiGiam = GiaGoc - (GiaGoc / 100) * PhamTramGiamGia;
                    txtThanhToan.Text = GiaSauKhiGiam.ToString();
                }
            }
            catch
            {

            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int PhamTramGiamGia = Convert.ToInt32(txtGiamGia.Text);
                double GiaGoc = Convert.ToDouble(txtTongTien.Text);
                double GiaSauKhiGiam = GiaGoc - (GiaGoc / 100) * PhamTramGiamGia;
                txtThanhToan.Text = GiaSauKhiGiam.ToString();
            }
            catch
            {

            }
        }

        private void btnThemVaoToa_Click(object sender, EventArgs e)
        {
            int idnhasanxuat = Convert.ToInt32(txtIDNSX.Text);
            int idhoadonnhaphang = HoaDonNhapKhoDAO.Instance.LayDanhSachHoaDonChuaThanhToan(idnhasanxuat);
            int idthuoc = Convert.ToInt32(txtIDThuoc.Text);
            int idnhanvien = Convert.ToInt32(txtIDNhanVien.Text);
            int soluong = (int)numSoLuong.Value;
            if (idhoadonnhaphang == -1)
            {
                HoaDonNhapKhoDAO.Instance.ThemHoaDonNhapKho(idnhanvien, idnhasanxuat);
                ChiTietHoaDonNhapKhoDAO.Instance.ThemChiTietHoaDonNhapKho(HoaDonNhapKhoDAO.Instance.LayMaxHoaDonNhapKho(), idthuoc, soluong);
                int idmaxhoadonnhaphang = HoaDonNhapKhoDAO.Instance.LayMaxHoaDonNhapKho();
                ShowToaThuoc(idmaxhoadonnhaphang);
            }
            else
            {
                ChiTietHoaDonNhapKhoDAO.Instance.ThemChiTietHoaDonNhapKho(HoaDonNhapKhoDAO.Instance.LayMaxHoaDonNhapKho(), idthuoc, soluong);
                int idmaxhoadonnhaphang = HoaDonNhapKhoDAO.Instance.LayMaxHoaDonNhapKho();
                ShowToaThuoc(idmaxhoadonnhaphang);
            }
        }

        private void cbxNhaSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDNSX.Text = cbxNhaSanXuat.SelectedValue.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int idnhasanxuat = Convert.ToInt32(txtIDNSX.Text);
            int idhoadonnhaphang = HoaDonNhapKhoDAO.Instance.LayDanhSachHoaDonChuaThanhToan(idnhasanxuat);

            if (idhoadonnhaphang != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho Khách Hàng: {0}\n Tổng tiền là: {1}", cbxNhaSanXuat.Text, txtThanhToan.Text), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonNhapKhoDAO.Instance.ThanhToan(idhoadonnhaphang, Convert.ToInt32(txtThanhToan.Text));
                    ThuocDAO.Instance.CapNhapSoLuongThuocNhap(HoaDonNhapKhoDAO.Instance.LayMaxHoaDonNhapKho());
                    //ReportBill f = new ReportBill();
                    //f.ShowDialog();
                    ShowToaThuoc(idhoadonnhaphang);
                }
            }
        }

        private void cbxNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDNhanVien.Text = cbxNhanVien.SelectedValue.ToString();
        }
        #endregion
    }
}
