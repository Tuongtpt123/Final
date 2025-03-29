namespace WindowsFormsApp2
{
    partial class FormAddReceipt
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
            this.moveProductIntoDbBtn = new System.Windows.Forms.Button();
            this.cancelledBtn = new System.Windows.Forms.Button();
            this.purchasedBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.noteStatusTxt = new System.Windows.Forms.Label();
            this.supplierListCbx = new System.Windows.Forms.ComboBox();
            this.totalPriceTxt = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteProductBtn = new System.Windows.Forms.Button();
            this.desQuantityBtn = new System.Windows.Forms.Button();
            this.incQuantityBtn = new System.Windows.Forms.Button();
            this.dgvReceiptDetails = new System.Windows.Forms.DataGridView();
            this.cbxProduct = new System.Windows.Forms.ComboBox();
            this.quantityTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.receiptDateDTP = new System.Windows.Forms.DateTimePicker();
            this.employeeTxt = new System.Windows.Forms.TextBox();
            this.addReceiptInfoBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.receiptDgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.orderGrBx.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // orderGrBx
            // 
            this.orderGrBx.Controls.Add(this.moveProductIntoDbBtn);
            this.orderGrBx.Controls.Add(this.cancelledBtn);
            this.orderGrBx.Controls.Add(this.purchasedBtn);
            this.orderGrBx.Controls.Add(this.button2);
            this.orderGrBx.Controls.Add(this.label3);
            this.orderGrBx.Controls.Add(this.groupBox1);
            this.orderGrBx.Controls.Add(this.receiptDgv);
            this.orderGrBx.Controls.Add(this.label2);
            this.orderGrBx.Controls.Add(this.button1);
            this.orderGrBx.Controls.Add(this.searchTxt);
            this.orderGrBx.Controls.Add(this.label1);
            this.orderGrBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderGrBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderGrBx.Location = new System.Drawing.Point(0, 0);
            this.orderGrBx.Name = "orderGrBx";
            this.orderGrBx.Size = new System.Drawing.Size(1924, 832);
            this.orderGrBx.TabIndex = 2;
            this.orderGrBx.TabStop = false;
            // 
            // moveProductIntoDbBtn
            // 
            this.moveProductIntoDbBtn.BackColor = System.Drawing.Color.White;
            this.moveProductIntoDbBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.moveProductIntoDbBtn.Location = new System.Drawing.Point(15, 680);
            this.moveProductIntoDbBtn.Name = "moveProductIntoDbBtn";
            this.moveProductIntoDbBtn.Size = new System.Drawing.Size(171, 45);
            this.moveProductIntoDbBtn.TabIndex = 11;
            this.moveProductIntoDbBtn.Text = "Chuyển hàng vào kho";
            this.moveProductIntoDbBtn.UseVisualStyleBackColor = false;
            this.moveProductIntoDbBtn.Click += new System.EventHandler(this.moveProductIntoDbBtn_Click);
            // 
            // cancelledBtn
            // 
            this.cancelledBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cancelledBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.cancelledBtn.Location = new System.Drawing.Point(967, 680);
            this.cancelledBtn.Name = "cancelledBtn";
            this.cancelledBtn.Size = new System.Drawing.Size(171, 45);
            this.cancelledBtn.TabIndex = 10;
            this.cancelledBtn.Text = "Hủy đơn nhập hàng";
            this.cancelledBtn.UseVisualStyleBackColor = false;
            this.cancelledBtn.Click += new System.EventHandler(this.cancelledBtn_Click);
            // 
            // purchasedBtn
            // 
            this.purchasedBtn.BackColor = System.Drawing.Color.White;
            this.purchasedBtn.ForeColor = System.Drawing.Color.Green;
            this.purchasedBtn.Location = new System.Drawing.Point(786, 680);
            this.purchasedBtn.Name = "purchasedBtn";
            this.purchasedBtn.Size = new System.Drawing.Size(171, 45);
            this.purchasedBtn.TabIndex = 9;
            this.purchasedBtn.Text = "Xác nhận thanh toán";
            this.purchasedBtn.UseVisualStyleBackColor = false;
            this.purchasedBtn.Click += new System.EventHandler(this.purchasedBtn_Click);
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
            this.label3.Size = new System.Drawing.Size(152, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Danh sách nhập hàng:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.noteStatusTxt);
            this.groupBox1.Controls.Add(this.supplierListCbx);
            this.groupBox1.Controls.Add(this.totalPriceTxt);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.receiptDateDTP);
            this.groupBox1.Controls.Add(this.employeeTxt);
            this.groupBox1.Controls.Add(this.addReceiptInfoBtn);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(1155, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 554);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm đơn nhập hàng";
            // 
            // noteStatusTxt
            // 
            this.noteStatusTxt.AutoSize = true;
            this.noteStatusTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noteStatusTxt.Location = new System.Drawing.Point(207, 134);
            this.noteStatusTxt.Name = "noteStatusTxt";
            this.noteStatusTxt.Size = new System.Drawing.Size(119, 17);
            this.noteStatusTxt.TabIndex = 15;
            this.noteStatusTxt.Text = "Chờ thanh toán";
            // 
            // supplierListCbx
            // 
            this.supplierListCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.supplierListCbx.FormattingEnabled = true;
            this.supplierListCbx.Items.AddRange(new object[] {
            "Chọn nhà cung cấp"});
            this.supplierListCbx.Location = new System.Drawing.Point(210, 29);
            this.supplierListCbx.Name = "supplierListCbx";
            this.supplierListCbx.Size = new System.Drawing.Size(240, 24);
            this.supplierListCbx.TabIndex = 14;
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
            this.groupBox2.Controls.Add(this.dgvReceiptDetails);
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
            this.deleteProductBtn.Click += new System.EventHandler(this.deleteProductBtn_Click_1);
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
            // dgvReceiptDetails
            // 
            this.dgvReceiptDetails.AllowUserToAddRows = false;
            this.dgvReceiptDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReceiptDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceiptDetails.Location = new System.Drawing.Point(6, 103);
            this.dgvReceiptDetails.Name = "dgvReceiptDetails";
            this.dgvReceiptDetails.ReadOnly = true;
            this.dgvReceiptDetails.Size = new System.Drawing.Size(570, 175);
            this.dgvReceiptDetails.TabIndex = 10;
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
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click_1);
            // 
            // receiptDateDTP
            // 
            this.receiptDateDTP.Location = new System.Drawing.Point(210, 99);
            this.receiptDateDTP.Name = "receiptDateDTP";
            this.receiptDateDTP.Size = new System.Drawing.Size(200, 23);
            this.receiptDateDTP.TabIndex = 11;
            // 
            // employeeTxt
            // 
            this.employeeTxt.Location = new System.Drawing.Point(210, 64);
            this.employeeTxt.Name = "employeeTxt";
            this.employeeTxt.ReadOnly = true;
            this.employeeTxt.Size = new System.Drawing.Size(169, 23);
            this.employeeTxt.TabIndex = 2;
            // 
            // addReceiptInfoBtn
            // 
            this.addReceiptInfoBtn.Location = new System.Drawing.Point(22, 510);
            this.addReceiptInfoBtn.Name = "addReceiptInfoBtn";
            this.addReceiptInfoBtn.Size = new System.Drawing.Size(191, 38);
            this.addReceiptInfoBtn.TabIndex = 6;
            this.addReceiptInfoBtn.Text = "Lưu đơn nhập hàng";
            this.addReceiptInfoBtn.UseVisualStyleBackColor = true;
            this.addReceiptInfoBtn.Click += new System.EventHandler(this.addOrderInfoBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Tình trạng:";
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
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhà cung cấp:";
            // 
            // receiptDgv
            // 
            this.receiptDgv.AllowUserToAddRows = false;
            this.receiptDgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.receiptDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.receiptDgv.Location = new System.Drawing.Point(15, 110);
            this.receiptDgv.MultiSelect = false;
            this.receiptDgv.Name = "receiptDgv";
            this.receiptDgv.ReadOnly = true;
            this.receiptDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.receiptDgv.Size = new System.Drawing.Size(1123, 545);
            this.receiptDgv.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(383, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "*Nhập mã nhập hàng, mã nhà cung cấp hoặc mã nhân viên";
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
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm nhập hàng:";
            // 
            // FormAddReceipt
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1924, 832);
            this.Controls.Add(this.orderGrBx);
            this.Name = "FormAddReceipt";
            this.Text = "FormAddReceipt";
            this.Load += new System.EventHandler(this.FormAddReceipt_Load);
            this.orderGrBx.ResumeLayout(false);
            this.orderGrBx.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptDgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox orderGrBx;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteProductBtn;
        private System.Windows.Forms.Button desQuantityBtn;
        private System.Windows.Forms.Button incQuantityBtn;
        private System.Windows.Forms.DataGridView dgvReceiptDetails;
        private System.Windows.Forms.ComboBox cbxProduct;
        private System.Windows.Forms.TextBox quantityTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.DateTimePicker receiptDateDTP;
        private System.Windows.Forms.TextBox employeeTxt;
        private System.Windows.Forms.Button addReceiptInfoBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView receiptDgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox searchTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label totalPriceTxt;
        private System.Windows.Forms.ComboBox supplierListCbx;
        private System.Windows.Forms.Label noteStatusTxt;
        private System.Windows.Forms.Button cancelledBtn;
        private System.Windows.Forms.Button purchasedBtn;
        private System.Windows.Forms.Button moveProductIntoDbBtn;
    }
}