using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsRelatedProducts : UCProductDetailsMaster
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
            var itemModuleProductList = RelatedProductData.GetRelatedProductList(productId);
            dlShowCaseProducts.DataSource = itemModuleProductList;
            dlShowCaseProducts.DataBind();

            foreach (DataListItem item in dlShowCaseProducts.Items)
            {
                if (item.FindControl("imgProduct") != null)
                {
                    Image imgProduct = (Image)item.FindControl("imgProduct");
                    int relatedProductId = 0;
                    HiddenField hdnRelatedProductId = (HiddenField)item.FindControl("hdnRelatedProductId");

                    int.TryParse(hdnRelatedProductId.Value, out relatedProductId);
                    imgProduct.ImageUrl = "";
                    var itemProduct = itemModuleProductList.Where(x => x.Id == relatedProductId).FirstOrDefault();
                    if (itemProduct != null && itemProduct.Multimedias != null && itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
                    {
                        var image = itemProduct.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                        imgProduct.ImageUrl = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_" + image.FilePath;
                    }
                    else
                    {
                        imgProduct.ImageUrl = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_nopicture.jpg";
                    }
                }
            }
        }
    }
}