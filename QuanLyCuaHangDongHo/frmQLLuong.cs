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
    public partial class frmQLLuong : Form
    {
        public frmQLLuong()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {
            string query = "SELECT * FROM Luong";
            DataProvider provider = new DataProvider();
            dtgvLuong.DataSource = provider.ExcuteQuery(query);
            dtgvLuong.Columns[0].HeaderText = "Mã Hóa Đơn";
            dtgvLuong.Columns[1].HeaderText = "Ngày bán";
            dtgvLuong.Columns[2].HeaderText = "Mã nhân viên";
            dtgvLuong.AllowUserToAddRows = false;
            dtgvLuong.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        void ResetValue()
        {
            txtMaBangLuong.Text = "";
            txtHSLuong.Text = "";
            txtMaNhanVien.Text = "";
            txtThuong.Text = "";
            txtNgayCong.Text = "";
            cbThang.SelectedIndex = -1;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLLuong_Load(object sender, EventArgs e)
        {
            txtMaBangLuong.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaBangLuong.Enabled = true;
            txtMaBangLuong.Focus();
        }
    }
}
