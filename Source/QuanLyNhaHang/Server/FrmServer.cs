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

namespace Server
{
    public partial class FrmServer : Form
    {
        #region - SERVER -
        private IPEndPoint IP;
        private  Socket server;
        private  List<Socket> clientList;
        private Thread listen;
        private string remoteEndPoint;

        private string layIpServer()
        {
            string myIP = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress diachi in host.AddressList)
            {
                if (diachi.AddressFamily.ToString() == "InterNetwork")
                    myIP = diachi.ToString();
            }
            return myIP;
        }

        private void connect()
        {
            txtIP.Text = layIpServer();
            clientList = new List<Socket>();

            IP = new IPEndPoint(IPAddress.Any, 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            server.Bind(IP); // chấp nhận IP

            listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100); // tối đa 100 client đồng thời
                        Socket client = server.Accept();
                        int dem = 0;

                        //chỉ chấp nhận client kết nối 1 lần
                        foreach (Socket s in clientList)
                            if (getIPClient(getIPandPortclient(s)) == getIPClient(getIPandPortclient(client)))
                                dem++;
                        if (dem == 0)
                        {
                            clientList.Add(client);
                            textBox_server.Text += "\r\n\t# " + getIPandPortclient(client) + " connect...";
                        }

                        Thread nhan = new Thread(nhanThongTinTuCacClient);
                        nhan.IsBackground = true;
                        nhan.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }


        //test lại
        private void close(List<Socket> client)
        {
            try
            {
                foreach (Socket i in client) //đóng hết kết nối client
                {
                    guiTinDenClient(i, "close");
                    i.Close();
                }

                client.Clear();

                server.Close();
            }
            catch { }
        }

        private void guiTinDenClient(Socket client, object test)
        {
            client.Send(phanManhRa(test));
        }

        private void nhanThongTinTuCacClient(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);

                    string message = (string)gomManhLai(data);

                    luuTTclientGuiVao(client, message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        
        //test
        private void luuTTclientGuiVao(Socket client,string mess)
        {
            if(mess == "close")
            {
                textBox_server.AppendText("\r\n\t# " + getIPandPortclient(client) + " disconnect...");
                clientList.Remove(client);
                return;
            }
            textBox_server.AppendText("\r\n\t# " + getIPandPortclient(client) + " send: " + mess);

            //gửi tin đến các client còn lại
            foreach(Socket s in clientList)
            {
                if (getIPandPortclient(s) != getIPandPortclient(client))
                    guiTinDenClient(s, mess);
            }
        }

        private byte[] phanManhRa(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        private object gomManhLai(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        //lấy ip và port của các client kết nối
        private string getIPandPortclient(Socket client)
        {
            string str = "";
            try
            {
                str = Convert.ToString(client.RemoteEndPoint);
                remoteEndPoint = str;
            }
            catch (Exception e)
            {
                string str1 = "Error..... " + e.StackTrace;
                //Console.WriteLine(str1);
                str = "Socket is closed with " + remoteEndPoint;
            }
            return str;
        }

        private static string getIPClient(string getIdandPort)
        {
            string[] cut = getIdandPort.Split(':');
            return cut[0];
        }

        private Socket getClientDisSql(string ip)
        {
            string ipTest = "";
            foreach(Socket s in clientList)
            {
                ipTest = getIPClient(getIPandPortclient(s));
                if (ipTest == ip)
                    return s;   
            }
            return null;
        }

        #endregion




        public FrmServer()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false; //ngăn....
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                connect();
                textBox_server.AppendText("\r\n\t# Mở server thành công...");
                btn_Stop.Enabled = true;
                btnStart.Enabled = false;
                
            }
            catch
            {
                textBox_server.AppendText("\r\n\t# Mở server thất bại...");
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                close(clientList);
                textBox_server.AppendText("\r\n\t# Đóng server thành công...");
                btnStart.Enabled = true;
                btn_Stop.Enabled = false;
            }
            catch
            {
                textBox_server.AppendText("\r\n\t# Đóng server thất bại... ");
            }
        }


        /// <summary>
        /// tiếp tục thêm lệnh, test lại còn sai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            if(txtExe.Text != "")
            {
                //thiếu bước kiểm tra ip
                //cấu trúc: disconnect sql ip
                if(txtExe.Text.Contains("disconnect sql"))
                {
                    string[] cut = txtExe.Text.Split(' ');
                    string ip = cut[2];
                    Socket client = getClientDisSql(ip);
                    guiTinDenClient(client, "disSql");
                    txtExe.Text = "";
                    textBox_server.AppendText("\r\n\r\n\t# Ngắt kết nối sql IP: " + ip + "\r\n");
                }
            }
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            close(clientList);
        }

        
    }
}
