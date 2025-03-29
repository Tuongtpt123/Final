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
    public partial class Form_Main : Form
    {
        //Data Source=GIGABYTE\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True
        //SqlConnection ketNoi;
        //SqlDataAdapter boDocGhi;
        //DataSet duLieu;
        //SqlCommand boLenh;
        private string connectionString = "Data Source=GIGABYTE\\SQLEXPRESS;Initial Catalog=ProjectDB;Integrated Security=True";

        private bool _isLoginChecked = false;

        public Form_Main()
        {
            InitializeComponent();

            
        }

        private Form currentFormChild;
        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelBody.Controls.Add(childForm);
            panelBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (SessionManager.Instance.IsLoggedIn)
            {
                //loginStatuslbl.Text = $"Xin chào, {SessionManager.Instance.Username}";
                usernamelbl.Text = SessionManager.Instance.Username;
                roleNamelbl.Text = SessionManager.Instance.RoleName;
                //LoadUserInfo(SessionManager.Instance.UserId);
            }
            else
            {
                CheckLogin(); // Bắt buộc đăng nhập nếu chưa có phiên
            }
            panelTop.BackColor = Color.FromArgb(41, 41, 41);
            panelLeft.BackColor = Color.FromArgb(25, 25, 25);

            funcName.ForeColor = Color.WhiteSmoke;
            usernamelbl.ForeColor = Color.WhiteSmoke;
            roleNamelbl.ForeColor = Color.WhiteSmoke;

            numberCount();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panelBody_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SessionManager.Instance.IsLoggedIn)
            {
                DialogResult result = MessageBox.Show(
                    "Đăng xuất và thoát?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            //// Nếu chưa đăng nhập hoặc nhấn Yes, thoát ứng dụng
            //SessionManager.Instance.Logout();
        }

        private void Form_Main_Activated(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập lại nếu người dùng thoát mà chưa đăng nhập
            if (!_isLoginChecked)
            {
                CheckLogin();
                _isLoginChecked = true;
            }
        }
        
        public class SessionManager
        {
            private static SessionManager _instance;
            public static SessionManager Instance => _instance ?? (_instance = new SessionManager());

            public bool IsLoggedIn { get; private set; }
            public string Username { get; private set; }
            public string UserId { get; private set; } // Lưu user_id
            public string RoleName { get; private set; } // Lưu chức vụ của người dùng
            public string EmployeeName { get; private set; } // Lưu tên nhân viên

            private SessionManager() { }

            public void Login(string userId, string username, string roleName, string employeeName)
            {
                UserId = userId;
                Username = username;
                RoleName = roleName;
                EmployeeName = employeeName;
                IsLoggedIn = true;  
            }

            //public void Logout()
            //{
            //    UserId = null;
            //    Username = null;
            //    RoleName = null;
            //    EmployeeName = null;
            //    IsLoggedIn = false;
            //}
        }

        private void CheckLogin()
        {
            if (!SessionManager.Instance.IsLoggedIn)
            {
                using (LoginForm loginForm = new LoginForm())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        Application.Exit(); // Thoát ứng dụng nếu không đăng nhập
                    }
                }
            }
        }

        //private void OpenForm<T>() where T : Form, new()
        //{
        //    if (!SessionManager.Instance.IsLoggedIn)
        //    {
        //        MessageBox.Show("Bạn cần đăng nhập để sử dụng chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    var form = new T();
        //    form.MdiParent = this;
        //    form.Show();
        //}

        private void numberCount()
        {
            // Đếm số lượng sản phẩm
            string query = "SELECT COUNT(*) FROM PRODUCT_INFO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                productCountlbl.Text = count.ToString();
            }

            // Đếm số lượng khách hàng
            query = "SELECT COUNT(*) FROM CUSTOMER_INFO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                customerCountlbl.Text = count.ToString();
            }
            query = "SELECT COUNT(*) FROM USER_INFO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                userCountlbl.Text = count.ToString();
            }
            query = "SELECT COUNT(*) FROM SUPPLIER_INFO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                int count = (int)command.ExecuteScalar();
                supplierCountlbl.Text = count.ToString();
            }
        }

        //Hàm kiểm tra role nhân viên bán hàng
        private bool isNhanVienBanHang()
        {
            if (SessionManager.Instance.RoleName.ToLower() == "admin" || SessionManager.Instance.RoleName.ToLower() == "nhân viên bán hàng" || SessionManager.Instance.RoleName.ToLower() == "quản lí")
            {
                return true;
            }
            return false;
        }

        //Hàm kiểm tra role quản lý
        private bool isQuanLi()
        {
            if (SessionManager.Instance.RoleName.ToLower() == "admin" || SessionManager.Instance.RoleName.ToLower() == "quản lí")
            {
                return true;
            }
            return false;
        }

        //Hàm kiểm tra role nhân viên kho
        private bool isNhanVienKho()
        {
            if (SessionManager.Instance.RoleName.ToLower() == "admin" || SessionManager.Instance.RoleName.ToLower() == "nhân viên kho" || SessionManager.Instance.RoleName.ToLower() == "quản lí")
            {
                return true;
            }
            return false;
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            funcName.Text = "Trang chủ";
            
            numberCount();
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            if (isNhanVienKho())
            {
                funcName.Text = "Sản phẩm";
                openChildForm(new FrmProDuct());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            if (isNhanVienBanHang())
            {
                funcName.Text = "Đơn hàng";
                openChildForm(new OrderForm());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void customerBtn_Click(object sender, EventArgs e)
        {
            if (isNhanVienBanHang())
            {
                funcName.Text = "Khách hàng";
                openChildForm(new FrmCustomer());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            if (isNhanVienKho())
            {
                funcName.Text = "Nhập hàng";
                openChildForm(new FormAddReceipt());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            if (isQuanLi())
            {
                funcName.Text = "Nhà cung cấp";
                openChildForm(new FrmSupplier());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Báo cáo công nợ
        private void deptRpMenuStripGr_Click(object sender, EventArgs e)
        {
            if (isQuanLi())
            {
                SDebtRpForm deptRpForm = new SDebtRpForm();
                deptRpForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        //Báo cáo hàng tồn kho
        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isNhanVienKho())
            {
                inventoryRpForm inventoryRpForm = new inventoryRpForm();
                inventoryRpForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void logoutMenuStrip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Thông tin người dùng
        private void userInfoMenuStrip_Click(object sender, EventArgs e)
        {
            FormUserInfo formUserInfo = new FormUserInfo();
            formUserInfo.ShowDialog();
        }

        private void userManagerMenuStrip_Click(object sender, EventArgs e)
        {
            //Mở form nếu người dùng là quản lý hoặc hơn
            if (isQuanLi())
            {
                FormUsers formUsers = new FormUsers();
                formUsers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        //Quản lý khách hàng trong Trang chủ
        private void label13_Click(object sender, EventArgs e)
        {
            if (isNhanVienBanHang())
            {
                funcName.Text = "Khách hàng";
                //openChildForm(new CustomerForm());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Quản lý sản phẩm trong Trang chủ
        private void label11_Click(object sender, EventArgs e)
        {
            if (isNhanVienKho())
            {
                funcName.Text = "Sản phẩm";
                //openChildForm(new ProductForm());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Quản lý nhà cung cấp trong Trang chủ
        private void label12_Click(object sender, EventArgs e)
        {
            if (isQuanLi())
            {
                funcName.Text = "Nhà cung cấp";
                //openChildForm(new FormSupplier());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Quản lý nhân viên trong Trang chủ
        private void label14_Click(object sender, EventArgs e)
        {
            if (isQuanLi())
            {
                FormUsers formUsers = new FormUsers();
                formUsers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
