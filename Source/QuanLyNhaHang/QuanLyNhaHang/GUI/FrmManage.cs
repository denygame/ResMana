using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FrmManage : Form
    {
        public static bool testClickThemMon = false;
        private static bool testClickXoaMon = false;
        private TaiKhoan tkDangNhap = FrmBegin.tkDangNhap;

        private int widthButtonBanAn = Constant.widthButtonBanAnSizeNho, heightButtonBanAn = Constant.heightButtonBanAnSizeNho;

        public FrmManage()
        {
            InitializeComponent();
            khoiTaoCbSanh();
            this.Text += " - Tài khoản: " + tkDangNhap.UserName;
            cbSanh.Select(); //focus
        }

        #region Events

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {

        }

        private void FrmManage_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.widthButtonBanAn = Constant.widthButtonBanAnSizeLon;
                this.heightButtonBanAn = Constant.heightButtonBanAnSizeLon;
            }
            else
            {
                this.widthButtonBanAn = Constant.widthButtonBanAnSizeNho;
                this.heightButtonBanAn = Constant.heightButtonBanAnSizeNho;
            }
            khoiTaoBanTheoIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
        }

        private void txtBan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

        }

        //load bàn theo cbSanh
        private void cbSanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBan.Text = "";
            Sanh sanhCB = cbSanh.SelectedItem as Sanh;
            khoiTaoBanTheoIdSanh(sanhCB.IdSanh);
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            testClickThemMon = true;
            if (txtBan.Text != "")
            {
                string tenSanhBan = (cbSanh.SelectedItem as Sanh).TenSanh + " - " + txtBan.Text;
                FrmAddFood f = new FrmAddFood((dataGridView_HDtheoBan.Tag as BanAn), tenSanhBan);

                if (Application.OpenForms["FrmAddFood"] == null)
                {
                    f.EventThemMonAn += F_EventThemMonAn;
                    f.Show();
                }
                else
                    Application.OpenForms["FrmAddFood"].Focus();
            }
            else
            {
                MessageBox.Show("Hãy chọn bàn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                testClickThemMon = false;
            }

        }

        //event hay, xem kỹ
        private void F_EventThemMonAn(object sender, EventArgs e)
        {
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);

            //lấy bàn ăn mới vì đã thay đổi thông tin trạng thái xuống database
            BanAn banAnThayThe = BanAnDAL.layBanAn((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);

            //chỉ resetButton khi thay đổi trạng thái bàn ăn
            if (banAnThayThe.TrangThai != (dataGridView_HDtheoBan.Tag as BanAn).TrangThai)
            {
                resetButton(dataGridView_HDtheoBan.Tag as BanAn, banAnThayThe);
                dataGridView_HDtheoBan.Tag = banAnThayThe;//test
            }
        }

        private void checkBoxXoa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxXoa.Checked == true)
            {
                nUDslXoa.Enabled = true;
                btnXoaMon.Enabled = true;
                checkBoxXoa.ForeColor = Color.Red;
            }
            else
            {
                nUDslXoa.Enabled = false;
                btnXoaMon.Enabled = false;
                checkBoxXoa.ForeColor = Color.Black;
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            testClickXoaMon = true;
            if (txtBan.Text != "")
            {
                if ((dataGridView_HDtheoBan.Tag as BanAn).TrangThai == "Khách")
                {
                    int dongHienTai = dataGridView_HDtheoBan.CurrentCell.RowIndex;
                    string tenMonAn = dataGridView_HDtheoBan.Rows[dongHienTai].Cells[0].Value.ToString();
                    int soLuong = (int)nUDslXoa.Value;
                    xoaMonAnTrongHoaDonTheoBan(tenMonAn, soLuong);


                    //hienThiHDtheoBan((txtTongTien.Tag as BanAn).IdBanAn);
                    //BanAn banAnThayThe = BanAnDAL.layBanAn((txtTongTien.Tag as BanAn).IdBanAn);

                    ////chỉ resetButton khi thay đổi trạng thái bàn ăn
                    //if (banAnThayThe.TrangThai != (txtTongTien.Tag as BanAn).TrangThai)
                    //{
                    //    resetButton(txtTongTien.Tag as BanAn, banAnThayThe);
                    //    txtTongTien.Tag = banAnThayThe;//test
                    //}
                }
                else MessageBox.Show("Hãy chọn bàn có hóa đơn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else MessageBox.Show("Hãy chọn bàn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btnDatCho_Click(object sender, EventArgs e)
        {
            FrmBookTable f = new FrmBookTable();
            f.ShowDialog();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (testClickThemMon == false)
            {
                txtBan.Text = ((sender as Button).Tag as BanAn).TenBan;
                txtTongTien.Tag = (sender as Button).Tag;
                dataGridView_HDtheoBan.Tag = (sender as Button).Tag;
                hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            }
            else
            {
                MessageBox.Show("Bạn chưa đóng khung thêm món ăn", "Thông Báo", MessageBoxButtons.OK);
                Application.OpenForms["FrmAddFood"].Focus();
            }
        }

        #endregion

        #region Methods

        private void hienThiHDtheoBan(int idBan)
        {
            List<ChiTietHoaDonTheoBan> list = HoaDonTheoBanDAL.layHoaDonTheoIdBanAn(idBan);
            dataGridView_HDtheoBan.DataSource = list;
            dataGridView_HDtheoBan.Columns[0].HeaderText = "Tên Thức Ăn";
            dataGridView_HDtheoBan.Columns[0].Width = 150;
            dataGridView_HDtheoBan.Columns[1].HeaderText = "Số Lượng";
            dataGridView_HDtheoBan.Columns[1].Width = 79;
            dataGridView_HDtheoBan.Columns[2].HeaderText = "Thành Tiền";
            dataGridView_HDtheoBan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_HDtheoBan.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_HDtheoBan.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            float tongTien = 0;
            for (int i = 0; i < list.Count; i++)
                tongTien += list[i].ThanhTien;

            //thay đổi giá trị tiền về việt nam đồng
            CultureInfo culture = new CultureInfo("vi-vN");
            txtTongTien.Text = tongTien.ToString("c", culture);
        }

        private void khoiTaoCbSanh()
        {
            List<Sanh> listSanh = SanhDAL.layDsSanh();
            cbSanh.DataSource = listSanh;
            cbSanh.DisplayMember = "TenSanh";
        }

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
            Button btn = new Button() { Width = this.widthButtonBanAn, Height = this.widthButtonBanAn };
            btn.Text = banAn.TenBan + "\n";
            btn.Tag = banAn; // mỗi button tạo ra tag vào nó bàn ăn đó
            btn.Text += banAn.TrangThai;
            btn.TextAlign = ContentAlignment.BottomCenter;

            //test pic cho button <phải bỏ thư mục Img vào bin>
            Bitmap bmp;
            switch (banAn.TrangThai)
            {
                case "Bàn Trống":
                    bmp = new Bitmap(@"Img\banTrong.png");
                    btn.Image = bmp;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.BackColor = Color.LightBlue;
                    break;
                case "Khách":
                    bmp = new Bitmap(@"Img\coNguoi.png");
                    btn.Image = bmp;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.BackColor = Color.LightPink;
                    break;
                case "Bàn Đặt Chỗ":
                    bmp = new Bitmap(@"Img\datCho.png");
                    btn.Image = bmp;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.BackColor = Color.LightGray;
                    break;
            }
            return btn;
        }

        //chỉ xóa 1 bàn r thêm vào
        private void thayTheBanAn(FlowLayoutPanel fl, Control banCanThayDoi, Control banThayDoi)
        {
            int index = fl.Controls.IndexOf(banCanThayDoi);
            if (index == -1) return;
            fl.Controls.RemoveAt(index);
            banCanThayDoi.Dispose();
            fl.Controls.Add(banThayDoi);
            fl.Controls.SetChildIndex(banThayDoi, index);
        }

        private void resetButton(BanAn banAnCanThayThe, BanAn banAnThayThe)
        {
            Button btnCanThayThe = new Button();
            foreach (Control c in flowLayoutPanel_BanAn.Controls)
                if (((c as Button).Tag as BanAn).IdBanAn == banAnCanThayThe.IdBanAn)
                { btnCanThayThe = c as Button; break; }

            thayTheBanAn(flowLayoutPanel_BanAn, btnCanThayThe, khoiTaoBanAn(banAnThayThe));
        }

        private void xoaMonAnTrongHoaDonTheoBan(string tenMonAn, int soLuongXoa)
        {
            int idHoaDon = HoaDonDAL.layIdHDchuaThanhToanTheoIDban((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            HoaDonTheoBanDAL.xoaMonAnTrenHoaDonTheoBan(idHoaDon, tenMonAn, soLuongXoa);
        }

        #endregion




    }
}
