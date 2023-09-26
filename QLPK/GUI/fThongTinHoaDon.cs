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
    public partial class fThongTinHoaDon : Form
    {
        public fThongTinHoaDon()
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
        void ShowToaThuoc(int idhd)
        {
            lsvToaThuoc.Items.Clear();
            List<GioHang> danhsachchitiethoadon = ChiTietHoaDonDAO.Instance.DanhSachToaThuocTheoIDHoaDon2(idhd);
            float tongtien = 0;

            foreach (GioHang item in danhsachchitiethoadon)
            {
                ListViewItem lsvItem = new ListViewItem(item.Tenthuoc.ToString());
                lsvItem.SubItems.Add(item.Chucnang.ToString());
                lsvItem.SubItems.Add(item.Tendonvi.ToString());
                lsvItem.SubItems.Add(item.Giale.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                tongtien += item.Thanhtien;
                lsvToaThuoc.Items.Add(lsvItem);
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
        private void btnChonBenhNhan_Click(object sender, EventArgs e)
        {
            fChonBenhNhan f = new fChonBenhNhan();
            f.ShowDialog();
            txtIDBenhNhan.Text = ChonBenhNhan.id;
            txtHoTen.Text = ChonBenhNhan.hoten;
            txtNamSinh.Text = ChonBenhNhan.namsinh;
            txtGioiTinh.Text = ChonBenhNhan.gioitinh;
            txtSDT.Text = ChonBenhNhan.sdt;
            txtEmail.Text = ChonBenhNhan.email;
            txtDiaChi.Text = ChonBenhNhan.diachi;
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

        private void txtIDHoaDon_TextChanged(object sender, EventArgs e)
        {
            ShowToaThuoc(Convert.ToInt32(txtIDHoaDon.Text));
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

        private void btnThemVaoToa_Click(object sender, EventArgs e)
        {
            int idhoadon = HoaDonDAO.Instance.LayDanhSachHoaDonChuaThanhToan(Convert.ToInt32(txtIDBenhNhan.Text));
            int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
            int idthuoc = Convert.ToInt32(txtIDThuoc.Text);
            int idnhanvien = Convert.ToInt32(cbxNhanVien.SelectedValue);
            int soluong = (int)numSoLuong.Value;

            if (txtIDBenhNhan.Text == "")
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!!!", "Thông Báo");
            }
            else
            {
                if (idhoadon == -1)
                {
                    HoaDonDAO.Instance.ThemHoaDon(idbenhnhan, idnhanvien);
                    ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(HoaDonDAO.Instance.LayMaxHoaDon(), idthuoc, soluong);
                    int idmaxhoadon = HoaDonDAO.Instance.LayMaxHoaDon();
                    ShowToaThuoc(idmaxhoadon);
                }
                else
                {
                    ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(HoaDonDAO.Instance.LayMaxHoaDon(), idthuoc, soluong);
                    int idmaxhoadon = HoaDonDAO.Instance.LayMaxHoaDon();
                    ShowToaThuoc(idmaxhoadon);
                }
            }
        }

        private void btnThemBenhNhan_Click(object sender, EventArgs e)
        {
            fThongTinBenhNhan f = new fThongTinBenhNhan();
            f.btnThemBenhNhan.Enabled = true;
            f.ShowDialog();
            load();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int idHoaDon = HoaDonDAO.Instance.LayDanhSachHoaDonChuaThanhToan(Convert.ToInt32(txtIDBenhNhan.Text));

            if (idHoaDon != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho Khách Hàng: {0}\n Tổng tiền là: {1}", txtHoTen.Text, txtThanhToan.Text), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonDAO.Instance.ThanhToan(idHoaDon, Convert.ToInt32(txtThanhToan.Text));
                    ThuocDAO.Instance.CapNhapSoLuongThuoc(HoaDonDAO.Instance.LayMaxHoaDon());
                    fReportHoaDonThuoc f = new fReportHoaDonThuoc();
                    f.ShowDialog();
                    ShowToaThuoc(idHoaDon);
                }
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
        #endregion
    }
}
