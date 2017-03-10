using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class ThucAnDAL
    {
        public static List<ThucAn> layDSthucAnTheoIdMenu(int idMenu)
        {
            List<ThucAn> list = new List<ThucAn>();
            DataTable data = DatabaseExecute.sqlQuery("select * from ThucAn where idMenu = " + idMenu);
            foreach(DataRow i in data.Rows)
            {
                ThucAn test = new ThucAn(i);
                list.Add(test);
            }
            return list;
        }
    }
}
