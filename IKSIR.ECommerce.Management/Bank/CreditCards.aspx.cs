using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Management.Common;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.Bank;

namespace IKSIR.ECommerce.Management.Bank
{
    public partial class CreditCards : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CardImage.ImageUrl == "")
                CardImage.Visible = false;
            else
                CardImage.Visible = true;
            if (!Page.IsPostBack)
            {
                BindValues();
                GetList();
            }
        }

        private bool GetItem(int itemId)
        {
            bool retValue = false;
            pnlForm.Visible = true;

            if (GetCreditCardMain(itemId))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Kredi Kart bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Ürün Fiyat bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            CardImage.Visible = true;
            return retValue;
        }
        private void GetList()
        {

            List<CreditCard> itemList = CreditCardData.GetCreditCardList();

            if (txtFilterName.Text != "")
            {
                string Name = txtFilterName.Text;
                itemList = itemList.Where(x => x.Name == Name).ToList();
            }

            gvList.DataSource = itemList;
            gvList.DataBind();
            ClearForm();
            pnlForm.Visible = false;

        }
        private bool InsertItem()
        {
            bool retValue = false;
            int CreditCardId = InsertCreditCard();

            if (CreditCardId > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Kredi Kartı başarıyla kaydedildi.</span><br />";

                retValue = true;
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">CreditCardId kaydedilirken hatalar oluştu lütfen daha sonra tekrar deneyiniz.</span><br />";
            }

            if (SavePaymentTermRate(CreditCardId))
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Vade Oranı başarıyla kaydedildi.</span><br />";
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Vade Oranı kaydedilirken hatalar oluştu lütfen daha sonra tekrar deneyiniz.</span><br />";
            }

            return retValue;
        }
        private bool UpdateItem(int CreditCardId)
        {
            bool retValue = false;

            if (UpdateCreditCardMain(CreditCardId))
                retValue = true;
            return retValue;
        }
        private void BindValues()
        {

            List<IKSIR.ECommerce.Model.Bank.Bank> itemBank = BankData.GetBankList();
            Utility.BindDropDownList(ddlBanks, itemBank, "Name", "Id");
            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();

            List<EnumValue> itemCreditCardStatus = EnumValueData.GetEnumValues(19);
            Utility.BindDropDownList(ddlCreditCardStatus, itemCreditCardStatus, "Value", "Id");

            List<EnumValue> itemRateStatus = EnumValueData.GetEnumValues(18);
            Utility.BindDropDownList(ddlRate, itemRateStatus, "Value", "Id");

        }
        private void ClearForm()
        {
            CardImage.Visible = false;
            CardImage.ImageUrl = "";
            txtMonth.Text = string.Empty;
            txtName.Text = string.Empty;
            txtRateOne.Text = string.Empty;
            txtRateTwo.Text = string.Empty;
            ddlBanks.SelectedIndex = -1;
            ddlCreditCardStatus.SelectedIndex = -1;
            ddlRate.SelectedIndex = -1;
            Session["PRODUCT_TERMRATE_LIST"] = null;
            btnSave.CommandArgument = string.Empty;
            gvTermRate.DataSource = null;
            gvTermRate.DataBind();

            RadTabStrip1.SelectedIndex = 0;
            RadPageView1.Selected = true;
        }
        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();

            lblCreditCardId.Text = "Yeni Kayıt";
            lblPaymetTermRateId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            ddlBanks.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int CreditCardId = 0;
            if (btnSave.CommandArgument != "") //Kayıt güncelleme.
            {
                CreditCardId = Convert.ToInt32(btnSave.CommandArgument);
                SaveCreditCards(CreditCardId);
            }
            else
            {
                CreditCardId = InsertCreditCard();
            }
            SavePaymentTermRate(CreditCardId);
            GetList();
        }
        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            btnSave.CommandArgument = itemId.ToString();
            GetItem(itemId);
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (DeleteCreditCardMain(itemId))
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Kredi Kartı Başarıyla silindi <i>Ürün Id: " + itemId.ToString() + "</i></span><br />";
                GetList();
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Kredi Kartı silinirken hata oluştu! <i>Ürün Id: " + itemId.ToString() + "</i></span><br />";
            }
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlList.Visible = true;
            pnlFilter.Visible = true;
        }

        #region CreditCards
        private bool GetCreditCardMain(int CreditCardId)
        {
            bool retValue = false;
            try
            {

                var item = CreditCardData.Get(CreditCardId);
                lblCreditCardId.Text = item.Id.ToString();
                txtName.Text = item.Name.ToString();
                ddlBanks.SelectedValue = item.Bank.Id.ToString();
                ddlCreditCardStatus.SelectedValue = item.Status.Id.ToString();
                CardImage.ImageUrl = "../CreditCardImages/" + item.Image.ToString();
                var itemPaymentTermRate = PaymetTermRateData.GetPaymetTermRateList(CreditCardId);

                Session.Add("PRODUCT_TERMRATE_LIST", itemPaymentTermRate);
                gvTermRate.DataSource = itemPaymentTermRate;
                gvTermRate.DataBind();

                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "GetCreditCard";
                itemSystemLog.Content = "Id=" + CreditCardId + " ile alanlar doldurulamadı. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool SaveCreditCards(int CreditCardId)
        {
            bool retValue = false;
            try
            {
                if (btnSave.CommandArgument != "")
                {
                    //güncelle                    
                    if (UpdateCreditCardMain(CreditCardId))
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Ürün güncelleme başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Ürün güncellenirken hata oluştu.";
                        retValue = false;
                    }
                }
                else
                {
                    //yeni kayıt
                    if (InsertCreditCard() > 0)
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Yeni ürün kaydı başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Yeni Ürün kaydedilirken hata oluştu.";
                        retValue = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { }
            return retValue;
        }

        private int InsertCreditCard()
        {
            int retValue = 0;
            List<IKSIR.ECommerce.Model.Bank.CreditCard> itemList = CreditCardData.GetCreditCardList();


            string Name = txtName.Text;
            itemList = itemList.Where(x => x.Name == Name).ToList();

            var itemCreditCard = new IKSIR.ECommerce.Model.Bank.CreditCard();
            if (itemList.Count > 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu ürün için fiyat zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
            }
            else
            {
                itemCreditCard.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = Convert.ToInt32(ddlBanks.SelectedValue) };
                itemCreditCard.Image = SaveImage();
                itemCreditCard.Name = txtName.Text;
                itemCreditCard.Status = new EnumValue() { Id = Convert.ToInt32(ddlCreditCardStatus.SelectedValue) };

                int result = CreditCardData.Insert(itemCreditCard);
                if (result > 0)
                {
                    retValue = result;
                }
            }

            return retValue;
        }

        private bool UpdateCreditCardMain(int CreditCardId)
        {
            bool retValue = false;

            var itemCreditCard = CreditCardData.Get(CreditCardId);
            if (itemCreditCard != null)
            {
                itemCreditCard.Id = CreditCardId;
                itemCreditCard.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = Convert.ToInt32(ddlBanks.SelectedValue) };
                string Url = SaveImage();
                if (Url == "")
                    itemCreditCard.Image = itemCreditCard.Image;
                else
                    itemCreditCard.Image = Url;

                itemCreditCard.Name = txtName.Text;
                itemCreditCard.Status = new EnumValue() { Id = Convert.ToInt32(ddlCreditCardStatus.SelectedValue) };

                int result = CreditCardData.Update(itemCreditCard);
                if (result != 1)
                    retValue = true;
            }
            return retValue;
        }
        private bool DeleteCreditCardMain(int CreditCardId)
        {
            bool retValue = false;

            if (CreditCardData.Delete(CreditCardId) > 0)
            {
                retValue = true;
            }
            return retValue;

        }

        private string SaveImage()
        {
            bool isOK = false;
            string targetFileNameImage = "";
            string fileExtension = "";
            string fileName = "";
            foreach (Telerik.Web.UI.UploadedFile uploadedFile in ruCreditCardImage.UploadedFiles)
            {
                System.Threading.Thread.Sleep(1000);
                fileName = DateTime.Now.ToString().Replace(".", "").Replace(":", "").Replace("/", "").Replace("-", "").Replace(" ", "");

                //IMaj kaydet.
                string targetFolderImage = Server.MapPath("~/CreditCardImages/");

                targetFileNameImage = System.IO.Path.Combine(targetFolderImage, fileName + uploadedFile.GetExtension());

                //Eğer resim ise 3 farklı boyutta resize et.
                fileExtension = uploadedFile.GetExtension();
                if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".gif")
                {
                    try
                    {
                        uploadedFile.SaveAs(targetFileNameImage, isOK);
                        Utility.ResizeImage(targetFileNameImage, Server.MapPath("~/CreditCardImages" + fileName + fileExtension), 50, 24, true);
                        divAlert.InnerHtml += "<span style=\"color:Green\">Dosya başarıyla yüklendi. Dosya Adı: <i>" + uploadedFile.FileName + "</i></span><br />";
                    }
                    catch (Exception exception)
                    {
                        divAlert.InnerHtml += "<span style=\"color:Red\">Dosya yüklenirken hata oluştu! Dosya Adı: <i>" + uploadedFile.FileName + "</i> Hata:" + exception.ToString() + "</span><br />";
                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "SaveDocuments";
                        itemSystemLog.Content = " IMaj eklerken hata oluştu. Hata: " + exception.ToString();
                        itemSystemLog.Type = new EnumValue() { Id = 0 };
                        SystemLogData.Insert(itemSystemLog);

                    }
                }
                else
                {
                    uploadedFile.SaveAs(targetFolderImage, isOK);
                }

            }
            return fileName + fileExtension;
        }
        #endregion

        #region TermRate
        protected void btnAddTermRate_Click(object sender, EventArgs e)
        {
            SavePaymentTermRateToList();


            ddlRate.SelectedIndex = -1;
            txtRateOne.Text = string.Empty;
            txtRateTwo.Text = string.Empty;
            txtMonth.Text = string.Empty;
            btnAddTermRate.CommandArgument = "";
            lblPaymetTermRateId.Text = "Yeni Kayıt";
        }
        protected void lbtTermRateEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var paymentTermRateId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            btnSave.CommandArgument = lblCreditCardId.Text.ToString();
            if (!GetPaymentTermRates(Convert.ToInt32(paymentTermRateId)))
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Vade Oran bilgilerini getirirken hata oluştu!</span><br />";
            }
            RadTabStrip1.SelectedIndex = 1;
            RadPageView2.Selected = true;
        }
        protected void lbtnTermRateDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (DeletePaymentTermRate(itemId))
            {

                divAlert.InnerHtml += "<span style=\"color:Green\">Vade Oranı başarıyla silindi</span><br />";

                GetItem(Convert.ToInt32(lblCreditCardId.Text));
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Vade Oranı silinirken hata oluştu!</span><br />";
            }
        }
        private List<PaymetTermRate> GetPaymetTermRateList()
        {
            List<PaymetTermRate> PaymetTermRateList;
            if (Session["PRODUCT_TERMRATE_LIST"] != null)
            {
                PaymetTermRateList = (List<PaymetTermRate>)Session["PRODUCT_TERMRATE_LIST"];
            }
            else
            {
                PaymetTermRateList = new List<PaymetTermRate>();
                Session.Add("PRODUCT_TERMRATE_LIST", PaymetTermRateList);
            }
            PaymetTermRateList = (List<PaymetTermRate>)Session["PRODUCT_TERMRATE_LIST"];

            return PaymetTermRateList;
        }
        private bool GetPaymentTermRate(int CreditCardId)
        {
            bool retValue = false;

            try
            {

                var paymentTermRateList = PaymetTermRateData.GetPaymetTermRateList(CreditCardId);

                Session.Add("PRODUCT_TERMRATE_LIST", paymentTermRateList);
                gvTermRate.DataSource = paymentTermRateList;
                gvTermRate.DataBind();
                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductPrice";
                itemSystemLog.Content = "Ürün fiyatı kaydedilirken hata oluştu. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
                retValue = false;
            }
            return retValue;
        }
        private bool GetTermRate()
        {
            bool retValue = false;
            var paymentRateList = GetPaymetTermRateList();
            gvTermRate.DataSource = paymentRateList;
            gvTermRate.DataBind();
            return retValue;
        }
        private bool GetPaymentTermRates(int PaymentTermRateId)
        {
            bool retValue = false;

            var itemPaymentTermRate = PaymetTermRateData.Get(PaymentTermRateId);
            lblPaymetTermRateId.Text = itemPaymentTermRate.Id.ToString();
            txtMonth.Text = itemPaymentTermRate.Month.ToString();
            ddlRate.SelectedValue = itemPaymentTermRate.Status.Id.ToString();
            string[] Rates = itemPaymentTermRate.Rate.ToString().Split('.');
            txtRateOne.Text = Rates[0].ToString();
            txtRateTwo.Text = Rates[1].ToString();
            btnAddTermRate.CommandArgument = lblPaymetTermRateId.Text.ToString();
            retValue = true;
            GetItem(Convert.ToInt32(lblCreditCardId.Text));
            return retValue;
        }
        private bool SavePaymentTermRateToList()
        {
            bool retValue = false;
            try
            {

                var paymentTermRateList = GetPaymetTermRateList();
                if (btnAddTermRate.CommandArgument != "")
                {
                    //güncelle
                    int PaymetTermRateId = DBHelper.IntValue(btnAddTermRate.CommandArgument);
                    if (PaymetTermRateId != 0)
                    {

                        PaymetTermRate item = paymentTermRateList.Where(x => x.Id == PaymetTermRateId).SingleOrDefault();
                        paymentTermRateList.Remove(item);
                        var newItem = new PaymetTermRate();
                        newItem.Id = item.Id;

                        newItem.Rate = Convert.ToDecimal(txtRateOne.Text.ToString() + "." + txtRateTwo.Text.ToString());
                        newItem.Month = Convert.ToInt32(txtMonth.Text);
                        newItem.Status = new EnumValue() { Id = Convert.ToInt32(ddlRate.SelectedValue) };
                        newItem.CreditCard = new CreditCard() { Id = Convert.ToInt32(lblCreditCardId.Text) };


                        paymentTermRateList.Add(newItem);
                        divAlert.InnerHtml += "<span style=\"color:Green\">Vade oranı güncelleme başarılı.</span><br />";
                        retValue = true;
                    }
                    else
                    {
                        divAlert.InnerHtml += "<span style=\"color:Red\">Vade oranı güncellenirken hata oluştu!</span><br />";
                        retValue = false;
                    }
                }
                else
                {
                    try
                    {

                        var item = new PaymetTermRate();

                        item.Rate = Convert.ToDecimal(txtRateOne.Text.ToString() + "." + txtRateTwo.Text.ToString());
                        item.Month = Convert.ToInt32(txtMonth.Text);
                        item.Status = new EnumValue() { Id = Convert.ToInt32(ddlRate.SelectedValue) };
                        // item.CreditCard = new CreditCard() { Id = Convert.ToInt32(lblCreditCardId.Text) };

                        paymentTermRateList.Add(item);
                        divAlert.InnerHtml += "<span style=\"color:Green\">Yeni vade oranı kaydı başarılı.</span><br />";
                        retValue = true;
                    }
                    catch (Exception)
                    {
                        divAlert.InnerHtml += "<span style=\"color:Red\">Yeni vade oranı kaydedilirken hata oluştu.</span><br />";
                        retValue = false;
                    }
                }
                GetTermRate();
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductProperty";
                itemSystemLog.Content = "Ürün özelliği kaydedilirken hata oluştu. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            finally
            {

            }
            return retValue;
        }
        private bool SavePaymentTermRate(int CreditCardId)
        {
            bool retValue = false;
            try
            {
                var PaymentTermRateList = GetPaymetTermRateList();

                foreach (PaymetTermRate itempaymentTermRate in PaymentTermRateList)
                {
                    if (itempaymentTermRate.Id != 0)
                    {
                        //güncelle
                        if (PaymetTermRateData.Update(itempaymentTermRate) < 0)
                        {
                            divAlert.InnerHtml += "<span style=\"color:Green\">Vade Oranı güncelleme başarılı.</span><br />";
                            retValue = true;
                        }
                        else
                        {
                            divAlert.InnerHtml += "<span style=\"color:Red\">Vade Oranı  güncellenirken hata oluştu.</span><br />";
                            retValue = false;
                        }
                    }
                    else
                    {
                        //yeni kayıt
                        itempaymentTermRate.CreditCard = new CreditCard() { Id = CreditCardId };
                        if (PaymetTermRateData.Insert(itempaymentTermRate) > 0)
                        {
                            divAlert.InnerHtml += "<span style=\"color:Green\">Vade oranı kaydı başarılı.</span><br />";
                            retValue = true;
                        }
                        else
                        {
                            divAlert.InnerHtml += "<span style=\"color:Red\">Vade Oranı kaydedilirken hata oluştu.</span><br />";
                            retValue = false;
                        }
                    }
                }
                GetTermRate();
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductProperties";
                itemSystemLog.Content = CreditCardId.ToString() + " Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            finally
            {

            }
            return retValue;
        }
        private bool InsertPaymentTermRateToList(PaymetTermRate itemPaymentTermRate)
        {

            bool retValue = false;
            try
            {
                var paymetTermRateList = GetPaymetTermRateList();
                paymetTermRateList = (List<PaymetTermRate>)Session["PRODUCT_TERMRATE_LIST"];
                PaymetTermRate item = new PaymetTermRate();
                item.Id = 0;//Yeni kayıt.
                item.CreditCard.Id = itemPaymentTermRate.CreditCard.Id;
                item.Month = itemPaymentTermRate.Month;
                item.Rate = itemPaymentTermRate.Rate;
                item.Status = itemPaymentTermRate.Status;

                paymetTermRateList.Add(item);
                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "InsertproductShipmentPrice";
                itemSystemLog.Content = "Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }
        private bool DeletePaymentTermRate(int PaymentTermRateId)
        {
            bool retValue = false;
            try
            {

                if (PaymetTermRateData.Delete(PaymentTermRateId) < 0)
                {
                    retValue = true;
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete PaymentTermRate";
                itemSystemLog.Content = "Id=" + PaymentTermRateId.ToString() + " ile Karho Kaydı silinemedi. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }
        #endregion

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            GetList();
        }



    }
}