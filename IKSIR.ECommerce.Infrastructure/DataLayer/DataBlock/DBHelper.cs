using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock
{
    public class DBHelper
    {
        public static int IntValue(object value)
        {
            int retValue;
            if (value == null || value == DBNull.Value || value == "")
                retValue = 0;
            else
            {
                if (Int32.TryParse(value.ToString(), out retValue))
                    return retValue;
                else
                    retValue = 0;
            }
            return retValue;
        }

        public static string StringValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return "";
            else
                return value.ToString();
        }

        public static decimal DecValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0M;
            else
                return Convert.ToDecimal(value);
        }
        public static DateTime DateValue(object value)
        {
            if (value == null || value == DBNull.Value || value == "")
                return Convert.ToDateTime("01.01.2000");
            else
                return Convert.ToDateTime(value);
        }
    }
}
