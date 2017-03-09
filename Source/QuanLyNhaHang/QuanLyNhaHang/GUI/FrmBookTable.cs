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
    public partial class FrmBookTable : Form
    {
        public FrmBookTable()
        {
            InitializeComponent();
        }
        private int giay, testProcessBar;
        private int returnGiay()
        {
            return (int.Parse(cbPhut.SelectedItem.ToString()) * 60) + (int.Parse(cbGio.SelectedItem.ToString()) * 60 * 60);
        }
      // test processbar và timer
        private void timerGiuBan_Tick(object sender, EventArgs e)
        {
            giay--;
            lbTime.Text = giay + " Giây";
            txtName.Text = giay.ToString();
            if (giay<0)
            {
                timerGiuBan.Enabled = false;
                MessageBox.Show("Xong");
            }
            if (giay >= 0)
            {
                progressBar1.Value = testProcessBar - giay;
                txtSdt.Text = progressBar1.Maximum.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            timerGiuBan.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            testProcessBar = giay = returnGiay();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = testProcessBar;
            timerGiuBan.Enabled = true;
        }
    }
}
