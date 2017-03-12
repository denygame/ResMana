using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class BanAnDAL
    {
        public static List<BanAn> layDsBanAn(int idSanh)
        {
            List<BanAn> list = new List<BanAn>();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idSanh = " + idSanh);
            foreach (DataRow i in data.Rows)
            {
                BanAn test = new BanAn(i);
                list.Add(test);
            }
            return list;
        }

        public static BanAn layBanAn(int idBanAn)
        {
            BanAn test = new BanAn();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM BanAn WHERE idBanAn = " + idBanAn);
            foreach (DataRow i in data.Rows)
            {
                test = new BanAn(i);
            }
            return test;
        }

        public static void chuyenBan(int idBan1, int idBan2)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_ChuyenBan @idBan1 , @idBan2 ", new object[] { idBan1, idBan2 });
            }
            catch { }
        }

        public static void gopBan(int idBan1, int idBan2, int idBanGop)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_GopBan @idBan1 , @idBan2 , @idBanGop ", new object[] { idBan1, idBan2, idBanGop});
            }
            catch { }
        }
    }
}
