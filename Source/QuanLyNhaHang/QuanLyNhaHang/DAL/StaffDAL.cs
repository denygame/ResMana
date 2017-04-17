using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class StaffDAL
    {

        public static DataTable getDataTableStaff()
        {
            return DatabaseExecute.sqlQuery("SELECT idNhanVien AS [ID Nhân Viên], tenNhanVien AS [Tên Nhân Viên], ngaySinh AS [Ngày Sinh], gioiTinh AS [Giới Tính], chucVu AS [Chức Vụ] FROM dbo.NhanVien WHERE checkDelete = 0");
        }

        public static List<Staff> getListStaff()
        {
            List<Staff> list = new List<Staff>();
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM dbo.NhanVien WHERE checkDelete = 0");
            foreach (DataRow i in data.Rows)
            {
                Staff test = new Staff(i);
                list.Add(test);
            }
            return list;
        }

        public static Staff getStaff(int id)
        {
            DataTable data = DatabaseExecute.sqlQuery("SELECT * FROM dbo.NhanVien WHERE checkDelete = 0 AND idNhanVien = " + id);
            foreach (DataRow i in data.Rows)
                return new Staff(i);
            return null;
        }

        public static bool insertStaff( string ten, DateTime ngSinh, string gT, string cV, string que, string dC, string tel, string email)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("INSERT dbo.NhanVien( tenNhanVien ,ngaySinh , gioiTinh ,chucVu ,queQuan ,email ,diaChi , tel) VALUES(N'{0}', '{1}', N'{2}', N'{3}', N'{4}', '{5}', N'{6}', N'{7}')", ten, ngSinh, gT, cV, que, email, dC, tel));
            return result > 0;
        }

        //xoa 1 nhan vien fai xoa cac tk
        public static bool deleteStaff(int id)
        {
            if (AccountDAL.deleteAccByIdStaff(id))
            {
                int result = DatabaseExecute.sqlExecuteNonQuery("UPDATE dbo.NhanVien SET checkDelete = 1 WHERE idNhanVien = " + id);
                return result > 0;
            }
            return false;
        }

        public static bool updateStaff(int id, string ten, DateTime ngSinh, string gT, string cV, string que, string dC, string tel, string email)
        {
            int result = DatabaseExecute.sqlExecuteNonQuery(string.Format("UPDATE dbo.NhanVien SET tenNhanVien = N'{0}', ngaySinh = '{1}', gioiTinh = N'{2}', chucVu = N'{3}', queQuan = N'{4}', email = N'{5}', diaChi=N'{6}', tel=N'{7}' WHERE idNhanVien = {8}", ten, ngSinh, gT, cV, que, email, dC, tel, id));
            return result > 0;
        }

        public static int getLastIdStaff()
        {
            try { return (int)DatabaseExecute.sqlExecuteScalar("select MAX(idNhanVien) from NhanVien"); }
            catch { return -1; }
        }
    }
}
