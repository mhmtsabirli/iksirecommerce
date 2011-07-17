using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

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
                GetItems();
            }
        }

        private void GetItems()
        {
            StringBuilder sbMenuItems = new StringBuilder();
            var itemModule = ModuleData.Get(new Model.CommonModel.Module(){Id=moduleId});
            var itemModuleProductList = ModuleProductData.GetModuleProductList(moduleId);

            if(itemModule != null)
                lblModuleName.Text = itemModule.Name;

            sbMenuItems.AppendLine("<ul>");

            foreach (var item in itemModuleProductList)
            {
                sbMenuItems.AppendLine("<li><a href=\"../Pages/ProductDetails.aspx?pid=" + item.Id.ToString() + "\">" + item.Title + "</a></li>");
            }
            sbMenuItems.AppendLine("</ul>");

            divModuleProducts.InnerHtml = sbMenuItems.ToString();
        }
    }
}