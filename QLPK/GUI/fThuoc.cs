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
    public partial class fThuoc : Form
    {
        public fThuoc()
        {
            InitializeComponent();
            load();
            cbxLoaiThuoc.Text = "";
        }
        #region Method
        public void load()
        {
            LoadDanhSachThuoc();
            TimTenThuoc();
            LoadcbxLoaiThuoc();
        }

        void LoadDanhSachThuoc()
        {
            dtgvThuoc.DataSource = ThuocDAO.Instance.LayDanhSachThuoc();
        }

        private void TimTenThuoc()
        {
            List<Thuoc> danhsachthuoc = ThuocDAO.Instance.TimDanhSachThuoc();
            AutoCompleteStringCollection auto = new AutoCompleteStringCollection();
            foreach (Thuoc item in danhsachthuoc)
            {
                auto.Add(item.TenThuoc.ToString());
            }

            txtTenThuoc.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenThuoc.AutoCompleteCustomSource = auto;
        }

        void LoadcbxLoaiThuoc()
        {
            List<LoaiThuoc> danhsachloai = LoaiThuocDAO.Instance.LayDanhSachLoai();
            cbxLoaiThuoc.DataSource = danhsachloai;
            cbxLoaiThuoc.DisplayMember = "tenloai";
        }
        #endregion
        #region Event
        private void dtgvThuoc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fChiTietThuoc f = new fChiTietThuoc();
            f.txtIDThuoc.Text = this.dtgvThuoc.CurrentRow.Cells[0].Value.ToString();
            f.txtTenThuoc.Text = this.dtgvThuoc.CurrentRow.Cells[1].Value.ToString();
            f.txtDuongUong.Text = this.dtgvThuoc.CurrentRow.Cells[2].Value.ToString();
            f.txtDangBaoChe.Text = this.dtgvThuoc.CurrentRow.Cells[3].Value.ToString();
            f.txtHamLuong.Text = this.dtgvThuoc.CurrentRow.Cells[4].Value.ToString();
            f.txtThanhPhan.Text = this.dtgvThuoc.CurrentRow.Cells[5].Value.ToString();
            f.txtHinhDang.Text = this.dtgvThuoc.CurrentRow.Cells[6].Value.ToString();
            f.txtHanDung.Text = this.dtgvThuoc.CurrentRow.Cells[7].Value.ToString();
            f.txtChucNang.Text = this.dtgvThuoc.CurrentRow.Cells[8].Value.ToString();
            f.txtGiaNhap.Text = this.dtgvThuoc.CurrentRow.Cells[10].Value.ToString();
            f.txtGiaBanSi.Text = this.dtgvThuoc.CurrentRow.Cells[11].Value.ToString();
            f.txtGiaBanLe.Text = this.dtgvThuoc.CurrentRow.Cells[12].Value.ToString();
            f.txtGiaKhuyenMai.Text = this.dtgvThuoc.CurrentRow.Cells[13].Value.ToString();
            f.cbxLoaiThuoc.Text = this.dtgvThuoc.CurrentRow.Cells[14].Value.ToString();
            f.cbxDonViTinh.Text = this.dtgvThuoc.CurrentRow.Cells[15].Value.ToString();
            f.cbxNhaSanXuat.Text = this.dtgvThuoc.CurrentRow.Cells[16].Value.ToString();
            f.ShowDialog();
            load();
        }

        private void txtTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtgvThuoc.DataSource = ThuocDAO.Instance.TimKiemDanhSachThuoc(txtTenThuoc.Text);
            }
        }

        private void cbxLoaiThuoc_TextChanged(object sender, EventArgs e)
        {
            dtgvThuoc.DataSource = LoaiThuocDAO.Instance.TimKiemDanhSachThuoc(cbxLoaiThuoc.Text);
            txtTenThuoc.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            fChiTietThuoc f = new fChiTietThuoc();
            f.btnThemThuoc.Enabled = true;
            f.btnLamMoi.Enabled = true;
            f.ShowDialog();
            load();
        }
        #endregion
        
    }
}
