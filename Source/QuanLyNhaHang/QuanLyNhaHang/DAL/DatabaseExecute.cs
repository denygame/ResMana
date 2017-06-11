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
        public static DataTable sqlQuery(string query, object[] bienSoTruyenVao = null)
        {
            DataTable data = new DataTable();
            conn.Open();
            SqlCommand comm = new SqlCommand(query, conn);
            if (bienSoTruyenVao != null)
            {
                string[] listBienSo = query.Split(' ');
                int i = 0;
                foreach (string text in listBienSo)
                {
                    if (text.Contains("@"))
                    {
                        comm.Parameters.AddWithValue(text, bienSoTruyenVao[i]);
                        i++;
                    }
                }
            }
            SqlDataAdapter adapter = new SqlDataAdapter(comm);
            adapter.Fill(data);
            conn.Close();
            return data;
        }

        //dùng cho insert update 
        public static int sqlExecuteNonQuery(string query, object[] bienSoTruyenVao = null)
        {
            int traVe = -1;
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            if (bienSoTruyenVao != null)
            {
                string[] listBienSo = query.Split(' ');
                int i = 0;
                foreach (string text in listBienSo)
                {
                    if (text.Contains("@"))
                    {
                        comm.Parameters.AddWithValue(text, bienSoTruyenVao[i]);
                        i++;
                    }
                }
            }
            traVe = comm.ExecuteNonQuery();
            conn.Close();
            return traVe;
        }
    //execute trả về object
        public static object sqlExecuteScalar(string query, object[] bienSoTruyenVao = null)
        {
            object traVe = -1;
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            if (bienSoTruyenVao != null)
            {
                string[] listBienSo = query.Split(' ');
                int i = 0;
                foreach (string text in listBienSo)
                {
                    if (text.Contains("@"))
                    {
                        comm.Parameters.AddWithValue(text, bienSoTruyenVao[i]);
                        i++;
                    }
                }
            }
            traVe = comm.ExecuteScalar();
            conn.Close();
            return traVe;
        }

        public static int runFileSql(string tenServer)
        {
            SqlConnection connection;
            SqlCommand com;
            string strConn = "Data Source = " + tenServer + "; Initial Catalog = master; Integrated Security = True";
            DropDatabase(tenServer);
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

        public static int DropDatabase(string tenServer)
        {
            SqlConnection connection;
            SqlCommand com;
            try
            {
                connection = new SqlConnection("Data Source = " + tenServer + "; Initial Catalog = master; Integrated Security = True");
                string query = "use master drop database " + Constant.databaseName;
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




        private static string stringPrint = "";


        public static string returnPrint(string query, object[] bienSoTruyenVao = null)
        {
            int traVe = -1;
            SqlCommand comm = new SqlCommand(query, conn);
            conn.Open();
            if (bienSoTruyenVao != null)
            {
                string[] listBienSo = query.Split(' ');
                int i = 0;
                foreach (string text in listBienSo)
                {
                    if (text.Contains("@"))
                    {
                        comm.Parameters.AddWithValue(text, bienSoTruyenVao[i]);
                        i++;
                    }
                }
            }
            conn.InfoMessage += Conn_InfoMessage;
            traVe = comm.ExecuteNonQuery();
            conn.Close();
            return stringPrint;
        }

        private static void Conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            stringPrint = e.Message;
        }
    }
}
