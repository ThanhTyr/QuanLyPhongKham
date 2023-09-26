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
    public partial class fBaoCaoTaiChinh : Form
    {
        DateTime adatetime = new DateTime();
        BindingSource tienloithang = new BindingSource();
        BindingSource phinhapthang = new BindingSource();
        BindingSource phinhaphomnay = new BindingSource();
        BindingSource tongsoluongSP = new BindingSource();
        BindingSource tongsoluongSPhomnay = new BindingSource();
        BindingSource tongsohd = new BindingSource();
        BindingSource tongsohdhomnay = new BindingSource();
        BindingSource doanhsothang = new BindingSource();
        BindingSource doanhsohomnay = new BindingSource();
        public fBaoCaoTaiChinh()
        {
            InitializeComponent();
            load();
        }
        private void fBaoCaoTaiChinh_Load(object sender, EventArgs e)
        {
            charTongTien.DataSource = HoaDonDAO.Instance.DanhSachTongTienTheoThang();
            charTongTien.Series["TongTien"].XValueMember = "Thang";
            charTongTien.Series["TongTien"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            charTongTien.Series["TongTien"].YValueMembers = "DoanhThu";
            charTongTien.Series["TongTien"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }
        #region Method
        void load()
        {
            TimTenBenhNhan();
            LoadcbxBacSi();
            LoadDanhSachDoanhThu();
            Tongsohd();
            Tongsoluongthuoc();
            Doanhso();
            PhiNhapKho();
            TienLoiTrongThang();
        }
        void LoadDanhSachDoanhThu()
        {
            dtgvDoanhThu.DataSource = HoaDonDAO.Instance.LayDanhSachDoanhThu();
        }
        private void TimTenBenhNhan()
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
        void LoadcbxBacSi()
        {
            List<NhanVien> danhsachnhanvien = NhanVienDAO.Instance.LayDanhSachBacSi2();
            cbxNhanVien.DataSource = danhsachnhanvien;
            cbxNhanVien.ValueMember = "idnhanvien";
            cbxNhanVien.DisplayMember = "tennv";
        }
        void Tongsohd()
        {
            adatetime = DateTime.Now;
            int today = Convert.ToInt32(adatetime.Day);
            int month = Convert.ToInt32(adatetime.Month);
            int year = Convert.ToInt32(adatetime.Year);

            tongsohd.DataSource = HoaDonDAO.Instance.DanhSachHoanDonThang(month, year);
            lblHoaDonTrongThang.DataBindings.Add(new Binding("Text", tongsohd, "soHD"));

            tongsohdhomnay.DataSource = HoaDonDAO.Instance.DanhSachHoaDonHomNay(today, month, year);
            lblHoaDonTrongHomNay.DataBindings.Add(new Binding("Text", tongsohdhomnay, "soHDtoday"));
        }
        void Tongsoluongthuoc()
        {
            adatetime = DateTime.Now;
            int today = Convert.ToInt32(adatetime.Day);
            int month = Convert.ToInt32(adatetime.Month);
            int year = Convert.ToInt32(adatetime.Year);

            tongsoluongSP.DataSource = ThuocDAO.Instance.DanhSachTongSoLuongThuoc();
            lblTongSoLuongThuoc.DataBindings.Add(new Binding("Text", tongsoluongSP, "SoLuong"));

            tongsoluongSPhomnay.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachSoLuongNhapHomNay(today, month, year);
            lblNhapKhoHomNay.DataBindings.Add(new Binding("Text", tongsoluongSPhomnay, "SoLuong"));
        }
        void Doanhso()
        {
            adatetime = DateTime.Now;
            int today = Convert.ToInt32(adatetime.Day);
            int month = Convert.ToInt32(adatetime.Month);
            int year = Convert.ToInt32(adatetime.Year);

            doanhsothang.DataSource = HoaDonDAO.Instance.DanhSachDoanhSoThang(month, year);
            lblDoanhSoTrongThang.DataBindings.Add(new Binding("Text", doanhsothang, "DoanhSo"));

            doanhsohomnay.DataSource = HoaDonDAO.Instance.DanhSachDoanhSoHomNay(today, month, year);
            lblDoanhSoTrongHomNay.DataBindings.Add(new Binding("Text", doanhsohomnay, "DoanhSo"));
        }
        void PhiNhapKho()
        {
            adatetime = DateTime.Now;
            int today = Convert.ToInt32(adatetime.Day);
            int month = Convert.ToInt32(adatetime.Month);
            int year = Convert.ToInt32(adatetime.Year);

            phinhapthang.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachPhiNhapThang(month, year);
            lblPhiNhapKhoTrongThang.DataBindings.Add(new Binding("Text", phinhapthang, "PhiNhap"));

            phinhaphomnay.DataSource = HoaDonNhapKhoDAO.Instance.DanhSachPhiNhapHomNay(today, month, year);
            lblPhiNhapKhoTrongNgay.DataBindings.Add(new Binding("Text", phinhaphomnay, "PhiNhap"));
        }
        void TienLoiTrongThang()
        {
            adatetime = DateTime.Now;
            int today = Convert.ToInt32(adatetime.Day);
            int month = Convert.ToInt32(adatetime.Month);
            int year = Convert.ToInt32(adatetime.Year);

            tienloithang.DataSource = HoaDonNhapKhoDAO.Instance.TienLoiTrongThang(month, year);
            lblTienLoiTrongThang.DataBindings.Add(new Binding("Text", tienloithang, "TienLoi"));
        }
        #endregion

        #region Event
        private void txtTenKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvDoanhThu.DataSource = HoaDonDAO.Instance.LayDanhSachDoanhThuTheoTenkhachHang(txtTenKhachHang.Text);
            }
        }

        private void cbxNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvDoanhThu.DataSource = HoaDonDAO.Instance.LayDanhSachDoanhThuTheoTenNhanVien(cbxNhanVien.Text);
            txtTenKhachHang.Text = "";
        }

        private void dtpkDenNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvDoanhThu.DataSource = HoaDonDAO.Instance.DoanhThuTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
            txtTenKhachHang.Text = "";
        }

        private void dtpkTuNgay_ValueChanged(object sender, EventArgs e)
        {
            dtgvDoanhThu.DataSource = HoaDonDAO.Instance.DoanhThuTheoNgay(dtpkTuNgay.Value, dtpkDenNgay.Value);
            txtTenKhachHang.Text = "";
        }
        #endregion
    }
}
