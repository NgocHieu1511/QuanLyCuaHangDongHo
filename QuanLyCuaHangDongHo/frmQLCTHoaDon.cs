using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDongHo
{
    public partial class frmQLCTHoaDon : Form
    {
        public frmQLCTHoaDon()
        {
            InitializeComponent();
        }

        private void frmQLCTHoaDon_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLHoaDon f = new frmQLHoaDon();
            f.ShowDialog();
            f.Close();
        }

        private void dtgvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
