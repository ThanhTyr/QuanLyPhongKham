using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class ChiTietHoaDon
    {
        public ChiTietHoaDon(int idChiTietHoaDon, int soluong)
        {
            this.IdChiTietHoaDon = idChiTietHoaDon;
            this.Soluong = soluong;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.IdChiTietHoaDon = (int)row["id"];
            this.Soluong = (int)row["soluong"];
        }

        private int idChiTietHoaDon;
        private int soluong;

        public int IdChiTietHoaDon { get => idChiTietHoaDon; set => idChiTietHoaDon = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
