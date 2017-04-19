namespace QuanLyNhaHang.GUI
{
    partial class FrmAccountProfile
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
            this.panel_doiMK = new System.Windows.Forms.Panel();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_changePass = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.checkBox_showPass = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel_doiMK.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_doiMK);
            this.panel1.Controls.Add(this.checkBox_changePass);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(385, 383);
            this.panel1.TabIndex = 0;
            // 
            // panel_doiMK
            // 
            this.panel_doiMK.Controls.Add(this.checkBox_showPass);
            this.panel_doiMK.Controls.Add(this.btnCapNhat);
            this.panel_doiMK.Controls.Add(this.panel5);
            this.panel_doiMK.Controls.Add(this.panel3);
            this.panel_doiMK.Controls.Add(this.panel4);
            this.panel_doiMK.Location = new System.Drawing.Point(3, 100);
            this.panel_doiMK.Name = "panel_doiMK";
            this.panel_doiMK.Size = new System.Drawing.Size(378, 283);
            this.panel_doiMK.TabIndex = 3;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.Blue;
            this.btnCapNhat.Location = new System.Drawing.Point(0, 228);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(378, 36);
            this.btnCapNhat.TabIndex = 7;
            this.btnCapNhat.Text = "Cập Nhật Mật Khẩu";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtConfirm);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(0, 142);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(378, 50);
            this.panel5.TabIndex = 4;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.ForeColor = System.Drawing.Color.Black;
            this.txtConfirm.Location = new System.Drawing.Point(145, 13);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(193, 26);
            this.txtConfirm.TabIndex = 5;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(27, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nhập Lại:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNewPass);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(0, 86);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(378, 50);
            this.panel3.TabIndex = 3;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.ForeColor = System.Drawing.Color.Black;
            this.txtNewPass.Location = new System.Drawing.Point(145, 13);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(193, 26);
            this.txtNewPass.TabIndex = 4;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(15, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật Khẩu Mới:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtOldPass);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(0, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(378, 50);
            this.panel4.TabIndex = 2;
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPass.ForeColor = System.Drawing.Color.Black;
            this.txtOldPass.Location = new System.Drawing.Point(145, 13);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Size = new System.Drawing.Size(193, 26);
            this.txtOldPass.TabIndex = 3;
            this.txtOldPass.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật Khẩu Cũ:";
            // 
            // checkBox_changePass
            // 
            this.checkBox_changePass.AutoSize = true;
            this.checkBox_changePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_changePass.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_changePass.Location = new System.Drawing.Point(131, 70);
            this.checkBox_changePass.Name = "checkBox_changePass";
            this.checkBox_changePass.Size = new System.Drawing.Size(122, 24);
            this.checkBox_changePass.TabIndex = 2;
            this.checkBox_changePass.Text = "Đổi mật khẩu";
            this.checkBox_changePass.UseVisualStyleBackColor = true;
            this.checkBox_changePass.CheckedChanged += new System.EventHandler(this.checkBox_changePass_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUserName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 50);
            this.panel2.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Red;
            this.txtUserName.Location = new System.Drawing.Point(145, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(193, 26);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUserName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(36, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản:";
            // 
            // btnThoat
            // 
            this.btnThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(223, 389);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(158, 29);
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // checkBox_showPass
            // 
            this.checkBox_showPass.AutoSize = true;
            this.checkBox_showPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_showPass.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_showPass.Location = new System.Drawing.Point(113, 198);
            this.checkBox_showPass.Name = "checkBox_showPass";
            this.checkBox_showPass.Size = new System.Drawing.Size(152, 24);
            this.checkBox_showPass.TabIndex = 6;
            this.checkBox_showPass.Text = "Hiển thị mật khẩu";
            this.checkBox_showPass.UseVisualStyleBackColor = true;
            this.checkBox_showPass.CheckedChanged += new System.EventHandler(this.checkBox_showPass_CheckedChanged);
            // 
            // FrmAccountProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 424);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmAccountProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tài Khoản";
            this.Load += new System.EventHandler(this.FrmAccountProfile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_doiMK.ResumeLayout(false);
            this.panel_doiMK.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_changePass;
        private System.Windows.Forms.Panel panel_doiMK;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.CheckBox checkBox_showPass;
    }
}