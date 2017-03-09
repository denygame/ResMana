using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class DatabaseExecute
    {
        public static SqlConnection conn = new SqlConnection(QuanLyNhaHang.Properties.Settings.Default.strConnection);
        //public static SqlConnection conn = new SqlConnection("Data Source = THANH-HUY; Initial Catalog = QLNH; Integrated Security = True");
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

        //dùng cho insert update 
        public static int sqlExecuteNonQuery(string query)
        {
            int traVe = -1;
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();
            return traVe;
        }


        public static int thucThiSql()
        {
            SqlConnection connection;
            SqlCommand com;
            string strConn = "Data Source = " + Environment.MachineName + "; Initial Catalog = master; Integrated Security = True";
            DropDatabase();
            string file = File.ReadAllText(@"sql\" + Constant.fileSqlName);
            string[] mangCatGO = file.Split(new string[] { "GO" }, StringSplitOptions.None);
            try
            {
                using (connection = new SqlConnection(strConn))
                {
                    connection.Open();
                    foreach (string i in mangCatGO)
                        using (com = connection.CreateCommand())
                        {
                            com.CommandText = i;
                            com.ExecuteNonQuery();
                        }
                }
                return 1;
            }
            catch { return 0; }

        }

        public static int DropDatabase()
        {
            SqlConnection connection;
            SqlCommand com;
            try
            {
                connection = new SqlConnection("Data Source = " + Environment.MachineName + "; Initial Catalog = master; Integrated Security = True");
                string query = "drop database "+ Constant.databaseName;
                com = new SqlCommand(query, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
