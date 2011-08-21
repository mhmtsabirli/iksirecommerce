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
        public static User loginUser = null;
        public static Basket basket = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
                GetUserAddresses();
            }

            if (Session["LOGIN_USER"] != null && Session["USER_BASKET"] != null)
            {
                if (!Page.IsPostBack)
                {
                    loginUser = (User)Session["LOGIN_USER"];
                    basket = (Basket)HttpContext.Current.Session["USER_BASKET"];
                    GetUserAddresses();
                }
            }
            else
            {
                Response.Redirect("../SecuredPages/Login.aspx?returl=../Pages/OrderBasket.aspx");
            }
        }

        private void BindValues()
        {
            List<EnumValue> addressTypes = EnumValueData.GetEnumValues(10); //AddressTipleri
            Utility.BindDropDownList(ddlShippingAddressType, addressTypes, "Value", "Id");

            List<Country> countryList = CountryData.GetCountryList();
            Utility.BindDropDownList(ddlShippingAddressCountries, countryList, "Name", "Id");
            ddlShippingAddressCountries.SelectedValue = "1"; //Türkiye default seçili geliyor. =>ayhant
            List<City> cityList = CityData.GetCityList(1); //Türkiyenin şehirlerini default getiriyoruz. =>ayhant
            Utility.BindDropDownList(ddlShippingAddressCities, cityList, "Name", "Id");

            Utility.BindDropDownList(ddlBillingAddressType, addressTypes, "Value", "Id");
            Utility.BindDropDownList(ddlBillingAddressCountries, countryList, "Name", "Id");
            ddlBillingAddressCountries.SelectedValue = "1"; //Türkiye default seçili geliyor. =>ayhant
            Utility.BindDropDownList(ddlBillingAddressCities, cityList, "Name", "Id");
        }

        private void GetUserAddresses()
        {
            List<Address> itemList = AddressData.GetMembershipAddresses(1);
            rblShippingAddresses.DataTextField = "Title";
            rblShippingAddresses.DataValueField = "Id";
            rblShippingAddresses.DataSource = itemList;
            rblShippingAddresses.DataBind();

            rblBillingAddresses.DataTextField = "Title";
            rblBillingAddresses.DataValueField = "Id";
            rblBillingAddresses.DataSource = itemList;
            rblBillingAddresses.DataBind();
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
                    ddlShippingAddressDistricts.Visible = true;
                    txtCity.Visible = false;
                    txtDistrict.Visible = false;
                }
                else
                {
                    //Türkiye dışında bir ülke seçerse city/distrcit textbox olacak.
                    ddlShippingAddressCities.Items.Clear();
                    ddlShippingAddressCities.Visible = false;
                    ddlShippingAddressDistricts.Visible = false;
                    txtCity.Visible = true;
                    txtDistrict.Visible = true;
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
            int countryId = -1;
            int.TryParse(ddlBillingAddressCountries.SelectedValue, out countryId);

            if (countryId != -1)
            {
                if (countryId == 1) //Türkiye ise
                {
                    List<City> cityList = CityData.GetCityList(countryId);
                    Utility.BindDropDownList(ddlBillingAddressCities, cityList, "Name", "Id");

                    ddlBillingAddressCities.Visible = true;
                    ddlBillingAddressDistricts.Visible = true;
                    txtCity.Visible = false;
                    txtDistrict.Visible = false;
                }
                else
                {
                    //Türkiye dışında bir ülke seçerse city/distrcit textbox olacak.
                    ddlBillingAddressCities.Items.Clear();
                    ddlBillingAddressCities.Visible = false;
                    ddlBillingAddressDistricts.Visible = false;
                    txtCity.Visible = true;
                    txtDistrict.Visible = true;
                }
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

        protected void btnShippingAddressSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnBillingAddressSave_Click(object sender, EventArgs e)
        {

        }

        protected void rblShippingAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rblBillingAddresses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void imgbtnContinue_Click(object sender, ImageClickEventArgs e)
        {
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
    }
}