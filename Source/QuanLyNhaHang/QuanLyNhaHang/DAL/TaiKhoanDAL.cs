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
            DatabaseExecute.conn.Open();
            SqlCommand com = new SqlCommand(query, DatabaseExecute.conn);
            com.Parameters.Add(new SqlParameter("@uN", userName));
            com.Parameters.Add(new SqlParameter("@pW", passWord));
            int x = (int)com.ExecuteScalar();
            DatabaseExecute.conn.Close();
            if (x == 1) return true;
            return false;

        }
    }
}
