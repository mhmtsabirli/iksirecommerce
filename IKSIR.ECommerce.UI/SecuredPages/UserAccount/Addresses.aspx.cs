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
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.UI.SecuredPages.UserAccount
{
    public partial class Addresses : System.Web.UI.Page
    {
        public User loginUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] == null)
            {
                Response.Redirect("../Login.aspx?returl=" + Request.Url.PathAndQuery);
            }
            if (!Page.IsPostBack)
            {
                loginUser = (User)Session["LOGIN_USER"];
                BindValues();
                GetAddresses();
            }
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlForm.Visible = true;
        }

        protected void btnAddressSave_Click(object sender, EventArgs e)
        {
            if (!CheckAddressForm())
            {
                return;
            }
            if (btnAddressSave.CommandArgument != "") //Kayıt güncelleme.
            {
                if (SaveItem(Convert.ToInt32(btnAddressSave.CommandArgument)))
                {
                    divAlert.InnerHtml = "<span style=\"color:Green\">Adresiniz başarıyla güncellendi.</span><br />";
                    ClearForm();
                    pnlForm.Visible = false;
                    GetAddresses();
                }
                else
                {
                    divAlert.InnerHtml = "<span style=\"color:Red\">Adresinizi güncellenirken bir hata oluştu.</span><br />";
                }
            }
            else
            {
                if (SaveItem())
                {
                    divAlert.InnerHtml = "<span style=\"color:Green\">Adresiniz başarıyla kaydedildi.</span><br />";
                    ClearForm();
                    pnlForm.Visible = false;
                    GetAddresses();
                }
                else
                {
                    divAlert.InnerHtml = "<span style=\"color:Red\">Adresinizi kaydedilirken bir hata oluştu.</span><br />";
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
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (DeleteItem(itemId))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Adresiniz başarıyla silindi.</span><br />";
                GetAddresses();
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Adresiniz silinirken bir hata oluştu.</span><br />";
            }
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

            btnAddressSave.CommandArgument = item.Id.ToString();
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

            //List<EnumValue> itemListOrderStatus = EnumValueData.GetEnumValues(20);
            //Utility.BindDropDownList(ddlFilterOrderStatus, itemListOrderStatus, "Value", "Id");
        }

        private void GetAddresses()
        {
            loginUser = (User)Session["LOGIN_USER"];
            List<Address> itemList = AddressData.GetMembershipAddresses(loginUser.Id);
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private bool SaveItem(int id = 0)
        {
            bool retValue = false;
            try
            {
                loginUser = (User)Session["LOGIN_USER"];
                var addressItem = new Address();
                addressItem.Id = id;
                addressItem.User = new Model.MembershipModel.User() { Id = loginUser.Id };
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
            btnAddressSave.CommandArgument = string.Empty;
            divAlert.InnerHtml = "";
        }

        private bool CheckAddressForm()
        {
            bool retValue = true;
            divAlert.InnerHtml = "";
            if (txtAddressTitle.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Adres Tanımı alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (ddlAddressType.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Adres Tipi seçiniz.</span><br />";
                retValue = false;
            }
            if (txtFirstName.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Ad alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtLastName.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Soyad alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (ddlCountries.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Ülke seçiniz.</span><br />";
                retValue = false;
            }
            if (ddlCities.Visible && ddlCities.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Şehir seçiniz.</span><br />";
                retValue = false;
            }
            if (txtCity.Visible && txtCity.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Şehir alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (ddlDistricts.Visible && ddlDistricts.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/İlçe seçiniz.</span><br />";
                retValue = false;
            }
            if (txtDistrict.Visible && txtDistrict.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/İlçe alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtPostCode.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Posta Kodu alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtAddress.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Adres alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtPhone.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Telefon alanı zorunlu.</span><br />";
                retValue = false;
            }
            return retValue;
        }
    }
}