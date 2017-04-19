using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang
{
    public class EncryptPassword
    {
        public static byte[] encryptData(string data)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedBytes;
            UTF8Encoding encoder = new UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string md5(string data)
        {
            string maHoa = BitConverter.ToString(encryptData(data)).Replace("-", "").Replace("1", "ute").Replace("7", "leuleu").Replace("z", "p").Replace("5", "#->87@o{}").Replace("0", "ksadjhq159").ToLower() ;
            maHoa += "qwsxaczdervhdsfuebfewpof5jgikngdHSsSFfdspofjsdoifuiegtfweg6514fds65f85sd1fffd65xf";
            return maHoa;
        }
    }
}
