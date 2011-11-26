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
            if (Session["3ds"] != null)
            {
                if (Request["ApprovedCode"] == "1")
                {
                    SaveOrder((PaymetInfo)Session["PaymentInfo"]);
                }
                else
                {
                    Response.Redirect("OrderPayment.aspx");
                }
            }
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

            if (orders.Basket.TotalRatedPrice >= 100)
            {
                lblShippingPrice.Text = "0.00";
                lblBasketTotal.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.TotalRatedPrice);
            }
            else
            {
                decimal totaldesi = 0;

                foreach (var item in orders.Basket.BasketItems)
                {
                    if (item.Product.Desi != null && item.Product.Desi != "")
                        totaldesi += item.Count * Convert.ToDecimal(item.Product.Desi);
                }

                lblShippingPrice.Text = Utility.CurrencyFormat(OrderData.CalculateShippingPrice(totaldesi));
                lblBasketTotal.Text = Toolkit.Utility.CurrencyFormat(orders.Basket.TotalRatedPrice + OrderData.CalculateShippingPrice(totaldesi));
            }

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

        private void SaveOrder(PaymetInfo paymetInfo)
        {
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                User loginUser = (User)Session["LOGIN_USER"];
                Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                basket.Status = new Model.CommonModel.EnumValue() { Id = 29 };
                int retValue = 0;
                int basketId = 0;

                int billingAddressId = BasketAddressData.Insert(basket.BillingAddress, basketId, 0);
                int shippingAddressId = BasketAddressData.Insert(basket.ShippingAddress, basketId, 0);

                basket.BillingAddress.Id = billingAddressId;
                basket.ShippingAddress.Id = shippingAddressId;
                basket.ShippingCompany = new Model.ProductModel.Shipment() { Id = basket.ShippingCompany.Id };
                basketId = BasketData.Insert(basket);
                if (basketId > 0)
                    foreach (BasketItem basketItem in basket.BasketItems)
                    {
                        basketItem.Basket = new Basket() { Id = basketId };
                        basketItem.Status = new Model.CommonModel.EnumValue() { Id = 39 };
                        retValue = BasketItemData.Insert(basketItem);
                        if (retValue <= 0)
                        {
                            break;
                        }
                    }
                basket.Id = basketId;



                if (retValue > 0) //itemlar başarıyla kaydedildiyese
                {
                    paymetInfo.Cvc = "";
                    paymetInfo.CreditCardNumber = "";
                    retValue = PaymetInfoData.Insert(paymetInfo);
                }

                if (retValue > 0) //itemlar başarıyla kaydedildiyese
                {
                    IKSIR.ECommerce.Model.Order.Order order = new IKSIR.ECommerce.Model.Order.Order();
                    order.User = loginUser;
                    order.Basket = basket;
                    order.TotalPrice = basket.TotalPrice;
                    order.TotalRatedPrice = basket.TotalRatedPrice;
                    order.ShippingPrice = Convert.ToDecimal(Session["Shipping"].ToString());
                   
                        order.Status = new Model.CommonModel.EnumValue() { Id = 32 };
                    order.PaymetInfo = new PaymetInfo() { Id = retValue };
                    retValue = OrderData.Insert(order);
                    order.Id = retValue;
                    Session.Add("USER_ORDER", order);

                }

                if (retValue > 0)
                {
                    string MailBody = File.ReadAllText(HttpContext.Current.Request.MapPath("~") + "/MailTemplates/OrderResultMail.htm");
                    MailBody = MailBody.Replace("%OrderID%", retValue.ToString());

                    MailBody = MailBody.Replace("%Taxamount%", lblTotalTax.Text);
                    MailBody = MailBody.Replace("%TotalAmount%", lblTotalPrice.Text);
                    MailBody = MailBody.Replace("%ShippingAmount%", lblShippingPrice.Text);
                    MailBody = MailBody.Replace("%TotalOrderAmount%", lblBasketTotal.Text);
                    MailBody = MailBody.Replace("%BillingAddress%", "İl : " + basket.BillingAddress.City != null ? basket.BillingAddress.CityName : basket.BillingAddress.City.Name + " </br>İlçe : " + basket.BillingAddress.District.Name.ToString() +
                        "</br> Adres : " + basket.BillingAddress.AddressDetail.ToString() + "</br>Posta Kodu : " + basket.BillingAddress.PostalCode.ToString());
                    MailBody = MailBody.Replace("%DeliveryAddress%", "İl : " + basket.ShippingAddress.City != null ? basket.ShippingAddress.CityName : basket.ShippingAddress.City.Name + " </br>İlçe : " + basket.ShippingAddress.District.Name.ToString() +
                      "</br> Adres : " + basket.ShippingAddress.AddressDetail.ToString() + "</br>Posta Kodu : " + basket.ShippingAddress.PostalCode.ToString());
                    MailBody = MailBody.Replace("%NameSurname%", loginUser.FirstName.ToString() + " " + loginUser.LastName.ToString());
                    string HtmlProducts = "<table><tr><td>Ürün Adı</td><td>Sayısı</td><td>Fiyatı</td></tr>";
                    foreach (BasketItem basketItem in basket.BasketItems)
                    {
                        HtmlProducts += "<tr>";
                        HtmlProducts += "<td>" + basketItem.Product.Title.ToString() + "</td>";
                        HtmlProducts += "<td>" + basketItem.Count.ToString() + "</td>";
                        HtmlProducts += "<td>" + basketItem.ItemPrice.ToString() + "</td>";
                        HtmlProducts += "</tr>";

                    }
                    HtmlProducts += "</table>";

                    MailBody = MailBody.Replace("%Products%", HtmlProducts);
                    //bool retValueSendMail = Mail.sendMail(loginUser.Email.ToString(), "musterihizmetleri@senarinsaat.com.tr", "Senar İnşaat A.Ş. | Şipariş Bilgileriniz", MailBody);

                    if (false)
                    {
                        
                    }
                    else
                    {
                        Session.Add("IsSend", 0);
                    }
                }
                Session.Remove("USER_BASKET");
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=Default.aspx");
            }
        }
    }
}