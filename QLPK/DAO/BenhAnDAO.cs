using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class BenhAnDAO
    {
        private static BenhAnDAO instance;

        public static BenhAnDAO Instance
        {
            get { if (instance == null) instance = new BenhAnDAO(); return instance; }
            private set => instance = value;
        }

        private BenhAnDAO() { }

        public DataTable LayDanhSachBenhAn(string id)
        {
            string query = string.Format("select ba.id as [Mã Bệnh Án], ba.lydokham as [Lý Do Khám], ba.trieuchung as [Triệu Chứng], ba.sieuam as [Siêu Âm], ba.chuandoan as [Chuẩn Đoán], ba.loidan as [Lời Dặn], ba.ngaylap as [Ngày Lập], hd.tongtien as [Tổng Tiền], ba.tinhtrang as [Tình Trạng], nv.tennv as [Bác Sĩ], hd.id as [Mã Hóa Đơn] from dbo.BenhAn as ba, dbo.BenhNhan as bn , dbo.HoaDon as hd, NhanVien as nv where ba.idHoaDon = hd.id and ba.idBenhNhan = bn.id and ba.idNhanVien = nv.id and ba.idBenhNhan = {0}", id);
            return DataProvider.Instance.Executequery(query);
        }

        public int KiemTraBenhAn(int idbn)
        {
            DataTable data = DataProvider.Instance.Executequery("select * from BenhAn where idBenhNhan = " + idbn + "");

            if (data.Rows.Count > 0)
            {
                BenhAn benhan = new BenhAn(data.Rows[0]);
                return benhan.IdBenhAn;
            }

            return -1;
        }
        public bool ThemToaVaoBenhAn(string lydokham, string trieuchung, string sieuam, string chuandoan, string loidan, int idnhanvien, int idbenhnhan, int idhoadon)
        {
            string query = string.Format("insert dbo.BenhAn (lydokham, trieuchung, sieuam, chuandoan, loidan, idNhanVien, idBenhNhan, idHoaDon) values (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', {5}, {6}, {7})", lydokham, trieuchung, sieuam, chuandoan, loidan, idnhanvien, idbenhnhan, idhoadon);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;

        }
    }
}
