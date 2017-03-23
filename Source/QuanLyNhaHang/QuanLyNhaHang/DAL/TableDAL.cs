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
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idSanh = " + idSanh);
            foreach (DataRow i in data.Rows)
            {
                Table test = new Table(i);
                list.Add(test);
            }
            return list;
        }
        public static DataTable getListTable()
        {
            DataTable data = DatabaseExecute.sqlQuery("SELECT idBanAn, tenSanh, tenBan, trangThai  FROM dbo.BanAn, dbo.Sanh WHERE BanAn.idSanh = Sanh.idSanh");
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
    }
}
