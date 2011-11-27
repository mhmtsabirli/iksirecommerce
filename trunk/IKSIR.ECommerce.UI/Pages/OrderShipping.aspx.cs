using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderShipping : System.Web.UI.Page
    {
        public User loginUser = null;
        public Basket basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                if (!Page.IsPostBack)
                {
                    loginUser = (User)Session["LOGIN_USER"];
                    basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    GetShippingCompanies();
                }
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=../Pages/OrderShipping.aspx");
            }
        }

        private void GetShippingCompanies()
        {
            decimal totaldesi = 0;

            foreach (var item in basket.BasketItems)
            {
                if (item.Product.Desi != null && item.Product.Desi != "")
                    totaldesi += item.Count * Convert.ToDecimal(item.Product.Desi);
            }

            List<Shipment> itemList = ShipmentData.GetShipmentList(totaldesi);

            if (basket.TotalRatedPrice >= 100)
            {
                foreach (Shipment item in itemList)
                {
                    item.Detail = item.Title + " / <span style=\"color:red;\">Ücretsiz</span>";
                }
            }
            else
            {
                foreach (Shipment item in itemList)
                {
                    item.Detail = item.Title + " / " + Utility.CurrencyFormat(item.UnitPrice) + " TL";
                }
            }
            rblShippingCompanies.DataTextField = "Detail";
            rblShippingCompanies.DataValueField = "Id";
            rblShippingCompanies.DataSource = itemList;
            rblShippingCompanies.DataBind();
        }

        protected void imgbtnContinue_Click(object sender, ImageClickEventArgs e)
        {
            loginUser = (User)Session["LOGIN_USER"];
            basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
            if (rblShippingCompanies.SelectedIndex == -1)
            {
                string textForMessage = @"<script language='javascript'> alert('Bir kargo firması seçiniz!');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
            else
            {
                basket.ShippingCompany = ShipmentData.Get(Convert.ToInt32(rblShippingCompanies.SelectedValue));
                Session.Add("USER_BASKET", basket);
                Response.Redirect("../SecuredPages/OrderPayment.aspx");
            }
        }

        protected void imgbtnBackToAddress_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Pages/OrderAddress.aspx");
        }
    }
}