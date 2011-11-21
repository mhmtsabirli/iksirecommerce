using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public class posnettds_util
    {
        public static string GetReturnURL(HttpRequest Request)
        {
            string url = "";
            Regex regEx = null;

            string domainName = Request.ServerVariables["SERVER_NAME"];
            url = Request.ServerVariables["URL"];

            string protocol = "http";
            if (Request.ServerVariables["HTTPS"] == "on")
            {
                protocol = "https";
            }

            string port = "";
            if (((protocol != "https") && (Request.ServerVariables["SERVER_PORT"] != "80"))
                || ((protocol == "https") && (Request.ServerVariables["SERVER_PORT"] != "443")))
            {
                port = ":" + Request.ServerVariables["SERVER_PORT"];
            }

            url = protocol + "://" + domainName + port + url;

            regEx = new Regex(".aspx", RegexOptions.IgnoreCase);
            return regEx.Replace(url, "_resp.aspx");
        }
        public static string ConvertYTLToYKR(string amount)
        {
            if (amount.Length > 0)
            {
                return Convert.ToString(Convert.ToDouble(amount.Replace(".", "")) * 100);
            }
            else
            {
                return amount;
            }
        }

         public static string  GetCurrencyText(string currencyCode )
         {

        if (currencyCode == "YT" || currencyCode == "TL") 
            return "TL";
        else if (currencyCode == "US") 
            return "USD";
        else if (currencyCode == "EU")
            return "EUR";
        else
            return "";
        
         }

  



    }
}