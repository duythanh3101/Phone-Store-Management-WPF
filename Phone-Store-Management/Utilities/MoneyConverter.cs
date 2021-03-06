﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Store_Management.Utilities
{
    public class MoneyConverter
    {
        public static string ToDecimal(double price)
        {
            decimal value = 0.00M;
            value = Convert.ToDecimal(price);
            return value.ToString("C");
            //decimal value = 0.00M;
            //value = Convert.ToDecimal(price);
            //return value.ToString("#,###" + " VND", CultureInfo.GetCultureInfo("vi-VN").NumberFormat);
        }

        public static string ToMoney(long value)
        {
            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
            return String.Format(info, "{0:c}", value);
        }
    }
}
