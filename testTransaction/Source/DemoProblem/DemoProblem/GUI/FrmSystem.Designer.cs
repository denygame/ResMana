namespace DemoProblem.GUI
{
    partial class FrmSystem
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
            this.cbProblem = new System.Windows.Forms.ComboBox();
            this.rB_Poke = new System.Windows.Forms.RadioButton();
            this.rB_Wait = new System.Windows.Forms.RadioButton();
            this.dataGridView_NhanVien = new System.Windows.Forms.DataGridView();
            this.btnDemo = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabNhanVien.SuspendLayout();
            this.panel48.SuspendLayout();
            this.panel47.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhanVien);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
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
            this.panel47.Controls.Add(this.btnDemo);
            this.panel47.Controls.Add(this.cbProblem);
            this.panel47.Controls.Add(this.rB_Poke);
            this.panel47.Controls.Add(this.rB_Wait);
            this.panel47.Controls.Add(this.dataGridView_NhanVien);
            this.panel47.Location = new System.Drawing.Point(0, 0);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(829, 392);
            this.panel47.TabIndex = 0;
            // 
            // cbProblem
            // 
            this.cbProblem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProblem.Enabled = false;
            this.cbProblem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProblem.FormattingEnabled = true;
            this.cbProblem.Location = new System.Drawing.Point(236, 13);
            this.cbProblem.Name = "cbProblem";
            this.cbProblem.Size = new System.Drawing.Size(304, 28);
            this.cbProblem.TabIndex = 4;
            this.cbProblem.SelectedIndexChanged += new System.EventHandler(this.cbProblem_SelectedIndexChanged);
            // 
            // rB_Poke
            // 
            this.rB_Poke.AutoSize = true;
            this.rB_Poke.Enabled = false;
            this.rB_Poke.Location = new System.Drawing.Point(695, 19);
            this.rB_Poke.Name = "rB_Poke";
            this.rB_Poke.Size = new System.Drawing.Size(87, 17);
            this.rB_Poke.TabIndex = 3;
            this.rB_Poke.TabStop = true;
            this.rB_Poke.Text = "Thread Poke";
            this.rB_Poke.UseVisualStyleBackColor = true;
            // 
            // rB_Wait
            // 
            this.rB_Wait.AutoSize = true;
            this.rB_Wait.Enabled = false;
            this.rB_Wait.Location = new System.Drawing.Point(590, 19);
            this.rB_Wait.Name = "rB_Wait";
            this.rB_Wait.Size = new System.Drawing.Size(84, 17);
            this.rB_Wait.TabIndex = 2;
            this.rB_Wait.TabStop = true;
            this.rB_Wait.Text = "Thread Wait";
            this.rB_Wait.UseVisualStyleBackColor = true;
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
            // btnDemo
            // 
            this.btnDemo.BackColor = System.Drawing.Color.Silver;
            this.btnDemo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemo.ForeColor = System.Drawing.Color.Red;
            this.btnDemo.Location = new System.Drawing.Point(41, 13);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(129, 28);
            this.btnDemo.TabIndex = 5;
            this.btnDemo.Text = "DEMO";
            this.btnDemo.UseVisualStyleBackColor = false;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // FrmSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 503);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống";
            this.Load += new System.EventHandler(this.FrmSystem_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNhanVien.ResumeLayout(false);
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_NhanVien)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.RadioButton rB_Poke;
        private System.Windows.Forms.RadioButton rB_Wait;
        private System.Windows.Forms.ComboBox cbProblem;
        private System.Windows.Forms.Button btnDemo;
    }
}