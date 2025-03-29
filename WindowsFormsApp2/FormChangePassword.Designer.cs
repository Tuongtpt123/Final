namespace WindowsFormsApp2
{
    partial class FormChangePassword
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
            this.notilbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentPasstxt = new System.Windows.Forms.TextBox();
            this.newPasstxt = new System.Windows.Forms.TextBox();
            this.confirmNewPasstxt = new System.Windows.Forms.TextBox();
            this.saveChangeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // notilbl
            // 
            this.notilbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.notilbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notilbl.Location = new System.Drawing.Point(12, 35);
            this.notilbl.Name = "notilbl";
            this.notilbl.Size = new System.Drawing.Size(560, 23);
            this.notilbl.TabIndex = 0;
            this.notilbl.Text = "Thay đổi mật khẩu cho: username";
            this.notilbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu hiện tại:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu mới:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Xác nhận mật khẩu mới:";
            // 
            // currentPasstxt
            // 
            this.currentPasstxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.currentPasstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPasstxt.Location = new System.Drawing.Point(195, 112);
            this.currentPasstxt.Name = "currentPasstxt";
            this.currentPasstxt.PasswordChar = '*';
            this.currentPasstxt.Size = new System.Drawing.Size(182, 23);
            this.currentPasstxt.TabIndex = 0;
            // 
            // newPasstxt
            // 
            this.newPasstxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newPasstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasstxt.Location = new System.Drawing.Point(195, 152);
            this.newPasstxt.Name = "newPasstxt";
            this.newPasstxt.PasswordChar = '*';
            this.newPasstxt.Size = new System.Drawing.Size(182, 23);
            this.newPasstxt.TabIndex = 1;
            // 
            // confirmNewPasstxt
            // 
            this.confirmNewPasstxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmNewPasstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmNewPasstxt.Location = new System.Drawing.Point(194, 192);
            this.confirmNewPasstxt.Name = "confirmNewPasstxt";
            this.confirmNewPasstxt.PasswordChar = '*';
            this.confirmNewPasstxt.Size = new System.Drawing.Size(183, 23);
            this.confirmNewPasstxt.TabIndex = 2;
            // 
            // saveChangeBtn
            // 
            this.saveChangeBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveChangeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveChangeBtn.Location = new System.Drawing.Point(396, 249);
            this.saveChangeBtn.Name = "saveChangeBtn";
            this.saveChangeBtn.Size = new System.Drawing.Size(124, 32);
            this.saveChangeBtn.TabIndex = 3;
            this.saveChangeBtn.Text = "Lưu thay đổi";
            this.saveChangeBtn.UseVisualStyleBackColor = true;
            this.saveChangeBtn.Click += new System.EventHandler(this.saveChangeBtn_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(393, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Hiện mật khẩu";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // FormChangePassword
            // 
            this.AcceptButton = this.saveChangeBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveChangeBtn);
            this.Controls.Add(this.confirmNewPasstxt);
            this.Controls.Add(this.newPasstxt);
            this.Controls.Add(this.currentPasstxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.notilbl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormChangePassword";
            this.Text = "FormChangePassword";
            this.Load += new System.EventHandler(this.FormChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label notilbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox currentPasstxt;
        private System.Windows.Forms.TextBox newPasstxt;
        private System.Windows.Forms.TextBox confirmNewPasstxt;
        private System.Windows.Forms.Button saveChangeBtn;
        private System.Windows.Forms.Label label5;
    }
}