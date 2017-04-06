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
    }
}
