using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProblem.DTO
{
    public class IPConnection
    {
        private string ip;

        public IPConnection(DataRow r)
        {
            this.Ip = r["ip"].ToString();
        }

        public string Ip
        {
            get
            {
                return ip;
            }

            set
            {
                ip = value;
            }
        }
    }
}
