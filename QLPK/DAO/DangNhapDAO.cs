using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    class DangNhapDAO
    {
        private static DangNhapDAO instance;

        public static DangNhapDAO Instance
        {
            get { if (instance == null) instance = new DangNhapDAO(); return instance; }
            private set => instance = value;
        }

        private DangNhapDAO() { }

        public bool Login(string taikhoan, string matkhau)
        {
            string query = "USP_DangNhap @taiKhoan , @matKhau";
            DataTable result = DataProvider.Instance.Executequery(query, new object[] { taikhoan, matkhau });
            return result.Rows.Count > 0;
        }

        public DangNhap DangNhapBangTaiKhoan(string taikhoan)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from TaiKhoan where taikhoan = N'" + taikhoan + "'");

            foreach (DataRow item in data.Rows)
            {
                return new DangNhap(item);
            }

            return null;
        }
    }
}
