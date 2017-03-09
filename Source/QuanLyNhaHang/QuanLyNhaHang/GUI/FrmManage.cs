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
    public partial class FrmManage : Form
    {
        public FrmManage()
        {
            InitializeComponent();

            khoiTaoCbSanh();
        }

        #region Events

        //load bàn theo cbSanh
        private void cbSanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBan.Text = "";
            Sanh sanhCB = cbSanh.SelectedItem as Sanh;
            khoiTaoBanTheoIdSanh(sanhCB.IdSanh);
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSystem f = new FrmSystem();
            if (Application.OpenForms["FrmSystem"] == null) f.Show();
            else Application.OpenForms["FrmSystem"].Focus();
        }
        // test 2 form song song
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            FrmAddFood f = new FrmAddFood();
            if (Application.OpenForms["FrmAddFood"] == null)
                f.Show();
            else
                Application.OpenForms["FrmAddFood"].Focus();
        }

        private void checkBoxXoa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxXoa.Checked == true)
            {
                nUDslXoa.Enabled = false;
                checkBoxXoa.ForeColor = Color.Red;
            }
            else
            {
                nUDslXoa.Enabled = true;
                checkBoxXoa.ForeColor = Color.Black;
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            testcode();
        }

        private void btnDatCho_Click(object sender, EventArgs e)
        {
            FrmBookTable f = new FrmBookTable();
            f.ShowDialog();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            txtBan.Text = ((sender as Button).Tag as BanAn).TenBan;
        }
        #endregion

        #region Methods
        private void khoiTaoCbSanh()
        {
            List<Sanh> listSanh = SanhDAL.layDsSanh();
            cbSanh.DataSource = listSanh;
            cbSanh.DisplayMember = "TenSanh";
        }

        //hàm add list bàn ăn
        private void khoiTaoBanTheoIdSanh(int idSanh)
        {
            flowLayoutPanel_BanAn.Controls.Clear();
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn(idSanh);
            foreach (BanAn i in listBanAn)
            {
                Button btn = khoiTaoBanAn(i);
                btn.Click += Btn_Click;
                flowLayoutPanel_BanAn.Controls.Add(btn);
            }
        }

        //hàm tạo bàn ăn (test lại)
        private Button khoiTaoBanAn(BanAn banAn)
        {
            Button btn = new Button() { Width = Constant.widthButtonBanAn, Height = Constant.heightButtonBanAn };
            btn.Text = banAn.TenBan + "\n";
            btn.Tag = banAn; // mỗi button tạo ra tag vào nó bàn ăn đó
            switch (banAn.TrangThai)
            {
                case 0: btn.Text += "Trống"; break;
                case 1: btn.Text += "Có Người"; break;
                case 2: btn.Text += "Bàn Đặt Chỗ"; break;
            }

            btn.TextAlign = ContentAlignment.BottomCenter;

            //test pic cho button <phải bỏ thư mục Img vào bin>
            Bitmap bmp = new Bitmap(@"Img\banTrong.png");
            btn.Image = bmp;
            btn.ImageAlign = ContentAlignment.TopCenter;

            btn.BackColor = Color.LightBlue;

            return btn;
        }
        //hàm thay thế bàn ăn (VD: thêm món ăn vào thì thay thế 1 bàn chứ k chạy hết tất cả)
        private void thayTheBanAn(FlowLayoutPanel fl, Control banCanThayDoi, Control banThayDoi)
        {
            int index = fl.Controls.IndexOf(banCanThayDoi);
            if (index == -1) return;
            fl.Controls.RemoveAt(index);
            banCanThayDoi.Dispose();
            fl.Controls.Add(banThayDoi);
            fl.Controls.SetChildIndex(banThayDoi, index);
        }

        //hàm test, nhớ xóa
        private void testcode()
        {
            Button btnCanThayThe = new Button();
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn(cbSanh.SelectedIndex + 1);
            foreach (BanAn b in listBanAn)
                if (b.TrangThai == 2)
                {
                    foreach (Control c in flowLayoutPanel_BanAn.Controls)
                    {
                        if (((c as Button).Tag as BanAn).IdBanAn == b.IdBanAn)
                        {
                            ((c as Button).Tag as BanAn).TrangThai = 0;
                            btnCanThayThe = c as Button;
                        }
                    }
                    break;
                }
            thayTheBanAn(flowLayoutPanel_BanAn, btnCanThayThe, khoiTaoBanAn(btnCanThayThe.Tag as BanAn));
        }
        #endregion


    }
}
