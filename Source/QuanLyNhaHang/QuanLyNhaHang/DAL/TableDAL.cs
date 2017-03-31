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
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idSanh = " + idSanh + " AND checkDelete = 0");
            foreach (DataRow i in data.Rows)
            {
                Table test = new Table(i);
                list.Add(test);
            }
            return list;
        }

        public static DataTable getListTable()
        {
            DataTable data = DatabaseExecute.sqlQuery("SELECT idBanAn, tenSanh, tenBan, trangThai  FROM dbo.BanAn, dbo.Sanh WHERE BanAn.idSanh = Sanh.idSanh AND BanAn.checkDelete = 0");
            return data;
        }

        public static Table getTable(int idBanAn)
        {
            Table test = new Table();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idBanAn = " + idBanAn);
            foreach (DataRow i in data.Rows)
            {
                test = new Table(i);
            }
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
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_GopBan @idBan1 , @idBan2 , @idBanGop ", new object[] { idBan1, idBan2, idBanGop});
            }
            catch { }
        }



        public static bool insertTable()
        {
            /*if (tenThucAn.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT dbo.ThucAn ( tenThucAn, idMenu, giaTien ) VALUES  ( N'{0}', {1} ,  {2} )", tenThucAn, idMenu, giaTien));
            return result > 0;*/
            return true;
        }

        public static bool deleteTable(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("UPDATE dbo.ThucAn SET checkDelete = 1 WHERE idThucAn = " + id);
            return result > 0;
        }

        public static bool updateTable()
        {
            /*int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.ThucAn SET tenThucAn = N'{0}', idMenu = {1}, giaTien = {2} WHERE idThucAn = {3}", ten, idMenu, gia, idThucAn));
            return result > 0;*/
            return true;
        }

        public static int countTable()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.BanAn");
        }

    }
}
