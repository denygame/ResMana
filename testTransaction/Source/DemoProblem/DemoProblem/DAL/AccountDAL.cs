using DemoProblem.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProblem.DAL
{
    public class AccountDAL
    {
        //test
        public static int login(string userName, string passWord)
        {
            try
            {
                return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.TaiKhoan WHERE userName = @userName AND pass = @passWOrd AND checkDelete = 0", new object[] { userName, passWord });
            }
            catch { return 0; }
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

        public static bool insertAccount(string userName, int loaiTK, int idNhanVien)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT TaiKhoan (userName, pass, idNhanVien, loaiTK) VALUES ('{0}', '{1}', {2}, {3} )", userName, "123", idNhanVien, loaiTK));
            return result > 0;
        }

        public static int countAccByUsername(string username)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.TaiKhoan WHERE userName = '" + username + "'");
        }


        public static int countAccByIdStaff(int idStaff)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.TaiKhoan WHERE idNhanVien = '" + idStaff + "'");
        }


        public static bool deleteAccByIdStaff(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("UPDATE dbo.TaiKhoan SET checkDelete = 1 WHERE idNhanVien = " + id);
            return result > 0;
        }

        

        public static bool changePass(string userName, string oldPass, string newPass)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_doiMatKhau @userName , @passWord , @newPassword ", new object[] { userName, oldPass, newPass });

            return result > 0;
        }
    }
}
