using DemoProblem.DAL;
using DemoProblem.DTO;
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

namespace DemoProblem.GUI
{
    public partial class FrmSystem : Form
    {
        public FrmSystem()
        {
            InitializeComponent();
        }

        private int check = -1;

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
            int testTrans = -1;
            int cbproblem = -1;
            if (check == 0)
            {
                if (rB_Wait.Checked == true) testTrans = 0;
                if (rB_Poke.Checked == true) testTrans = 1;
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
                    f = new FrmStaffProfile(test,cbproblem);
                else f = new FrmStaffProfile(nv,testTrans);

                f.Thaydoi += F_Thaydoi;
                f.ShowDialog();
            }
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


        #region - Event thêm xóa sửa -
       


        private void btnXemNhanVien_Click(object sender, EventArgs e)
        {
            if(check == -1)
            {
                loadDataStaff();
                return;
            }

            if (cbProblem.SelectedIndex == 0)
            {
                dataGridView_NhanVien.DataSource = StaffDAL.phanTrangDulieuRac(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
            }

            // k dùng dc stored procedure, k thể chạy song song ? test
            if(cbProblem.SelectedIndex == 1)
            {
                dataGridView_NhanVien.DataSource = StaffDAL.GetStaffListANDpage(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
                Thread.Sleep(3000);
                dataGridView_NhanVien.DataSource = StaffDAL.GetStaffListANDpage(Convert.ToInt32(txtTrangNhanVien.Text), Constant.phanTrangNV);
            }


        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView_NhanVien.CurrentCell.RowIndex;
            //int columnindex = dataGridView_NhanVien.CurrentCell.ColumnIndex;
            string result = dataGridView_NhanVien.Rows[rowindex].Cells[0].Value.ToString();
            if (result != null)
            {
               if (StaffDAL.deleteStaff(Convert.ToInt32(result)))
               {
                     loadDataStaff();
               }
            }
        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            loadFrmStaff("testNotNull");
        }


       

        private void dataGridView_NhanVien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            loadFrmStaff();
        }

        private void F_Thaydoi(object sender, EventTruyenDuLieu e)
        {
            loadDataStaff();
        }

        #endregion

        private void FrmSystem_Load(object sender, EventArgs e)
        {
            Initialize();
        }



        #endregion

        private void btnDemo_Click(object sender, EventArgs e)
        {
            if (check == -1)
            {
                cbProblem.Enabled = true;
                check = 0;
                return;
            }
            if(check == 0)
            {
                check = -1;
                cbProblem.Enabled = false;
                rB_Poke.Enabled = false;
                rB_Wait.Enabled = false;
                rB_Wait.Checked = false;
                rB_Poke.Checked = false;
                return;
            }
        }

        private void cbProblem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbProblem.SelectedIndex == 2)
            {
                rB_Poke.Enabled = true;
                rB_Wait.Enabled = true;
                rB_Wait.Checked = true;
            }
            else
            {
                rB_Poke.Enabled = false;
                rB_Wait.Enabled = false;
                rB_Wait.Checked = false;
                rB_Poke.Checked = false;
            }
        }
    }
}