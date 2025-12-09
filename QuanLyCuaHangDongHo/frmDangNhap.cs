using QuanLyCuaHangDongHo.DAO;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //// Tạo form mới
            //frmDangKy f = new frmDangKy();

            //// Hiển thị Form2
            //f.ShowDialog();
            //this.Close();

            
            
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình không", "Thông báo", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes){
            //    e.Cancel = false;
                
            //}
            //else
            //    e.Cancel = true;
                
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtpassword.Text;
            if (Login(username,password))
            {
                this.Hide();
                frmMain f = new frmMain(username);
                // Ẩn form đăng nhập
                f.ShowDialog();    // Mở form Trang Chủ
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
           


        }
        
        bool Login(string username,string password)
        {
            DataProvider provider = new DataProvider();
            string query = "SELECT * FROM TaiKhoan WHERE taiKhoan = N'" + username + "' AND matKhau = N'" + password + "'";

            DataTable result = provider.ExcuteQuery(query);
            return result.Rows.Count>0;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtpassword.UseSystemPasswordChar = false;
            }else 
                txtpassword.UseSystemPasswordChar=true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
