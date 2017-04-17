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
        /// <summary>
        /// lấy hóa đơn của bàn ăn
        /// </summary>
        /// <param name="idBanAn"></param>
        /// <returns></returns>
        public static List<ChiTietHoaDonTheoBan> getBillByIdTable(int idBanAn)
        {
            List<ChiTietHoaDonTheoBan> list = new List<ChiTietHoaDonTheoBan>();
            string query = "SELECT t.tenThucAn, ct.soLuong, ct.soLuong*t.giaTien AS [thanhTien] FROM dbo.ChiTietHoaDon AS ct, dbo.HoaDon AS hd, dbo.ThucAn AS t WHERE ct.idHoaDon = hd.idHoaDon AND ct.idThucAn = t.idThucAn AND hd.trangThai = N'Chưa thanh toán' AND hd.idBanAn = " + idBanAn;
            DataTable data = DatabaseExecute.sqlQuery(query);
            foreach(DataRow r in data.Rows)
            {
                ChiTietHoaDonTheoBan test = new ChiTietHoaDonTheoBan(r);
                list.Add(test);
            }
            return list;
        }


        /// <summary>
        /// xóa món ăn trên hóa đơn
        /// </summary>
        /// <param name="idHoaDon"></param>
        /// <param name="tenMonAn"></param>
        /// <param name="soLuong"></param>
        public static void deleteFoodInBill(int idHoaDon, string tenMonAn, int soLuong)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_XoaMonTrongHDtheoBan @idHoaDon , @tenThucAn , @soLuong", new object[] { idHoaDon, tenMonAn, soLuong });
            }
            catch { }
        }

    }
}
