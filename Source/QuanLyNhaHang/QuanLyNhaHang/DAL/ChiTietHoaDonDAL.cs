using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class ChiTietHoaDonDAL
    {
        public static void themMonAnVaoBan(int idHoaDon, int idThucAn, int soLuong)
        {
            DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_ThemCTHD @idHoaDon , @idThucAn , @soLuong", new object[] { idHoaDon, idThucAn, soLuong });
        }
    }
}
