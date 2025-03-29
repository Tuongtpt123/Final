using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FormUsers : Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";

        public FormUsers()
        {
            InitializeComponent();
            LoadRoles();
            loadData();
        }

        private void uSER_INFOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.uSER_INFOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.projectDBDataSet3);

        }

        private void loadData()
        {
            string query = @"SELECT 
                            u.user_id, 
                            u.name, 
                            u.email, 
                            u.address, 
                            u.birth, 
                            u.phone, 
                            u.role_id, 
                            r.role_name 
                            FROM USER_INFO u 
                            JOIN USER_ROLE r ON u.role_id = r.role_id 
                            ORDER BY u.user_id, u.name";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    userInfoDgv.DataSource = dt;

                    //Tạo bảng dữ liệu
                    userInfoDgv.Columns["user_id"].HeaderText = "Mã NV";
                    userInfoDgv.Columns["name"].HeaderText = "Họ tên";
                    userInfoDgv.Columns["email"].HeaderText = "Email";
                    userInfoDgv.Columns["address"].HeaderText = "Địa chỉ";
                    userInfoDgv.Columns["birth"].HeaderText = "Ngày sinh";
                    userInfoDgv.Columns["phone"].HeaderText = "Số điện thoại";
                    userInfoDgv.Columns["role_id"].HeaderText = "Mã chức vụ";
                    userInfoDgv.Columns["role_name"].HeaderText = "Chức vụ";

                    //Ẩn cột role_id
                    userInfoDgv.Columns["role_id"].Visible = false;

                    //Chỉnh độ rộng cột
                    userInfoDgv.Columns["user_id"].Width = 80;
                    userInfoDgv.Columns["name"].Width = 200;
                    userInfoDgv.Columns["email"].Width = 150;
                    userInfoDgv.Columns["address"].Width = 200;
                    userInfoDgv.Columns["birth"].Width = 100;
                    userInfoDgv.Columns["phone"].Width = 100;
                    userInfoDgv.Columns["role_name"].Width = 150;

                    //Định dạng ngày sinh
                    userInfoDgv.Columns["birth"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    //Canh giữa dữ liệu
                    userInfoDgv.Columns["user_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void FormUsers_Load(object sender, EventArgs e)
        {
            

        }

        //Load danh sách chức vụ vào ComboBox
        private void LoadRoles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT role_id, role_name FROM USER_ROLE", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                roleCbx.DisplayMember = "role_name";
                roleCbx.ValueMember = "role_id";
                roleCbx.DataSource = dt;
            }
        }

        private void uSER_INFODataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void uSER_INFODataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (userInfoDgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = userInfoDgv.SelectedRows[0];
                user_idTextBox.Text = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                nameTextBox.Text = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                emailTextBox.Text = row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                addressTextBox.Text = row.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                //Nếu ngày sinh không null thì hiển thị
                if (row.Cells["dataGridViewTextBoxColumn5"].Value != DBNull.Value)
                {
                    birthDateTimePicker.Value = Convert.ToDateTime(row.Cells["dataGridViewTextBoxColumn5"].Value);
                }

                phoneTextBox.Text = row.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
                if (row.Cells["dataGridViewTextBoxColumn7"].Value != DBNull.Value)
                {
                    string selectedRoleId = row.Cells["dataGridViewTextBoxColumn7"].Value.ToString();
                    roleCbx.SelectedValue = selectedRoleId;
                }
                //Lấy thông tin đăng nhập
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM LOGIN_INFO WHERE user_id = @user_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usernameTextBox.Text = reader["username"].ToString();
                        passwordTextBox.Text = reader["password"].ToString();
                    }
                    else
                    {
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                }
            }
            passwordConfirmTextBox.Text = "";
        }

        //Hàm kiểm tra ID người dùng
        private bool IsUserIdExists(string userId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM USER_INFO WHERE user_id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Trả về true nếu đã tồn tại
            }
        }

        //Kiếm tra username đã tồn tại chưa
        private bool IsUsernameExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM LOGIN_INFO WHERE username = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Trả về true nếu đã tồn tại
            }
        }

        //Thêm thông tin người dùng
        private void button4_Click(object sender, EventArgs e)
        {
            if (user_idTextBox.Text == "" || nameTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ít nhất mã và họ tên người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra user_id đã tồn tại chưa
            if (IsUserIdExists(user_idTextBox.Text.Trim()))
            {
                MessageBox.Show("Người dùng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra độ dài mã nhân viên
            if (user_idTextBox.Text.Length < 4 || user_idTextBox.Text.Length > 10)
            {
                MessageBox.Show("Mã nhân viên nên được đặt từ 4 đến 10 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra độ dài tên người dùng
            if (nameTextBox.Text.Length > 50)
            {
                MessageBox.Show("Tên người dùng quá dài! (phải nhỏ hơn 50 ký tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra email hợp lệ
            if (emailTextBox.Text != "" && !emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra số điện thoại hợp lệ
            if (phoneTextBox.Text != "" && (phoneTextBox.Text.Length < 10 || phoneTextBox.Text.Length > 11))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra username đã tồn tại chưa
            if (usernameTextBox.Text != "" && IsUsernameExists(usernameTextBox.Text.Trim()))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra độ dài username và password
            if (usernameTextBox.Text.Length < 6 || usernameTextBox.Text.Length > 20)
            {
                MessageBox.Show("Tên đăng nhập nên được đặt từ 6 đến 20 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passwordTextBox.Text.Length < 6 || passwordTextBox.Text.Length > 20)
            {
                MessageBox.Show("Mật khẩu nên được đặt từ 6 đến 20 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra mật khẩu
            if (passwordTextBox.Text != passwordConfirmTextBox.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO USER_INFO (user_id, name, email, address, birth, phone, role_id) VALUES (@user_id, @name, @email, @address, @birth, @phone, @role_id)", conn, transaction);
                        cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@name", nameTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@birth", birthDateTimePicker.Value);
                        cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text.Trim());
                        cmd.Parameters.AddWithValue("@role_id", roleCbx.SelectedValue);
                        cmd.ExecuteNonQuery();

                        //Thêm thông tin đăng nhập
                        if (user_idTextBox.Text != "" && passwordTextBox.Text != "" && passwordConfirmTextBox.Text != "")
                        {
                            cmd = new SqlCommand("INSERT INTO LOGIN_INFO (username, password, user_id) VALUES (@username, @password, @user_id)", conn, transaction);
                            cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                            cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                            cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                            cmd.ExecuteNonQuery();
                        }
                        //Nếu chưa nhập thông tin đăng nhập: lấy user_id làm username và password
                        else
                        {
                            cmd = new SqlCommand("INSERT INTO LOGIN_INFO (username, password, user_id) VALUES (@username, @password, @user_id)", conn, transaction);
                            cmd.Parameters.AddWithValue("@username", user_idTextBox.Text);
                            cmd.Parameters.AddWithValue("@password", user_idTextBox.Text);
                            cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                        }

                        transaction.Commit();
                        MessageBox.Show("Thêm thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        loadData();

                        //Reset các giá trị textbox
                        resetValue();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi thêm thông tin người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Khi ấn Hiện mật khẩu
        private void label5_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.PasswordChar == '*')
            {
                passwordTextBox.PasswordChar = '\0';
                passwordConfirmTextBox.PasswordChar = '\0';
            }
            else
            {
                passwordTextBox.PasswordChar = '*';
                passwordConfirmTextBox.PasswordChar = '*';
            }
        }

        //Cập nhật thông tin người dùng
        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (user_idTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng chọn người dùng cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra user_id đã tồn tại chưa
            if (!IsUserIdExists(user_idTextBox.Text.Trim()))
            {
                MessageBox.Show("Người dùng không tồn tại!" + Environment.NewLine + "Lưu ý: mã nhân viên không thể bị thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra độ dài tên người dùng
            if (nameTextBox.Text.Length > 50)
            {
                MessageBox.Show("Tên người dùng quá dài! (phải nhỏ hơn 50 ký tự)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra email hợp lệ
            if (emailTextBox.Text != "" && !emailTextBox.Text.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra số điện thoại hợp lệ
            if (phoneTextBox.Text != "" && (phoneTextBox.Text.Length < 10 || phoneTextBox.Text.Length > 11))
            {
                MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra độ dài username và password
            if (usernameTextBox.Text.Length < 6 || usernameTextBox.Text.Length > 20)
            {
                MessageBox.Show("Tên đăng nhập nên được đặt từ 6 đến 20 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (passwordTextBox.Text.Length < 6 || passwordTextBox.Text.Length > 20)
            {
                MessageBox.Show("Mật khẩu nên được đặt từ 6 đến 20 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra mật khẩu có khớp không
            if (passwordTextBox.Text != passwordConfirmTextBox.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật thông tin người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE USER_INFO SET name = @name, email = @email, address = @address, birth = @birth, phone = @phone, role_id = @role_id WHERE user_id = @user_id", conn, transaction);
                        cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                        cmd.Parameters.AddWithValue("@name", nameTextBox.Text);
                        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                        cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                        cmd.Parameters.AddWithValue("@birth", birthDateTimePicker.Value);
                        cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                        cmd.Parameters.AddWithValue("@role_id", roleCbx.SelectedValue);
                        cmd.ExecuteNonQuery();
                        //Cập nhật thông tin đăng nhập
                        if (user_idTextBox.Text != "" && passwordTextBox.Text != "" && passwordConfirmTextBox.Text != "")
                        {
                            cmd = new SqlCommand("UPDATE LOGIN_INFO SET username = @username, password = @password WHERE user_id = @user_id", conn, transaction);
                            cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                            cmd.Parameters.AddWithValue("@password", passwordTextBox.Text);
                            cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Cập nhật thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        loadData();

                        //Reset các giá trị textbox
                        resetValue();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật thông tin người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Cập nhật các giá trị textbox sau khi thao tác
        private void resetValue()
        {
            user_idTextBox.Text = "";
            nameTextBox.Text = "";
            emailTextBox.Text = "";
            addressTextBox.Text = "";
            birthDateTimePicker.Value = DateTime.Now;
            phoneTextBox.Text = "";
            roleCbx.SelectedIndex = 0;
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
            passwordConfirmTextBox.Text = "";
        }

        //Xóa thông tin người dùng, bao gồm cả thông tin đăng nhập
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (user_idTextBox.Text == "")
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin người dùng này?" + Environment.NewLine +
                                                  "Thông tin đăng nhập cũng sẽ bị xóa.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();
                    try
                    {
                        //Xóa thông tin đăng nhập
                        SqlCommand cmd = new SqlCommand("DELETE FROM LOGIN_INFO WHERE user_id = @user_id", conn, transaction);
                        cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM USER_INFO WHERE user_id = @user_id", conn, transaction);
                        cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                        MessageBox.Show("Xóa thông tin người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        loadData();

                        //Reset các giá trị textbox
                        resetValue();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi xóa thông tin người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                return;
            }
        }
        //Tìm kiếm người dùng theo mã hoặc tên
        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = searchTxt.Text;
            if (searchValue == "")
            {
                MessageBox.Show("Vui lòng nhập mã thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Hiển thị thông tin người dùng theo mã hoặc tên, bao gồm chúc vụ
                    string query = @"SELECT 
                                    u.user_id, 
                                    u.name, 
                                    u.email, 
                                    u.address, 
                                    u.birth, 
                                    u.phone, 
                                    u.role_id, 
                                    r.role_name 
                                    FROM USER_INFO u 
                                    JOIN USER_ROLE r ON u.role_id = r.role_id 
                                    WHERE u.user_id LIKE @searchValue OR u.name LIKE @searchValue";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@searchValue", "%" + searchValue + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Không tìm thấy thông tin người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    userInfoDgv.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm thông tin người dùng: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Reset lại dữ liệu
        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userInfoDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void userInfoDgv_SelectionChanged(object sender, EventArgs e)
        {
            //Hiện thông tin người dùng khi click vào dòng
            if (userInfoDgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = userInfoDgv.SelectedRows[0];
                user_idTextBox.Text = row.Cells["user_id"].Value.ToString();
                nameTextBox.Text = row.Cells["name"].Value.ToString();
                emailTextBox.Text = row.Cells["email"].Value.ToString();
                addressTextBox.Text = row.Cells["address"].Value.ToString();
                //Nếu ngày sinh không null thì hiển thị
                if (row.Cells["birth"].Value != DBNull.Value)
                {
                    birthDateTimePicker.Value = Convert.ToDateTime(row.Cells["birth"].Value);
                }
                phoneTextBox.Text = row.Cells["phone"].Value.ToString();
                if (row.Cells["role_id"].Value != DBNull.Value)
                {
                    string selectedRoleId = row.Cells["role_id"].Value.ToString();
                    roleCbx.SelectedValue = selectedRoleId;
                }
                //Lấy thông tin đăng nhập
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //Hiện mật khẩu mỗi khi chọn người dùng
                    passwordTextBox.PasswordChar = '*';
                    passwordConfirmTextBox.PasswordChar = '*';

                    conn.Open();
                    string query = "SELECT * FROM LOGIN_INFO WHERE user_id = @user_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user_id", user_idTextBox.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usernameTextBox.Text = reader["username"].ToString();
                        passwordTextBox.Text = reader["password"].ToString();
                    }
                    else
                    {
                        usernameTextBox.Text = "";
                        passwordTextBox.Text = "";
                    }
                }
            }
        }
    }
}
