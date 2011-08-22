using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.UI.ClassLibrary;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int basketItemCount = 0;
            Shopping.GetBasket(ref basketItemCount);

            if (basketItemCount != 0)
            {
                hplToBasket.Text = "Sepetiniz (" + basketItemCount.ToString() + ")"; ;
                hplToBasket.NavigateUrl = "../Pages/OrderBasket.aspx";
            }
            else
            {
                hplToBasket.Text = "Sepetinizde ürün bulunmamaktadır.";
                hplToBasket.NavigateUrl = "";
            }
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/SearchResult.aspx?searchkey=" + txtSearchText.Text);
        }
    }
}