using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class TableDAL
    {
        public static List<Table> getListTableByIdSanh(int idSanh)
        {
            List<Table> list = new List<Table>();
            DataTable data = DatabaseExecute.sqlQuery("SP_getListTableByIdSanh @idSanh", new object[] { idSanh });
            foreach (DataRow i in data.Rows)
            {
                Table test = new Table(i);
                list.Add(test);
            }
            return list;
        }

        public static DataTable getListTable()
        {
            return DatabaseExecute.sqlQuery("SP_getListTable");
        }

        public static Table getTable(int idBanAn)
        {
            Table test = new Table();
            DataTable data = DatabaseExecute.sqlQuery("SP_getTable @idTable", new object[] { idBanAn });
            foreach (DataRow i in data.Rows)
                test = new Table(i);
            return test;
        }

        /// <summary>
        /// chuyển bàn
        /// </summary>
        /// <param name="idBan1"></param>
        /// <param name="idBan2"></param>
        public static void switchTable(int idBan1, int idBan2)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_ChuyenBan @idBan1 , @idBan2 ", new object[] { idBan1, idBan2 });
            }
            catch { }
        }

        /// <summary>
        /// gộp bàn
        /// </summary>
        /// <param name="idBan1"></param>
        /// <param name="idBan2"></param>
        /// <param name="idBanGop"></param>
        public static void lumpTable(int idBan1, int idBan2, int idBanGop)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_GopBan @idBan1 , @idBan2 , @idBanGop ", new object[] { idBan1, idBan2, idBanGop });
            }
            catch { }
        }



        public static bool insertTable(string tenBan, int idSanh, string trangThai)
        {
            if (tenBan.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertTable @ten , @idSanh , @trangThai", new object[] { tenBan, idSanh, trangThai });
            return result > 0;
        }

        public static bool deleteTable(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_deleteTable @idTable", new object[] { id });
            return result > 0;
        }

        public static bool updateTable(int idBan, int idSanh, string tenBan)
        {
            if (tenBan.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateTable @idBan , @ten , @idSanh", new object[] { idBan, tenBan, idSanh });
            return result > 0;
        }

        public static int countTable()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countTable");
        }


        //public static bool updateEmptyTable(int idTable)
        //{
        //    int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.BanAn SET trangThai = N'Bàn Trống' WHERE idBanAn = {0}", idTable));
        //    return result > 0;
        //}

    }
}
