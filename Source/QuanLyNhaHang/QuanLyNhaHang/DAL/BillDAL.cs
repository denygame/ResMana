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
            DataTable data = DatabaseExecute.sqlQuery("SP_getIdBillUncheckByTable @idBanAn", new object[] { idBanAn });
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
            try { return (int)DatabaseExecute.sqlExecuteScalar("SP_getLastIdBill"); }
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
        /// lấy danh sách hóa đơn chưa thanh toán (không dùng nữa)
        /// </summary>
        /// <returns></returns>
        public static DataTable getListUncheckBill()
        {
            return DatabaseExecute.sqlQuery("SP_getListUncheckBill");
        }

        public static DataTable GetBillListByDateANDpage(DateTime In, DateTime Out, int page, int pageRows)
        {
            return DatabaseExecute.sqlQuery("StoredProcedure_PhanTrangHoaDonDTT @dateIn , @dateOut , @page , @pageRows", new object[] { In, Out, page, pageRows });
        }

        public static DataTable GetBillUncheckListByDateANDpage(int page, int pageRows)
        {
            return DatabaseExecute.sqlQuery("StoredProcedure_PhanTrangHoaDonCTT @page , @pageRows", new object[] { page, pageRows });
        }


        public static void CheckOut(int idBill, int discount, float totalPrice)
        {
            DatabaseExecute.sqlExecuteNonQuery("SP_checkOut @idBill , @totalPrice , @discount", new object[] { idBill, totalPrice, discount });
        }

        public static int GetNumBillByDate(DateTime from, DateTime to)
        {
            return (int)DatabaseExecute.sqlExecuteScalar("StoredProcedure_laySoHoaDonDTT @dateIn , @dateOut", new object[] { from, to });
        }

        public static int GetNumUncheckBill()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("StoredProcedure_laySoHoaDonCTT");
        }


        public static double getTotalMoney(DateTime from, DateTime to)
        {
            return (double)DatabaseExecute.sqlExecuteScalar("StoredProcedure_layTongDoanhThu @dateIn , @dateOut ", new object[] { from, to });
        }
    }
}