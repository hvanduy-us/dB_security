using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LAP4_CaNhan
{
    public partial class Form1 : Form
    {

        String strConnect = "";
        SqlConnection connect = null;
        SqlCommand command;
        SqlDataAdapter adapter = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ShowCaptcha()
        {
            Random rand = new Random();
            int num = rand.Next(6, 8);
            string captcha = "";
            int totl = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    totl++;
                    if (totl == num)
                        break;
                    { }
                }
            } while (true);
            LBCaptCha.Text = captcha;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            strConnect = @"Data Source=.\MSSQLSERVER02;Initial Catalog=QLSV;Integrated Security=True";

            if(connect==null)
            {
                connect = new SqlConnection(strConnect);
            }   
            if(connect.State==ConnectionState.Closed)
            {
                connect.Open();
                //MessageBox.Show("kết nối SQL Server thanh công");
            }

            ShowCaptcha();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void LBAccount_Click(object sender, EventArgs e)
        {

        }

        private void BTExit_Click(object sender, EventArgs e)
        {

            if(connect!=null && connect.State==ConnectionState.Open)
            {
                connect.Close();
            }
            this.Close();
            Application.Exit();
        }

        private void TBPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(CBPassword.Checked)
            {
                TBPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                TBPassWord.UseSystemPasswordChar = true;
            }
        }

        private void BTLogIn_Click(object sender, EventArgs e)
        {

            try
            {
                if(TBCaptCha.Text == LBCaptCha.Text)
                {

                    String account = TBAccount.Text;
                    String passWord = TBPassWord.Text;

                    SHA1 EnCrypto = SHA1.Create();
                    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passWord);
                    byte[] hash = EnCrypto.ComputeHash(inputBytes);


                    String query = "EXEC SP_lOGIN @acc, @pass";
                    command = new SqlCommand(query, connect);

                    command.Parameters.Add(new SqlParameter("@acc", account));
                    command.Parameters.Add(new SqlParameter("@pass", hash));

                    command.ExecuteNonQuery();
                    Form2 f2 = new Form2();
                    f2.account = account;
                    f2.passWord = passWord;
                    f2.strConnect = strConnect;
                    this.Hide();
                    f2.Show();
                }else
                {
                    errorProvider1.SetError(TBCaptCha, "Captcha fail");
                    TBCaptCha.Text = "";
                    ShowCaptcha();
                }
            }
            catch (SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                errorProvider2.SetError(TBAccount, "Account fail");
                errorProvider3.SetError(TBPassWord, "Password fail");
                // MessageBox(error.Message);
            }



        }
    }
}
