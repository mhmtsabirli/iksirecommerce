using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.UI.ClassLibrary;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderBasket : System.Web.UI.Page
    {
        public static User loginUser = null;
        public static Basket basket = null;

        public decimal BasketTotal = 0;
        public decimal TotalTax = 0;
        public decimal TotalPrice = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Kullanıcı login değilse sayfaya giremez.
            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                if (!Page.IsPostBack)
                {
                    loginUser = (User)Session["LOGIN_USER"];
                    basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    if (basket.BasketItems.Count == 0)
                    {
                        cbxComfirmation.Visible = false;
                        rptBasketProducts.Visible = false;
                        hplNoItem.Visible = true;
                        divBasketTotal.Visible = false;
                        anchorConfirmation.Visible = false;
                        divBasketButtons.Visible = false;
                    }
                    else
                    {
                        cbxComfirmation.Visible = true;
                        rptBasketProducts.Visible = true;
                        hplNoItem.Visible = false;
                        divBasketTotal.Visible = true;
                        anchorConfirmation.Visible = true;
                        divBasketButtons.Visible = true;
                        GetOrderBasket();
                    }
                    var item = StaticPageData.Get(10);
                    if (item != null)
                        divRules.InnerHtml = item.PageContent;
                }
            }
            else
            {
                Response.Redirect("Login.aspx?returl=Default.aspx");
            }
        }

        private void GetOrderBasket()
        {
            rptBasketProducts.DataSource = basket.BasketItems;
            rptBasketProducts.DataBind();

            lblBasketTotal.Text = BasketTotal.ToString();
            lblTotalTax.Text = TotalTax.ToString();
            lblTotalPrice.Text = TotalPrice.ToString();
        }

        protected void rptBasketProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Image imgProduct = e.Item.FindControl("imgProduct") as Image;
                HiddenField hdnProductId = e.Item.FindControl("hdnProductId") as HiddenField;
                TextBox txtItemCount = e.Item.FindControl("txtItemCount") as TextBox;
                int count = Convert.ToInt32(txtItemCount.Text);

                Repeater rptProductProperties = e.Item.FindControl("rptProductProperties") as Repeater;
                int productId;

                if (hdnProductId != null && rptProductProperties != null && hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                {
                    rptProductProperties.DataSource = ProductPropertyData.GetProductProperties(productId);
                    rptProductProperties.DataBind();

                    var productPriceData = ProductPriceData.GetByProduct(productId);
                    if (productPriceData != null)
                    {
                        BasketTotal += count * productPriceData.Price;
                        TotalTax += count * productPriceData.Price * productPriceData.Tax / 100;
                        TotalPrice += count * productPriceData.UnitPrice;
                    }
                }
            }
        }

        protected void rptBasketProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Update")
                {
                    int productId;
                    int productCount;
                    ImageButton imgbtnRefreshItemCount = (ImageButton)e.Item.FindControl("imgbtnRefreshItemCount");
                    TextBox txtItemCount = (TextBox)e.Item.FindControl("txtItemCount");
                    if (imgbtnRefreshItemCount != null && txtItemCount != null && imgbtnRefreshItemCount.CommandArgument != null && int.TryParse(imgbtnRefreshItemCount.CommandArgument, out productId) && int.TryParse(txtItemCount.Text, out productCount))
                    {
                        Shopping.AddToBasket(productId, productCount);
                    }
                }

                if (e.CommandName == "Delete")
                {
                    int productId;
                    ImageButton imgbtnDeleteItem = (ImageButton)e.Item.FindControl("imgbtnDeleteItem");
                    if (imgbtnDeleteItem != null && imgbtnDeleteItem.CommandArgument != null && int.TryParse(imgbtnDeleteItem.CommandArgument, out productId))
                    {
                        Shopping.RemoveBasketItem(productId);
                    }
                }
                GetOrderBasket();
            }
        }

        protected void imgbtnContinue_Click(object sender, ImageClickEventArgs e)
        {
            if (basket.BasketItems.Count == 0)
            {
                string textForMessage = @"<script language='javascript'> alert('Sepetinizde hiç ürün bulunmamaktadır. Devam etmek için sepetinize ürün ekleyiniz.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                return;
            }

            if (cbxComfirmation.Checked)
            {
                basket.TotalPrice = TotalPrice;
                Session.Add("USER_BASKET", basket);
                Response.Redirect("OrderAddress.aspx");
            }
            else
            {
                string textForMessage = @"<script language='javascript'> alert('Genel kurallar ve koşulları kabul ediniz!');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
        }

        protected void dlBasketProducts_ItemDataBound(object sender, DataListItemEventArgs e)
        {

        }

        protected void dlBasketProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {

        }

        protected void Update(object sender, CommandEventArgs e)
        {

        }
    }
}