using DemoProblem.DAL;
using DemoProblem.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProblem.GUI
{
    public partial class FrmAddAccount : Form
    {
        private event EventHandler evFromAddAccount;
        public event EventHandler EvFromAddAccount
        {
            add { evFromAddAccount += value; }
            remove { evFromAddAccount -= value; }
        }

        private Staff nv;
        public FrmAddAccount(Staff nv)
        {
            InitializeComponent();
            this.nv = nv;
        }

        private void FrmAddAccount_Load(object sender, EventArgs e)
        {
            txtIdNhanVien.Text = nv.IdNhanVien.ToString();
            txtIdNhanVien.Enabled = false;
            txtUsername.Focus();
            cbAccType.DataSource = Constant.listLoaiTK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "")
            {
                MessageBox.Show("User name không được rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(AccountDAL.countAccByUsername(txtUsername.Text) != 0)
            {
                MessageBox.Show("User name đã có trong hệ thống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
                return;
            }
            else
            {
                int loaiTk = -1;
                if (cbAccType.SelectedIndex == 0) loaiTk = 2; else loaiTk = 1; 
                try
                {
                    AccountDAL.insertAccount(txtUsername.Text, loaiTk, Convert.ToInt32(txtIdNhanVien.Text));
                }
                catch
                {
                    MessageBox.Show("Có lỗi khi thêm tài khoản!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Cấp tài khoản thành công", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.None);
                evFromAddAccount(this, new EventArgs());
                this.Close();
            }
        }

        #region - username k nhập ký tự đặc biệt -
        char[] specialKey = { '\'', '"', '@', '=', '+', '*', '!', ';', ' ', '>', '<', '?', '/', '(', ')', '%', '$', '#', '@', '^', '&', ':', '.', ',', '`', '~', '[', ']', '{', '}' };

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool match = specialKey.Contains(e.KeyChar);

            if (match) e.Handled = true;  //-- Không thực thi
            else e.Handled = false;         //-- Thực thi
        }
        #endregion
    }
}
