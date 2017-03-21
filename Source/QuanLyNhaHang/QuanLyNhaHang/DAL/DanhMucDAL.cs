using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class DanhMucDAL
    {
        
        public static List<DanhMuc> layDSdanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string query = "select * from DanhMuc";
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach(DataRow i in data.Rows)
            {
                DanhMuc d = new DanhMuc(i);
                list.Add(d);
            }
            return list;
        }
    }
}
