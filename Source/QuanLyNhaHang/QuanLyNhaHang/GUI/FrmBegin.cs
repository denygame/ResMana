using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FrmBegin : Form
    {
        public FrmBegin()
        {
            InitializeComponent();



        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmManage f = new FrmManage();
            if (Application.OpenForms["FrmManage"] == null) f.Show();
            else Application.OpenForms["FrmManage"].Focus();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            FrmSystem f = new FrmSystem();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }


        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ngắt kết nối với server thành công! Chương trình sẽ khởi động lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            QuanLyNhaHang.Properties.Settings.Default.Reset();
            Application.Exit();
            Application.Restart();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();
            f.ButtonDN_Clicked += new EventHandler(frm_Button_Clicked); //bắt event trước mới show
            f.ShowDialog();
            this.Show();
        }
        private void frm_Button_Clicked(object sender, EventArgs e)
        {
            foreach (Control i in panel1.Controls) i.Enabled = true;
        }
    }
}
