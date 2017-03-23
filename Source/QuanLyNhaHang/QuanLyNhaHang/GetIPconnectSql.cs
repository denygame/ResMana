using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang
{
    public class GetIPconnectSql
    {
        public static string getIP()
        {
            string myIP = "";
            string hostname = "";
            IPHostEntry ip = new IPHostEntry();
            hostname = Dns.GetHostName();
            ip = Dns.GetHostByName(hostname);

            foreach (IPAddress listip in ip.AddressList)
            {
                myIP = listip.ToString();
            }
            return myIP;
        }

    }
}

