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
    public partial class fDanhSachHen : Form
    {
        public fDanhSachHen()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadDanhSachHen();
        }
        void LoadDanhSachHen()
        {
            dtgvDanhSachHen.DataSource = DanhSachKhamDAO.Instance.LayDanhSachKham();
        }
        #endregion

        #region Event
        private void dtpkDen_ValueChanged(object sender, EventArgs e)
        {
            dtgvDanhSachHen.DataSource = DanhSachKhamDAO.Instance.DanhSachHenTheoNgay(dtpkTu.Value, dtpkDen.Value);
        }

        private void dtpkTu_ValueChanged(object sender, EventArgs e)
        {
            dtgvDanhSachHen.DataSource = DanhSachKhamDAO.Instance.DanhSachHenTheoNgay(dtpkTu.Value, dtpkDen.Value);
        }
        private void dtgvDanhSachHen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fThongTinCuocHen f = new fThongTinCuocHen();
            f.dtpkThoiGianHen.Text = this.dtgvDanhSachHen.CurrentRow.Cells[0].Value.ToString();
            f.txtSTT.Text = this.dtgvDanhSachHen.CurrentRow.Cells[1].Value.ToString();
            f.txtIDHen.Text = this.dtgvDanhSachHen.CurrentRow.Cells[2].Value.ToString();
            f.txtIDBenhNhan.Text = this.dtgvDanhSachHen.CurrentRow.Cells[3].Value.ToString();
            f.txtHoTen.Text = this.dtgvDanhSachHen.CurrentRow.Cells[4].Value.ToString();
            f.txtSDT.Text = this.dtgvDanhSachHen.CurrentRow.Cells[5].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThongTinCuocHen f = new fThongTinCuocHen();
            f.btnThem.Enabled = true;
            f.ShowDialog();
            load();
        }

        #endregion
    }
}
