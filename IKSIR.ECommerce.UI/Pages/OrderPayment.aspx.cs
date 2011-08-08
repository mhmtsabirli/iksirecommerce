using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetShippingCompanies();
            }


            //if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            //{
            //    if (!Page.IsPostBack)
            //    {
            //        loginUser = (User)Session["LOGIN_USER"];
            //        basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
            //        GetUserAddresses();
            //    }
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx?returl=OrderBasket.aspx");
            //}
        }

        private void GetShippingCompanies()
        {
            List<IKSIR.ECommerce.Model.ProductModel.Shipment> itemList = ShipmentData.GetShipmentList();
            rblShippingCompanies.DataTextField = "Title";
            rblShippingCompanies.DataValueField = "Id";
            rblShippingCompanies.DataSource = itemList;
            rblShippingCompanies.DataBind();
        }
    }
}