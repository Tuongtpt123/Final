namespace WindowsFormsApp2
{
    partial class FormUsers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label user_idLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label birthLabel;
            System.Windows.Forms.Label phoneLabel;
            System.Windows.Forms.Label usernameLabel;
            System.Windows.Forms.Label passwordLabel;
            System.Windows.Forms.Label role_nameLabel;
            System.Windows.Forms.Label label4;
            this.projectDBDataSet3 = new WindowsFormsApp2.ProjectDBDataSet3();
            this.uSER_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSER_INFOTableAdapter = new WindowsFormsApp2.ProjectDBDataSet3TableAdapters.USER_INFOTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp2.ProjectDBDataSet3TableAdapters.TableAdapterManager();
            this.lOGIN_INFOTableAdapter = new WindowsFormsApp2.ProjectDBDataSet3TableAdapters.LOGIN_INFOTableAdapter();
            this.uSER_ROLETableAdapter = new WindowsFormsApp2.ProjectDBDataSet3TableAdapters.USER_ROLETableAdapter();
            this.user_idTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.birthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.uSER_ROLEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.roleCbx = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordConfirmTextBox = new System.Windows.Forms.TextBox();
            this.showPasslbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userInfoDgv = new System.Windows.Forms.DataGridView();
            this.lOGIN_INFOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            user_idLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            birthLabel = new System.Windows.Forms.Label();
            phoneLabel = new System.Windows.Forms.Label();
            usernameLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            role_nameLabel = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.projectDBDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSER_INFOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSER_ROLEBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGIN_INFOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // user_idLabel
            // 
            user_idLabel.AutoSize = true;
            user_idLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            user_idLabel.Location = new System.Drawing.Point(31, 54);
            user_idLabel.Name = "user_idLabel";
            user_idLabel.Size = new System.Drawing.Size(107, 20);
            user_idLabel.TabIndex = 2;
            user_idLabel.Text = "Mã nhân viên:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nameLabel.Location = new System.Drawing.Point(31, 96);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(61, 20);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Họ tên:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            emailLabel.Location = new System.Drawing.Point(31, 134);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(52, 20);
            emailLabel.TabIndex = 6;
            emailLabel.Text = "Email:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            addressLabel.Location = new System.Drawing.Point(31, 179);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(61, 20);
            addressLabel.TabIndex = 8;
            addressLabel.Text = "Địa chỉ:";
            // 
            // birthLabel
            // 
            birthLabel.AutoSize = true;
            birthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            birthLabel.Location = new System.Drawing.Point(472, 94);
            birthLabel.Name = "birthLabel";
            birthLabel.Size = new System.Drawing.Size(82, 20);
            birthLabel.TabIndex = 10;
            birthLabel.Text = "Ngày sinh:";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            phoneLabel.Location = new System.Drawing.Point(472, 137);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new System.Drawing.Size(85, 20);
            phoneLabel.TabIndex = 12;
            phoneLabel.Text = "Điện thoại:";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            usernameLabel.Location = new System.Drawing.Point(39, 50);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new System.Drawing.Size(87, 20);
            usernameLabel.TabIndex = 15;
            usernameLabel.Text = "Username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            passwordLabel.Location = new System.Drawing.Point(39, 92);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(79, 20);
            passwordLabel.TabIndex = 17;
            passwordLabel.Text = "Mật khẩu:";
            // 
            // role_nameLabel
            // 
            role_nameLabel.AutoSize = true;
            role_nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            role_nameLabel.Location = new System.Drawing.Point(472, 51);
            role_nameLabel.Name = "role_nameLabel";
            role_nameLabel.Size = new System.Drawing.Size(70, 20);
            role_nameLabel.TabIndex = 18;
            role_nameLabel.Text = "Chức vụ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(39, 134);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(151, 20);
            label4.TabIndex = 19;
            label4.Text = "Xác nhận mật khẩu:";
            // 
            // projectDBDataSet3
            // 
            this.projectDBDataSet3.DataSetName = "ProjectDBDataSet3";
            this.projectDBDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // uSER_INFOBindingSource
            // 
            this.uSER_INFOBindingSource.DataMember = "USER_INFO";
            this.uSER_INFOBindingSource.DataSource = this.projectDBDataSet3;
            // 
            // uSER_INFOTableAdapter
            // 
            this.uSER_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CPU_INFOTableAdapter = null;
            this.tableAdapterManager.CUSTOMER_INFOTableAdapter = null;
            this.tableAdapterManager.DETAIL_ORDER_INFOTableAdapter = null;
            this.tableAdapterManager.DETAIL_RECEIPT_INFOTableAdapter = null;
            this.tableAdapterManager.GPU_INFOTableAdapter = null;
            this.tableAdapterManager.HARDDRIVE_INFOTableAdapter = null;
            this.tableAdapterManager.LOGIN_INFOTableAdapter = this.lOGIN_INFOTableAdapter;
            this.tableAdapterManager.MAINBOARD_INFOTableAdapter = null;
            this.tableAdapterManager.MONITOR_INFOTableAdapter = null;
            this.tableAdapterManager.ORDER_INFOTableAdapter = null;
            this.tableAdapterManager.PRODUCT_INFOTableAdapter = null;
            this.tableAdapterManager.RAM_INFOTableAdapter = null;
            this.tableAdapterManager.RECEIPT_INFOTableAdapter = null;
            this.tableAdapterManager.SUPPLIER_INFOTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp2.ProjectDBDataSet3TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.USER_INFOTableAdapter = this.uSER_INFOTableAdapter;
            this.tableAdapterManager.USER_ROLETableAdapter = this.uSER_ROLETableAdapter;
            // 
            // lOGIN_INFOTableAdapter
            // 
            this.lOGIN_INFOTableAdapter.ClearBeforeFill = true;
            // 
            // uSER_ROLETableAdapter
            // 
            this.uSER_ROLETableAdapter.ClearBeforeFill = true;
            // 
            // user_idTextBox
            // 
            this.user_idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSER_INFOBindingSource, "user_id", true));
            this.user_idTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_idTextBox.Location = new System.Drawing.Point(172, 51);
            this.user_idTextBox.Name = "user_idTextBox";
            this.user_idTextBox.Size = new System.Drawing.Size(214, 26);
            this.user_idTextBox.TabIndex = 3;
            // 
            // nameTextBox
            // 
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSER_INFOBindingSource, "name", true));
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(172, 93);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(214, 26);
            this.nameTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            this.emailTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSER_INFOBindingSource, "email", true));
            this.emailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailTextBox.Location = new System.Drawing.Point(172, 134);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(214, 26);
            this.emailTextBox.TabIndex = 7;
            // 
            // addressTextBox
            // 
            this.addressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSER_INFOBindingSource, "address", true));
            this.addressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressTextBox.Location = new System.Drawing.Point(172, 176);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(258, 85);
            this.addressTextBox.TabIndex = 9;
            // 
            // birthDateTimePicker
            // 
            this.birthDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.uSER_INFOBindingSource, "birth", true));
            this.birthDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.birthDateTimePicker.Location = new System.Drawing.Point(589, 96);
            this.birthDateTimePicker.Name = "birthDateTimePicker";
            this.birthDateTimePicker.Size = new System.Drawing.Size(188, 26);
            this.birthDateTimePicker.TabIndex = 11;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.uSER_INFOBindingSource, "phone", true));
            this.phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.Location = new System.Drawing.Point(589, 137);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(148, 26);
            this.phoneTextBox.TabIndex = 13;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOGIN_INFOBindingSource, "username", true));
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(206, 47);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(189, 26);
            this.usernameTextBox.TabIndex = 16;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lOGIN_INFOBindingSource, "password", true));
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(206, 89);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(189, 26);
            this.passwordTextBox.TabIndex = 18;
            // 
            // uSER_ROLEBindingSource
            // 
            this.uSER_ROLEBindingSource.DataMember = "USER_ROLE";
            this.uSER_ROLEBindingSource.DataSource = this.projectDBDataSet3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.updateBtn);
            this.groupBox1.Controls.Add(this.roleCbx);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(role_nameLabel);
            this.groupBox1.Controls.Add(this.user_idTextBox);
            this.groupBox1.Controls.Add(this.phoneTextBox);
            this.groupBox1.Controls.Add(phoneLabel);
            this.groupBox1.Controls.Add(user_idLabel);
            this.groupBox1.Controls.Add(this.birthDateTimePicker);
            this.groupBox1.Controls.Add(birthLabel);
            this.groupBox1.Controls.Add(nameLabel);
            this.groupBox1.Controls.Add(this.addressTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(addressLabel);
            this.groupBox1.Controls.Add(emailLabel);
            this.groupBox1.Controls.Add(this.emailTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1064, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 616);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cá nhân";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(371, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "(*) Các trường bắt buộc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(88, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(138, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "*";
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Location = new System.Drawing.Point(470, 546);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(116, 42);
            this.deleteBtn.TabIndex = 28;
            this.deleteBtn.Text = "Xóa";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(172, 546);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(118, 42);
            this.addBtn.TabIndex = 24;
            this.addBtn.Text = "Tạo";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(35, 546);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(118, 42);
            this.updateBtn.TabIndex = 23;
            this.updateBtn.Text = "Cập nhật";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // roleCbx
            // 
            this.roleCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleCbx.FormattingEnabled = true;
            this.roleCbx.Location = new System.Drawing.Point(589, 48);
            this.roleCbx.Name = "roleCbx";
            this.roleCbx.Size = new System.Drawing.Size(148, 28);
            this.roleCbx.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordConfirmTextBox);
            this.groupBox2.Controls.Add(this.showPasslbl);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(this.usernameTextBox);
            this.groupBox2.Controls.Add(this.passwordTextBox);
            this.groupBox2.Controls.Add(passwordLabel);
            this.groupBox2.Controls.Add(usernameLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(536, 182);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tài khoản đăng nhập";
            // 
            // passwordConfirmTextBox
            // 
            this.passwordConfirmTextBox.Location = new System.Drawing.Point(206, 134);
            this.passwordConfirmTextBox.Name = "passwordConfirmTextBox";
            this.passwordConfirmTextBox.PasswordChar = '*';
            this.passwordConfirmTextBox.Size = new System.Drawing.Size(189, 26);
            this.passwordConfirmTextBox.TabIndex = 22;
            // 
            // showPasslbl
            // 
            this.showPasslbl.AutoSize = true;
            this.showPasslbl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPasslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPasslbl.ForeColor = System.Drawing.Color.Blue;
            this.showPasslbl.Location = new System.Drawing.Point(401, 95);
            this.showPasslbl.Name = "showPasslbl";
            this.showPasslbl.Size = new System.Drawing.Size(103, 18);
            this.showPasslbl.TabIndex = 21;
            this.showPasslbl.Text = "Hiện mật khẩu";
            this.showPasslbl.Click += new System.EventHandler(this.label5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(848, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Quản lý thông tin nhân viên";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(899, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 29);
            this.button2.TabIndex = 27;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "*Nhập mã hoặc tên nhân viên";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(802, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 25;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTxt.Location = new System.Drawing.Point(15, 163);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(764, 26);
            this.searchTxt.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tìm thông tin nhân viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "Danh sách nhân viên:";
            // 
            // userInfoDgv
            // 
            this.userInfoDgv.AllowUserToAddRows = false;
            this.userInfoDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.userInfoDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userInfoDgv.Location = new System.Drawing.Point(11, 268);
            this.userInfoDgv.MultiSelect = false;
            this.userInfoDgv.Name = "userInfoDgv";
            this.userInfoDgv.ReadOnly = true;
            this.userInfoDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userInfoDgv.Size = new System.Drawing.Size(1046, 616);
            this.userInfoDgv.TabIndex = 31;
            this.userInfoDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userInfoDgv_CellContentClick);
            this.userInfoDgv.SelectionChanged += new System.EventHandler(this.userInfoDgv_SelectionChanged);
            // 
            // lOGIN_INFOBindingSource
            // 
            this.lOGIN_INFOBindingSource.DataMember = "FK_LOGIN_INFO_USER_INFO";
            this.lOGIN_INFOBindingSource.DataSource = this.uSER_INFOBindingSource;
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.userInfoDgv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.searchTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormUsers";
            this.Text = "FormUsers";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.projectDBDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSER_INFOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSER_ROLEBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userInfoDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOGIN_INFOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProjectDBDataSet3 projectDBDataSet3;
        private System.Windows.Forms.BindingSource uSER_INFOBindingSource;
        private ProjectDBDataSet3TableAdapters.USER_INFOTableAdapter uSER_INFOTableAdapter;
        private ProjectDBDataSet3TableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.TextBox user_idTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.DateTimePicker birthDateTimePicker;
        private System.Windows.Forms.TextBox phoneTextBox;
        private ProjectDBDataSet3TableAdapters.LOGIN_INFOTableAdapter lOGIN_INFOTableAdapter;
        private System.Windows.Forms.BindingSource lOGIN_INFOBindingSource;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private ProjectDBDataSet3TableAdapters.USER_ROLETableAdapter uSER_ROLETableAdapter;
        private System.Windows.Forms.BindingSource uSER_ROLEBindingSource;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox roleCbx;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Label showPasslbl;
        private System.Windows.Forms.TextBox passwordConfirmTextBox;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView userInfoDgv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
    }
}