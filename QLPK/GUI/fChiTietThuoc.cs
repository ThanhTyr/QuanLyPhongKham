using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLPK.DAO;
using QLPK.DTO;

namespace QLPK.GUI
{
    public partial class fChiTietThuoc : Form
    {
        fThuoc t = new fThuoc();

        public fChiTietThuoc()
        {
            InitializeComponent();
            load();
        }

        #region Method
        void load()
        {
            LoadcbxLoaiThuoc();
            LoadcbxDonViTinh();
            LoadcbxNhaSanXuat();
        }
        void LoadcbxLoaiThuoc()
        {
            List<LoaiThuoc> danhsachloai = LoaiThuocDAO.Instance.LayDanhSachLoai();
            cbxLoaiThuoc.DataSource = danhsachloai;
            cbxLoaiThuoc.DisplayMember = "tenloai";
        }
        void LoadcbxDonViTinh()
        {
            List<DonViTinh> danhsachdonvi = DonViTinhDAO.Instance.LayDanhSachDonViTinh();
            cbxDonViTinh.DataSource = danhsachdonvi;
            cbxDonViTinh.DisplayMember = "tendonvi";
        }
        void LoadcbxNhaSanXuat()
        {
            List<NhaSanXuat> danhsachnhasanxuat = NhaSanXuatDAO.Instance.LayDanhSachNhaSanXuat();
            cbxNhaSanXuat.DataSource = danhsachnhasanxuat;
            cbxNhaSanXuat.DisplayMember = "tennhasanxuat";
        }
        void cleartext()
        {
            txtChucNang.Text = "";
            txtDangBaoChe.Text = "";
            txtDuongUong.Text = "";
            txtGiaBanLe.Text = "";
            txtGiaBanSi.Text = "";
            txtGiaKhuyenMai.Text = "";
            txtGiaNhap.Text = "";
            txtHamLuong.Text = "";
            txtHanDung.Text = "";
            txtHinhDang.Text = "";
            txtIDThuoc.Text = "";
            txtTenThuoc.Text = "";
            txtThanhPhan.Text = "";
        }
        #endregion

        #region Event
        private void btnThemThuoc_Click_1(object sender, EventArgs e)
        {
            string tenthuoc = txtTenThuoc.Text;
            string duonguong = txtDuongUong.Text;
            string dangbaoche = txtDangBaoChe.Text;
            string hamluong = txtHamLuong.Text;
            string thanhphan = txtThanhPhan.Text;
            string hinhdang = txtHinhDang.Text;
            string handung = txtHanDung.Text;
            string chucnang = txtChucNang.Text;
            float gianhap = Convert.ToInt32(txtGiaNhap.Text);
            float giasi = Convert.ToInt32(txtGiaBanSi.Text);
            float giale = Convert.ToInt32(txtGiaBanLe.Text);
            float giankhuyenmai = Convert.ToInt32(txtGiaKhuyenMai.Text);
            int idloaithuoc = (cbxLoaiThuoc.SelectedItem as LoaiThuoc).IdLoai;
            int idnhasanxuat = (cbxNhaSanXuat.SelectedItem as NhaSanXuat).IdNhaSanXuat;
            int iddonvitinh = (cbxDonViTinh.SelectedItem as DonViTinh).IdDonViTinh;
            if (ThuocDAO.Instance.InsertThuoc(tenthuoc, duonguong, dangbaoche, hamluong, thanhphan, hinhdang, handung, chucnang, gianhap, giasi, giale, giankhuyenmai, idloaithuoc, idnhasanxuat, iddonvitinh))
            {
                MessageBox.Show("Thêm thuốc thành công");
            }
            else
            {
                MessageBox.Show("Thêm thuốc thất bại");
            }
            this.Close();
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (txtIDThuoc.Text != "")
            {
                int id = Convert.ToInt32(txtIDThuoc.Text);
                string tenthuoc = txtTenThuoc.Text;
                string duonguong = txtDuongUong.Text;
                string dangbaoche = txtDangBaoChe.Text;
                string hamluong = txtHamLuong.Text;
                string thanhphan = txtThanhPhan.Text;
                string hinhdang = txtHinhDang.Text;
                string handung = txtHanDung.Text;
                string chucnang = txtChucNang.Text;
                float gianhap = Convert.ToInt32(txtGiaNhap.Text);
                float giasi = Convert.ToInt32(txtGiaBanSi.Text);
                float giale = Convert.ToInt32(txtGiaBanLe.Text);
                float giankhuyenmai = Convert.ToInt32(txtGiaKhuyenMai.Text);
                int idloaithuoc = (cbxLoaiThuoc.SelectedItem as LoaiThuoc).IdLoai;
                int idnhasanxuat = (cbxNhaSanXuat.SelectedItem as NhaSanXuat).IdNhaSanXuat;
                int iddonvitinh = (cbxDonViTinh.SelectedItem as DonViTinh).IdDonViTinh;
                if (ThuocDAO.Instance.UpdateThuoc(id, tenthuoc, duonguong, dangbaoche, hamluong, thanhphan, hinhdang, handung, chucnang, gianhap, giasi, giale, giankhuyenmai, idloaithuoc, idnhasanxuat, iddonvitinh))
                {
                    MessageBox.Show("Sửa thuốc thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thuốc thất bại");
                }
            }
            else
            {
                MessageBox.Show("Hiện không có ID !!!", "Thông Báo");
            }
            this.Close();
        }

        private void btnXoaThuoc_Click_1(object sender, EventArgs e)
        {
            int idthuoc = Convert.ToInt32(txtIDThuoc.Text);
            if (ThuocDAO.Instance.DeleteThuoc(idthuoc))
            {
                MessageBox.Show("Xóa thuốc thành công");
            }
            else
            {
                MessageBox.Show("Xóa thuốc thất bại");
            }
            this.Close();
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {
            cleartext();
        }
        private void btnThemLoaiThuoc_Click(object sender, EventArgs e)
        {
            string tenLoai = cbxLoaiThuoc.Text;

            if (LoaiThuocDAO.Instance.InsertLoaiThuoc(tenLoai))
            {
                MessageBox.Show("Thêm loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm loại thất bại");
            }

            load();
        }

        private void btnThemNSX_Click(object sender, EventArgs e)
        {
            string tennsx = cbxNhaSanXuat.Text;

            if (NhaSanXuatDAO.Instance.InsertNhaSanXuat(tennsx))
            {
                MessageBox.Show("Thêm nhà sản xuất thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhà sản xuất thất bại");
            }

            load();
        }

        private void btnThemDonViTinh_Click(object sender, EventArgs e)
        {
            string tendvt = cbxDonViTinh.Text;

            if (DonViTinhDAO.Instance.InsertDonViTinh(tendvt))
            {
                MessageBox.Show("Thêm đơn vị thành công");
            }
            else
            {
                MessageBox.Show("Thêm đơn vị thất bại");
            }

            load();
        }
        #endregion
    }
}
