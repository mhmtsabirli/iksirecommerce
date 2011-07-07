using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCMainCategories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbMainCategories = new StringBuilder();
            sbMainCategories.AppendLine("<ul id=\"menu1\" class=\"example_menu\">");
            sbMainCategories.AppendLine("<li><a class=\"collapsed\">MainItem 1</a>");
            sbMainCategories.AppendLine("<ul>");
            sbMainCategories.AppendLine("<li><a href=\"#\">SubMenu1</a></li>");
            sbMainCategories.AppendLine("<li><a href=\"#\">SubMenu2</a></li>");
            sbMainCategories.AppendLine("<li><a href=\"#\">SubMenu3</a></li>");
            sbMainCategories.AppendLine("</ul>");
            sbMainCategories.AppendLine("</li>");
            sbMainCategories.AppendLine("</ul>");
            divMainCategories.InnerHtml = sbMainCategories.ToString();
        }
    }
}