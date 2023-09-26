using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class DanhSachKhamDAO
    {
        private static DanhSachKhamDAO instance;

        public static DanhSachKhamDAO Instance
        {
            get { if (instance == null) instance = new DanhSachKhamDAO(); return instance; }
            private set => instance = value;
        }

        private DanhSachKhamDAO() { }
        public DataTable LayDanhSachKham()
        {
            return DataProvider.Instance.Executequery("select dsk.ngaykham as [Ngày Khám], dsk.stt as [Số Thứ Tự], dsk.id as [Mã Khám], bn.id as [Mã Bênh Nhân], bn.tenbn as [Tên Bệnh Nhân], bn.sdtbn as [Số Điện Thoại] from DanhSachKham as dsk, BenhNhan as bn where dsk.idBenhNhan = bn.id and dsk.ngaykham = CONVERT(varchar, GETDATE(), 111) and dsk.tinhtrang = 0");
        }
        public DataTable TimKiemDanhSachKham(string name)
        {
            string query = string.Format("select dsk.ngaykham as [Ngày Khám], dsk.stt as [Số Thứ Tự], dsk.id as [Mã Khám], bn.id as [Mã Bênh Nhân], bn.tenbn as [Tên Bệnh Nhân], bn.sdtbn as [Số Điện Thoại] from DanhSachKham as dsk, BenhNhan as bn where dsk.idBenhNhan = bn.id and dsk.ngaykham = CONVERT(varchar, GETDATE(), 111) and dsk.tinhtrang = 0 and bn.tenbn like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }

        public int KiemTraDanhSachKham()
        {
            DataTable data = DataProvider.Instance.Executequery("select * from DanhSachKham where ngaykham = CONVERT(varchar, GETDATE(), 111)");

            if (data.Rows.Count > 0)
            {
                DanhSachKham benhnhan = new DanhSachKham(data.Rows[0]);
                return benhnhan.Idbenhnhan;
            }

            return -1;
        }
        public int KiemTraDanhSachKhamTheoNgay(string ngaykham)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from DanhSachKham where ngaykham = '"+ ngaykham+"'");

            if (data.Rows.Count > 0)
            {
                DanhSachKham benhnhan = new DanhSachKham(data.Rows[0]);
                return benhnhan.Stt;
            }

            return -1;
        }
        public int KiemTraDanhSachKham2(int idbenhnhan)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from DanhSachKham where idBenhNhan = "+ idbenhnhan + " and ngaykham = CONVERT(varchar, GETDATE(), 111) and tinhtrang = 0");

            if (data.Rows.Count > 0)
            {
                DanhSachKham benhnhan = new DanhSachKham(data.Rows[0]);
                return benhnhan.Idbenhnhan;
            }

            return -1;
        }
        public bool ThemVaoDanhSachKham(int idbenhnhan, int stt)
        {
            string query = string.Format("insert dbo.DanhSachKham (idBenhNhan, stt) values ({0}, {1})", idbenhnhan, stt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public int LayMaxSTT()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MAX(stt) from dbo.DanhSachKham where tinhtrang = 0");
        }
        public int LayMaxSTTNgayHen(string ngaykham)
        {
            return (int)DataProvider.Instance.ExecuteScalar("select MAX(stt) from dbo.DanhSachKham where tinhtrang = 0 and ngaykham = '" + ngaykham + "'");
        }
        public void ThanhToan(int idbenhnhan)
        {
            string query = "update dbo.DanhSachKham set tinhtrang = 1 where idBenhNhan = " + idbenhnhan + " and ngaykham = CONVERT(varchar, GETDATE(), 111) and tinhtrang = 0 ";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public DataTable DanhSachHenTheoNgay(DateTime ngayBD, DateTime ngayKT)
        {
            return DataProvider.Instance.Executequery("exec USP_DanhSachHenTheoNgay @ngayBD , @ngayKT", new object[] { ngayBD, ngayKT });
        }
        public bool DeleteHen(int idhen)
        {
            string query = string.Format("delete DanhSachKham where id = N'{0}'", idhen);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool UpdateHen(int id, int idbenhnhan, DateTime? thoigianhen)
        {
            string query = string.Format("update dbo.DanhSachKham set ngaykham = '{1}', idBenhNhan = '{2}' where id = '{0}'", id, thoigianhen, idbenhnhan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool Inserthen(int idbenhnhan, int stt, string thoigianhen)
        {
            string query = string.Format("insert dbo.DanhSachKham (idBenhNhan, stt, ngaykham) values ({0}, {1}, N'{2}')", idbenhnhan, stt, thoigianhen);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
