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
    }
    }

