namespace QuanLyNhaHang
{
    partial class FrmManage
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
            this.flowLayoutPanel_BanAn = new System.Windows.Forms.FlowLayoutPanel();
            this.panelSanh = new System.Windows.Forms.Panel();
            this.btnDatCho = new System.Windows.Forms.Button();
            this.btnHuyBan = new System.Windows.Forms.Button();
            this.txtBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSanh = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.danhSachĐătChôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelHoaDon = new System.Windows.Forms.Panel();
            this.listView_HoaDon = new System.Windows.Forms.ListView();
            this.panelDkBan = new System.Windows.Forms.Panel();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.cbGopBan2 = new System.Windows.Forms.ComboBox();
            this.cbGopBan1 = new System.Windows.Forms.ComboBox();
            this.cbChuyenBan = new System.Windows.Forms.ComboBox();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.nUdGiamGia = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBoxXoa = new System.Windows.Forms.CheckBox();
            this.nUDslXoa = new System.Windows.Forms.NumericUpDown();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.panelSanh.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelHoaDon.SuspendLayout();
            this.panelDkBan.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdGiamGia)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDslXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_BanAn
            // 
            this.flowLayoutPanel_BanAn.AutoScroll = true;
            this.flowLayoutPanel_BanAn.Location = new System.Drawing.Point(12, 96);
            this.flowLayoutPanel_BanAn.Name = "flowLayoutPanel_BanAn";
            this.flowLayoutPanel_BanAn.Size = new System.Drawing.Size(682, 448);
            this.flowLayoutPanel_BanAn.TabIndex = 0;
            // 
            // panelSanh
            // 
            this.panelSanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSanh.Controls.Add(this.btnDatCho);
            this.panelSanh.Controls.Add(this.btnHuyBan);
            this.panelSanh.Controls.Add(this.txtBan);
            this.panelSanh.Controls.Add(this.label1);
            this.panelSanh.Controls.Add(this.cbSanh);
            this.panelSanh.Location = new System.Drawing.Point(12, 38);
            this.panelSanh.Name = "panelSanh";
            this.panelSanh.Size = new System.Drawing.Size(682, 52);
            this.panelSanh.TabIndex = 1;
            // 
            // btnDatCho
            // 
            this.btnDatCho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatCho.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDatCho.Location = new System.Drawing.Point(523, 3);
            this.btnDatCho.Name = "btnDatCho";
            this.btnDatCho.Size = new System.Drawing.Size(75, 45);
            this.btnDatCho.TabIndex = 4;
            this.btnDatCho.Text = "Đặt Chỗ";
            this.btnDatCho.UseVisualStyleBackColor = true;
            this.btnDatCho.Click += new System.EventHandler(this.btnDatCho_Click);
            // 
            // btnHuyBan
            // 
            this.btnHuyBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBan.ForeColor = System.Drawing.Color.Red;
            this.btnHuyBan.Location = new System.Drawing.Point(604, 3);
            this.btnHuyBan.Name = "btnHuyBan";
            this.btnHuyBan.Size = new System.Drawing.Size(75, 45);
            this.btnHuyBan.TabIndex = 5;
            this.btnHuyBan.Text = "Hủy Bàn";
            this.btnHuyBan.UseVisualStyleBackColor = true;
            // 
            // txtBan
            // 
            this.txtBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBan.Location = new System.Drawing.Point(320, 11);
            this.txtBan.Name = "txtBan";
            this.txtBan.ReadOnly = true;
            this.txtBan.Size = new System.Drawing.Size(164, 24);
            this.txtBan.TabIndex = 1;
            this.txtBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn Sảnh";
            // 
            // cbSanh
            // 
            this.cbSanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanh.FormattingEnabled = true;
            this.cbSanh.Location = new System.Drawing.Point(107, 9);
            this.cbSanh.Name = "cbSanh";
            this.cbSanh.Size = new System.Drawing.Size(174, 26);
            this.cbSanh.TabIndex = 0;
            this.cbSanh.SelectedIndexChanged += new System.EventHandler(this.cbSanh_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhSachĐătChôToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1116, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // danhSachĐătChôToolStripMenuItem
            // 
            this.danhSachĐătChôToolStripMenuItem.Name = "danhSachĐătChôToolStripMenuItem";
            this.danhSachĐătChôToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.danhSachĐătChôToolStripMenuItem.Text = "Danh Sách Đặt Chỗ";
            // 
            // panelHoaDon
            // 
            this.panelHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHoaDon.Controls.Add(this.listView_HoaDon);
            this.panelHoaDon.Location = new System.Drawing.Point(700, 96);
            this.panelHoaDon.Name = "panelHoaDon";
            this.panelHoaDon.Size = new System.Drawing.Size(404, 448);
            this.panelHoaDon.TabIndex = 3;
            // 
            // listView_HoaDon
            // 
            this.listView_HoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_HoaDon.Location = new System.Drawing.Point(3, 3);
            this.listView_HoaDon.Name = "listView_HoaDon";
            this.listView_HoaDon.Size = new System.Drawing.Size(398, 442);
            this.listView_HoaDon.TabIndex = 0;
            this.listView_HoaDon.UseCompatibleStateImageBehavior = false;
            // 
            // panelDkBan
            // 
            this.panelDkBan.Controls.Add(this.btnGopBan);
            this.panelDkBan.Controls.Add(this.cbGopBan2);
            this.panelDkBan.Controls.Add(this.cbGopBan1);
            this.panelDkBan.Controls.Add(this.cbChuyenBan);
            this.panelDkBan.Controls.Add(this.btnChuyenBan);
            this.panelDkBan.Location = new System.Drawing.Point(12, 550);
            this.panelDkBan.Name = "panelDkBan";
            this.panelDkBan.Size = new System.Drawing.Size(682, 62);
            this.panelDkBan.TabIndex = 4;
            // 
            // btnGopBan
            // 
            this.btnGopBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGopBan.Location = new System.Drawing.Point(351, 8);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(75, 45);
            this.btnGopBan.TabIndex = 4;
            this.btnGopBan.Text = "Gộp Bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            // 
            // cbGopBan2
            // 
            this.cbGopBan2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGopBan2.FormattingEnabled = true;
            this.cbGopBan2.Location = new System.Drawing.Point(547, 21);
            this.cbGopBan2.Name = "cbGopBan2";
            this.cbGopBan2.Size = new System.Drawing.Size(99, 21);
            this.cbGopBan2.TabIndex = 3;
            // 
            // cbGopBan1
            // 
            this.cbGopBan1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGopBan1.FormattingEnabled = true;
            this.cbGopBan1.Location = new System.Drawing.Point(442, 21);
            this.cbGopBan1.Name = "cbGopBan1";
            this.cbGopBan1.Size = new System.Drawing.Size(99, 21);
            this.cbGopBan1.TabIndex = 2;
            // 
            // cbChuyenBan
            // 
            this.cbChuyenBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuyenBan.FormattingEnabled = true;
            this.cbChuyenBan.Location = new System.Drawing.Point(36, 21);
            this.cbChuyenBan.Name = "cbChuyenBan";
            this.cbChuyenBan.Size = new System.Drawing.Size(99, 21);
            this.cbChuyenBan.TabIndex = 0;
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnChuyenBan.Location = new System.Drawing.Point(157, 8);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(75, 45);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển Bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Controls.Add(this.nUdGiamGia);
            this.panel1.Location = new System.Drawing.Point(700, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 62);
            this.panel1.TabIndex = 5;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(16, 6);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(195, 24);
            this.txtTongTien.TabIndex = 13;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(47, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Giảm Giá";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.Red;
            this.btnThanhToan.Location = new System.Drawing.Point(297, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(104, 56);
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            // 
            // nUdGiamGia
            // 
            this.nUdGiamGia.Location = new System.Drawing.Point(139, 35);
            this.nUdGiamGia.Name = "nUdGiamGia";
            this.nUdGiamGia.ReadOnly = true;
            this.nUdGiamGia.Size = new System.Drawing.Size(47, 20);
            this.nUdGiamGia.TabIndex = 10;
            this.nUdGiamGia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBoxXoa);
            this.panel2.Controls.Add(this.nUDslXoa);
            this.panel2.Controls.Add(this.btnXoaMon);
            this.panel2.Controls.Add(this.btnThemMon);
            this.panel2.Location = new System.Drawing.Point(700, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(404, 52);
            this.panel2.TabIndex = 6;
            // 
            // checkBoxXoa
            // 
            this.checkBoxXoa.AutoSize = true;
            this.checkBoxXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxXoa.ForeColor = System.Drawing.Color.Blue;
            this.checkBoxXoa.Location = new System.Drawing.Point(266, 3);
            this.checkBoxXoa.Name = "checkBoxXoa";
            this.checkBoxXoa.Size = new System.Drawing.Size(111, 17);
            this.checkBoxXoa.TabIndex = 1;
            this.checkBoxXoa.Text = "Xóa Hết Món Này";
            this.checkBoxXoa.UseVisualStyleBackColor = true;
            this.checkBoxXoa.CheckedChanged += new System.EventHandler(this.checkBoxXoa_CheckedChanged);
            // 
            // nUDslXoa
            // 
            this.nUDslXoa.Location = new System.Drawing.Point(297, 26);
            this.nUDslXoa.Name = "nUDslXoa";
            this.nUDslXoa.ReadOnly = true;
            this.nUDslXoa.Size = new System.Drawing.Size(47, 20);
            this.nUDslXoa.TabIndex = 2;
            this.nUDslXoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnXoaMon.Location = new System.Drawing.Point(174, 3);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(75, 45);
            this.btnXoaMon.TabIndex = 3;
            this.btnXoaMon.Text = "Xóa Món";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnThemMon.Location = new System.Drawing.Point(35, 3);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(75, 45);
            this.btnThemMon.TabIndex = 0;
            this.btnThemMon.Text = "Thêm Món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // FrmManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDkBan);
            this.Controls.Add(this.panelHoaDon);
            this.Controls.Add(this.panelSanh);
            this.Controls.Add(this.flowLayoutPanel_BanAn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Nhà Hàng";
            this.panelSanh.ResumeLayout(false);
            this.panelSanh.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelHoaDon.ResumeLayout(false);
            this.panelDkBan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUdGiamGia)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDslXoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_BanAn;
        private System.Windows.Forms.Panel panelSanh;
        private System.Windows.Forms.ComboBox cbSanh;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBan;
        private System.Windows.Forms.Panel panelHoaDon;
        private System.Windows.Forms.ListView listView_HoaDon;
        private System.Windows.Forms.Panel panelDkBan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.ComboBox cbChuyenBan;
        private System.Windows.Forms.Button btnChuyenBan;
        private System.Windows.Forms.Button btnGopBan;
        private System.Windows.Forms.ComboBox cbGopBan2;
        private System.Windows.Forms.ComboBox cbGopBan1;
        private System.Windows.Forms.NumericUpDown nUdGiamGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnHuyBan;
        private System.Windows.Forms.NumericUpDown nUDslXoa;
        private System.Windows.Forms.CheckBox checkBoxXoa;
        private System.Windows.Forms.Button btnDatCho;
        private System.Windows.Forms.ToolStripMenuItem danhSachĐătChôToolStripMenuItem;
    }
}

