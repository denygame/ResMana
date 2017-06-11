using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang
{
    public class EventTruyenDuLieu
    {
        private Account tk;

        public Account Tk
        {
            get
            {
                return tk;
            }

            set
            {
                tk = value;
            }
        }

        public Table BanAnGop
        {
            get
            {
                return banAnGop;
            }

            set
            {
                banAnGop = value;
            }
        }

        public bool CapTaiKhoan
        {
            get
            {
                return capTaiKhoan;
            }

            set
            {
                capTaiKhoan = value;
            }
        }


        public EventTruyenDuLieu(Account t)
        {
            this.Tk = t;
        }

        private Table banAnGop;

        public EventTruyenDuLieu(Table ba)
        {
            this.BanAnGop = ba;
        }

        private bool capTaiKhoan;   // true là cấp

        public EventTruyenDuLieu(bool capTaiKhoan)
        {
            this.CapTaiKhoan = capTaiKhoan;
        }

        
    }
}
