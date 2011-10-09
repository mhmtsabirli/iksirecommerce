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
            if (!Page.IsPostBack)
            {
                BindCategories();
                if (Request.QueryString["catid"] != null && Request.QueryString["catid"] != "")
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "$('#example4 .expand_all').click(); $('#menu4 > li > a.expanded + ul').show();", true);

                    int catid = 0;
                    int.TryParse(Request.QueryString["catid"], out catid);
                    var catItem = ProductCategoryData.Get(catid);
                    var item = Request.Form["anchor" + catItem.ParentCategory.Id];
                    if (item != null)
                    { 
                        
                    }
                }
            }
        }

        private void BindCategories()
        {
            StringBuilder sbMainCategories = new StringBuilder();
            List<ProductCategory> itemList = GetCategories();
            var parentCat = new ProductCategory() { Id = 0 };
            if (itemList != null && itemList.Count > 0)
            {
                var mainCategories = itemList.Where(x => x.ParentCategory == null).ToList();
                sbMainCategories.AppendLine("<ul id=\"menu1\" class=\"example_menu\">");
                foreach (var item in mainCategories)
                {
                    sbMainCategories.AppendLine("<li><a name=\"anchor" + item.Id + "\" class=\"collapsed\">" + item.Title + "</a>");
                    var subCategories = itemList.Where(x => x.ParentCategory != null && x.ParentCategory.Id == item.Id).ToList();
                    if (subCategories.Count > 0)
                    {
                        sbMainCategories.AppendLine("<ul>");
                        foreach (var itemSub in subCategories)
                        {
                            sbMainCategories.AppendLine("<li><a href=\"/Pages/ProductList.aspx?catid=" + itemSub.Id.ToString() + "\">" + itemSub.Title + "</a>");
                        }
                        sbMainCategories.AppendLine("</ul>");
                    }
                }
                sbMainCategories.AppendLine("</ul>");

                divMainCategories.InnerHtml = sbMainCategories.ToString();
            }
        }

        private List<ProductCategory> GetCategories()
        {
            List<ProductCategory> itemList = new List<ProductCategory>();
            if (Session["SITE_MAIN_CATEGORIES"] != null)
            {
                itemList = (List<ProductCategory>)Session["SITE_MAIN_CATEGORIES"];
            }
            else
            {
                itemList = ProductCategoryData.GetProductCategoryList();
                Session.Add("SITE_MAIN_CATEGORIES", itemList);
            }
            return itemList;
        }
    }
}