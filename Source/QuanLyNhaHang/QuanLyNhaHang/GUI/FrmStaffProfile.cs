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
        Account acc;

        private bool checkClickTD;

        private event EventHandler<EventTruyenDuLieu> thaydoiFrmSystem;
        public event EventHandler<EventTruyenDuLieu> ThaydoiFrmSystem
        {
            add { thaydoiFrmSystem += value; }
            remove { thaydoiFrmSystem -= value; }
        }

        private event EventHandler<EventTruyenDuLieu> thaydoiFrmDemo;
        public event EventHandler<EventTruyenDuLieu> ThaydoiFrmDemo
        {
            add { thaydoiFrmDemo += value; }
            remove { thaydoiFrmDemo -= value; }
        }




        private string test = null;

        //3 biến demo 
        private int matDulieu = -1;
        private int unread = -1;
        private int problem = -1;

        private bool fixMatDuLieu;


        #region frm system
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
        #endregion




        #region frm demo problem
        public FrmStaffProfile(Staff nv, int testTrans, Account acc, bool fixOrNot, string docLai = null)
        {
            InitializeComponent();
            this.nv = nv;
            this.acc = acc;
            this.fixMatDuLieu = fixOrNot;
            if (docLai != null)
            {
                this.matDulieu = -1; //k doc lai
                this.unread = 0;
            }
            else this.matDulieu = testTrans;//mất dữ liệu
            load();
        }

        public FrmStaffProfile(string test, int problem, Account acc)
        {
            InitializeComponent();
            this.test = test;
            this.acc = acc;
            this.AcceptButton = btnCapAcc;
            this.problem = problem;
            load(test);
        }
        #endregion




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


        #region quickControls
        /// <summary>
        /// tắt readonly để có thể thay đổi dc
        /// </summary>
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

        /// <summary>
        /// mở readonly đồng thời trả về giới tính
        /// </summary>
        /// <returns></returns>
        private string openReadOnly()
        {
            string gT = "";
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

            return gT;
        }
        #endregion


        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if (checkClickTD == false)
            {
                btnCapAcc.Visible = false;
                btnThayDoi.BackColor = Color.PaleTurquoise;
                this.AcceptButton = btnThayDoi;
                checkClickTD = true;

                closeReadOnly();
            }
            else
            {
                this.AcceptButton = null;
                btnCapAcc.Visible = true;
                btnThayDoi.BackColor = Color.Silver;
                checkClickTD = false;

                string gT = openReadOnly();

                //frm system - k demo hoặc demo khong doc lai
                if (matDulieu == -1)
                {
                    if (StaffDAL.updateStaff(Convert.ToInt32(txtIdNhanVien.Text), txtTen.Text, dTp_NgaySinh.Value, gT, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text))
                    {
                        if (unread == 0) thaydoiFrmDemo(sender, new EventTruyenDuLieu(false));
                        else thaydoiFrmSystem(sender, new EventTruyenDuLieu(false));
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtTen.Focus();
                    }
                    return;
                }

                if (matDulieu != -1)
                {
                    #region demo lost updated khi testTrans != -1
                    //tức là frm demo 
                    if (matDulieu == 0)
                    {
                        StaffDAL.waitLostUpdate(Convert.ToInt32(txtIdNhanVien.Text), txtTen.Text, dTp_NgaySinh.Value, gT, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
                    }
                    if (matDulieu == 1)
                    {
                        StaffDAL.pokeLostUpdate(Convert.ToInt32(txtIdNhanVien.Text), txtTen.Text, dTp_NgaySinh.Value, gT, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
                    }

                    thaydoiFrmDemo(sender, new EventTruyenDuLieu(false));

                    #endregion
                }


            }
        }

        private void btnCapAcc_Click(object sender, EventArgs e)
        {
            if (test != null)
            {
                string gt = "";
                if (cbGT.SelectedIndex == 0) gt = "Nam"; else gt = "Nữ";

                // nếu k phải demo
                if (problem == -1)
                {
                    if (StaffDAL.insertStaff(txtTen.Text, dTp_NgaySinh.Value, gt, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text))
                    {
                        thaydoiFrmSystem(sender, new EventTruyenDuLieu(false));
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtTen.Focus();
                    }
                    return;
                }

                #region demo problem dirty với bóng ma
                if (problem == 0)
                {
                    //doc du lieu rac
                    StaffDAL.insertRollBack();
                }

                if (problem == 1)
                {
                    //bóng ma
                    StaffDAL.insertStaff(txtTen.Text, dTp_NgaySinh.Value, gt, txtChucVu.Text, txtQue.Text, txtDiaChi.Text, txtSDT.Text, txtEmail.Text);
                }
                thaydoiFrmDemo(sender, new EventTruyenDuLieu(false));
                this.Close();
                #endregion
            }
            else
            {
                FrmAddAccount f = new FrmAddAccount(nv);
                f.EvFromAddAccount += F_EvFromAddAccount;
                f.ShowDialog();
            }
        }

        private void F_EvFromAddAccount(object sender, EventArgs e)
        {
            thaydoiFrmSystem(this, new EventTruyenDuLieu(true));
        }



        //khi load không có trong bảng lock thì mới show button
        private void FrmStaffProfile_Load(object sender, EventArgs e)
        {
            if (nv != null && acc != null)
            {
                if (matDulieu != -1)//mat du lieu
                {
                    if (fixMatDuLieu)
                    {
                        int count = StaffDAL.getCountLockLU_withUser(nv.IdNhanVien, acc.UserName);
                        //MessageBox.Show(count.ToString());
                        if (count == 1)
                        {
                            btnThayDoi.Visible = true;
                        }
                        else
                        {
                            btnThayDoi.Visible = false;
                        }
                    }
                    else
                    {
                        btnThayDoi.Visible = true;
                    }
                }
            }
        }

        private void FrmStaffProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nv != null)
            {
                if (matDulieu != -1)//mat du lieu
                {
                    int count = StaffDAL.getCountLockLU(nv.IdNhanVien);
                    //MessageBox.Show(count.ToString());
                    if (count == 1)
                    {
                        StaffDAL.deleteLockLostUpdate(nv.IdNhanVien);
                    }
                }
            }
        }
    }
}