using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.UI.ClassLibrary;
using Telerik.Web.UI;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.MembershipModel;
namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsMain : UCProductDetailsMaster
    {
        public static User loginUser = null;
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

                if (itemMainImage != null)
                {
                    //imgMainImage.ImageUrl = 
                    //anchorBigImage.HRef = "http://banyom.com.tr/documents/Orginal/Images/" + itemMainImage.FilePath;
                    imgBig.Src = "http://banyom.com.tr/documents/Images/Big/big_" + itemMainImage.FilePath;
                }
                else
                {
                    //anchorBigImage.HRef = "#";
                    imgBig.Src = "";
                }

                RadRating.Value = ProductRateData.GetProductRate(productId);
                int imageCount = 0;
                foreach (var item in productMultimedias)
                {
                    imageCount += 1;
                    divSmallImages.InnerHtml += "<a href=\"#\" rel=\"" + item.FilePath + "\" class=\"image\">";
                    divSmallImages.InnerHtml += "<img src=\"http://banyom.com.tr/documents/Images/Icon/icon_" + item.FilePath + "\" class=\"thumb\" border=\"0\" /></a>";

                    if (imageCount == 3)
                        break;
                }

                if (product.Video != null && product.Video != "")
                {
                    divSmallImages.InnerHtml += "<a href=\"#\"><img src=\"../images/urun_video.jpg\" alt=\"Ürün videosunu izlemek için tıklayınız.\" /></a>";
                }
                //container.InnerHtml = otherImages;
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

        protected void RadRating_Rate(object sender, EventArgs e)
        {
            loginUser = (User)Session["LOGIN_USER"];
            if (loginUser != null)
            {
                var itemList = ProductRateData.GetList(productId);
                ProductRate retItem = null;
                if (itemList != null)
                    retItem = itemList.Where(x => x.UserId == loginUser.Id && x.Product.Id == productId).FirstOrDefault();
                if (retItem != null)
                {
                    string textForMessage = @"<script language='javascript'> alert('Bu ürüne daha önce oy kullanmışsınız.');</script>";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                }
                else
                {
                    RadRating rating = (RadRating)sender;
                    var item = new ProductRate();
                    item.Product = new Product() { Id = productId };
                    item.UserId = loginUser.Id;
                    item.Rate = Convert.ToInt32(rating.Value);
                    var retValue = ProductRateData.Insert(item);

                    if (retValue > 0)
                    {
                        string textForMessage = @"<script language='javascript'> alert('Oyunuz alınmıştır. Teşekkür ederiz.');</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                    }
                    else
                    {
                        string textForMessage = @"<script language='javascript'> alert('Oyunuz alınırken bir hata oluştur. Lütfen daha sonra tekrar deneyiniz.');</script>";
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                    }
                }
            }
            else
            {
                string textForMessage = @"<script language='javascript'> alert('Oy vermek için üye girişi yapmanız gerekmektedir.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
            RadRating.Value = ProductRateData.GetProductRate(productId);
        }

        protected void lbtnAddToFavorite_Click(object sender, EventArgs e)
        {
            loginUser = (User)Session["LOGIN_USER"];
            if (loginUser != null)
            {
                List<UserFavoriteProduct> userFavoriteProductList = UserFavoriteProductData.GetList(loginUser.Id);
                var item = userFavoriteProductList.Where(x => x.Product.Id == productId).FirstOrDefault();

                if (item != null)
                {
                    string textForMessage = @"<script language='javascript'> alert('Bu ürün zaten favori ürünleriniz arasında.');</script>";
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                }
                else
                {
                    Response.Redirect("../SecuredPages/MyAccount.aspx?favoritproductid=" + productId.ToString());
                }
            }
            else
            {
                string textForMessage = @"<script language='javascript'> alert('Favorilerinize eklemek için üye girişi yapmanız gerekmektedir.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
        }
    }
}