using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsSimilarProducts : UCProductDetailsMaster
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
            var itemModuleProductList = SimilarProductData.GetSimilarProductList(productId);
            dlShowCaseProducts.DataSource = itemModuleProductList;
            dlShowCaseProducts.DataBind();

            foreach (DataListItem item in dlShowCaseProducts.Items)
            {
                if (item.FindControl("imgProduct") != null)
                {
                    Image imgProduct = (Image)item.FindControl("imgProduct");
                    HiddenField hdnProductId = (HiddenField)item.FindControl("hdnProductId");

                    imgProduct.ImageUrl = "";
                    var itemProduct = itemModuleProductList.Where(x => x.Id == productId).FirstOrDefault();
                    if (itemProduct != null && itemProduct.Multimedias != null && itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
                    {
                        var image = itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                        imgProduct.ImageUrl = "http://banyom.com.tr/documents/Images/Icon/icon_" + image.FilePath;
                    }
                }
            }
        }
    }
}