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
       // public static SqlConnection conn = new SqlConnection(QuanLyNhaHang.Properties.Settings.Default.strConnection);
        public static SqlConnection conn = new SqlConnection("Data Source = THANH-HUY; Initial Catalog = QLNH; Integrated Security = True");
        public static DataTable sqlQuery(string query)
        {
            DataTable data = new DataTable();

            conn.Open();

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);

            conn.Close();

            return data;
        }
    }
}
