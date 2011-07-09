using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCNewsFromUs : System.Web.UI.UserControl
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
            var itemList = NewsData.GetList();

            sbMenuItems.AppendLine("<ul>");

            int i = 0;
            foreach (var item in itemList)
            {
                i++;                
                sbMenuItems.AppendLine("<li><span>" + item.CreateDate.ToString("dd/MM/yyyy") + "</span> <a href=\"../Pages/Content.aspx?newsid=" + item.Id.ToString() + "\">" + item.Title + "</a></li>");
                if (i > 5)
                    break;
            }
            sbMenuItems.AppendLine("</ul>");

            divMenuItems.InnerHtml = sbMenuItems.ToString();
        }
    }
}