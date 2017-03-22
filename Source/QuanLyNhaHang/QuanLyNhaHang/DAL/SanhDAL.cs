using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class SanhDAL
    {
        public static List<Sanh> getListSanh()
        {
            List<Sanh> list = new List<Sanh>();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM Sanh");
            foreach(DataRow i in data.Rows)
            {
                Sanh test = new Sanh(i);
                list.Add(test);
            }
            return list;
        }

        public static Sanh getSanh(int idSanh)
        {
            Sanh test = new Sanh();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM Sanh WHERE idSanh = " + idSanh);
            foreach (DataRow i in data.Rows)
            {
                test = new Sanh(i);
            }
            return test;
        }
    }
}
