using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Model.Bank;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;

namespace IKSIR.ECommerce.Management.Order
{
    public partial class WaitingOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCreditCard.Enabled = false;
            ddlMonth.Enabled = false;
            ddlPaymentType.Enabled = false;
            ddlTransferAccount.Enabled = false;

            if (!Page.IsPostBack)
            {
                BindValues();
                GetList();
            }
        }

        private bool GetItem(int itemId)
        {
            Model.Order.Order itemOrder = OrderData.Get(itemId, 0, new EnumValue() { Id = 0 });
            bool retValue = false;

            pnlForm.Visible = true;
            if (GetCustomerInfo(itemOrder.User))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Müşteri bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Müşteri bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            if (GetProductInfo(itemOrder.Basket.BasketItems))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Ürün bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Ürün bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            if (GetPaymentInfo(itemOrder.PaymetInfo))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Müşteri bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Ürün Genel bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            if (GetBillingInfo(itemOrder.Basket.BillingAddress))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Müşteri bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Ürün Genel bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            lbltotalPrice.Text = itemOrder.TotalPrice.ToString();
            lbltotalRatedPrice.Text = itemOrder.TotalRatedPrice.ToString();
            lblId.Text = itemOrder.Id.ToString();
            return retValue;

        }

        private bool GetPaymentInfo(Model.Bank.PaymetInfo paymetInfo)
        {
            bool IsOk = false;
            try
            {
                List<EnumValue> ListPaymentType = EnumValueData.GetEnumValues(21);//Ödeme Tipleri
                Utility.BindDropDownList(ddlPaymentType, ListPaymentType, "Value", "Id");
                ddlPaymentType.SelectedValue = paymetInfo.PaymentType.Id.ToString();
                if (paymetInfo.PaymentType.Id == 36)//havale
                {
                    DvTransferAccount.Visible = true;
                    List<TransferAccount> ListTransferAccount = TransferAccountData.GetTransferAccountList();
                    Utility.BindDropDownList(ddlTransferAccount, ListTransferAccount, "Description", "Id");
                    ddlTransferAccount.SelectedValue = paymetInfo.TransferAccount.Id.ToString();

                }
                else
                {
                    DvCreditCard.Visible = true;
                    List<CreditCard> ListCreditCard = CreditCardData.GetCreditCardList();
                    Utility.BindDropDownList(ddlCreditCard, ListCreditCard, "Name", "Id");

                    ddlCreditCard.SelectedValue = paymetInfo.CreditCard.Id.ToString();
                    lblBank.Text = paymetInfo.CreditCard.Bank.Name.ToString();
                    
                    List<PaymetTermRate> ListRates = PaymetTermRateData.GetPaymetTermRateList(paymetInfo.CreditCard.Id);
                    Utility.BindDropDownList(ddlMonth, ListRates, "Month", "Month");
                    ddlMonth.SelectedValue = paymetInfo.SelectedTerm.ToString();
                    lblRate.Text = paymetInfo.Rate.ToString();
                    lblCardName.Text = paymetInfo.Name.ToString();
                    lblCardNumber.Text = paymetInfo.CreditCardNumber.ToString();
                    lblExDate.Text = paymetInfo.Month.ToString() + "/" + paymetInfo.Year.ToString();
                    lblCvv.Text = paymetInfo.Cvc.ToString();
                }
                IsOk = true;
            }
            catch
            {
                IsOk = false;
            }
            return IsOk;
        }

        private bool GetProductInfo(List<BasketItem> list)
        {
            bool IsOk = false;
            try
            {
                gvBasketItems.DataSource = list;
                gvBasketItems.DataBind();
                IsOk = true;
            }
            catch
            {
                IsOk = false;
            }
            return IsOk;
        }

        private bool GetCustomerInfo(Model.MembershipModel.User user)
        {
            bool IsOk = false;
            try
            {
                lblUserId.Text = user.Id.ToString();
                lblFirstName.Text = user.FirstName.ToString();
                lblLastName.Text = user.LastName.ToString();
                lblTcIdentity.Text = user.TcId.ToString();
                lblMobilePhone.Text = user.MobilePhone.ToString();
                IsOk = true;
            }
            catch
            {
                IsOk = false;
            }
            return IsOk;
        }

        private bool GetBillingInfo(Address address)
        {
            bool isOk = false;
            try
            {
                string City = address.City.Name.ToString();
                string District = address.District.Name.ToString();
                string AddressDetail = address.AddressDetail.ToString();
                string PostalCode = address.PostalCode.ToString();
                lblBillingCity.Text = City;
                lblBillingDetail.Text = District;
                lblBillingDetail.Text = AddressDetail;
                lblBillingPostalCode.Text = PostalCode;

                isOk = true;
            }
            catch
            {
                isOk = false;
            }

            return isOk;
        }

        private void GetList()
        {
            List<Model.Order.Order> itemList = OrderData.GetList(Convert.ToInt32(ddlFilterOrderStatus.SelectedValue));

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });

            if (StockControl(itemOrder.Basket.BasketItems))
            {
                if (Payment(itemOrder))
                {
                    //Mail Gönderilecek =>Tayfun

                    //OrderStatus Update ediliyor
                    itemOrder.Status = new EnumValue() { Id = 32 };// Ödeme alındı durumuna update ediliyor
                    int result = OrderData.Update(itemOrder);
                    if (result == 1)
                        divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Durumu güncellenemedi</span><br />";

                    //Stok Güncelleniyor
                    StokProcess(itemOrder.Basket.BasketItems);

                    ClearForm();
                    pnlForm.Visible = false;

                    divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Ödeme Onayı alındı durumuna gelmiştir</span><br />";
                }

            }
            GetList();
        }

        private void StokProcess(List<BasketItem> list)
        {
            bool isOk = true;
            foreach (BasketItem basketItem in list)
            {
                Product product = ProductData.Get(basketItem.Product.Id);
                try
                {
                    product.Stok = product.Stok - basketItem.Count;
                    int result = ProductData.Update(product);
                    if (result != 1)
                        isOk = true;
                }
                catch
                {
                    divAlert.InnerHtml += "<span style=\"color:Red\"" + product.ProductCode.ToString() + "Kodlu ürün stok güncellemesinde sorun çıktı kontrol ediniz</span><br />";
                    isOk = false;
                }
            }

        }
        private bool Payment(Model.Order.Order itemOrder)
        {
            if (itemOrder.PaymetInfo.PaymentType.Id == 36)//havale
            {
                return true;
            }
            else
            {
                return true;
                string term = "";
                ePayment.cc5payment mycc5pay = new ePayment.cc5payment();
                mycc5pay.clientid = itemOrder.PaymetInfo.CreditCard.VposId.ToString();
                mycc5pay.name = itemOrder.PaymetInfo.CreditCard.VposName.ToString();
                mycc5pay.password = itemOrder.PaymetInfo.CreditCard.VposPassword.ToString();
                mycc5pay.oid = lblId.Text;
                mycc5pay.host = itemOrder.PaymetInfo.CreditCard.VposHost.ToString();
                mycc5pay.ip = HttpContext.Current.Request.ServerVariables["Remote_Addr"];//"127.0.0.7";// Request.UserHostAddress;

                mycc5pay.bname = lblId.Text;
                divAlert.InnerHtml = NoTurkishChar(lblCardName.Text).ToLower() + "<br>";
                mycc5pay.orderresult = 0;
                mycc5pay.chargetype = "Auth";
                mycc5pay.cardnumber = lblCardNumber.Text;
                string[] date = lblExDate.ToString().Split('/');
                mycc5pay.expmonth = date[0].ToString();
                mycc5pay.expyear = date[1].ToString();
                mycc5pay.cv2 = lblCvv.Text;
                mycc5pay.subtotal = lbltotalRatedPrice.Text;
                mycc5pay.userid = itemOrder.PaymetInfo.CreditCard.VposUser.ToString();
                mycc5pay.currency = "949";//TL
                if (ddlMonth.SelectedValue == "1")
                    term = "";
                else
                    term = ddlMonth.SelectedValue;

                mycc5pay.taksit = term;
                divAlert.InnerHtml = mycc5pay.processorder();

                if (mycc5pay.appr == "Approved")
                {
                    divAlert.InnerHtml += "Para çekildi.";
                    return true;
                }

                else
                {
                    divAlert.InnerHtml += "<span style=\"color:Red\">";
                    divAlert.InnerHtml += "<br>HataMesaji:" + mycc5pay.errmsg;
                    divAlert.InnerHtml += "<br>OrderId:" + mycc5pay.oid;
                    divAlert.InnerHtml += "<br>ApprovalKodu:" + mycc5pay.appr;
                    divAlert.InnerHtml += "</span><br />";
                    return false;
                }
            }
        }
        private string NoTurkishChar(string str)
        {
            str = str.Replace("ı", "i");
            str = str.Replace("ç", "c");
            str = str.Replace("ö", "o");
            str = str.Replace("ş", "s");
            str = str.Replace("ğ", "g");
            str = str.Replace("ü", "u");
            str = str.Replace("Ç", "c");
            str = str.Replace("Ş", "s");
            str = str.Replace("İ", "i");
            str = str.Replace("Ö", "o");
            str = str.Replace("Ğ", "g");
            str = str.Replace("Ü", "u");
            return str;
        }
        private bool StockControl(List<BasketItem> list)
        {
            bool isOk = true;
            foreach (BasketItem basketItem in list)
            {
                Product product = ProductData.Get(basketItem.Product.Id);
                if (product.Stok < basketItem.Count)
                {
                    divAlert.InnerHtml += "<span style=\"color:Red\">" + product.ProductCode.ToString() + "Kodlu ürün stok yetmemektedir. Lütfen Kontrol Ediniz</span><br />";
                    isOk = false;
                }
            }
            return isOk;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });
            itemOrder.Status = new EnumValue() { Id = 38 };// Silindi durumuna update ediliyor 
            int result = OrderData.Update(itemOrder);
            if (result != 1)
                divAlert.InnerHtml += "<span style=\"color:Green\">Sipariş Silindi durumuna alınmıştır </span><br />";
            else
                divAlert.InnerHtml += "<span style=\"color:Green\">Sipariş güncellemesi sırasında hata oluştu </span><br />";

            ClearForm();
            pnlForm.Visible = false;

            GetList();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = false;
            pnlList.Visible = true;
            pnlFilter.Visible = true;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            btnApprove.CommandArgument = itemId.ToString();
            lblId.Text = itemId.ToString();
            GetItem(itemId);

        }

        protected void lbtnAddress_Click(object sender, EventArgs e)
        {
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });
            foreach (BasketItem basketItem in itemOrder.Basket.BasketItems)
            {
                if (basketItem.Id == itemId)
                {
                    if (basketItem.ShippingAddress.City != null)
                    {
                        string City = basketItem.ShippingAddress.City.Name.ToString();
                        string District = basketItem.ShippingAddress.District.Name.ToString();
                        string AddressDetail = basketItem.ShippingAddress.AddressDetail.ToString();
                        string PostalCode = basketItem.ShippingAddress.PostalCode.ToString();
                        dvAdress.Visible = true;
                        lblCity.Text = City;
                        lblDetail.Text = District;
                        lblDetail.Text = AddressDetail;
                        lblPostalCode.Text = PostalCode;
                    }
                }
            }
        }

        protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPaymentType.SelectedValue == "36") // havale
            {
                DvTransferAccount.Visible = true;
                DvCreditCard.Visible = false;
            }
            else
            {
                DvTransferAccount.Visible = false;
                DvCreditCard.Visible = true;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            List<EnumValue> itemListOrderStatus = EnumValueData.GetEnumValues(20);
            Utility.BindDropDownList(ddlFilterOrderStatus, itemListOrderStatus, "Value", "Id");
        }

        private void ClearForm()
        {

        }


    }
}