using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return instance; }
            private set => instance = value;
        }

        private HoaDonDAO() { }
        public DataTable LayDanhSachHoaDon()
        {
            return DataProvider.Instance.Executequery("select hd.id as [Mã Hóa Đơn], bn.id as [Mã Bệnh Nhân], nv.tennv as [Nhân Viên], bn.tenbn as [Bệnh Nhân], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [SĐT], hd.tongtien as [Tổng Tiền], hd.ngayban as [Ngày Bán], hd.tinhtrang as [Tình Trạng] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idNhanVien = nv.id and hd.idBenhNhan = bn.id");
        }
        public List<HoaDon> TimDanhSachMaHoaDon()
        {
            List<HoaDon> list = new List<HoaDon>();

            string query = "SELECT * FROM HoaDon";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                HoaDon hoadon = new HoaDon(item);
                list.Add(hoadon);
            }

            return list;
        }
        public DataTable DanhSachHoaDonTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return DataProvider.Instance.Executequery("exec USP_DanhSachHoaDonTheoNgay @ngayBD , @ngayKT", new object[] { ngayBD, ngayKT });
        }
        public DataTable TimKiemDanhSachHoaDonTheoID(int idhoadon)
        {
            string query = string.Format("select hd.id as [Mã Hóa Đơn], bn.id as [Mã Bệnh Nhân], nv.tennv as [Nhân Viên], bn.tenbn as [Bệnh Nhân], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [SĐT], hd.tongtien as [Tổng Tiền], hd.ngayban as [Ngày Bán], hd.tinhtrang as [Tình Trạng] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idNhanVien = nv.id and hd.idBenhNhan = bn.id and hd.id = {0}", idhoadon);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable TimKiemDanhSachHoaDonTheoTen(string ten)
        {
            string query = string.Format("select hd.id as [Mã Hóa Đơn], bn.id as [Mã Bệnh Nhân], nv.tennv as [Nhân Viên], bn.tenbn as [Bệnh Nhân], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [SĐT], hd.tongtien as [Tổng Tiền], hd.ngayban as [Ngày Bán], hd.tinhtrang as [Tình Trạng] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idNhanVien = nv.id and hd.idBenhNhan = bn.id and bn.tenbn like N'%{0}%'", ten);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable TimKiemDanhSachHoaDonTheoNhanVien(string tennv)
        {
            string query = string.Format("select hd.id as [Mã Hóa Đơn], bn.id as [Mã Bệnh Nhân], nv.tennv as [Nhân Viên], bn.tenbn as [Bệnh Nhân], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [SĐT], hd.tongtien as [Tổng Tiền], hd.ngayban as [Ngày Bán], hd.tinhtrang as [Tình Trạng] from HoaDon as hd, ChiTietHoaDon as cthd, NhanVien as nv, BenhNhan as bn where hd.idNhanVien = nv.id and hd.idBenhNhan = bn.id and cthd.idHoaDon = hd.id and nv.tennv = N'{0}'", tennv);
            return DataProvider.Instance.Executequery(query);
        }
        public int LayDanhSachHoaDonChuaThanhToan(int idbenhnhan)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from HoaDon where idBenhNhan = " + idbenhnhan + " and tinhtrang = 0");

            if (data.Rows.Count > 0)
            {
                HoaDon hoadon = new HoaDon(data.Rows[0]);
                return hoadon.IdHoaDon;
            }

            return -1;
        }
        public void ThemHoaDon(int idnv, int idbn)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_ThemHoaDon @idNV , @idBN", new object[] { idnv, idbn });
        }
        public int LayMaxHoaDon()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MAX(id) from dbo.HoaDon");
        }
        public void ThanhToan(int idHoaDon, float thanhtoan)
        {
            string query = "update dbo.HoaDon set tinhtrang = 1, tongtien = '" + thanhtoan + "' where id = " + idHoaDon;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable LayDanhSachDoanhThu()
        {
            return DataProvider.Instance.Executequery("select hd.id as [Mã hóa đơn], nv.tennv as [Tên bác sĩ], bn.tenbn as [Tên khách hàng], hd.tongtien as [Tổng tiền], hd.ngayban as [Ngày bán] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and hd.tinhtrang = 1");
        }
        public DataTable LayDanhSachDoanhThuTheoTenkhachHang(string tenkh)
        {
            string query = string.Format("select hd.id as [Mã hóa đơn], nv.tennv as [Tên bác sĩ], bn.tenbn as [Tên khách hàng], hd.tongtien as [Tổng tiền], hd.ngayban as [Ngày bán] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and hd.tinhtrang = 1 and bn.tenbn like N'%{0}%'", tenkh);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable LayDanhSachDoanhThuTheoTenNhanVien(string tennhanVien)
        {
            string query = string.Format("select hd.id as [Mã hóa đơn], nv.tennv as [Tên bác sĩ], bn.tenbn as [Tên khách hàng], hd.tongtien as [Tổng tiền], hd.ngayban as [Ngày bán] from HoaDon as hd, NhanVien as nv, BenhNhan as bn where hd.idBenhNhan = bn.id and hd.idNhanVien = nv.id and hd.tinhtrang = 1 and nv.tennv = N'{0}'", tennhanVien);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable DoanhThuTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return DataProvider.Instance.Executequery("exec [USP_DoanhThuTheoNgay] @ngayBD , @ngayKT", new object[] { ngayBD, ngayKT });
        }
        public DataTable DanhSachTongTienTheoThang()
        {
            return DataProvider.Instance.Executequery("Select month(hd.ngayban) as 'Thang', Sum(hd.tongtien) as 'DoanhThu' From HoaDon as hd Group by month(hd.ngayban)");
        }
        public DataTable DanhSachHoanDonThang(int month, int year)
        {
            return DataProvider.Instance.Executequery("select COUNT(hd.id) as soHD from HoaDon as hd where month(hd.ngayban) = '" + month + "' and year(hd.ngayban) = " + year);
        }
        public DataTable DanhSachHoaDonHomNay(int today, int month, int year)
        {
            return DataProvider.Instance.Executequery("select COUNT(hd.id) as soHDtoday from HoaDon as hd where day(hd.ngayban) = '" + today + "' and month(hd.ngayban) = '" + month + "' and year(hd.ngayban) = " + year);
        }
        public DataTable DanhSachDoanhSoThang(int month, int year)
        {
            return DataProvider.Instance.Executequery("select sum(hd.tongtien) as DoanhSo from HoaDon as hd where MONTH(hd.ngayban) = '" + month + "' and YEAR(hd.ngayban) = " + year);
        }

        public DataTable DanhSachDoanhSoHomNay(int today, int month, int year)
        {
            return DataProvider.Instance.Executequery("select sum(hd.tongtien) as DoanhSo from HoaDon as hd where MONTH(hd.ngayban) = '" + month + "' and YEAR(hd.ngayban) = '" + year + "' and DAY(hd.ngayban) = " + today);
        }
    }
}
