using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class HoaDonNhapKhoDAO
    {
        private static HoaDonNhapKhoDAO instance;

        public static HoaDonNhapKhoDAO Instance
        {
            get { if (instance == null) instance = new HoaDonNhapKhoDAO(); return instance; }
            private set => instance = value;
        }

        private HoaDonNhapKhoDAO() { }
        public DataTable LayDanhSachKhoHang()
        {
            return DataProvider.Instance.Executequery("select hdnh.NgayNhap as [Ngày Nhập], hdnh.id as [Mã Nhập], nv.tennv as [Tên Nhân Viên], hdnh.tongtien as [Tổng Tiền Nhập], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.NhaSanXuat as nsx, dbo.HoaDonNhapHang as hdnh, dbo.NhanVien as nv where hdnh.idNhaSanXuat = nsx.id and hdnh.idNhanVien = nv.id and hdnh.tinhtrang = 1");
        }
        public DataTable TimKiemDanhSachKhoHang(int idhoadonnhaphang)
        {
            string query = string.Format("select hdnh.NgayNhap as [Ngày Nhập], hdnh.id as [Mã Nhập], nv.tennv as [Tên Nhân Viên], hdnh.tongtien as [Tổng Tiền Nhập], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.NhaSanXuat as nsx, dbo.HoaDonNhapHang as hdnh, dbo.NhanVien as nv where hdnh.idNhaSanXuat = nsx.id and hdnh.idNhanVien = nv.id and hdnh.tinhtrang = 1 and hdnh.id like '{0}'", idhoadonnhaphang);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable TimKiemNhanVienNhapKhoHang(string tennhanVien)
        {
            string query = string.Format("select hdnh.NgayNhap as [Ngày Nhập], hdnh.id as [Mã Nhập], nv.tennv as [Tên Nhân Viên], hdnh.tongtien as [Tổng Tiền Nhập], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.NhaSanXuat as nsx, dbo.HoaDonNhapHang as hdnh, dbo.NhanVien as nv where hdnh.idNhaSanXuat = nsx.id and hdnh.idNhanVien = nv.id and hdnh.tinhtrang = 1 and nv.tennv = N'{0}'", tennhanVien);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable DanhSachNhapHangTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return DataProvider.Instance.Executequery("exec [USP_DanhSachNhapHangTheoNgay] @ngayBD , @ngayKT", new object[] { ngayBD, ngayKT });
        }
        public DataTable DanhSachNhapHangTheoNhaSanXuat(string tennsx)
        {
            string query = string.Format("select hdnh.NgayNhap as [Ngày Nhập], hdnh.id as [Mã Nhập], nv.tennv as [Tên Nhân Viên], hdnh.tongtien as [Tổng Tiền Nhập], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.NhaSanXuat as nsx, dbo.HoaDonNhapHang as hdnh, dbo.NhanVien as nv where hdnh.idNhaSanXuat = nsx.id and hdnh.idNhanVien = nv.id and hdnh.tinhtrang = 1 and nsx.tennhasanxuat = N'{0}'", tennsx);
            return DataProvider.Instance.Executequery(query);
        }
        public int LayDanhSachHoaDonChuaThanhToan(int idnsx)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from HoaDonNhapHang where idNhaSanXuat = " + idnsx + " and tinhtrang = 0");

            if (data.Rows.Count > 0)
            {
                HoaDonNhapKho hoadonnhapkho = new HoaDonNhapKho(data.Rows[0]);
                return hoadonnhapkho.Idhoadonnhapkho;
            }

            return -1;
        }
        public void ThemHoaDonNhapKho(int idnv, int idnsx)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_ThemHoaDonNhapKho @idNV , @idNSX", new object[] { idnv, idnsx });
        }
        public int LayMaxHoaDonNhapKho()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MAX(id) from dbo.HoaDonNhapHang");
        }
        public void ThanhToan(int idHoaDonNhapHang, float thanhtoan)
        {
            string query = "update dbo.HoaDonNhapHang set tinhtrang = 1, tongtien = '" + thanhtoan + "' where id = " + idHoaDonNhapHang;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable DanhSachSoLuongNhapHomNay(int today, int month, int year)
        {
            return DataProvider.Instance.Executequery("select sum(cthdnh.soluong) as SoLuong from ChiTietHoaDonNhapHang as cthdnh, HoaDonNhapHang as hdnh where cthdnh.idHoaDonNhapHang = hdnh.id and year(hdnh.NgayNhap) = '" + year + "' and month(hdnh.NgayNhap) = '" + month + "' and day(hdnh.NgayNhap) = " + today);
        }
        public DataTable DanhSachPhiNhapThang(int month, int year)
        {
            return DataProvider.Instance.Executequery("select sum(hdnh.tongtien) as PhiNhap from HoaDonNhapHang as hdnh where MONTH(hdnh.NgayNhap) = '" + month + "' and YEAR(hdnh.NgayNhap) = " + year);
        }

        public DataTable DanhSachPhiNhapHomNay(int today, int month, int year)
        {
            return DataProvider.Instance.Executequery("select sum(hdnh.tongtien) as PhiNhap from HoaDonNhapHang as hdnh where MONTH(hdnh.NgayNhap) = '" + month + "' and YEAR(hdnh.NgayNhap) = '" + year + "' and DAY(hdnh.NgayNhap) = " + today);
        }
        public DataTable TienLoiTrongThang(int month, int year)
        {
            return DataProvider.Instance.Executequery("select (sum(hd.tongtien) - sum(hdnh.tongtien)) as TienLoi from HoaDon as hd, HoaDonNhapHang as hdnh where MONTH(hdnh.NgayNhap) = '" + month + "' and YEAR(hdnh.NgayNhap) = '" + year + "' and MONTH(hd.ngayban) = '" + month + "' and YEAR(hd.ngayban) = " + year);
        }
    }
}
