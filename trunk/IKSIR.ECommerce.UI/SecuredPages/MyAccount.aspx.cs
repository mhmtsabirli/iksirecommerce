﻿using System;
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

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] == null)
            {
                Response.Redirect("Login.aspx?returl=MyAccount.aspx");
            }
            if (!Page.IsPostBack)
            {

                BindValues();
                GetList();
            }
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = true;
            txtAddressTitle.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.CommandArgument != "") //Kayıt güncelleme.
            {
                if (SaveItem(Convert.ToInt32(btnSave.CommandArgument)))
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Adresiniz başarıyla güncellendi.";
                    ClearForm();
                    pnlForm.Visible = false;
                    GetList();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Adresinizi güncellenirken bir hata oluştu.";
                }
            }
            else
            {
                if (SaveItem())
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Adresiniz başarıyla kaydedildi.";
                    ClearForm();
                    pnlForm.Visible = false;
                    GetList();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Adresiniz kaydedilirken bir hata oluştu.";
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlList.Visible = true;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            GetItem(itemId);
        }

        protected void lbtnView_Click(object sender, EventArgs e)
        {

            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            GetOrderItem(itemId);
            dvMyOrder.Visible = true;
            ddlPaymentType.Enabled = false;

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (DeleteItem(itemId))
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Item başarıyla silindi.";
                GetList();
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Item silerken bir hata oluştu.";
            }
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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetOrderList();
        }

        protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = -1;
            int.TryParse(ddlCountries.SelectedValue, out countryId);

            if (countryId != -1)
            {
                if (countryId == 1) //Türkiye ise
                {
                    List<City> cityList = CityData.GetCityList(countryId);
                    Utility.BindDropDownList(ddlCities, cityList, "Name", "Id");

                    ddlCities.Visible = true;
                    ddlDistricts.Visible = true;
                    txtCity.Visible = false;
                    txtDistrict.Visible = false;
                }
                else
                {
                    //Türkiye dışında bir ülke seçerse city/distrcit textbox olacak.
                    ddlCities.Items.Clear();
                    ddlCities.Visible = false;
                    ddlDistricts.Visible = false;
                    txtCity.Visible = true;
                    txtDistrict.Visible = true;
                }
            }
        }

        protected void ddlCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = -1;
            int.TryParse(ddlCities.SelectedValue, out cityId);
            if (cityId != -1)
            {
                List<District> cityList = DistrictData.GetDistrictList(cityId);
                Utility.BindDropDownList(ddlDistricts, cityList, "Name", "Id");
            }
            else
            {
                ddlDistricts.Items.Clear();
            }
        }

        private void GetItem(int itemId)
        {
            var item = AddressData.Get(itemId);
            txtAddressTitle.Text = item.Title;
            if (item.Type != null)
                ddlAddressType.SelectedValue = item.Type.Id.ToString();

            btnSave.CommandArgument = item.Id.ToString();
            txtFirstName.Text = item.FirstName;
            txtLastName.Text = item.LastName;
            txtAddress.Text = item.AddressDetail;
            txtPostCode.Text = item.PostalCode;

            if (item.Country != null)
                ddlCountries.SelectedValue = item.Country.Id.ToString();
            if (item.City != null)
            {
                ddlCities.SelectedValue = item.City.Id.ToString();
                ddlCities_SelectedIndexChanged(null, null);
                ddlCities.Visible = true;
                txtCity.Visible = false;
            }
            else
            {
                txtCity.Text = item.CityName;
                txtCity.Visible = true;
                ddlCities.Visible = false;
            }

            if (item.District != null)
            {
                ddlDistricts.SelectedValue = item.District.Id.ToString();
                ddlDistricts.Visible = true;
                txtDistrict.Visible = false;
            }
            else
            {
                txtDistrict.Text = item.DistrictName;
                txtDistrict.Visible = true;
                ddlDistricts.Visible = false;
            }
            txtPhone.Text = item.Phone;
            txtGSMPhone.Text = item.GSMPhone;
            pnlForm.Visible = true;
        }

        private bool GetOrderItem(int itemId)
        {
            Model.Order.Order itemOrder = OrderData.Get(itemId, 0, new EnumValue() { Id = 0 });
            bool retValue = false;

            pnlForm.Visible = true;

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
            lblId.Text = itemOrder.Id.ToString();
            lbltotalPrice.Text = itemOrder.TotalPrice.ToString();
            lbltotalRatedPrice.Text = itemOrder.TotalRatedPrice.ToString();
            return retValue;

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

        private bool GetPaymentInfo(Model.Bank.PaymetInfo paymetInfo)
        {
            bool IsOk = false;
            try
            {
                List<EnumValue> ListPaymentType = EnumValueData.GetEnumValues(21);//Ödeme Tipleri
                Utility.BindDropDownList(ddlPaymentType, ListPaymentType, "Value", "Id");
                ddlPaymentType.SelectedValue = paymetInfo.PaymentType.Id.ToString();

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

        private void BindValues()
        {
            List<EnumValue> addressTypes = EnumValueData.GetEnumValues(10); //AddressTipleri
            Utility.BindDropDownList(ddlAddressType, addressTypes, "Value", "Id");

            List<Country> countryList = CountryData.GetCountryList();
            Utility.BindDropDownList(ddlCountries, countryList, "Name", "Id");
            ddlCountries.SelectedValue = "1"; //Türkiye default seçili geliyor. =>ayhant
            List<City> cityList = CityData.GetCityList(1); //Türkiyenin şehirlerini default getiriyoruz. =>ayhant
            Utility.BindDropDownList(ddlCities, cityList, "Name", "Id");

            List<EnumValue> itemListOrderStatus = EnumValueData.GetEnumValues(20);
            Utility.BindDropDownList(ddlFilterOrderStatus, itemListOrderStatus, "Value", "Id");
        }

        private void GetList()
        {
            List<Address> itemList = AddressData.GetMembershipAddresses(1);
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private void GetOrderList()
        {
            User User = (User)Session["LOGIN_USER"];
            List<Model.Order.Order> itemList = OrderData.GetList(Convert.ToInt32(ddlFilterOrderStatus.SelectedValue), User.Id);

            gvOrderList.DataSource = itemList;
            gvOrderList.DataBind();
        }

        private bool SaveItem(int id = 0)
        {
            bool retValue = false;
            try
            {
                var addressItem = new Address();
                addressItem.Id = id;
                addressItem.User = new Model.MembershipModel.User() { Id = 1 };
                addressItem.Title = txtAddressTitle.Text;
                int typeId = -1;
                int.TryParse(ddlAddressType.SelectedValue, out typeId);
                if (typeId != -1)
                    addressItem.Type = new EnumValue() { Id = typeId };
                addressItem.FirstName = txtFirstName.Text;
                addressItem.LastName = txtLastName.Text;
                addressItem.AddressDetail = txtAddress.Text;
                addressItem.PostalCode = txtPostCode.Text;

                int countryId = -1;
                int.TryParse(ddlCountries.SelectedValue, out countryId);
                if (typeId != -1)
                    addressItem.Country = new Country() { Id = countryId };

                int cityId = -1;
                int.TryParse(ddlCities.SelectedValue, out cityId);
                if (ddlCities.Visible && cityId != -1)
                    addressItem.City = new City() { Id = cityId };
                else if (txtCity.Visible)
                    addressItem.CityName = txtCity.Text;

                int districtId = -1;
                int.TryParse(ddlDistricts.SelectedValue, out districtId);
                if (ddlDistricts.Visible && districtId != -1)
                    addressItem.District = new District() { Id = districtId };
                else if (txtDistrict.Visible)
                    addressItem.DistrictName = txtDistrict.Text;

                addressItem.Phone = txtPhone.Text;
                addressItem.GSMPhone = txtGSMPhone.Text;

                if (AddressData.Save(addressItem) > 0)
                {
                    retValue = true;
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "User Yeni address ekledi";
                    itemSystemLog.Content = "Title" + addressItem.Title;
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
                else
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "User Yeni addres eklerken hata oluştu.";
                    itemSystemLog.Content = "Title" + txtAddressTitle.Text + " Id: " + addressItem.Id;
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "User Yeni addres eklerken hata oluştu.";
                itemSystemLog.Content = "Title" + txtAddressTitle.Text + " Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }

        private void ClearForm()
        {
            lblError.Text = "";
            txtAddressTitle.Text = string.Empty;
            ddlAddressType.SelectedIndex = -1;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPostCode.Text = string.Empty;
            ddlCountries.SelectedValue = "1";
            ddlCountries_SelectedIndexChanged(null, null);
            ddlDistricts.SelectedIndex = -1;
            ddlCities_SelectedIndexChanged(null, null);
            txtCity.Visible = false;
            txtDistrict.Visible = false;
            ddlCities.Visible = true;
            ddlDistricts.Visible = true;
            txtPhone.Text = string.Empty;
            txtGSMPhone.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}