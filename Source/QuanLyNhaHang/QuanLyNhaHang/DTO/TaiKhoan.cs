using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class TaiKhoan
    {
        private string userName, pass;
        private int idNhanVien, loaiTK;
        public TaiKhoan(DataRow r)
        {
            this.UserName = r["userName"].ToString();
            this.Pass = r["pass"].ToString();
            this.IdNhanVien = (int)r["idNhanVien"];
            this.LoaiTK = (int)r["loaiTK"];
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
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

        public int LoaiTK
        {
            get
            {
                return loaiTK;
            }

            set
            {
                loaiTK = value;
            }
        }
    }
}
