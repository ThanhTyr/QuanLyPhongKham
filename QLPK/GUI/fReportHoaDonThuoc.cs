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
    public partial class fReportHoaDonThuoc : Form
    {
        public fReportHoaDonThuoc()
        {
            InitializeComponent();
        }

        private void fReportHoaDonThuoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyPhongKhamDataSet2.USP_HoaDonThuocCuaBenhNhan' table. You can move, or remove it, as needed.
            this.uSP_HoaDonThuocCuaBenhNhanTableAdapter.Fill(this.quanLyPhongKhamDataSet2.USP_HoaDonThuocCuaBenhNhan);

            this.rvrHoaDonThuoc.RefreshReport();
        }
    }
}
