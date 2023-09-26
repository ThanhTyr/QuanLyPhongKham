using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class BenhNhan
    {
        public BenhNhan(int idBenhNhan, string tenbn, int namsinhbn, string gioitinhbn, string diachibn, string sdtbn, string emailbn, string tieusubenh, string ghichu, DateTime? ngaytao)
        {
            this.IdBenhNhan = idBenhNhan;
            this.Tenbn = tenbn;
            this.Namsinhbn = namsinhbn;
            this.Gioitinhbn = gioitinhbn;
            this.Diachibn = diachibn;
            this.Sdtbn = sdtbn;
            this.Emailbn = emailbn;
            this.Tieusubenh = tieusubenh;
            this.Ghichu = ghichu;
            this.Ngaytao = ngaytao;
        }

        public BenhNhan(DataRow row)
        {
            this.IdBenhNhan = (int)row["id"];
            this.Tenbn = row["tenbn"].ToString();
            this.Namsinhbn = (int)row["namsinhbn"];
            this.Gioitinhbn = row["gioitinhbn"].ToString();
            this.Diachibn = row["diachibn"].ToString();
            this.Sdtbn = row["sdtbn"].ToString();
            this.Emailbn = row["emailbn"].ToString();
            this.Tieusubenh = row["tieusubenh"].ToString();
            this.Ghichu = row["ghichu"].ToString();
            var ngaytaotemp = row["ngaytao"];
            if (ngaytaotemp.ToString() != "")
            {
                this.Ngaytao = (DateTime?)ngaytaotemp;
            }
        }

        private int idBenhNhan;
        private string tenbn;
        private int namsinhbn;
        private string gioitinhbn;
        private string diachibn;
        private string sdtbn;
        private string emailbn;
        private string tieusubenh;
        private string ghichu;
        private DateTime? ngaytao;

        public int IdBenhNhan { get => idBenhNhan; set => idBenhNhan = value; }
        public string Tenbn { get => tenbn; set => tenbn = value; }
        public int Namsinhbn { get => namsinhbn; set => namsinhbn = value; }
        public string Gioitinhbn { get => gioitinhbn; set => gioitinhbn = value; }
        public string Diachibn { get => diachibn; set => diachibn = value; }
        public string Sdtbn { get => sdtbn; set => sdtbn = value; }
        public string Emailbn { get => emailbn; set => emailbn = value; }
        public string Tieusubenh { get => tieusubenh; set => tieusubenh = value; }
        public string Ghichu { get => ghichu; set => ghichu = value; }
        public DateTime? Ngaytao { get => ngaytao; set => ngaytao = value; }
    }
}
