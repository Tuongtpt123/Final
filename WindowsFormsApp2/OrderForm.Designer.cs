namespace WindowsFormsApp2
{
    partial class OrderForm
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
            this.orderGrBx = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalPriceTxt = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteProductBtn = new System.Windows.Forms.Button();
            this.desQuantityBtn = new System.Windows.Forms.Button();
            this.incQuantityBtn = new System.Windows.Forms.Button();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.orderDateDTP = new System.Windows.Forms.DateTimePicker();
            this.customerInfoCheckBtn = new System.Windows.Forms.Button();
            this.employeeTxt = new System.Windows.Forms.TextBox();
            this.noteTxt = new System.Windows.Forms.TextBox();
            this.customerTxt = new System.Windows.Forms.TextBox();
            this.addOrderInfoBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OrdersDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.orderGrBx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // orderGrBx
            // 
            this.orderGrBx.Controls.Add(this.button2);
            this.orderGrBx.Controls.Add(this.label3);
            this.orderGrBx.Controls.Add(this.groupBox1);
            this.orderGrBx.Controls.Add(this.OrdersDgv);
            this.orderGrBx.Controls.Add(this.label2);
            this.orderGrBx.Controls.Add(this.button1);
            this.orderGrBx.Controls.Add(this.searchTxt);
            this.orderGrBx.Controls.Add(this.label1);
            this.orderGrBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderGrBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderGrBx.Location = new System.Drawing.Point(0, 0);
            this.orderGrBx.Name = "orderGrBx";
            this.orderGrBx.Size = new System.Drawing.Size(1822, 823);
            this.orderGrBx.TabIndex = 1;
            this.orderGrBx.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(899, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Danh sách đơn hàng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.totalPriceTxt);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.orderDateDTP);
            this.groupBox1.Controls.Add(this.customerInfoCheckBtn);
            this.groupBox1.Controls.Add(this.employeeTxt);
            this.groupBox1.Controls.Add(this.noteTxt);
            this.groupBox1.Controls.Add(this.customerTxt);
            this.groupBox1.Controls.Add(this.addOrderInfoBtn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(1155, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 562);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm đơn hàng";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(416, 470);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 17);
            this.label12.TabIndex = 16;
            this.label12.Text = "(*) Các trường bắt buộc";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(96, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(171, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 14;
            this.label10.Text = "*";
            // 
            // totalPriceTxt
            // 
            this.totalPriceTxt.AutoSize = true;
            this.totalPriceTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.totalPriceTxt.Location = new System.Drawing.Point(24, 470);
            this.totalPriceTxt.Name = "totalPriceTxt";
            this.totalPriceTxt.Size = new System.Drawing.Size(180, 20);
            this.totalPriceTxt.TabIndex = 13;
            this.totalPriceTxt.Text = "Tổng cộng: 0.00 VND";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.deleteProductBtn);
            this.groupBox2.Controls.Add(this.desQuantityBtn);
            this.groupBox2.Controls.Add(this.incQuantityBtn);
            this.groupBox2.Controls.Add(this.dgvOrderDetails);
            this.groupBox2.Controls.Add(this.cbxProduct);
            this.groupBox2.Controls.Add(this.quantityTxt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.addProductBtn);
            this.groupBox2.Location = new System.Drawing.Point(22, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 289);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm:";
            // 
            // deleteProductBtn
            // 
            this.deleteProductBtn.ForeColor = System.Drawing.Color.Red;
            this.deleteProductBtn.Location = new System.Drawing.Point(95, 64);
            this.deleteProductBtn.Name = "deleteProductBtn";
            this.deleteProductBtn.Size = new System.Drawing.Size(68, 33);
            this.deleteProductBtn.TabIndex = 13;
            this.deleteProductBtn.Text = "Xóa";
            this.deleteProductBtn.UseVisualStyleBackColor = true;
            this.deleteProductBtn.Click += new System.EventHandler(this.deleteProductBtn_Click);
            // 
            // desQuantityBtn
            // 
            this.desQuantityBtn.Location = new System.Drawing.Point(528, 33);
            this.desQuantityBtn.Name = "desQuantityBtn";
            this.desQuantityBtn.Size = new System.Drawing.Size(31, 28);
            this.desQuantityBtn.TabIndex = 12;
            this.desQuantityBtn.Text = "-";
            this.desQuantityBtn.UseVisualStyleBackColor = true;
            this.desQuantityBtn.Click += new System.EventHandler(this.desQuantityBtn_Click);
            // 
            // incQuantityBtn
            // 
            this.incQuantityBtn.Location = new System.Drawing.Point(491, 33);
            this.incQuantityBtn.Name = "incQuantityBtn";
            this.incQuantityBtn.Size = new System.Drawing.Size(31, 27);
            this.incQuantityBtn.TabIndex = 11;
            this.incQuantityBtn.Text = "+";
            this.incQuantityBtn.UseVisualStyleBackColor = true;
            this.incQuantityBtn.Click += new System.EventHandler(this.incQuantityBtn_Click);
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(6, 103);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.Size = new System.Drawing.Size(570, 175);
            this.dgvOrderDetails.TabIndex = 10;
            // 
            // cbxProduct
            // 
            this.cbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduct.FormattingEnabled = true;
            this.cbxProduct.Location = new System.Drawing.Point(95, 33);
            this.cbxProduct.Name = "cbxProduct";
            this.cbxProduct.Size = new System.Drawing.Size(240, 24);
            this.cbxProduct.TabIndex = 9;
            // 
            // quantityTxt
            // 
            this.quantityTxt.Location = new System.Drawing.Point(441, 34);
            this.quantityTxt.Name = "quantityTxt";
            this.quantityTxt.Size = new System.Drawing.Size(44, 23);
            this.quantityTxt.TabIndex = 8;
            this.quantityTxt.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(367, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Số lượng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Sản phẩm:";
            // 
            // addProductBtn
            // 
            this.addProductBtn.Location = new System.Drawing.Point(20, 64);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Size = new System.Drawing.Size(68, 33);
            this.addProductBtn.TabIndex = 5;
            this.addProductBtn.Text = "Thêm";
            this.addProductBtn.UseVisualStyleBackColor = true;
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click);
            // 
            // orderDateDTP
            // 
            this.orderDateDTP.Location = new System.Drawing.Point(210, 99);
            this.orderDateDTP.Name = "orderDateDTP";
            this.orderDateDTP.Size = new System.Drawing.Size(200, 23);
            this.orderDateDTP.TabIndex = 11;
            // 
            // customerInfoCheckBtn
            // 
            this.customerInfoCheckBtn.Location = new System.Drawing.Point(392, 25);
            this.customerInfoCheckBtn.Name = "customerInfoCheckBtn";
            this.customerInfoCheckBtn.Size = new System.Drawing.Size(72, 31);
            this.customerInfoCheckBtn.TabIndex = 1;
            this.customerInfoCheckBtn.Text = "Kiểm tra";
            this.customerInfoCheckBtn.UseVisualStyleBackColor = true;
            this.customerInfoCheckBtn.Click += new System.EventHandler(this.customerInfoCheckBtn_Click);
            // 
            // employeeTxt
            // 
            this.employeeTxt.Location = new System.Drawing.Point(210, 64);
            this.employeeTxt.Name = "employeeTxt";
            this.employeeTxt.ReadOnly = true;
            this.employeeTxt.Size = new System.Drawing.Size(169, 23);
            this.employeeTxt.TabIndex = 2;
            // 
            // noteTxt
            // 
            this.noteTxt.Location = new System.Drawing.Point(210, 134);
            this.noteTxt.Multiline = true;
            this.noteTxt.Name = "noteTxt";
            this.noteTxt.Size = new System.Drawing.Size(247, 38);
            this.noteTxt.TabIndex = 8;
            // 
            // customerTxt
            // 
            this.customerTxt.Location = new System.Drawing.Point(210, 29);
            this.customerTxt.Name = "customerTxt";
            this.customerTxt.Size = new System.Drawing.Size(169, 23);
            this.customerTxt.TabIndex = 0;
            // 
            // addOrderInfoBtn
            // 
            this.addOrderInfoBtn.Location = new System.Drawing.Point(22, 510);
            this.addOrderInfoBtn.Name = "addOrderInfoBtn";
            this.addOrderInfoBtn.Size = new System.Drawing.Size(191, 38);
            this.addOrderInfoBtn.TabIndex = 6;
            this.addOrderInfoBtn.Text = "Xác nhận và lưu hóa đơn";
            this.addOrderInfoBtn.UseVisualStyleBackColor = true;
            this.addOrderInfoBtn.Click += new System.EventHandler(this.addOrderInfoBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ghi chú (không dấu):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ngày đặt hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nhân viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Điện thoại khách hàng:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // OrdersDgv
            // 
            this.OrdersDgv.AllowUserToAddRows = false;
            this.OrdersDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.OrdersDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OrdersDgv.Location = new System.Drawing.Point(15, 110);
            this.OrdersDgv.MultiSelect = false;
            this.OrdersDgv.Name = "OrdersDgv";
            this.OrdersDgv.ReadOnly = true;
            this.OrdersDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.OrdersDgv.Size = new System.Drawing.Size(1123, 553);
            this.OrdersDgv.TabIndex = 5;
            this.OrdersDgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrdersDgv_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "*Nhập mã đơn hàng, mã khách hàng hoặc mã nhân viên";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(802, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(15, 36);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.Size = new System.Drawing.Size(764, 23);
            this.searchTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm đơn hàng:";
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1822, 823);
            this.Controls.Add(this.orderGrBx);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.orderGrBx.ResumeLayout(false);
            this.orderGrBx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrdersDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox orderGrBx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label totalPriceTxt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteProductBtn;
        private System.Windows.Forms.Button desQuantityBtn;
        private System.Windows.Forms.Button incQuantityBtn;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.TextBox quantityTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.DateTimePicker orderDateDTP;
        private System.Windows.Forms.Button customerInfoCheckBtn;
        private System.Windows.Forms.TextBox employeeTxt;
        private System.Windows.Forms.TextBox noteTxt;
        private System.Windows.Forms.TextBox customerTxt;
        private System.Windows.Forms.Button addOrderInfoBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView OrdersDgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}