using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class FoodDAL
    {
        public static DataTable getListFood()
        {
            return DatabaseExecute.sqlQuery("SP_getListFood");
        }

        public static Food getFoodById(int idThucAn)
        {
            Food traVe = new Food();
            DataTable data = DatabaseExecute.sqlQuery("SP_getFoodById @idThucAn", new object[] { idThucAn });
            foreach (DataRow r in data.Rows)
                traVe = new Food(r);
            return traVe;
        }

        /// <summary>
        /// lấy danh sách thức ăn theo id danh mục
        /// </summary>
        /// <param name="idMenu"></param>
        /// <returns></returns>
        public static List<Food> getListFoodByIdCategory(int idMenu)
        {
            List<Food> list = new List<Food>();
            DataTable data = DatabaseExecute.sqlQuery("SP_getListFoodByIdCategory @idCategory", new object[] { idMenu });
            foreach (DataRow i in data.Rows)
            {
                Food test = new Food(i);
                list.Add(test);
            }
            return list;
        }

        public static bool insertFood(string tenThucAn, int idMenu, float giaTien)
        {
            if (tenThucAn.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_insertFood @tenThucAn , @idMenu , @giaTien", new object[] { tenThucAn, idMenu, giaTien });
            return result > 0;
        }

        public static bool deleteFood(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_deleteFood @idThucAn", new object[] { id });
            return result > 0;
        }

        public static bool updateFood(int idThucAn, string ten, float gia, int idMenu)
        {
            if (ten.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery("SP_updateFood @id , @ten , @idMenu , @gia", new object[] { idThucAn, ten, idMenu, gia });
            return result > 0;
        }

        public static int countFood()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_countFood");
        }

        public static List<Food> searchFood(string source)
        {
            string name = source;
            int id = 0;
            if (Test.HasNumber(source) && Test.IsNumber(source))
            {
                id = Convert.ToInt32(source);
                name = "";
            }
            List<Food> list = new List<Food>();
            DataTable data = DatabaseExecute.sqlQuery("seachCateOrSanhOrThucAn @id , @name , @cateOrSanhOrFood ", new object[] { id, name, 2 });
            foreach (DataRow i in data.Rows)
            {
                Food temp = new Food(i);
                list.Add(temp);
            }
            return list;
        }

    }
}
