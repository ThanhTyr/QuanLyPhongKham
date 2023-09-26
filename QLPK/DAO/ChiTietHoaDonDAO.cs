using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietHoaDonDAO() { }

        public DataTable LayDanhSachChiTietHoaDon(string id)
        {
            string query = string.Format("select hd.ngayban as [Ngày], t.tenthuoc as [Tên Thuốc], cthd.soluong as [Số Lượng], dvt.tendonvi as [Đơn Vị Tính], t.giale as [Đơn Giá], t.giale*cthd.soluong as [Thành Tiền] from dbo.BenhAn as ba, dbo.HoaDon as hd, dbo.ChiTietHoaDon as cthd, dbo.Thuoc as t, dbo.DonViTinh as dvt where ba.idHoaDon = hd.id and cthd.idHoaDon = hd.id and cthd.idThuoc = t.id and t.idDonViTinh = dvt.id and hd.id = {0}", id);
            return DataProvider.Instance.Executequery(query);
        }
        public List<GioHang> DanhSachToaThuocTheoIDHoaDon(int idhd)
        {
            List<GioHang> danhsachtoathuoc = new List<GioHang>();

            string query = string.Format("select cthd.id, t.tenthuoc, t.giale, t.chucnang, dvt.tendonvi, cthd.soluong, t.giale*cthd.soluong as thanhtien from ChiTietHoaDon as cthd, Thuoc as t, DonViTinh as dvt, HoaDon as hd where cthd.idThuoc = t.id and t.idDonViTinh = dvt.id and cthd.idHoaDon = hd.id and hd.id = '{0}' and hd.tinhtrang = 0", idhd);
            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                GioHang toathuoc = new GioHang(item);
                danhsachtoathuoc.Add(toathuoc);
            }

            return danhsachtoathuoc;
        }
        public List<GioHang> DanhSachToaThuocTheoIDHoaDon2(int idhd)
        {
            List<GioHang> danhsachtoathuoc = new List<GioHang>();

            string query = string.Format("select cthd.id, t.tenthuoc, t.giale, t.chucnang, dvt.tendonvi, cthd.soluong, t.giale*cthd.soluong as thanhtien from ChiTietHoaDon as cthd, Thuoc as t, DonViTinh as dvt, HoaDon as hd where cthd.idThuoc = t.id and t.idDonViTinh = dvt.id and cthd.idHoaDon = hd.id and hd.id = '{0}'", idhd);
            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                GioHang toathuoc = new GioHang(item);
                danhsachtoathuoc.Add(toathuoc);
            }

            return danhsachtoathuoc;
        }
        public void ThemChiTietHoaDon(int idhoadon, int idthuoc, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_ThemChiTietHoaDon @idHoaDon , @idThuoc , @soluong", new object[] { idhoadon, idthuoc, soluong });
        }
    }
}
