using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
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


        #region -- Methods --

        private void nUd_giamgia()
        {
            CultureInfo culture = new CultureInfo("vi-vN");
            if (nUdGiamGia.Value != 0)
            {
                int discount = (int)nUdGiamGia.Value;
                float tongTien = totalPrice();
                double finalPrice = tongTien - (tongTien * discount / 100);
                txtTongTien.Text = finalPrice.ToString("c", culture);
            }
            else
            {
                txtTongTien.Text = totalPrice().ToString("c", culture);
            }
        }

        private float totalPrice()
        {
            float tongTien = 0;
            for (int i = 0; i < list.Count; i++)
                tongTien += list[i].ThanhTien;
            return tongTien;
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

        private float returnMoney()
        {
            float khachTra = (float)Convert.ToDouble(txtKhachTra.Text);
            if (nUdGiamGia.Value == 0)
            {
                return khachTra - totalPrice();
            }
            else
            {
                return khachTra - (float)conLai();
            }
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

        private double conLai()
        {
            int discount = (int)nUdGiamGia.Value;
            return totalPrice() - (totalPrice() * discount / 100);
        }

        private string getDate()
        {
            string d, m;
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (day < 10) d = "0" + day.ToString(); else d = day.ToString();
            if (month < 10) m = "0" + month.ToString(); else m = month.ToString();

            return "Ngày: " + d + "/" + m + "/" + year;
        }

        private string getTime()
        {
            string h, m, s;
            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;
            int se = DateTime.Now.Second;
            if (hour < 10) h = "0" + hour.ToString(); else h = hour.ToString();
            if (min < 10) m = "0" + min.ToString(); else m = min.ToString();
            if (se < 10) s = "0" + se.ToString(); else s = se.ToString();
            return "Giờ: " + h + ":" + m + ":" + s;
        }

        public static string DoiSoSangDonViTienTe(float _object)
        {
            try
            {
                CultureInfo culture = new CultureInfo("vi-vN");
                string strThanhTien = _object.ToString("c", culture);

                return strThanhTien;
            }
            catch (Exception)
            {

            }
            return "0.000";
        }

        private string getNameStaff()
        {
            return StaffDAL.getStaff(AccountDAL.getAccount(acc.UserName).IdNhanVien).TenNhanVien;
        }

        #endregion


        #region -- Events --

        private void FrmBillCheckOut_Load(object sender, EventArgs e)
        {
            list = HoaDonTheoBanDAL.getBillByIdTable(idTable);

            lblName.Text = nameTable;
            lblNhanVien.Text = "Nhân Viên: " + getNameStaff(); ;

            loadBill();
            loadTXT();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nUdGiamGia_ValueChanged(object sender, EventArgs e)
        {
            nUd_giamgia();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            double finalPrice;
            if (nUdGiamGia.Value == 0)
                finalPrice = Convert.ToDouble(totalPrice());
            else finalPrice = conLai();


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


        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintDialog _PrintDialog = new PrintDialog();
                PrintDocument _PrintDocument = new PrintDocument();

                //_PrintDialog.Document = _PrintDocument; //add the document to the dialog box

                _PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(_CreateReceipt); //add an event handler that will do the printing
                                                                                                               //on a till you will not want to ask the user where to print but this is fine for the test envoironment.
                                                                                                               // DialogResult result = _PrintDialog.ShowDialog();

                //if (result == DialogResult.OK)
                {
                    _PrintDocument.Print();
                }
            }
            catch (Exception)
            {

            }
        }


        private void _CreateReceipt(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphic = e.Graphics;
            Font font = new Font("Courier New", 12);
            float FontHeight = font.GetHeight();
            int startX = 10;
            int startY = 10;
            int offset = 40;

            graphic.DrawString("Restaurant", new Font("Courier New", 18), new SolidBrush(Color.Black), startX + 150, startY);

            /*string top = "Tên Sản Phẩm".PadRight(24) + "Thành Tiền";
            graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);*/

            graphic.DrawString(nameTable, font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5;
            graphic.DrawString(getDate(), font, new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(getTime(), font, new SolidBrush(Color.Black), startX + 300, startY + offset);
            offset = offset + (int)FontHeight + 5;
            graphic.DrawString("Nhân viên thanh toán: " + getNameStaff(), font, new SolidBrush(Color.Black), startX, startY + offset);



            offset = offset + (int)FontHeight + 15; //make the spacing consistent
            graphic.DrawString("-----------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 5; //make the spacing consistent

            foreach (ChiTietHoaDonTheoBan item in list)
            {
                decimal d = Decimal.Parse(item.ThanhTien.ToString(), System.Globalization.NumberStyles.Float);
                graphic.DrawString(item.SoLuong + "x ", font, new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(item.TenThucAn, font, new SolidBrush(Color.Black), startX + 80, startY + offset);
                graphic.DrawString(DoiSoSangDonViTienTe((float)d), font, new SolidBrush(Color.Black), startX + 300, startY + offset);
                offset = offset + (int)FontHeight + 5; //xuống hàng              
            }
            graphic.DrawString("-----------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

            offset = offset + (int)FontHeight + 5;

            offset = offset + 15; //make some room so that the total stands out.

            graphic.DrawString("TỔNG CỘNG: ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
            graphic.DrawString(DoiSoSangDonViTienTe((float)totalPrice()), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 300, startY + offset);

            if (nUdGiamGia.Value != 0)
            {
                offset = offset + (int)FontHeight + 5;
                graphic.DrawString("GIẢM GIÁ: ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(nUdGiamGia.Value + "%", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 300, startY + offset);

                offset = offset + (int)FontHeight + 5;
                graphic.DrawString("CÒN LẠI: ", new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                graphic.DrawString(DoiSoSangDonViTienTe((float)conLai()), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX + 300, startY + offset);
            }


            if (txtKhachTra.Text != "")
            {
                if ((float)Convert.ToDouble(txtKhachTra.Text) >= totalPrice())
                {
                    offset = offset + (int)FontHeight + 15; //make the spacing consistent              
                    graphic.DrawString("TIỀN MẶT: ", font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(DoiSoSangDonViTienTe((float)Convert.ToDouble(txtKhachTra.Text)), font, new SolidBrush(Color.Black), startX + 300, startY + offset);

                    offset = offset + (int)FontHeight + 5; //make the spacing consistent              
                    graphic.DrawString("TRẢ LẠI: ", font, new SolidBrush(Color.Black), startX, startY + offset);
                    graphic.DrawString(DoiSoSangDonViTienTe(returnMoney()), font, new SolidBrush(Color.Black), startX + 300, startY + offset);
                }
            }

            offset = offset + (int)FontHeight + 15; //make the spacing consistent    
            graphic.DrawString("------------------  ~ <•> ~  ------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
            offset = offset + (int)FontHeight + 10;
            graphic.DrawString(" QUẢN LÝ NHÀ HÀNG - NHÓM 8 ", font, new SolidBrush(Color.Black), startX + 100, startY + offset);
        }


        private void txtKhachTra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

    }
}
