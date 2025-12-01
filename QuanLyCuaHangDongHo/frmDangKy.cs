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
    public partial class frmDangKy : Form
    {
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }

        private void frmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không", "Thông báo", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{
            //    e.Cancel = false;
            //}
            //else
            //    e.Cancel = true;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangNhap frm = new frmDangNhap();
            
            frm.ShowDialog();
            this.Close();


        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã đăng ký tài khoản thành công !", "Thông báo", MessageBoxButtons.OK);
        }

        private void lblDangKy_Click(object sender, EventArgs e)
        {

        }

        private void lblTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
