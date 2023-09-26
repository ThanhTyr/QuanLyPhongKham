using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class HoaDon
    {
        public HoaDon(int idHoaDon, float tongtien, DateTime? ngayban, int tinhtrang)
        {
            this.IdHoaDon = idHoaDon;
            this.Tongtien = tongtien;
            this.Ngayban = ngayban;
            this.Tinhtrang = tinhtrang;
        }

        public HoaDon(DataRow row)
        {
            this.IdHoaDon = (int)row["id"];
            this.Tongtien = (float)Convert.ToDouble(row["tongtien"].ToString());
            var ngaybantemp = row["ngayban"];
            if (ngaybantemp.ToString() != "")
            {
                this.Ngayban = (DateTime?)ngaybantemp;
            }
            this.Tinhtrang = (int)row["tinhtrang"];
        }

        private int idHoaDon;
        private float tongtien;
        private DateTime? ngayban;
        private int tinhtrang;

        public int IdHoaDon { get => idHoaDon; set => idHoaDon = value; }
        public float Tongtien { get => tongtien; set => tongtien = value; }
        public DateTime? Ngayban { get => ngayban; set => ngayban = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
