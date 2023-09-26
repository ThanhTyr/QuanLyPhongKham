using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO() { }

        public DataTable LayDanhSachNhanVien()
        {
            return DataProvider.Instance.Executequery("select nv.id as [Mã Nhân Viên], nv.tennv as [Họ Tên], nv.namsinhnv as [Năm Sinh], nv.gioitinhnv as [Giới Tính], nv.diachinv as [Địa Chỉ], nv.sdtnv as [Số Điện Thoại], nv.emailnv as [Email], nv.chucvu as [Chức Vụ], nv.vitri as [Vị Trí] from dbo.NhanVien as nv");
        }

        public List<NhanVien> TimDanhSachNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = "SELECT * FROM NhanVien";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(item);
                list.Add(nhanVien);
            }

            return list;
        }

        public DataTable TimKiemDanhSachNhanVien(string name)
        {
            string query = string.Format("select nv.id as [Mã Nhân Viên], nv.tennv as [Họ Tên], nv.namsinhnv as [Năm Sinh], nv.gioitinhnv as [Giới Tính], nv.diachinv as [Địa Chỉ], nv.sdtnv as [Số Điện Thoại], nv.emailnv as [Email], nv.chucvu as [Chức Vụ], nv.vitri as [Vị Trí] from dbo.NhanVien as nv where nv.tennv like N'%{0}%'", name);
            return DataProvider.Instance.Executequery(query);
        }
        public bool DeleteNhanVien(int idnhanvien)
        {
            string query = string.Format("delete NhanVien where id = N'{0}'", idnhanvien);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool UpdateNhanVien(int id, string tennv, int namsinhnv, string gioitinhnv, string diachinv, string sdtnv, string emailnv, string chucvu, string vitri)
        {
            string query = string.Format("update dbo.NhanVien set tennv = N'{1}', namsinhnv = {2}, gioitinhnv = N'{3}', diachinv = N'{4}', sdtnv = N'{5}', emailnv = N'{6}', chucvu = N'{7}', vitri = N'{8}' where id = {0}", id, tennv, namsinhnv, gioitinhnv, diachinv, sdtnv, emailnv, chucvu, vitri);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public bool InsertNhanVien(string tennv, int namsinhnv, string gioitinhnv, string diachinv, string sdtnv, string emailnv, string chucvu, string vitri)
        {
            string query = string.Format("insert dbo.NhanVien (tennv, namsinhnv, gioitinhnv, diachinv, sdtnv, emailnv, chucvu, vitri) values (N'{0}', {1}, N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", tennv, namsinhnv, gioitinhnv, diachinv, sdtnv, emailnv, chucvu, vitri);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
        public List<NhanVien> LayDanhSachBacSi()
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = "select * from NhanVien where vitri = N'Bác Sĩ'";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }

            return list;
        }
        public List<NhanVien> LayDanhSachBacSi2()
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = "select * from NhanVien";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }

            return list;
        }
    }
}
