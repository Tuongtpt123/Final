using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WindowsFormsApp2
{
    public partial class FrmProDuct : Form
    {
        SqlConnection KetNoi;

        SqlDataAdapter BoDocGhi;

        DataSet DuLieu;
        public FrmProDuct()
        {
            InitializeComponent();
        }
        private void FrmProDuct_Load(object sender, EventArgs e)
        {
            string chuoiKN = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True";
            KetNoi = new SqlConnection(chuoiKN);

            LoadData("PRODUCT_INFO");
            SetInput(false);

            dataGridView1.Columns["product_name"].Width = 210;
            dataGridView1.Columns["product_type"].Width = 150;
            dataGridView1.Columns["product_id"].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns["product_name"].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns["price"].HeaderText = "Giá";
            dataGridView1.Columns["product_type"].HeaderText = "Loại sản phẩm";
            dataGridView1.Columns["warranty"].HeaderText = "Bảo hành";
            dataGridView1.Columns["inventory_quantity"].HeaderText = "Số lượng tồn kho";

            comboBox1.Items.Add("RAM");
            comboBox1.Items.Add("CPU");
            comboBox1.Items.Add("GPU");
            comboBox1.Items.Add("MAINBOARD");
            comboBox1.Items.Add("HARDDRIVE");

            TinhTongSoLuongTonKho();
        }
        private void LoadData(string tableName , string search = "")
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
                    lenh = $"SELECT * FROM {tableName} WHERE product_name LIKE @search OR product_id LIKE @search";
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = textBox1.Text.Trim(); 
                string tableName = "PRODUCT_INFO"; 

                LoadData(tableName, searchText); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }

        private string action = "";
        private string cpuaction = "";
        private void SetInput(bool Visible)
        {
            
            groupBox3.Visible = Visible;
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
        private void Set5(bool Visible)
        {
            button2.Visible= Visible;
            button3.Visible= Visible;
            button4.Visible = Visible;
        }
        private void Set6(bool Visible)
        {
            groupBox4.Visible = Visible;
        }
        private void Set7GPU(bool Visible)
        {
            textBox10.Visible= Visible;
            textBox11.Visible= Visible;
            label12.Visible= Visible;
            label13.Visible= Visible;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
            action = "add";
            SetInput(true);
            textBox2.Enabled = true;

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            
            textBox6.Text = "";
            textBox7.Text = "";

            Set2(false);
            Set6(false);

            groupBox3.Text = button2.Text + " Sản phẩm";

            
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["product_id"].Value.ToString();
                textBox3.Text = row.Cells["product_name"].Value.ToString();
                textBox4.Text = row.Cells["price"].Value.ToString();                            
                textBox7.Text = row.Cells["inventory_quantity"].Value.ToString();
                string warranty = row.Cells["warranty"].Value.ToString();
                if (warranty == "12 tháng") radioButton1.Checked = true;
                else if (warranty == "24 tháng") radioButton2.Checked = true;
                else if (warranty == "Không có") radioButton3.Checked = true;
                string productType = row.Cells["product_type"].Value.ToString();


        if (comboBox1.Items.Contains(productType))
        {
            comboBox1.SelectedItem = productType;
        }
        if(productType == "CPU")
                {
                    LoadData("CPU_INFO");
                    DataGridViewRow rov = dataGridView1.Rows[e.RowIndex];
                    textBox5.Text = rov.Cells["cores"].Value.ToString();
                    textBox6.Text = rov.Cells["threads"].Value.ToString();
                    textBox8.Text = rov.Cells["base_speed"].Value.ToString();
                    textBox9.Text = rov.Cells["max_speed"].Value.ToString();
                    textBox10.Text = rov.Cells["socket"].Value.ToString();
                    textBox11.Text = rov.Cells["brand"].Value.ToString();

                }
        else if(productType == "GPU")
                {
                    LoadData("GPU_INFO");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewRow gov = dataGridView1.Rows[0];
                        
                        textBox5.Text = gov.Cells["standard_bus"].Value.ToString();
                        textBox6.Text = gov.Cells["max_monitor"].Value.ToString();
                        textBox8.Text = gov.Cells["vram_usage"].Value.ToString();
                        textBox9.Text = gov.Cells["brand"].Value.ToString();
                    }
                }
         else if( productType == "RAM")
                {
                    LoadData("RAM_INFO");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewRow nk = dataGridView1.Rows[0];
                        textBox5.Text = nk.Cells["ram_type"].Value.ToString();
                        textBox6.Text = nk.Cells["ram_capacity"].Value.ToString();
                        textBox8.Text = nk.Cells["ram_bus"].Value.ToString();
                        textBox9.Text = nk.Cells["ram_cooling"].Value.ToString();
                        textBox11.Text = nk.Cells["brand"].Value.ToString();
                    }
                }
        else if (productType == "MAINBOARD")
                {
                    LoadData("MAINBOARD_INFO");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewRow kk = dataGridView1.Rows[0];
                        textBox5.Text = kk.Cells["cpu"].Value.ToString();
                        textBox6.Text = kk.Cells["chipset"].Value.ToString();
                        textBox8.Text = kk.Cells["mainboard_usage"].Value.ToString();
                        textBox9.Text = kk.Cells["intergrated_graphics"].Value.ToString();
                        textBox10.Text = kk.Cells["motherboard_os"].Value.ToString();
                        textBox11.Text = kk.Cells["brand"].Value.ToString();
                    }
                }
        else if(productType == "HARDDRIVE")
                {
                    LoadData("HARDDRIVE_INFO");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        DataGridViewRow kov = dataGridView1.Rows[0];
                        textBox5.Text = kov.Cells["hd_capacity"].Value.ToString();
                        textBox6.Text = kov.Cells["hd_type"].Value.ToString();
                        textBox8.Text = kov.Cells["brand"].Value.ToString();
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            action = "edit";
            groupBox3.Text = button3.Text + " Sản phẩm";
            SetInput(true);
            textBox2.Enabled = false;
            Set3(false);
            Set6(false);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm trước khí sửa!");
                return;
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            action = "delete";
            SetInput(true);
            textBox2.Enabled = true;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
           
            textBox6.Enabled = false;
            textBox7.Enabled = false;

            Set4(false);
            Set6(false);
            groupBox3.Text = button4.Text + " Sản phẩm";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = KetNoi;
                    string selectedCategory = comboBox1.Text;
                    string warrantyValue = radioButton1.Checked ? "12 tháng" :
                                           radioButton2.Checked ? "24 tháng" : "Không có";

                    if (action == "add")
                    {
                        cmd.CommandText = "INSERT INTO PRODUCT_INFO (product_id, product_name, price, product_type, warranty, inventory_quantity) VALUES (@Ma, @Ten, @gia, @loai, @baohanh, @soluong)";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.Parameters.AddWithValue("@gia", textBox4.Text);
                        cmd.Parameters.AddWithValue("@loai", selectedCategory);
                        cmd.Parameters.AddWithValue("@baohanh", warrantyValue);
                        cmd.Parameters.AddWithValue("@soluong", textBox7.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);

                        switch (selectedCategory)
                        {
                            case "CPU":
                                cmd.CommandText = "INSERT INTO CPU_INFO (product_id, cores, threads, base_speed, max_speed, socket, brand) VALUES (@Ma, @Cores, @Threads, @BaseSpeed, @MaxSpeed, @Socket, @Brand)";
                                cmd.Parameters.AddWithValue("@Cores", textBox5.Text);
                                cmd.Parameters.AddWithValue("@Threads", textBox6.Text);
                                cmd.Parameters.AddWithValue("@BaseSpeed", textBox8.Text);
                                cmd.Parameters.AddWithValue("@MaxSpeed", textBox9.Text);
                                cmd.Parameters.AddWithValue("@Socket", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox11.Text);
                                break;

                            case "GPU":
                                cmd.CommandText = "INSERT INTO GPU_INFO (product_id, standard_bus, max_monitor, vram_usage, brand) VALUES (@Ma, @standard_bus, @max_monitor, @vram_usage, @Brand)";
                                cmd.Parameters.AddWithValue("@standard_bus", textBox5.Text);
                                cmd.Parameters.AddWithValue("@max_monitor", textBox6.Text);
                                cmd.Parameters.AddWithValue("@vram_usage", textBox8.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox9.Text);
                                break;

                            case "RAM":
                                cmd.CommandText = "INSERT INTO RAM_INFO (product_id, ram_type, ram_capacity, ram_bus, ram_cooling, ram_led, brand) VALUES (@Ma, @type, @capacity, @bus, @cooling, @led, @brand)";
                                cmd.Parameters.AddWithValue("@type", textBox5.Text);
                                cmd.Parameters.AddWithValue("@capacity", textBox6.Text);
                                cmd.Parameters.AddWithValue("@bus", textBox8.Text);
                                cmd.Parameters.AddWithValue("@cooling", textBox9.Text);
                                cmd.Parameters.AddWithValue("@led", textBox10.Text);
                                cmd.Parameters.AddWithValue("@brand", textBox11.Text);
                                break;

                            case "MAINBOARD":
                                cmd.CommandText = "INSERT INTO MAINBOARD_INFO (product_id, cpu, chipset, mainboard_usage, intergrated_graphics, motherboard_os, brand) VALUES (@Ma, @cpu, @chip, @usage, @grap, @os, @Brand)";
                                cmd.Parameters.AddWithValue("@cpu", textBox5.Text);
                                cmd.Parameters.AddWithValue("@chip", textBox6.Text);
                                cmd.Parameters.AddWithValue("@usage", textBox8.Text);
                                cmd.Parameters.AddWithValue("@grap", textBox9.Text);
                                cmd.Parameters.AddWithValue("@os", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox11.Text);
                                break;
                            case "HARDDRIVE":
                                cmd.CommandText = "INSERT INTO HARDDRIVE_INFO (product_id, hd_capacity, hd_type, brand) VALUES (@Ma, @capacity, @type, @Brand)";
                                cmd.Parameters.AddWithValue("@capacity", textBox5.Text);
                                cmd.Parameters.AddWithValue("@type", textBox6.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox8.Text);
                                break;
                            default:
                                throw new Exception("Loại sản phẩm không hợp lệ");
                        }
                        cmd.ExecuteNonQuery();
                    }
                    else if (action == "edit")
                    {
                        cmd.CommandText = "UPDATE PRODUCT_INFO SET product_name = @Ten, price = @gia, product_type = @loai, warranty = @baohanh, inventory_quantity = @soluong WHERE product_id = @Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.Parameters.AddWithValue("@Ten", textBox3.Text);
                        cmd.Parameters.AddWithValue("@gia", textBox4.Text);
                        cmd.Parameters.AddWithValue("@loai", selectedCategory);
                        cmd.Parameters.AddWithValue("@baohanh", warrantyValue);
                        cmd.Parameters.AddWithValue("@soluong", textBox7.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);

                        switch (selectedCategory)
                        {
                            case "CPU":
                                cmd.CommandText = "UPDATE CPU_INFO SET cores=@Cores, threads=@Threads, base_speed=@BaseSpeed, max_speed=@MaxSpeed, socket=@Socket, brand=@Brand WHERE product_id=@Ma";
                                cmd.Parameters.AddWithValue("@Cores", textBox5.Text);
                                cmd.Parameters.AddWithValue("@Threads", textBox6.Text);
                                cmd.Parameters.AddWithValue("@BaseSpeed", textBox8.Text);
                                cmd.Parameters.AddWithValue("@MaxSpeed", textBox9.Text);
                                cmd.Parameters.AddWithValue("@Socket", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox11.Text);
                                break;

                            case "GPU":
                                cmd.CommandText = "UPDATE GPU_INFO SET standard_bus=@standard_bus, max_monitor=@max_monitor, vram_usage=@vram_usage, brand=@Brand WHERE product_id=@Ma";
                                cmd.Parameters.AddWithValue("@standard_bus", textBox5.Text);
                                cmd.Parameters.AddWithValue("@max_monitor", textBox6.Text);
                                cmd.Parameters.AddWithValue("@vram_usage", textBox8.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox9.Text);
                                break;

                            case "RAM":
                                cmd.CommandText = "UPDATE RAM_INFO SET ram_type=@type, ram_capacity=@capacity, ram_bus=@bus, ram_cooling= @cooling, ram_led= @led, brand=@Brand WHERE product_id=@Ma";
                                cmd.Parameters.AddWithValue("@type", textBox5.Text);
                                cmd.Parameters.AddWithValue("@capacity", textBox6.Text);
                                cmd.Parameters.AddWithValue("@bus", textBox8.Text);
                                cmd.Parameters.AddWithValue("@cooling", textBox9.Text);
                                cmd.Parameters.AddWithValue("@led", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox11.Text);
                                break;

                            case "MAINBOARD":
                                cmd.CommandText = "UPDATE MAINBOARD_INFO SET cpu =@cpu, chipset=@Chipset, mainboard_usage =@usage, intergrated_graphics= @grap, motherboard_os= @os, brand=@Brand WHERE product_id=@Ma";
                                cmd.Parameters.AddWithValue("@cpu", textBox5.Text);
                                cmd.Parameters.AddWithValue("@Chipset", textBox6.Text);
                                cmd.Parameters.AddWithValue("@usage", textBox8.Text);
                                cmd.Parameters.AddWithValue("@grap", textBox9.Text);
                                cmd.Parameters.AddWithValue("@os", textBox10.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox11.Text);
                                break;
                            case "HARDDRIVE":
                                cmd.CommandText = "UPDATE HARDDRIVE_INFO SET hd_capacity=@capacity, hd_type=@type, brand=@Brand WHERE product_id=@Ma";
                                cmd.Parameters.AddWithValue("@capacity", textBox5.Text);
                                cmd.Parameters.AddWithValue("@type", textBox6.Text);
                                cmd.Parameters.AddWithValue("@Brand", textBox8.Text);
                                break;
                            default:
                                throw new Exception("Loại sản phẩm không hợp lệ");
                        }
                        cmd.ExecuteNonQuery();
                    }
                    else if (action == "delete")
                    {
                        cmd.CommandText = "DELETE FROM CPU_INFO WHERE product_id = @Ma; DELETE FROM GPU_INFO WHERE product_id = @Ma; DELETE FROM RAM_INFO WHERE product_id = @Ma; DELETE FROM MAINBOARD_INFO WHERE product_id = @Ma; DELETE FROM HARDDRIVE_INFO WHERE product_id = @Ma;";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.CommandText = "DELETE FROM PRODUCT_INFO WHERE product_id = @Ma";
                        cmd.Parameters.AddWithValue("@Ma", textBox2.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                KetNoi.Close();
                MessageBox.Show("Thực hiện thành công!");
                LoadData("PRODUCT_INFO");
                SetInput(false);
                TinhTongSoLuongTonKho();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            Set5(true);
        }




        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           try
            {
                string searchText = textBox1.Text.Trim(); 
                string tableName = "PRODUCT_INFO"; 

                LoadData(tableName, searchText); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadData("CPU_INFO");


        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "CPU")
            {
                LoadData("CPU_INFO");
                label8.Text = "Số Lõi: ";
                label9.Text = "Số luồng: ";
                label10.Text = "Tốc độ cơ sở: ";
                label11.Text = "Tốc độ tối đa: ";
                label12.Text = "Dây: ";
                label13.Text = "Hãng: ";
                Set6(true);
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;



                groupBox4.Text = comboBox1.Text;
                return;

            }
            else if (comboBox1.SelectedItem.ToString() == "GPU")
            {
                LoadData("GPU_INFO");
                Set6(true);
                dataGridView1.Columns["product_id"].Width = 240;
                label8.Text = "Bus tiêu chuẩn: ";
                label9.Text = "Max_monitor: ";
                label10.Text = "Tốc độ màn hình: ";
                label11.Text = "Thương hiệu: ";
                Set7GPU(false);
                groupBox4.Text = comboBox1.Text;
                return;

            }
            else if (comboBox1.SelectedItem.ToString() == "RAM")
            {
                LoadData("RAM_INFO");
                dataGridView1.Columns["product_id"].Width = 240;
                label8.Text = "Loại ram: ";
                label9.Text = "Dung lượng ram: ";
                label10.Text = "Bus ram: ";
                label11.Text = "Làm mát ram: ";
                label12.Text = "Led của ram: ";
                label13.Text = "Thương hiệu: ";
                Set6(true);
                textBox9.Visible = true;
                textBox10.Visible = true;
                textBox11.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;

                groupBox4.Text = comboBox1.Text;
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == "MAINBOARD")
            {
                LoadData("MAINBOARD_INFO");
                dataGridView1.Columns["product_id"].Width = 240;
                label8.Text = "CPU: ";
                label9.Text = "Bộ vi xử lý: ";
                label10.Text = "Bo mạch chính: ";
                label11.Text = "Đồ họa tích hợp: ";
                label12.Text = "Bo mạch chủ: ";
                label13.Text = "Thương hiệu: ";
                Set6(true);


                groupBox4.Text = comboBox1.Text;
                return;
            }
            else if (comboBox1.SelectedItem.ToString() == "HARDDRIVE")
            {
                LoadData("HARDDRIVE_INFO");
                Set6(true);
                dataGridView1.Columns["product_id"].Width = 240;
                label8.Text = "Dung lượng HD: ";
                label9.Text = "Tốc độ màn hình: ";
                label10.Text = "Thương hiệu: ";
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                textBox9.Visible = false;
                textBox10.Visible = false;
                textBox11.Visible = false;
                Set7GPU(false);
                groupBox4.Text = comboBox1.Text;
                return;
            }
            }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadData("GPU_INFO");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadData("PRODUCT_INFO");
            dataGridView1.Columns["product_name"].Width = 210;
            dataGridView1.Columns["product_type"].Width = 150;

        }
        private void button8_Click_1(object sender, EventArgs e)
        {
            LoadData("RAM_INFO");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            LoadData("MAINBOARD_INFO");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadData("HARDDRIVE_INFO");
        }
        private void TinhTongSoLuongTonKho()
        {
            int tongSoLuong = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["inventory_quantity"].Value != null) // Kiểm tra giá trị không null
                {
                    int soLuong;
                    if (int.TryParse(row.Cells["inventory_quantity"].Value.ToString(), out soLuong))
                    {
                        tongSoLuong += soLuong;
                    }
                }
            }

            // Hiển thị tổng số lượng tồn kho trong textBox12
            textBox12.Text = tongSoLuong.ToString();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn xác nhận hủy!","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadData("PRODUCT_INFO");
                groupBox3.Visible = false;
                Set2(true);
                button2.Visible = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 20)
            {
                MessageBox.Show("Không được nhập quá 20 ký tự!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = textBox2.Text.Substring(0, 10);
                textBox2.SelectionStart = textBox2.Text.Length; // Đưa con trỏ về cuối
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                textBox2.Text = row.Cells["product_id"].Value.ToString();
                textBox3.Text = row.Cells["product_name"].Value.ToString();
                textBox4.Text = row.Cells["price"].Value.ToString();
                textBox7.Text = row.Cells["inventory_quantity"].Value.ToString();
                string warranty = row.Cells["warranty"].Value.ToString();
                if (warranty == "12 tháng") radioButton1.Checked = true;
                else if (warranty == "24 tháng") radioButton2.Checked = true;
                else if (warranty == "Không có") radioButton3.Checked = true;
                
            }
        }
    }
}
