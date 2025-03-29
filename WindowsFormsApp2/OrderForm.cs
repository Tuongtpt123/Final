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
    public partial class OrderForm: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";
        private DataTable orderDetailsTable;

        public OrderForm()
        {
            InitializeComponent();

            LoadProducts();
            InitializeOrderDetailsTable();
        }

        //Tải danh sách sản phẩm
        private void LoadProducts()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT product_id, product_name, price FROM PRODUCT_INFO";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbxProduct.DataSource = dt;
                    cbxProduct.DisplayMember = "product_name";
                    cbxProduct.ValueMember = "product_id";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khởi tạo bảng tạm lưu chi tiết đơn hàng
        private void InitializeOrderDetailsTable()
        {
            orderDetailsTable = new DataTable();
            orderDetailsTable.Columns.Add("Mã sản phẩm", typeof(string));
            orderDetailsTable.Columns.Add("Tên sản phẩm", typeof(string));
            orderDetailsTable.Columns.Add("Đơn giá", typeof(decimal));
            orderDetailsTable.Columns.Add("Số lượng", typeof(int));
            orderDetailsTable.Columns.Add("Thành tiền", typeof(decimal));
            //orderDetailsTable.Columns.Add("total", typeof(decimal), "quantity * price");

            dgvOrderDetails.DataSource = orderDetailsTable;
            
        }

        //Hàm lấy giá sản phẩm từ CSDL
        private decimal GetProductPrice(string productId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT price FROM PRODUCT_INFO WHERE product_id = @product_id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@product_id", productId);
                return (decimal)cmd.ExecuteScalar();
            }
        }
        
        private void loadData() {
            string query = @"SELECT 
                        o.order_id, 
                        c.customer_name, 
                        u.name, 
                        o.order_date, 
                        p.product_name,
                        d.quantity,
                        o.total_price, 
                        o.note
                     FROM ORDER_INFO o
                     JOIN CUSTOMER_INFO c ON o.customer_id = c.customer_id
                     JOIN USER_INFO u ON o.user_id = u.user_id
                     JOIN DETAIL_ORDER_INFO d ON o.order_id = d.order_id
                     JOIN PRODUCT_INFO p ON d.product_id = p.product_id
                     ORDER BY o.order_id DESC, o.order_date;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Mở kết nối SQL

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    OrdersDgv.DataSource = dt;

                    // Tùy chỉnh hiển thị DataGridView
                    OrdersDgv.Columns["order_id"].HeaderText = "Mã Đơn Hàng";
                    OrdersDgv.Columns["customer_name"].HeaderText = "Tên Khách Hàng";
                    OrdersDgv.Columns["name"].HeaderText = "Nhân Viên";
                    OrdersDgv.Columns["order_date"].HeaderText = "Ngày Đặt";
                    OrdersDgv.Columns["product_name"].HeaderText = "Sản Phẩm";
                    OrdersDgv.Columns["quantity"].HeaderText = "Số Lượng";
                    OrdersDgv.Columns["total_price"].HeaderText = "Tổng Tiền (VND)";
                    OrdersDgv.Columns["note"].HeaderText = "Ghi Chú";
                    

                    // Căn chỉnh cột
                    OrdersDgv.Columns["order_id"].Width = 80;
                    OrdersDgv.Columns["customer_name"].Width = 150;
                    OrdersDgv.Columns["name"].Width = 150;
                    OrdersDgv.Columns["order_date"].Width = 100;
                    OrdersDgv.Columns["product_name"].Width = 150;
                    OrdersDgv.Columns["quantity"].Width = 80;
                    OrdersDgv.Columns["total_price"].Width = 100;
                    OrdersDgv.Columns["note"].Width = 200;
                    

                    // Căn giữa dữ liệu trong một số cột
                    OrdersDgv.Columns["order_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    OrdersDgv.Columns["quantity"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    OrdersDgv.Columns["total_price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // Định dạng cột ngày tháng
                    OrdersDgv.Columns["order_date"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Định dạng số tiền
                    OrdersDgv.Columns["total_price"].DefaultCellStyle.Format = "N0"; // Hiển thị số tiền có dấu phẩy (1,000,000)
                }
            }
            catch (SqlException ex)  // Xử lý lỗi SQL
            {
                MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)  // Xử lý các lỗi chung
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            loadData();

            employeeTxt.Text = SessionManager.Instance.EmployeeName; // Gán tên nhân viên đang đăng nhập

            // Đảm bảo không có đường viền trên/dưới
            dgvOrderDetails.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dgvOrderDetails.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //Hàm kiểm tra sản phẩm đã tồn tại trong bảng
        private void AddProductToOrder(string productId, string productName, decimal unitPrice, int quantity, decimal totalPrice)
        {
            bool productExists = false;

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["Tên sản phẩm"].Value?.ToString() == productName)
                {
                    //Sản phẩm đã tồn tại → Cập nhật số lượng
                    int existingQuantity = Convert.ToInt32(row.Cells["Số lượng"].Value);
                    row.Cells["Số lượng"].Value = existingQuantity + quantity;
                    row.Cells["Thành tiền"].Value = unitPrice * (existingQuantity + quantity);
                    productExists = true;
                    break;
                }
            }

            if (!productExists)
            {
                //Nếu sản phẩm chưa có → Thêm dòng mới vào DataGridView
                totalPrice = unitPrice * quantity;
                orderDetailsTable.Rows.Add(productId, productName, unitPrice, quantity, totalPrice);
            }

        }

        //Thêm sản phẩm vào danh sách trước khi lưu
        private void addProductBtn_Click(object sender, EventArgs e)
        {
            if (cbxProduct.SelectedValue == null || quantityTxt.Text == "")
            {
                MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (int.Parse(quantityTxt.Text) < 1)
            {
                MessageBox.Show("Số lượng sản phẩm phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = cbxProduct.SelectedValue.ToString();
            string productName = cbxProduct.Text;
            decimal unitPrice = GetProductPrice(productId);
            int quantity = int.Parse(quantityTxt.Text);
            decimal totalPrice = GetProductPrice(productId);

            //Kiểm tra hàng đã chọn còn hàng trong kho không
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string querry = "SELECT inventory_quantity FROM PRODUCT_INFO WHERE product_id = @product_id";
                    SqlDataAdapter da = new SqlDataAdapter(querry, conn);
                    da.SelectCommand.Parameters.AddWithValue("@product_id", productId);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (int.Parse(quantityTxt.Text) > int.Parse(dt.Rows[0][0].ToString()))
                    {
                        MessageBox.Show("Số lượng sản phẩm trong kho không đủ!" + Environment.NewLine + "(Số lượng còn lại: " + dt.Rows[0][0].ToString() + ")", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra số lượng sản phẩm trong kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AddProductToOrder(productId, productName, unitPrice, quantity, totalPrice);
            //orderDetailsTable.Rows.Add(productId, productName, quantity, price);

            //Cập nhật tổng giá tiền
            CalculateTotalPrice();

        }

        //Mặc định các giá trị về ban đầu
        private void resetValue()
        {
            customerTxt.Text = "";
            orderDateDTP.Value = DateTime.Now;
            noteTxt.Text = "";
            orderDetailsTable.Clear();
            totalPriceTxt.Text = "Tổng cộng: 0.00 VND";
        }

        //hàm đếm số lượng tồn kho trong kho
        private int CheckInventoryQuantity(string productId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT inventory_quantity FROM PRODUCT_INFO WHERE product_id = @product_id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", productId);

                        object value = cmd.ExecuteScalar();
                        return (value != null && value != DBNull.Value) ? Convert.ToInt32(value) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra số lượng tồn kho: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }


        //Lưu đơn hàng vào SQL Server
        private void addOrderInfoBtn_Click(object sender, EventArgs e)
        {
            if (customerTxt.Text == "" || employeeTxt.Text == "" || orderDetailsTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đơn hàng và ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra thông tin khách hàng có trong CSDL không
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT customer_id FROM CUSTOMER_INFO WHERE customer_id = @customer_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerTxt.Text.Trim());

                    object result = cmd.ExecuteScalar();

                    if (result == null) //Nếu chưa có khách hàng trong CSDL
                    {
                        MessageBox.Show("Khách hàng chưa tồn tại. Vui lòng thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormAddCustomer addCustomerForm = new FormAddCustomer(customerTxt.Text.Trim());
                        addCustomerForm.ShowDialog();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Kiểm tra số lượng tồn kho
            foreach (DataRow row in orderDetailsTable.Rows)
            {
                int inventoryQuantity = CheckInventoryQuantity(row["Mã sản phẩm"].ToString());
                if (int.Parse(row["Số lượng"].ToString()) > inventoryQuantity)
                {
                    MessageBox.Show("Số lượng sản phẩm " + row["Mã sản phẩm"] + " trong kho không đủ!" + Environment.NewLine + "(Số lượng còn lại: " + inventoryQuantity + ")", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn lưu đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return;
            }
            else {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //Thêm vào ORDER_INFO
                        string insertOrderQuery = @"INSERT INTO ORDER_INFO (customer_id, user_id, order_date, total_price, note)
                                                OUTPUT INSERTED.order_id
                                                VALUES (@customer_id, @user_id, @order_date, @total_price, @note)";

                        SqlCommand cmdOrder = new SqlCommand(insertOrderQuery, conn, transaction);
                        cmdOrder.Parameters.AddWithValue("@customer_id", customerTxt.Text);
                        cmdOrder.Parameters.AddWithValue("@user_id", SessionManager.Instance.UserId); //Lấy user_id từ SessionManager
                        cmdOrder.Parameters.AddWithValue("@order_date", orderDateDTP.Value);

                        //Xử lý tổng giá tiền
                        decimal totalPrice = 0;
                        foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                        {
                            if (row.Cells["Đơn giá"].Value != null && row.Cells["Số lượng"].Value != null)
                            {
                                decimal unitPrice = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                                int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);

                                totalPrice += unitPrice * quantity;
                            }
                        }
                        cmdOrder.Parameters.AddWithValue("@total_price", totalPrice);
                        cmdOrder.Parameters.AddWithValue("@note", noteTxt.Text);
                        int orderId = (int)cmdOrder.ExecuteScalar();

                        //Thêm vào DETAIL_ORDER_INFO
                        string insertDetailQuery = @"INSERT INTO DETAIL_ORDER_INFO (order_id, product_id, quantity)
                                                 VALUES (@order_id, @product_id, @quantity)";
                        foreach (DataRow row in orderDetailsTable.Rows)
                        {
                            SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, transaction);
                            cmdDetail.Parameters.AddWithValue("@order_id", orderId);
                            cmdDetail.Parameters.AddWithValue("@product_id", row["Mã sản phẩm"]);
                            cmdDetail.Parameters.AddWithValue("@quantity", row["Số lượng"]);
                            //cmdDetail.Parameters.AddWithValue("@price", row["price"]);
                            cmdDetail.ExecuteNonQuery();
                        }

                        //Cập nhật số lượng sản phẩm trong kho#
                        foreach (DataRow row in orderDetailsTable.Rows)
                        {
                            string updateInventoryQuery = "UPDATE PRODUCT_INFO SET inventory_quantity = inventory_quantity - @quantity WHERE product_id = @product_id";
                            SqlCommand cmdUpdateInventory = new SqlCommand(updateInventoryQuery, conn, transaction);
                            cmdUpdateInventory.Parameters.AddWithValue("@quantity", row["Số lượng"]);
                            cmdUpdateInventory.Parameters.AddWithValue("@product_id", row["Mã sản phẩm"]);
                            cmdUpdateInventory.ExecuteNonQuery();
                        }

                        //Xác nhận lưu
                        transaction.Commit();
                        MessageBox.Show("Đơn hàng đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Reset giá trị
                        resetValue();
                        //Load lại dữ liệu
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi lưu đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            
            }
        }

        //Hàm kiêm  tra thông tin khách hàng
        private void customerCheck(string customerTxt)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT customer_id FROM CUSTOMER_INFO WHERE customer_id = @customer_id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@customer_id", customerTxt);

                    object result = cmd.ExecuteScalar();

                    if (result != null) //Khách hàng đã tồn tại
                    {
                        MessageBox.Show($"Khách hàng {result.ToString()} đã tồn tại. Tiếp tục nhập đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else //Khách hàng chưa tồn tại → mở Form thêm khách hàng
                    {
                        MessageBox.Show("Khách hàng chưa tồn tại. Vui lòng thêm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FormAddCustomer addCustomerForm = new FormAddCustomer(customerTxt);
                        addCustomerForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khi click vào nút Kiểm tra khách hàng:
        private void customerInfoCheckBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(customerTxt.Text.Trim()))
            {
                MessageBox.Show("Bạn chưa nhập thông tin khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            customerCheck(customerTxt.Text);

        }

        //Xóa sản phẩm trong bảng
        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            if (dgvOrderDetails.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvOrderDetails.SelectedRows)
                {
                    dgvOrderDetails.Rows.Remove(row);
                }
            }
            else if (dgvOrderDetails.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgvOrderDetails.SelectedCells)
                {
                    dgvOrderDetails.Rows.RemoveAt(cell.RowIndex);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CalculateTotalPrice();
        }

        //Cập nhật tổng giá tiền
        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.Cells["Đơn giá"].Value != null && row.Cells["Số lượng"].Value != null)
                {
                    decimal unitPrice = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);

                    totalPrice += unitPrice * quantity;
                }
                else if (row.Cells["Đơn giá"].Value == null || row.Cells["Số lượng"].Value == null)
                {
                    totalPriceTxt.Text = "Tổng cộng: 0 VND";
                }
            }

            totalPriceTxt.Text = "Tổng cộng: " + totalPrice.ToString("N2") + " VND"; // Định dạng số tiền (VD: 10,000.00)
        }

        //Tăng giảm số lượng sản phẩm
        private void incQuantityBtn_Click(object sender, EventArgs e)
        {
            quantityTxt.Text = (int.Parse(quantityTxt.Text) + 1).ToString();
        }

        //Giảm số lượng sản phẩm
        private void desQuantityBtn_Click(object sender, EventArgs e)
        {
            if (int.Parse(quantityTxt.Text) > 1)
                quantityTxt.Text = (int.Parse(quantityTxt.Text) - 1).ToString();
        }

        //Tìm kiếm đơn hàng
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = searchTxt.Text.Trim();

                // Kiểm tra nếu ô tìm kiếm trống
                if (string.IsNullOrEmpty(searchText))
                {
                    MessageBox.Show("Vui lòng nhập giá trị để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem nhập vào có phải số không (order_id)
                bool isNumber = int.TryParse(searchText, out int searchInt);

                string query = "SELECT O.order_id, " +
                       "C.customer_name, " +
                       "U.name, " +
                       "O.order_date, " +
                       "P.product_name, " +
                       "D.quantity, " +
                       "O.total_price, " +
                       "O.note " +
                       "FROM ORDER_INFO O " +
                       "JOIN CUSTOMER_INFO C ON O.customer_id = C.customer_id " +
                       "JOIN USER_INFO U ON O.user_id = U.user_id " +
                       "JOIN DETAIL_ORDER_INFO D ON o.order_id = d.order_id " +
                       "JOIN PRODUCT_INFO P ON d.product_id = p.product_id " +
                       "WHERE (@isNumber = 1 AND ( O.order_id = @searchInt OR C.customer_id = @searchInt)) " + // Nếu là số thì tìm theo order_id hoặc customer_id
                       "   OR (@isNumber = 0 AND U.user_id = @searchText)"; // Nếu không phải số thì tìm theo user_id

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Truyền tham số vào câu truy vấn
                        cmd.Parameters.AddWithValue("@isNumber", isNumber ? 1 : 0);
                        cmd.Parameters.AddWithValue("@searchInt", isNumber ? searchInt : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@searchText", !isNumber ? searchText : (object)DBNull.Value);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Kiểm tra nếu không có dữ liệu trả về
                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //OrdersDgv.DataSource = null; // Xóa dữ liệu hiển thị nếu không tìm thấy
                        }
                        else
                        {
                            OrdersDgv.DataSource = dt; // Hiển thị kết quả
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi trong quá trình tìm kiếm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Button Hiển thị tất cả đơn hàng
        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void OrdersDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
