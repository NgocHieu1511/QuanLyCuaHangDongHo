using QuanLyCuaHangDongHo.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDongHo
{
    public partial class frmQLNhanVien : Form
    {
        public frmQLNhanVien()
        {
            InitializeComponent();
            this.KeyPreview = true;
            LoadList();
        }
        void LoadList()
        {
            string query = "SELECT * FROM NhanVien";
            DataProvider provider = new DataProvider();
            dtgvNhanVien.DataSource = provider.ExcuteQuery(query);
            dtgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dtgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dtgvNhanVien.Columns[2].HeaderText = "Ngày sinh";
            dtgvNhanVien.Columns[3].HeaderText = "Giới tính";
            dtgvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dtgvNhanVien.Columns[5].HeaderText = "Địa chỉ";
            dtgvNhanVien.AllowUserToAddRows = false;
            dtgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;



        }
        void ResetValue()
        {
            txtMaNhanVien.Text = "";
            dtpNgaySinh.Value = DateTime.Now;

            txtSoDienThoai.Text = "";
            txtDiaChi.Text = "";
            txtTenNhanVien.Text = "";
            cbGioiTinh.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fmain = new frmMain();
            fmain.ShowDialog();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void frmQLNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaNhanVien.Enabled = true;
            txtMaNhanVien.Focus();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            // 1. Kiểm tra tên nhân viên
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }

            // 2. Kiểm tra địa chỉ
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }

            // 3. Kiểm tra giới tính
            if (cbGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Kiểm tra số điện thoại
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }
            string query = "UPDATE NhanVien SET " +
                   "TenNV = N'" + txtTenNhanVien.Text + "', " +
                   "NgaySinh = '" + dtpNgaySinh.Text + "', " +
                   "GioiTinh = N'" + cbGioiTinh.Text + "', " +
                   "SDT = N'" + sdt + "', " +
                   "DiaChi = N'" + txtDiaChi.Text + "' " +
                   "WHERE MaNV = N'" + txtMaNhanVien.Text + "'";
            provider.RunSQL(query);

            MessageBox.Show("Đã cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadList();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvNhanVien_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }
            txtMaNhanVien.Text = dtgvNhanVien.CurrentRow.Cells[0].Value.ToString();
            txtTenNhanVien.Text = dtgvNhanVien.CurrentRow.Cells[1].Value.ToString();
            txtDiaChi.Text = dtgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            cbGioiTinh.Text = dtgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            dtpNgaySinh.Value = ((DateTime)dtgvNhanVien.CurrentRow.Cells[2].Value);

            txtSoDienThoai.Text = dtgvNhanVien.CurrentRow.Cells[4].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;



        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            DataProvider provider = new DataProvider();

            // 1. Kiểm tra mã nhân viên
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }

            // 2. Kiểm tra tên nhân viên
            if (txtTenNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNhanVien.Focus();
                return;
            }
            // 3.Kiểm tra địa chỉ
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            // 3. CHECK SỐ ĐIỆN THOẠI
            string sdt = txtSoDienThoai.Text.Trim();

            if (sdt.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDienThoai.Focus();
                return;
            }

            if (!sdt.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }

            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            //kiểm tra ngày sinh
            if (dtpNgaySinh.Value == null)
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgaySinh.Focus();
                return;
            }
            //kiểm tra giới tinh
            if (cbGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return;
            }


            // 4. Kiểm tra trùng mã
            query = "SELECT MaNV FROM NhanVien WHERE MaNV='" + txtMaNhanVien.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhanVien.Focus();
                return;
            }

            string ngay = dtpNgaySinh.Value.ToString("yyyy-MM-dd");

            // 6. INSERT đầy đủ 6 trường
            query = string.Format(
                "INSERT INTO NhanVien (MaNV, TenNV, NgaySinh, GioiTinh, SDT, DiaChi) " +
                "VALUES (N'{0}', N'{1}', '{2}', N'{3}', N'{4}', N'{5}')",
                txtMaNhanVien.Text,
                txtTenNhanVien.Text,
                ngay,
                cbGioiTinh.Text,
                sdt,
                txtDiaChi.Text
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNhanVien.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM NhanVien WHERE MaNV = N'" + txtMaNhanVien.Text + "'";
                provider.RunSQL(query);

                MessageBox.Show("Xoá nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadList();     // làm mới DataGridView
                ResetValue();   // reset form
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNhanVien.Enabled = false;
        }

        private void frmQLNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e) {
           DataProvider provider = new DataProvider();

                if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin tìm kiếm", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTimKiem.Focus();
                return;
            }

            string keyword = txtTimKiem.Text.Trim();

            string query = @"
        SELECT * FROM NhanVien 
        WHERE 
            maNV LIKE N'%" + keyword + @"%' OR
            tenNV LIKE N'%" + keyword + @"%' OR
            ngaysinh LIKE N'%" + keyword + @"%' OR
            gioitinh LIKE N'%" + keyword + @"%' OR
            sdt LIKE N'%" + keyword + @"%' OR
            diachi LIKE N'%" + keyword + @"%'
    ";

            DataTable dt = provider.GetDataTable(query);
            dtgvNhanVien.DataSource = dt;
        }






        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

