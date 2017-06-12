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
    public class StaffDAL
    {

        public static DataTable getDataTableStaff()
        {
            return DatabaseExecute.sqlQuery("SP_getListStaffFormat");
        }

        public static List<Staff> getListStaff()
        {
            List<Staff> list = new List<Staff>();
            DataTable data = DatabaseExecute.sqlQuery("SP_getListStaff");
            foreach (DataRow i in data.Rows)
            {
                Staff test = new Staff(i);
                list.Add(test);
            }
            return list;
        }

        public static Staff getStaff(int id)
        {
            DataTable data = DatabaseExecute.sqlQuery("SP_getStaff @idNhanVien", new object[] { id });
            foreach (DataRow i in data.Rows)
                return new Staff(i);
            return null;
        }

        public static bool insertStaff(string ten, DateTime ngSinh, string gT, string cV, string que, string dC, string tel, string email)
        {
            if (ten.Length > 100 || cV.Length > 100 || que.Length > 100 || dC.Length > 200 || email.Length > 200) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertStaff @ten , @ngaySinh , @gioiTinh , @chucVu , @queQuan , @diaChi , @tel , @mail", new object[] { ten, ngSinh, gT, cV, que, dC, tel, email });
            return result > 0;
        }

        //xoa 1 nhan vien fai xoa cac tk
        public static bool deleteStaff(int id)
        {
            if (AccountDAL.countAccByIdStaff(id) > 0)
                try { AccountDAL.deleteAccByIdStaff(id); } catch { return false; }

            int result = DatabaseExecute.sqlExecuteNonQuery("SP_deleteStaff @idNhanVien", new object[] { id });
            return result > 0;

        }

        public static bool updateStaff(int id, string ten, DateTime ngSinh, string gT, string cV, string que, string dC, string tel, string email)
        {
            if (ten.Length > 100 || cV.Length > 100 || que.Length > 100 || dC.Length > 200 || email.Length > 200) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateStaff @idNhanVien , @ten , @ngaySinh , @gioiTinh , @chucVu , @queQuan , @diaChi , @tel , @mail", new object[] { id, ten, ngSinh, gT, cV, que, dC, tel, email });
            return result > 0;
        }

        public static int getLastIdStaff()
        {
            try { return (int)DatabaseExecute.sqlExecuteScalar("SP_getMaxIdStaff"); }
            catch { return -1; }
        }

        public static DataTable GetStaffListANDpage(int page, int pageRows)
        {
            return DatabaseExecute.sqlQuery("StoredProcedure_PhanTrangNhanVien @page , @pageRows", new object[] { page, pageRows });
        }

        public static int GetTotalStaff()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("StoredProcedure_layTongSoNhanVien");
        }





        #region lost Update

        #region fix
        public static void insertLockLostUpdate(int idNhanVien, string userName)
        {
            DatabaseExecute.sqlQuery("SP_insertLockLU @idNhanVien , @userName", new object[] { idNhanVien, userName });
        }

        public static void deleteLockLostUpdate(int idNhanVien)
        {
            DatabaseExecute.sqlQuery("SP_deleteLockLU @idNhanVien", new object[] { idNhanVien });
        }

        public static int getCountLockLU(int idNhanVien)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countLockLU @idNhanVien", new object[] { idNhanVien });
        }

        public static int getCountLockLU_withUser(int idNhanVien, string userName)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countLockLU_withUser @idNhanVien , @userName", new object[] { idNhanVien, userName });
        }
        #endregion


        public static bool waitLostUpdate(int id, string cv)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_waitUpdate @chucVu , @id", new object[] { cv, id });
            return result > 0;
        }

        public static bool pokeLostUpdate(int id, string cv)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_pokeUpdate @chucVu , @id", new object[] { cv, id });
            return result > 0;
        }


        #endregion


        #region doc du lieu rac
        public static bool insertRollBack()
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_waitInsertRollback");
            return result > 0;
        }

        public static DataTable phanTrangDulieuRac(int page, int pageRows)
        {
            return DatabaseExecute.sqlQuery("SP_PhanTrangDEMOrac @page , @pageRows", new object[] { page, pageRows });
        }

        public static DataTable phanTrangDulieuRacFix(int page, int pageRows)
        {
            return DatabaseExecute.sqlQuery("StoredProcedure_PhanTrangNhanVien @page , @pageRows", new object[] { page, pageRows });
        }


        #endregion


        #region demo phantom
        public static string getTotalStaffPhantom()
        {
            return DatabaseExecute.returnPrint("SP_tongNV_phantom");
        }

        public static string getTotalStaffPhantomAndFix()
        {
            return DatabaseExecute.returnPrint("SP_tongNV_phantomFix");
        }
        #endregion


        #region khong the doc lai
        public static string getNameKTheDoclai(int idNhanVien)
        {
            return DatabaseExecute.returnPrint("SP_kTheDocLai @idNhanVien", new object[] { idNhanVien });
        }

        public static string getNameKTheDoclaiFix(int idNhanVien)
        {
            return DatabaseExecute.returnPrint("SP_kTheDocLaiFix @idNhanVien", new object[] { idNhanVien });
        }
        #endregion
    }
}
