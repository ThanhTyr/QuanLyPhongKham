using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class Thuoc
    {
        public Thuoc(int idThuoc, string tenThuoc, string duongUong, string dangBaoChe, string hamLuong, string thanhPhan, string hinhDang, string hanDung, string chucNang, int soLuong, float giaNhap, float giaSi, float giaLe, float gianKhuyenMai)
        {
            this.IdThuoc = idThuoc;
            this.TenThuoc = tenThuoc;
            this.DuongUong = duongUong;
            this.DangBaoChe = dangBaoChe;
            this.HamLuong = hamLuong;
            this.ThanhPhan = thanhPhan;
            this.HinhDang = hinhDang;
            this.HanDung = hanDung;
            this.ChucNang = chucNang;
            this.SoLuong = soLuong;
            this.GiaNhap = giaNhap;
            this.GiaSi = giaSi;
            this.GiaLe = giaLe;
            this.GianKhuyenMai = gianKhuyenMai;
        }

        public Thuoc(DataRow row)
        {
            this.IdThuoc = (int)row["id"];
            this.TenThuoc = row["tenthuoc"].ToString();
            this.DuongUong = row["duonguong"].ToString();
            this.DangBaoChe = row["dangbaoche"].ToString();
            this.HamLuong = row["hamluong"].ToString();
            this.ThanhPhan = row["thanhphan"].ToString();
            this.HinhDang = row["hinhdang"].ToString();
            this.HanDung = row["handung"].ToString();
            this.ChucNang = row["chucnang"].ToString();
            this.SoLuong = (int)row["soluong"];
            this.GiaNhap = (float)Convert.ToDouble(row["gianhap"].ToString());
            this.GiaSi = (float)Convert.ToDouble(row["giasi"].ToString());
            this.GiaLe = (float)Convert.ToDouble(row["giale"].ToString());
            this.GianKhuyenMai = (float)Convert.ToDouble(row["giankhuyenmai"].ToString());
        }

        private int idThuoc;
        private string tenThuoc;
        private string duongUong;
        private string dangBaoChe;
        private string hamLuong;
        private string thanhPhan;
        private string hinhDang;
        private string hanDung;
        private string chucNang;
        private int soLuong;
        private float giaNhap;
        private float giaSi;
        private float giaLe;
        private float gianKhuyenMai;

        public int IdThuoc { get => idThuoc; set => idThuoc = value; }
        public string TenThuoc { get => tenThuoc; set => tenThuoc = value; }
        public string DuongUong { get => duongUong; set => duongUong = value; }
        public string DangBaoChe { get => dangBaoChe; set => dangBaoChe = value; }
        public string HamLuong { get => hamLuong; set => hamLuong = value; }
        public string ThanhPhan { get => thanhPhan; set => thanhPhan = value; }
        public string HinhDang { get => hinhDang; set => hinhDang = value; }
        public string HanDung { get => hanDung; set => hanDung = value; }
        public string ChucNang { get => chucNang; set => chucNang = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float GiaNhap { get => giaNhap; set => giaNhap = value; }
        public float GiaSi { get => giaSi; set => giaSi = value; }
        public float GiaLe { get => giaLe; set => giaLe = value; }
        public float GianKhuyenMai { get => gianKhuyenMai; set => gianKhuyenMai = value; }
    }
}
