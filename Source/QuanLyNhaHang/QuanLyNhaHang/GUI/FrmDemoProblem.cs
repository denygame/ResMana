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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    public partial class FrmDemoProblem : Form
    {
        private event EventHandler truyen;
        public event EventHandler Truyen
        {
            add { truyen += value; }
            remove { truyen -= value; }
        }


        private Account tkDn;
        public FrmDemoProblem(Account acc)
        {
            InitializeComponent();

            this.tkDn = acc;
            this.Text += "  -+-  Tài Khoản: " + acc.UserName;
        }

        private int check = -1;
        private bool fixLoi = false;

        #region Methods

        #region - KHỞI TẠO -
        private void Initialize()
        {
            loadDataStaff();

            cbProblem.DataSource = Constant.listProblem;
        }



        private void loadDataStaff()
        {
            dataGridView_NhanVien.DataSource = StaffDAL.GetStaffListANDpage(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
        }



        #endregion




        private void loadFrmStaff(string test = null)
        {
            int matDulieu = -1;
            int cbproblem = -1;
            if (check == 0)
            {
                if (rB_Wait.Checked == true) matDulieu = 0;
                if (rB_Poke.Checked == true) matDulieu = 1;
                cbproblem = cbProblem.SelectedIndex;
            }

            int rowindex = dataGridView_NhanVien.CurrentCell.RowIndex;
            //int columnindex = dataGridView_NhanVien.CurrentCell.ColumnIndex;
            string result = dataGridView_NhanVien.Rows[rowindex].Cells[0].Value.ToString();

            if (result != null)
            {
                FrmStaffProfile f;
                Staff nv = StaffDAL.getStaff(Convert.ToInt32(result));
                if (test != null)
                    f = new FrmStaffProfile(test, cbproblem, tkDn); //insert bong ma, du lieu rac
                else
                {
                    if (cbproblem == 2)//mat du lieu
                    {
                        if (fixLoi) f = new FrmStaffProfile(nv, matDulieu, tkDn, true);
                        else f = new FrmStaffProfile(nv, matDulieu, tkDn, false);
                    }
                    else f = new FrmStaffProfile(nv, matDulieu, tkDn, false, "khong the doc lai"); //k doc lai
                }

                f.ThaydoiFrmDemo += F_ThaydoiFrmDemo;
                f.ShowDialog();
            }
        }

        private void F_ThaydoiFrmDemo(object sender, EventTruyenDuLieu e)
        {
            loadDataStaff();
        }


        #endregion

        #region Events




        #region - Phân Trang Nhân Viên -
        private void txtTrangNhanVien_TextChanged(object sender, EventArgs e)
        {
            dataGridView_NhanVien.DataSource = StaffDAL.GetStaffListANDpage(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
        }

        private void btnTrangTruocNhanVien_Click(object sender, EventArgs e)
        {
            int pageNow = Convert.ToInt32(txtTrangNhanVien.Text);
            if (pageNow > 1)
                pageNow--;
            txtTrangNhanVien.Text = pageNow.ToString();
        }

        private void btnTrangSauNhanVien_Click(object sender, EventArgs e)
        {
            int tongNhanVien;
            int pageNow = Convert.ToInt32(txtTrangNhanVien.Text);
            tongNhanVien = StaffDAL.GetTotalStaff();

            int lastPage = tongNhanVien / Constant.phanTrangNV;
            if (tongNhanVien % Constant.phanTrangNV != 0)
                lastPage++;
            if (pageNow < lastPage)
                pageNow++;
            txtTrangNhanVien.Text = pageNow.ToString();
        }

        #endregion


        #region - Event thêm xóa sửa (demo) -



        private void btnXemNhanVien_Click(object sender, EventArgs e)
        {
            if (check == -1)
            {
                loadDataStaff();
                return;
            }

            // du lieu rac
            if (cbProblem.SelectedIndex == 0)
            {
                if (!fixLoi)
                    dataGridView_NhanVien.DataSource = StaffDAL.phanTrangDulieuRac(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
                else
                    dataGridView_NhanVien.DataSource = StaffDAL.phanTrangDulieuRacFix(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
                return;
            }

            dataGridView_NhanVien.DataSource = StaffDAL.GetStaffListANDpage(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView_NhanVien.CurrentCell.RowIndex;
            //int columnindex = dataGridView_NhanVien.CurrentCell.ColumnIndex;
            string result = dataGridView_NhanVien.Rows[rowindex].Cells[0].Value.ToString();
            if (result != null)
            {
                if (result != tkDn.IdNhanVien.ToString())
                {
                    if (StaffDAL.deleteStaff(Convert.ToInt32(result)))
                    {
                        loadDataStaff();
                    }
                }
                else MessageBox.Show("Không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            loadFrmStaff("testNotNull");
        }




        private void dataGridView_NhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fixLoi)
            {
                int rowindex = dataGridView_NhanVien.CurrentCell.RowIndex;
                //int columnindex = dataGridView_NhanVien.CurrentCell.ColumnIndex;
                string result = dataGridView_NhanVien.Rows[rowindex].Cells[0].Value.ToString();
                if (result != null)
                {
                    if (StaffDAL.getCountLockLU(int.Parse(result)) != 1)
                        StaffDAL.insertLockLostUpdate(int.Parse(result), tkDn.UserName);
                }
            }
            loadFrmStaff();
        }


        #endregion

        private void FrmSystem_Load(object sender, EventArgs e)
        {
            panel47.Visible = false;
            panel48.Visible = false;
            btnHuy.Visible = false;
            btnTongNhanVien.Visible = false;
            btnKtheDocLai.Visible = false;
            Initialize();
        }

        private void cbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProblem.SelectedIndex == 2)
            {
                rB_Poke.Visible = true;
                rB_Wait.Visible = true;
                rB_Wait.Checked = true;
            }
            else
            {
                rB_Poke.Visible = false;
                rB_Wait.Visible = false;
                rB_Wait.Checked = false;
                rB_Poke.Checked = false;
            }

            if (cbProblem.SelectedIndex == 1) btnTongNhanVien.Visible = true;
            else btnTongNhanVien.Visible = false;

            if (cbProblem.SelectedIndex == 3) btnKtheDocLai.Visible = true;
            else btnKtheDocLai.Visible = false;
        }

        #endregion

        private void FrmDemoProblem_FormClosing(object sender, FormClosingEventArgs e)
        {
            truyen(this, new EventArgs());
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            fixLoi = true;
            btnHuy.Visible = true;
            btnFix.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            fixLoi = false;
            btnHuy.Visible = false;
            btnFix.Enabled = true;
        }

        private void dEMOToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (check == -1)
            {
                panel47.Visible = true;
                panel48.Visible = true;
                check = 0;
                return;
            }
            if (check == 0)
            {
                check = -1;
                panel47.Visible = false;
                panel48.Visible = false;
                rB_Wait.Checked = false;
                rB_Poke.Checked = false;
                return;
            }
        }


        //bóng ma, chú ý phải fix lỗi cả nút này lẫn thêm trong frmStaffProfile
        private void btnTongNhanVien_Click(object sender, EventArgs e)
        {
            if (!fixLoi)//demo
            {
                MessageBox.Show(StaffDAL.getTotalStaffPhantom(), "Kết Quả", MessageBoxButtons.OK);
            }
            else//fix loi
            {
                MessageBox.Show(StaffDAL.getTotalStaffPhantomAndFix(), "Kết Quả", MessageBoxButtons.OK);
            }
        }


        // không thể đọc lại 
        private void btnKtheDocLai_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView_NhanVien.CurrentCell.RowIndex;
            //int columnindex = dataGridView_NhanVien.CurrentCell.ColumnIndex;
            string result = dataGridView_NhanVien.Rows[rowindex].Cells[0].Value.ToString();

            if (!fixLoi)//demo
            {
                if (result != null)
                {
                    MessageBox.Show(StaffDAL.getNameKTheDoclai(int.Parse(result)), "Kết Quả", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (result != null)
                {
                    MessageBox.Show(StaffDAL.getNameKTheDoclaiFix(int.Parse(result)), "Kết Quả", MessageBoxButtons.OK);
                }
            }
        }
    }
}