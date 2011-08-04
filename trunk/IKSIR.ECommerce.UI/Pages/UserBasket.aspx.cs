﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.UI.ClassLibrary;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class UserBasket : System.Web.UI.Page
    {
        public static User loginUser = null;
        public static Basket userBasket = null;

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
                    userBasket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    GetUserBasket();
                }
            }
            else
            {
                Response.Redirect("Login.aspx?returl=UserBasket.aspx");
            }
        }

        private void GetUserBasket()
        {
            rptBasketProducts.DataSource = userBasket.BasketItems;
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
                Repeater rptProductProperties = e.Item.FindControl("rptProductProperties") as Repeater;
                int productId;

                if (hdnProductId != null && rptProductProperties != null && hdnProductId.Value != "" && int.TryParse(hdnProductId.Value, out productId))
                {
                    rptProductProperties.DataSource = ProductPropertyData.GetProductProperties(productId);
                    rptProductProperties.DataBind();

                    var productPriceData = ProductPriceData.GetByProduct(productId);
                    if (productPriceData != null)
                    {
                        BasketTotal += productPriceData.Price;
                        TotalTax += productPriceData.Price * productPriceData.Tax / 100;
                        TotalPrice += productPriceData.UnitPrice;
                    }
                }
            }
        }

        protected void rptBasketProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.CommandName == "Refresh")
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
            }
        }


    }
}