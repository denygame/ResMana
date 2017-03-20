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
        private TaiKhoan tk;

        public TaiKhoan Tk
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

        public BanAn BanAnGop
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

       /* public int TruyentestTrenMay
        {
            get
            {
                return truyentestTrenMay;
            }

            set
            {
                truyentestTrenMay = value;
            }
        }*/

        public EventTruyenDuLieu(TaiKhoan t)
        {
            this.Tk = t;
        }

        private BanAn banAnGop;

        public EventTruyenDuLieu(BanAn ba)
        {
            this.BanAnGop = ba;
        }


        /*private int truyentestTrenMay;
        public EventTruyenDuLieu(int i)
        {
            TruyentestTrenMay = i;
        }*/

        
    }
}
