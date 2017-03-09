using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class BanAnDAL
    {
        public static List<BanAn> layDsBanAn(int idSanh)
        {
            List<BanAn> list = new List<BanAn>();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idSanh = "+ idSanh);
            foreach(DataRow i in data.Rows)
            {
                BanAn test = new BanAn(i);
                list.Add(test);
            }
            return list;
        }
    }
}
