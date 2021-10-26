using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Linq;

namespace LAP4_CaNhan
{
    public partial class Form2 : Form
    {
        public String strConnect = "";
        public String account = "";
        public String passWord = "";
        SqlConnection connect = null;
        SqlCommand command;
        SqlDataAdapter adapter = null;
        DataTable dt;
        String key = "18120341";
        public Form2()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            connect.Close();
            this.Close();
            Application.Exit();

        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            strConnect = @"Data Source=.\MSSQLSERVER02;Initial Catalog=QLSV;Integrated Security=True";

            if (connect == null)
            {
                connect = new SqlConnection(strConnect); 
            }
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                //MessageBox.Show("kết nối SQL Server thanh công");
            }
            String query = @"EXEC SP_SEL_NHANVIEN";
            command = new SqlCommand(query, connect);

            command.ExecuteNonQuery();

            adapter = new SqlDataAdapter(command);
            dt = new DataTable();
            dt.Clear();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {

                Aes myAes = Aes.Create();
                String key = "18120341";
                SHA256 mySHA256 = SHA256Managed.Create();
                myAes.Key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(key));
                myAes.IV = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };


                String strLuong = dr["LUONG"].ToString();
                byte[] bluong = StringToByteArray(strLuong);
                string roundtrip = DecryptStringFromBytes_Aes(bluong, myAes.Key, myAes.IV);
  
                dr["LUONG"] = roundtrip;
            }


            DGVNhanvien.DataSource = dt;

            DGVNhanvien.Columns["MANV"].Width = 154;
            DGVNhanvien.Columns["HOTEN"].Width = 175;
            DGVNhanvien.Columns["EMAIL"].Width = 175;
            DGVNhanvien.Columns["LUONG"].Width = 155;

        }

        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        private void BTThem_Click(object sender, EventArgs e)
        {
            try
            {
                TBMaNV.Text = "";
                TBEmail.Text = "";
                TBTenDN.Text = "";
                TBHoten.Text = "";
                TBLuong.Text = "";
                TBMatkhau.Text = "";

            }
            catch (SqlException error)

            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\nThêm sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void BTXoa_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 f3 = new Form3();
                f3.MaNV = TBMaNV.Text;
                f3.strConnect = strConnect;
                this.Hide();
                f3.ShowDialog();

            }
            catch (SqlException error)

            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\nThêm sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void BTGhi_Click(object sender, EventArgs e)
        {

            try
            {
                SHA1 EnCrypto = SHA1.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(TBMatkhau.Text);
                byte[] matKhau = EnCrypto.ComputeHash(inputBytes);


                Aes myAes = Aes.Create();
                String key = "18120341";
                SHA256 mySHA256 = SHA256Managed.Create();
                myAes.Key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(key));
                myAes.IV = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes_Aes(TBLuong.Text, myAes.Key, myAes.IV);



                String query = @"EXEC SP_INS_ENCRYPT_NHANVIEN @MaNV, @Hoten, @Email , @Luong , @TenDN, @Matkhau";
                command = new SqlCommand(query, connect);

                command.Parameters.Add(new SqlParameter("@MaNV", TBMaNV.Text));
                command.Parameters.Add(new SqlParameter("@Hoten", TBHoten.Text));
                command.Parameters.Add(new SqlParameter("@Email", TBEmail.Text));
                command.Parameters.Add(new SqlParameter("@Luong", encrypted));
                command.Parameters.Add(new SqlParameter("@TenDN", TBTenDN.Text));
                command.Parameters.Add(new SqlParameter("@Matkhau", matKhau));

                command.ExecuteNonQuery();
                Form2 f2t = new Form2();
                f2t.strConnect = strConnect;
                this.Close();
                f2t.Show();
                //DGVNhanvien.Refresh();
            }
            catch (SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\n Ghi/ Lưu sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void BTSua_Click(object sender, EventArgs e)
        {
            try
            {
                SHA1 EnCrypto = SHA1.Create();
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(TBMatkhau.Text);
                byte[] matKhau = EnCrypto.ComputeHash(inputBytes);

                Aes myAes = Aes.Create();
                String key = "18120341";
                SHA256 mySHA256 = SHA256Managed.Create();
                myAes.Key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(key));
                myAes.IV = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

                // Encrypt the string to an array of bytes.
                byte[] luong = EncryptStringToBytes_Aes(TBLuong.Text, myAes.Key, myAes.IV);

                int temp = 0;
                if(TBMatkhau.Text != "#######")
                {
                    temp = 1;
                }
                String query = @"EXEC SP_UPDATE_NHANVIEN @MaNV, @HoTen, @Email, @Luong, @TenDN, @Matkhau, @temp";
                command = new SqlCommand(query, connect);

                command.Parameters.Add(new SqlParameter("@MaNV", TBMaNV.Text));
                command.Parameters.Add(new SqlParameter("@HoTen", TBHoten.Text));
                command.Parameters.Add(new SqlParameter("@Email", TBEmail.Text));
                command.Parameters.Add(new SqlParameter("@Luong", luong));
                command.Parameters.Add(new SqlParameter("@TenDN", TBTenDN.Text));
                command.Parameters.Add(new SqlParameter("@Matkhau", matKhau));
                command.Parameters.Add(new SqlParameter("@temp", temp));

                command.ExecuteNonQuery();

                Form2 f2t = new Form2();
                f2t.strConnect = strConnect;
                this.Close();
                f2t.Show();
            }
            catch (SqlException error)
            {
                string errorStr = error.ToString();
                string[] arrStr0 = errorStr.Split(':');
                string[] arrStr = arrStr0[1].Split('\n');
                MessageBox.Show(arrStr[0].ToString() + "\n Sửa sinh viên không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTKhong_Click(object sender, EventArgs e)
        {
            connect.Close();
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();

        }

        private void DGVNhanvien_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow row = DGVNhanvien.Rows[rowIndex];
                TBMaNV.Text = row.Cells[0].Value.ToString();
                TBHoten.Text = row.Cells[1].Value.ToString();
                TBEmail.Text = row.Cells[2].Value.ToString();
                TBLuong.Text = row.Cells[3].Value.ToString();
                TBMatkhau.Text = "#######";

                String query = "select TENDN from NHANVIEN where MANV = @manv";
                command = new SqlCommand(query, connect);
                command.Parameters.Add(new SqlParameter("@manv", TBMaNV.Text));


                TBTenDN.Text = (String)command.ExecuteScalar();

            }
        }

        private void DGVNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
