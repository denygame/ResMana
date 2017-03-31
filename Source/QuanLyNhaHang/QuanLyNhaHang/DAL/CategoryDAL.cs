using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class CategoryDAL
    {
        public static List<Category> getListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT * FROM dbo.DanhMuc WHERE checkDelete = 0";
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach (DataRow i in data.Rows)
            {
                Category d = new Category(i);
                list.Add(d);
            }
            return list;
        }

        public static bool insertCategory(string tenMenu)
        {
            if (tenMenu.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT dbo.DanhMuc ( tenMenu ) VALUES  ( N'{0}')", tenMenu));
            return result > 0;
        }

        public static bool deleteCategory(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_DeleteCategory @idCategory",new object[] {id});
            return result > 0;
        }

        public static bool updateCategory(int id, string name)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.DanhMuc SET tenMenu = N'{0}' WHERE idMenu = {1}", name, id));
            return result > 0;
        }

        public static int countCategory()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM DanhMuc");
        }
    }
}
