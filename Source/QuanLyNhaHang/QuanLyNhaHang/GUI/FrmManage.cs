using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.GUI;
using QuanLyNhaHang.SqlDe;
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
        private TaiKhoan tkDangNhap = FrmBegin.tkDangNhap;

        private int widthButtonBanAn = Constant.widthButtonBanAnSizeNho, heightButtonBanAn = Constant.heightButtonBanAnSizeNho;

        public FrmManage()
        {
            InitializeComponent();
            khoiTaoCbSanh();
            this.Text += " - Tài khoản: " + tkDangNhap.UserName;
            cbSanh.Select(); //focus

            khoiTaoCbGopBan1();
        }

        #region Events


        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            HoaDonDAL.xoaHoaDonBan_HuyBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            resetButton(dataGridView_HDtheoBan.Tag as BanAn, BanAnDAL.layBanAn((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn));
            btnHuyBan.Enabled = false;
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            BanAn banChuyenSang = cbChuyenBan.SelectedItem as BanAn;
            BanAnDAL.chuyenBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn, banChuyenSang.IdBanAn);
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            resetButton(dataGridView_HDtheoBan.Tag as BanAn, BanAnDAL.layBanAn((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn));
            resetButton(banChuyenSang, BanAnDAL.layBanAn(banChuyenSang.IdBanAn));

            cbChuyenBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            cbChuyenBan.DataSource = null;
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

            dataGridView_HDtheoBan.DataSource = null;
            txtTongTien.Text = "";
            btnHuyBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            cbChuyenBan.Enabled = false;
            cbChuyenBan.DataSource = null;

            //chỉ cho gộp bàn trong sảnh
            cbGopBan1.DataSource = null;
            cbGopBan2.DataSource = null;
            khoiTaoCbGopBan1();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
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
            }
        }

        //event chính, xem kỹ
        private void F_EventThemMonAn(object sender, EventArgs e)
        {
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);

            //lấy bàn ăn mới vì đã thay đổi thông tin trạng thái xuống database
            BanAn banAnThayThe = BanAnDAL.layBanAn((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);

            //chỉ resetButton khi thay đổi trạng thái bàn ăn
            if (banAnThayThe.TrangThai != (dataGridView_HDtheoBan.Tag as BanAn).TrangThai)
            {
                dataGridView_HDtheoBan.Tag = banAnThayThe;//test
                resetButton(dataGridView_HDtheoBan.Tag as BanAn, banAnThayThe);
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (txtBan.Text != "")
            {
                if ((dataGridView_HDtheoBan.Tag as BanAn).TrangThai == Constant.trangThaiBanTrong)
                {
                    MessageBox.Show("Hãy chọn bàn có hóa đơn", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                if ((dataGridView_HDtheoBan.Tag as BanAn).TrangThai == Constant.trangThaiCoNguoiTrongBan)
                {
                    int idBan = (dataGridView_HDtheoBan.Tag as BanAn).IdBanAn;
                    int dongHienTai = dataGridView_HDtheoBan.CurrentCell.RowIndex;
                    string tenMonAn = dataGridView_HDtheoBan.Rows[dongHienTai].Cells[0].Value.ToString();
                    int soLuong = (int)nUDslXoa.Value;
                    xoaMonAnTrongHoaDonTheoBan(tenMonAn, soLuong);
                    hienThiHDtheoBan(idBan);
                    F_EventThemMonAn(sender, e);
                    cbChuyenBan.DataSource = null;
                    btnChuyenBan.Enabled = false;
                    cbChuyenBan.Enabled = false;
                    return;
                }
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
            if (Application.OpenForms["FrmAddFood"] != null)
            {
                MessageBox.Show("Bạn chưa đóng khung thêm món ăn", "Thông Báo", MessageBoxButtons.OK);
                Application.OpenForms["FrmAddFood"].Focus();
                return;
            }

            if (((sender as Button).Tag as BanAn).TrangThai == Constant.trangThaiCoNguoiTrongBan)
            {
                cbChuyenBan.Enabled = true;
                btnChuyenBan.Enabled = true;
                btnHuyBan.Enabled = true;
                khoiTaoCBchuyenBan(((sender as Button).Tag as BanAn).IdBanAn, cbChuyenBan);
            }
            else
            {
                cbChuyenBan.Enabled = false;
                btnHuyBan.Enabled = false;
                btnChuyenBan.Enabled = false;
                cbChuyenBan.DataSource = null;
            }

            txtBan.Text = ((sender as Button).Tag as BanAn).TenBan;
            dataGridView_HDtheoBan.Tag = (sender as Button).Tag;
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (cbGopBan1.SelectedItem != null && cbGopBan2.SelectedItem != null)
            {
                FrmQuesGopBan f = new FrmQuesGopBan(listBanCoTheGop());
                f.EventGopBan += F_EventGopBan;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa có đủ bàn có thể gộp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void F_EventGopBan(object sender, EventTruyenDuLieu e)
        {
            BanAnDAL.gopBan((cbGopBan1.SelectedItem as BanAn).IdBanAn, (cbGopBan2.SelectedItem as BanAn).IdBanAn, e.BanAnGop.IdBanAn);
            hienThiHDtheoBan((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            
            khoiTaoBanTheoIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
        }

        private void cbGopBan1_SelectedIndexChanged(object sender, EventArgs e)
        {
            khoiTaoCbGopBan2();
        }

        private void FrmManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["FrmAddFood"] != null)
                Application.OpenForms["FrmAddFood"].Close();
        }

        #endregion

        #region Methods

        private List<BanAn> listBanCoTheGop()
        {
            List<BanAn> l = new List<BanAn>();
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn((cbSanh.SelectedItem as Sanh).IdSanh);
            foreach (BanAn ba in listBanAn)
            {
                if (ba.IdBanAn == (cbGopBan1.SelectedItem as BanAn).IdBanAn)
                    l.Add(ba);
                if (ba.IdBanAn == (cbGopBan2.SelectedItem as BanAn).IdBanAn)
                    l.Add(ba);
                if (ba.TrangThai == Constant.trangThaiBanTrong)
                    l.Add(ba);
            }
            return l;
        }

        private void khoiTaoCBchuyenBan(int idBanAnCoKhachDangClick, ComboBox cb)
        {
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn((cbSanh.SelectedItem as Sanh).IdSanh);
            List<BanAn> kq = new List<BanAn>();
            foreach (BanAn ba in listBanAn)
                if (ba.IdBanAn != idBanAnCoKhachDangClick)
                    kq.Add(ba);
            cb.DataSource = kq;
            cb.DisplayMember = "TenBan";
        }

        private void khoiTaoCbGopBan1()
        {
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn((cbSanh.SelectedItem as Sanh).IdSanh);
            List<BanAn> kq = new List<BanAn>();
            foreach (BanAn ba in listBanAn)
                if (ba.TrangThai != Constant.trangThaiBanTrong)
                    kq.Add(ba);
            cbGopBan1.DataSource = kq;
            cbGopBan1.DisplayMember = "TenBan";
        }

        private void khoiTaoCbGopBan2()
        {
            List<BanAn> kq = new List<BanAn>();
            for (int i = 0; i < cbGopBan1.Items.Count; i++)
            {
                if (cbGopBan1.Items[i] != cbGopBan1.SelectedItem)
                    kq.Add(cbGopBan1.Items[i] as BanAn);
            }
            cbGopBan2.DataSource = kq;
            cbGopBan2.DisplayMember = "TenBan";
        }

        private void hienThiHDtheoBan(int idBan)
        {
            khoiTaoCbGopBan1();
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

        public void khoiTaoBanTheoIdSanh(int idSanh)
        {
            flowLayoutPanel_BanAn.Controls.Clear();
            List<BanAn> listBanAn = BanAnDAL.layDsBanAn(idSanh);
            foreach (BanAn i in listBanAn)
            {
                Button btn = khoiTaoBanAn(i);
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
            //phải để event ở đây, k để trên khởi tạo danh sách bàn ăn <bug>
            btn.Click += Btn_Click;
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



        //test k dc xóa
        private void FrmManage_Load(object sender, EventArgs e)
        {
            BanAnListen b = new BanAnListen((cbSanh.SelectedItem as Sanh).IdSanh);
        }







        private void xoaMonAnTrongHoaDonTheoBan(string tenMonAn, int soLuongXoa)
        {
            int idHoaDon = HoaDonDAL.layIdHDchuaThanhToanTheoIDban((dataGridView_HDtheoBan.Tag as BanAn).IdBanAn);
            HoaDonTheoBanDAL.xoaMonAnTrenHoaDonTheoBan(idHoaDon, tenMonAn, soLuongXoa);
        }

        
        #endregion




    }
}
