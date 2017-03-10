using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class ThucAn
    {
        private int idThucAn, idMenu;
        private string tenThucAn;
        private float giaTien;
        public ThucAn(DataRow r)
        {
            this.IdMenu = (int)r["idMenu"];
            this.IdThucAn = (int)r["idThucAn"];
            this.TenThucAn = r["tenThucAn"].ToString();
            this.GiaTien = (float)Convert.ToDouble(r["giaTien"].ToString());
        }
        public float GiaTien
        {
            get
            {
                return giaTien;
            }

            set
            {
                giaTien = value;
            }
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

        public int IdThucAn
        {
            get
            {
                return idThucAn;
            }

            set
            {
                idThucAn = value;
            }
        }

        public int IdMenu
        {
            get
            {
                return idMenu;
            }

            set
            {
                idMenu = value;
            }
        }
    }
}
