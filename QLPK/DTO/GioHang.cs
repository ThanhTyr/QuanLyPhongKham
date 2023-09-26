using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class GioHang
    {
        public GioHang(int idchitiethoadon, string tenthuoc, float giale, string chucnang, string tendonvi, int soluong, float thanhtien)
        {
            this.Idchitiethoadon = idchitiethoadon;
            this.Tenthuoc = tenthuoc;
            this.Giale = giale;
            this.Chucnang = chucnang;
            this.Tendonvi = tendonvi;
            this.Soluong = soluong;
            this.Thanhtien = thanhtien;
        }

        public GioHang(DataRow row)
        {
            this.Idchitiethoadon = (int)row["id"];
            this.Tenthuoc = row["tenthuoc"].ToString();
            this.Chucnang = row["chucnang"].ToString();
            this.Soluong = (int)row["soluong"];
            this.Tendonvi = row["tendonvi"].ToString();
            this.Thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            this.Giale = (float)Convert.ToDouble(row["giale"].ToString());
        }

        private int idchitiethoadon;
        private string tenthuoc;
        private float giale;
        private string chucnang;
        private string tendonvi;
        private int soluong;
        private float thanhtien;

        public int Idchitiethoadon { get => idchitiethoadon; set => idchitiethoadon = value; }
        public string Tenthuoc { get => tenthuoc; set => tenthuoc = value; }
        public float Giale { get => giale; set => giale = value; }
        public string Chucnang { get => chucnang; set => chucnang = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }
    }
}
