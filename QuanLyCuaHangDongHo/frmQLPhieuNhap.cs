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
    public partial class frmQLPhieuNhap : Form
    {
        public frmQLPhieuNhap()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {

            string query = "SELECT * FROM PhieuNhap";
            DataProvider provider = new DataProvider();
            dtgvPhieuNhap.DataSource = provider.ExcuteQuery(query);
            dtgvPhieuNhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dtgvPhieuNhap.Columns[1].HeaderText = "Mã nhà cung cấp";
            dtgvPhieuNhap.Columns[2].HeaderText = "Ngày nhập";
            dtgvPhieuNhap.Columns[3].HeaderText = "Tiền nhập";

            dtgvPhieuNhap.AllowUserToAddRows = false;
            dtgvPhieuNhap.EditMode = DataGridViewEditMode.EditProgrammatically;



        }
        //private void LoadInfoPhieuNhap()
        //{
        //    DataProvider provider = new DataProvider();
        //    string query;
        //    query = "SELECT maPN FROM PhieuNhap WHERE maPN = N'" + txtMaPN.Text + "'";
        //    txtMaPN.Text = provider.GetFieldValues(query);

        //    query = "SELECT maNV FROM PhieuNhap WHERE maPN = N'" + txtMaPN.Text + "'";
        //    cbMaNV.SelectedValue = provider.GetFieldValues(query);
        //    query = "SELECT maNCC FROM PhieuNhap WHERE maPN = N'" + txtMaPN.Text + "'";
        //    cbNCC.SelectedValue = provider.GetFieldValues(query);
        //    query = "SELECT ngay FROM PhieuNhap WHERE maPN = N'" + txtMaPN.Text + "'";
        //    dtpNgayNhap.Value = DateTime.Parse(provider.GetFieldValues(query));
            

        //}
        void ResetValue()
        {
            txtPN.Text = "";
            cbNCC.SelectedIndex=-1;
            cbNV.SelectedIndex=-1;
            dtpNgay.Value = DateTime.Now;


        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void frmQLPhieuNhap_Load(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            txtPN.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            provider.FillCombo("SELECT maNV, tenNV FROM NhanVien", cbNV, "maNV", "maNV");
            cbNV.SelectedIndex = -1;
            provider.FillCombo("SELECT maNCC, tenNCC FROM NhaCungCap", cbNCC, "maNCC", "maNCC");
            cbNCC.SelectedIndex = -1;


            LoadList();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQLCTPhieuNhap f = new frmQLCTPhieuNhap();
            f.ShowDialog();
            this.Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtPN.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtPN.Enabled = true;
            txtPN.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string query;
            DataProvider provider = new DataProvider();

            // 1. Kiểm tra mã nhân viên
            if (txtPN.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã phiếu nhập", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPN.Focus();
                return;
            }

            
            
            
            
            //kiểm tra ngày sinh
            if (dtpNgay.Value == null)
            {
                MessageBox.Show("Bạn phải nhập ngày nhập hàng", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgay.Focus();
                return;
            }
            //kiểm tra giới tinh
            if (cbNCC.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mã nhà cung cấp !");
                return;
            }


            // 4. Kiểm tra trùng mã
            query = "SELECT maPN FROM PhieuNhap WHERE maPN='" + txtPN.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPN.Focus();
                return;
            }

            string ngay = dtpNgay.Value.ToString("yyyy-MM-dd");

            // 6. INSERT đầy đủ 6 trường
            query = string.Format(
                "INSERT INTO PhieuNhap (maPN, maNCC, ngay, maNV) " +
                "VALUES (N'{0}', N'{1}', '{2}', N'{3}')",
                txtPN.Text,
                cbNCC.Text,
                ngay,
                cbNV.Text
                
            );

            // 7. Chạy INSERT đúng cách
            provider.RunSQL(query);
            // >>> Thêm đoạn này ngay dưới INSERT:
            string updateTienNhap = "UPDATE PhieuNhap " +
                        "SET tienNhap = (SELECT SUM(soLuong * donGia) " +
                        "FROM ChiTietPhieuNhap " +
                        "WHERE ChiTietPhieuNhap.maPN = PhieuNhap.maPN) " +
                        "WHERE maPN = '" + txtPN.Text.Trim() + "'";




            provider.RunSQL(updateTienNhap);

            // 8. Làm mới form
            LoadList();
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaPN.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPN.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPN.Focus();
                return;
            }
            

            

            // 3. Kiểm tra giới tính
            if (cbNV.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbNCC.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string ngay = dtpNgay.Value.ToString("yyyy-MM-dd");

            string query = "UPDATE PhieuNhap SET " +
                   "maPN = N'" + txtPN.Text + "', " +
                   "maNCC = '" + cbNCC.Text + "', " +
                   "ngay = N'" + ngay + "', " +
                   "maNV = N'" + cbNV.Text + "' " +

                   "WHERE maPN = N'" + txtPN.Text + "'";
            provider.RunSQL(query);

            MessageBox.Show("Đã cập nhật thông tin phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadList();
            ResetValue();
            btnBoQua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();

            if (dtgvPhieuNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (txtPN.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "DELETE FROM PhieuNhap WHERE maPN = N'" + txtPN.Text + "'";
                provider.RunSQL(query);

                MessageBox.Show("Xoá phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadList();     
                ResetValue();   
            }
        }

        private void dtgvPhieuNhap_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPN.Focus();
                return;
            }
            txtPN.Text = dtgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();           
            cbNCC.Text = dtgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            
            dtpNgay.Value = ((DateTime)dtgvPhieuNhap.CurrentRow.Cells[2].Value);
            cbNV.Text = dtgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();


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
        SELECT * FROM PhieuNhap 
        WHERE 
            maPN LIKE N'%" + keyword + @"%' OR
            maNCC LIKE N'%" + keyword + @"%' OR
            ngay LIKE N'%" + keyword + @"%' OR
            tienNhap LIKE N'%" + keyword + @"%' OR
            maNV LIKE N'%" + keyword + @"%' 
            
    ";

            DataTable dt = provider.GetDataTable(query);
            dtgvPhieuNhap.DataSource = dt;
        }
    }
    }
    

