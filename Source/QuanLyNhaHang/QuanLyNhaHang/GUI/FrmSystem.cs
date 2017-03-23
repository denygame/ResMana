﻿using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
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


        BindingSource danhmucBinding = new BindingSource();
        BindingSource thucAnBinding = new BindingSource();
        BindingSource sanhBinding = new BindingSource();
        BindingSource banAnBinding = new BindingSource();
        BindingSource taiKhoanBinding = new BindingSource();

        private string testTenDanhMuc = "";

        #region Methods

        #region - KHỞI TẠO -
        private void Initialize()
        {
            getListUncheckBill();

            setTime1Month();

            dataGridView_DanhMuc.DataSource = danhmucBinding;
            dataGridView_ThucAn.DataSource = thucAnBinding;
            dataGridView_Sanh.DataSource = sanhBinding;
            dataGridView_BanAn.DataSource = banAnBinding;
            dataGridView_TaiKhoan.DataSource = taiKhoanBinding;

            //binding làm hàm riêng vì còn gọi lạo hàm load khi thêm xóa sửa
            loadDataCategory();
            loadDataFood();
            loadDataSanh();
            loadDataTable();
            loadDataAccount();

            bindingAccount();
            bindingCategory();
            bindingFood();
            bindingSanh();
            bindingTable();

            loadCbTenSanh();
            loadCbCategoryInFood();
        }

        private void loadDataAccount()
        {
            taiKhoanBinding.DataSource = AccountDAL.getListAccount();
        }

        private void bindingAccount()
        {
            dataGridView_TaiKhoan.Columns[0].HeaderText = "Username";
            dataGridView_TaiKhoan.Columns[1].HeaderText = "ID Nhân Viên";
            dataGridView_TaiKhoan.Columns[2].HeaderText = "Loại Tài Khoản";

            txtUsername.DataBindings.Add(new Binding("Text", taiKhoanBinding, "userName", true, DataSourceUpdateMode.Never));
            txtIdNhanVien.DataBindings.Add(new Binding("Text", taiKhoanBinding, "idNhanVien", true, DataSourceUpdateMode.Never));
        }

        private void loadDataSanh()
        {
            sanhBinding.DataSource = SanhDAL.getListSanh();
        }

        private void bindingSanh()
        {
            dataGridView_Sanh.Columns[0].HeaderText = "ID Sảnh";
            dataGridView_Sanh.Columns[1].HeaderText = "Tên Sảnh";

            txtIdSanh.DataBindings.Add(new Binding("Text", sanhBinding, "IdSanh", true, DataSourceUpdateMode.Never));
            txtTenSanh.DataBindings.Add(new Binding("Text", sanhBinding, "TenSanh", true, DataSourceUpdateMode.Never));
        }

        private void loadDataFood()
        {
            thucAnBinding.DataSource = FoodDAL.getListFood();
        }

        private void bindingFood()
        {
            dataGridView_ThucAn.Columns[0].HeaderText = "ID Thức Ăn";
            dataGridView_ThucAn.Columns[1].HeaderText = "Tên Món Ăn";
            dataGridView_ThucAn.Columns[2].HeaderText = "Danh Mục";
            dataGridView_ThucAn.Columns[3].HeaderText = "Giá Tiền";

            txtIdThucAn.DataBindings.Add(new Binding("Text", thucAnBinding, "IdThucAn", true, DataSourceUpdateMode.Never));
            txtTenThucAn.DataBindings.Add(new Binding("Text", thucAnBinding, "TenThucAn", true, DataSourceUpdateMode.Never));
            txtGiaTienThucAn.DataBindings.Add(new Binding("Text", thucAnBinding, "GiaTien", true, DataSourceUpdateMode.Never));
        }

        private void loadCbCategoryInFood()
        {
            cbDanhMucThucAn.DataSource = CategoryDAL.getListCategory();
            cbDanhMucThucAn.DisplayMember = "TenMenu";
        }

        private void loadCbTenSanh()
        {
            cbTenSanh.DataSource = SanhDAL.getListSanh();
            cbTenSanh.DisplayMember = "TenSanh";
        }

        private void loadDataCategory()
        {
            danhmucBinding.DataSource = CategoryDAL.getListCategory();
        }

        private void bindingCategory()
        {
            dataGridView_DanhMuc.Columns[0].HeaderText = "ID Danh Mục";
            dataGridView_DanhMuc.Columns[1].HeaderText = "Tên Danh Mục";

            //true là tự động ép kiểu (ví dụ ép kiểu int về text trên textbox)
            //IdMenu, TenMenu là tên trong DTO.DanhMuc <hệ public>
            txtIdDanhMuc.DataBindings.Add(new Binding("Text", danhmucBinding, "idMenu", true, DataSourceUpdateMode.Never));
            txtTenDanhMuc.DataBindings.Add(new Binding("Text", danhmucBinding, "tenMenu", true, DataSourceUpdateMode.Never));
        }

        private void loadDataTable()
        {
            banAnBinding.DataSource = TableDAL.getListTable();
        }

        private void bindingTable()
        {
            dataGridView_BanAn.Columns[0].HeaderText = "ID Bàn";
            dataGridView_BanAn.Columns[1].HeaderText = "Tên Sảnh";
            dataGridView_BanAn.Columns[2].HeaderText = "Tên Bàn";
            dataGridView_BanAn.Columns[3].HeaderText = "Trạng Thái";

            txtIdBanAn.DataBindings.Add(new Binding("Text", banAnBinding, "idBanAn", true, DataSourceUpdateMode.Never));
            txtTenBan.DataBindings.Add(new Binding("Text", banAnBinding, "tenBan", true, DataSourceUpdateMode.Never));
            txtTrangThai.DataBindings.Add(new Binding("Text", banAnBinding, "trangThai", true, DataSourceUpdateMode.Never));
        }

        private void setTime1Month()
        {
            DateTime today = DateTime.Now;
            dateTimePicker_From.Value = new DateTime(today.Year, today.Month, 1);

            //thêm một tháng trừ 1 ngày => cuối tháng
            dateTimePicker_To.Value = dateTimePicker_From.Value.AddMonths(1).AddDays(-1);
        }

        #endregion


        private void thietKeThemXoa(string themSua, string tab, FlowLayoutPanel fl)
        {
            Button btnTX = new Button();
            btnTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnTX.Name = "btn" + themSua + tab;
            btnTX.Size = new System.Drawing.Size(155, 32);
            btnTX.TabIndex = 17;
            if (themSua == Constant.them)
                btnTX.Text = "Thêm";
            else btnTX.Text = "Sửa";
            btnTX.ForeColor = Color.Blue;
            btnTX.UseVisualStyleBackColor = false;

            btnTX.Click += btnTX_Click;
            fl.Controls.Add(btnTX);


            Button btnHuy = new Button();
            btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnHuy.Name = "btnHuy" + tab;
            btnHuy.ForeColor = Color.Red;
            btnHuy.Size = new System.Drawing.Size(155, 32);
            btnHuy.TabIndex = 17;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;

            btnHuy.Click += btnHuy_Click;
            fl.Controls.Add(btnHuy);
        }


        private void insertCategory()
        {
            if (txtTenDanhMuc.Text != "")
            {
                if (CategoryDAL.insertCategory(txtTenDanhMuc.Text))
                {
                    MessageBox.Show("Thêm danh mục thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.None);
                    loadDataCategory();
                    setButtonHuyDanhMuc();
                    txtTenDanhMuc.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm danh mục", "Thông Báo", MessageBoxButtons.OK);
                    txtTenDanhMuc.Text = "";
                    txtTenDanhMuc.Focus();
                }
            }
            else MessageBox.Show("Bạn chưa nhập vào tên Danh Mục", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void setButtonHuyDanhMuc()
        {
            panel11.Visible = true;
            fl_testDM.Controls.Clear();
            panel_IdDM.Visible = true;
            txtIdDanhMuc.Enabled = true;

            panel_TenDanhMuc.Location = new Point(3, 63);
            txtTenDanhMuc.ReadOnly = true;
            txtTenDanhMuc.Text = testTenDanhMuc;
        }

        private void setButtonHuyThucAn()
        {
            panel14.Visible = true;
            fl_testThucAn.Controls.Clear();
            panel_idThucan.Visible = true;
            txtIdThucAn.Enabled = true;

            panel_tenThucAn.Location = new Point(3, 63);
            panel_DanhMucThucAn.Location = new Point(3, 122);
            panel_GiaThucAn.Location = new Point(3, 181);
        }

        private void setButtonHuySanh()
        {
            panel23.Visible = true;
            fl_Sanh.Controls.Clear();
            panel_idSanh.Visible = true;
            txtIdSanh.Enabled = true;

            panel_tenSanh.Location = new Point(3, 63);
        }

        private void setButtonHuyBanAn()
        {
            panel30.Visible = true;
            fl_BanAn.Controls.Clear();
            panel_idBan.Visible = true;
            txtIdBanAn.Enabled = true;

            panel_tenBan.Location = new Point(3, 63);
            panel_cnTTban.Location = new Point(3, 122);
            panel_tenSanhBanAn.Location = new Point(3, 181);
        }

        private void setButtonHuyTaiKhoan()
        {
            panel39.Visible = true;
            fl_TaiKhoan.Controls.Clear();
            fl_TaiKhoan.Visible = false;
            btnRestPass.Visible = true;
            txtUsername.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if ((sender as Button).Name.Contains("DanhMuc"))
            {
                setButtonHuyDanhMuc();
                return;
            }
            if ((sender as Button).Name.Contains("ThucAn"))
            {
                setButtonHuyThucAn();
                return;
            }
            if ((sender as Button).Name.Contains("Sanh"))
            {
                setButtonHuySanh();
                return;
            }
            if ((sender as Button).Name.Contains("BanAn"))
            {
                setButtonHuyBanAn();
                return;
            }
            if ((sender as Button).Name.Contains("TK"))
            {
                setButtonHuyTaiKhoan();
                return;
            }
        }

        private void btnTX_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Name)
            {
                case "btnThemDanhMuc":
                    insertCategory();
                    break;
            }
        }

        private void getListUncheckBill()
        {
            dataGridView_HoaDon.DataSource = BillDAL.getListUncheckBill();

            dataGridView_HoaDon.Columns[0].HeaderText = "Tên Sảnh";
            dataGridView_HoaDon.Columns[1].HeaderText = "Tên Bàn";
            dataGridView_HoaDon.Columns[2].HeaderText = "Ngày Đến";
            dataGridView_HoaDon.Columns[3].HeaderText = "Trạng Thái";
        }
        #endregion

        #region Events
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            panel_IdDM.Visible = false;
            thietKeThemXoa(Constant.them, "DanhMuc", fl_testDM);
            panel11.Visible = false;

            panel_TenDanhMuc.Location = new Point(3, 4);

            testTenDanhMuc = txtTenDanhMuc.Text;
            txtTenDanhMuc.Text = "";
            txtTenDanhMuc.ReadOnly = false;
            txtTenDanhMuc.Focus();
        }

        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            thietKeThemXoa(Constant.sua, "DanhMuc", fl_testDM);
            panel11.Visible = false;
            txtIdDanhMuc.Enabled = false;
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            if(txtTenDanhMuc.Text == "")
            {
                MessageBox.Show("Danh mục rỗng, hãy thêm danh mục!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (CategoryDAL.deleteCategory(Convert.ToInt32(txtIdDanhMuc.Text)))
            {
                MessageBox.Show("Xóa danh mục thành công", "Thông Báo", MessageBoxButtons.OK);
                loadDataCategory();
                loadDataFood();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục", "Thông Báo", MessageBoxButtons.OK);
            }
        }

        private void btnThemThucAn_Click(object sender, EventArgs e)
        {
            panel_idThucan.Visible = false;
            thietKeThemXoa(Constant.them, "ThucAn", fl_testThucAn);
            panel14.Visible = false;

            panel_tenThucAn.Location = new Point(3, 4);
            panel_DanhMucThucAn.Location = new Point(3, 63);
            panel_GiaThucAn.Location = new Point(3, 122);
        }

        private void txtIdThucAn_TextChanged(object sender, EventArgs e)
        {
            //khi id thức ăn thay đổi thì binding combobox danh mục
            int idThucAn = Convert.ToInt32(txtIdThucAn.Text);

            Food thucAn = FoodDAL.getFoodById(idThucAn);

            //vì cùng chung 1 list làm datasource nên chọn vị trí dc
            List<DanhMuc> list = CategoryDAL.getListCategory();
            int dem = 0;
            foreach (DanhMuc i in list)
            {
                if (i.IdMenu == thucAn.IdMenu)
                    break;
                dem++;
            }
            cbDanhMucThucAn.SelectedIndex = dem;
        }

        private void txtIdBanAn_TextChanged(object sender, EventArgs e)
        {
            int idBanAn = Convert.ToInt32(txtIdBanAn.Text);
            Table table = TableDAL.getTable(idBanAn);
            List<Sanh> list = SanhDAL.getListSanh();
            int dem = 0;
            foreach (Sanh s in list)
            {
                if (s.IdSanh == table.IdSanh)
                    break;
                dem++;
            }
            cbTenSanh.SelectedIndex = dem;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            Account acc = AccountDAL.getAccount(txtUsername.Text);
            switch (acc.LoaiTK)
            {
                case 0: txtLoaiTaiKhoan.Text = "Nhân Viên"; break;
                case 1: txtLoaiTaiKhoan.Text = "Quản Lý"; break;
            }
        }

        private void btnSuaThucAn_Click(object sender, EventArgs e)
        {
            thietKeThemXoa(Constant.sua, "ThucAn", fl_testThucAn);
            panel14.Visible = false;
            txtIdThucAn.Enabled = false;
        }

        private void btnXoaThucAn_Click(object sender, EventArgs e)
        {

        }

        private void btnThemSanh_Click(object sender, EventArgs e)
        {
            panel_idSanh.Visible = false;
            thietKeThemXoa(Constant.them, "Sanh", fl_Sanh);
            panel23.Visible = false;

            panel_tenSanh.Location = new Point(3, 4);
        }

        private void btnSuaSanh_Click(object sender, EventArgs e)
        {
            thietKeThemXoa(Constant.sua, "Sanh", fl_Sanh);
            panel23.Visible = false;
            txtIdSanh.Enabled = false;
        }

        private void btnXoaSanh_Click(object sender, EventArgs e)
        {

        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            panel_idBan.Visible = false;
            thietKeThemXoa(Constant.them, "BanAn", fl_BanAn);
            panel30.Visible = false;

            panel_tenBan.Location = new Point(3, 4);
            panel_cnTTban.Location = new Point(3, 63);
            panel_tenSanhBanAn.Location = new Point(3, 122);
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            thietKeThemXoa(Constant.sua, "BanAn", fl_BanAn);
            panel30.Visible = false;
            txtIdBanAn.Enabled = false;
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            btnRestPass.Visible = false;
            fl_TaiKhoan.Visible = true;
            thietKeThemXoa(Constant.sua, "TK", fl_TaiKhoan);
            panel39.Visible = false;
            txtUsername.Enabled = false;
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void FrmSystem_Load(object sender, EventArgs e)
        {
            Initialize();


        }

        private void btnTrangTruocBill_Click(object sender, EventArgs e)
        {

        }

        private void btnTrangSauBill_Click(object sender, EventArgs e)
        {

        }


        #endregion
    }
}
