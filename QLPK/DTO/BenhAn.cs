using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class BenhAn
    {
        public BenhAn(int idBenhAn, string lydokham, string trieuchung, string sieuam, string chuandoan, string loidan, DateTime? ngaylap, int tinhtrang)
        {
            this.IdBenhAn = idBenhAn;
            this.Lydokham = lydokham;
            this.Trieuchung = trieuchung;
            this.Sieuam = sieuam;
            this.Chuandoan = chuandoan;
            this.Loidan = loidan;
            this.Ngaylap = ngaylap;
            this.Tinhtrang = tinhtrang;
        }

        public BenhAn(DataRow row)
        {
            this.IdBenhAn = (int)row["id"];
            this.Lydokham = row["lydokham"].ToString();
            this.Trieuchung = row["trieuchung"].ToString();
            this.Sieuam = row["sieuam"].ToString();
            this.Chuandoan = row["chuandoan"].ToString();
            this.Loidan = row["loidan"].ToString();
            var ngaylaptemp = row["ngaylap"];
            if (ngaylaptemp.ToString() != "")
            {
                this.Ngaylap = (DateTime?)ngaylaptemp;
            }
            this.Tinhtrang = (int)row["tinhtrang"];
        }

        private int idBenhAn;
        private string lydokham;
        private string trieuchung;
        private string sieuam;
        private string chuandoan;
        private string loidan;
        private DateTime? ngaylap;
        private int tinhtrang;

        public int IdBenhAn { get => idBenhAn; set => idBenhAn = value; }
        public string Lydokham { get => lydokham; set => lydokham = value; }
        public string Trieuchung { get => trieuchung; set => trieuchung = value; }
        public string Sieuam { get => sieuam; set => sieuam = value; }
        public string Chuandoan { get => chuandoan; set => chuandoan = value; }
        public string Loidan { get => loidan; set => loidan = value; }
        public DateTime? Ngaylap { get => ngaylap; set => ngaylap = value; }
        public int Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
    }
}
