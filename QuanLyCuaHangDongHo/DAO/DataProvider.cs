
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHangDongHo.DAO
{
    internal class DataProvider
    {
        private string connectionSTR =
    @"Data Source=DESKTOP-MVLKNT7\SQLEXPRESS;Initial Catalog=QuanLyCuaHangDongHo;Integrated Security=True;Encrypt=False";

        public DataTable ExcuteQuery(string query, Object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR)) {


                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }


                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }

            return data;
        }
    
    public bool CheckKey(string query)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);


            SqlDataAdapter dap = new SqlDataAdapter(query,connection);
            DataTable table = new DataTable();
            dap.Fill(table);
            if (table.Rows.Count > 0)
                return true;
            else return false;
        }
        //Hàm thực hiện câu lệnh SQL
        public void RunSQL(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                try
                {
                    cmd.ExecuteNonQuery(); // ✔ chạy lệnh SQL không trả về dữ liệu
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public DataTable GetDataTable(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(table);
            }

            return table;
        }
        public string GetFieldValues(string query)
        {
            string ma = "";
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            connection.Close();
            return ma;
        }
        public void FillCombo(string query, ComboBox cbo, string ma, string ten)
        {
            SqlConnection connection = new SqlConnection(connectionSTR);
            connection.Open();
            SqlDataAdapter dap = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
            connection.Close();
        }



    }
}
    
