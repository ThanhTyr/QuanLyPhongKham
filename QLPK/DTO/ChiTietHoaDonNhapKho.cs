using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class ChiTietHoaDonNhapKho
    {
        public ChiTietHoaDonNhapKho(int idchitiethoadonnhapkho, int soluong)
        {
            this.Idchitiethoadonnhapkho = idchitiethoadonnhapkho;
            this.Soluong = soluong;
        }

        public ChiTietHoaDonNhapKho(DataRow row)
        {
            this.Idchitiethoadonnhapkho = (int)row["id"];
            this.Soluong = (int)row["soluong"];
        }

        private int idchitiethoadonnhapkho;
        private int soluong;

        public int Idchitiethoadonnhapkho { get => idchitiethoadonnhapkho; set => idchitiethoadonnhapkho = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
