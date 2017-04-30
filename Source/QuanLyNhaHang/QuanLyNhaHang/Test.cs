using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang
{
    public class Test
    {
        //có chứa 1 số trở lên
        public static bool HasNumber(string input)
        {
            return input.Where(x => Char.IsDigit(x)).Any();
        }

        //chuỗi là số thôi
        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
