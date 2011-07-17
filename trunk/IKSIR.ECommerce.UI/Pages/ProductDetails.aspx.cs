using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        int productId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.Request.QueryString["pid"] != null && Page.Request.QueryString["pid"].ToString() != "" && int.TryParse(Page.Request.QueryString["pid"].ToString(), out productId))
                {
                    GetProductDetails();
                    UCProductDetailsCreditCardAdvantages1.ProductId = productId;
                    UCProductDetailDocuments1.ProductId = productId;
                    UCProductDetailsProductInfos1.ProductId = productId;
                    UCProductDetailsComments1.ProductId = productId;
                    UCProductDetailsMain1.ProductId = productId;
                    UCProductDetailsRelatedProducts1.ProductId = productId;
                    UCProductDetailsSimilarProducts1.ProductId = productId;
                }
                else
                {
                    Response.Redirect("pages/Default.aspx");
                }
            }
        }

        private void GetProductDetails()
        {
            GetNextPreviousButtons();
        }

        private void GetNextPreviousButtons()
        {
            hplPreviousProduct.Visible = false;
            hplNextProduct.Visible = false;
            int moduleId = 0;
            int categoryId = 0;
            if (Page.Request.QueryString["modid"] != null && Page.Request.QueryString["modid"].ToString() != "" && int.TryParse(Page.Request.QueryString["modid"].ToString(), out moduleId))
            {
                //Eğer ModülId boş değilse o modüle ait diğer ürün linkini ver.
                List<Product> list = ModuleProductData.GetModuleProductList(moduleId);

                var item = list.Where(x => x.Id < productId).First();
                if (item != null)
                {
                    hplPreviousProduct.NavigateUrl = "/ProductDetails.aspx?pid=" + item.Id.ToString();
                    hplPreviousProduct.Visible = true;
                }

                item = list.Where(x => x.Id > productId).First();
                if (item != null)
                {
                    hplNextProduct.NavigateUrl = "/ProductDetails.aspx?pid=" + item.Id.ToString();
                    hplNextProduct.Visible = true;
                }
            }
            else if (Page.Request.QueryString["catid"] != null && Page.Request.QueryString["catid"].ToString() != "" && int.TryParse(Page.Request.QueryString["catid"].ToString(), out categoryId))
            {
                //Eğer CategoryId boş değilse o kategoriye ait diğer ürün linkini ver.
                List<Product> list = ProductCategoryData.GetProductCategoryList(categoryId);

                var item = list.Where(x => x.Id < productId).First();
                if (item != null)
                {
                    hplPreviousProduct.NavigateUrl = "/ProductDetails.aspx?pid=" + item.Id.ToString();
                    hplPreviousProduct.Visible = true;
                }

                item = list.Where(x => x.Id > productId).First();
                if (item != null)
                {
                    hplNextProduct.NavigateUrl = "/ProductDetails.aspx?pid=" + item.Id.ToString();
                    hplNextProduct.Visible = true;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}