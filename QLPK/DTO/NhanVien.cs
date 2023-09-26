using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class NhanVien
    {
        public NhanVien(int idNhanVien, string tennv, int namsinhnv, string gioitinhnv, string diachinv, string sdtnv, string emailnv, string chucvu, string vitri)
        {
            this.IdNhanVien = idNhanVien;
            this.Tennv = tennv;
            this.Namsinhnv = namsinhnv;
            this.Gioitinhnv = gioitinhnv;
            this.Diachinv = diachinv;
            this.Sdtnv = sdtnv;
            this.Emailnv = emailnv;
            this.Chucvu = chucvu;
            this.Vitri = vitri;
        }

        public NhanVien(DataRow row)
        {
            this.IdNhanVien = (int)row["id"];
            this.Tennv = row["tennv"].ToString();
            this.Namsinhnv = (int)row["namsinhnv"];
            this.Gioitinhnv = row["gioitinhnv"].ToString();
            this.Diachinv = row["diachinv"].ToString();
            this.Sdtnv = row["sdtnv"].ToString();
            this.Emailnv = row["emailnv"].ToString();
            this.Chucvu = row["chucvu"].ToString();
            this.Vitri = row["vitri"].ToString();
        }

        private int idNhanVien;
        private string tennv;
        private int namsinhnv;
        private string gioitinhnv;
        private string diachinv;
        private string sdtnv;
        private string emailnv;
        private string chucvu;
        private string vitri;

        public int IdNhanVien { get => idNhanVien; set => idNhanVien = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public int Namsinhnv { get => namsinhnv; set => namsinhnv = value; }
        public string Gioitinhnv { get => gioitinhnv; set => gioitinhnv = value; }
        public string Diachinv { get => diachinv; set => diachinv = value; }
        public string Sdtnv { get => sdtnv; set => sdtnv = value; }
        public string Emailnv { get => emailnv; set => emailnv = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Vitri { get => vitri; set => vitri = value; }
    }
}
