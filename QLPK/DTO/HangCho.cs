using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class HangCho
    {
        public HangCho(int idhangcho, string noidung, int tinhtrang, DateTime? thoigianhen)
        {
            this.Idhangcho = idhangcho;
            this.Noidung = noidung;
            this.Tinhtrang = tinhtrang;
            this.Thoigianhen = thoigianhen;
        }

        public HangCho(DataRow row)
        {
            this.Noidung = row["noidung"].ToString();
            this.Idhangcho = (int)row["id"];
            this.Tinhtrang = (int)row["tinhtrang"];
            var ngaybantemp = row["thoigianhen"];
            if (ngaybantemp.ToString() != "")
            {
                this.Thoigianhen = (DateTime?)ngaybantemp;
            }
        }
        private int idhangcho;
        private string noidung;
        private int tinhtrang;
        private DateTime? thoigianhen;

        public int Idhangcho { get => idhangcho; set => idhangcho = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public DateTime? Thoigianhen { get => thoigianhen; set => thoigianhen = value; }
    }
}
