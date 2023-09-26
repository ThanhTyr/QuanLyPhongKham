using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DAO
{
    public class HangChoDAO
    {
        private static HangChoDAO instance;

        public static HangChoDAO Instance
        {
            get { if (instance == null) instance = new HangChoDAO(); return instance; }
            private set => instance = value;
        }

        private HangChoDAO() { }
        public DataTable LayDanhSachHen()
        {
            return DataProvider.Instance.Executequery("select h.id as [Mã Hẹn], h.thoigianhen as [Thời Gian], bn.tenbn as [Họ Tên], (YEAR(GETDATE()) - bn.namsinhbn) as [Tuổi], bn.gioitinhbn as [Giới Tính], bn.sdtbn as [Liên Hệ], h.noidung as [Nội dung], bn.ghichu as [Ghi Chú], nv.tennv as [Bác Sĩ], h.tinhtrang as [Tình Trang], h.idBenhNhan as [Mã Bệnh Nhân] from dbo.HangCho as h, dbo.BenhNhan as bn, dbo.NhanVien as nv where h.idBenhNhan = bn.id and h.idNhanVien = nv.id");
        }
        public DataTable DanhSachHenTheoTimKiem(string bacsi)
        {
            string query = string.Format("select h.id as [Mã Hẹn], h.thoigianhen as [Thời Gian], bn.tenbn as [Họ Tên], (YEAR(GETDATE()) - bn.namsinhbn) as [Tuổi], bn.gioitinhbn as [Giới Tính], bn.sdtbn as [Liên Hệ], h.noidung as [Nội dung], bn.ghichu as [Ghi Chú], nv.tennv as [Bác Sĩ], h.tinhtrang as [Tình Trang], h.idBenhNhan as [Mã Bệnh Nhân] from dbo.HangCho as h, dbo.BenhNhan as bn, dbo.NhanVien as nv where h.idBenhNhan = bn.id and h.idNhanVien = nv.id and nv.tennv = N'{0}'", bacsi);
            return DataProvider.Instance.Executequery(query);
        }
        
        
    }
}
