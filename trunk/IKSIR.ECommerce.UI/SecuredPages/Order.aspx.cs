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
using IKSIR.ECommerce.Model.Bank;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using System.IO;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class Order : System.Web.UI.Page
    {
        public User loginUser = null;
        public Model.Order.Order orders = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] != null && Session["USER_ORDER"] != null)
            {
                if (!Page.IsPostBack)
                {
                    loginUser = (User)Session["LOGIN_USER"];
                    orders = (Model.Order.Order)HttpContext.Current.Session["USER_ORDER"];
                    GetOrderBasket();
                }
                if (Session["IsSend"] != null && Session["IsSend"] != "")
                {
                    if (Session["IsSend"].ToString() == "0")
                        IsSendMail.Visible = true;
                }
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=../Pages/Default.aspx");
            }

        }
        private void GetOrderBasket()
        {
            loginUser = (User)Session["LOGIN_USER"];
            orders = (Model.Order.Order)HttpContext.Current.Session["USER_ORDER"];
            lblUser.Text = loginUser.FirstName.ToString() + " " + loginUser.LastName.ToString();
            lblOrderNo.Text = orders.Id.ToString();
            rptBasketProducts.DataSource = orders.Basket.BasketItems;
            rptBasketProducts.DataBind();

            lblShippingPrice.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.ShippingCompany.UnitPrice);
            lblBasketTotal.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.TotalRatedPrice + orders.Basket.ShippingCompany.UnitPrice);
            lblTotalTax.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.TotalRatedPrice - orders.Basket.TotalPrice);
            lblTotalPrice.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.TotalPrice);
        }
        protected void rptBasketProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                loginUser = (User)Session["LOGIN_USER"];
                orders = (Model.Order.Order)HttpContext.Current.Session["USER_ORDER"];
                Image imgProduct = e.Item.FindControl("imgProduct") as Image;
                HiddenField hdnProductId = e.Item.FindControl("hdnProductId") as HiddenField;
                DropDownList ddlItemCount = e.Item.FindControl("ddlItemCount") as DropDownList;

                Label lblUnitPrice = e.Item.FindControl("lblUnitPrice") as Label;
                Label lblBasketItemPrice = e.Item.FindControl("lblBasketItemPrice") as Label;

                decimal unitePrice = 0;
                decimal.TryParse(lblUnitPrice.Text, out unitePrice);
                lblUnitPrice.Text = Toolkit.Utility.CurrencyFormat(unitePrice);

                decimal basketItemPrice = 0;
                decimal.TryParse(lblBasketItemPrice.Text, out basketItemPrice);
                lblBasketItemPrice.Text = Toolkit.Utility.CurrencyFormat(basketItemPrice);

                Repeater rptProductProperties = e.Item.FindControl("rptProductProperties") as Repeater;
                int productId;

                if (hdnProductId != null && rptProductProperties != null && hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                {
                    var itemProduct = ProductData.Get(productId);

                    if (itemProduct != null)
                    {
                        for (int i = 1; i <= itemProduct.MaxQuantity; i++)
                        {
                            ddlItemCount.Items.Add(new ListItem(i.ToString(), i.ToString()));
                        }
                    }

                    var product = orders.Basket.BasketItems.Where(x => x.Product.Id == productId).First();

                    if (product != null)
                    {
                        ddlItemCount.SelectedValue = product.Count.ToString();
                    }

                    rptProductProperties.DataSource = ProductPropertyData.GetProductProperties(productId);
                    rptProductProperties.DataBind();
                }
            }
        }
    }
}