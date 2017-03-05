using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class FrmManage : Form
    {
        public FrmManage()
        {
            InitializeComponent();
        }
    // test 2 form song song
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            FrmAddFood f = new FrmAddFood();
            if (Application.OpenForms["FrmAddFood"] == null)
            {
                f.Show();
            }
            else
            {
                Application.OpenForms["FrmAddFood"].Focus();
            }
        }

        private void checkBoxXoa_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxXoa.Checked == true)
                nUDslXoa.Enabled = false;
            else nUDslXoa.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmBookTable f = new FrmBookTable();
            f.ShowDialog();
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {

        }
    }
}
