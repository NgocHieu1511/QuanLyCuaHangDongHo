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
    public partial class frmQLNhaCungCap : Form
    {
        public frmQLNhaCungCap()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {
            string query = "SELECT * FROM NhaCungCap";
            DataProvider provider = new DataProvider();
            dtgvNCC.DataSource = provider.ExcuteQuery(query);
            dtgvNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dtgvNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dtgvNCC.Columns[2].HeaderText = "Số điện thoại";
            dtgvNCC.Columns[3].HeaderText = "Địa chỉ";
            dtgvNCC.AllowUserToAddRows = false;
            dtgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;



        }
        void ResetValue()
        {
            txtMaNCC.Text = "";

            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTenNCC.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmQLNhaCungCap_Load(object sender, EventArgs e)
        {
            txtMaNCC.Enabled = false;
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
           txtMaNCC.Enabled = true;
            txtMaNCC.Focus();
        }

        private void dtgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvNCC_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }
           txtMaNCC.Text =dtgvNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = dtgvNCC.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dtgvNCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = dtgvNCC.CurrentRow.Cells[3].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            DataProvider provider = new DataProvider();

            // 1. Kiểm tra mã nhân viên
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhà cung cấp", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }

            // 2. Kiểm tra tên nhân viên
            if (txtTenNCC.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhà cung cấp", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNCC.Focus();
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
            string sdt = txtSDT.Text.Trim();

            if (sdt.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;
            }

            if (!sdt.All(Char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }

            if (sdt.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng 10 số!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Focus();
                return;
            }
            
            


            // 4. Kiểm tra trùng mã
            query = "SELECT MaNV FROM NhanVien WHERE MaNV='" + txtMaNCC.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNCC.Focus();
                return;
            }

            

            
            query = string.Format(
                "INSERT INTO NhaCungCap (maNCC, tenNCC,sdt, diachi) " +
                "VALUES (N'{0}', N'{1}', '{2}', N'{3}')",
                txtMaNCC.Text,
                txtTenNCC.Text,
              
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
            txtMaNCC.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaNCC.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNCC.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM NhaCungCap WHERE MaNCC = N'" + txtMaNCC.Text + "'";
                provider.RunSQL(query);

                MessageBox.Show("Xoá nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadList();     // làm mới DataGridView
                ResetValue();   // reset form
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
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
        SELECT * FROM NhaCungCap 
        WHERE 
            maNCC LIKE N'%" + keyword + @"%' OR
            tenNCC LIKE N'%" + keyword + @"%' OR
            sdt LIKE N'%" + keyword + @"%' OR
            diachi LIKE N'%" + keyword + @"%'
    ";

            DataTable dt = provider.GetDataTable(query);
            dtgvNCC.DataSource = dt;
        }
    }
    }

