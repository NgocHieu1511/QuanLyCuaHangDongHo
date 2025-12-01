using QuanLyCuaHangDongHo.DAO;
using System;
using System.Collections;
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
    public partial class frmQLSanPham : Form
    {
        public frmQLSanPham()
        {
            InitializeComponent();
            LoadList();
        }

        void LoadList()
        {
            string query = "SELECT * FROM SanPham";
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            DataProvider provider = new DataProvider();
            dtgvSanPham.DataSource = provider.ExcuteQuery(query);
            dtgvSanPham.Columns[0].HeaderText = "Mã Sản Phẩm";
            dtgvSanPham.Columns[1].HeaderText = "Tên Sản Phẩm";
            dtgvSanPham.Columns[2].HeaderText = "Giá";
            dtgvSanPham.Columns[3].HeaderText = "Số lượng";
            dtgvSanPham.Columns[4].HeaderText = "Hình ảnh";
            dtgvSanPham.AllowUserToAddRows = false;
            //không cho người dùng tự thêm cột bằng tay
            dtgvSanPham.EditMode = DataGridViewEditMode.EditProgrammatically;
            //không cho người dùng sửa dữ liệu trực tiếp trong ô

        }
        void ResetValue()
        {
            txtTenSP.Text = "";
            

            txtGia.Text = "0";
            txtMaSP.Text = "";
            txtSoLuong.Text = "0";
            txtAnh.Text = "";
            picAnh.Image = null;


        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLSanPham_Load(object sender, EventArgs e)
        {

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
            txtMaSP.Enabled = true;
            txtMaSP.Focus();
            txtSoLuong.Enabled = true;
            txtGia.Enabled = true;
            txtAnh.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void dtgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }
            if (dtgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSP.Text = dtgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dtgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtGia.Text = dtgvSanPham.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.Text = dtgvSanPham.CurrentRow.Cells[3].Value.ToString();
            txtAnh.Text = dtgvSanPham.CurrentRow.Cells[4].Value.ToString();
            String query = "SELECT Anh FROM SanPham WHERE maSP = N'" + txtMaSP.Text + "'";
            txtAnh.Text = provider.GetFieldValues(query);
            picAnh.Image = Image.FromFile(txtAnh.Text);
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            //kiểm tra mã sản phẩm
            if(txtMaSP.Text.Trim().Length== 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }
            //kiem tra tên sản phẩm
            if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }
            // Kiểm tra Số lượng
            int soLuong;
            if (txtSoLuong.Text.Trim().Length == 0 || !int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // Kiểm tra Giá
            double gia;
            if (txtGia.Text.Trim().Length == 0 || !double.TryParse(txtGia.Text.Trim(), out gia) || gia < 0)
            {
                MessageBox.Show("Giá sản phẩm phải là số hợp lệ và không âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            // Kiểm tra Ảnh (nếu muốn)
            if (txtAnh.Text.Trim().Length == 0 )
            {
                MessageBox.Show("File ảnh không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnOpen.Focus();
                return;
            }
            //kiểm tra xem mã mặt hàng có bị trùng không
            string query = "SELECT maSP FROM SanPham WHERE MaSP=N'" + txtMaSP.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã sản phẩm này đã tồn tại, bạn phải chọn mã sản phẩm khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }
            query = "INSERT INTO SanPham(MaSP,TenSP,soLuong,gia,Anh) VALUES(N'"
                + txtMaSP.Text.Trim() + "',N'" + txtTenSP.Text.Trim() +
                "'," + txtSoLuong.Text.Trim() + "," + txtGia.Text +
                ",'" + txtAnh.Text.Trim()+"')";
            provider.RunSQL(query);
            LoadList();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSP.Enabled = false;

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
                txtAnh.Text = dlgOpen.FileName;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSP.Focus();
                return;
            }

            if (txtTenSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenSP.Focus();
                return;
            }

            // Kiểm tra số lượng
            int soLuong;
            if (!int.TryParse(txtSoLuong.Text.Trim(), out soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên không âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // Kiểm tra giá
            double gia;
            if (!double.TryParse(txtGia.Text.Trim(), out gia) || gia < 0)
            {
                MessageBox.Show("Giá sản phẩm phải là số hợp lệ và không âm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return;
            }

            if (txtAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Câu UPDATE
            string query = "UPDATE SanPham SET " +
                             "TenSP = N'" + txtTenSP.Text.Trim() + "', " +
                             "SoLuong = " + soLuong + ", " +
                             "Gia = " + gia + ", " +
                             "Anh = '" + txtAnh.Text.Trim() + "' " +
                           "WHERE MaSP = N'" + txtMaSP.Text.Trim() + "'";

            provider.RunSQL(query);

            MessageBox.Show("Đã cập nhật thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadList();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            if (dtgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE SanPham WHERE MaSP=N'" + txtMaSP.Text + "'";
                provider.RunSQL(query);

                MessageBox.Show("Xoá sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadList();     // làm mới DataGridView
                ResetValue();   // reset form
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
        SELECT * FROM SanPham 
        WHERE 
            MaSP LIKE N'%" + keyword + @"%' OR
            TenSP LIKE N'%" + keyword + @"%' OR
            soLuong LIKE N'%" + keyword + @"%' OR
            gia LIKE N'%" + keyword + @"%' OR
            Anh LIKE N'%" + keyword + @"%'
    ";

            DataTable dt = provider.GetDataTable(query);
            dtgvSanPham.DataSource = dt;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaSP.Enabled = false;
        }
    }
}

