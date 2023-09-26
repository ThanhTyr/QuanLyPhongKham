using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class HoaDonNhapKho
    {
        public HoaDonNhapKho(int idhoadonnhapkho, float tongtien, DateTime? ngaynhap, int tinhtrang)
        {
            this.Idhoadonnhapkho = idhoadonnhapkho;
            this.Tongtien = tongtien;
            this.Ngaynhap = ngaynhap;
            this.Tinhtrang = tinhtrang;
        }

        public HoaDonNhapKho(DataRow row)
        {
            this.Idhoadonnhapkho = (int)row["id"];
            this.Tongtien = (float)Convert.ToDouble(row["tongtien"].ToString());
            var ngaybantemp = row["ngaynhap"];
            if (ngaybantemp.ToString() != "")
            {
                this.Ngaynhap = (DateTime?)ngaybantemp;
            }
            this.Tinhtrang = (int)row["tinhtrang"];
        }

        private int idhoadonnhapkho;
        private float tongtien;
        private DateTime? ngaynhap;
        private int tinhtrang;

        public int Idhoadonnhapkho { get => idhoadonnhapkho; set => idhoadonnhapkho = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public DateTime? Ngaynhap { get => ngaynhap; set => ngaynhap = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
