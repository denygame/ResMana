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
    public partial class FrmQuesGopBan : Form
    {
        public FrmQuesGopBan(List<BanAn> listBanGop)
        {
            InitializeComponent();
            cbBan.DataSource = listBanGop;
            cbBan.DisplayMember = "TenBan";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private event EventHandler<EventTruyenDuLieu> eventGopBan;
        public event EventHandler<EventTruyenDuLieu> EventGopBan
        {
            add { eventGopBan += value; }
            remove { eventGopBan -= value; }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            eventGopBan(this, new EventTruyenDuLieu(cbBan.SelectedItem as BanAn));
            this.Close();
        }
    }
}
