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
        public static List<DanhMuc> getListCategory()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string query = "select * from DanhMuc";
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach (DataRow i in data.Rows)
            {
                DanhMuc d = new DanhMuc(i);
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

        //xóa danh mục phải xóa hết thức ăn trong danh mục đó
        public static bool deleteCategory(int id)
        {
            FoodDAL.deleteFoodInCategory(id);
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("DELETE FROM dbo.DanhMuc WHERE idMenu = {0}", id));
            return result > 0;
        }

        public static bool updateCategory(int id, string name)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.DanhMuc SET tenMenu = N'{0}' WHERE idMenu = {1}", name, id));
            return result > 0;
        }
    }
}
