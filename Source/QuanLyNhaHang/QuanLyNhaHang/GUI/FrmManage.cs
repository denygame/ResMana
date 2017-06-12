using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private Account tkDangNhap = FrmBegin.tkDangNhap;

        private int widthButtonBanAn = Constant.widthButtonBanAnSizeNho, heightButtonBanAn = Constant.heightButtonBanAnSizeNho;


        public FrmManage()
        {
            InitializeComponent();
        }


        #region - Events -

        #region - Rê chuột thì kiểm tra LoadTable - 
        private void FrmManage_MouseEnter(object sender, EventArgs e)
        {
            loadClient();
        }

        private void flowLayoutPanel_BanAn_MouseEnter(object sender, EventArgs e)
        {
            loadClient();
        }

        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            loadClient();
        }
        #endregion

        private void FrmManage_Load(object sender, EventArgs e)
        {
            loadCbSanh();
            this.Text += "  -+-  Tài Khoản: " + tkDangNhap.UserName;
            cbSanh.Select(); //focus
            loadCbLumpTable1();
        }

        private void btnHuyBan_Click(object sender, EventArgs e)
        {
            if (testCloseFormAddFood() == 0) return;

            BillDAL.deleteBill_CancleTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
            resetTagTable();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (testCloseFormAddFood() == 0) return;

            Table banChuyenSang = cbChuyenBan.SelectedItem as Table;
            TableDAL.switchTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn, banChuyenSang.IdBanAn);
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
            cbChuyenBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            cbChuyenBan.DataSource = null;
            btnHuyBan.Enabled = false;
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
            loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (dataGridView_HDtheoBan.Tag == null)
            {
                MessageBox.Show("Hãy chọn bàn cần thanh toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idBill = BillDAL.getIdBillUncheckByIdTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn);

            if (idBill != -1)
            {
                string name = SanhDAL.getSanh((cbSanh.SelectedItem as Sanh).IdSanh).TenSanh + " -  " + TableDAL.getTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn).TenBan;
                FrmBillCheckOut f = new FrmBillCheckOut(name, tkDangNhap, (dataGridView_HDtheoBan.Tag as Table).IdBanAn);
                f.Truyen += F_Truyen;
                f.ShowDialog();
            }
        }

        private void F_Truyen(object sender, EventArgs e)
        {
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);

            resetTagTable();
        }

        //load bàn theo cbSanh
        private void cbSanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBan.Text = "";
            Sanh sanhCB = cbSanh.SelectedItem as Sanh;
            loadTableWithIdSanh(sanhCB.IdSanh);

            dataGridView_HDtheoBan.DataSource = null;
            txtTongTien.Text = "";
            btnHuyBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            cbChuyenBan.Enabled = false;
            cbChuyenBan.DataSource = null;

            //chỉ cho gộp bàn trong sảnh
            cbGopBan1.DataSource = null;
            cbGopBan2.DataSource = null;
            loadCbLumpTable1();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (txtBan.Text != "")
            {
                string tenSanhBan = (cbSanh.SelectedItem as Sanh).TenSanh + " - " + txtBan.Text;
                FrmAddFood f = new FrmAddFood((dataGridView_HDtheoBan.Tag as Table), tenSanhBan);

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

        /// <summary>
        /// event chính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void F_EventThemMonAn(object sender, EventArgs e)
        {
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);

            //lấy bàn ăn mới vì đã thay đổi thông tin trạng thái xuống database
            Table banAnThayThe = TableDAL.getTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn);

            //chỉ reset Button khi thay đổi trạng thái bàn ăn
            if (banAnThayThe.TrangThai != (dataGridView_HDtheoBan.Tag as Table).TrangThai)
            {
                dataGridView_HDtheoBan.Tag = banAnThayThe;//test
                loadTableWithIdSanh(banAnThayThe.IdSanh);
                testSwitchTable();
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (txtBan.Text != "")
            {
                if ((dataGridView_HDtheoBan.Tag as Table).TrangThai == Constant.trangThaiBanTrong)
                {
                    MessageBox.Show("Hãy chọn bàn có hóa đơn", "Thông Báo", MessageBoxButtons.OK);
                    return;
                }
                if ((dataGridView_HDtheoBan.Tag as Table).TrangThai == Constant.trangThaiCoNguoiTrongBan)
                {
                    int idBan = (dataGridView_HDtheoBan.Tag as Table).IdBanAn;
                    int dongHienTai = dataGridView_HDtheoBan.CurrentCell.RowIndex;
                    string tenMonAn = dataGridView_HDtheoBan.Rows[dongHienTai].Cells[0].Value.ToString();
                    int soLuong = (int)nUDslXoa.Value;
                    deleteFoodInBill(tenMonAn, soLuong);
                    showBill(idBan);
                    F_EventThemMonAn(sender, e);
                    cbChuyenBan.DataSource = null;
                    btnChuyenBan.Enabled = false;
                    cbChuyenBan.Enabled = false;
                    return;
                }
            }
            else MessageBox.Show("Hãy chọn bàn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        public void Btn_Click(object sender, EventArgs e)
        {
            if (testCloseFormAddFood() == 0) return;

            if (((sender as Button).Tag as Table).TrangThai == Constant.trangThaiCoNguoiTrongBan)
            {
                cbChuyenBan.Enabled = true;
                btnChuyenBan.Enabled = true;
                btnHuyBan.Enabled = true;
                loadCbSwitchTable(((sender as Button).Tag as Table).IdBanAn, cbChuyenBan);
            }
            else
            {
                cbChuyenBan.Enabled = false;
                btnHuyBan.Enabled = false;
                btnChuyenBan.Enabled = false;
                cbChuyenBan.DataSource = null;
            }

            txtBan.Text = ((sender as Button).Tag as Table).TenBan;
            dataGridView_HDtheoBan.Tag = (sender as Button).Tag;
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
        }

        private void btnGopBan_Click(object sender, EventArgs e)
        {
            if (cbGopBan1.SelectedItem != null && cbGopBan2.SelectedItem != null)
            {
                FrmQuesGopBan f = new FrmQuesGopBan(listTableCanLump());
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
            TableDAL.lumpTable((cbGopBan1.SelectedItem as Table).IdBanAn, (cbGopBan2.SelectedItem as Table).IdBanAn, e.BanAnGop.IdBanAn);
            showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
        }

        private void cbGopBan1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCbLumpTable2();
        }

        private void FrmManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms["FrmAddFood"] != null)
                Application.OpenForms["FrmAddFood"].Close();
        }

        #endregion

        #region - Methods -
        /// <summary>
        /// hàm load tất cả client đăng nhập database khi database change
        /// </summary>
        private void loadClient()
        {
            //2 máy trở lên mới làm thì > 1
            if (IPConnectionDAL.countIPconnect() > 0)
            {
                if (TestLoadTableDAL.getCountTableChange() > 0)
                {
                    List<TestLoadTable> list = TestLoadTableDAL.getListIdTableChange();
                    foreach (TestLoadTable i in list)
                    {
                        Table t = TableDAL.getTable(i.Id);
                        foreach (Control c in flowLayoutPanel_BanAn.Controls)
                            if (((c as Button).Tag as Table).IdBanAn == i.Id)
                                if (((c as Button).Tag as Table).TrangThai != t.TrangThai)
                                {
                                    loadTableWithIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
                                    if (dataGridView_HDtheoBan.Tag != null)
                                        showBill((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
                                    return;
                                }
                    }
                }
                else return;
            }
        }


        /// <summary>
        /// dùng cho nút thanh toán vs hủy bàn
        /// </summary>
        private void resetTagTable()
        {
            btnHuyBan.Enabled = false;
            cbChuyenBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            cbChuyenBan.DataSource = null;
            cbSanh.Select();
            txtBan.Text = "";
        }

        /// <summary>
        /// list bàn có thể gộp
        /// </summary>
        /// <returns></returns>
        private List<Table> listTableCanLump()
        {
            List<Table> l = new List<Table>();
            List<Table> listBanAn = TableDAL.getListTableByIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
            foreach (Table ba in listBanAn)
            {
                if (ba.IdBanAn == (cbGopBan1.SelectedItem as Table).IdBanAn)
                    l.Add(ba);
                if (ba.IdBanAn == (cbGopBan2.SelectedItem as Table).IdBanAn)
                    l.Add(ba);
                if (ba.TrangThai == Constant.trangThaiBanTrong)
                    l.Add(ba);
            }
            return l;
        }

        /// <summary>
        /// truyền data cb chuyển bàn
        /// </summary>
        /// <param name="idBanAnCoKhachDangClick"></param>
        /// <param name="cb"></param>
        private void loadCbSwitchTable(int idBanAnCoKhachDangClick, ComboBox cb)
        {
            if (cbSanh.SelectedItem != null)
            {
                List<Table> listBanAn = TableDAL.getListTableByIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
                List<Table> kq = new List<Table>();
                foreach (Table ba in listBanAn)
                    if (ba.IdBanAn != idBanAnCoKhachDangClick)
                        kq.Add(ba);
                cb.DataSource = kq;
                cb.DisplayMember = "TenBan";
            }
        }

        /// <summary>
        /// truyền data cb gộp bàn
        /// </summary>
        private void loadCbLumpTable1()
        {
            if (cbSanh.SelectedItem != null)
            {
                List<Table> listBanAn = TableDAL.getListTableByIdSanh((cbSanh.SelectedItem as Sanh).IdSanh);
                List<Table> kq = new List<Table>();
                foreach (Table ba in listBanAn)
                    if (ba.TrangThai != Constant.trangThaiBanTrong)
                        kq.Add(ba);
                cbGopBan1.DataSource = kq;
                cbGopBan1.DisplayMember = "TenBan";
            }
        }

        private void loadCbLumpTable2()
        {
            List<Table> kq = new List<Table>();
            for (int i = 0; i < cbGopBan1.Items.Count; i++)
            {
                if (cbGopBan1.Items[i] != cbGopBan1.SelectedItem)
                    kq.Add(cbGopBan1.Items[i] as Table);
            }
            cbGopBan2.DataSource = kq;
            cbGopBan2.DisplayMember = "TenBan";
        }

        /// <summary>
        /// hiển thị hóa đơn theo bàn
        /// </summary>
        /// <param name="idBan"></param>
        private void showBill(int idBan)
        {
            loadCbLumpTable1();
            List<ChiTietHoaDonTheoBan> list = HoaDonTheoBanDAL.getBillByIdTable(idBan);
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

        /// <summary>
        /// truyền data cb sảnh
        /// </summary>
        private void loadCbSanh()
        {
            List<Sanh> listSanh = SanhDAL.getListSanh();
            cbSanh.DataSource = listSanh;
            cbSanh.DisplayMember = "TenSanh";
        }

        /// <summary>
        /// tạo các bàn theo id sảnh
        /// </summary>
        /// <param name="idSanh"></param>
        private void loadTableWithIdSanh(int idSanh)
        {
            flowLayoutPanel_BanAn.Controls.Clear();
            if (cbSanh.SelectedItem != null)
            {
                List<Table> listBanAn = TableDAL.getListTableByIdSanh(idSanh);
                foreach (Table i in listBanAn)
                {
                    Button btn = initTable(i);
                    flowLayoutPanel_BanAn.Controls.Add(btn);
                }
            }
        }

        //hàm tạo bàn ăn (test lại phần default)
        private Button initTable(Table banAn)
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
                default:
                    bmp = new Bitmap(@"Img\banTrong.png");
                    btn.Image = bmp;
                    btn.ImageAlign = ContentAlignment.TopCenter;
                    btn.BackColor = Color.LightBlue;
                    break;
            }
            //phải để event ở đây, k để trên khởi tạo danh sách bàn ăn <bug>
            btn.Click += Btn_Click;
            btn.MouseEnter += Btn_MouseEnter;
            return btn;
        }



        //chỉ xóa 1 bàn r thêm vào <k dùng đến?>
        private void thayTheBanAn(FlowLayoutPanel fl, Control banCanThayDoi, Control banThayDoi)
        {
            int index = fl.Controls.IndexOf(banCanThayDoi);
            if (index == -1) return;
            fl.Controls.RemoveAt(index);
            banCanThayDoi.Dispose();
            fl.Controls.Add(banThayDoi);
            fl.Controls.SetChildIndex(banThayDoi, index);
        }

        private void resetButton(Table banAnCanThayThe, Table banAnThayThe)
        {
            Button btnCanThayThe = new Button();
            foreach (Control c in flowLayoutPanel_BanAn.Controls)
                if (((c as Button).Tag as Table).IdBanAn == banAnCanThayThe.IdBanAn)
                { btnCanThayThe = c as Button; break; }

            thayTheBanAn(flowLayoutPanel_BanAn, btnCanThayThe, initTable(banAnThayThe));
        }



        private void deleteFoodInBill(string tenMonAn, int soLuongXoa)
        {
            int idHoaDon = BillDAL.getIdBillUncheckByIdTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn);
            HoaDonTheoBanDAL.deleteFoodInBill(idHoaDon, tenMonAn, soLuongXoa);
        }

        /// <summary>
        /// kiểm tra có hóa đơn thì hiện cb
        /// </summary>
        private void testSwitchTable()
        {
            if ((dataGridView_HDtheoBan.Tag as Table).TrangThai == Constant.trangThaiCoNguoiTrongBan)
            {
                cbChuyenBan.Enabled = true;
                btnChuyenBan.Enabled = true;
                btnHuyBan.Enabled = true;
                loadCbSwitchTable((dataGridView_HDtheoBan.Tag as Table).IdBanAn, cbChuyenBan);
            }
            else
            {
                cbChuyenBan.Enabled = false;
                btnHuyBan.Enabled = false;
                btnChuyenBan.Enabled = false;
                cbChuyenBan.DataSource = null;
            }
        }



        /// <summary>
        /// kiểm tra xem có đóng form add food chưa
        /// </summary>
        /// <returns></returns>
        private int testCloseFormAddFood()
        {
            if (Application.OpenForms["FrmAddFood"] != null)
            {
                MessageBox.Show("Bạn chưa đóng khung thêm món ăn", "Thông Báo", MessageBoxButtons.OK);
                Application.OpenForms["FrmAddFood"].Focus();
                return 0;
            }
            return 1;
        }

        #endregion
        
    }
}
