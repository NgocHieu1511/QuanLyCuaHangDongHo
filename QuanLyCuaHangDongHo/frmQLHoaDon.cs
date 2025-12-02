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
            dtgvQLHoaDon.Columns[1].HeaderText = "Ngày bán";
            dtgvQLHoaDon.Columns[2].HeaderText = "Mã nhân viên";
            dtgvQLHoaDon.AllowUserToAddRows = false;
            dtgvQLHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        void ResetValue()
        {
            txtMaHĐ.Text = "";
            cbMaNV.SelectedIndex = -1;
            dtpNgayBan.Value = DateTime.Now;
        }
         private void LoadInfoHoaDon()
        {
            DataProvider provider = new DataProvider();
            string query;
            query = "SELECT maHD FROM HoaDon WHERE maHD = N'" + txtMaHĐ.Text + "'";
            txtMaHĐ.Text = provider.GetFieldValues(query);
            
            query = "SELECT maNV FROM HoaDon WHERE maHD = N'" + txtMaHĐ.Text + "'";
            cbMaNV.Text = provider.GetFieldValues(query);
            query = "SELECT ngay FROM HoaDon WHERE maHD = N'" + txtMaHĐ.Text + "'";
            dtpNgayBan.Value = DateTime.Parse(provider.GetFieldValues(query));

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
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThem.Enabled = false;
            ResetValue();
            LoadList();
        }

        private void dtgvQLHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvQLHoaDon.Rows[e.RowIndex];

                txtMaHĐ.Text = row.Cells["maHD"].Value.ToString();
                cbMaNV.SelectedValue = row.Cells["maNV"].Value.ToString();
                dtpNgayBan.Value = Convert.ToDateTime(row.Cells["ngay"].Value);

                btnXoa.Enabled = true;
                btnInHoaDon.Enabled = true;
                btnLuu.Enabled = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            string query;
            
            query = "SELECT MaHD FROM HoaDon WHERE MaHD=N'" + txtMaHĐ.Text + "'";
            if (!provider.CheckKey(query))
            {
                // Mã hóa đơn chưa có, tiến hành lưu các thông tin chung
                // Mã HDBan được sinh tự động do đó không có trường hợp trùng khóa
                if (dtpNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNgayBan.Focus();
                    return;
                }
                if (cbMaNV.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaNV.Focus();
                    return;
                }

                query = "INSERT INTO HoaDon(MaHD, ngay, MaNV) VALUES (N'"
        + txtMaHĐ.Text.Trim() + "', '"
        + dtpNgayBan.Text.Trim() + "', N'"
        + cbMaNV.SelectedValue + "')";
                provider.RunSQL(query);

            }
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnInHoaDon.Enabled = true;
        }
    }
}
