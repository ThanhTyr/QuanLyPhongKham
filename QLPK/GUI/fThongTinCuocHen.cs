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
    public partial class fThongTinCuocHen : Form
    {
        public fThongTinCuocHen()
        {
            InitializeComponent();
            load();
        }
        #region Method
        void load()
        {
        }
        void cleartext()
        {
            txtHoTen.Text = "";
            txtIDHen.Text = "";
            txtSDT.Text = "";
            dtpkThoiGianHen.ResetText();
        }
        #endregion
        #region Event
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtIDHen.Text != "")
            {
                int id = Convert.ToInt32(txtIDHen.Text);
                DateTime? thoigianhen = dtpkThoiGianHen.Value;
                int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
                if (DanhSachKhamDAO.Instance.UpdateHen(id, idbenhnhan, thoigianhen))
                {
                    MessageBox.Show("Sửa cuộc hẹn thành công");
                }
                else
                {
                    MessageBox.Show("Sửa cuộc hẹn thất bại");
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
            int idhen = Convert.ToInt32(txtIDHen.Text);
            if (DanhSachKhamDAO.Instance.DeleteHen(idhen))
            {
                MessageBox.Show("Xóa cuộc hẹn thành công");
            }
            else
            {
                MessageBox.Show("Xóa cuộc hẹn thất bại");
            }
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cleartext();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int stt = 0;
            string thoigianhen = dtpkThoiGianHen.Text;
            int danhsachkham = DanhSachKhamDAO.Instance.KiemTraDanhSachKhamTheoNgay(thoigianhen);
            if(danhsachkham != -1)
            {
                if (txtIDBenhNhan.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân !!!!", "Thông Báo");
                }
                else
                {
                    int maxstt = Convert.ToInt32(DanhSachKhamDAO.Instance.LayMaxSTTNgayHen(thoigianhen));
                    stt = maxstt + 1 ;
                    int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
                    DanhSachKhamDAO.Instance.Inserthen(idbenhnhan, stt, thoigianhen);
                }
            }
            else
            {
                if (txtIDBenhNhan.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân !!!!", "Thông Báo");
                }
                else
                {
                    int idbenhnhan = Convert.ToInt32(txtIDBenhNhan.Text);
                    DanhSachKhamDAO.Instance.Inserthen(idbenhnhan, stt, thoigianhen);
                }
            }
            this.Close();
        }

        private void btnChonBenhNhan_Click(object sender, EventArgs e)
        {
            fChonBenhNhan f = new fChonBenhNhan();
            f.ShowDialog();
            txtIDBenhNhan.Text = ChonBenhNhan.id;
            txtHoTen.Text = ChonBenhNhan.hoten;
            txtSDT.Text = ChonBenhNhan.sdt;
        }
        #endregion
    }
}
