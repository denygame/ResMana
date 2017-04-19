using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang
{
    public class Constant
    {
        public static int widthButtonBanAnSizeNho = 105;
        public static int heightButtonBanAnSizeNho = 105;
        public static int widthButtonBanAnSizeLon = 112;
        public static int heightButtonBanAnSizeLon = 112;

        public static int timeForRestartApp = 2;

        public static string databaseName = "HQTCSDL";
        public static string fileSqlName = "DataQLNH.sql";

        //dưới database
        public static string trangThaiCoNguoiTrongBan = "Khách";
        public static string trangThaiBanTrong = "Bàn Trống";

        public static string passDefault = "123";

        //in ra file txt pass mặc định đã mã hóa
        public static void passDefaultEncrypted()
        {
            using (StreamWriter sw = new StreamWriter("passDefaultEncrypted.txt"))
                sw.Write(EncryptPassword.md5(passDefault));
        }

        public static string portSqlServerSetUpByMe = ",1433";
        //public static string userNameSqlServer = "sa";
        //public static string passSqlServer = "123456";

        public static string them = "Them";
        public static string sua = "Sua";

        //3 loại tk : 0 là admin, 1 là nhân viên 2 là quản lý
        public static List<string> listLoaiTK = new List<string>() { "Quản Lý", "Nhân Viên" };
        public static List<string> listGioiTinh = new List<string>() { "Nam", "Nữ" };
        public static List<string> listNu = new List<string>() { "Nữ" };
        public static List<string> listNam = new List<string>() { "Nam" };

        public static int phanTrangHD = 16;
        public static int phanTrangNV = 14;
    }
}
