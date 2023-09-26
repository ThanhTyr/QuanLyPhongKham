using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class ChiTietHoaDonNhapKhoDAO
    {
        private static ChiTietHoaDonNhapKhoDAO instance;

        public static ChiTietHoaDonNhapKhoDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonNhapKhoDAO(); return instance; }
            private set => instance = value;
        }

        private ChiTietHoaDonNhapKhoDAO() { }
        public List<DonHangNhapKho> DanhSachNhapKhoTheoIDHoaDonNhapKho(int idhdnh)
        {
            List<DonHangNhapKho> danhsanhdonhangnhapkho = new List<DonHangNhapKho>();

            string query = string.Format("select cthdnh.id, t.tenthuoc, t.gianhap, t.chucnang, dvt.tendonvi, cthdnh.soluong, t.gianhap*cthdnh.soluong as thanhtien from ChiTietHoaDonNhapHang as cthdnh, Thuoc as t, DonViTinh as dvt, HoaDonNhapHang as hdnh where cthdnh.idThuoc = t.id and t.idDonViTinh = dvt.id and cthdnh.idHoaDonNhapHang = hdnh.id and hdnh.id = '{0}'", idhdnh);
            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                DonHangNhapKho donhangnhapkho = new DonHangNhapKho(item);
                danhsanhdonhangnhapkho.Add(donhangnhapkho);
            }

            return danhsanhdonhangnhapkho;
        }
        public void ThemChiTietHoaDonNhapKho(int idhoadonnhapkho, int idthuoc, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_ThemChiTietHoaDonNhapKho @idHoaDonNhapKho , @idThuoc , @soluong", new object[] { idhoadonnhapkho, idthuoc, soluong });
        }
    }
}
