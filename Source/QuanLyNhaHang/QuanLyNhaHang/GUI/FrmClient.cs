using QuanLyNhaHang.DAL;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.GUI
{
    public partial class FrmClient : Form
    {
        private bool testClickConnect = false;
        private int testTrenMay = -1;   // test trên máy 1, kết nối server -1
        public static string idSanh = "";

        #region - CLIENT -
        private static IPEndPoint IP;
        private static Socket client;

        /* public static string layIpCuaMayClient()
         {
             string hostName = Dns.GetHostName();

             IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);

             IPAddress[] iPAddress = ipHostEntry.AddressList;

             return "IP: " + iPAddress[0].ToString();

         }*/


        public static bool connect(string ip)
        {

            //địa chỉ của server
            IP = new IPEndPoint(IPAddress.Parse(ip), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                    client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến Server: " + ip, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Thread listen = new Thread(nhanThongTinTuServer);
            listen.IsBackground = true;
            listen.Start();
            return true;
        }

        public static void close()
        {
            try
            {
                guiTinDenServer("close");
            }
            catch { }
            client.Close();
        }

        public static void guiTinDenServer(object test)
        {
            client.Send(phanManhRa(test));
        }

        public static void nhanThongTinTuServer()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)gomManhLai(data);

                    messServer(message);
                }
            }
            catch
            {
                close();
            }
        }

        private static void messServer(string messFromServer)
        {
            if(messFromServer == "close")
            {
                foreach(Form f in Application.OpenForms)
                {
                    if (f.Name != "FrmClient")
                        f.Dispose();
                }
                MessageBox.Show("Server đã đóng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Restart();
            }
            if(messFromServer == "disSql")
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name != "FrmClient")
                        f.Dispose();
                }
                MessageBox.Show("Server đã ngắt kết nối sql của bạn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                QuanLyNhaHang.Properties.Settings.Default.Reset();
                Application.Restart();
            }
            else
            {
                idSanh = messFromServer;
            }
        }

        public static string truyenTindenFormManage()
        {
            return idSanh;
        }

        public static byte[] phanManhRa(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        public static object gomManhLai(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }



        /*private event EventHandler<EventTruyenDuLieu> truyenTestTrenMay;
        public event EventHandler<EventTruyenDuLieu> TruyenTestTrenMay
        {
            add { truyenTestTrenMay += value; }
            remove { truyenTestTrenMay -= value; }
        }*/


        private void showFormNao()
        {
            try
            {
                DatabaseExecute.conn.Open();
                DatabaseExecute.conn.Close();
                FrmBegin f = new FrmBegin(testTrenMay);
                
                if (Application.OpenForms["FrmBegin"] == null)
                    f.Show();
                else
                    Application.OpenForms["FrmBegin"].Focus();
            }
            catch (Exception)
            {
                QuanLyNhaHang.Properties.Settings.Default.Reset();
                FrmSqlConnection f = new FrmSqlConnection(txtIPServer.Text);
                
                if (Application.OpenForms["FrmSqlConnection"] == null)
                    f.Show();
                else
                    Application.OpenForms["FrmSqlConnection"].Focus();
            }
            finally
            {
                DatabaseExecute.conn.Close();
            }
        }

        #endregion


        public FrmClient()
        {
            InitializeComponent();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            if (radioButton_local.Checked == true)
            {
                testTrenMay = 1;
                showFormNao();
            }
            else
            {
                if (txtIPServer.Text != "")
                {
                    if (connect(txtIPServer.Text))
                    {
                        testTrenMay = -1;
                        showFormNao();
                    }
                    testClickConnect = true;
                }
                else
                {
                    MessageBox.Show("Chưa nhập IP Server!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIPServer.Focus();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(testClickConnect == true)
               close();
        }

        private void radioButton_server_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_server.Checked == true)
            {
                panel_ip.Enabled = true;
            }
            else
            {
                panel_ip.Enabled = false;
            }
        }

        private void checkBox_LocalHost_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_LocalHost.Checked == true)
            {
                txtIPServer.Text = "127.0.0.1";
                txtIPServer.ReadOnly = true;
            }
            else
            {
                txtIPServer.Text = "";
                txtIPServer.ReadOnly = false;
            }
        }

        private void FrmClient_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton_local_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_LocalHost.Checked = false;
            txtIPServer.Text = "";
        }
    }
}
