using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class HoaDonTheoBanDAL
    {
        public static List<ChiTietHoaDonTheoBan> layHoaDonTheoIdBanAn(int idBanAn)
        {
            List<ChiTietHoaDonTheoBan> list = new List<ChiTietHoaDonTheoBan>();
            string query = "SELECT t.tenThucAn, ct.soLuong, ct.soLuong*t.giaTien AS [thanhTien] FROM dbo.ChiTietHoaDon AS ct, dbo.HoaDon AS hd, dbo.ThucAn AS t WHERE ct.idHoaDon = hd.idHoaDon AND ct.idThucAn = t.idThucAn AND hd.idBanAn = " + idBanAn;
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach(DataRow r in data.Rows)
            {
                ChiTietHoaDonTheoBan test = new ChiTietHoaDonTheoBan(r);
                list.Add(test);
            }
            return list;
        }
    }
}
