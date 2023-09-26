using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class TaiKhoan
    {
        public TaiKhoan(int idtaikhoan, string taikhoan, string matkhau, int loaitk)
        {
            this.Idtaikhoan = idtaikhoan;
            this.Taikhoan = taikhoan;
            this.Matkhau = matkhau;
            this.Loaitk = loaitk;
        }

        public TaiKhoan(DataRow row)
        {
            this.Taikhoan = row["taikhoan"].ToString();
            this.Idtaikhoan = (int)row["id"];
            this.Matkhau = row["matkhau"].ToString();
            this.Loaitk = (int)row["loaitk"];
        }

        private int idtaikhoan;
        private string taikhoan;
        private string matkhau;
        private int loaitk;

        public int Idtaikhoan { get => idtaikhoan; set => idtaikhoan = value; }
        public string Taikhoan { get => taikhoan; set => taikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public int Loaitk { get => loaitk; set => loaitk = value; }
    }
}
