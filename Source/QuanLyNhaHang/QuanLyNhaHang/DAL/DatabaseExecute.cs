using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class DatabaseExecute
    {
        public static DataTable ExecuteQuery(string query)
        {
            string connectionSTR = "Data Source=THANH-HUY;Initial Catalog=QLNH;Integrated Security=True";
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                conn.Close();
            }
            return data;
        }
    }
}
