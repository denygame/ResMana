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
    public partial class FrmAccountProfile : Form
    {
        private Account acc;
        public FrmAccountProfile(Account acc)
        {
            InitializeComponent();
            this.acc = acc;
        }

        private void checkBox_changePass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_changePass.Checked == true)
            {
                panel_doiMK.Enabled = true;
                checkBox_changePass.ForeColor = Color.Red;
            }
            else
            {
                panel_doiMK.Enabled = false;
                checkBox_changePass.ForeColor = Color.Blue;
            }
        }

        private void FrmAccountProfile_Load(object sender, EventArgs e)
        {
            panel_doiMK.Enabled = false;
            checkBox_changePass.Select();
            txtUserName.Text = acc.UserName;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void changePass()
        {
            string userName = txtUserName.Text;
            string passWord = EncryptPassword.md5(txtOldPass.Text);
            string newPass = EncryptPassword.md5(txtNewPass.Text);
            string reEnpass = EncryptPassword.md5(txtConfirm.Text);

            if (!newPass.Equals(reEnpass))
            {
                MessageBox.Show("Nhập lại mật khẩu mới không đúng!", "Thông báo nhập lại!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
            }
            else
            {
                if (AccountDAL.changePass(userName, passWord, newPass))
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Nhập mật khẩu sai!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOldPass.Focus();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            changePass();
        }

        private void checkBox_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox_showPass.Checked == true)
            {
                txtOldPass.UseSystemPasswordChar = false;
                txtNewPass.UseSystemPasswordChar = false;
                txtConfirm.UseSystemPasswordChar = false;
            }
            else
            {
                txtOldPass.UseSystemPasswordChar = true;
                txtNewPass.UseSystemPasswordChar = true;
                txtConfirm.UseSystemPasswordChar = true;
            }
        }
    }
}
