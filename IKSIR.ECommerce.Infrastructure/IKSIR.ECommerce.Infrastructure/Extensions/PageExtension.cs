using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace IKSIR.ECommerce.Infrastructure.Extensions
{
    public static class PageExtension
    { 
        public static void Alert(this Page page, string alert)
        {
            page.ClientScript.RegisterStartupScript(typeof(Page), "alert", "alert('" + alert + "');", true);
        }
    }
}
