using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsMain : UCProductDetailsMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && productId != 0)
            {
                GetProductDetails(productId);
            }
        }

        private void GetProductDetails(int productId)
        {
            try
            {
                var product = ProductData.Get(productId);
                var productMultimedias = MultimediasData.GetItemMultimedias(3, productId);
                var itemMainImage = productMultimedias.Where(x => x.IsDefault == true).First();
                if (itemMainImage != null)
                {
                    imgMainImage.ImageUrl = "http://212.58.8.103/documents/Images/Big/big_" + itemMainImage.FilePath;
                }

                string otherImages = "";
                foreach (var item in productMultimedias)
                {
                    otherImages += "<a href=\"#\"><img src=\"http://212.58.8.103/documents/Images/Small/small_" + item.FilePath + "\" alt=\"\" /></a>";
                }
                divOtherImages.InnerHtml = otherImages;
                lblProductCode.Text = product.ProductCode;
                lblProductName.Text = product.Title;
                //lblProductWarranty.Text = product.
                //lblProductStock.Text = product.
                //lblProductPrice.Text = product.
                //lblBigProductPrice.Text = product.
                //lblProductPriceWithKDV.Text = product.
            }
            catch (Exception exception)
            {
            }
        }
    }
}