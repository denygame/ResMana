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

        public FrmBegin()
        {
            InitializeComponent();

            IPConnectionDAL.insertIP(GetIPconnectSql.getIP());


            //in ra pass ma hoa mac dinh
            //Constant.passDefaultEncrypted();
        }

        #region - Methods -
        /// <summary>
        /// khởi tạo textbox tài khoản
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        private Label initLabelXC()
        {
            string ten = string.Format("ĐÃ ĐĂNG NHẬP");
            Label txt = new Label();
            txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txt.Text = ten;
            txt.Location = new Point(130, 3);
            txt.Size = new Size(381, 40);
            txt.Name = "txtTest";
            txt.ForeColor = Color.DarkBlue;
            txt.KeyPress += Txt_KeyPress;
            return txt;
        }

        private bool testAcc()
        {
            if (tkDangNhap.LoaiTK == 1)
            {
                MessageBox.Show("Tài khoản của bạn không đủ quyền để thực hiện hành động này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        #endregion

        #region - Events -
        private void btnThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            FrmManage f = new FrmManage();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            FrmAccountProfile f = new FrmAccountProfile(tkDangNhap);
            f.ShowDialog();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            if (!testAcc()) return;
            FrmSystem f = new FrmSystem(tkDangNhap);
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

            AccountDAL.replaceCheckLogin(tkDangNhap.UserName, 0);//đăng xuất

            foreach (Control item in panel2.Controls.OfType<Control>())
            {
                if (item.Name == "txtTest")
                    panel2.Controls.Remove(item);
            }
        }

        private bool testDisconnect()
        {
            try
            {
                QuanLyNhaHang.Properties.Settings.Default.Reset();
                return true;
            }
            catch { return false; }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (!testAcc()) return;
            if (testDisconnect())
            {
                IPConnectionDAL.deleteIP(GetIPconnectSql.getIP());

                AccountDAL.replaceCheckLogin(tkDangNhap.UserName, 0);//đăng xuất

                MessageBox.Show("Ngắt kết nối với server thành công! Chương trình sẽ khởi động lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            else MessageBox.Show("Có lỗi trong quá trình ngắt kết nối", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Text += "  -+-  Tài Khoản: " + e.Tk.UserName;
            panel2.Controls.Add(initLabelXC());
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void FrmBegin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tkDangNhap != null)
            {
                if (tkDangNhap.CheckLogin == 1)
                    AccountDAL.replaceCheckLogin(tkDangNhap.UserName, 0);//đăng xuất
            }
            IPConnectionDAL.deleteIP(GetIPconnectSql.getIP());
        }

        #endregion

       
    }
}
