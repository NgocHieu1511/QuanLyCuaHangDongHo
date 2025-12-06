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
    public partial class frmThongKe : Form
    {
        public frmThongKe()
        {
            InitializeComponent();
            LoadList();
        }
        void LoadList()
        {
            DataProvider provider = new DataProvider();
            string query = $@"SELECT ngayLap,SUM(TongTien) AS TongTien FROM HoaDon WHERE ngayLap BETWEEN
'{dtpNgayBatDau.Value.ToString("yyyyMMdd")}' AND '{dtpNgayKetThuc.Value.ToString("yyyyMMdd")}' GROUP BY ngayLap";
            dtgvThongKe.DataSource = provider.ExcuteQuery(query);
            dtgvThongKe.Columns[0].HeaderText = "Ngày lập";
            dtgvThongKe.Columns[1].HeaderText = "Tổng tiền";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain f = new frmMain();
            f.ShowDialog();
            this.Close();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            LoadList();


        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
