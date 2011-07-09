using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.StaticData;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCMainCategories : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sbMainCategories = new StringBuilder();

            var itemList = ProductCategoryData.GetProductCategoryList();
            var parentCat = new ProductCategory() { Id = 0 };
            var mainCategories = itemList.Where(x => x.ParentCategory == null).ToList();

            sbMainCategories.AppendLine("<ul id=\"menu1\" class=\"example_menu\">");
            foreach (var item in mainCategories)
            {
                sbMainCategories.AppendLine("<li><a class=\"collapsed\">" + item.Title + "</a>");
                var subCategories = itemList.Where(x => x.ParentCategory != null && x.ParentCategory.Id == item.Id).ToList();
                if (subCategories.Count > 0)
                {
                    sbMainCategories.AppendLine("<ul>");
                    foreach (var itemSub in subCategories)
                    {
                        sbMainCategories.AppendLine("<li><a href=\"../Pages/ProductList.aspx?catid=" + itemSub.Id.ToString() + "\">" + itemSub.Title + "</a>");
                    }
                    sbMainCategories.AppendLine("</ul>");
                }
            }
            sbMainCategories.AppendLine("</ul>");

            divMainCategories.InnerHtml = sbMainCategories.ToString();
        }
    }
}