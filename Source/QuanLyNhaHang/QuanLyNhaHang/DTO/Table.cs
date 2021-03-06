﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DTO
{
    public class Table
    {
        private int idBanAn, idSanh;
        private string tenBan, trangThai;


        public Table() { }

        public Table(DataRow rows)
        {
            this.IdBanAn = (int)rows["idBanAn"];
            this.TenBan = rows["tenBan"].ToString();
            this.IdSanh = (int)rows["idSanh"];
            this.TrangThai = rows["trangThai"].ToString();
        }
      

        public int IdBanAn
        {
            get
            {
                return idBanAn;
            }

            set
            {
                idBanAn = value;
            }
        }

        public int IdSanh
        {
            get
            {
                return idSanh;
            }

            set
            {
                idSanh = value;
            }
        }

        public string TenBan
        {
            get
            {
                return tenBan;
            }

            set
            {
                tenBan = value;
            }
        }


        public string TrangThai
        {
            get
            {
                return trangThai;
            }

            set
            {
                trangThai = value;
            }
        }
    }
}
