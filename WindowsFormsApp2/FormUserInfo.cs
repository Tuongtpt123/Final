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
using static WindowsFormsApp2.Form_Main;

namespace WindowsFormsApp2
{
    public partial class FormUserInfo: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";
        DataTable userInfo = new DataTable();
        public FormUserInfo()
        {
            InitializeComponent();
        }
        private void FormUserInfo_Load(object sender, EventArgs e)
        {
            string query = @"SELECT 
                            u.user_id, 
                            u.name, 
                            ISNULL(u.email, N'Không có email') AS email, 
                            ISNULL(u.address, N'Chưa cập nhật') AS address, 
                            ISNULL(u.birth, '01-01-1900') AS birth, 
                            ISNULL(u.phone, N'Không có số điện thoại') AS phone, 
                            ISNULL(r.role_name, N'Chưa có chức vụ') AS role_name 
                            FROM USER_INFO u 
                            JOIN USER_ROLE r on u.role_id = r.role_id 
                            WHERE user_id = @user_id 
                            ";
            try
            {
                usernamelbl.Text = "Xin chào! " + SessionManager.Instance.Username;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();
                    SqlCommand command = new SqlCommand(query, connection, transaction);
                    command.Parameters.AddWithValue("@user_id", SessionManager.Instance.UserId);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(userInfo);
                }
                if (userInfo.Rows.Count > 0)
                {
                    DataRow row = userInfo.Rows[0];
                    useridTxt.Text = row["user_id"].ToString();
                    nameTxt.Text = row["name"].ToString();
                    emailTxt.Text = row["email"].ToString();
                    addressTxt.Text = row["address"].ToString();
                    birthTxt.Text = row["birth"].ToString();
                    phoneTxt.Text = row["phone"].ToString();
                    rolenameTxt.Text = row["role_name"].ToString();

                    //địng dạng dd/MM/yyyy cho ngày sinh
                    DateTime birth = Convert.ToDateTime(birthTxt.Text);
                    birthTxt.Text = birth.ToString("dd/MM/yyyy");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin người dùng");
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi tải thông tin người dùng", "Thông báo!");
                this.Close();
            }
        }

        private void changePasswordBtn_Click(object sender, EventArgs e)
        {
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.ShowDialog();
        }
    }
}
