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
using System.IO;

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

            formControl(itemOrder);

            txtInvoiceNo.Text = itemOrder.InvoiceNo.ToString();
            txtShipmentNo.Text = itemOrder.ShippmentNo.ToString();
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
            if (GetShippingInfo(itemOrder.Basket.ShippingAddress))
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

        private bool GetShippingInfo(Address address)
        {
            bool isOk = false;
            try
            {
                if (address != null)
                {
                    string City="";
                    if (address.City.Name != null)
                        City = address.City.Name.ToString();
                    else
                        City = address.CityName.ToString();
                    string District = "";
                    if (address.District.Name != null)
                        District = address.District.Name.ToString();
                    else
                        District = address.DistrictName.ToString();

                    string AddressDetail = address.AddressDetail.ToString();
                    string PostalCode = address.PostalCode.ToString();

                    lblCity.Text = City;
                    lblDistrict.Text = District;
                    lblDetail.Text = AddressDetail;
                    lblPostalCode.Text = PostalCode;
                }
                isOk = true;
            }
            catch
            {
                isOk = false;
            }

            return isOk;
        }

        private void formControl(Model.Order.Order itemOrder)
        {
            txtShipmentNo.Enabled = false;
            txtInvoiceNo.Enabled = false;
            btnApprove.Visible = false;
            btnInvoice.Visible = false;
            btnShipment.Visible = false;
            btnOrderApprove.Visible = false;
            if (itemOrder.Status.Id == 29)
            {
                btnApprove.Visible = true;
            }
            else if (itemOrder.Status.Id == 32)
            {
                txtInvoiceNo.Enabled = true;
                btnInvoice.Visible = true;
            }
            else if (itemOrder.Status.Id == 33)
            {
                txtShipmentNo.Enabled = true;
                btnShipment.Visible = true;
            }
            else if (itemOrder.Status.Id == 34)
            {
                btnOrderApprove.Visible = true;
            }
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
                lblEmail.Text = user.Email.ToString();
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
                string City="";
                if (address.City.Name != null)
                    City = address.City.Name.ToString();
                else
                    City = address.CityName.ToString();
                string District = "";
                if (address.District.Name != null)
                    District = address.District.Name.ToString();
                else
                    District = address.DistrictName.ToString();

                string AddressDetail = address.AddressDetail.ToString();
                string PostalCode = address.PostalCode.ToString();
                lblBillingCity.Text = City;
                lblBillingDistrict.Text = District;
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



            //OrderStatus Update ediliyor
            itemOrder.Status = new EnumValue() { Id = 32 };// Ödeme alındı durumuna update ediliyor
            int result = OrderData.Update(itemOrder);
            if (result == 1)
                divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Durumu güncellenemedi</span><br />";

            //Stok Güncelleniyor
            ClearForm();
            pnlForm.Visible = false;

            divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Ödeme Onayı alındı durumuna gelmiştir</span><br />";
            GetList();
        }
        protected void btnInvoice_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });

            //Mail Gönderilecek =>Tayfun

            //OrderStatus Update ediliyor
            itemOrder.Status = new EnumValue() { Id = 33 };// faturlandı durumuna update ediliyor
            itemOrder.ShippmentNo = txtShipmentNo.Text;
            itemOrder.InvoiceNo = txtInvoiceNo.Text;
            int result = OrderData.Update(itemOrder);
            if (result == 1)
                divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Durumu güncellenemedi</span><br />";

            //Stok Güncelleniyor
            StokProcess(itemOrder.Basket.BasketItems);

            SendMail(itemOrder);
            ClearForm();
            pnlForm.Visible = false;

            divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş faturalandı durumuna gelmiştir</span><br />";
            GetList();
        }
        protected void btnShipment_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });


            //OrderStatus Update ediliyor
            itemOrder.Status = new EnumValue() { Id = 34 };// faturlandı durumuna update ediliyor
            itemOrder.ShippmentNo = txtShipmentNo.Text;
            itemOrder.InvoiceNo = txtInvoiceNo.Text;
            int result = OrderData.Update(itemOrder);
            if (result == 1)
                divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Durumu güncellenemedi</span><br />";

            ClearForm();
            pnlForm.Visible = false;

            SendMail(itemOrder);
            divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş kargoya verildi durumuna gelmiştir</span><br />";
            GetList();
        }
        protected void btnOrderApprove_Click(object sender, EventArgs e)
        {
            Model.Order.Order itemOrder = OrderData.Get(Convert.ToInt32(lblId.Text), 0, new EnumValue() { Id = 0 });


            //Mail Gönderilecek =>Tayfun

            //OrderStatus Update ediliyor
            itemOrder.Status = new EnumValue() { Id = 35 };// faturlandı durumuna update ediliyor
            int result = OrderData.Update(itemOrder);
            if (result == 1)
                divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş Durumu güncellenemedi</span><br />";

            ClearForm();
            pnlForm.Visible = false;

            divAlert.InnerHtml += "<span style=\"color:Red\">Sipariş tamamlandı durumuna gelmiştir</span><br />";
            GetList();
        }

        private void SendMail(Model.Order.Order itemOrder)
        {
            string MailBody = File.ReadAllText(HttpContext.Current.Request.MapPath("~") + "/MailTemplates/OrderResultMail.htm");
            MailBody = MailBody.Replace("%OrderID%", itemOrder.Id.ToString());

            MailBody = MailBody.Replace("%Taxamount%", Convert.ToString((itemOrder.TotalRatedPrice) - (itemOrder.TotalPrice)));
            MailBody = MailBody.Replace("%TotalAmount%", itemOrder.TotalPrice.ToString());
            MailBody = MailBody.Replace("%ShippingAmount%", itemOrder.ShippingPrice.ToString());
            MailBody = MailBody.Replace("%TotalOrderAmount%", itemOrder.TotalRatedPrice.ToString());
            MailBody = MailBody.Replace("%BillingAddress%", "İl : " + itemOrder.Basket.BillingAddress.City.Name.ToString() + " </br>İlçe : " + itemOrder.Basket.BillingAddress.District.Name.ToString() +
                "</br> Adres : " + itemOrder.Basket.BillingAddress.AddressDetail.ToString() + "</br>Posta Kodu : " + itemOrder.Basket.BillingAddress.PostalCode.ToString());
            MailBody = MailBody.Replace("%DeliveryAddress%", "İl : " + itemOrder.Basket.ShippingAddress.City.Name.ToString() + " </br>İlçe : " + itemOrder.Basket.ShippingAddress.District.Name.ToString() +
              "</br> Adres : " + itemOrder.Basket.ShippingAddress.AddressDetail.ToString() + "</br>Posta Kodu : " + itemOrder.Basket.ShippingAddress.PostalCode.ToString());
            MailBody = MailBody.Replace("%NameSurname%", itemOrder.User.FirstName.ToString() + " " + itemOrder.User.LastName.ToString());
            string HtmlProducts = "<table><tr><td>Ürün Adı</td><td>Sayısı</td><td>Fiyatı</td></tr>";
            foreach (BasketItem basketItem in itemOrder.Basket.BasketItems)
            {
                HtmlProducts += "<tr>";
                HtmlProducts += "<td>" + basketItem.Product.Title.ToString() + "</td>";
                HtmlProducts += "<td>" + basketItem.Count.ToString() + "</td>";
                HtmlProducts += "<td>" + basketItem.ItemPrice.ToString() + "</td>";
                HtmlProducts += "</tr>";

            }
            HtmlProducts += "</table>";

            MailBody = MailBody.Replace("%Products%", HtmlProducts);

            if (itemOrder.Status.Id == 33)
                MailBody = MailBody.Replace("%Detail%", "Faturalandırılmış olup Kargoya verildiğinde tarafınıza bilgi verilecektir.");
            if (itemOrder.Status.Id == 34)
                MailBody = MailBody.Replace("%Detail%", "Kargoya verilmiş olup kargo numaranız :" + itemOrder.ShippmentNo.ToString() + " 'dır. Kargo takibini sitemiz üzerinden veya kargo numarası ile kargo firması üzerinden yapabilirsiniz ");

            bool retValueSendMail = Mail.sendMail(itemOrder.User.Email.ToString(), "musterihizmetleri@senarinsaat.com.tr", "Senar İnşaat A.Ş. | Şipariş Bilgileriniz", MailBody);

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