namespace Server
{
    partial class FrmServer
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_server = new System.Windows.Forms.TextBox();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.Blue;
            this.btnStart.Location = new System.Drawing.Point(44, 68);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(103, 28);
            this.btnStart.TabIndex = 13;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(150, 12);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(161, 26);
            this.txtIP.TabIndex = 9;
            this.txtIP.Text = "127.0.0.1";
            this.txtIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "IP Server";
            // 
            // textBox_server
            // 
            this.textBox_server.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textBox_server.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_server.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.textBox_server.Location = new System.Drawing.Point(12, 102);
            this.textBox_server.Multiline = true;
            this.textBox_server.Name = "textBox_server";
            this.textBox_server.ReadOnly = true;
            this.textBox_server.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_server.Size = new System.Drawing.Size(366, 295);
            this.textBox_server.TabIndex = 14;
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.ForeColor = System.Drawing.Color.Red;
            this.btn_Stop.Location = new System.Drawing.Point(240, 68);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(103, 28);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 409);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.textBox_server);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmServer";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_server;
        private System.Windows.Forms.Button btn_Stop;
    }
}

