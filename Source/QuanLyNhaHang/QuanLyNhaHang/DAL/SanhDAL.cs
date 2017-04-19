using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class SanhDAL
    {
        public static List<Sanh> getListSanh()
        {
            List<Sanh> list = new List<Sanh>();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM Sanh WHERE checkDelete = 0");
            foreach(DataRow i in data.Rows)
            {
                Sanh test = new Sanh(i);
                list.Add(test);
            }
            return list;
        }

        //chưa dùng
        public static Sanh getSanh(int idSanh)
        {
            Sanh test = new Sanh();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM Sanh WHERE idSanh = " + idSanh);
            foreach (DataRow i in data.Rows)
            {
                test = new Sanh(i);
            }
            return test;
        }

        public static bool insertSanh(string tenSanh)
        {
            if (tenSanh.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT dbo.Sanh ( tenSanh ) VALUES  ( N'{0}')", tenSanh));
            return result > 0;
        }

        public static bool deleteSanh(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_DeleteSanh @idSanh", new object[] { id });
            return result > 0;
        }

        public static bool updateSanh(int id, string name)
        {
            if (name.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.Sanh SET tenSanh = N'{0}' WHERE idSanh = {1}", name, id));
            return result > 0;
        }

        public static int countSanh()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.Sanh WHERE checkDelete = 0");
        }
    }
}
