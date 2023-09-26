using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class ThuocDAO
    {
        private static ThuocDAO instance;

        public static ThuocDAO Instance
        {
            get { if (instance == null) instance = new ThuocDAO(); return instance; }
            private set => instance = value;
        }

        private ThuocDAO() { }

        public DataTable LayDanhSachThuoc()
        {
            return DataProvider.Instance.Executequery("exec USP_LayDanhSachThuoc");
        }

        public List<Thuoc> TimDanhSachThuoc()
        {
            List<Thuoc> list = new List<Thuoc>();

            string query = "select * from Thuoc";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                Thuoc thuoc = new Thuoc(item);
                list.Add(thuoc);
            }

            return list;
        }

        public DataTable TimKiemDanhSachThuoc(string name)
        {
            string query = string.Format("select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.duonguong as [Đường Uống], t.dangbaoche as [Dạng Bào Chế], t.hamluong as [Hàm Lượng], t.thanhphan as [Thành Phần], t.hinhdang as [Hình Dáng], t.handung as [Hạn Dùng], t.chucnang as [Chức Năng], t.soluong as [Số Lượng], t.gianhap as [Giá Nhập], t.giasi as [Giá Sỉ], t.giale as [Giá Lẻ], t.giankhuyenmai as [Giá Khuyến Mãi], lt.tenloai as [Tên Loại], dvt.tendonvi as [Đơn Vị], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.Thuoc as t, dbo.LoaiThuoc as lt, dbo.DonViTinh as dvt, dbo.NhaSanXuat as nsx where t.idLoaiThuoc = lt.id and t.idDonViTinh = dvt.id and t.idNhaSanXuat = nsx.id and t.tenthuoc like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }

        public bool UpdateThuoc(int id, string tenthuoc, string duonguong, string dangbaoche, string hamluong, string thanhphan, string hinhdang, string handung, string chucnang, float gianhap, float giasi, float giale, float giankhuyenmai, int idloaithuoc, int idnhasanxuat, int iddonvitinh)
        {
            string query = string.Format("update dbo.Thuoc set tenthuoc = N'{1}', duonguong = N'{2}', dangbaoche = N'{3}', hamluong = N'{4}', thanhphan = N'{5}', hinhdang = N'{6}', handung = N'{7}', chucnang = N'{8}', gianhap = N'{9}', giasi = N'{10}', giale = N'{11}', giankhuyenmai = N'{12}', idLoaiThuoc = N'{13}', idNhaSanXuat = N'{14}', idDonViTinh = N'{15}' where id = N'{0}'", id, tenthuoc, duonguong, dangbaoche, hamluong, thanhphan, hinhdang, handung, chucnang, gianhap, giasi, giale, giankhuyenmai, idloaithuoc, idnhasanxuat, iddonvitinh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool InsertThuoc(string tenthuoc, string duonguong, string dangbaoche, string hamluong, string thanhphan, string hinhdang, string handung, string chucnang, float gianhap, float giasi, float giale, float giankhuyenmai, int idloaithuoc, int idnhasanxuat, int iddonvitinh)
        {
            string query = string.Format("insert dbo.Thuoc (tenthuoc, duonguong, dangbaoche, hamluong, thanhphan, hinhdang, handung, chucnang, gianhap, giasi, giale, giankhuyenmai, idloaithuoc, idnhasanxuat, iddonvitinh) values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', {8}, {9}, {10}, {11}, {12}, {13}, {14})", tenthuoc, duonguong, dangbaoche, hamluong, thanhphan, hinhdang, handung, chucnang, gianhap, giasi, giale, giankhuyenmai, idloaithuoc, idnhasanxuat, iddonvitinh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool DeleteThuoc(int idthuoc)
        {
            string query = string.Format("delete Thuoc where id = N'{0}'", idthuoc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public DataTable LayDanhSachThuoc2()
        {
            return DataProvider.Instance.Executequery("select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.giale as [Giá Lẻ], t.chucnang as [Cách Dùng], dvt.tendonvi as [Đơn Vị] from dbo.Thuoc as t, dbo.DonViTinh as dvt");
        }
        public DataTable TimKiemDanhSachThuoc2(string name)
        {
            string query = string.Format("select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.giale as [Giá Lẻ], t.chucnang as [Cách Dùng], dvt.tendonvi as [Đơn Vị] from dbo.Thuoc as t, dbo.DonViTinh as dvt where  t.tenthuoc like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }
        public void CapNhapSoLuongThuoc(int idHoaDon)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_CapNhatSoLuongKho @idHoaDon", new object[] { idHoaDon });
        }
        public void CapNhapSoLuongThuocNhap(int idHoaDonNhapHang)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_CapNhatSoLuongKhoNhapHang @idHoaDonNhapHang", new object[] { idHoaDonNhapHang });
        }
        public DataTable DanhSachTongSoLuongThuoc()
        {
            return DataProvider.Instance.Executequery("select sum(t.soluong) as SoLuong from Thuoc as t");
        }
    }
}
