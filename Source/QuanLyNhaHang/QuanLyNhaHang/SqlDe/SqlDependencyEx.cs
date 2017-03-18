using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.SqlDe
{
    public class SqlDependencyEx
    {
        private string connection = QuanLyNhaHang.Properties.Settings.Default.strConnection;
        private string query;
        private Action hamChay;
        public SqlDependencyEx(Action ac, string query)
        {
            this.hamChay = ac;
            this.query = query;

            //listen thay đổi
            SqlDependency.Stop(connection);
            SqlDependency.Start(connection);
        }

        public void loadData()
        {
            using(SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                
                SqlDependency dependency = new SqlDependency(command);

                dependency.OnChange += Dependency_OnChange;

                command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                hamChay?.Invoke();
            }
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;
            de.OnChange -= Dependency_OnChange;
            loadData();
        }

        private void ketThuc()
        {
            SqlDependency.Stop(connection);
        }
    }
}
