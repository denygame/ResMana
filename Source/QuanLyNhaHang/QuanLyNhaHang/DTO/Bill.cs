using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Bill
    {
        private int idHoaDon, idBanAn;
        private int? discount;
        private float tongTien;
        private string userName;
        private DateTime? ngayDen;
        private string trangThai;

        public Bill(DataRow r)
        {
            this.IdHoaDon = (int)r["idHoaDon"];
            this.IdBanAn = (int)r["idBanAn"];
            this.TrangThai = r["trangThai"].ToString();
            this.TongTien = (float)Convert.ToDouble(r["tongTien"].ToString());
            this.Discount = (int)r["discount"];
            this.UserName = r["userName"].ToString();
            this.NgayDen = (DateTime?)r["ngayDen"];
        }
        public int IdHoaDon
        {
            get
            {
                return idHoaDon;
            }

            set
            {
                idHoaDon = value;
            }
        }

        public int IdBanAn
        {
            get
            {
                return idBanAn;
            }

            set
            {
                idBanAn = value;
            }
        }

        public string TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
        

        public int? Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }

        public float TongTien
        {
            get
            {
                return tongTien;
            }

            set
            {
                tongTien = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public DateTime? NgayDen
        {
            get
            {
                return ngayDen;
            }

            set
            {
                ngayDen = value;
            }
        }
    }
}
