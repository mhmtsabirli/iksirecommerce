using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.UI;
namespace IKSIR.ECommerce.Toolkit
{
    public class Utility
    {
        protected bool IsEmail(string mail)
        {
            string emailPattern = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";

            return Regex.IsMatch(mail, emailPattern);
        }
        public static string Encrypt(string strValue)
        {
            return Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(strValue));
        }
        public static string Decrypt(string strValue)
        {
            return System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(strValue));
        }
        public static string CurrencyFormat(decimal currency)
        {
             
            string temp = "";
            if (currency < 1)
            {
                temp = "0" + currency.ToString("#,##.00");
            }
            else
            {
                temp = currency.ToString("#,##.00");
            }
            if (temp.Substring(temp.Length - 3, 1) != ",")
            {
                temp = temp.Replace(',', '+');
                temp = temp.Replace('.', ',');
                temp = temp.Replace('+', '.');
            }
            return NumberManipulation.ChangeNumberFormatByCulture(temp, new CultureInfo("tr-TR"), Thread.CurrentThread.CurrentCulture); 
        }
    }
}
