using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
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
        public static Account tkDangNhap;
        private bool testClick = false;

        private int truyenTestTrenMay = -1;


        public FrmBegin(int truyenTestTrenMay)
        {
            InitializeComponent();

            this.truyenTestTrenMay = truyenTestTrenMay;
        }

        #region - Methods -
        /// <summary>
        /// khởi tạo textbox tài khoản
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        private TextBox initTextBoxAccount(Account tk)
        {
            string ten = string.Format("Xin chào: {0}", tk.UserName);
            TextBox txt = new TextBox();
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.Text = ten;
            txt.Location = new Point(5, 3);
            txt.Size = new Size(381, 40);
            txt.TextAlign = HorizontalAlignment.Center;
            txt.Name = "txtTest";
            txt.ForeColor = Color.Blue;
            txt.KeyPress += Txt_KeyPress;
            return txt;
        }
        #endregion

        #region - Events -
        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmManage f = new FrmManage(truyenTestTrenMay);
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {

        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            FrmSystem f = new FrmSystem();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            foreach (Control i in flowLayoutPanel1.Controls) i.Enabled = false;
            btnDangNhap.Visible = true;
            foreach (Control item in panel2.Controls.OfType<Control>())
            {
                if (item.Name == "txtTest")
                    panel2.Controls.Remove(item);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLyNhaHang.Properties.Settings.Default.Reset();
                MessageBox.Show("Ngắt kết nối với server thành công! Chương trình sẽ khởi động lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                testClick = true;
                Application.Restart();
            }
            catch { MessageBox.Show("Có lỗi trong quá trình ngắt kết nối", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            FrmLogin f = new FrmLogin();

            f.EventDN += F_EventDN;

            f.ShowDialog();
            this.Show();
        }

        private void F_EventDN(object sender, EventTruyenDuLieu e)
        {
            tkDangNhap = e.Tk;
            foreach (Control i in flowLayoutPanel1.Controls) i.Enabled = true;
            btnDangNhap.Visible = false;

            //btnAcc.Text = e.Tk.UserName;

            panel2.Controls.Add(initTextBoxAccount(e.Tk));
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        #endregion


    }
}
