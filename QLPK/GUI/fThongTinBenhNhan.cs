using QLPK.DAO;
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
    public partial class fThongTinBenhNhan : Form
    {
        public fThongTinBenhNhan()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadcbxGioiTinh();
        }
        void LoadcbxGioiTinh()
        {
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nữ");
        }
        void cleartext()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtHoTen.Text = "";
            txtGhiChu.Text = "";
            txtIDBenhNhan.Text = "";
            txtSDT.Text = "";
            txtNamSinh.Text = "";
            cbxGioiTinh.Text = "";
            txtTieuSuBenh.Text = "";
        }
        void checkdanhsachkham(int idbenhnhan)
        {
            int danhsachkham = DanhSachKhamDAO.Instance.KiemTraDanhSachKham2(idbenhnhan);
            if(danhsachkham != -1)
            {
                btnThemHangCho.Enabled = false;
            }
        }
        #endregion
        #region Event
        private void btnThemBenhNhan_Click(object sender, EventArgs e)
        {
            string tenbn = txtHoTen.Text;
            int namsinhbn = Convert.ToInt32(txtNamSinh.Text);
            string gioitinhbn = cbxGioiTinh.Text;
            string diachibn = txtDiaChi.Text;
            string sdtbn = txtSDT.Text;
            string emailbn = txtEmail.Text;
            string tieusubenh = txtTieuSuBenh.Text;
            string ghichu = txtGhiChu.Text;
            string ngaytao = dtpNgayTao.Value.ToString("MM/dd/yyyy");
            if (BenhNhanDAO.Instance.InsertBenhNhan(tenbn, namsinhbn, gioitinhbn, diachibn, sdtbn, emailbn, tieusubenh, ghichu, ngaytao))
            {
                MessageBox.Show("Thêm bệnh nhân thành công");
            }
            else
            {
                MessageBox.Show("Thêm bệnh nhân thất bại");
            }
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtIDBenhNhan.Text != "")
            {
                int id = Convert.ToInt32(txtIDBenhNhan.Text);
                string tenbn = txtHoTen.Text;
                int namsinhbn = Convert.ToInt32(txtNamSinh.Text);
                string gioitinhbn = cbxGioiTinh.Text;
                string diachibn = txtDiaChi.Text;
                string sdtbn = txtSDT.Text;
                string emailbn = txtEmail.Text;
                string tieusubenh = txtTieuSuBenh.Text;
                string ghichu = txtGhiChu.Text;
                string ngaytao = dtpNgayTao.Value.ToString("MM/dd/yyyy");
                if (BenhNhanDAO.Instance.UpdateBenhNhan(id, tenbn, namsinhbn, gioitinhbn, diachibn, sdtbn, emailbn, tieusubenh, ghichu, ngaytao))
                {
                    MessageBox.Show("Sửa bệnh nhân thành công");
                }
                else
                {
                    MessageBox.Show("Sửa bệnh nhân thất bại");
                }
            }
            else
            {
                MessageBox.Show("Hiện không có ID !!!", "Thông Báo");
            }
            this.Close();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
            if (BenhNhanDAO.Instance.DeleteBenhNhan(idbenhnhan))
            {
                MessageBox.Show("Xóa bệnh nhân thành công");
            }
            else
            {
                MessageBox.Show("Xóa bệnh nhân thất bại");
            }
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        private void btnThemHangCho_Click(object sender, EventArgs e)
        {
            int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
            int danhsachkham = DanhSachKhamDAO.Instance.KiemTraDanhSachKham();
            if (danhsachkham != -1)
            {
                int maxstt = Convert.ToInt32(DanhSachKhamDAO.Instance.LayMaxSTT());
                int stt = maxstt + 1;
                if (DanhSachKhamDAO.Instance.ThemVaoDanhSachKham(idbenhnhan, stt))
                {
                    MessageBox.Show("Thêm danh sách chờ thành công");
                }
                else
                {
                    MessageBox.Show("Thêm danh sách chờ thất bại");
                }
            }
            else
            {
                int stt = 1;
                if (DanhSachKhamDAO.Instance.ThemVaoDanhSachKham(idbenhnhan, stt))
                {
                    MessageBox.Show("Thêm danh sách chờ thành công");
                }
                else
                {
                    MessageBox.Show("Thêm danh sách chờ thất bại");
                }
            }
            checkdanhsachkham(Convert.ToInt32(txtIDBenhNhan.Text));
        }

        private void txtIDBenhNhan_TextChanged(object sender, EventArgs e)
        {
            checkdanhsachkham(Convert.ToInt32(txtIDBenhNhan.Text));
        }
        #endregion
    }
}
