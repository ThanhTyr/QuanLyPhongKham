using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class DanhSachKham
    {
        public DanhSachKham(int iddanhsachkham, int stt, DateTime? ngaykham, int tinhtrang, int idbenhnhan)
        {
            this.Iddanhsachkham = iddanhsachkham;
            this.Stt = stt;
            this.Ngaykham = ngaykham;
            this.Tinhtrang = tinhtrang;
            this.Idbenhnhan = idbenhnhan;
        }

        public DanhSachKham(DataRow row)
        {
            this.Iddanhsachkham = (int)row["id"];
            this.Idbenhnhan = (int)row["idBenhNhan"];
            this.Stt = (int)row["stt"];
            var ngaybantemp = row["ngaykham"];
            if (ngaybantemp.ToString() != "")
            {
                this.Ngaykham = (DateTime?)ngaybantemp;
            }
            this.Tinhtrang = (int)row["tinhtrang"];
        }

        private int iddanhsachkham;
        private int idbenhnhan;
        private int stt;
        private int tinhtrang;
        private DateTime? ngaykham;

        public int Iddanhsachkham { get => iddanhsachkham; set => iddanhsachkham = value; }
        public int Stt { get => stt; set => stt = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public DateTime? Ngaykham { get => ngaykham; set => ngaykham = value; }
        public int Idbenhnhan { get => idbenhnhan; set => idbenhnhan = value; }
    }
}
