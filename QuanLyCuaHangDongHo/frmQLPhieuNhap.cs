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
    public partial class frmQLPhieuNhap : Form
    {
        public frmQLPhieuNhap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLPhieuNhap_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLCTPhieuNhap f = new frmQLCTPhieuNhap();
            f.ShowDialog();
            this.Close();
        }
    }
    }

