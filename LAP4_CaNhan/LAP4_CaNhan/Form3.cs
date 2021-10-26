using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAP4_CaNhan
{
    public partial class Form3 : Form
    {
        public String strConnect;
        public String MaNV;
        SqlConnection connect;
        SqlCommand command;

        public Form3()
        {
            InitializeComponent();
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            if (connect == null)
            {
                connect = new SqlConnection(strConnect);
            }
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                //MessageBox.Show("kết nối SQL Server thanh công");
            }

        }

        private void BTXoa_Click(object sender, EventArgs e)
        {
            String query = @"EXEC SP_DEL_NHANVIEN @MaNV";
            command = new SqlCommand(query, connect);
            command.Parameters.Add(new SqlParameter("@MaNV", MaNV));

            command.ExecuteNonQuery();
            connect.Close();
            Form2 f2 = new Form2();
            f2.strConnect = strConnect;
            f2.Show();
            this.Close();

        }

        private void BTHuy_Click(object sender, EventArgs e)
        {
            connect.Close();
            this.Close();

        }
    }
}
