using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
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
        private event EventHandler<EventTruyenDuLieu> eventDN;
        public event EventHandler<EventTruyenDuLieu> EventDN
        {
            add { eventDN += value; }
            remove { eventDN -= value; }
        }

        public FrmLogin()
        {
            InitializeComponent();
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            int lo = AccountDAL.login(txtUserName.Text, EncryptPassword.md5(txtPassWord.Text));
            if (lo == -1)
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lo == 0)
            {
                if (AccountDAL.getCheckLogin(txtUserName.Text))
                {
                    MessageBox.Show("Tài Khoản đã được đăng nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                AccountDAL.replaceCheckLogin(txtUserName.Text, 1);//đăng nhập
                eventDN(this, new EventTruyenDuLieu(AccountDAL.getAccount(txtUserName.Text)));
                this.Close();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked == true)
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
