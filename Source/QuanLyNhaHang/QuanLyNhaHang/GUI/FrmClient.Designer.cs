namespace QuanLyNhaHang.GUI
{
    partial class FrmClient
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
            this.radioButton_server = new System.Windows.Forms.RadioButton();
            this.radioButton_local = new System.Windows.Forms.RadioButton();
            this.panel_ip = new System.Windows.Forms.Panel();
            this.checkBox_LocalHost = new System.Windows.Forms.CheckBox();
            this.txtIPServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel_ip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_server);
            this.groupBox1.Controls.Add(this.radioButton_local);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(13, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Kết Nối";
            // 
            // radioButton_server
            // 
            this.radioButton_server.AutoSize = true;
            this.radioButton_server.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_server.Location = new System.Drawing.Point(205, 42);
            this.radioButton_server.Name = "radioButton_server";
            this.radioButton_server.Size = new System.Drawing.Size(126, 24);
            this.radioButton_server.TabIndex = 1;
            this.radioButton_server.TabStop = true;
            this.radioButton_server.Text = "Kết nối Server";
            this.radioButton_server.UseVisualStyleBackColor = true;
            this.radioButton_server.CheckedChanged += new System.EventHandler(this.radioButton_server_CheckedChanged);
            // 
            // radioButton_local
            // 
            this.radioButton_local.AutoSize = true;
            this.radioButton_local.ForeColor = System.Drawing.Color.Blue;
            this.radioButton_local.Location = new System.Drawing.Point(36, 42);
            this.radioButton_local.Name = "radioButton_local";
            this.radioButton_local.Size = new System.Drawing.Size(123, 24);
            this.radioButton_local.TabIndex = 0;
            this.radioButton_local.TabStop = true;
            this.radioButton_local.Text = "Test trên máy";
            this.radioButton_local.UseVisualStyleBackColor = true;
            this.radioButton_local.CheckedChanged += new System.EventHandler(this.radioButton_local_CheckedChanged);
            // 
            // panel_ip
            // 
            this.panel_ip.Controls.Add(this.checkBox_LocalHost);
            this.panel_ip.Controls.Add(this.txtIPServer);
            this.panel_ip.Controls.Add(this.label1);
            this.panel_ip.Enabled = false;
            this.panel_ip.Location = new System.Drawing.Point(13, 150);
            this.panel_ip.Name = "panel_ip";
            this.panel_ip.Size = new System.Drawing.Size(368, 100);
            this.panel_ip.TabIndex = 1;
            // 
            // checkBox_LocalHost
            // 
            this.checkBox_LocalHost.AutoSize = true;
            this.checkBox_LocalHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_LocalHost.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_LocalHost.Location = new System.Drawing.Point(110, 76);
            this.checkBox_LocalHost.Name = "checkBox_LocalHost";
            this.checkBox_LocalHost.Size = new System.Drawing.Size(157, 21);
            this.checkBox_LocalHost.TabIndex = 2;
            this.checkBox_LocalHost.Text = "Kết nối tới LocalHost";
            this.checkBox_LocalHost.UseVisualStyleBackColor = true;
            this.checkBox_LocalHost.CheckedChanged += new System.EventHandler(this.checkBox_LocalHost_CheckedChanged);
            // 
            // txtIPServer
            // 
            this.txtIPServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPServer.Location = new System.Drawing.Point(130, 27);
            this.txtIPServer.Name = "txtIPServer";
            this.txtIPServer.Size = new System.Drawing.Size(179, 26);
            this.txtIPServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(50, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Server";
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.ForeColor = System.Drawing.Color.Blue;
            this.btnKetNoi.Location = new System.Drawing.Point(49, 275);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(110, 32);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.Text = "Kết Nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(234, 275);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 328);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.panel_ip);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmClient";
            this.Text = "Client Connect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmClient_FormClosing);
            this.Load += new System.EventHandler(this.FrmClient_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_ip.ResumeLayout(false);
            this.panel_ip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_local;
        private System.Windows.Forms.RadioButton radioButton_server;
        private System.Windows.Forms.Panel panel_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPServer;
        private System.Windows.Forms.CheckBox checkBox_LocalHost;
        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.Button btnExit;
    }
}