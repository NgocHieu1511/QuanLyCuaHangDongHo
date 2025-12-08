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
    public partial class frmQLCTPhieuNhap : Form
    {
        public frmQLCTPhieuNhap()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {

            string query = "SELECT * FROM ChiTietPhieuNhap";
            DataProvider provider = new DataProvider();
            dtgvCTPhieuNhap.DataSource = provider.ExcuteQuery(query);
            dtgvCTPhieuNhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgvCTPhieuNhap.Columns[1].HeaderText = "Số lượng";
            dtgvCTPhieuNhap.Columns[2].HeaderText = "Đơn giá";
            dtgvCTPhieuNhap.Columns[3].HeaderText = "Mã sản phẩm";

            dtgvCTPhieuNhap.AllowUserToAddRows = false;
            dtgvCTPhieuNhap.EditMode = DataGridViewEditMode.EditProgrammatically;



        }
        void ResetValue()
        {
            txtDonGia.Text = "0";
            txtSoLuong.Text = "0";
            cbMaSP.SelectedIndex = -1;
            cbMaPN.SelectedIndex = -1;
            



        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLPhieuNhap f = new frmQLPhieuNhap();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLCTPhieuNhap_Load(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            cbMaPN.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            provider.FillCombo("SELECT maPN FROM PhieuNhap", cbMaPN, "maPN","maPN");
            cbMaPN.SelectedIndex = -1;
            provider.FillCombo("SELECT maSP FROM SanPham", cbMaSP, "maSP", "tenSP");
            cbMaSP.SelectedIndex = -1;


            LoadList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            cbMaPN.Enabled = true;
            cbMaPN.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            DataProvider provider = new DataProvider();

            // 1. Kiểm tra mã nhân viên
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }



            //kiểm tra giới tinh
            if (cbMaPN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập !");
                return;
            }
            if (cbMaSP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm !");
                return;
            }


            // 4. Kiểm tra trùng mã
            query = "SELECT maPN FROM ChiTietPhieuNhap WHERE maPN='" + cbMaPN.SelectedItem + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbMaPN.Focus();
                return;
            }

            

            // 6. INSERT đầy đủ 6 trường
            query = string.Format(
                "INSERT INTO ChiTietPhieuNhap (maPN, soLuong, donGia, maSP) " +
                "VALUES (N'{0}', N'{1}', '{2}', N'{3}')",
                cbMaPN.Text,
                txtSoLuong.Text,
                txtDonGia.Text,
                cbMaSP.Text

            );

            // 7. Chạy INSERT đúng cách
            provider.RunSQL(query);
            string updateTienNhap = "UPDATE PhieuNhap " +
                        "SET tienNhap = (SELECT SUM(soLuong * donGia) " +
                        "FROM ChiTietPhieuNhap " +
                        "WHERE ChiTietPhieuNhap.maPN = PhieuNhap.maPN) " +
                        "WHERE maPN = '" + cbMaPN.Text.Trim() + "'";
            
            provider.RunSQL(updateTienNhap);


            // 8. Làm mới form
            LoadList();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            cbMaPN.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvCTPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           

            // 3. Kiểm tra giới tính
            if (cbMaPN.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã phiếu nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbMaSP.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. Kiểm tra số điện thoại
            string DonGia = txtDonGia.Text.Trim();
            if (DonGia.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDonGia.Focus();
                return;
            }
            string SoLuong = txtSoLuong.Text.Trim();
            if (SoLuong.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            string query = "UPDATE ChiTietPhieuNhap SET " +
                   "maPN = N'" + cbMaPN.Text + "', " +
                   "maSP = '" + cbMaSP.Text + "', " +
                   "soLuong = N'" + txtSoLuong.Text + "', " +
                   "donGia = N'" + txtDonGia.Text + "' " +
                   
                   "WHERE MaPN = N'" + cbMaPN.Text + "'";
            provider.RunSQL(query);

            MessageBox.Show("Đã cập nhật thông tin chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadList();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvCTPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cbMaSP.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaSP.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM ChiTietPhieuNhap WHERE maPN = N'" + cbMaPN.Text + "' AND maSP = N'" + cbMaSP.Text + "'";

                provider.RunSQL(query);

                MessageBox.Show("Xoá phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            cbMaPN.Enabled = false;
        }

        private void dtgvCTPhieuNhap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaPN.Focus();
                return;
            }
            cbMaPN.Text = dtgvCTPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            txtSoLuong.Text = dtgvCTPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            txtDonGia.Text = dtgvCTPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            cbMaSP.Text = dtgvCTPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            

            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;

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
        SELECT * FROM ChiTietPhieuNhap 
        WHERE 
            maPN LIKE N'%" + keyword + @"%' OR
            maSP LIKE N'%" + keyword + @"%' OR
            soLuong LIKE N'%" + keyword + @"%' OR
            donGia LIKE N'%" + keyword + @"%' 
            
    ";

            DataTable dt = provider.GetDataTable(query);
            dtgvCTPhieuNhap.DataSource = dt;
        }
    }
    }

    

