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

                if (productMultimedias == null || productMultimedias.Count == 0)
                {
                    productMultimedias.Add(new Model.CommonModel.Multimedia()
                    {
                        FilePath = "nopicture.jpg",
                        IsDefault = true
                    });
                }

                var itemMainImage = productMultimedias.Where(x => x.IsDefault == true).First();
                string otherImages = "";
                otherImages = "<div id=\"image\" style=\"height: 250px; width: 350px; background-color:Gray; border: 4px #666 solid; text-align:center;\">";

                if (itemMainImage != null)
                {
                    //imgMainImage.ImageUrl = 
                    otherImages += "<a href=\"http://banyom.com.tr/documents/Orginal/Images/" + itemMainImage.FilePath + "\" rel=\"lightbox\"><img src=\"http://banyom.com.tr/documents/Images/Big/big_" + itemMainImage.FilePath + "\" border=\"0\" /></a></div><br/>";
                }

                int imageCount = 0;
                foreach (var item in productMultimedias)
                {
                    imageCount += 1;
                    //otherImages += "<a href=\"#\"><img src=\"http://banyom.com.tr/documents/Images/Icon/icon_" + item.FilePath + "\" alt=\"\" /></a>";

                    otherImages += "<a href=\"#\" rel=\"http://banyom.com.tr/documents/Images/Big/big_" + item.FilePath + "\" class=\"image\">";
                    otherImages += "<img src=\"http://banyom.com.tr/documents/Images/Icon/icon_" + item.FilePath + "\" class=\"thumb\" border=\"0\" /></a>";

                    if (imageCount == 3)
                        break;
                }
                otherImages += " <div class=\"clear\"></div><div class='favori' style='float:left; width: 350px; padding-top:3px;'><a href='#'><img src='../images/urun_favorilere_ekle.jpg' alt='' />Favorilerime Ekle</a></div>";
                otherImages += "<br/><br/><div class='urun_paylas' style='float:left; width: 225px;'><ul><li><a href='#'><img src='../images/urun_paylas_1.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_2.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_3.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_4.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_5.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_6.png' alt='' /></a></li>";
                otherImages += "<li><a href='#'><img src='../images/urun_paylas_7.png' alt='' /></a></li></ul></div>";
                otherImages += "<div class='urun_yildiz' style='float:left;'></div><div class='clear'></div>";
                otherImages += "</div>";
                //otherImages += "<a href=\"#\"><img src=\"../images/urun_video.jpg\" alt=\"Ürün videosunu izlemek için tıklayınız.\" /></a>";

                if (product.Video != null && product.Video != "")
                {
                    otherImages += "<a href=\"#\"><img src=\"../images/urun_video.jpg\" alt=\"Ürün videosunu izlemek için tıklayınız.\" /></a>";
                }
                container.InnerHtml = otherImages;
                lblProductCode.Text = product.ProductCode;
                lblProductName.Text = product.Title;
                lblProductWarranty.Text = product.Guarantee.ToString() + " Yıl";
                lblProductStock.Text = product.Stok.ToString();
                lblProductPrice.Text = product.ProductPrice.UnitPrice.ToString();
                lblProductPriceWithKDV.Text = product.ProductPrice.Price.ToString();
                lblBigProductPrice.Text = product.ProductPrice.Price.ToString();
                imgBtnAddToBasket.CommandArgument = product.Id.ToString();
                imgBtnBuyNow.CommandArgument = product.Id.ToString();
                for (int i = 1; i <= product.MaxQuantity; i++)
                {
                    ddlProductCount.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
            }
            catch (Exception exception)
            {
            }
        }

        protected void imgBtnAddToBasket_Click(object sender, ImageClickEventArgs e)
        {
            int productId = 0;
            int count = 0;

            string strproductId = ((ImageButton)sender).CommandArgument;

            if (int.TryParse(strproductId, out productId) && int.TryParse(ddlProductCount.SelectedValue, out count))
                Shopping.AddToBasket(productId, count);
        }

        protected void imgBtnBuyNow_Click(object sender, ImageClickEventArgs e)
        {
            int productId = 0;
            int count = 0;

            string strproductId = ((ImageButton)sender).CommandArgument;

            if (int.TryParse(strproductId, out productId) && int.TryParse(ddlProductCount.SelectedValue, out count))
                Shopping.AddToBasket(productId, count);
        }
    }
}