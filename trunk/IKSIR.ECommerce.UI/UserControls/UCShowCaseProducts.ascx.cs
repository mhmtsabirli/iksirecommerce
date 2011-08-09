using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.UI.ClassLibrary;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCShowCaseProducts : System.Web.UI.UserControl
    {
        private int moduleId = 0;
        public int ModuleId
        {
            set { moduleId = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetItems();
            }
        }

        private void GetItems()
        {
            var itemModuleProductList = ModuleProductData.GetModuleProductList(moduleId);
            if (itemModuleProductList.Count > 6)
            {
                anchorContinue.Visible = true;
                anchorContinue.HRef = "../Pages/ProductList.aspx?modid=" + moduleId.ToString() + "&p=2";
            }
            else
            {
                anchorContinue.Visible = false;
            }
            dlShowCaseProducts.DataSource = itemModuleProductList.Take(6);
            dlShowCaseProducts.DataBind();

            foreach (DataListItem item in dlShowCaseProducts.Items)
            {
                if (item.FindControl("imgProduct") != null && item.FindControl("hdnProductId") != null)
                {
                    Image imgProduct = (Image)item.FindControl("imgProduct");
                    HiddenField hdnProductId = (HiddenField)item.FindControl("hdnProductId");

                    int productId = 0;
                    if (hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                    {
                        imgProduct.ImageUrl = "";
                        var itemProduct = itemModuleProductList.Where(x => x.Id == productId).FirstOrDefault();
                        if (itemProduct != null && itemProduct.Multimedias != null && itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
                        {
                            var image = itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                            imgProduct.ImageUrl = "http://212.58.8.103/documents/Images/Small/small_" + image.FilePath;
                        }
                    }
                }
            }
        }

        protected void imgbtnAddtoBasket_Click(object sender, ImageClickEventArgs e)
        {
            int productId = 0;
            string strproductId = ((ImageButton)sender).CommandArgument;

            if (int.TryParse(strproductId, out productId))
                Shopping.AddToBasket(productId);
        }
    }
}