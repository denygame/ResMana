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
            DataTable data = DatabaseExecute.sqlQuery("SP_getListCategory");
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
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertCategory @tenMenu", new object[] { tenMenu });
            return result > 0;
        }

        public static bool deleteCategory(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_DeleteCategory @idCategory", new object[] { id });
            return result > 0;
        }

        public static bool updateCategory(int id, string name)
        {
            if (name.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateCategory @id , @ten", new object[] { id, name });
            return result > 0;
        }

        public static int countCategory()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countCategory");
        }


        public static List<Category> searchCate(string source)
        {
            string name = source;
            int id = 0;
            if (Test.HasNumber(source) && Test.IsNumber(source))
            {
                id = Convert.ToInt32(source);
                name = "";
            }
            List<Category> list = new List<Category>();
            DataTable data = DatabaseExecute.sqlQuery("seachCateOrSanhOrThucAn @id , @name , @cateOrSanhOrFood ", new object[] { id, name, 0 });
            foreach (DataRow i in data.Rows)
            {
                Category temp = new Category(i);
                list.Add(temp);
            }
            return list;
        }
    }
}
