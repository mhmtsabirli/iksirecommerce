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

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderPayment : System.Web.UI.Page
    {
        public static User loginUser = null;
        public static Basket basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                if (!Page.IsPostBack)
                {
                    loginUser = (User)Session["LOGIN_USER"];
                    basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    GetOrderBasket();
                }
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=../Pages/Default.aspx");
            }

            if (!Page.IsPostBack)
            {
                SaveOrder();
                BindForm();
            }
        }

        private void BindForm()
        {
            List<TransferAccount> itemList = TransferAccountData.GetTransferAccountList();
            rblTransferAccount.DataTextField = "Detail";
            rblTransferAccount.DataValueField = "Id";
            rblTransferAccount.DataSource = itemList;
            rblTransferAccount.DataBind();
        }


        private void GetOrderBasket()
        {
            rptBasketProducts.DataSource = basket.BasketItems;
            rptBasketProducts.DataBind();
        }


        protected void rptBasketProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image imgProduct = e.Item.FindControl("imgProduct") as Image;
                HiddenField hdnProductId = e.Item.FindControl("hdnProductId") as HiddenField;
                DropDownList ddlItemCount = e.Item.FindControl("ddlItemCount") as DropDownList;


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

                    var product = basket.BasketItems.Where(x => x.Product.Id == productId).First();

                    if (product != null)
                    {
                        ddlItemCount.SelectedValue = product.Count.ToString();
                    }

                    rptProductProperties.DataSource = ProductPropertyData.GetProductProperties(productId);
                    rptProductProperties.DataBind();
                }
            }
        }

        private void SaveOrder()
        {
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                User loginUser = (User)Session["LOGIN_USER"];
                Basket basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                basket.Status = new Model.CommonModel.EnumValue() { Id = 29 };
                int retValue = 0;
                int basketId = 0;

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

                if (retValue > 0) //itemlar başarıyla kaydedildiyese
                {
                    PaymetInfo paymetInfo = new Model.Bank.PaymetInfo() { CreditCard = new CreditCard() { Id = 1 }, CreditCardNumber = "123123", Cvc = "345", Month = 12, Year = 2012, PaymentType = new Model.CommonModel.EnumValue() { Id = 37 } };
                    retValue = PaymetInfoData.Insert(paymetInfo);
                }

                if (retValue > 0) //itemlar başarıyla kaydedildiyese
                {
                    Order order = new Order();
                    order.User = loginUser;
                    order.Basket = basket;
                    order.TotalPrice = basket.TotalPrice;
                    order.Status = new Model.CommonModel.EnumValue() { Id = 29 };
                    order.PaymetInfo = new PaymetInfo() { Id = retValue };
                    retValue = OrderData.Insert(order);
                }
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=Default.aspx");
            }
        }
    }
}