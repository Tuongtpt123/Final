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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp2
{
    public partial class FrmSupplier : Form
    {
        SqlConnection KetNoi;

        SqlDataAdapter BoDocGhi;

        DataSet DuLieu;
        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            string chuoiKN = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True";
            KetNoi = new SqlConnection(chuoiKN);

            LoadData("SUPPLIER_INFO");

            dataGridView1.Columns["supplier_address"].Width = 320;
            dataGridView1.Columns["supplier_email"].Width = 170;
            dataGridView1.Columns["supplier_id"].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns["supplier_name"].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns["supplier_address"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["supplier_email"].HeaderText = "Email";
            dataGridView1.Columns["supplier_phone"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["supplier_debt"].HeaderText = "Công nợ nhà cung cấp";
            Set1(false);
            textBox7.Text = "0";

            textBox7.Enabled = false;
        }
        private void LoadData(string tableName, string search = "")
        {
            try
            {
                KetNoi.Open();
                string lenh;

                if (string.IsNullOrEmpty(search))
                {
                    lenh = $"SELECT * FROM {tableName}";
                }
                else
                {
                    lenh = $"SELECT * FROM {tableName} WHERE supplier LIKE @search OR supplier_id LIKE @search";
                }

                BoDocGhi = new SqlDataAdapter(lenh, KetNoi);

                if (!string.IsNullOrEmpty(search))
                {
                    BoDocGhi.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");
                }

                DuLieu = new DataSet();
                BoDocGhi.Fill(DuLieu);
                dataGridView1.DataSource = DuLieu.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                KetNoi.Close();
            }
        }
        private void Set2(bool Visible)
        {
            button3.Visible = Visible;
            button4.Visible = Visible;
        }
        private void Set3(bool Visible)
        {
            button2.Visible = Visible;
            button4.Visible = Visible;
        }
        private void Set4(bool Visible)
        {
            button2.Visible = Visible;
            button3.Visible = Visible;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox2.Text = row.Cells["supplier_id"].Value.ToString();
            textBox3.Text = row.Cells["supplier_name"].Value.ToString();
            textBox4.Text = row.Cells["supplier_address"].Value.ToString();
            textBox5.Text = row.Cells["supplier_email"].Value.ToString();
            textBox6.Text = row.Cells["supplier_phone"].Value.ToString();
            textBox7.Text = row.Cells["supplier_debt"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox1.Text.Trim();
                string tableName = "SUPPLIER_INFO";

                LoadData(tableName, searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox1.Text.Trim();
                string tableName = "SUPPLIER_INFO";

                LoadData(tableName, searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private string action = "";
        private void Set1(bool Visible)
        {
            groupBox1.Visible = Visible;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            action = "add";
            groupBox1.Text = button2.Text + " Nhà cung cấp";
            Set1(true);
            Set2(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            action = "edit";
            groupBox1.Text = button2.Text + " Nhà cung cấp";
            Set1(true);
            textBox2.Enabled = false;
            Set3(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            action = "edit";
            groupBox1.Text = button2.Text + " Nhà cung cấp";
            Set1(true);
            Set4(false);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = KetNoi;
                    if (action == "add")
                    {
                        cmd.CommandText = "insert into SUPPLIER_INFO (supplier_id, supplier_name, supplier_address, supplier_email, supplier_phone, supplier_debt) values(@Ma, @Ten, @address, @email, @phone, @dept)";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.Parameters.AddWithValue("@address", textBox4.Text);
                        cmd.Parameters.AddWithValue("@email", textBox5.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox6.Text);
                        cmd.Parameters.AddWithValue("@dept", textBox7.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else if (action == "edit")
                    {
                        cmd.CommandText = "update SUPPLIER_INFO set supplier_id =@Ma, supplier_name =@Ten, supplier_address= @address, supplier_email= @email, supplier_phone=@ phone, supplier_debt =@dept where customer_id =@Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.Parameters.AddWithValue("@address", textBox4.Text);
                        cmd.Parameters.AddWithValue("@email", textBox5.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox6.Text);
                        cmd.Parameters.AddWithValue("@dept", textBox7.Text);
                        cmd.Parameters.Clear();
                    }
                    else if (action == "delete")
                    {
                        cmd.CommandText = "delete from SUPPLIER_INFO where supplier_id =@Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.ExecuteNonQuery();
                    }
                    KetNoi.Close();
                    MessageBox.Show("Thực hiện thành công!");
                    LoadData("SUPPLIER_INFO");
                    Set1(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
      
            DialogResult result = MessageBox.Show("Bạn muốn xác nhận hủy!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadData("SUPPLIER_INFO");
                groupBox1.Visible = false;
                Set2(true);
                button2.Visible = true;
            
        }
    }
    }
}
