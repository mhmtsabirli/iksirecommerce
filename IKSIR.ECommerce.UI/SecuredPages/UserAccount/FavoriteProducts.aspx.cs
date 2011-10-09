using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.SecuredPages.UserAccount
{
    public partial class FavoriteProducts : System.Web.UI.Page
    {
        public User loginUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] == null)
            {
                Response.Redirect("../Login.aspx?returl=" + Request.Url.PathAndQuery);
            }
            if (!Page.IsPostBack)
            {
                loginUser = (User)Session["LOGIN_USER"];
                GetUserFavoriteProducts();
                int favoritproductid = 0;
                if (Page.Request.QueryString["favoritproductid"] != null && Page.Request.QueryString["favoritproductid"] != "" && int.TryParse(Page.Request.QueryString["favoritproductid"], out favoritproductid))
                {
                    var item = ProductData.Get(favoritproductid);
                    if(item != null)
                        AddToFavoriteList(favoritproductid);
                    else
                        divAlert.InnerHtml = "<span style=\"color:Red\">Böyle bir ürün bulunamadı.</span><br />";
                }
            }
        }

        private void GetUserFavoriteProducts()
        {
            loginUser = (User)Session["LOGIN_USER"];
            List<UserFavoriteProduct> userFavoriteProductList = UserFavoriteProductData.GetList(loginUser.Id);
            if (userFavoriteProductList != null && userFavoriteProductList.Count > 0)
            {
                rptUserFavoriteProducts.DataSource = userFavoriteProductList;
                rptUserFavoriteProducts.DataBind();
                lblNoUserFavoriteProducts.Visible = false;
            }
            else
            {
                lblNoUserFavoriteProducts.Visible = true;
            }
        }
     
        private void AddToFavoriteList(int favoritproductid)
        {
            loginUser = (User)Session["LOGIN_USER"];
            UserFavoriteProduct userFavoriteProduct = new UserFavoriteProduct();
            userFavoriteProduct.UserId = loginUser.Id;
            userFavoriteProduct.Product = new Model.ProductModel.Product() { Id = favoritproductid };
            List<UserFavoriteProduct> userFavoriteProductList = UserFavoriteProductData.GetList(loginUser.Id);
            UserFavoriteProduct item = null;
            if (userFavoriteProductList != null)
                item = userFavoriteProductList.Where(x => x.Product.Id == favoritproductid).FirstOrDefault();
            string textForMessage = "";
            if (item != null)
            {
                textForMessage = @"<script language='javascript'> alert('Bu ürün zaten favori ürünleriniz arasında.');</script>";
            }
            else
            {
                int retValue = UserFavoriteProductData.Insert(userFavoriteProduct);
                if (retValue > 0)
                {
                    textForMessage = @"<script language='javascript'> alert('Ürün favori ürünlerinize eklenmiştir.');</script>";
                    GetUserFavoriteProducts();
                }
                else
                {
                    textForMessage = @"<script language='javascript'> alert('Ürün favori ürünlerinize eklenirken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.');</script>";
                }
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
        }
    }
}