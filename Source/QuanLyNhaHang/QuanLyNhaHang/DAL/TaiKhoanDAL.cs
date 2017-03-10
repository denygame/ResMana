using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class TaiKhoanDAL
    {
        //test
        public static bool dangNhap(string userName, string passWord)
        {
            string query = "select count(*) from TaiKhoan where userName = @uN  AND pass = @pW";
            int x = (int)DatabaseExecute.sqlExecuteScalar(query, new object[] { userName, passWord });
            if (x == 1) return true;
            return false;
        }
        public static TaiKhoan layTaiKhoan(string userName) 
        {
            DataTable data = new DataTable();
            data = DatabaseExecute.sqlQuery("select * from TaiKhoan where userName = @uN", new object[] { userName });
            foreach (DataRow row in data.Rows)
                return new TaiKhoan(row);
            return null;
        }
    }
}
