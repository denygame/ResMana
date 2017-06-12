using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.DAL
{
    public class AccountDAL
    {
        //test
        public static int login(string userName, string passWord)
        {
            int result = -1;
            try
            {
                result = (int)DatabaseExecute.sqlExecuteScalar("SP_checkLogin @userName , @passWord", new object[] { userName, passWord });
            }
            catch { return -1; }

            if (result == 0) return 0; else return 1;
        }

        //chỉ 1 ip đăng nhập 1 tài khoản
        public static bool replaceCheckLogin(string userName, int check)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_replaceCheckLogin @userName , @checkLogin", new object[] { userName, check });

            return result > 0;
        }

        public static Account getAccount(string userName)
        {
            DataTable data = new DataTable();
            data = DatabaseExecute.sqlQuery("SP_getAccount @userName", new object[] { userName });
            foreach (DataRow row in data.Rows)
                return new Account(row);
            return null;
        }

        public static bool getCheckLogin(string userName)
        {
            Account r = getAccount(userName);
            if (r != null)
            {
                if (r.CheckLogin == 1) return true;
                else return false;
            }
            return false;
        }

        public static DataTable getListAccount()
        {
            return DatabaseExecute.sqlQuery("SP_getListAccount");
        }

        public static bool deleteAccount(string userName)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_deleteAccount @userName", new object[] { userName });
            return result > 0;
        }

        public static bool updateAccount(string userName, int loaiTK)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateAccount @userName , @loaiTK", new object[] { userName, loaiTK });
            return result > 0;
        }

        public static bool insertAccount(string userName, int loaiTK, int idNhanVien)
        {
            string pass = EncryptPassword.md5(Constant.passDefault);
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertAccount @userName , @pass ,  @loaiTK , @idNhanVien", new object[] { userName, pass, loaiTK, idNhanVien });
            return result > 0;
        }

        public static int countAccByUsername(string username)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countAccByUserName @userName", new object[] { username });
        }


        public static int countAccByIdStaff(int idStaff)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countAccByIdStaff @idNhanVien", new object[] { idStaff });
        }


        public static bool deleteAccByIdStaff(int id)
        {
            DatabaseExecute.sqlExecuteNonQuery("SP_checkLogin0ByStaff @idNhanVien", new object[] { id });
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_deleteAccountByStaff @idNhanVien", new object[] { id });
            return result > 0;
        }

        public static bool ResetAccount(string userName)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_resetPass @userName , @pass", new object[] { userName, EncryptPassword.md5(Constant.passDefault) });

            return result > 0;
        }

        public static bool changePass(string userName, string oldPass, string newPass)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_doiMatKhau @userName , @passWord , @newPassword ", new object[] { userName, oldPass, newPass });

            return result > 0;
        }
    }
}
