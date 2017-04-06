using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Staff
    {
        private int idNhanVien;
        private string tenNhanVien;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string chucVu;
        private string queQuan;
        private string email;
        private string diaChi;
        private int tel;
        
        public Staff(DataRow r)
        {
            this.IdNhanVien = (int)r["idNhanVien"];
            this.TenNhanVien = r["tenNhanVien"].ToString();
            this.NgaySinh = (DateTime)r["ngaySinh"];
            this.GioiTinh = r["gioiTinh"].ToString();
            this.ChucVu = r["chucVu"].ToString();
            this.QueQuan = r["queQuan"].ToString();
            this.Email = r["email"].ToString();
            this.DiaChi = r["diaChi"].ToString();
            this.Tel = (int)r["tel"];
        }


        public DateTime NgaySinh
        {
            get
            {
                return ngaySinh;
            }

            set
            {
                ngaySinh = value;
            }
        }

        public int IdNhanVien
        {
            get
            {
                return idNhanVien;
            }

            set
            {
                idNhanVien = value;
            }
        }

        public string TenNhanVien
        {
            get
            {
                return tenNhanVien;
            }

            set
            {
                tenNhanVien = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return gioiTinh;
            }

            set
            {
                gioiTinh = value;
            }
        }

        public string ChucVu
        {
            get
            {
                return chucVu;
            }

            set
            {
                chucVu = value;
            }
        }

        public string QueQuan
        {
            get
            {
                return queQuan;
            }

            set
            {
                queQuan = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return diaChi;
            }

            set
            {
                diaChi = value;
            }
        }

        public int Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }
    }
}
