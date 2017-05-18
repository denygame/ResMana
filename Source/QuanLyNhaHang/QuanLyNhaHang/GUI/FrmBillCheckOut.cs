using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    public partial class FrmBillCheckOut : Form
    {
        private Account acc;
        private string nameTable;
        private int idTable;
        private List<ChiTietHoaDonTheoBan> list;

        private event EventHandler truyen;
        public event EventHandler Truyen
        {
            add { truyen += value; }
            remove { truyen -= value; }
        }

        public FrmBillCheckOut(string nameTable, Account acc, int idTable)
        {
            InitializeComponent();
            this.nameTable = nameTable;
            this.acc = acc;
            this.idTable = idTable;
        }
        private void loadBill()
        {
            List<ChiTietHoaDonTheoBan> listNew = HoaDonTheoBanDAL.getBillByIdTable(idTable);
            dataHD.DataSource = listNew;
            dataHD.Columns[0].HeaderText = "Tên Thức Ăn";
            dataHD.Columns[0].Width = 150;
            dataHD.Columns[1].HeaderText = "Số Lượng";
            dataHD.Columns[1].Width = 79;
            dataHD.Columns[2].HeaderText = "Thành Tiền";
            dataHD.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataHD.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataHD.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void loadTXT()
        {
            List<ChiTietHoaDonTheoBan> listNew = HoaDonTheoBanDAL.getBillByIdTable(idTable);
            float tongTien = 0;
            for (int i = 0; i < listNew.Count; i++)
                tongTien += listNew[i].ThanhTien;

            //thay đổi giá trị tiền về việt nam đồng
            CultureInfo culture = new CultureInfo("vi-vN");
            txtTongTien.Text = tongTien.ToString("c", culture);
        }

        private void FrmBillCheckOut_Load(object sender, EventArgs e)
        {
            list = HoaDonTheoBanDAL.getBillByIdTable(idTable);
            string nameStaff = StaffDAL.getStaff(AccountDAL.getAccount(acc.UserName).IdNhanVien).TenNhanVien;
            lblName.Text = nameTable;
            lblNhanVien.Text = "Nhân Viên: " + nameStaff;

            loadBill();
            loadTXT();
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nUdGiamGia_ValueChanged(object sender, EventArgs e)
        {
            if (nUdGiamGia.Value != 0)
            {
                int discount = (int)nUdGiamGia.Value;
                float tongTien = 0;
                for (int i = 0; i < list.Count; i++)
                    tongTien += list[i].ThanhTien;

                double finalPrice = tongTien - (tongTien * discount / 100);

                CultureInfo culture = new CultureInfo("vi-vN");
                txtTongTien.Text = finalPrice.ToString("c", culture);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //đổi chuỗi
            string[] test = txtTongTien.Text.ToString().Split(new char[] { ',', '.' });
            string tP = "";
            for (int i = 0; i < test.Length - 1; i++) tP += test[i];

            double finalPrice = Convert.ToDouble(tP);

            int discount = (int)nUdGiamGia.Value;
            int idBill = BillDAL.getIdBillUncheckByIdTable(idTable);
            if (idBill != -1)
            {
                BillDAL.CheckOut(idBill, discount, (float)finalPrice);
                loadBill();
                loadTXT();
                truyen(this, new EventArgs());
            }
        }
    }
}
