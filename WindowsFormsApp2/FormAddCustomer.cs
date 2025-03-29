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

namespace WindowsFormsApp2
{
    public partial class FormAddCustomer: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";

        public FormAddCustomer(string customerId)
        {
            InitializeComponent();
            customerIdTxt.Text = customerId; //Tự động điền ID từ OrderForm
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Kiểm tra & thêm khách hàng mới
        private void saveCustomerBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerIdTxt.Text) || string.IsNullOrWhiteSpace(customerIdTxt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (customerIdTxt.Text.Length != 10)
            {
                MessageBox.Show("SĐT khách hàng không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (customerNameTxt.Text.Length > 49)
            {
                MessageBox.Show("Tên khách hàng quá dài!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                //Kiểm tra ID khách hàng có tồn tại không
                string checkQuery = "SELECT COUNT(*) FROM CUSTOMER_INFO WHERE customer_id = @customer_id";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@customer_id", customerIdTxt.Text);
                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    MessageBox.Show("ID khách hàng đã tồn tại. Vui lòng nhập ID khác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Thêm khách hàng mới vào CSDL
                string insertQuery = "INSERT INTO CUSTOMER_INFO (customer_id, customer_name) VALUES (@customer_id, @customer_name)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@customer_id", customerIdTxt.Text.Trim());
                insertCmd.Parameters.AddWithValue("@customer_name", customerNameTxt.Text.Trim());
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); //Đóng form sau khi thêm thành công
            }
        }
    }
}
