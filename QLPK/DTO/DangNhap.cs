using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class DangNhap
    {
        public DangNhap(string taikhoan, int loaitk, int idNhanVien, string matkhau = null)
        {
            this.Taikhoan = taikhoan;
            this.Loaitk = loaitk;
            this.Matkhau = matkhau;
            this.IdNhanVien = idNhanVien;
        }

        public DangNhap(DataRow row)
        {
            this.Taikhoan = row["taikhoan"].ToString();
            this.Loaitk = (int)row["loaitk"];
            this.Matkhau = row["matkhau"].ToString();
            this.IdNhanVien = (int)row["idNhanVien"];
        }

        private string taikhoan;
        private string matkhau;
        private int loaitk;
        private int idNhanVien;

        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Loaitk { get => loaitk; set => loaitk = value; }
        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
    }
}
