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
    public partial class FrmAddFood : Form
    {
        public FrmAddFood(string Name)
        {
            InitializeComponent();
            cbDanhMuc.Select();    //focus test
            loadData();

            txtName.Text = Name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }


        private void cbThucAnTheoCbMenu(int idMenu)
        {
            cbMonAn.DataSource = ThucAnDAL.layDSthucAnTheoIdMenu(idMenu); ;
            cbMonAn.DisplayMember = "TenThucAn";
        }

        private void loadData()
        {
            cbDanhMuc.DataSource = DanhMucDAL.layDSdanhMuc();
            cbDanhMuc.DisplayMember = "TenMenu";
        }

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMenu = 0;
            if ((sender as ComboBox).SelectedItem == null) return;
            idMenu = ((sender as ComboBox).SelectedItem as DanhMuc).IdMenu;

            cbThucAnTheoCbMenu(idMenu);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbMonAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtGiaTien.Text = ((cbMonAn.SelectedItem as ThucAn).GiaTien.ToString());
            numericUpDown1_ValueChanged(sender, e);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown1.Value < 0)
            {
                txtGiaTien.Text = "0";
                return;
            }
            txtGiaTien.Text = (((cbMonAn.SelectedItem as ThucAn).GiaTien) * (int)numericUpDown1.Value).ToString();
        }
    }
}
