using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class IPConnectionDAL
    {
        public static void insertIP(string ip)
        {
            DatabaseExecute.sqlQuery("StoredProcedure_InsertIP @ip", new object[] { ip });       
        }

        public static int countIPconnect()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.IPConnectionDatabase");
        }

        public static void deleteIP(string ip)
        {
            DatabaseExecute.sqlQuery("StoredProcedure_DeleteIP @ip",new object[] { ip });
        }
    }
}
