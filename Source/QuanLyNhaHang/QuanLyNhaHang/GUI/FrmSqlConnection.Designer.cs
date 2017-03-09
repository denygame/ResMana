namespace QuanLyNhaHang.GUI
{
    partial class FrmSqlConnection
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
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxPass = new System.Windows.Forms.CheckBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTenServer = new System.Windows.Forms.TextBox();
            this.checkBoxXacThuc = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnXoaDatabase = new System.Windows.Forms.Button();
            this.btnChaySql = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLayServerName = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 341);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnThoat);
            this.panel6.Controls.Add(this.btnKetNoi);
            this.panel6.Location = new System.Drawing.Point(3, 270);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(372, 55);
            this.panel6.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(228, 3);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(98, 49);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.ForeColor = System.Drawing.Color.Blue;
            this.btnKetNoi.Location = new System.Drawing.Point(42, 3);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(98, 49);
            this.btnKetNoi.TabIndex = 0;
            this.btnKetNoi.Text = "Kết Nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Location = new System.Drawing.Point(4, 120);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(371, 144);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBoxPass);
            this.panel4.Controls.Add(this.txtPassWord);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(3, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(365, 78);
            this.panel4.TabIndex = 3;
            // 
            // checkBoxPass
            // 
            this.checkBoxPass.AutoSize = true;
            this.checkBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPass.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxPass.Location = new System.Drawing.Point(185, 53);
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
            this.txtPassWord.Size = new System.Drawing.Size(195, 26);
            this.txtPassWord.TabIndex = 1;
            this.txtPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(32, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật Khẩu:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtUserName);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(365, 50);
            this.panel5.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(158, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(195, 26);
            this.txtUserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(11, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên Đăng Nhập:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtTenServer);
            this.panel2.Controls.Add(this.checkBoxXacThuc);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 111);
            this.panel2.TabIndex = 0;
            // 
            // txtTenServer
            // 
            this.txtTenServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenServer.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTenServer.Location = new System.Drawing.Point(40, 49);
            this.txtTenServer.Name = "txtTenServer";
            this.txtTenServer.Size = new System.Drawing.Size(297, 26);
            this.txtTenServer.TabIndex = 3;
            this.txtTenServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBoxXacThuc
            // 
            this.checkBoxXacThuc.AutoSize = true;
            this.checkBoxXacThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxXacThuc.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxXacThuc.Location = new System.Drawing.Point(100, 86);
            this.checkBoxXacThuc.Name = "checkBoxXacThuc";
            this.checkBoxXacThuc.Size = new System.Drawing.Size(166, 22);
            this.checkBoxXacThuc.TabIndex = 2;
            this.checkBoxXacThuc.Text = "Xác thực SQL Server";
            this.checkBoxXacThuc.UseVisualStyleBackColor = true;
            this.checkBoxXacThuc.CheckedChanged += new System.EventHandler(this.checkBoxXacThuc_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(107, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÊN SERVER";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnLayServerName);
            this.panel7.Controls.Add(this.btnXoaDatabase);
            this.panel7.Controls.Add(this.btnChaySql);
            this.panel7.Controls.Add(this.label4);
            this.panel7.Location = new System.Drawing.Point(12, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(379, 60);
            this.panel7.TabIndex = 2;
            // 
            // btnXoaDatabase
            // 
            this.btnXoaDatabase.ForeColor = System.Drawing.Color.Blue;
            this.btnXoaDatabase.Location = new System.Drawing.Point(144, 21);
            this.btnXoaDatabase.Name = "btnXoaDatabase";
            this.btnXoaDatabase.Size = new System.Drawing.Size(93, 23);
            this.btnXoaDatabase.TabIndex = 2;
            this.btnXoaDatabase.Text = "Drop Database";
            this.btnXoaDatabase.UseVisualStyleBackColor = true;
            this.btnXoaDatabase.Click += new System.EventHandler(this.btnXoaDatabase_Click);
            // 
            // btnChaySql
            // 
            this.btnChaySql.ForeColor = System.Drawing.Color.Blue;
            this.btnChaySql.Location = new System.Drawing.Point(45, 21);
            this.btnChaySql.Name = "btnChaySql";
            this.btnChaySql.Size = new System.Drawing.Size(93, 23);
            this.btnChaySql.TabIndex = 1;
            this.btnChaySql.Text = "Execute SQL";
            this.btnChaySql.UseVisualStyleBackColor = true;
            this.btnChaySql.Click += new System.EventHandler(this.btnChaySql_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Test";
            // 
            // btnLayServerName
            // 
            this.btnLayServerName.ForeColor = System.Drawing.Color.Blue;
            this.btnLayServerName.Location = new System.Drawing.Point(243, 21);
            this.btnLayServerName.Name = "btnLayServerName";
            this.btnLayServerName.Size = new System.Drawing.Size(93, 23);
            this.btnLayServerName.TabIndex = 3;
            this.btnLayServerName.Text = "Server Name";
            this.btnLayServerName.UseVisualStyleBackColor = true;
            this.btnLayServerName.Click += new System.EventHandler(this.btnLayServerName_Click);
            // 
            // FrmSqlConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 432);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmSqlConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết Nối Server SQL";
            this.Load += new System.EventHandler(this.FrmSqlConnection_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxXacThuc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox checkBoxPass;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.TextBox txtTenServer;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnChaySql;
        private System.Windows.Forms.Button btnXoaDatabase;
        private System.Windows.Forms.Button btnLayServerName;
    }
}