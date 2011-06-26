using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static bool isDate(this string Date)
        {
            try
            {
                Convert.ToDateTime(Date);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool isNumeric(this string Number)
        {
            try
            {
                Convert.ToInt32(Number);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}