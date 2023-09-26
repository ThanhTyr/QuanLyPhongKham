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
    public partial class fThongTinNhanVien : Form
    {
        public fThongTinNhanVien()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
            LoadcbxGioiTinh();
            LoadcbxChucVu();
            LoadcbxViTri();
        }

        void LoadcbxGioiTinh()
        {
            cbxGioiTinh.Items.Add("Nam");
            cbxGioiTinh.Items.Add("Nữ");
        }
        void LoadcbxChucVu()
        {
            cbxChucVu.Items.Add("Admin");
            cbxChucVu.Items.Add("Nhân Viên");
        }

        void LoadcbxViTri()
        {
            cbxViTri.Items.Add("Bác Sĩ");
            cbxViTri.Items.Add("Nhân viên");
        }
        void cleartext()
        {
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtHoTen.Text = "";
            txtIDNhanVien.Text = "";
            txtNgaySinh.Text = "";
            txtSDT.Text = "";
            cbxChucVu.Text = "";
            cbxGioiTinh.Text = "";
            cbxViTri.Text = "";
        }
        #endregion
        #region Event
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            string tennv = txtHoTen.Text;
            int namsinhnv = Convert.ToInt32(txtNgaySinh.Text);
            string gioitinhnv = cbxGioiTinh.Text;
            string diachinv = txtDiaChi.Text;
            string sdtnv = txtSDT.Text;
            string emailnv = txtEmail.Text;
            string chucvu = cbxChucVu.Text;
            string vitri = cbxViTri.Text;
            if (NhanVienDAO.Instance.InsertNhanVien(tennv, namsinhnv, gioitinhnv, diachinv, sdtnv, emailnv, chucvu, vitri))
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtIDNhanVien.Text != "")
            {
                int id = Convert.ToInt32(txtIDNhanVien.Text);
                string tennv = txtHoTen.Text;
                int namsinhnv = Convert.ToInt32(txtNgaySinh.Text);
                string gioitinhnv = cbxGioiTinh.Text;
                string diachinv = txtDiaChi.Text;
                string sdtnv = txtSDT.Text;
                string emailnv = txtEmail.Text;
                string chucvu = cbxChucVu.Text;
                string vitri = cbxViTri.Text;
                if (NhanVienDAO.Instance.UpdateNhanVien(id, tennv, namsinhnv, gioitinhnv, diachinv, sdtnv, emailnv, chucvu, vitri))
                {
                    MessageBox.Show("Sửa nhân viên thành công");
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại");
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
            int idnhanvien = Convert.ToInt32(txtIDNhanVien.Text);
            if (NhanVienDAO.Instance.DeleteNhanVien(idnhanvien))
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
            this.Close();
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        #endregion
    }
}
