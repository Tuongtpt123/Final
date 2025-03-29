using System;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using static WindowsFormsApp2.Form_Main;

namespace WindowsFormsApp2
{
    public partial class FormChangePassword : Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";

        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void saveChangeBtn_Click(object sender, EventArgs e)
        {
            string username = SessionManager.Instance.Username;
            string currentPassword = currentPasstxt.Text.Trim();
            string newPassword = newPasstxt.Text.Trim();

            if (currentPasstxt.Text == "" || newPasstxt.Text == "" || confirmNewPasstxt.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo!");
                return;
            }

            if (newPasstxt.Text != confirmNewPasstxt.Text)
            {
                MessageBox.Show("Mật khẩu mới không khớp", "Thông báo!");
                return;
            }

            if (currentPassword == newPassword)
            {
                MessageBox.Show("Mật khẩu mới phải khác mật khẩu hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Kiểm tra mật khẩu hiện tại
                string queryCheck = "SELECT COUNT(*) FROM LOGIN_INFO WHERE username = @username AND password = @password";
                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn))
                {
                    cmdCheck.Parameters.AddWithValue("@username", username);
                    cmdCheck.Parameters.AddWithValue("@password", currentPassword);

                    int count = (int)cmdCheck.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Cập nhật mật khẩu mới
                DialogResult result = MessageBox.Show("Xác nhận thay đổi mật khẩu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string queryUpdate = "UPDATE LOGIN_INFO SET password = @newPassword WHERE username = @username";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                    {
                        cmdUpdate.Parameters.AddWithValue("@username", username);
                        cmdUpdate.Parameters.AddWithValue("@newPassword", newPassword);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công!" + Environment.NewLine + "Tự động thoát sau 3s", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Thoát form sau 3 giây
                            timer1_Tick(3);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật thất bại, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }


        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            notilbl.Text = "Xin chào! " + SessionManager.Instance.Username;
        }

        //Hiển thị mật khẩu
        private void label5_Click(object sender, EventArgs e)
        {
            if (currentPasstxt.PasswordChar == '*')
            {
                currentPasstxt.PasswordChar = '\0';
                newPasstxt.PasswordChar = '\0';
                confirmNewPasstxt.PasswordChar = '\0';
            }
            else
            {
                currentPasstxt.PasswordChar = '*';
                newPasstxt.PasswordChar = '*';
                confirmNewPasstxt.PasswordChar = '*';
            }

        }
        //Hàm đếm ngược thời gian
        private int timer1_Tick(int n)
        {
            if (n > 0)
            {
                timer1_Tick(n - 1);
            }
            Thread.Sleep(1000);
            return n;
        }
    }
}
