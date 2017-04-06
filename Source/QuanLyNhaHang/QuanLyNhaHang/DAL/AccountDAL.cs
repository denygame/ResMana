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
    public class AccountDAL
    {
        //test
        public static bool login(string userName, string passWord)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_DangNhap @userName , @pass ", new object[] { userName, passWord });
                return true;
            }
            catch { return false; }
        }
        public static Account getAccount(string userName)
        {
            DataTable data = new DataTable();
            data = DatabaseExecute.sqlQuery("select * from TaiKhoan where userName = @uN", new object[] { userName });
            foreach (DataRow row in data.Rows)
                return new Account(row);
            return null;
        }

        public static DataTable getListAccount()
        {
            DataTable data = DatabaseExecute.sqlQuery("SELECT userName, idNhanVien, loaiTK from dbo.TaiKhoan WHERE checkDelete = 0");
            return data;
        }

        public static bool deleteAccount(string userName)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("UPDATE dbo.TaiKhoan SET checkDelete = 1 WHERE userName = N'" + userName + "'");
            return result > 0;
        }

        public static bool updateAccount(string userName, int loaiTK)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.TaiKhoan SET loaiTK = {0} WHERE userName = N'{1}'", loaiTK, userName));
            return result > 0;
        }
    }
}
