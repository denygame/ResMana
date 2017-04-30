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
            string query = "SELECT idThucAn, tenThucAn, tenMenu, giaTien FROM dbo.ThucAn, dbo.DanhMuc WHERE DanhMuc.idMenu = ThucAn.idMenu AND ThucAn.checkDelete = 0";
            return DatabaseExecute.sqlQuery(query);
        }

        public static Food getFoodById(int idThucAn)
        {
            Food traVe = new Food();
            string query = "Select * from ThucAn where idThucAn = " + idThucAn;
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach (DataRow r in data.Rows)
            {
                traVe = new Food(r);
            }
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
            DataTable data = DatabaseExecute.sqlQuery(string.Format("select * from dbo.ThucAn where idMenu = {0} and checkDelete = 0",idMenu ));
            foreach(DataRow i in data.Rows)
            {
                Food test = new Food(i);
                list.Add(test);
            }
            return list;
        }


        public static bool insertFood(string tenThucAn, int idMenu, float giaTien)
        {
            if (tenThucAn.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT dbo.ThucAn ( tenThucAn, idMenu, giaTien ) VALUES  ( N'{0}', {1} ,  {2} )", tenThucAn, idMenu, giaTien));
            return result > 0;
        }

        public static bool deleteFood(int id)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery("UPDATE dbo.ThucAn SET checkDelete = 1 WHERE idThucAn = " + id);
            return result > 0;
        }

        public static bool updateFood(int idThucAn, string ten, float gia, int idMenu)
        {
            if (ten.Length > 100) return false;
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.ThucAn SET tenThucAn = N'{0}', idMenu = {1}, giaTien = {2} WHERE idThucAn = {3}", ten, idMenu, gia, idThucAn));
            return result > 0;
        }

        public static int countFood()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SELECT COUNT(*) FROM dbo.ThucAn WHERE checkDelete = 0");
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
