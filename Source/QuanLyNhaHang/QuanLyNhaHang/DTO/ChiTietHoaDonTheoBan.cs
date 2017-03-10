using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class ChiTietHoaDonTheoBan
    {
        private string tenThucAn;
        private int soLuong;
        private float thanhTien;

        
        public ChiTietHoaDonTheoBan(DataRow r)
        {
            this.TenThucAn = r["tenThucAn"].ToString();
            this.SoLuong = (int)r["soLuong"];
            this.thanhTien = (float)Convert.ToDouble(r["thanhTien"].ToString());
        }

        public string TenThucAn
        {
            get
            {
                return tenThucAn;
            }

            set
            {
                tenThucAn = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }

        public float ThanhTien
        {
            get
            {
                return thanhTien;
            }

            set
            {
                thanhTien = value;
            }
        }
    }
}
