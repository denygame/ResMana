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
    public partial class FrmSystem : Form
    {
        public FrmSystem()
        {
            InitializeComponent();
        }




        #region Methods
        private void thietKeThemXoa(string themSua, string tab, FlowLayoutPanel fl)
        {
            Button btnTX = new Button();
            btnTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTX.Name = "btn" + themSua + tab;
            btnTX.Size = new System.Drawing.Size(155, 32);
            btnTX.TabIndex = 17;
            btnTX.Text = themSua;
            btnTX.UseVisualStyleBackColor = false;

            btnTX.Click += btnTX_Click;
            fl.Controls.Add(btnTX);


            Button btnHuy = new Button();
            btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnHuy.Name = "btnHuy" + tab;
            btnHuy.Size = new System.Drawing.Size(155, 32);
            btnHuy.TabIndex = 17;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;

            btnHuy.Click += btnHuy_Click;
            fl.Controls.Add(btnHuy);
        }

        //test lai
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.Contains("DanhMuc"))
            {
                panel11.Visible = true;
                fl_testDM.Controls.Clear();
                panel_IdDM.Visible = true;

                panel_TenDanhMuc.Location = new Point(3, 63);
                return;
            }
            if ((sender as Button).Name.Contains("ThucAn"))
            {
                panel14.Visible = true;
                fl_testThucAn.Controls.Clear();
                panel_idThucan.Visible = true;

                panel_tenThucAn.Location = new Point(3, 63);
                panel_DanhMucThucAn.Location = new Point(3, 122);
                panel_GiaThucAn.Location = new Point(3, 181);
                return;
            }
            if ((sender as Button).Name.Contains("Sanh"))
            {
                panel23.Visible = true;
                fl_Sanh.Controls.Clear();
                panel_idSanh.Visible = true;

                panel_tenSanh.Location = new Point(3, 63);
                return;
            }
            if ((sender as Button).Name.Contains("BanAn"))
            {
                panel30.Visible = true;
                fl_BanAn.Controls.Clear();
                panel_idBan.Visible = true;

                panel_tenBan.Location = new Point(3, 63);
                panel_cnTTban.Location = new Point(3, 122);
                panel_tenSanhBanAn.Location = new Point(3, 181);
                return;
            }
            if ((sender as Button).Name.Contains("TK"))
            {
                panel39.Visible = true;
                fl_TaiKhoan.Controls.Clear();
                fl_TaiKhoan.Visible = false;
                btnRestPass.Visible = true;

                return;
            }
        }

        //test lai
        private void btnTX_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Thêm")
                MessageBox.Show("Click thêm...");
            else
                MessageBox.Show("Click sửa...");
        }
        #endregion

        #region Events
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            panel_IdDM.Visible = false;
            thietKeThemXoa((sender as Button).Text, "DanhMuc", fl_testDM);
            panel11.Visible = false;

            panel_TenDanhMuc.Location = new Point(3, 4);
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            btnThemDanhMuc_Click(sender, e);
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void btnXemDanhMuc_Click(object sender, EventArgs e)
        {

        }

        private void btnThemThucAn_Click(object sender, EventArgs e)
        {
            panel_idThucan.Visible = false;
            thietKeThemXoa((sender as Button).Text, "ThucAn", fl_testThucAn);
            panel14.Visible = false;

            panel_tenThucAn.Location = new Point(3, 4);
            panel_DanhMucThucAn.Location = new Point(3, 63);
            panel_GiaThucAn.Location = new Point(3, 122);
        }

        private void btnSuaThucAn_Click(object sender, EventArgs e)
        {
            btnThemThucAn_Click(sender, e);
        }

        private void btnXoaThucAn_Click(object sender, EventArgs e)
        {

        }

        private void btnXemThucAn_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void btnThemSanh_Click(object sender, EventArgs e)
        {
            panel_idSanh.Visible = false;
            thietKeThemXoa((sender as Button).Text, "Sanh", fl_Sanh);
            panel23.Visible = false;

            panel_tenSanh.Location = new Point(3, 4);
        }

        private void btnSuaSanh_Click(object sender, EventArgs e)
        {
            btnThemSanh_Click(sender, e);
        }

        private void btnXoaSanh_Click(object sender, EventArgs e)
        {

        }

        private void btnXemSanh_Click(object sender, EventArgs e)
        {

        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            panel_idBan.Visible = false;
            thietKeThemXoa((sender as Button).Text, "BanAn", fl_BanAn);
            panel30.Visible = false;

            panel_tenBan.Location = new Point(3, 4);
            panel_cnTTban.Location = new Point(3, 63);
            panel_tenSanhBanAn.Location = new Point(3, 122);
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            btnThemBan_Click(sender, e);
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {

        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {

        }

        private void btnThemTaiKhoan_Click(object sender, EventArgs e)
        {
            btnRestPass.Visible = false;
            fl_TaiKhoan.Visible = true;
            thietKeThemXoa((sender as Button).Text, "TK", fl_TaiKhoan);
            panel39.Visible = false;
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            btnThemTaiKhoan_Click(sender, e);
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void btnXemTaiKhoan_Click(object sender, EventArgs e)
        {

        }

    }
}
