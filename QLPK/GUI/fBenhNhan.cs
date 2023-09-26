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
    public partial class fBenhNhan : Form
    {
        public fBenhNhan()
        {
            InitializeComponent();
            load();
        }

        #region Method
        void load()
        {
            LoadDanhSachBenhNhan();
            TimTenBenhNhan();
        }

        void LoadDanhSachBenhNhan()
        {
            dtgvDanhSachBenhNhan.DataSource = BenhNhanDAO.Instance.LayDanhSachBenhNhan();
        }

        private void TimTenBenhNhan()
        {
            List<BenhNhan> danhsachbenhnhan = BenhNhanDAO.Instance.TimDanhSachBenhNhan();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (BenhNhan item in danhsachbenhnhan)
            {
                auto.Add(item.Tenbn.ToString());
            }

            txtThongTin.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtThongTin.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtThongTin.AutoCompleteCustomSource = auto;
        }
        #endregion
        #region Event
        private void dtgvDanhSachBenhNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dtgvDanhSachBenhNhan.CurrentRow.Cells[0].Value.ToString() != "")
            {
                dtgvBenhAn.DataSource = BenhAnDAO.Instance.LayDanhSachBenhAn(this.dtgvDanhSachBenhNhan.CurrentRow.Cells[0].Value.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân !!!", "Thông Báo");
            }
        }

        private void txtThongTin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvDanhSachBenhNhan.DataSource = BenhNhanDAO.Instance.TimKiemDanhSachBenhNhan(txtThongTin.Text);
            }
        }

        private void dtgvDanhSachBenhNhan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fThongTinBenhNhan f = new fThongTinBenhNhan();
            f.txtIDBenhNhan.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[0].Value.ToString();
            f.txtHoTen.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[1].Value.ToString();
            f.txtNamSinh.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[2].Value.ToString();
            f.cbxGioiTinh.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[3].Value.ToString();
            f.txtDiaChi.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[4].Value.ToString();
            f.txtSDT.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[5].Value.ToString();
            f.txtEmail.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[6].Value.ToString();
            f.txtTieuSuBenh.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[7].Value.ToString();
            f.txtGhiChu.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[8].Value.ToString();
            f.dtpNgayTao.Text = this.dtgvDanhSachBenhNhan.CurrentRow.Cells[9].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fThongTinBenhNhan f = new fThongTinBenhNhan();
            f.btnThemBenhNhan.Enabled = true;
            f.ShowDialog();
            load();
        }
        #endregion
        
    }
}
