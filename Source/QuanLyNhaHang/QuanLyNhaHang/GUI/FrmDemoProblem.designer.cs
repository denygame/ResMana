﻿namespace QuanLyNhaHang.GUI
{
    partial class FrmDemoProblem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.panel48 = new System.Windows.Forms.Panel();
            this.txtTrangNhanVien = new System.Windows.Forms.TextBox();
            this.btnTrangTruocNhanVien = new System.Windows.Forms.Button();
            this.btnTrangSauNhanVien = new System.Windows.Forms.Button();
            this.btnThemNhanVien = new System.Windows.Forms.Button();
            this.btnXoaNhanVien = new System.Windows.Forms.Button();
            this.btnXemNhanVien = new System.Windows.Forms.Button();
            this.panel47 = new System.Windows.Forms.Panel();
            this.btnKtheDocLai = new System.Windows.Forms.Button();
            this.btnTongNhanVien = new System.Windows.Forms.Button();
            this.rB_Poke = new System.Windows.Forms.RadioButton();
            this.rB_Wait = new System.Windows.Forms.RadioButton();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnFix = new System.Windows.Forms.Button();
            this.cbProblem = new System.Windows.Forms.ComboBox();
            this.dataGridView_NhanVien = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dEMOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhanVien);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(837, 479);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNhanVien
            // 
            this.tabNhanVien.Controls.Add(this.panel48);
            this.tabNhanVien.Controls.Add(this.panel47);
            this.tabNhanVien.Location = new System.Drawing.Point(4, 22);
            this.tabNhanVien.Name = "tabNhanVien";
            this.tabNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhanVien.Size = new System.Drawing.Size(829, 453);
            this.tabNhanVien.TabIndex = 6;
            this.tabNhanVien.Text = "Nhân Viên";
            this.tabNhanVien.UseVisualStyleBackColor = true;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.txtTrangNhanVien);
            this.panel48.Controls.Add(this.btnTrangTruocNhanVien);
            this.panel48.Controls.Add(this.btnTrangSauNhanVien);
            this.panel48.Controls.Add(this.btnThemNhanVien);
            this.panel48.Controls.Add(this.btnXoaNhanVien);
            this.panel48.Controls.Add(this.btnXemNhanVien);
            this.panel48.Location = new System.Drawing.Point(0, 398);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(829, 55);
            this.panel48.TabIndex = 1;
            // 
            // txtTrangNhanVien
            // 
            this.txtTrangNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangNhanVien.Location = new System.Drawing.Point(618, 17);
            this.txtTrangNhanVien.Name = "txtTrangNhanVien";
            this.txtTrangNhanVien.ReadOnly = true;
            this.txtTrangNhanVien.Size = new System.Drawing.Size(71, 27);
            this.txtTrangNhanVien.TabIndex = 6;
            this.txtTrangNhanVien.Text = "1";
            this.txtTrangNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTrangNhanVien.TextChanged += new System.EventHandler(this.txtTrangNhanVien_TextChanged);
            // 
            // btnTrangTruocNhanVien
            // 
            this.btnTrangTruocNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangTruocNhanVien.ForeColor = System.Drawing.Color.Blue;
            this.btnTrangTruocNhanVien.Location = new System.Drawing.Point(484, 14);
            this.btnTrangTruocNhanVien.Name = "btnTrangTruocNhanVien";
            this.btnTrangTruocNhanVien.Size = new System.Drawing.Size(128, 32);
            this.btnTrangTruocNhanVien.TabIndex = 5;
            this.btnTrangTruocNhanVien.Text = "Trang Trước";
            this.btnTrangTruocNhanVien.UseVisualStyleBackColor = true;
            this.btnTrangTruocNhanVien.Click += new System.EventHandler(this.btnTrangTruocNhanVien_Click);
            // 
            // btnTrangSauNhanVien
            // 
            this.btnTrangSauNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangSauNhanVien.ForeColor = System.Drawing.Color.Blue;
            this.btnTrangSauNhanVien.Location = new System.Drawing.Point(695, 14);
            this.btnTrangSauNhanVien.Name = "btnTrangSauNhanVien";
            this.btnTrangSauNhanVien.Size = new System.Drawing.Size(128, 32);
            this.btnTrangSauNhanVien.TabIndex = 7;
            this.btnTrangSauNhanVien.Text = "Trang Sau";
            this.btnTrangSauNhanVien.UseVisualStyleBackColor = true;
            this.btnTrangSauNhanVien.Click += new System.EventHandler(this.btnTrangSauNhanVien_Click);
            // 
            // btnThemNhanVien
            // 
            this.btnThemNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnThemNhanVien.ForeColor = System.Drawing.Color.Blue;
            this.btnThemNhanVien.Location = new System.Drawing.Point(70, 3);
            this.btnThemNhanVien.Name = "btnThemNhanVien";
            this.btnThemNhanVien.Size = new System.Drawing.Size(75, 50);
            this.btnThemNhanVien.TabIndex = 2;
            this.btnThemNhanVien.Text = "Thêm";
            this.btnThemNhanVien.UseVisualStyleBackColor = true;
            this.btnThemNhanVien.Click += new System.EventHandler(this.btnThemNhanVien_Click);
            // 
            // btnXoaNhanVien
            // 
            this.btnXoaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnXoaNhanVien.ForeColor = System.Drawing.Color.Red;
            this.btnXoaNhanVien.Location = new System.Drawing.Point(170, 3);
            this.btnXoaNhanVien.Name = "btnXoaNhanVien";
            this.btnXoaNhanVien.Size = new System.Drawing.Size(75, 50);
            this.btnXoaNhanVien.TabIndex = 3;
            this.btnXoaNhanVien.Text = "Xóa";
            this.btnXoaNhanVien.UseVisualStyleBackColor = true;
            this.btnXoaNhanVien.Click += new System.EventHandler(this.btnXoaNhanVien_Click);
            // 
            // btnXemNhanVien
            // 
            this.btnXemNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)), true);
            this.btnXemNhanVien.ForeColor = System.Drawing.Color.Blue;
            this.btnXemNhanVien.Location = new System.Drawing.Point(270, 3);
            this.btnXemNhanVien.Name = "btnXemNhanVien";
            this.btnXemNhanVien.Size = new System.Drawing.Size(75, 50);
            this.btnXemNhanVien.TabIndex = 4;
            this.btnXemNhanVien.Text = "Xem";
            this.btnXemNhanVien.UseVisualStyleBackColor = true;
            this.btnXemNhanVien.Click += new System.EventHandler(this.btnXemNhanVien_Click);
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.btnKtheDocLai);
            this.panel47.Controls.Add(this.btnTongNhanVien);
            this.panel47.Controls.Add(this.rB_Poke);
            this.panel47.Controls.Add(this.rB_Wait);
            this.panel47.Controls.Add(this.btnHuy);
            this.panel47.Controls.Add(this.btnFix);
            this.panel47.Controls.Add(this.cbProblem);
            this.panel47.Controls.Add(this.dataGridView_NhanVien);
            this.panel47.Location = new System.Drawing.Point(0, 0);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(829, 392);
            this.panel47.TabIndex = 0;
            // 
            // btnKtheDocLai
            // 
            this.btnKtheDocLai.BackColor = System.Drawing.Color.Silver;
            this.btnKtheDocLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKtheDocLai.ForeColor = System.Drawing.Color.Red;
            this.btnKtheDocLai.Location = new System.Drawing.Point(618, 3);
            this.btnKtheDocLai.Name = "btnKtheDocLai";
            this.btnKtheDocLai.Size = new System.Drawing.Size(74, 49);
            this.btnKtheDocLai.TabIndex = 10;
            this.btnKtheDocLai.Text = "Không Đọc Lại";
            this.btnKtheDocLai.UseVisualStyleBackColor = false;
            this.btnKtheDocLai.Click += new System.EventHandler(this.btnKtheDocLai_Click);
            // 
            // btnTongNhanVien
            // 
            this.btnTongNhanVien.BackColor = System.Drawing.Color.Silver;
            this.btnTongNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongNhanVien.ForeColor = System.Drawing.Color.Red;
            this.btnTongNhanVien.Location = new System.Drawing.Point(538, 3);
            this.btnTongNhanVien.Name = "btnTongNhanVien";
            this.btnTongNhanVien.Size = new System.Drawing.Size(74, 49);
            this.btnTongNhanVien.TabIndex = 9;
            this.btnTongNhanVien.Text = "Tổng NV";
            this.btnTongNhanVien.UseVisualStyleBackColor = false;
            this.btnTongNhanVien.Click += new System.EventHandler(this.btnTongNhanVien_Click);
            // 
            // rB_Poke
            // 
            this.rB_Poke.AutoSize = true;
            this.rB_Poke.Location = new System.Drawing.Point(705, 35);
            this.rB_Poke.Name = "rB_Poke";
            this.rB_Poke.Size = new System.Drawing.Size(87, 17);
            this.rB_Poke.TabIndex = 8;
            this.rB_Poke.TabStop = true;
            this.rB_Poke.Text = "Thread Poke";
            this.rB_Poke.UseVisualStyleBackColor = true;
            // 
            // rB_Wait
            // 
            this.rB_Wait.AutoSize = true;
            this.rB_Wait.Location = new System.Drawing.Point(705, 6);
            this.rB_Wait.Name = "rB_Wait";
            this.rB_Wait.Size = new System.Drawing.Size(84, 17);
            this.rB_Wait.TabIndex = 7;
            this.rB_Wait.TabStop = true;
            this.rB_Wait.Text = "Thread Wait";
            this.rB_Wait.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Silver;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.Color.Red;
            this.btnHuy.Location = new System.Drawing.Point(92, 13);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(59, 28);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnFix
            // 
            this.btnFix.BackColor = System.Drawing.Color.Silver;
            this.btnFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFix.ForeColor = System.Drawing.Color.Red;
            this.btnFix.Location = new System.Drawing.Point(27, 13);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(59, 28);
            this.btnFix.TabIndex = 5;
            this.btnFix.Text = "FIX";
            this.btnFix.UseVisualStyleBackColor = false;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // cbProblem
            // 
            this.cbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProblem.FormattingEnabled = true;
            this.cbProblem.Location = new System.Drawing.Point(212, 13);
            this.cbProblem.Name = "cbProblem";
            this.cbProblem.Size = new System.Drawing.Size(304, 28);
            this.cbProblem.TabIndex = 4;
            this.cbProblem.SelectedIndexChanged += new System.EventHandler(this.cbProblem_SelectedIndexChanged);
            // 
            // dataGridView_NhanVien
            // 
            this.dataGridView_NhanVien.AllowUserToAddRows = false;
            this.dataGridView_NhanVien.AllowUserToDeleteRows = false;
            this.dataGridView_NhanVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_NhanVien.Location = new System.Drawing.Point(0, 58);
            this.dataGridView_NhanVien.Name = "dataGridView_NhanVien";
            this.dataGridView_NhanVien.ReadOnly = true;
            this.dataGridView_NhanVien.Size = new System.Drawing.Size(829, 331);
            this.dataGridView_NhanVien.TabIndex = 1;
            this.dataGridView_NhanVien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_NhanVien_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(829, 453);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Hướng Dẫn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(534, 380);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(184, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Vấn đề không thể đọc lại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(474, 100);
            this.label8.TabIndex = 7;
            this.label8.Text = "+ Mở 2 chương trình, chọn Vấn đề không thể đọc lại\r\n\r\n+ 1 chương trình click Khôn" +
    "g Đọc Lại ( hàm show 2 lần tên của nv )\r\n\r\n+ 1 chương trình trong lúc đó update " +
    "tên nhân viên của Staff đó";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(333, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(448, 100);
            this.label6.TabIndex = 6;
            this.label6.Text = "+ Mở 2 chương trình, chọn Vấn đề mất dữ liệu đã cập nhật\r\n\r\n+ 1 chọn Thread Wait," +
    " 1 chọn Thread Poke\r\n\r\n+ 2 ct cùng update Staff ( Wait update 1 tt, Poke chừa tt" +
    " đó ra)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(65, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Vấn đề mất dữ liệu đã cập nhật";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(407, 100);
            this.label4.TabIndex = 4;
            this.label4.Text = "+ Mở 2 chương trình, chọn Vấn đề bóng ma dữ liệu\r\n\r\n+ 1 chương trình click TổngNV" +
    " ( hàm show 2 lần tổng nv )\r\n\r\n+ 1 chương trình trong lúc đó thêm vào Staff";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(534, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Vấn đề bóng ma dữ liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(306, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(475, 60);
            this.label3.TabIndex = 2;
            this.label3.Text = "+ Mở 2 chương trình, chọn Vấn đề đọc dữ liệu rác\r\n\r\n+ 1 chương trình thêm vào Sta" +
    "ff, 1 chương trình xem ngay lúc thêm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(81, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vấn đề đọc dữ liệu rác";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(256, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hướng Dẫn Demo Problem";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dEMOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(861, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dEMOToolStripMenuItem
            // 
            this.dEMOToolStripMenuItem.Name = "dEMOToolStripMenuItem";
            this.dEMOToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.dEMOToolStripMenuItem.Text = "DEMO";
            this.dEMOToolStripMenuItem.Click += new System.EventHandler(this.dEMOToolStripMenuItem_Click_1);
            // 
            // FrmDemoProblem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 524);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmDemoProblem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Demo Problem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDemoProblem_FormClosing);
            this.Load += new System.EventHandler(this.FrmSystem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhanVien;
        private System.Windows.Forms.Panel panel48;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.Button btnThemNhanVien;
        private System.Windows.Forms.Button btnXoaNhanVien;
        private System.Windows.Forms.Button btnXemNhanVien;
        private System.Windows.Forms.TextBox txtTrangNhanVien;
        private System.Windows.Forms.Button btnTrangTruocNhanVien;
        private System.Windows.Forms.Button btnTrangSauNhanVien;
        private System.Windows.Forms.DataGridView dataGridView_NhanVien;
        private System.Windows.Forms.ComboBox cbProblem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dEMOToolStripMenuItem;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.RadioButton rB_Poke;
        private System.Windows.Forms.RadioButton rB_Wait;
        private System.Windows.Forms.Button btnTongNhanVien;
        private System.Windows.Forms.Button btnKtheDocLai;
    }
}