using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class NhaSanXuatDAO
    {
        private static NhaSanXuatDAO instance;

        public static NhaSanXuatDAO Instance
        {
            get { if (instance == null) instance = new NhaSanXuatDAO(); return instance; }
            private set => instance = value;
        }

        private NhaSanXuatDAO() { }

        public List<NhaSanXuat> LayDanhSachNhaSanXuat()
        {
            List<NhaSanXuat> list = new List<NhaSanXuat>();

            string query = "select * from NhaSanXuat";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                NhaSanXuat nhasanxuat = new NhaSanXuat(item);
                list.Add(nhasanxuat);
            }

            return list;
        }
        public bool InsertNhaSanXuat(string tennsx)
        {
            string query = string.Format("insert dbo.NhaSanXuat (tennhasanxuat) values (N'{0}')", tennsx);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
