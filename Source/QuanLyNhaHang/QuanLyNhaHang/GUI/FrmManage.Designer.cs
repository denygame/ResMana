﻿namespace QuanLyNhaHang
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
            this.txtBan = new System.Windows.Forms.TextBox();
            this.btnHuyBan = new System.Windows.Forms.Button();
            this.cbSanh = new System.Windows.Forms.ComboBox();
            this.panelHoaDon = new System.Windows.Forms.Panel();
            this.dataGridView_HDtheoBan = new System.Windows.Forms.DataGridView();
            this.panelDkBan = new System.Windows.Forms.Panel();
            this.btnGopBan = new System.Windows.Forms.Button();
            this.cbGopBan2 = new System.Windows.Forms.ComboBox();
            this.cbGopBan1 = new System.Windows.Forms.ComboBox();
            this.cbChuyenBan = new System.Windows.Forms.ComboBox();
            this.btnChuyenBan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nUDslXoa = new System.Windows.Forms.NumericUpDown();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.panelSanh.SuspendLayout();
            this.panelHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HDtheoBan)).BeginInit();
            this.panelDkBan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDslXoa)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_BanAn
            // 
            this.flowLayoutPanel_BanAn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_BanAn.AutoScroll = true;
            this.flowLayoutPanel_BanAn.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel_BanAn.Location = new System.Drawing.Point(12, 96);
            this.flowLayoutPanel_BanAn.Name = "flowLayoutPanel_BanAn";
            this.flowLayoutPanel_BanAn.Size = new System.Drawing.Size(682, 448);
            this.flowLayoutPanel_BanAn.TabIndex = 0;
            this.flowLayoutPanel_BanAn.MouseEnter += new System.EventHandler(this.flowLayoutPanel_BanAn_MouseEnter);
            // 
            // panelSanh
            // 
            this.panelSanh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSanh.BackColor = System.Drawing.SystemColors.Control;
            this.panelSanh.Controls.Add(this.txtBan);
            this.panelSanh.Controls.Add(this.btnHuyBan);
            this.panelSanh.Controls.Add(this.cbSanh);
            this.panelSanh.Location = new System.Drawing.Point(12, 38);
            this.panelSanh.Name = "panelSanh";
            this.panelSanh.Size = new System.Drawing.Size(682, 52);
            this.panelSanh.TabIndex = 1;
            // 
            // txtBan
            // 
            this.txtBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBan.ForeColor = System.Drawing.Color.Black;
            this.txtBan.Location = new System.Drawing.Point(298, 12);
            this.txtBan.Name = "txtBan";
            this.txtBan.ReadOnly = true;
            this.txtBan.Size = new System.Drawing.Size(184, 26);
            this.txtBan.TabIndex = 6;
            this.txtBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnHuyBan
            // 
            this.btnHuyBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyBan.Enabled = false;
            this.btnHuyBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyBan.ForeColor = System.Drawing.Color.Red;
            this.btnHuyBan.Location = new System.Drawing.Point(584, 2);
            this.btnHuyBan.Name = "btnHuyBan";
            this.btnHuyBan.Size = new System.Drawing.Size(75, 45);
            this.btnHuyBan.TabIndex = 5;
            this.btnHuyBan.Text = "Hủy Bàn";
            this.btnHuyBan.UseVisualStyleBackColor = true;
            this.btnHuyBan.Click += new System.EventHandler(this.btnHuyBan_Click);
            // 
            // cbSanh
            // 
            this.cbSanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSanh.FormattingEnabled = true;
            this.cbSanh.Location = new System.Drawing.Point(3, 12);
            this.cbSanh.Name = "cbSanh";
            this.cbSanh.Size = new System.Drawing.Size(174, 26);
            this.cbSanh.TabIndex = 0;
            this.cbSanh.SelectedIndexChanged += new System.EventHandler(this.cbSanh_SelectedIndexChanged);
            // 
            // panelHoaDon
            // 
            this.panelHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHoaDon.BackColor = System.Drawing.SystemColors.Control;
            this.panelHoaDon.Controls.Add(this.dataGridView_HDtheoBan);
            this.panelHoaDon.Location = new System.Drawing.Point(700, 96);
            this.panelHoaDon.Name = "panelHoaDon";
            this.panelHoaDon.Size = new System.Drawing.Size(371, 448);
            this.panelHoaDon.TabIndex = 3;
            // 
            // dataGridView_HDtheoBan
            // 
            this.dataGridView_HDtheoBan.AllowUserToAddRows = false;
            this.dataGridView_HDtheoBan.AllowUserToDeleteRows = false;
            this.dataGridView_HDtheoBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_HDtheoBan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_HDtheoBan.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_HDtheoBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_HDtheoBan.Location = new System.Drawing.Point(4, 1);
            this.dataGridView_HDtheoBan.Name = "dataGridView_HDtheoBan";
            this.dataGridView_HDtheoBan.ReadOnly = true;
            this.dataGridView_HDtheoBan.Size = new System.Drawing.Size(364, 444);
            this.dataGridView_HDtheoBan.TabIndex = 0;
            // 
            // panelDkBan
            // 
            this.panelDkBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDkBan.BackColor = System.Drawing.SystemColors.Control;
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
            this.btnGopBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGopBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGopBan.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnGopBan.Location = new System.Drawing.Point(387, 8);
            this.btnGopBan.Name = "btnGopBan";
            this.btnGopBan.Size = new System.Drawing.Size(75, 45);
            this.btnGopBan.TabIndex = 4;
            this.btnGopBan.Text = "Gộp Bàn";
            this.btnGopBan.UseVisualStyleBackColor = true;
            this.btnGopBan.Click += new System.EventHandler(this.btnGopBan_Click);
            // 
            // cbGopBan2
            // 
            this.cbGopBan2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGopBan2.DropDownHeight = 120;
            this.cbGopBan2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGopBan2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGopBan2.FormattingEnabled = true;
            this.cbGopBan2.IntegralHeight = false;
            this.cbGopBan2.Location = new System.Drawing.Point(573, 17);
            this.cbGopBan2.Name = "cbGopBan2";
            this.cbGopBan2.Size = new System.Drawing.Size(99, 26);
            this.cbGopBan2.TabIndex = 3;
            // 
            // cbGopBan1
            // 
            this.cbGopBan1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbGopBan1.DropDownHeight = 120;
            this.cbGopBan1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGopBan1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGopBan1.FormattingEnabled = true;
            this.cbGopBan1.IntegralHeight = false;
            this.cbGopBan1.Location = new System.Drawing.Point(468, 17);
            this.cbGopBan1.Name = "cbGopBan1";
            this.cbGopBan1.Size = new System.Drawing.Size(99, 26);
            this.cbGopBan1.TabIndex = 2;
            this.cbGopBan1.SelectedIndexChanged += new System.EventHandler(this.cbGopBan1_SelectedIndexChanged);
            // 
            // cbChuyenBan
            // 
            this.cbChuyenBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbChuyenBan.DropDownHeight = 120;
            this.cbChuyenBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChuyenBan.Enabled = false;
            this.cbChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChuyenBan.FormattingEnabled = true;
            this.cbChuyenBan.IntegralHeight = false;
            this.cbChuyenBan.Location = new System.Drawing.Point(10, 17);
            this.cbChuyenBan.Name = "cbChuyenBan";
            this.cbChuyenBan.Size = new System.Drawing.Size(99, 26);
            this.cbChuyenBan.TabIndex = 0;
            // 
            // btnChuyenBan
            // 
            this.btnChuyenBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChuyenBan.Enabled = false;
            this.btnChuyenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenBan.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnChuyenBan.Location = new System.Drawing.Point(115, 8);
            this.btnChuyenBan.Name = "btnChuyenBan";
            this.btnChuyenBan.Size = new System.Drawing.Size(75, 45);
            this.btnChuyenBan.TabIndex = 1;
            this.btnChuyenBan.Text = "Chuyển Bàn";
            this.btnChuyenBan.UseVisualStyleBackColor = true;
            this.btnChuyenBan.Click += new System.EventHandler(this.btnChuyenBan_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtTongTien);
            this.panel1.Controls.Add(this.btnThanhToan);
            this.panel1.Location = new System.Drawing.Point(700, 550);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 62);
            this.panel1.TabIndex = 5;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(16, 14);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(213, 30);
            this.txtTongTien.TabIndex = 13;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.Red;
            this.btnThanhToan.Location = new System.Drawing.Point(264, 3);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(104, 56);
            this.btnThanhToan.TabIndex = 11;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.nUDslXoa);
            this.panel2.Controls.Add(this.btnXoaMon);
            this.panel2.Controls.Add(this.btnThemMon);
            this.panel2.Location = new System.Drawing.Point(700, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(371, 52);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(247, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Lượng Xóa";
            // 
            // nUDslXoa
            // 
            this.nUDslXoa.Location = new System.Drawing.Point(276, 26);
            this.nUDslXoa.Name = "nUDslXoa";
            this.nUDslXoa.Size = new System.Drawing.Size(47, 20);
            this.nUDslXoa.TabIndex = 2;
            this.nUDslXoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUDslXoa.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnXoaMon.Location = new System.Drawing.Point(154, 3);
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
            this.ClientSize = new System.Drawing.Size(1085, 624);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDkBan);
            this.Controls.Add(this.panelHoaDon);
            this.Controls.Add(this.panelSanh);
            this.Controls.Add(this.flowLayoutPanel_BanAn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sảnh Chính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmManage_FormClosing);
            this.Load += new System.EventHandler(this.FrmManage_Load);
            this.MouseEnter += new System.EventHandler(this.FrmManage_MouseEnter);
            this.Resize += new System.EventHandler(this.FrmManage_Resize);
            this.panelSanh.ResumeLayout(false);
            this.panelSanh.PerformLayout();
            this.panelHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_HDtheoBan)).EndInit();
            this.panelDkBan.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDslXoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_BanAn;
        private System.Windows.Forms.Panel panelSanh;
        private System.Windows.Forms.ComboBox cbSanh;
        private System.Windows.Forms.Panel panelHoaDon;
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
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnHuyBan;
        private System.Windows.Forms.NumericUpDown nUDslXoa;
        private System.Windows.Forms.DataGridView dataGridView_HDtheoBan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBan;
    }
}

