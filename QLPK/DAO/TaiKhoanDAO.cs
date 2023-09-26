using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance
        {
            get { if (instance == null) instance = new TaiKhoanDAO(); return instance; }
            private set => instance = value;
        }

        private TaiKhoanDAO() { }
        public DataTable LayDanhSachTaiKhoan()
        {
            return DataProvider.Instance.Executequery("select tk.taikhoan, tk.loaitk, nv.tennv from dbo.TaiKhoan as tk, NhanVien as nv where tk.idNhanVien = nv.id");
        }
        public bool ResetMatKhau(string taikhoan)
        {
            string query = string.Format("update TaiKhoan set matkhau = N'0' where taikhoan = N'{0}'", taikhoan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool InsertTaiKhoan(string taikhoan, int idnhanvien, int loaitk)
        {
            string query = string.Format("insert dbo.TaiKhoan (taikhoan, idNhanVien, loaitk )values (N'{0}', N'{1}', {2})", taikhoan, idnhanvien, loaitk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool UpdateTaiKhoan(string taiKhoan, int idnhanvien, int loaitk)
        {
            string query = string.Format("update dbo.TaiKhoan set idNhanVien = N'{1}', loaitk = {2} where taikhoan = N'{0}'", taiKhoan, idnhanvien, loaitk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }

        public bool DeleteTaiKhoan(string taikhoan)
        {
            string query = string.Format("Delete TaiKhoan where taikhoan = N'{0}'", taikhoan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
