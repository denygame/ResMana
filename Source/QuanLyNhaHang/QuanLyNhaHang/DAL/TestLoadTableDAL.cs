﻿using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAL
{
    public class TestLoadTableDAL
    {
        public static int getCountTableChange()
        {
            return (int)DatabaseExecute.sqlExecuteScalar("SP_getCountTableChange");
        }

        public static List<TestLoadTable> getListIdTableChange()
        {
            List<TestLoadTable> list = new List<TestLoadTable>();
            DataTable data = DatabaseExecute.sqlQuery("SP_getListIdTableChange");
            foreach(DataRow r in data.Rows)
            {
                TestLoadTable i = new TestLoadTable(r);
                list.Add(i);
            }
            return list;
        }

        public static void deleteTestTableinSql()
        {
            DatabaseExecute.sqlQuery("SP_deleteTestTableinSql");
        }
    }
}
