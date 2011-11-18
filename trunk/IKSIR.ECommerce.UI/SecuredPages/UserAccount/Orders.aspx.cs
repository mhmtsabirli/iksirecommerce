using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.UI.SecuredPages.UserAccount
{
    public partial class Orders : System.Web.UI.Page
    {
        public User loginUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] == null)
            {
                Response.Redirect("../Login.aspx?returl=" + Request.Url.PathAndQuery);
            }
            else
            {
                BindFilterForm();
            }

            loginUser = (User)Session["LOGIN_USER"];

            if (Request.QueryString["oid"] != null && Request.QueryString["oid"].ToString() != null)
            {
                int orderId = 0;
                if (int.TryParse(Page.Request.QueryString["oid"], out orderId))
                {
                    txtOrderNo.Text = orderId.ToString();
                    GetOrderList();
                    GetOrderItem(orderId);
                    dvMyOrder.Visible = true;
                    //ddlPaymentType.Enabled = false;
                }
            }
        }

        private void BindFilterForm()
        {
            ddlFilterOrderStarDateDay.Items.Clear();
            ddlFilterOrderStarDateMonth.Items.Clear();
            ddlFilterOrderStarDateYear.Items.Clear();
            ddlFilterOrderEndDateDay.Items.Clear();
            ddlFilterOrderEndDateMonth.Items.Clear();
            ddlFilterOrderEndDateYear.Items.Clear();

            for (int i = 1; i <= 31; i++)
            {
                ddlFilterOrderStarDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderStarDateDay.Items.Insert(0, new ListItem("Gün", "-1"));
            for (int i = 1; i <= 12; i++)
            {
                ddlFilterOrderStarDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderStarDateMonth.Items.Insert(0, new ListItem("Ay", "-1"));
            for (int i = DateTime.Now.Year; i > 2010; i--)
            {
                ddlFilterOrderStarDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderStarDateYear.Items.Insert(0, new ListItem("Yıl", "-1"));

            for (int i = 1; i <= 31; i++)
            {
                ddlFilterOrderEndDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderEndDateDay.Items.Insert(0, new ListItem("Gün", "-1"));
            for (int i = 1; i <= 12; i++)
            {
                ddlFilterOrderEndDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderEndDateMonth.Items.Insert(0, new ListItem("Ay", "-1"));
            for (int i = DateTime.Now.Year; i > 2010; i--)
            {
                ddlFilterOrderEndDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlFilterOrderEndDateYear.Items.Insert(0, new ListItem("Yıl", "-1"));
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetOrderList();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(CustomerOrderId.Value.ToString()), 0, new EnumValue() { Id = 0 });
            itemOrder.Status = new EnumValue() { Id = 43 };// Silindi durumuna update ediliyor 
            int result = OrderData.Update(itemOrder);
            if (result != 1)
                divAlert.InnerHtml += "<span style=\"color:Green\">Siparişiniz İptal edilmek üzere kayıt edilmiştir. </span><br />";
            else
                divAlert.InnerHtml += "<span style=\"color:Green\">Sipariş güncellemesi sırasında hata oluştu </span><br />";

            dvMyOrder.Visible = false;
            divAlert.Visible = true;
            GetOrderList();
        }

        private void GetOrderList()
        {
            List<Model.Order.Order> itemList = OrderData.GetList(0, loginUser.Id);
            if (txtOrderNo.Text != "")
            {
                int OrderNo = Convert.ToInt32(txtOrderNo.Text);
                itemList = itemList.Where(x => x.Id == OrderNo).ToList();
            }
            else if (ddlFilterOrderStarDateDay.SelectedValue != "-1" && ddlFilterOrderStarDateMonth.SelectedValue != "-1" && ddlFilterOrderStarDateYear.SelectedValue != "-1"
                && ddlFilterOrderEndDateDay.SelectedValue != "-1" && ddlFilterOrderEndDateMonth.SelectedValue != "-1" && ddlFilterOrderEndDateYear.SelectedValue != "-1")
            {
                var startDate = new DateTime(DBHelper.IntValue(ddlFilterOrderStarDateYear.SelectedValue), DBHelper.IntValue(ddlFilterOrderStarDateMonth.SelectedValue), DBHelper.IntValue(ddlFilterOrderStarDateDay.SelectedValue));
                var endDate = new DateTime(DBHelper.IntValue(ddlFilterOrderEndDateYear.SelectedValue), DBHelper.IntValue(ddlFilterOrderEndDateMonth.SelectedValue), DBHelper.IntValue(ddlFilterOrderEndDateDay.SelectedValue));
                itemList = itemList.Where(x => x.CreateDate >= startDate && x.CreateDate <= endDate).ToList();
            }
            else
            {
                if (ddlFilterOrderStatus.SelectedValue == "1")
                {
                    itemList = itemList.Where(x => x.Status.Id != 35).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 38).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 43).ToList();
                }
                else if (ddlFilterOrderStatus.SelectedValue == "2")
                {
                    itemList = itemList.Where(x => x.Status.Id == 35).ToList();
                }
                else if (ddlFilterOrderStatus.SelectedValue == "3")
                {

                    itemList = itemList.Where(x => x.Status.Id != 29).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 32).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 33).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 34).ToList();
                    itemList = itemList.Where(x => x.Status.Id != 35).ToList();
                }
                else
                {

                }
            }
            gvOrderList.DataSource = itemList;
            gvOrderList.DataBind();
        }

        private bool GetOrderItem(int itemId)
        {
            List<Model.Order.Order> itemList = OrderData.GetList(0, loginUser.Id);
            Model.Order.Order itemOrder = itemList.Where(x => x.Id == itemId).FirstOrDefault();
            bool retValue = false;
            if (itemOrder == null)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Aradığınız sipariş bulunamadı.</span><br />";
                return retValue;
            }
            if (GetOrderDetail(itemOrder))
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Ürün bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Ürün bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }

            if (itemOrder.Status.Id == 34 || itemOrder.Status.Id == 35 || itemOrder.Status.Id == 38 || itemOrder.Status.Id == 43)
                btnDelete.Visible = false;
            //if (GetPaymentInfo(itemOrder.PaymetInfo))
            //{
            //    divAlert.InnerHtml += "<span style=\"color:Green\">Müşteri bilgileri başarıyla yüklendi.</span><br />";
            //    retValue = true;
            //}
            //else
            //{
            //    divAlert.InnerHtml += "<span style=\"color:Red\">Ürün Genel bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            //}
            //if (GetBillingInfo(itemOrder.Basket.BillingAddress))
            //{
            //    divAlert.InnerHtml += "<span style=\"color:Green\">Fatura Adresi bilgileri başarıyla yüklendi.</span><br />";
            //    retValue = true;
            //}
            //else
            //{
            //    divAlert.InnerHtml += "<span style=\"color:Red\">Ürün Genel bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            //}
            //lblId.Text = itemOrder.Id.ToString();
            //lbltotalPrice.Text = itemOrder.TotalPrice.ToString();
            //lbltotalRatedPrice.Text = itemOrder.TotalRatedPrice.ToString();
            return retValue;

        }

        private bool GetOrderDetail(Model.Order.Order orderItem)
        {
            bool retValue = true;
            try
            {
                Basket itemBasket = orderItem.Basket;
                lblShippingAddressNameSurName.Text = itemBasket.ShippingAddress.FirstName + " " + orderItem.Basket.ShippingAddress.LastName;
                lblShippingAddressDetail.Text = itemBasket.ShippingAddress.AddressDetail;
                lblShippingAddressPhone.Text = itemBasket.ShippingAddress.Phone;

                lblBillingAddressNameSurname.Text = itemBasket.BillingAddress.FirstName + " " + orderItem.Basket.BillingAddress.LastName;
                lblBillingAddressDetail.Text = itemBasket.BillingAddress.AddressDetail;
                lblBillingAddressPhone.Text = itemBasket.BillingAddress.Phone;

                rptBasketProducts.DataSource = orderItem.Basket.BasketItems;
                rptBasketProducts.DataBind();

                lblShippingCompanyName.Text = itemBasket.ShippingCompany.Title;
                lblShippingPrice.Text = Toolkit.Utility.CurrencyFormat(itemBasket.ShippingCompany.UnitPrice);

                lblBasketTotal.Text = Toolkit.Utility.CurrencyFormat(orderItem.TotalRatedPrice + itemBasket.ShippingCompany.UnitPrice);
                lblTotalTax.Text = Toolkit.Utility.CurrencyFormat(orderItem.TotalRatedPrice - orderItem.TotalPrice);
                lblTotalPrice.Text = Toolkit.Utility.CurrencyFormat(orderItem.TotalPrice);
            }
            catch (Exception)
            {
                retValue = false;
                throw;
            }
            return retValue;
        }

        private bool GetProductInfo(List<BasketItem> list)
        {
            bool IsOk = false;
            try
            {
                //gvBasketItems.DataSource = list;
                //gvBasketItems.DataBind();
                IsOk = true;
            }
            catch
            {
                IsOk = false;
            }
            return IsOk;
        }

        //private bool GetBillingInfo(Address address)
        //{
        //    bool isOk = false;
        //    try
        //    {
        //        string City = address.City.Name.ToString();
        //        string District = address.District.Name.ToString();
        //        string AddressDetail = address.AddressDetail.ToString();
        //        string PostalCode = address.PostalCode.ToString();
        //        lblBillingCity.Text = City;
        //        lblBillingDetail.Text = District;
        //        lblBillingDetail.Text = AddressDetail;
        //        lblBillingPostalCode.Text = PostalCode;

        //        isOk = true;
        //    }
        //    catch
        //    {
        //        isOk = false;
        //    }

        //    return isOk;
        //}

        //private bool GetPaymentInfo(Model.Bank.PaymetInfo paymetInfo)
        //{
        //    bool IsOk = false;
        //    try
        //    {
        //        List<EnumValue> ListPaymentType = EnumValueData.GetEnumValues(21);//Ödeme Tipleri
        //        Utility.BindDropDownList(ddlPaymentType, ListPaymentType, "Value", "Id");
        //        ddlPaymentType.SelectedValue = paymetInfo.PaymentType.Id.ToString();

        //        IsOk = true;
        //    }
        //    catch
        //    {
        //        IsOk = false;
        //    }
        //    return IsOk;
        //}

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var enumValueList = EnumValueData.GetEnumValues(itemId);

            try
            {
                if (AddressData.Delete(itemId) < 0)
                {
                    returnValue = true;
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Kullanıcı Adres sildi";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Kullanıcı adres silerken hata oluştu";
                itemSystemLog.Content = "Id=" + itemId + " Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return returnValue;
        }

        protected void lbtnView_Click(object sender, EventArgs e)
        {
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            //gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);
            CustomerOrderId.Value = itemId.ToString(); ;
            GetOrderItem(itemId);

            dvMyOrder.Visible = true;

            //ddlPaymentType.Enabled = false;
        }

        //protected void lbtnAddress_Click(object sender, EventArgs e)
        //{
        //    var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
        //    //gvList.SelectedIndex = index;
        //    var itemId = (sender as LinkButton).CommandArgument == ""
        //                     ? 0
        //                     : Convert.ToInt32((sender as LinkButton).CommandArgument);

        //    Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });
        //    foreach (BasketItem basketItem in itemOrder.Basket.BasketItems)
        //    {
        //        if (basketItem.Id == itemId)
        //        {
        //            if (basketItem.ShippingAddress.City != null)
        //            {
        //                string City = basketItem.ShippingAddress.City.Name.ToString();
        //                string District = basketItem.ShippingAddress.District.Name.ToString();
        //                string AddressDetail = basketItem.ShippingAddress.AddressDetail.ToString();
        //                string PostalCode = basketItem.ShippingAddress.PostalCode.ToString();
        //                dvAdress.Visible = true;
        //                lblCity.Text = City;
        //                lblDetail.Text = District;
        //                lblDetail.Text = AddressDetail;
        //                lblPostalCode.Text = PostalCode;
        //            }
        //        }
        //    }
        //}
    }
}