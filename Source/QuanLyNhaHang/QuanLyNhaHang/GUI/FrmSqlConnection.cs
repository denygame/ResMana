using QuanLyNhaHang.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    public partial class FrmSqlConnection : Form
    {
        private string ip;
        public FrmSqlConnection(string ip)
        {
            InitializeComponent();
            this.ip = ip;

            if (ip == "")
            {
                txtTenServer.Text = Environment.MachineName;
            }
            else
            {
                txtTenServer.Text = ip + Constant.portSqlServerSetUpByMe;
            }
        }

        #region - Events -
        private void checkBoxXacThuc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxXacThuc.Checked == true)
            {
                checkBoxXacThuc.ForeColor = Color.Red;
                txtUserName.Enabled = true;
                txtPassWord.Enabled = true;
                checkBoxPass.Enabled = true;
            }
            else
            {
                checkBoxXacThuc.ForeColor = Color.Blue;
                txtUserName.Enabled = false;
                txtPassWord.Enabled = false;
                checkBoxPass.Enabled = false;
            }
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

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            string connectionSTR = "";
            if (checkBoxXacThuc.Checked)
            {
                connectionSTR = @"Data Source=" + txtTenServer.Text + ";Initial Catalog=" + Constant.databaseName + ";User ID=" + txtUserName.Text + ";Password=" + txtPassWord.Text;
            }
            else
            {
                connectionSTR = @"Data Source=" + txtTenServer.Text + ";Initial Catalog=" + Constant.databaseName + ";Integrated Security=True";
            }
            ketNoi(connectionSTR);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSqlConnection_Load(object sender, EventArgs e)
        {
            txtPassWord.Enabled = false;
            txtUserName.Enabled = false;
            checkBoxPass.Enabled = false;
        }

        private void btnChaySql_Click(object sender, EventArgs e)
        {
            if (DatabaseExecute.runFileSql(txtTenServer.Text) == 1)
                MessageBox.Show("Chạy file SQL thành công!", "Thông Báo");
            else MessageBox.Show("Không thành công!", "Thông Báo");
        }

        private void btnXoaDatabase_Click(object sender, EventArgs e)
        {
            if (DatabaseExecute.DropDatabase(txtTenServer.Text) == 1)
                MessageBox.Show("Xóa Database thành công!", "Thông Báo");
            else MessageBox.Show("Không thành công, không có Database!", "Thông Báo");
        }

        private void btnLayServerName_Click(object sender, EventArgs e)
        {
            txtTenServer.Text = Environment.MachineName;
        }
        #endregion

        #region - Methods -
        private void ketNoi(string connectionSTR)
        {
            SqlConnection conn = new SqlConnection(connectionSTR);
            try
            {
                conn.Open();
                QuanLyNhaHang.Properties.Settings.Default.strConnection = connectionSTR;
                QuanLyNhaHang.Properties.Settings.Default.Save();
                MessageBox.Show("Kết nối thành công, chương trình sẽ tự khởi động lại cho lần chạy đầu", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Thread.Sleep(Constant.timeForRestartApp * 1000);
               
                Application.Restart();
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối không thành công, xin kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


    }
}
