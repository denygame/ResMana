namespace QuanLyNhaHang.GUI
{
    partial class FrmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBoxPass = new System.Windows.Forms.CheckBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(396, 248);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThoat);
            this.panel4.Controls.Add(this.btnDangNhap);
            this.panel4.Location = new System.Drawing.Point(0, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 38);
            this.panel4.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(288, 6);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(90, 29);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.Blue;
            this.btnDangNhap.Location = new System.Drawing.Point(190, 6);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(90, 29);
            this.btnDangNhap.TabIndex = 0;
            this.btnDangNhap.Text = "OK";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(345, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "PHẦN MỀM QUẢN LÝ NHÀ HÀNG";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBoxPass);
            this.panel3.Controls.Add(this.txtPassWord);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(390, 78);
            this.panel3.TabIndex = 1;
            // 
            // checkBoxPass
            // 
            this.checkBoxPass.AutoSize = true;
            this.checkBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPass.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxPass.Location = new System.Drawing.Point(199, 53);
            this.checkBoxPass.Name = "checkBoxPass";
            this.checkBoxPass.Size = new System.Drawing.Size(148, 22);
            this.checkBoxPass.TabIndex = 2;
            this.checkBoxPass.Text = "Hiển Thị Mật Khẩu";
            this.checkBoxPass.UseVisualStyleBackColor = true;
            this.checkBoxPass.CheckedChanged += new System.EventHandler(this.checkBoxPass_CheckedChanged);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassWord.Location = new System.Drawing.Point(158, 13);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(217, 26);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(33, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật Khẩu:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(390, 50);
            this.panel2.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(158, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(217, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Đăng Nhập:";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnThoat;
            this.ClientSize = new System.Drawing.Size(420, 273);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.CheckBox checkBoxPass;
    }
}