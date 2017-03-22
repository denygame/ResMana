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
            string query = "SELECT idThucAn, tenThucAn, tenMenu, giaTien FROM dbo.ThucAn, dbo.DanhMuc WHERE DanhMuc.idMenu = ThucAn.idMenu";
            return DatabaseExecute.sqlQuery(query);
        }

        public static Food getFoodById(int idThucAn)
        {
            Food traVe = new Food();
            string query = "Select * from ThucAn where idThucAn = " + idThucAn;
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach(DataRow r in data.Rows)
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
            DataTable data = DatabaseExecute.sqlQuery("select * from ThucAn where idMenu = " + idMenu);
            foreach(DataRow i in data.Rows)
            {
                Food test = new Food(i);
                list.Add(test);
            }
            return list;
        }
    }
}
