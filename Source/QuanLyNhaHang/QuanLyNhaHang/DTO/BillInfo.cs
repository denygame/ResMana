using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class BillInfo
    {
        private int idCTHD, idHoaDon, idThucAn, soLuong;

        public BillInfo(DataRow r)
        {
            this.IdCTHD = (int)r["idCTHD"];
            this.IdHoaDon = (int)r["idHoaDon"];
            this.IdThucAn = (int)r["idThucAn"];
            this.SoLuong = (int)r["soLuong"];
        }

        public int IdCTHD
        {
            get
            {
                return idCTHD;
            }

            set
            {
                idCTHD = value;
            }
        }

        public int IdHoaDon
        {
            get
            {
                return idHoaDon;
            }

            set
            {
                idHoaDon = value;
            }
        }

        public int IdThucAn
        {
            get
            {
                return idThucAn;
            }

            set
            {
                idThucAn = value;
            }
        }

        public int SoLuong
        {
            get
            {
                return soLuong;
            }

            set
            {
                soLuong = value;
            }
        }
    }
}
