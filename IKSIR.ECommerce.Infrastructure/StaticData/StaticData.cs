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

    }

}

