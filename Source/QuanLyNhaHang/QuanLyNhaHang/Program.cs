using QuanLyNhaHang.DAL;
using QuanLyNhaHang.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhaHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                DatabaseExecute.conn.Open();
                DatabaseExecute.conn.Close();
                Application.Run(new FrmBegin());
            }
            catch (Exception)
            {
                QuanLyNhaHang.Properties.Settings.Default.Reset();
                Application.Run(new FrmSqlConnection());
            }
            finally
            {
                DatabaseExecute.conn.Close();
            }


            //debug
            //Application.Run(new FrmBegin());
        }
    }
}
