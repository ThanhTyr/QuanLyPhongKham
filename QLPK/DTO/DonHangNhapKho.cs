using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class DonHangNhapKho
    {
        public DonHangNhapKho(int idchitiethoadon, string tenthuoc, float gianhap, string chucnang, string tendonvi, int soluong, float thanhtien)
        {
            this.Idchitiethoadonnhaphang = idchitiethoadon;
            this.Tenthuoc = tenthuoc;
            this.Gianhap = gianhap;
            this.Chucnang = chucnang;
            this.Tendonvi = tendonvi;
            this.Soluong = soluong;
            this.Thanhtien = thanhtien;
        }

        public DonHangNhapKho(DataRow row)
        {
            this.Idchitiethoadonnhaphang = (int)row["id"];
            this.Tenthuoc = row["tenthuoc"].ToString();
            this.Chucnang = row["chucnang"].ToString();
            this.Soluong = (int)row["soluong"];
            this.Tendonvi = row["tendonvi"].ToString();
            this.Thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            this.Gianhap = (float)Convert.ToDouble(row["gianhap"].ToString());
        }

        private int idchitiethoadonnhaphang;
        private string tenthuoc;
        private float gianhap;
        private string chucnang;
        private string tendonvi;
        private int soluong;
        private float thanhtien;

        public int Idchitiethoadonnhaphang { get => idchitiethoadonnhaphang; set => idchitiethoadonnhaphang = value; }
        public string Tenthuoc { get => tenthuoc; set => tenthuoc = value; }
        public float Gianhap { get => gianhap; set => gianhap = value; }
        public string Chucnang { get => chucnang; set => chucnang = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }
    }
}
