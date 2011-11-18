using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public class posnettds_config
    {
        public static string MERCHANT_ID = "6734273367";
        public static string TERMINAL_ID = "67932822";
        public static string POSNET_ID = "3261";
        public static string ENCKEY = "10,10,10,10,10,10,10,10";

    //'OOS/TDS sisteminin web adresi
    public static string OOS_TDS_SERVICE_URL = "http://setmpos.ykb.com/3DSWebService/YKBPaymentService";
    //'Posnet XML Servisinin web adresi
    public static string XML_SERVICE_URL = "http://setmpos.ykb.com/PosnetWebService/XML";

    //'Üye İşyeri sayfası başlangıç web adresi (hata durumunda bu sayfaya dönülür.)
    public static string MERCHANT_INIT_URL = "OrderPayment.aspx";
    //'Üye İşyeri dönüş sayfasının web adresi
    public static string MERCHANT_RETURN_URL = "http://localhost:1751/Posnet.NetOOSTDS/merchant_islem_sonu.aspx";

    public static string OPEN_NEW_WINDOW = "0";

    //'3D-Secure kontrolleri
    public static bool TD_SECURE_CHECK = false;
    public static string TD_SECURE_CHECK_MASK = "1:2:4";
    }
}