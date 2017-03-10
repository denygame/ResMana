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
            eventDN(this, new EventTruyenDuLieu(TaiKhoanDAL.layTaiKhoan(txtUserName.Text)));
            
            if(TaiKhoanDAL.dangNhap(txtUserName.Text, txtPassWord.Text))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
