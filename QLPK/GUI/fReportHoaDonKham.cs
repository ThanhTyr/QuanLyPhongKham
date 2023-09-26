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
    public partial class fReportHoaDonKham : Form
    {
        public fReportHoaDonKham()
        {
            InitializeComponent();
        }

        private void fReportHoaDonKham_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyPhongKhamDataSet1.USP_HoaDonKhamCuaBenhNhan' table. You can move, or remove it, as needed.
            this.uSP_HoaDonKhamCuaBenhNhanTableAdapter.Fill(this.quanLyPhongKhamDataSet1.USP_HoaDonKhamCuaBenhNhan);

            this.rvrHoaDonKham.RefreshReport();
        }
    }
}
