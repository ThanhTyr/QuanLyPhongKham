using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class BenhNhanDAO
    {
        private static BenhNhanDAO instance;

        public static BenhNhanDAO Instance
        {
            get { if (instance == null) instance = new BenhNhanDAO(); return instance; }
            private set => instance = value;
        }

        private BenhNhanDAO() { }

        public DataTable LayDanhSachBenhNhan()
        {
            return DataProvider.Instance.Executequery("select bn.id as [Mã Bệnh Nhân], bn.tenbn as [Họ Tên], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [Số Điện Thoại], bn.emailbn as [Email], bn.tieusubenh as [Tiểu Sử Bệnh], bn.ghichu as [Ghi Chú], bn.ngaytao as [Ngày Tạo] from dbo.BenhNhan as bn");
        }

        public List<BenhNhan> TimDanhSachBenhNhan()
        {
            List<BenhNhan> list = new List<BenhNhan>();

            string query = "SELECT * FROM BenhNhan";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                BenhNhan benhnhan = new BenhNhan(item);
                list.Add(benhnhan);
            }

            return list;
        }
        public DataTable TimKiemDanhSachKham(string name)
        {
            string query = string.Format("select GETDATE() as [Ngày Khám], dsk.stt as [Số Thứ Tự], dsk.id as [Mã Khám], bn.id as [Mã Bênh Nhân], bn.tenbn as [Tên Bệnh Nhân] from DanhSachKham as dsk, BenhNhan as bn where dsk.idBenhNhan = bn.id and bn.tenbn like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }

        public DataTable TimKiemDanhSachBenhNhan(string name)
        {
            string query = string.Format("select bn.id as [Mã Bệnh Nhân], bn.tenbn as [Họ Tên], bn.namsinhbn as [Năm Sinh], bn.gioitinhbn as [Giới Tính], bn.diachibn as [Địa Chỉ], bn.sdtbn as [Số Điện Thoại], bn.emailbn as [Email], bn.tieusubenh as [Tiểu Sử Bệnh], bn.ghichu as [Ghi Chú], bn.ngaytao as [Ngày Tạo] from dbo.BenhNhan as bn where bn.tenbn like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }
        public DataTable TimKiemDanhSachBenhNhanTheoID(string idnv)
        {
            string query = string.Format("select * from dbo.BenhNhan as bn where bn.id = '{0}'", idnv);
            return DataProvider.Instance.Executequery(query);
        }
        public bool DeleteBenhNhan(int idbenhnhan)
        {
            string query = string.Format("delete BenhNhan where id = N'{0}'", idbenhnhan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool UpdateBenhNhan(int id, string tenbn, int namsinhbn, string gioitinhbn, string diachibn, string sdtbn, string emailbn, string tieusubenh, string ghichu, string ngaytao)
        {
            string query = string.Format("update dbo.BenhNhan set tenbn = N'{1}', namsinhbn = {2}, gioitinhbn = N'{3}', diachibn = N'{4}', sdtbn = N'{5}', emailbn = N'{6}', tieusubenh = N'{7}', ghichu = N'{8}', ngaytao = N'{9}' where id = {0}", id, tenbn, namsinhbn, gioitinhbn, diachibn, sdtbn, emailbn, tieusubenh, ghichu, ngaytao);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool InsertBenhNhan(string tenbn, int namsinhbn, string gioitinhbn, string diachibn, string sdtbn, string emailbn, string tieusubenh, string ghichu, string ngaytao)
        {
            string query = string.Format("insert dbo.BenhNhan (tenbn, namsinhbn, gioitinhbn, diachibn, sdtbn, emailbn, tieusubenh, ghichu, ngaytao ) values (N'{0}', {1}, N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}')", tenbn, namsinhbn, gioitinhbn, diachibn, sdtbn, emailbn, tieusubenh, ghichu, ngaytao);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool InsertBenhNhanHen(string tenbn, int namsinhbn, string gioitinhbn, string sdtbn, string ngaytao)
        {
            string query = string.Format("insert dbo.BenhNhan (tenbn, namsinhbn, gioitinhbn, sdtbn, ngaytao ) values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", tenbn, namsinhbn, gioitinhbn, sdtbn, ngaytao);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public int LayMaxBenhNhan()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MAX(id) from dbo.BenhNhan");
        }
    }
}
