using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace IKSIR.ECommerce.Infrastructure.StaticData
{
    class StaticData
    {

    }

    ///<summary>
    /// Idevit ile alakalı sabit bilgileri barındırır.
    ///</summary>
    public class Idevit
    {
        public const string SiteTitle = "Idevit E-Ticaret";
        public const string cssPatht = "C:idevit.css";

        public static string ConnectionString = System.Configuration.ConfigurationSettings.AppSettings["IdevitProdConnectionString"].ToString();
        public static string Agents = System.Configuration.ConfigurationSettings.AppSettings["Agents"].ToString();
        public static string MailHost = System.Configuration.ConfigurationSettings.AppSettings["MailHost"].ToString();
        public static string MailPort = System.Configuration.ConfigurationSettings.AppSettings["MailPort"].ToString();
        public static string MailUserName = System.Configuration.ConfigurationSettings.AppSettings["MailUserName"].ToString();
        public static string MailPassword = System.Configuration.ConfigurationSettings.AppSettings["MailPassword"].ToString();
        public static string ImagePath = System.Configuration.ConfigurationSettings.AppSettings["Idevit_ImagePath"].ToString();
        public static string DocumentPath = System.Configuration.ConfigurationSettings.AppSettings["Idevit_DocumentPath"].ToString();
    }
}

