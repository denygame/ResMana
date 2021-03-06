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
    public partial class FrmAddFood : Form
    {
        private Table banAn;
        private Account tkDangNhap = FrmBegin.tkDangNhap;

        private event EventHandler eventThemMonAn;
        public event EventHandler EventThemMonAn
        {
            add { eventThemMonAn += value; }
            remove { eventThemMonAn -= value; }
        }


        public FrmAddFood(Table ban, string tenSanh_Ban)
        {
            InitializeComponent();
            cbDanhMuc.Select();    //focus test
            loadCbCategory();
            this.banAn = ban;
            txtName.Text = tenSanh_Ban;
        }

        #region - Events -
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int idHoaDon = BillDAL.getIdBillUncheckByIdTable(this.banAn.IdBanAn);
            int idThucAn = (cbMonAn.SelectedItem as Food).IdThucAn;
            int soLuong = (int)numericUpDown1.Value;

            if (idHoaDon == -1)
            {
                if (soLuong > 0)
                {
                    //tạo hóa đơn nên hóa đơn cuối là cái mới nhất
                    BillDAL.addBillForTable(this.banAn.IdBanAn, tkDangNhap.UserName);
                    BillInfoDAL.addFoodToTable(BillDAL.getLastIdBill(), idThucAn, soLuong);
                }
                //xóa
                else
                    HoaDonTheoBanDAL.deleteFoodInBill(BillDAL.getIdBillUncheckByIdTable(banAn.IdBanAn), (cbMonAn.SelectedItem as Food).TenThucAn, -soLuong);
                
            }
            else BillInfoDAL.addFoodToTable(idHoaDon, idThucAn, soLuong);

            //thêm món xong mới bắt sự kiện
            eventThemMonAn(this, new EventArgs());
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMenu = 0;
            if ((sender as ComboBox).SelectedItem == null) return;
            idMenu = ((sender as ComboBox).SelectedItem as Category).IdMenu;

            loadCbFoodByIdCategory(idMenu);
        }
    
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGiaTien.Text = ((cbMonAn.SelectedItem as Food).GiaTien.ToString());
            numericUpDown1_ValueChanged(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 0)
            {
                txtGiaTien.Text = "0";
                return;
            }
            txtGiaTien.Text = (((cbMonAn.SelectedItem as Food).GiaTien) * (int)numericUpDown1.Value).ToString();
        }

        #endregion

        #region - Methods -
        /// <summary>
        /// khởi tạo cb thức ăn theo cb danh mục
        /// </summary>
        /// <param name="idMenu"></param>
        private void loadCbFoodByIdCategory(int idMenu)
        {
            cbMonAn.DataSource = FoodDAL.getListFoodByIdCategory(idMenu); ;
            cbMonAn.DisplayMember = "TenThucAn";
        }

        public void loadCbCategory()
        {
            cbDanhMuc.DataSource = CategoryDAL.getListCategory();
            cbDanhMuc.DisplayMember = "TenMenu";
        }
        #endregion
    }
}
