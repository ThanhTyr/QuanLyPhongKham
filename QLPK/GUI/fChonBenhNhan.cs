using QLPK.DAO;
using QLPK.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPK.GUI
{
    public partial class fChonBenhNhan : Form
    {
        public fChonBenhNhan()
        {
            InitializeComponent();
            load();
        }
        void load()
        {
            dtgvBenhNhan.DataSource = BenhNhanDAO.Instance.LayDanhSachBenhNhan();
            TimTenBenhNhan();
        }

        private void dtgvBenhNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ChonBenhNhan.id = this.dtgvBenhNhan.CurrentRow.Cells[0].Value.ToString();
            ChonBenhNhan.hoten = this.dtgvBenhNhan.CurrentRow.Cells[1].Value.ToString();
            ChonBenhNhan.namsinh = this.dtgvBenhNhan.CurrentRow.Cells[2].Value.ToString();
            ChonBenhNhan.gioitinh = this.dtgvBenhNhan.CurrentRow.Cells[3].Value.ToString();
            ChonBenhNhan.diachi = this.dtgvBenhNhan.CurrentRow.Cells[4].Value.ToString();
            ChonBenhNhan.sdt = this.dtgvBenhNhan.CurrentRow.Cells[5].Value.ToString();
            ChonBenhNhan.email = this.dtgvBenhNhan.CurrentRow.Cells[6].Value.ToString();
            ChonBenhNhan.ngaytao = this.dtgvBenhNhan.CurrentRow.Cells[9].Value.ToString();
            this.Close();
        }
        private void TimTenBenhNhan()
        {
            List<BenhNhan> danhsachbenhnhan = BenhNhanDAO.Instance.TimDanhSachBenhNhan();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (BenhNhan item in danhsachbenhnhan)
            {
                auto.Add(item.Tenbn.ToString());
            }

            txtTimBenhNhan.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTimBenhNhan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimBenhNhan.AutoCompleteCustomSource = auto;
        }

        private void txtTimBenhNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvBenhNhan.DataSource = BenhNhanDAO.Instance.TimKiemDanhSachBenhNhan(txtTimBenhNhan.Text);
            }
        }
    }
}
