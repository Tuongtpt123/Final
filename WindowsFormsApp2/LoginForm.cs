using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp2.Form_Main;

namespace WindowsFormsApp2
{
    public partial class LoginForm: Form
    {
        //SqlConnection ketNoi;
        //SqlDataAdapter boDocGhi;
        //DataSet duLieu;
        //SqlCommand boLenh;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginFormGrbx_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                string chuoiKN = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True";
                using (SqlConnection ketNoi = new SqlConnection(chuoiKN))
                {
                    string lenh = @"
                SELECT UI.user_id, UI.name, UR.role_name 
                FROM USER_INFO UI 
                JOIN USER_ROLE UR ON UI.role_id = UR.role_id
                JOIN LOGIN_INFO LI ON UI.user_id = LI.user_id
                WHERE LI.username = @username AND LI.password = @password";

                    using (SqlCommand cmd = new SqlCommand(lenh, ketNoi))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        ketNoi.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userId = reader["user_id"].ToString();
                                string roleName = reader["role_name"].ToString();
                                string employeeName = reader["name"].ToString();

                                //MessageBox.Show("Bạn đã đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                SessionManager.Instance.Login(userId, username, roleName, employeeName);

                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Sai tài khoản hoặc mật khẩu!" + Environment.NewLine + "Hãy liên hệ với quản lý nếu bạn đã quên mật khảu!", "Không thẻ đăng nhập!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
