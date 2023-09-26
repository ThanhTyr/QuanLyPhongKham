using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class LoaiThuocDAO
    {
        private static LoaiThuocDAO instance;

        public static LoaiThuocDAO Instance
        {
            get { if (instance == null) instance = new LoaiThuocDAO(); return instance; }
            private set => instance = value;
        }

        private LoaiThuocDAO() { }

        public List<LoaiThuoc> LayDanhSachLoai()
        {
            List<LoaiThuoc> list = new List<LoaiThuoc>();

            string query = "SELECT * FROM LoaiThuoc";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                LoaiThuoc loaithuoc = new LoaiThuoc(item);
                list.Add(loaithuoc);
            }

            return list;
        }

        public DataTable TimKiemDanhSachThuoc(string name)
        {
            string query = string.Format("select t.id as [Mã Thuốc], t.tenthuoc as [Tên Thuốc], t.duonguong as [Đường Uống], t.dangbaoche as [Dạng Bào Chế], t.hamluong as [Hàm Lượng], t.thanhphan as [Thành Phần], t.hinhdang as [Hình Dáng], t.handung as [Hạn Dùng], t.chucnang as [Chức Năng], t.soluong as [Số Lượng], t.gianhap as [Giá Nhập], t.giasi as [Giá Sỉ], t.giale as [Giá Lẻ], t.giankhuyenmai as [Giá Khuyến Mãi], lt.tenloai as [Tên Loại], dvt.tendonvi as [Đơn Vị], nsx.tennhasanxuat as [Nhà Sản Xuất] from dbo.Thuoc as t, dbo.LoaiThuoc as lt, dbo.DonViTinh as dvt, dbo.NhaSanXuat as nsx where t.idLoaiThuoc = lt.id and t.idDonViTinh = dvt.id and t.idNhaSanXuat = nsx.id and lt.tenloai like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }
        public bool InsertLoaiThuoc(string tenLoai)
        {
            string query = string.Format("insert dbo.LoaiThuoc (tenloai) values (N'{0}')", tenLoai);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
