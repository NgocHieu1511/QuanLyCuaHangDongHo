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
            //string query = "SELECT * FROM ChiTietHoaDon";
            string query = "SELECT a.maSP, b.tenSP, a.soLuong, b.gia, a.giamGia,a.ThanhTien " +
             "FROM ChiTietHoaDon AS a, SanPham AS b WHERE a.maHD = N'" + txtMaHD.Text + "' AND a.maSP=b.maSP";
            DataProvider provider = new DataProvider();
            dtgvQLHoaDon.DataSource = provider.ExcuteQuery(query);


            dtgvQLHoaDon.Columns[0].HeaderText = "Mã sản phẩm";
            dtgvQLHoaDon.Columns[1].HeaderText = "Tên sản phẩm";
            dtgvQLHoaDon.Columns[2].HeaderText = "Số lượng";
            dtgvQLHoaDon.Columns[3].HeaderText = "Đơn giá";
            dtgvQLHoaDon.Columns[4].HeaderText = "Giảm giá %";
            dtgvQLHoaDon.Columns[5].HeaderText = "Thành Tiền";
            //dtgvQLHoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            //dtgvQLHoaDon.Columns[1].HeaderText = "Mã sản phẩm";
            //dtgvQLHoaDon.Columns[2].HeaderText = "Số lượng";
            //dtgvQLHoaDon.Columns[3].HeaderText = "Đơn giá";
            //dtgvQLHoaDon.Columns[].HeaderText = "Giarm giá";
            //dtgvQLHoaDon.Columns[5].HeaderText = "Thành Tiền";

            dtgvQLHoaDon.AllowUserToAddRows = false;
            dtgvQLHoaDon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        void ResetValue()
        {
            txtMaHD.Text = "";
            dtpNgayBan.Value = DateTime.Now;
            cbMaNV.Text = "";
            txtTongTien.Text = "0";

            cbMaSP.Text = "";
            txtSoLuong.Text = "";
            txtGiamGia.Text = "0";

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
            query = "SELECT maHD FROM HoaDon WHERE maHD = N'" + txtMaHD.Text + "'";
            txtMaHD.Text = provider.GetFieldValues(query);

            query = "SELECT maNV FROM HoaDon WHERE maHD = N'" + txtMaHD.Text + "'";
            cbMaNV.SelectedValue = provider.GetFieldValues(query);
            query = "SELECT ngaylap FROM HoaDon WHERE maHD = N'" + txtMaHD.Text + "'";
            dtpNgayBan.Value = DateTime.Parse(provider.GetFieldValues(query));
            query = "SELECT TongTien FROM HoaDon WHERE maHD = N'" + txtMaHD.Text + "'";

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
            txtMaHD.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTenSP.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtTongTien.ReadOnly = true;

            txtGiamGia.Text = "0";
            txtTongTien.Text = "0";
            dtpNgayBan.Value = DateTime.Now;
            provider.FillCombo("SELECT maNV, tenNV FROM NhanVien", cbMaNV, "maNV", "maNV");
            cbMaNV.SelectedIndex = -1;
            provider.FillCombo("SELECT maSP, tenSP FROM SanPham", cbMaSP, "maSP", "maSP");
            cbMaSP.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHD.Text != "")
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

            txtMaHD.Text = provider.CreateKey("HD");
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
            query = "SELECT maHD FROM HoaDon WHERE maHD=N'" + txtMaHD.Text.Trim() + "'";
            if (!provider.CheckKey(query))
            {

                query = "INSERT INTO HoaDon (maHD, ngayLap, maNV, TongTien) VALUES(N'"
         + txtMaHD.Text.Trim() + "', '"
         + dtpNgayBan.Value + "', N'"
         + cbMaNV.SelectedValue + "', "
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
                cbMaSP.SelectedValue + "' AND maHD = N'" + txtMaHD.Text.Trim() + "'";
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

            query = "INSERT INTO ChiTietHoaDon(maHD,maSP,soLuong,DonGia, giamGia,ThanhTien) VALUES(N'" + txtMaHD.Text.Trim() + "',N'" + cbMaSP.SelectedValue + "'," + txtSoLuong.Text + "," + txtDonGia.Text + "," + txtGiamGia.Text + "," + txtThanhTien.Text + ")";
            provider.RunSQL(query);
            LoadList();
            //Cập nhật lại số lượng của mặt hàng vào bảng Sản phẩm
            slcon = sl - Convert.ToDouble(txtSoLuong.Text);
            query = "UPDATE SanPham SET SoLuong =" + slcon + " WHERE maSP= N'" + cbMaSP.SelectedValue + "'";
            provider.RunSQL(query);
            //Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Convert.ToDouble(provider.GetFieldValues("SELECT TongTien FROM HoaDon WHERE maHD = N'" + txtMaHD.Text + "'"));
            Tongmoi = tong + Convert.ToDouble(txtThanhTien.Text);
            query = "UPDATE HoaDon SET TongTien =" + Tongmoi + " WHERE maHD = N'" + txtMaHD.Text + "'";
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

            txtMaHD.Text = cbTimKiem.Text;
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

        private void dtgvQLHoaDon_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dtgvQLHoaDon.CurrentRow.Cells["maHD"].Value.ToString();
                frmQLHoaDon frm = new frmQLHoaDon();
                frm.txtMaHD.Text = mahd;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            DataProvider provider = new DataProvider();
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop B.A.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đan Phượng - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.maHD, a.ngayLap, a.TongTien, c.tenNV FROM HoaDon AS a, NhanVien AS c WHERE a.maHD = N'" + txtMaHD.Text + "' AND a.maNV = c.maNV";
            tblThongtinHD = provider.GetDataTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();

            //Lấy thông tin các mặt hàng
            sql = "SELECT b.tenSP, a.soLuong, b.gia, a.giamGia, a.ThanhTien " +
                  "FROM ChiTietHoaDon AS a , SanPham AS b WHERE a.maHD = N'" +
                  txtMaHD.Text + "' AND a.maSP = b.maSP";
            tblThongtinHang = provider.GetDataTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên sản phẩm";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][3];

            exSheet.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            double sl, slcon, slxoa;
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "SELECT maSP,soLuong FROM ChiTietHoaDon WHERE maHD = N'" + txtMaHD.Text + "'";
                DataProvider provider = new DataProvider();
                DataTable tblSanPham = provider.GetDataTable(query);
                for (int hang = 0; hang <= tblSanPham.Rows.Count - 1; hang++)
                {
                    // Cập nhật lại số lượng cho các mặt hàng
                    sl = Convert.ToDouble(provider.GetFieldValues("SELECT soLuong FROM SanPham WHERE maSP = N'" + tblSanPham.Rows[hang][0].ToString() + "'"));
                    slxoa = Convert.ToDouble(tblSanPham.Rows[hang][1].ToString());
                    slcon = sl + slxoa;
                    query = "UPDATE SanPham SET soLuong =" + slcon + " WHERE maSP= N'" + tblSanPham.Rows[hang][0].ToString() + "'";
                    provider.RunSQL(query);
                }

                //Xóa chi tiết hóa đơn
                query = "DELETE ChiTietHoaDon WHERE maHD=N'" + txtMaHD.Text + "'";
                provider.RunSQL(query);

                //Xóa hóa đơn
                query = "DELETE HoaDon WHERE maHD=N'" + txtMaHD.Text + "'";
                provider.RunSQL(query);
                ResetValue();
                LoadList();
                btnXoa.Enabled = false;
                btnIn.Enabled = false;
            }
        }
    }
}
