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
    public partial class fKhamBenh : Form
    {

        BindingSource danhsachbenhnhantheoid = new BindingSource();

        public fKhamBenh()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            TimTenBenhNhan();
            TimTenThuoc();
            LoadDanhSachThuoc();
            LoadcbxBacSi();
            LoadDanhSachKham();
        }
        void LoadDanhSachKham()
        {
            dtgvDanhSachBenhNhan.DataSource = DanhSachKhamDAO.Instance.LayDanhSachKham();
        }
        private void TimTenBenhNhan()
        {
            List<BenhNhan> danhsachbenhnhan = BenhNhanDAO.Instance.TimDanhSachBenhNhan();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (BenhNhan item in danhsachbenhnhan)
            {
                auto.Add(item.Tenbn.ToString());
            }

            txtTenBenhNhan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenBenhNhan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenBenhNhan.AutoCompleteCustomSource = auto;
        }

        private void TimTenThuoc()
        {
            List<Thuoc> danhsachthuoc = ThuocDAO.Instance.TimDanhSachThuoc();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Thuoc item in danhsachthuoc)
            {
                auto.Add(item.TenThuoc.ToString());
            }

            txtTimKiemThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTimKiemThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiemThuoc.AutoCompleteCustomSource = auto;
        }

        void LoadDanhSachThuoc()
        {
            dtgvDanhSachThuoc.DataSource = ThuocDAO.Instance.LayDanhSachThuoc2();
        }
        void TinhThanhTien()
        {
            if(txtDonGia.Text != "")
            {
                int sum;
                sum = Convert.ToInt32(txtDonGia.Text) * Convert.ToInt32(numSoLuong.Value);
                txtThanhTien.Text = sum.ToString();
            }
            
        }
        void LoadcbxBacSi()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi();
            cbxBacSi.DataSource = danhsachnhanvien;
            cbxBacSi.ValueMember = "idnhanvien";
            cbxBacSi.DisplayMember = "tennv";
        }
        void ShowToaThuoc(int idhd)
        {
            lsvToaThuoc.Items.Clear();
            List<GioHang> danhsachchitiethoadon = ChiTietHoaDonDAO.Instance.DanhSachToaThuocTheoIDHoaDon(idhd);
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
            txtTienThuoc.Text = tongtien.ToString();
            int TienKham = Convert.ToInt32(txtTienKham.Text);
            int TienThuoc = Convert.ToInt32(txtTienThuoc.Text);
            double TongTien = TienKham + TienThuoc;
            txtTongTien.Text = TongTien.ToString();
        }
        #endregion
        #region Event
        private void txtTenBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                dtgvDanhSachBenhNhan.DataSource = DanhSachKhamDAO.Instance.TimKiemDanhSachKham(txtTenBenhNhan.Text);
            }
        }
        private void dtgvDanhSachBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idbn = BenhAnDAO.Instance.KiemTraBenhAn(Convert.ToInt32(this.dtgvDanhSachBenhNhan.CurrentRow.Cells[3].Value.ToString()));
            if (idbn == -1)
            {
                dtgvDanhSachBenhAn.DataSource = BenhAnDAO.Instance.LayDanhSachBenhAn(this.dtgvDanhSachBenhNhan.CurrentRow.Cells[3].Value.ToString());
                dtgvThuocDaSuDung.DataSource = null;
            }
            else
            {
                dtgvDanhSachBenhAn.DataSource = BenhAnDAO.Instance.LayDanhSachBenhAn(this.dtgvDanhSachBenhNhan.CurrentRow.Cells[3].Value.ToString());
                dtgvThuocDaSuDung.DataSource = ChiTietHoaDonDAO.Instance.LayDanhSachChiTietHoaDon(this.dtgvDanhSachBenhAn.CurrentRow.Cells[10].Value.ToString());
            }
        }

        private void btnThemBenhNhan_Click(object sender, EventArgs e)
        {
            fThongTinBenhNhan f = new fThongTinBenhNhan();
            f.btnThemBenhNhan.Enabled = true;
            f.ShowDialog();
        }

        private void dtgvDanhSachBenhNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDBenhNhan.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[3].Value.ToString();
        }

        private void dtgvDanhSachBenhAn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDBenhAn.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[0].Value.ToString();
            txtLyDoKham.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[1].Value.ToString();
            txtTrieuChung.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[2].Value.ToString();
            txtSieuAm.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[3].Value.ToString();
            txtChuanDoan.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[4].Value.ToString();
            txtLoiDan.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[5].Value.ToString();
            dtpkNgayLap.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[6].Value.ToString();
            cbxTinhTrang.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[8].Value.ToString();
            cbxBacSi.Text = this.dtgvDanhSachBenhAn.CurrentRow.Cells[9].Value.ToString();
        }

        private void txtTimKiemThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvDanhSachThuoc.DataSource = ThuocDAO.Instance.TimKiemDanhSachThuoc(txtTimKiemThuoc.Text);
            }
        }

        private void dtgvDanhSachThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtIDThuoc.Text = this.dtgvDanhSachThuoc.CurrentRow.Cells[0].Value.ToString();
            txtTenThuoc.Text = this.dtgvDanhSachThuoc.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = this.dtgvDanhSachThuoc.CurrentRow.Cells[2].Value.ToString();
            txtCachDung.Text = this.dtgvDanhSachThuoc.CurrentRow.Cells[3].Value.ToString();
            txtDonViTinh.Text = this.dtgvDanhSachThuoc.CurrentRow.Cells[4].Value.ToString();
        }
        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void txtTienKham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int TienKham = Convert.ToInt32(txtTienKham.Text);
                int TienThuoc = Convert.ToInt32(txtTienThuoc.Text);
                double TongTien = TienKham + TienThuoc;
                txtTongTien.Text = TongTien.ToString();
            }
        }

        private void txtTienThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int TienKham = Convert.ToInt32(txtTienKham.Text);
                int TienThuoc = Convert.ToInt32(txtTienThuoc.Text);
                double TongTien = TienKham + TienThuoc;
                txtTongTien.Text = TongTien.ToString();
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

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            fChiTietThuoc f = new fChiTietThuoc();
            f.btnThemThuoc.Enabled = true;
            f.btnLamMoi.Enabled = true;
            f.ShowDialog();
            load();
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

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            int idHoaDon = HoaDonDAO.Instance.LayDanhSachHoaDonChuaThanhToan(Convert.ToInt32(txtIDBenhNhan.Text));

            if (idHoaDon != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho Khách Hàng: {0}\n Tổng tiền là: {1}", txtHoTen.Text, txtThanhToan.Text), "Thông Báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    HoaDonDAO.Instance.ThanhToan(idHoaDon, Convert.ToInt32(txtThanhToan.Text));
                    ThuocDAO.Instance.CapNhapSoLuongThuoc(HoaDonDAO.Instance.LayMaxHoaDon());
                    DanhSachKhamDAO.Instance.ThanhToan(Convert.ToInt32(txtIDBenhNhan.Text));
                    BenhAnDAO.Instance.ThemToaVaoBenhAn(txtLyDoKham.Text, txtTrieuChung.Text, txtSieuAm.Text, txtChuanDoan.Text, txtLoiDan.Text, Convert.ToInt32(cbxBacSi.SelectedValue), Convert.ToInt32(txtIDBenhNhan.Text), Convert.ToInt32(HoaDonDAO.Instance.LayMaxHoaDon()));
                    fReportHoaDonKham f = new fReportHoaDonKham();
                    f.ShowDialog();
                    ShowToaThuoc(Convert.ToInt32(txtIDBenhNhan.Text));
                }
            }
            load();
        }

        private void dtgvDanhSachBenhAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgvThuocDaSuDung.DataSource = ChiTietHoaDonDAO.Instance.LayDanhSachChiTietHoaDon(this.dtgvDanhSachBenhAn.CurrentRow.Cells[10].Value.ToString());
        }

        private void txtIDBenhNhan_TextChanged(object sender, EventArgs e)
        {
            txtHoTen.DataBindings.Clear();
            txtNamSinh.DataBindings.Clear();
            txtGioiTinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtTieuSuBenh.DataBindings.Clear();

            danhsachbenhnhantheoid.DataSource = BenhNhanDAO.Instance.TimKiemDanhSachBenhNhanTheoID(txtIDBenhNhan.Text);

            txtHoTen.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "tenbn", true, DataSourceUpdateMode.Never));
            txtNamSinh.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "namsinhbn", true, DataSourceUpdateMode.Never));
            txtGioiTinh.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "gioitinhbn", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "diachibn", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "sdtbn", true, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "emailbn", true, DataSourceUpdateMode.Never));
            txtTieuSuBenh.DataBindings.Add(new Binding("Text", danhsachbenhnhantheoid.DataSource, "tieusubenh", true, DataSourceUpdateMode.Never));
        }
        private void btnThemVaoToa_Click(object sender, EventArgs e)
        {
            int idhoadon = HoaDonDAO.Instance.LayDanhSachHoaDonChuaThanhToan(Convert.ToInt32(txtIDBenhNhan.Text));
            int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
            int idthuoc = Convert.ToInt32(txtIDThuoc.Text);
            int idnhanvien = Convert.ToInt32(cbxBacSi.SelectedValue);
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
        #endregion
    }
}
