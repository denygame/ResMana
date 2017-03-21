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
        public static DataTable layDSthucAn()
        {
            string query = "SELECT idThucAn, tenThucAn, tenMenu, giaTien FROM dbo.ThucAn, dbo.DanhMuc WHERE DanhMuc.idMenu = ThucAn.idMenu";
            return DatabaseExecute.sqlQuery(query);
        }

        public static ThucAn layThucAnTheoId(int idThucAn)
        {
            ThucAn traVe = new ThucAn();
            string query = "Select * from ThucAn where idThucAn = " + idThucAn;
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach(DataRow r in data.Rows)
            {
                traVe = new ThucAn(r);
            }
            return traVe;
        }

        


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
