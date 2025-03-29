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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp2
{
    public partial class FrmCustomer : Form
    {
        SqlConnection KetNoi;

        SqlDataAdapter BoDocGhi;

        DataSet DuLieu;
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            string chuoiKN = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True";
            KetNoi = new SqlConnection(chuoiKN);

            LoadData("CUSTOMER_INFO");
            dataGridView1.Columns["customer_name"].Width = 700;
            dataGridView1.Columns["customer_id"].HeaderText = "Mã Khách hàng";
            dataGridView1.Columns["customer_name"].HeaderText = "Tên khách hàng";

            Set1(false);
        }
        private void Set1(bool Visible)
        {
            groupBox1.Visible = Visible;
        }
        private void Set2(bool Visible)
        {
            button3.Visible = Visible;
            button4.Visible = Visible;
        }
        private void Set3(bool Visible)
        {
            button2.Visible = Visible;
            button4.Visible= Visible;
        }
        private void Set4(bool Visible)
        {
            button2.Visible= Visible;
            button3.Visible= Visible;
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
                    lenh = $"SELECT * FROM {tableName} WHERE customer_name LIKE @search OR customer_id LIKE @search";
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox1.Text.Trim();
                string tableName = "CUSTOMER_INFO";

                LoadData(tableName, searchText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            textBox2.Text = row.Cells["customer_id"].Value.ToString();
            textBox3.Text = row.Cells["customer_name"].Value.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            action = "add";
            Set1(true);
            groupBox1.Text = button2.Text+ " sản phẩm: ";
            Set2(false);
        }
        private string action = "";

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
                        cmd.CommandText = "insert into CUSTOMER_INFO (customer_id, customer_name) values(@Ma, @Ten)";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.ExecuteNonQuery();
                    }
                    else if (action == "edit")
                    {
                        cmd.CommandText = "update CUSTOMER_INFO set customer_id =@Ma, customer_name =@Ten where customer_id =@Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        //cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                    }
                    else if (action == "delete")
                    {
                        cmd.CommandText = "delete from CUSTOMER_INFO where customer_id =@Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.ExecuteNonQuery();
                    }
                    KetNoi.Close();
                    MessageBox.Show("Thực hiện thành công!");
                    LoadData("CUSTOMER_INFO");
                    Set1(false);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Lỗi: " + ex.Message);

            }
            Set2(true);
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            action = "edit";
            Set1(true);
            groupBox1.Text = button3.Text + " sản phẩm: ";
            textBox2.Enabled = false;
            Set3(false);

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("vui long chon ten khach hang!");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            action = "delete";
            Set1(true);
            groupBox1.Text = button4.Text + " sản phẩm: ";
            textBox3.Enabled = false;
            Set4(false);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
      
            DialogResult result = MessageBox.Show("Bạn muốn xác nhận hủy!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadData("CUSTOMER_INFO");
                groupBox1.Visible = false;
                Set2(true);
                button2.Visible = true;
            
        }
    }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textBox2.Text = row.Cells["customer_id"].Value.ToString();
                textBox3.Text = row.Cells["customer_name"].Value.ToString();
            }
        }
    }
}
