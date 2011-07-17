using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int productId = 0;
                if (Page.Request.QueryString["pid"] != null && Page.Request.QueryString["pid"].ToString() != "" && int.TryParse(Page.Request.QueryString["pid"].ToString(), out productId))
                {
                    GetProductDetails(productId);
                    UCProductCreditCardAdvantages1.ProductId = productId;
                    UCProductDetailDocuments1.ProductId = productId;
                    UCProductDetailProductInfos1.ProductId = productId;
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

        private void GetProductDetails(int productId)
        {

        }
    }
}