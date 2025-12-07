using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyCuaHangDongHo
{
    public partial class frmMain : Form
    {
        private string username;
        public frmMain()
        {
            InitializeComponent();
              

        }
        public frmMain(string username)
        {
            InitializeComponent(); 
            this.username = username;
        }
      

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLNhanVien f= new frmQLNhanVien();
            f.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            frmDangNhap f = new frmDangNhap();
            this.Hide();       
            f.ShowDialog();    
            this.Close();




        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmThongKe f = new frmThongKe();
            f.ShowDialog();
            this.Close();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            //lblWelcome.Text = "Xin chào " + username + "!";
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLLuong f = new frmQLLuong();
            f.ShowDialog();
            this.Close();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLNhaCungCap f = new frmQLNhaCungCap();
            f.ShowDialog();
            this.Close();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLSanPham f = new frmQLSanPham();
            f.ShowDialog();
            this.Close();
        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLPhieuNhap f = new frmQLPhieuNhap();
            f.ShowDialog();
            this.Close();
        }

        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLHoaDon f = new frmQLHoaDon();
            f.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
