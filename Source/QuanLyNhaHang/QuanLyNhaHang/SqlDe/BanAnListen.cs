using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.SqlDe
{
    public class BanAnListen
    {
        private SqlDependencyEx sqlDe;
        private int idSanh;

        public int IdSanh
        {
           get { return idSanh; }
           set { idSanh = value; }
        }

        public BanAnListen(int idSanh)
        {
            this.IdSanh = idSanh;

            string query = "SELECT [idHoaDon], [idBanAn], [trangThai] FROM [dbo].[HoaDon]";
            sqlDe = new SqlDependencyEx(hamChay, query);

            sqlDe.loadData();
        }

        private void hamChay()
        {
            FrmManage f = new FrmManage();
            f.khoiTaoBanTheoIdSanh(IdSanh);
        }
    }
}
