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
                int imageCount = 0;
                foreach (var item in productMultimedias)
                {
                    imageCount += 1;
                    otherImages += "<a href=\"#\"><img src=\"http://212.58.8.103/documents/Images/Icon/icon_" + item.FilePath + "\" alt=\"\" /></a>";
                    if (imageCount == 3)
                        break;
                }
                if (product.Video != null && product.Video != "")
                {
                    otherImages += "<a href=\"#\"><img src=\"../images/urun_video.jpg\" alt=\"Ürün videosunu izlemek için tıklayınız.\" /></a>";
                }
                divOtherImages.InnerHtml = otherImages;
                lblProductCode.Text = product.ProductCode;
                lblProductName.Text = product.Title;
                lblProductWarranty.Text = product.Guarantee.ToString() + " Yıl";
                lblProductStock.Text = product.Stok.ToString();
                lblProductPrice.Text = product.ProductPrice.UnitPrice.ToString();
                lblProductPriceWithKDV.Text = product.ProductPrice.Price.ToString();
                lblBigProductPrice.Text = product.ProductPrice.Price.ToString();
            }
            catch (Exception exception)
            {
            }
        }
    }
}