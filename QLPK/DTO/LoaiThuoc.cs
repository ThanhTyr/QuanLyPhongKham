using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class LoaiThuoc
    {
        public LoaiThuoc(int idLoai, string tenLoai)
        {
            this.IdLoai = idLoai;
            this.TenLoai = tenLoai;
        }

        public LoaiThuoc(DataRow row)
        {
            this.TenLoai = row["tenloai"].ToString();
            this.IdLoai = (int)row["id"];
        }

        private int idLoai;
        private string tenLoai;

        public int IdLoai { get => idLoai; set => idLoai = value; }
        public string TenLoai { get => tenLoai; set => tenLoai = value; }
    }
}
