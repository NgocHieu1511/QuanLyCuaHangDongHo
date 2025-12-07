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
            dtgvLuong.Columns[0].HeaderText = "Mã lương";
            dtgvLuong.Columns[1].HeaderText = "Mã Nhân viên";
            dtgvLuong.Columns[3].HeaderText = "Ngày công";
            dtgvLuong.Columns[4].HeaderText = "Hệ số lương";
            dtgvLuong.Columns[5].HeaderText = "Thưởng";
            dtgvLuong.Columns[5].HeaderText = "Tổng lương";


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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            DataProvider provider = new DataProvider();

            // 1. Kiểm tra mã bảng lương
            if (txtMaBangLuong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã bảng lương", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaBangLuong.Focus();
                return;
            }

            // 2. Kiểm tra mã nhân viên
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            
            // 3. CHECK SỐ ĐIỆN THOẠI
            string hsl = txtHSLuong.Text.Trim();

            if (hsl.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập hệ số lương", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHSLuong.Focus();
                return;
            }

            if (!hsl.All(Char.IsDigit))
            {
                MessageBox.Show("hệ số lương chỉ được chứa số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHSLuong.Focus();
                return;
            }

            if (hsl.Length != 2)
            {
                MessageBox.Show("hệ số lương phải đúng 2 chữ số", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHSLuong.Focus();
                return;
            }
            // 3. CHECK SỐ ĐIỆN THOẠI
            string ngaycong = txtNgayCong.Text.Trim();

            if (ngaycong.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNgayCong.Focus();
                return;
            }

            if (!ngaycong.All(Char.IsDigit))
            {
                MessageBox.Show("ngày công chỉ được chứa số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayCong.Focus();
                return;
            }

            int nc = int.Parse(ngaycong);

            if (nc < 0 || nc > 31)
            {
                MessageBox.Show("Ngày công phải nằm trong khoảng 0 - 31!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayCong.Focus();
                return;
            }





            // 4. Kiểm tra trùng mã
            query = "SELECT maLuong FROM Luong WHERE maLuong='" + txtMaBangLuong.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã lương đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaBangLuong.Focus();
                return;
            }
            




            // 6. INSERT đầy đủ 6 trường
            query = string.Format(
                "INSERT INTO Luong (maLuong, maNV, ngayCong, hsl, thuong) " +
                "VALUES (N'{0}', N'{1}', '{2}', N'{3}', N'{4}')",
                txtMaBangLuong.Text,
                txtMaNhanVien.Text,
                ngaycong,
                hsl,
                txtThuong.Text
                
            );

            // 7. Chạy INSERT đúng cách
            provider.RunSQL(query);

            // 8. Làm mới form
            LoadList();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaBangLuong.Enabled = false;
        }
    }
}
