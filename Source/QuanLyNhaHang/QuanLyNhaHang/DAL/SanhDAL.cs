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
            DataTable data = DatabaseExecute.sqlQuery("SP_getListSanh");
            foreach (DataRow i in data.Rows)
            {
                Sanh test = new Sanh(i);
                list.Add(test);
            }
            return list;
        }

        public static Sanh getSanh(int idSanh)
        {
            Sanh test = new Sanh();
            DataTable data = DatabaseExecute.sqlQuery("SP_getSanh @id", new object[] { idSanh });
            foreach (DataRow i in data.Rows)
            {
                test = new Sanh(i);
            }
            return test;
        }

        public static bool insertSanh(string tenSanh)
        {
            if (tenSanh.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertSanh @ten", new object[] { tenSanh });
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
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateSanh @idSanh , @tenSanh", new object[] { id, name });
            return result > 0;
        }

        public static int countSanh()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countSanh");
        }


        public static List<Sanh> searchSanh(string source)
        {
            string name = source;
            int id = 0;
            if (Test.HasNumber(source) && Test.IsNumber(source))
            {
                id = Convert.ToInt32(source);
                name = "";
            }
            List<Sanh> list = new List<Sanh>();
            DataTable data = DatabaseExecute.sqlQuery("seachCateOrSanhOrThucAn @id , @name , @cateOrSanhOrFood ", new object[] { id, name, 1 });
            foreach (DataRow i in data.Rows)
            {
                Sanh temp = new Sanh(i);
                list.Add(temp);
            }
            return list;
        }
    }
}
