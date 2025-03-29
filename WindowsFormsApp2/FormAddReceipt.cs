using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp2.Form_Main;

namespace WindowsFormsApp2
{
    public partial class FormAddReceipt: Form
    {
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True;";
        private DataTable receiptDetailsTable;

        public FormAddReceipt()
        {
            InitializeComponent();

            LoadProducts();
            InitializereceiptDetailsTable();

        }


        //Tải danh sách nhà cung cấp
        private void loadSupplierAndNote()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT supplier_id, supplier_name FROM SUPPLIER_INFO";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    supplierListCbx.DataSource = dt;
                    supplierListCbx.DisplayMember = "supplier_name";
                    supplierListCbx.ValueMember = "supplier_id";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Tải dữ liệu từ CSDL
        private void loadData()
        {
            string query = @"SELECT 
                            R.receipt_id, 
                            S.supplier_name, 
                            U.name, 
                            R.receipt_date, 
                            R.total_price, 
                            P.product_name, 
                            D.quantity, 
                            R.note 
                            FROM RECEIPT_INFO R 
                            JOIN SUPPLIER_INFO S ON R.supplier_id = S.supplier_id 
                            JOIN USER_INFO U ON R.user_id = U.user_id 
                            JOIN DETAIL_RECEIPT_INFO D ON R.receipt_id = D.receipt_id 
                            JOIN PRODUCT_INFO P ON D.product_id = P.product_id 
                            ORDER BY R.receipt_date DESC 
                            ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Mở kết nối SQL

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    receiptDgv.DataSource = dt;

                    // Tùy chỉnh hiển thị DataGridView
                    receiptDgv.Columns["receipt_id"].HeaderText = "Mã Nhập Hàng";
                    receiptDgv.Columns["supplier_name"].HeaderText = "Tên Nhà Cung Cấp";
                    receiptDgv.Columns["name"].HeaderText = "Nhân Viên";
                    receiptDgv.Columns["receipt_date"].HeaderText = "Ngày Lập Đơn";
                    receiptDgv.Columns["total_price"].HeaderText = "Tổng Tiền (VND)";
                    receiptDgv.Columns["note"].HeaderText = "Tình trạng";
                    receiptDgv.Columns["product_name"].HeaderText = "Tên Sản Phẩm";
                    receiptDgv.Columns["quantity"].HeaderText = "Số Lượng";


                    // Căn chỉnh cột
                    receiptDgv.Columns["receipt_id"].Width = 80;
                    receiptDgv.Columns["supplier_name"].Width = 150;
                    receiptDgv.Columns["name"].Width = 150;
                    receiptDgv.Columns["receipt_date"].Width = 100;
                    receiptDgv.Columns["total_price"].Width = 150;
                    receiptDgv.Columns["note"].Width = 130;
                    receiptDgv.Columns["product_name"].Width = 200;
                    receiptDgv.Columns["quantity"].Width = 100;


                    // Căn giữa dữ liệu trong một số cột
                    receiptDgv.Columns["receipt_id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    receiptDgv.Columns["total_price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // Định dạng cột ngày tháng
                    receiptDgv.Columns["receipt_date"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Định dạng số tiền
                    receiptDgv.Columns["total_price"].DefaultCellStyle.Format = "N0"; // Hiển thị số tiền có dấu phẩy (1,000,000)
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

        private void FormAddReceipt_Load(object sender, EventArgs e)
        {
            loadData();
            loadSupplierAndNote();
            employeeTxt.Text = SessionManager.Instance.EmployeeName; // Gán tên nhân viên đang đăng nhập
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

        //Tìm kiếm sản phẩm theo mã nhập hàng, mã nhà cung cấp hoặc mã nhân viên
        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = searchTxt.Text.Trim();

            // Nếu ô tìm kiếm trống thông báo lỗi
            if (searchTxt.Text == "")
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isNumber = int.TryParse(searchTxt.Text, out int searchInt);

            string query = @"SELECT 
                            R.receipt_id,
                            S.supplier_name,
                            U.name,
                            R.receipt_date,
                            R.total_price,
                            R.note,
                            P.product_name,
                            D.quantity
                            FROM RECEIPT_INFO R
                            JOIN SUPPLIER_INFO S ON R.supplier_id = S.supplier_id
                            JOIN USER_INFO U ON R.user_id = U.user_id
                            JOIN DETAIL_RECEIPT_INFO D ON R.receipt_id = D.receipt_id
                            JOIN PRODUCT_INFO P ON D.product_id = P.product_id
                            WHERE (@isNumber = 1 AND R.receipt_id = @searchInt)
                            OR (@isNumber = 0 AND ( U.user_id = @searchText OR S.supplier_id = @searchText))
                            ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();  // Mở kết nối SQL

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@isNumber", isNumber ? 1 : 0);
                        cmd.Parameters.AddWithValue("@searchInt", isNumber ? searchInt : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@searchText", !isNumber ? searchText : (object)DBNull.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            receiptDgv.DataSource = dt;
                        }
                    }
                }
            } 
            catch(Exception ex) {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Khi ấn vào nút hiện tất cả
        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }



        //Khởi tạo bảng tạm lưu chi tiết đơn hàng
        private void InitializereceiptDetailsTable()
        {
            receiptDetailsTable = new DataTable();
            receiptDetailsTable.Columns.Add("Mã sản phẩm", typeof(string));
            receiptDetailsTable.Columns.Add("Tên sản phẩm", typeof(string));
            receiptDetailsTable.Columns.Add("Đơn giá", typeof(decimal));
            receiptDetailsTable.Columns.Add("Số lượng", typeof(int));
            receiptDetailsTable.Columns.Add("Thành tiền", typeof(decimal));
            //receiptDetailsTable.Columns.Add("total", typeof(decimal), "quantity * price");

            dgvReceiptDetails.DataSource = receiptDetailsTable;

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

        //Hàm kiểm tra sản phẩm đã tồn tại trong bảng
        private void AddProductToOrder(string productId, string productName, decimal unitPrice, int quantity, decimal totalPrice)
        {
            bool productExists = false;

            foreach (DataGridViewRow row in dgvReceiptDetails.Rows)
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
                receiptDetailsTable.Rows.Add(productId, productName, unitPrice, quantity, totalPrice);
            }

        }

        //Thêm sản phẩm vào danh sách trước khi lưu
        private void addProductBtn_Click_1(object sender, EventArgs e)
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

            AddProductToOrder(productId, productName, unitPrice, quantity, totalPrice);
            //orderDetailsTable.Rows.Add(productId, productName, quantity, price);

            //Cập nhật tổng giá tiền
            CalculateTotalPrice();
        }

        //Cập nhật tổng giá tiền
        private void CalculateTotalPrice()
        {
            decimal totalPrice = 0;

            foreach (DataGridViewRow row in dgvReceiptDetails.Rows)
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

        //Lưu thông tin vào cơ sở dữ liệu
        private void addOrderInfoBtn_Click(object sender, EventArgs e)
        {
            if (receiptDetailsTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm sản phẩm vào đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (employeeTxt.Text == "" || supplierListCbx.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                DialogResult result = MessageBox.Show("Xác nhận lưu đơn hàng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                try
                {
                    //Thêm thông tin vào bảng RECEIPT_INFO
                    string query = "INSERT INTO RECEIPT_INFO (supplier_id, user_id, receipt_date, total_price, note) VALUES (@supplier_id, @user_id, @receipt_date, @total_price, @note); SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@supplier_id", supplierListCbx.SelectedValue);
                    cmd.Parameters.AddWithValue("@user_id", SessionManager.Instance.UserId);
                    cmd.Parameters.AddWithValue("@receipt_date", DateTime.Now);
                    //Xử lý tổng giá tiền
                    decimal totalPrice = 0;
                    foreach (DataGridViewRow row in dgvReceiptDetails.Rows)
                    {
                        if (row.Cells["Đơn giá"].Value != null && row.Cells["Số lượng"].Value != null)
                        {
                            decimal unitPrice = Convert.ToDecimal(row.Cells["Đơn giá"].Value);
                            int quantity = Convert.ToInt32(row.Cells["Số lượng"].Value);

                            totalPrice += unitPrice * quantity;
                        }
                    }
                    cmd.Parameters.AddWithValue("@total_price", totalPrice);
                    cmd.Parameters.AddWithValue("@note", "Chờ thanh toán");
                    int receiptId = Convert.ToInt32(cmd.ExecuteScalar());

                    //Thêm thông tin vào bảng DETAIL_RECEIPT_INFO
                    query = "INSERT INTO DETAIL_RECEIPT_INFO (receipt_id, product_id, quantity) VALUES (@receipt_id, @product_id, @quantity)";
                    cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                    foreach (DataRow row in receiptDetailsTable.Rows)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                        cmd.Parameters.AddWithValue("@product_id", row["Mã sản phẩm"]);
                        cmd.Parameters.AddWithValue("@quantity", row["Số lượng"]);
                        cmd.ExecuteNonQuery();
                    }

                    //Lưu công nợ nhà cung cấp nếu chưa thanh toán
                    query = "UPDATE SUPPLIER_INFO SET supplier_debt = supplier_debt + @total_price WHERE supplier_id = @supplier_id";
                    cmd = new SqlCommand(query, conn, transaction);
                    cmd.Parameters.AddWithValue("@total_price", totalPrice);
                    cmd.Parameters.AddWithValue("@supplier_id", supplierListCbx.SelectedValue);
                    cmd.ExecuteNonQuery();

                    //Xác nhận lưu
                    transaction.Commit();
                    MessageBox.Show("Thêm đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    resetValue();
                    loadData();
                    InitializereceiptDetailsTable();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Hàm reset form
        private void resetValue()
        {
            receiptDateDTP.Value = DateTime.Now;
            noteStatusTxt.Text = "Chờ thanh toán";
            receiptDetailsTable.Clear();
            totalPriceTxt.Text = "Tổng cộng: 0 VND";
        }

        //Xóa sản phẩm trong bảng
        private void deleteProductBtn_Click_1(object sender, EventArgs e)
        {
            if (dgvReceiptDetails.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvReceiptDetails.SelectedRows)
                {
                    dgvReceiptDetails.Rows.Remove(row);
                }
            }
            else if (dgvReceiptDetails.SelectedCells.Count > 0)
            {
                foreach (DataGridViewCell cell in dgvReceiptDetails.SelectedCells)
                {
                    dgvReceiptDetails.Rows.RemoveAt(cell.RowIndex);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            CalculateTotalPrice();
        }

        //Khi bấm nút hủy đơn
        private void cancelledBtn_Click(object sender, EventArgs e)
        {
            string query = "UPDATE RECEIPT_INFO SET note = N'Đã hủy' WHERE receipt_id = @receipt_id";

            if (receiptDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (receiptDgv.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã hủy")
            {
                MessageBox.Show("Đơn hàng này đã bị hủy trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy đơn hàng này?" + Environment.NewLine +
                                                  "Lưu ý: Những sản phẩm khác trong đơn hàng này cũng sẽ bị hủy!", 
                                                  "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                try
                {
                    int receiptId = Convert.ToInt32(receiptDgv.SelectedRows[0].Cells["receipt_id"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    //Nếu đơn hơn hàng bị hủy, cập nhật lại công nợ nhà cung cấp
                    query = "UPDATE SUPPLIER_INFO SET " +
                            "supplier_debt = supplier_debt - (SELECT total_price FROM RECEIPT_INFO " +
                            "WHERE receipt_id = @receipt_id) " +
                            "WHERE supplier_id = (SELECT supplier_id FROM RECEIPT_INFO " +
                            "WHERE receipt_id = @receipt_id)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Hủy đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hủy đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        //Khi bấm nút đã xác nhận thanh toán
        private void purchasedBtn_Click(object sender, EventArgs e)
        {
            string query = "UPDATE RECEIPT_INFO SET note = N'Đã thanh toán' WHERE receipt_id = @receipt_id ";

            if (receiptDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (receiptDgv.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã vào kho")
            {
                MessageBox.Show("Đơn hàng này đã được chuyển vào kho trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã thanh toán")
            {
                MessageBox.Show("Đơn hàng đã được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã hủy")
            {
                MessageBox.Show("Bạn không thể xác nhận thanh toán với đơn hàng này!" + Environment.NewLine + "Đơn hàng đã bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Xác nhận đã thanh toán đơn hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                try
                {
                    int receiptId = Convert.ToInt32(receiptDgv.SelectedRows[0].Cells["receipt_id"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //Cập nhật công nợ nhà cung cấp nếu đã thanh toán
                    query = "UPDATE SUPPLIER_INFO SET " +
                            "supplier_debt = supplier_debt - (SELECT total_price FROM RECEIPT_INFO " +
                            "WHERE receipt_id = @receipt_id) " +
                            "WHERE supplier_id = (SELECT supplier_id FROM RECEIPT_INFO " +
                            "WHERE receipt_id = @receipt_id)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Xác nhận thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xác nhận thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }

        //Khi bấm nút chuyển sản phẩm vào kho
        private void moveProductIntoDbBtn_Click(object sender, EventArgs e)
        {
            if (receiptDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (receiptDgv.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn một dòng dữ liệu để thực hiện thao tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã vào kho")
            {
                MessageBox.Show("Đơn hàng này đã được chuyển vào kho trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Đã hủy")
            {
                MessageBox.Show("Bạn không thể chuyển sản phẩm vào kho với đơn hàng này!" + Environment.NewLine + "Đơn hàng đã bị hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (receiptDgv.SelectedRows[0].Cells["note"].Value.ToString() == "Chờ thanh toán")
            {
                MessageBox.Show("Bạn không thể chuyển sản phẩm vào kho với đơn hàng này!" + Environment.NewLine + "Đơn hàng chưa được thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataGridViewRow selectedRow = receiptDgv.SelectedRows[0];
            string receiptId = selectedRow.Cells["receipt_id"].Value.ToString();
            string productName = selectedRow.Cells["product_name"].Value.ToString();
            int quantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value);
            // Xác nhận chuyển sản phẩm vào kho
            DialogResult result = MessageBox.Show("Xác nhận chuyển sản phẩm vào kho?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                updateNoteAndUpdateProductQuantity(receiptId, productName, quantity);
            }
            else
            {
                return;
            }
        }

        //Hàm xử lý khi ấn "Chuyển vào kho"
        private void updateNoteAndUpdateProductQuantity(string receiptId, string productName, int quantity)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        //Truy vấn product_id từ product_name
                        string getProductIdQuery = "SELECT product_id FROM PRODUCT_INFO WHERE product_name = @productName";
                        string productId = null;

                        using (SqlCommand cmd = new SqlCommand(getProductIdQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@productName", productName);
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                                productId = result.ToString();
                        }

                        //Nếu không tìm thấy product_id
                        if (string.IsNullOrEmpty(productId))
                        {
                            transaction.Rollback();
                            MessageBox.Show("Không tìm thấy sản phẩm trong kho!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //Cập nhật trạng thái note của đơn nhập
                        string updateReceiptQuery = "UPDATE RECEIPT_INFO SET note = N'Đã vào kho' WHERE receipt_id = @receiptId";
                        using (SqlCommand cmd = new SqlCommand(updateReceiptQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@receiptId", receiptId);
                            cmd.ExecuteNonQuery();
                        }

                        //Cập nhật số lượng sản phẩm trong kho
                        string updateProductQuery = "UPDATE PRODUCT_INFO SET inventory_quantity = inventory_quantity + @quantity WHERE product_id = @productId";
                        using (SqlCommand cmd = new SqlCommand(updateProductQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@quantity", quantity);
                            cmd.Parameters.AddWithValue("@productId", productId);
                            cmd.ExecuteNonQuery();
                        }

                        //Xác nhận transaction
                        transaction.Commit();
                        MessageBox.Show("Đã chuyển sản phẩm vào kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Cập nhật lại DataGridView
                        loadData();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Thêm số lượng sản phẩm
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
    }
}
