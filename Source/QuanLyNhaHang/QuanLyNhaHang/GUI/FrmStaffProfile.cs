using QuanLyNhaHang.DAL;
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
    public partial class FrmStaffProfile : Form
    {
        Staff nv;

        private bool checkClickTD;

        private event EventHandler thaydoi;
        public event EventHandler Thaydoi
        {
            add { thaydoi += value; }
            remove { thaydoi -= value; }
        }

        private string test = null;

        public FrmStaffProfile(Staff nv)
        {
            InitializeComponent();
            this.nv = nv;
            load();
        }

        public FrmStaffProfile(string test)
        {
            InitializeComponent();
            this.test = test;
            this.AcceptButton = btnCapAcc;
            load(test);
        }



        private void load(string test = null)
        {
            //format custom datetimepicker
            dTp_NgaySinh.Format = DateTimePickerFormat.Custom;
            dTp_NgaySinh.CustomFormat = "dd/MM/yyyy";

            
            if (test != null)
            {
                btnThayDoi.Visible = false;
                btnCapAcc.Text = "Thêm Nhân Viên";
                int idLastStaff = StaffDAL.getLastIdStaff();
                if (idLastStaff != -1)
                    txtIdNhanVien.Text = (idLastStaff + 1).ToString();
                closeReadOnly();
                return;
            }

            checkClickTD = false;
            txtIdNhanVien.Text = nv.IdNhanVien.ToString();
            txtTen.Text = nv.TenNhanVien;
            txtDiaChi.Text = nv.DiaChi;
            txtChucVu.Text = nv.ChucVu;
            txtEmail.Text = nv.Email;
            if (nv.GioiTinh == "Nam") cbGT.DataSource = Constant.listNam; else cbGT.DataSource = Constant.listNu;

            dTp_NgaySinh.Value = nv.NgaySinh;

            //chi select 1 ngay
            dTp_NgaySinh.MinDate = dTp_NgaySinh.Value;
            dTp_NgaySinh.MaxDate = dTp_NgaySinh.Value;

            //txtNgaySinh.Text = String.Format("{0:dd/MM/yyyy}", nv.NgaySinh);
            txtQue.Text = nv.QueQuan;
            txtSDT.Text = nv.Tel;
        }
        private void closeReadOnly()
        {
            txtTen.ReadOnly = false;
            txtSDT.ReadOnly = false;
            txtQue.ReadOnly = false;

            dTp_NgaySinh.MinDate = new DateTime(1753, 1, 1);
            dTp_NgaySinh.MaxDate = new DateTime(9998, 12, 31);

            cbGT.DataSource = Constant.listGioiTinh;
            txtEmail.ReadOnly = false;
            txtDiaChi.ReadOnly = false;
            txtChucVu.ReadOnly = false;
            txtIdNhanVien.Enabled = false;
        }
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if(checkClickTD == false)
            {
                btnCapAcc.Visible = false;
                btnThayDoi.BackColor = Color.PaleTurquoise;
                checkClickTD = true;
                closeReadOnly();
            }
            else
            {
                string gT = "";
                btnCapAcc.Visible = true;
                btnThayDoi.BackColor = Color.Silver;
                checkClickTD = false;
                dTp_NgaySinh.MinDate = dTp_NgaySinh.Value;
                dTp_NgaySinh.MaxDate = dTp_NgaySinh.Value;
                if (cbGT.SelectedIndex == 0)
                {
                    gT = Constant.listNam[0];
                    cbGT.DataSource = Constant.listNam;
                }
                else
                {
                    gT = Constant.listNu[0];
                    cbGT.DataSource = Constant.listNu;
                }
                txtTen.ReadOnly = true;
                txtSDT.ReadOnly = true;
                txtQue.ReadOnly = true;
                txtEmail.ReadOnly = true;
                txtDiaChi.ReadOnly = true;
                txtChucVu.ReadOnly = true;
                txtIdNhanVien.Enabled = true;

                StaffDAL.updateStaff(Convert.ToInt32(txtIdNhanVien.Text), txtTen.Text, dTp_NgaySinh.Value, gT, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);

                thaydoi(sender, e);
            }
        }

        private void btnCapAcc_Click(object sender, EventArgs e)
        {
            if (test != null)
            {
                string gt = "";
                if (cbGT.SelectedIndex == 0) gt = "Nam"; else gt = "Nữ";
                StaffDAL.insertStaff(txtTen.Text, dTp_NgaySinh.Value, gt, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);

                thaydoi(sender, e);
                this.Close();
            }
            else
            {
                FrmAddAccount f = new FrmAddAccount();
                f.ShowDialog();
            }
        }
    }
}
