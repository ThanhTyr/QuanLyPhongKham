using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPK.DTO
{
    public class DonViTinh
    {
        public DonViTinh(int idDonViTinh, string tendonvi)
        {
            this.IdDonViTinh = idDonViTinh;
            this.Tendonvi = tendonvi;
        }

        public DonViTinh(DataRow row)
        {
            this.Tendonvi = row["tendonvi"].ToString();
            this.IdDonViTinh = (int)row["id"];
        }

        private int idDonViTinh;
        private string tendonvi;

        public int IdDonViTinh { get => idDonViTinh; set => idDonViTinh = value; }
        public string Tendonvi { get => tendonvi; set => tendonvi = value; }
    }
}
