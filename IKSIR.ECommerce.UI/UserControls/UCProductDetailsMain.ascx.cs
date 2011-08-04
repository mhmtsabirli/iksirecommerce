using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.UI.ClassLibrary;

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
                    imgMainImage.Src = "http://212.58.8.103/documents/Images/Big/big_" + itemMainImage.FilePath;
                    anchorBigImage.HRef = "http://212.58.8.103/documents/Orginal/Images/" + itemMainImage.FilePath;
                }


                //<li><a class="zoomThumbActive" href='javascript:void(0);' rel="{gallery: 'gal1', smallimage: './imgProd/triumph_small1.jpg',largeimage: './imgProd/triumph_big1.jpg'}"><img src='imgProd/thumbs/triumph_thumb1.jpg'></a></li>


                string otherImages = "<ul id=\"thumblist\" class=\"clearfix\">";
                int imageCount = 0;
                foreach (var item in productMultimedias)
                {
                    imageCount += 1;
                    //otherImages += "<a href=\"#\"><img src=\"http://212.58.8.103/documents/Images/Icon/icon_" + item.FilePath + "\" alt=\"\" /></a>";
                    if(imageCount==1)
                    otherImages += "<li><a class=\"zoomThumbActive\" href='javascript:void(0);' rel=\"{gallery: 'gal1', smallimage: 'http://212.58.8.103/documents/Images/Big/big_" + item.FilePath + "',largeimage: 'http://212.58.8.103/documents/Orginal/Images/" + item.FilePath + "'}\"><img src=\"http://212.58.8.103/documents/Images/Icon/icon_" + item.FilePath + "\" alt=\"\" /></a></li>";
                    else
                        otherImages += "<li><a href='javascript:void(0);' rel=\"{gallery: 'gal1', smallimage: 'http://212.58.8.103/documents/Images/Big/big_" + item.FilePath + "',largeimage: 'http://212.58.8.103/documents/Orginal/Images/" + item.FilePath + "'}\"><img src=\"http://212.58.8.103/documents/Images/Icon/icon_" + item.FilePath + "\" alt=\"\" /></a></li>";

                    if (imageCount == 3)
                        break;
                }
                if (product.Video != null && product.Video != "")
                {
                    otherImages += "<a href=\"#\"><img src=\"../images/urun_video.jpg\" alt=\"Ürün videosunu izlemek için tıklayınız.\" /></a>";
                }
                otherImages += "</ul>";
                divOtherImages.InnerHtml = otherImages;
                lblProductCode.Text = product.ProductCode;
                lblProductName.Text = product.Title;
                lblProductWarranty.Text = product.Guarantee.ToString() + " Yıl";
                lblProductStock.Text = product.Stok.ToString();
                lblProductPrice.Text = product.ProductPrice.UnitPrice.ToString();
                lblProductPriceWithKDV.Text = product.ProductPrice.Price.ToString();
                lblBigProductPrice.Text = product.ProductPrice.Price.ToString();
                lbtnAddToBasket.CommandArgument = product.Id.ToString();
                for (int i = 1; i <= product.MaxQuantity; i++)
                {
                    ddlProductCount.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void lbtnAddToBasket_Click(object sender, EventArgs e)
        {
            int productId = 0;
            int count = 0;

            string strproductId = ((LinkButton)sender).CommandArgument;

            if (int.TryParse(strproductId, out productId) && int.TryParse(ddlProductCount.SelectedValue, out count))
                Shopping.AddToBasket(productId, count);
        }
    }
}