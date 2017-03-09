﻿using QuanLyNhaHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    public partial class FrmLogin : Form
    {
        public event EventHandler ButtonDN_Clicked = null;


        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (this.ButtonDN_Clicked != null)
                this.ButtonDN_Clicked(sender, e);
            string userName = txtUserName.Text;
            string passWord = txtPassWord.Text;
            if(TaiKhoanDAL.dangNhap(userName, passWord))
            {
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /* private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn muốn thoát chương trình?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            //    e.Cancel = true;
        }*/

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPass.Checked == true)
            {
                checkBoxPass.ForeColor = Color.Red;
                txtPassWord.UseSystemPasswordChar = false;
            }
            else
            {
                checkBoxPass.ForeColor = Color.Blue;
                txtPassWord.UseSystemPasswordChar = true;
            }
        }
    }
}
