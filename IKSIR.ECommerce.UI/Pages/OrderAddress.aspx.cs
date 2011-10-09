using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class OrderAddress : System.Web.UI.Page
    {
        public User loginUser = null;
        public Basket basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
                GetUserAddresses();
            }

            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                loginUser = (User)Session["LOGIN_USER"];
                basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=../Pages/OrderBasket.aspx");
            }
        }

        protected void ddlShippingAddressCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = -1;
            int.TryParse(ddlShippingAddressCountries.SelectedValue, out countryId);

            if (countryId != -1)
            {
                if (countryId == 1) //Türkiye ise
                {
                    List<City> cityList = CityData.GetCityList(countryId);
                    Utility.BindDropDownList(ddlShippingAddressCities, cityList, "Name", "Id");

                    ddlShippingAddressCities.Visible = true;
                    RequiredFieldValidatorShippingAddressCities.Visible = true;
                    ddlShippingAddressDistricts.Visible = true;
                    RequiredFieldValidatorShippingAddressDistricts.Visible = true;
                    txtShippingAddressCountryName.Visible = false;
                    txtShippingAddressCityName.Visible = false;
                    txtShippingAddressDistrictName.Visible = false;
                }
                else
                {
                    //Türkiye dışında bir ülke seçerse city/distrcit textbox olacak.
                    ddlShippingAddressCities.Items.Clear();
                    ddlShippingAddressCities.Visible = false;
                    RequiredFieldValidatorShippingAddressCities.Visible = false;
                    ddlShippingAddressDistricts.Visible = false;
                    RequiredFieldValidatorShippingAddressDistricts.Visible = false;
                    txtShippingAddressCountryName.Visible = true;
                    txtShippingAddressCityName.Visible = true;
                    txtShippingAddressDistrictName.Visible = true;
                }
            }
        }

        protected void ddlShippingAddressCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = -1;
            int.TryParse(ddlShippingAddressCities.SelectedValue, out cityId);
            if (cityId != -1)
            {
                List<District> cityList = DistrictData.GetDistrictList(cityId);
                Utility.BindDropDownList(ddlShippingAddressDistricts, cityList, "Name", "Id");
            }
            else
            {
                ddlShippingAddressDistricts.Items.Clear();
            }
        }

        protected void ddlBillingAddressCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            int countryId = 0;
            int.TryParse(ddlBillingAddressCountries.SelectedValue, out countryId);

            if (countryId == 2)
            {
                //Türkiye dışında bir ülke seçerse city/distrcit textbox olacak.
                ddlBillingAddressCities.Items.Clear();
                ddlBillingAddressCities.Visible = false;
                RequiredFieldValidatorBillingAddressCities.Visible = false;
                ddlBillingAddressDistricts.Visible = false;
                RequiredFieldValidatorBillingAddressDistricts.Visible = false;
                txtBillingAddressCityName.Visible = true;
                txtBillingAddressDistrictName.Visible = true;
            }
            else
            {
                //Diğer
                List<City> cityList = CityData.GetCityList(countryId);
                Utility.BindDropDownList(ddlBillingAddressCities, cityList, "Name", "Id");
                ddlBillingAddressCities.Visible = true;
                RequiredFieldValidatorBillingAddressCities.Visible = true;
                ddlBillingAddressDistricts.Visible = true;
                RequiredFieldValidatorBillingAddressDistricts.Visible = true;
                txtBillingAddressCityName.Visible = false;
                txtBillingAddressDistrictName.Visible = false;
            }
        }

        protected void ddlBillingAddressCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = -1;
            int.TryParse(ddlBillingAddressCities.SelectedValue, out cityId);
            if (cityId != -1)
            {
                List<District> cityList = DistrictData.GetDistrictList(cityId);
                Utility.BindDropDownList(ddlBillingAddressDistricts, cityList, "Name", "Id");
            }
            else
            {
                ddlBillingAddressDistricts.Items.Clear();
            }
        }

        protected void rblShippingAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rblBillingAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnUpdateShippingAddress_Click(object sender, EventArgs e)
        {
            int shippingAddressId = 0;
            if (rblShippingAddresses.SelectedIndex != -1 && int.TryParse(rblShippingAddresses.SelectedValue, out shippingAddressId))
            {
                pnlShippingAddress.Visible = true;
                lblShippingAddresFormTitle.Text = "Seçili Teslimat Adresini Güncelle";
                var selectedShippingAddress = AddressData.Get(shippingAddressId);
                txtShippingAddressTitle.Text = selectedShippingAddress.Title;
                txtShippingAddressFirstName.Text = selectedShippingAddress.FirstName;
                txtShippingAddressLastName.Text = selectedShippingAddress.LastName;
                if (selectedShippingAddress.Country != null && selectedShippingAddress.Country.Id != 0 && selectedShippingAddress.Country.Id != 2) //Diğer
                {
                    ddlShippingAddressCountries.SelectedValue = selectedShippingAddress.Country.Id.ToString();
                    ddlShippingAddressCountries_SelectedIndexChanged(null, null);
                    if (selectedShippingAddress.City != null && selectedShippingAddress.City.Id != 0 && selectedShippingAddress.City.Id != 83)
                    {
                        ddlShippingAddressCities.SelectedValue = selectedShippingAddress.City.Id.ToString();
                        ddlShippingAddressCities_SelectedIndexChanged(null, null);

                        if (selectedShippingAddress.District != null && selectedShippingAddress.District.Id != 0 && selectedShippingAddress.District.Id != 984) //Diğer
                        {
                            ddlShippingAddressDistricts.SelectedValue = selectedShippingAddress.District.Id.ToString();
                        }
                        else
                        {
                            txtShippingAddressDistrictName.Visible = true;
                            txtShippingAddressDistrictName.Text = selectedShippingAddress.DistrictName;
                        }
                    }
                    else
                    {
                        txtShippingAddressCityName.Visible = true;
                        txtShippingAddressCityName.Text = selectedShippingAddress.CityName;
                    }
                }
                else
                {
                    ddlShippingAddressCountries.SelectedValue = "2";
                    txtShippingAddressCountryName.Visible = true;
                    txtShippingAddressCountryName.Text = selectedShippingAddress.CountryName;

                    ddlShippingAddressCities.Visible = false;
                    RequiredFieldValidatorShippingAddressCities.Visible = false;
                    txtShippingAddressCityName.Visible = true;
                    txtShippingAddressCityName.Text = selectedShippingAddress.CityName;

                    ddlShippingAddressDistricts.Visible = false;
                    RequiredFieldValidatorShippingAddressDistricts.Visible = false;
                    txtShippingAddressDistrictName.Visible = true;
                    txtShippingAddressDistrictName.Text = selectedShippingAddress.DistrictName;
                }
                txtShippingAddressPostCode.Text = selectedShippingAddress.PostalCode;
                txtShippingAddressLine.Text = selectedShippingAddress.AddressDetail;
                txtShippingAddressPhone.Text = selectedShippingAddress.Phone;
                txtShippingAddressGSMPhone.Text = selectedShippingAddress.GSMPhone;
                btnShippingAddressSave.CommandArgument = shippingAddressId.ToString();
                btnShippingAddressSave.Text = "Seçili Teslimat Adresini Güncelle";
            }
        }

        protected void lbtnUpdateBillingAddress_Click(object sender, EventArgs e)
        {
            int billingAddressId = 0;
            if (rblBillingAddresses.SelectedIndex != -1 && int.TryParse(rblBillingAddresses.SelectedValue, out billingAddressId))
            {
                pnlBillingAddress.Visible = true;
                lblBillingAddressFormTitle.Text = "Seçili Fatura Adresini Güncelle";
                var selectedBillingAddress = AddressData.Get(billingAddressId);
                txtBillingAddressTitle.Text = selectedBillingAddress.Title;
                txtBillingAddressFirstName.Text = selectedBillingAddress.FirstName;
                txtBillingAddressLastName.Text = selectedBillingAddress.LastName;
                if (selectedBillingAddress.Country != null && selectedBillingAddress.Country.Id != 0 && selectedBillingAddress.Country.Id != 2) //Diğer
                {
                    ddlBillingAddressCountries.SelectedValue = selectedBillingAddress.Country.Id.ToString();
                    ddlBillingAddressCountries_SelectedIndexChanged(null, null);
                    if (selectedBillingAddress.City != null && selectedBillingAddress.City.Id != 0 && selectedBillingAddress.City.Id != 83)
                    {
                        ddlBillingAddressCities.SelectedValue = selectedBillingAddress.City.Id.ToString();
                        ddlBillingAddressCities_SelectedIndexChanged(null, null);

                        if (selectedBillingAddress.District != null && selectedBillingAddress.District.Id != 0 && selectedBillingAddress.District.Id != 984) //Diğer
                        {
                            ddlBillingAddressDistricts.SelectedValue = selectedBillingAddress.District.Id.ToString();
                        }
                        else
                        {
                            txtBillingAddressDistrictName.Visible = true;
                            txtBillingAddressDistrictName.Text = selectedBillingAddress.DistrictName;
                        }
                    }
                    else
                    {
                        txtBillingAddressCityName.Visible = true;
                        txtBillingAddressCityName.Text = selectedBillingAddress.CityName;
                    }
                }
                else
                {
                    txtBillingAddressCountryName.Visible = true;
                    txtBillingAddressCountryName.Text = selectedBillingAddress.CountryName;

                    ddlBillingAddressCities.Visible = false;
                    RequiredFieldValidatorBillingAddressCities.Visible = false;
                    txtBillingAddressCityName.Visible = true;
                    txtBillingAddressCityName.Text = selectedBillingAddress.CityName;

                    ddlBillingAddressDistricts.Visible = false;
                    RequiredFieldValidatorBillingAddressDistricts.Visible = false;
                    txtBillingAddressDistrictName.Visible = true;
                    txtBillingAddressDistrictName.Text = selectedBillingAddress.DistrictName;
                }
                txtBillingAddressPostCode.Text = selectedBillingAddress.PostalCode;
                txtBillingAddressLine.Text = selectedBillingAddress.AddressDetail;
                txtBillingAddressPhone.Text = selectedBillingAddress.Phone;
                txtBillingAddressGSMPhone.Text = selectedBillingAddress.GSMPhone;
                btnBillingAddressSave.CommandArgument = billingAddressId.ToString();
                btnBillingAddressSave.Text = "Seçili Fatura Adresini Güncelle";
            }
        }

        protected void lbtnNewShippingAddress_Click(object sender, EventArgs e)
        {
            lblShippingAddresFormTitle.Text = "Yeni Teslimat Adresi Tanımla";
            ClearShippingForm();
            pnlShippingAddress.Visible = true;
            btnShippingAddressSave.Text = "Yeni Teslimat Adresimi Kaydet";
        }

        protected void lbtnNewBillingAddress_Click(object sender, EventArgs e)
        {
            lblBillingAddressFormTitle.Text = "Yeni Fatura Adresi Tanımla";
            ClearBillingForm();
            pnlBillingAddress.Visible = true;
            btnBillingAddressSave.Text = "Yeni Fatura Adresimi Kaydet";
        }

        protected void btnShippingAddressSave_Click(object sender, EventArgs e)
        {
            int shippingAddressId = 0;
            if (btnShippingAddressSave.CommandArgument != null && btnShippingAddressSave.CommandArgument != "" && int.TryParse(btnShippingAddressSave.CommandArgument, out shippingAddressId) && shippingAddressId > 0)
            {
                //güncelle
                var shippingAddressItem = AddressData.Get(shippingAddressId);
                shippingAddressItem.Title = txtShippingAddressTitle.Text;
                shippingAddressItem.FirstName = txtShippingAddressFirstName.Text;
                shippingAddressItem.LastName = txtShippingAddressLastName.Text;
                if (ddlShippingAddressCountries.SelectedValue != "-1" && ddlShippingAddressCountries.SelectedValue != "")
                {
                    shippingAddressItem.Country = new Country() { Id = Convert.ToInt32(ddlShippingAddressCountries.SelectedValue) };
                    if (ddlShippingAddressCountries.SelectedValue == "2") //diğer
                    {
                        shippingAddressItem.CountryName = txtShippingAddressCountryName.Text;
                    }
                }
                if (ddlShippingAddressCities.SelectedValue != "-1" && ddlShippingAddressCities.SelectedValue != "")
                {
                    shippingAddressItem.City = new City() { Id = Convert.ToInt32(ddlShippingAddressCities.SelectedValue) };
                }

                if (txtShippingAddressCityName.Visible)
                {
                    shippingAddressItem.CityName = txtShippingAddressCityName.Text;
                }

                if (ddlShippingAddressDistricts.SelectedValue != "-1" && ddlShippingAddressDistricts.SelectedValue != "")
                {
                    shippingAddressItem.District = new District() { Id = Convert.ToInt32(ddlShippingAddressDistricts.SelectedValue) };
                }

                if (txtShippingAddressDistrictName.Visible)
                {
                    shippingAddressItem.DistrictName = txtShippingAddressDistrictName.Text;
                }

                shippingAddressItem.PostalCode = txtShippingAddressPostCode.Text;
                shippingAddressItem.AddressDetail = txtShippingAddressLine.Text;
                shippingAddressItem.Phone = txtShippingAddressPhone.Text;
                shippingAddressItem.GSMPhone = txtShippingAddressGSMPhone.Text;
                var returnValue = AddressData.Update(shippingAddressItem);
                if (returnValue > 0)
                {
                    lblShippingAddressAlert.Text = "Teslimat adresiniz başarıyla güncellendi.";
                    lblShippingAddressAlert.ForeColor = System.Drawing.Color.Green;
                    ClearShippingForm();
                    pnlShippingAddress.Visible = false;
                    rblShippingAddresses.SelectedIndex = -1;
                }
                else
                {
                    lblShippingAddressAlert.Text = "Teslimat adresiniz güncellenirken hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblShippingAddressAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                //yeni kayıt
                var shippingAddressItem = new Address();
                shippingAddressItem.User = new User() { Id = loginUser.Id };
                shippingAddressItem.Title = txtShippingAddressTitle.Text;
                shippingAddressItem.FirstName = txtShippingAddressFirstName.Text;
                shippingAddressItem.LastName = txtShippingAddressLastName.Text;
                if (ddlShippingAddressCountries.SelectedValue != "-1" && ddlShippingAddressCountries.SelectedValue != "-1")
                {
                    shippingAddressItem.Country = new Country() { Id = Convert.ToInt32(ddlShippingAddressCountries.SelectedValue) };
                    if (ddlShippingAddressCountries.SelectedValue == "2") //diğer
                    {
                        shippingAddressItem.CountryName = txtShippingAddressCountryName.Text;
                    }
                }

                if (ddlShippingAddressCities.SelectedValue != "-1" && ddlShippingAddressCities.SelectedValue != "")
                {
                    shippingAddressItem.City = new City() { Id = Convert.ToInt32(ddlShippingAddressCities.SelectedValue) };
                }
                if (txtShippingAddressCityName.Visible)
                {
                    shippingAddressItem.CityName = txtShippingAddressCityName.Text;
                }
                if (ddlShippingAddressDistricts.SelectedValue != "-1" && ddlShippingAddressDistricts.SelectedValue != "")
                {
                    shippingAddressItem.District = new District() { Id = Convert.ToInt32(ddlShippingAddressDistricts.SelectedValue) };
                }
                if (txtShippingAddressDistrictName.Visible)
                {
                    shippingAddressItem.DistrictName = txtShippingAddressDistrictName.Text;
                }

                shippingAddressItem.PostalCode = txtShippingAddressPostCode.Text;
                shippingAddressItem.AddressDetail = txtShippingAddressLine.Text;
                shippingAddressItem.Phone = txtShippingAddressPhone.Text;
                shippingAddressItem.GSMPhone = txtShippingAddressGSMPhone.Text;

                var returnValue = AddressData.Insert(shippingAddressItem);
                if (returnValue > 0)
                {
                    lblShippingAddressAlert.Text = "Yeni teslimat adresiniz başarıyla kaydedildi.";
                    lblShippingAddressAlert.ForeColor = System.Drawing.Color.Green;
                    ClearShippingForm();
                    pnlShippingAddress.Visible = false;
                    rblShippingAddresses.SelectedIndex = -1;
                }
                else
                {
                    lblShippingAddressAlert.Text = "Yeni teslimat adresiniz kaydedilirken hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblShippingAddressAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            GetUserAddresses();
        }

        protected void btnBillingAddressSave_Click(object sender, EventArgs e)
        {
            int billingAddressId = 0;
            if (btnBillingAddressSave.CommandArgument != null && btnBillingAddressSave.CommandArgument != "" && int.TryParse(btnBillingAddressSave.CommandArgument, out billingAddressId) && billingAddressId > 0)
            {
                //güncelle
                var billingAddressItem = AddressData.Get(billingAddressId);
                billingAddressItem.Title = txtBillingAddressTitle.Text;
                billingAddressItem.FirstName = txtBillingAddressFirstName.Text;
                billingAddressItem.LastName = txtBillingAddressLastName.Text;
                if (ddlBillingAddressCountries.SelectedValue != "-1" && ddlBillingAddressCountries.SelectedValue != "")
                {
                    billingAddressItem.Country = new Country() { Id = Convert.ToInt32(ddlBillingAddressCountries.SelectedValue) };
                    if (ddlBillingAddressCountries.SelectedValue == "2") //diğer
                    {
                        billingAddressItem.CountryName = txtBillingAddressCountryName.Text;
                    }
                }
                if (ddlBillingAddressCities.SelectedValue != "-1" && ddlBillingAddressCities.SelectedValue != "")
                {
                    billingAddressItem.City = new City() { Id = Convert.ToInt32(ddlBillingAddressCities.SelectedValue) };
                }
                if (txtBillingAddressCityName.Visible)
                {
                    billingAddressItem.CityName = txtBillingAddressCityName.Text;
                }
                if (ddlBillingAddressDistricts.SelectedValue != "-1" && ddlBillingAddressDistricts.SelectedValue != "")
                {
                    billingAddressItem.District = new District() { Id = Convert.ToInt32(ddlBillingAddressDistricts.SelectedValue) };
                }
                if (txtBillingAddressDistrictName.Visible)
                {
                    billingAddressItem.DistrictName = txtBillingAddressDistrictName.Text;
                }

                billingAddressItem.PostalCode = txtBillingAddressPostCode.Text;
                billingAddressItem.AddressDetail = txtBillingAddressLine.Text;
                billingAddressItem.Phone = txtBillingAddressPhone.Text;
                billingAddressItem.GSMPhone = txtBillingAddressGSMPhone.Text;
                AddressData.Update(billingAddressItem);

                var returnValue = AddressData.Update(billingAddressItem);
                if (returnValue > 0)
                {
                    lblBillingAddressAlert.Text = "Fatura adresiniz başarıyla güncellendi.";
                    lblBillingAddressAlert.ForeColor = System.Drawing.Color.Green;
                    ClearBillingForm();
                    pnlBillingAddress.Visible = false;
                    rblBillingAddresses.SelectedIndex = -1;
                }
                else
                {
                    lblBillingAddressAlert.Text = "Fatura adresiniz güncellenirken hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblBillingAddressAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                var billingAddressItem = new Address();
                billingAddressItem.Title = txtBillingAddressTitle.Text;
                billingAddressItem.FirstName = txtBillingAddressFirstName.Text;
                billingAddressItem.LastName = txtBillingAddressLastName.Text;
                if (ddlBillingAddressCountries.SelectedValue != "-1" && ddlBillingAddressCountries.SelectedValue != "")
                {
                    billingAddressItem.Country = new Country() { Id = Convert.ToInt32(ddlBillingAddressCountries.SelectedValue) };
                    if (ddlBillingAddressCountries.SelectedValue == "2") //diğer
                    {
                        billingAddressItem.CountryName = txtBillingAddressCountryName.Text;
                    }
                }
                if (ddlBillingAddressCities.SelectedValue != "-1" && ddlBillingAddressCities.SelectedValue != "")
                {
                    billingAddressItem.City = new City() { Id = Convert.ToInt32(ddlBillingAddressCities.SelectedValue) };
                }
                if (txtBillingAddressCityName.Visible)
                {
                    billingAddressItem.CityName = txtBillingAddressCityName.Text;
                }
                if (ddlBillingAddressDistricts.SelectedValue != "-1" && ddlBillingAddressDistricts.SelectedValue != "")
                {
                    billingAddressItem.District = new District() { Id = Convert.ToInt32(ddlBillingAddressDistricts.SelectedValue) };
                }
                if (txtBillingAddressDistrictName.Visible)
                {
                    billingAddressItem.DistrictName = txtBillingAddressDistrictName.Text;
                }

                billingAddressItem.PostalCode = txtBillingAddressPostCode.Text;
                billingAddressItem.AddressDetail = txtBillingAddressLine.Text;
                billingAddressItem.Phone = txtBillingAddressPhone.Text;
                billingAddressItem.GSMPhone = txtBillingAddressGSMPhone.Text;
                AddressData.Insert(billingAddressItem);

                var returnValue = AddressData.Insert(billingAddressItem);
                if (returnValue > 0)
                {
                    lblBillingAddressAlert.Text = "Yeni fatura adresiniz başarıyla kaydedildi.";
                    lblBillingAddressAlert.ForeColor = System.Drawing.Color.Green;
                    ClearBillingForm();
                    pnlBillingAddress.Visible = false;
                    rblBillingAddresses.SelectedIndex = -1;
                }
                else
                {
                    lblBillingAddressAlert.Text = "Yeni fatura adresiniz kaydedilirken hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblBillingAddressAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            GetUserAddresses();
        }

        protected void imgbtnContinue_Click(object sender, ImageClickEventArgs e)
        {
            loginUser = (User)Session["LOGIN_USER"];
            basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
            if (rblShippingAddresses.SelectedIndex == -1)
            {
                string textForMessage = @"<script language='javascript'> alert('Teslimat adresi seçmelisiniz!');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
            else if (rblBillingAddresses.SelectedIndex == -1)
            {
                string textForMessage = @"<script language='javascript'> alert('Fatura adresi seçmelisiniz!');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
            }
            else
            {
                basket.BillingAddress = AddressData.Get(Convert.ToInt32(rblBillingAddresses.SelectedValue));
                basket.ShippingAddress = AddressData.Get(Convert.ToInt32(rblShippingAddresses.SelectedValue));
                Session.Add("USER_BASKET", basket);
                Response.Redirect("OrderShipping.aspx");
            }
        }

        protected void imgbtnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Pages/OrderBasket.aspx");
        }

        private void ClearShippingForm()
        {
            txtShippingAddressTitle.Text = string.Empty;
            txtShippingAddressFirstName.Text = string.Empty;
            txtShippingAddressLastName.Text = string.Empty;
            ddlShippingAddressCountries.SelectedIndex = 0;
            txtShippingAddressCountryName.Text = string.Empty;
            txtShippingAddressCountryName.Visible = false;
            txtShippingAddressCityName.Text = string.Empty;
            txtShippingAddressCityName.Visible = false;
            ddlShippingAddressCities.Items.Clear();
            txtShippingAddressDistrictName.Text = string.Empty;
            txtShippingAddressDistrictName.Visible = false;
            ddlShippingAddressDistricts.Items.Clear();
            txtShippingAddressPostCode.Text = string.Empty;
            txtShippingAddressLine.Text = string.Empty;
            txtShippingAddressPhone.Text = string.Empty;
            txtShippingAddressGSMPhone.Text = string.Empty;
            btnShippingAddressSave.CommandArgument = string.Empty;
            rblShippingAddresses.SelectedIndex = -1;
            lblShippingAddressAlert.Text = "";
        }

        private void ClearBillingForm()
        {
            txtBillingAddressTitle.Text = string.Empty;
            txtBillingAddressFirstName.Text = string.Empty;
            txtBillingAddressLastName.Text = string.Empty;
            ddlBillingAddressCountries.SelectedIndex = 0;
            txtBillingAddressCountryName.Text = string.Empty;
            txtBillingAddressCountryName.Visible = false;
            txtBillingAddressCityName.Text = string.Empty;
            txtBillingAddressCityName.Visible = false;
            ddlBillingAddressCities.Items.Clear();
            txtBillingAddressDistrictName.Text = string.Empty;
            txtBillingAddressDistrictName.Visible = false;
            ddlBillingAddressDistricts.Items.Clear();
            txtBillingAddressPostCode.Text = string.Empty;
            txtBillingAddressLine.Text = string.Empty;
            txtBillingAddressPhone.Text = string.Empty;
            txtBillingAddressGSMPhone.Text = string.Empty;
            btnBillingAddressSave.CommandArgument = string.Empty;
            rblBillingAddresses.SelectedIndex = -1;
            lblBillingAddressAlert.Text = "";
        }

        private void BindValues()
        {
            List<EnumValue> addressTypes = EnumValueData.GetEnumValues(10); //AddressTipleri

            List<Country> countryList = CountryData.GetCountryList();
            Utility.BindDropDownList(ddlShippingAddressCountries, countryList, "Name", "Id");
            ddlShippingAddressCountries.SelectedValue = "1"; //Türkiye default seçili geliyor. =>ayhant
            List<City> cityList = CityData.GetCityList(1); //Türkiyenin şehirlerini default getiriyoruz. =>ayhant
            Utility.BindDropDownList(ddlShippingAddressCities, cityList, "Name", "Id");

            Utility.BindDropDownList(ddlBillingAddressCountries, countryList, "Name", "Id");
            ddlBillingAddressCountries.SelectedValue = "1"; //Türkiye default seçili geliyor. =>ayhant
            Utility.BindDropDownList(ddlBillingAddressCities, cityList, "Name", "Id");
        }

        private void GetUserAddresses()
        {
            loginUser = (User)Session["LOGIN_USER"];
            basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
            List<Address> itemList = AddressData.GetMembershipAddresses(loginUser.Id);
            rblShippingAddresses.DataTextField = "Title";
            rblShippingAddresses.DataValueField = "Id";
            rblShippingAddresses.DataSource = itemList;
            rblShippingAddresses.DataBind();

            rblBillingAddresses.DataTextField = "Title";
            rblBillingAddresses.DataValueField = "Id";
            rblBillingAddresses.DataSource = itemList;
            rblBillingAddresses.DataBind();
        }
    }
}