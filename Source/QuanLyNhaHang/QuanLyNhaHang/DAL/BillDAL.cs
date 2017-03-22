using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class BillDAL
    {
        /// <summary>
        /// lấy id hóa đơn chưa thanh toán của bàn
        /// </summary>
        /// <param name="idBanAn"></param>
        /// <returns></returns>
        public static int getIdBillUncheckByIdTable(int idBanAn)
        {
            DataTable data = DatabaseExecute.sqlQuery("select * from HoaDon where trangThai = N'Chưa thanh toán' and idBanAn = " +  idBanAn );
            if (data.Rows.Count > 0)
            {
                Bill layID = new Bill(data.Rows[0]);
                return layID.IdHoaDon;
            }
            return -1;
        }

        /// <summary>
        /// thêm hóa đơn cho bàn
        /// </summary>
        /// <param name="idBanAn"></param>
        /// <param name="userName"></param>
        public static void addBillForTable(int idBanAn, string userName)
        {
            try
            {
                DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_ThemHoaDon @idBanAn , @userName", new object[] { idBanAn, userName });
            }
            catch
            { }
        }

        /// <summary>
        /// lấy id hóa đơn cuối
        /// </summary>
        /// <returns></returns>
        public static int getLastIdBill()
        {
            try { return (int)DatabaseExecute.sqlExecuteScalar("select MAX(idHoaDon) from HoaDon"); }
            catch { return -1; }
        }

        /// <summary>
        /// xóa hóa đơn, hủy bàn
        /// </summary>
        /// <param name="idBanAn"></param>
        public static void deleteBill_CancleTable(int idBanAn)
        {
            try { DatabaseExecute.sqlExecuteNonQuery("StoredProcedure_HuyBan_XoaHoaDon @idBanAn ", new object[] { idBanAn }); }
            catch { }
        }

        /// <summary>
        /// lấy danh sách hóa đơn chưa thanh toán
        /// </summary>
        /// <returns></returns>
        public static DataTable getListUncheckBill()
        {
            return DatabaseExecute.sqlQuery("SELECT s.tenSanh, ba.tenBan, hd.ngayDen, hd.trangThai FROM dbo.HoaDon AS hd, dbo.BanAn AS ba, dbo.Sanh AS s WHERE ba.idBanAn = hd.idBanAn AND ba.idSanh = s.idSanh AND hd.trangThai = N'Chưa thanh toán'");
        }
    }
}