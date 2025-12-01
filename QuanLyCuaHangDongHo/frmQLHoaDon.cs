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
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QuanLyCuaHangDongHo
{
    public partial class frmQLHoaDon : Form
    {
        public frmQLHoaDon()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {
            string query = "SELECT * FROM HoaDon";
            DataProvider provider = new DataProvider();
            dtgvQLHoaDon.DataSource = provider.ExcuteQuery(query);
            dtgvQLHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
            dtgvQLHoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dtgvQLHoaDon.Columns[2].HeaderText = "Ngày bán";
            dtgvQLHoaDon.AllowUserToAddRows = false;
            dtgvQLHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLCTHoaDon f = new frmQLCTHoaDon();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLHoaDon_Load(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHĐ.ReadOnly = true;
            dtpNgayBan.Value = DateTime.Now;
            provider.FillCombo("SELECT MaNV, TenNV FROM NhanVien", cbMaNV, "MaNV", "MaNV");
            cbMaNV.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHĐ.Text != "")
            {
                //LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadList();
        }
    }
}
