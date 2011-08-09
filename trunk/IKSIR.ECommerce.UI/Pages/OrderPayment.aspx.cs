using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SaveOrder();
            }
        }

        private void SaveOrder()
        {
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                User loginUser = (User)Session["LOGIN_USER"];
                Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                Order order = new Order();

                order.User = loginUser;
                order.Basket = basket;
                //order.TotalPrice =
                //order.TotalRatedPrice =
                //order.PaymetInfo

                OrderData.Insert(order);
            }
            else
            {
                Response.Redirect("Login.aspx?returl=Default.aspx");
            }
        }
    }
}