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

        public EventTruyenDuLieu(TaiKhoan t)
        {
            this.Tk = t;
        }
    }
}
