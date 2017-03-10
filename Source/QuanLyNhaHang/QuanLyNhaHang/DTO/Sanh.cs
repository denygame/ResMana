using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Sanh
    {
        private int idSanh;
        private string tenSanh;
        public Sanh(DataRow rows)
        {
            this.IdSanh = (int) rows["idSanh"];
            this.TenSanh = rows["tenSanh"].ToString();
        }

        public int IdSanh
        {
            get
            {
                return idSanh;
            }

            set
            {
                idSanh = value;
            }
        }

        public string TenSanh
        {
            get
            {
                return tenSanh;
            }

            set
            {
                tenSanh = value;
            }
        }
    }
}
