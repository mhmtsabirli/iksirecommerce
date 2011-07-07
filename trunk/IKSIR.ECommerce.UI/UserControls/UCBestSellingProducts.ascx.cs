using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCBestSellingProducts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetItems();
            }
        }

        private void GetItems()
        {
            StringBuilder sbMenuItems = new StringBuilder();
            sbMenuItems.AppendLine("<ul>");
            sbMenuItems.AppendLine("<li><a href=\"#\">Ürün 1</a></li>");
            sbMenuItems.AppendLine("<li><a href=\"#\">Ürün 2</a></li>");
            sbMenuItems.AppendLine("<li><a href=\"#\">Ürün 3</a></li>");
            sbMenuItems.AppendLine("</ul>");
            divMenuItems.InnerHtml = sbMenuItems.ToString();
        }
    }
}