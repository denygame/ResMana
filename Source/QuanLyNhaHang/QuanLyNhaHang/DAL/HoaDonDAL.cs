using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class HoaDonDAL
    {
        public static int layIdHDchuaThanhToanTheoIDban(int idBanAn)
        {
            DataTable data = DatabaseExecute.sqlQuery("select * from HoaDon where trangThai = N'Chưa thanh toán' and idBanAn = " +  idBanAn );
            if (data.Rows.Count > 0)
            {
                HoaDon layID = new HoaDon(data.Rows[0]);
                return layID.IdHoaDon;
            }
            return -1;
        }
        public static void themHoaDonChoBan(int idBanAn, string userName)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_ThemHoaDon @idBanAn , @userName", new object[] { idBanAn, userName });
            }
            catch
            { }
        }
        public static int layIdHoaDonCuoiCung()
        {
            try { return (int)DatabaseExecute.sqlExecuteScalar("select MAX(idHoaDon) from HoaDon"); }
            catch { return -1; }
        }

        public static void xoaHoaDonBan_HuyBan(int idBanAn)
        {
            try { DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_HuyBan_XoaHoaDon @idBanAn ", new object[] { idBanAn }); }
            catch { }
        }

        public static DataTable layDShoaDonChuaThanhToan()
        {
            return DatabaseExecute.sqlQuery("SELECT s.tenSanh, ba.tenBan, hd.ngayDen, hd.trangThai FROM dbo.HoaDon AS hd, dbo.BanAn AS ba, dbo.Sanh AS s WHERE ba.idBanAn = hd.idBanAn AND ba.idSanh = s.idSanh AND hd.trangThai = N'Chưa thanh toán'");
        }
    }
}