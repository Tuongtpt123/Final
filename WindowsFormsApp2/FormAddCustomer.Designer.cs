namespace WindowsFormsApp2
{
    partial class FormAddCustomer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveCustomerBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.customerNameTxt = new System.Windows.Forms.TextBox();
            this.customerIdTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.saveCustomerBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.customerNameTxt);
            this.groupBox1.Controls.Add(this.customerIdTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // saveCustomerBtn
            // 
            this.saveCustomerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveCustomerBtn.Location = new System.Drawing.Point(462, 311);
            this.saveCustomerBtn.Name = "saveCustomerBtn";
            this.saveCustomerBtn.Size = new System.Drawing.Size(103, 43);
            this.saveCustomerBtn.TabIndex = 2;
            this.saveCustomerBtn.Text = "Lưu";
            this.saveCustomerBtn.UseVisualStyleBackColor = true;
            this.saveCustomerBtn.Click += new System.EventHandler(this.saveCustomerBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(257, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Thêm thông tin khách hàng";
            // 
            // customerNameTxt
            // 
            this.customerNameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameTxt.Location = new System.Drawing.Point(203, 237);
            this.customerNameTxt.Name = "customerNameTxt";
            this.customerNameTxt.Size = new System.Drawing.Size(362, 26);
            this.customerNameTxt.TabIndex = 1;
            // 
            // customerIdTxt
            // 
            this.customerIdTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerIdTxt.Location = new System.Drawing.Point(203, 151);
            this.customerIdTxt.Name = "customerIdTxt";
            this.customerIdTxt.Size = new System.Drawing.Size(362, 26);
            this.customerIdTxt.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Họ và tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Số điện thoại:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(200, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "*Tối đa 50 ký tự";
            // 
            // FormAddCustomer
            // 
            this.AcceptButton = this.saveCustomerBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormAddCustomer";
            this.Text = "FormAddCustomer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveCustomerBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customerNameTxt;
        private System.Windows.Forms.TextBox customerIdTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}