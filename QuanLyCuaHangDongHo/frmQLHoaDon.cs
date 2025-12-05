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
            
            string query = "SELECT  a.maSP, b.tenSP,a.SoLuong, b.gia, a.giamGia,a.ThanhTien FROM " +
                "ChiTietHoaDon AS a, SanPham AS b WHERE a.maHD = N'" + txtMaHĐ.Text + "' AND a.maSP=b.maSP";
            DataProvider provider = new DataProvider();
            dtgvQLHoaDon.DataSource = provider.ExcuteQuery(query);
            

            dtgvQLHoaDon.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvQLHoaDon.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvQLHoaDon.Columns[2].HeaderText = "Số lượng";
            dtgvQLHoaDon.Columns[3].HeaderText = "Đơn giá";
            dtgvQLHoaDon.Columns[4].HeaderText = "Giảm giá %";
            dtgvQLHoaDon.Columns[5].HeaderText = "Thành Tiền";
            dtgvQLHoaDon.AllowUserToAddRows = false;
            dtgvQLHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        void ResetValue()
        {
            txtMaHĐ.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            cbMaNV.Text = "";
            
            
           
            cbMaSP.Text = "";
            txtSoLuong.Text = "0";
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            txtThanhTien.Text = "0";
        }
        private void ResetValuesHang()
        {
            cbMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";
            txtThanhTien.Text = "0";
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
            query = "SELECT TongTien FROM HoaDon WHERE maHD = N'" + txtMaHĐ.Text + "'";

            txtTongTien.Text = provider.GetFieldValues(query);

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
            btnIn.Enabled = false;
            txtMaHĐ.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenSP.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            
            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            dtpNgayBan.Value = DateTime.Now;
            provider.FillCombo("SELECT MaNV, TenNV FROM NhanVien", cbMaNV, "MaNV", "MaNV");
            cbMaNV.SelectedIndex = -1;
            provider.FillCombo("SELECT MaSP, TenSP FROM SanPham", cbMaSP, "MaSP", "MaSP");
            cbMaSP.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHĐ.Text != "")
            {
                LoadInfoHoaDon();
                btnXoa.Enabled = true;
                btnIn.Enabled = true;
            }
            LoadList();

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnIn.Enabled = false;
            btnThem.Enabled = false;
            ResetValue();
            
            txtMaHĐ.Text = provider.CreateKey("HD");
            LoadList();
        }

        private void dtgvQLHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            string query;

            double sl, slcon, tong, Tongmoi;

            // Kiểm tra hóa đơn đã tồn tại chưa
            query = "SELECT maHD FROM HoaDon WHERE maHD=N'" + txtMaHĐ.Text.Trim() + "'";
            if (!provider.CheckKey(query))
            {
                //if (dtpNgayBan.Text.Length == 0)
                //{
                //    MessageBox.Show("Bạn phải nhập ngày bán", "Thông báo");
                //    dtpNgayBan.Focus();
                //    return;
                //}
                //if (cbMaNV.Text.Length == 0)
                //{
                //    MessageBox.Show("Bạn phải nhập nhân viên", "Thông báo");
                //    cbMaNV.Focus();
                //    return;
                //}
                query = "INSERT INTO HoaDon (maHD, ngay, maNV, TongTien) VALUES(N'"
         + txtMaHĐ.Text.Trim() + "', '"
         + dtpNgayBan.Value.ToString("yyyy-MM-dd") + "', N'"
         + cbMaNV.SelectedValue.ToString() + "', "
         + txtTongTien.Text + ")";

                provider.RunSQL(query);
            }

            if (cbMaSP.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sản phẩm", "Thông báo");
                cbMaSP.Focus();
                return;
            }

            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            if (txtGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiamGia.Focus();
                return;
            }
            query = "SELECT maSP FROM ChiTietHoaDon WHERE maSP=N'" + 
                cbMaSP.SelectedValue + "' AND maHD = N'" + txtMaHĐ.Text.Trim() + "'";
            if (provider.CheckKey(query))
            {
                MessageBox.Show("Mã sản phẩm này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaSP.Focus();
                return;
            }
            //Kiểm tra số lượng hàng trong kho có đủ cung cấp không
            sl = Convert.ToDouble(provider.GetFieldValues("SELECT SoLuong FROM SanPham WHERE maSP = N'" + cbMaSP.SelectedValue + "'"));
            if (Convert.ToDouble(txtSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }

            query = "INSERT INTO ChiTietHoaDon(maHD,maSP,SoLuong,DonGia, GiamGia,ThanhTien) VALUES(N'" + txtMaHĐ.Text.Trim() + "',N'" + cbMaSP.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            provider.RunSQL(query);
            LoadList();
            //Cập nhật lại số lượng của mặt hàng vào bảng Sản phẩm
            slcon = sl - Convert.ToDouble(txtSoLuong.Text);
            query = "UPDATE SanPham SET SoLuong =" + slcon + " WHERE maSP= N'" + cbMaSP.SelectedValue + "'";
            provider.RunSQL(query);
            //Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(provider.GetFieldValues("SELECT TongTien FROM HoaDon WHERE maHD = N'" + txtMaHĐ.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            query = "UPDATE HoaDon SET TongTien =" + Tongmoi + " WHERE maHD = N'" + txtMaHĐ.Text + "'";
            provider.RunSQL(query);
            txtTongTien.Text = Tongmoi.ToString();
            ResetValuesHang();
            btnThem.Enabled = true;
            btnIn.Enabled = true;
            btnXoa.Enabled = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbMaSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            DataProvider provider = new DataProvider();
            if (cbMaSP.Text == "")
            {
                txtTenSP.Text = "";
                txtDonGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT tenSP FROM SanPham WHERE maSP =N'" + cbMaSP.SelectedValue + "'";
            txtTenSP.Text = provider.GetFieldValues(str);
            str = "SELECT gia FROM SanPham WHERE maSP =N'" + cbMaSP.SelectedValue + "'";
            txtDonGia.Text = provider.GetFieldValues(str);
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            DataProvider provider = new DataProvider();
            if (cbMaNV.Text == "")
                txtTenNhanVien.Text = "";
            // Khi chọn Mã nhân viên thì tên nhân viên tự động hiện ra
            str = "Select tenNV from NhanVien where maNV =N'" + cbMaNV.SelectedValue + "'";
            txtTenNhanVien.Text = provider.GetFieldValues(str);
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi số lượng thì thực hiện tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            //Khi thay đổi giảm giá thì tính lại thành tiền
            double tt, sl, dg, gg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(txtGiamGia.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            txtThanhTien.Text = tt.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTimKiem_DropDown(object sender, EventArgs e)
        {
            DataProvider provider = new DataProvider();
            provider.FillCombo("SELECT maHD FROM HoaDon", cbTimKiem, "maHD", "maHD");
            cbTimKiem.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
         
            txtMaHĐ.Text = cbTimKiem.Text;
            LoadInfoHoaDon();
            LoadList();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnIn.Enabled = true;
            cbTimKiem.SelectedIndex = -1;
        }

        private void dtgvQLHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
