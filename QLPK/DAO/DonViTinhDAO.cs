using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class DonViTinhDAO
    {
        private static DonViTinhDAO instance;

        public static DonViTinhDAO Instance
        {
            get { if (instance == null) instance = new DonViTinhDAO(); return instance; }
            private set => instance = value;
        }

        private DonViTinhDAO() { }

        public List<DonViTinh> LayDanhSachDonViTinh()
        {
            List<DonViTinh> list = new List<DonViTinh>();

            string query = "select * from DonViTinh";

            DataTable data = DataProvider.Instance.Executequery(query);

            foreach (DataRow item in data.Rows)
            {
                DonViTinh donvitinh = new DonViTinh(item);
                list.Add(donvitinh);
            }

            return list;
        }
        public bool InsertDonViTinh(string tendvt)
        {
            string query = string.Format("insert dbo.DonViTinh (tendonvi) values (N'{0}')", tendvt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
