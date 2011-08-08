using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;

//Modüllerdeki ürünlerin gösterilmesini sağlar. En çok satılan en çok ziyaret edilen gibi. 
//Bu ürünler tek bir UserControlden modülId vasıtasıyla farklı modüllerdeki ürünlerin listelenmesini sağlar.
namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCModuleProducts : System.Web.UI.UserControl
    {
        private int moduleId = 0;
        public int ModuleId
        {
            set { moduleId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && moduleId != 0)
            {
                BindItems();
            }
        }

        private void BindItems()
        {
            StringBuilder sbMenuItems = new StringBuilder();
            List<Product> itemModuleProductList = GetItems();
            if (itemModuleProductList != null && itemModuleProductList.Count > 0)
            {
                sbMenuItems.AppendLine("<ul>");
                foreach (var item in itemModuleProductList)
                {
                    sbMenuItems.AppendLine("<li><a href=\"../Pages/ProductDetails.aspx?pid=" + item.Id.ToString() + "\">" + item.Title + "</a></li>");
                }
                sbMenuItems.AppendLine("</ul>");

                divModuleProducts.InnerHtml = sbMenuItems.ToString();
            }
        }

        private List<Product> GetItems()
        {
            List<Product> productList = new List<Product>();
            Dictionary<Module, List<Product>> allModuleProducts = new Dictionary<Module, List<Product>>();

            if (Session["SITE_MODULE_PRODUCTS"] != null)
            {
                allModuleProducts = (Dictionary<Module, List<Product>>)Session["SITE_MODULE_PRODUCTS"];
            }
            else
            {
                List<Module> allModules = ModuleData.GetModuleList();
                List<Product> moduleProducts = new List<Product>();

                foreach (Module module in allModules)
                {
                    moduleProducts = ModuleProductData.GetModuleProductList(module.Id);
                    allModuleProducts.Add(module, moduleProducts);
                }
                Session.Add("SITE_MODULE_PRODUCTS", allModuleProducts);
            }

            productList = allModuleProducts.Where(x => x.Key.Id == moduleId).SingleOrDefault().Value;
            var itemModule = allModuleProducts.Where(x => x.Key.Id == moduleId).SingleOrDefault().Key;
            if (itemModule != null)
                lblModuleName.Text = itemModule.Name;

            return productList;
        }
    }
}