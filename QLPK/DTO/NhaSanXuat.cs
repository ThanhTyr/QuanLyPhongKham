using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class NhaSanXuat
    {
        public NhaSanXuat(int idNhaSanXuat, string tennhasanxuat)
        {
            this.IdNhaSanXuat = idNhaSanXuat;
            this.Tennhasanxuat = tennhasanxuat;
        }

        public NhaSanXuat(DataRow row)
        {
            this.Tennhasanxuat = row["tennhasanxuat"].ToString();
            this.IdNhaSanXuat = (int)row["id"];
        }

        private int idNhaSanXuat;
        private string tennhasanxuat;

        public int IdNhaSanXuat { get => idNhaSanXuat; set => idNhaSanXuat = value; }
        public string Tennhasanxuat { get => tennhasanxuat; set => tennhasanxuat = value; }
    }
}
