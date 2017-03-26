using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Category
    {
        private int idMenu;
        private string tenMenu;
        public Category(DataRow r)
        {
            this.IdMenu = (int)r["idMenu"];
            this.TenMenu = r["tenMenu"].ToString();
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

        public string TenMenu
        {
            get
            {
                return tenMenu;
            }

            set
            {
                tenMenu = value;
            }
        }
    }
}
