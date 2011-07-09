using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
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
            ModuleProduct itemModuleProduct = new ModuleProduct() { Module = new Model.CommonModel.Module() { Id = 1 } };
            var itemModuleProductList = ModuleProductData.GetModuleProductList(itemModuleProduct);

            sbMenuItems.AppendLine("<ul>");

            foreach (var item in itemModuleProductList)
            {
                sbMenuItems.AppendLine("<li><a href=\"../Pages/ProductDetails.aspx?pid=" + item.Product.Id.ToString() + "\">" + item.ProductName + "</a></li>");
            }
            sbMenuItems.AppendLine("</ul>");

            divMenuItems.InnerHtml = sbMenuItems.ToString();
        }
    }
}