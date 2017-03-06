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
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmManage f = new FrmManage();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
