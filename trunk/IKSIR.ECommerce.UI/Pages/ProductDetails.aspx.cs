using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using System.Web.UI.HtmlControls;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        int productId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["pid"] != null && Page.Request.QueryString["pid"].ToString() != "" && int.TryParse(Page.Request.QueryString["pid"].ToString(), out productId))
            {
                if (!Page.IsPostBack)
                {
                    GetProductDetails();
                }
            }
            else
            {
                Response.Redirect("/Pages/Default.aspx");
            }
            UCProductDetailsCreditCardAdvantages1.ProductId = productId;
            UCProductDetailDocuments1.ProductId = productId;
            UCProductDetailsProductInfos1.ProductId = productId;
            UCProductDetailsComments1.ProductId = productId;
            UCProductDetailsMain1.ProductId = productId;
            UCProductDetailsRelatedAndSimilarProducts1.ProductId = productId;
        }

        private void GetProductDetails()
        {
            GetNextPreviousButtons();

            var item = ProductData.Get(productId);
            if (item == null)
                return;

            anchorProductCategory.InnerText = item.ProductCategory.Title;
            anchorProductCategory.HRef = "ProductList.aspx?catid=" + item.ProductCategory.Id;

            anchorProduct.InnerText = item.Title;
            anchorProduct.HRef = "ProductDetails.aspx?pid=" + item.Id.ToString();

            HtmlMeta meta = new HtmlMeta();
            meta.Name = "description";
            meta.Content = item.Description;
            this.Page.Header.Controls.Add(meta);

            meta = new HtmlMeta();
            meta.Name = "title";
            meta.Content = item.Title;
            this.Page.Header.Controls.Add(meta);

            HtmlHead head = (HtmlHead)Page.Header;
            HtmlLink link = new HtmlLink();
            link.Attributes.Add("rel", "image_src");

            string hrefValue = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_nopicture.jpg";
            if (item.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault() != null)
            {
                var image = item.Multimedias.Where(x => x.IsDefault == true).FirstOrDefault();
                hrefValue = "http://" + IKSIR.ECommerce.Infrastructure.StaticData.Idevit.ImagePath + "Small/small_" + image.FilePath;
            }
            link.Attributes.Add("href", hrefValue);
            head.Controls.Add(link);
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
    }
}