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
    public partial class UserInfos : System.Web.UI.Page
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
                BindUserInfosForm();
                GetUserInfos();
            }
        }

        private void GetUserInfos()
        {
            loginUser = (User)Session["LOGIN_USER"];
            BindUserInfosForm();
            var itemUser = new User();
            itemUser = UserData.Get(loginUser.Id);
            txtUserInfoFirstName.Text = itemUser.FirstName;
            txtUserInfoLastName.Text = itemUser.LastName;
            txtUserInfoEmail.Text = itemUser.Email;
            ddlUserInfoBirthDateDay.SelectedValue = itemUser.BirthDate.Day.ToString();
            ddlUserInfoBirthDateMonth.SelectedValue = itemUser.BirthDate.Month.ToString();
            ddlUserInfoBirthDateYear.SelectedValue = itemUser.BirthDate.Year.ToString();
            txtUserInfoMobilePhone.Text = itemUser.MobilePhone;
            txtUserInfoTCIdentity.Text = itemUser.TcId;
        }

        private void BindUserInfosForm()
        {
            for (int i = 1; i <= 31; i++)
            {
                ddlUserInfoBirthDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlUserInfoBirthDateDay.Items.Insert(0, new ListItem("Gün", "-1"));
            for (int i = 1; i <= 12; i++)
            {
                ddlUserInfoBirthDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlUserInfoBirthDateMonth.Items.Insert(0, new ListItem("Ay", "-1"));
            for (int i = 2005; i > 1930; i--)
            {
                ddlUserInfoBirthDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlUserInfoBirthDateYear.Items.Insert(0, new ListItem("Yıl", "-1"));

            KeyGenerator item = new KeyGenerator();
            string key = item.GetUniqueKey(6, true, true, false);
            Session.Add("REGISTER_SECURITYCODE", key);
        }

        private bool CheckUserInfoForm()
        {
            bool retValue = true;
            divAlert.InnerHtml = "";
            if (txtUserInfoFirstName.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Ad alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtUserInfoLastName.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Soyad alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtUserInfoEmail.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/E-posta alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (!Toolkit.Utility.isEmail(txtUserInfoEmail.Text))
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Eposta için geçerli bir e-posta giriniz.</span><br />";
                retValue = false;
            }
            if (ddlUserInfoBirthDateDay.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Doğum Tarihi gün alanını seçiniz.</span><br />";
                retValue = false;
            }
            if (ddlUserInfoBirthDateMonth.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Doğum Tarihi ay alanını seçiniz.</span><br />";
                retValue = false;
            }
            if (ddlUserInfoBirthDateYear.SelectedValue == "-1")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Doğum Tarihi yıl alanını seçiniz.</span><br />";
                retValue = false;
            }
            if (txtUserInfoMobilePhone.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/Cep Telefonu alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtUserInfoTCIdentity.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Üye Bilgilerim/TC Kimlik Numarası alanı zorunlu.</span><br />";
                retValue = false;
            }
            return retValue;
        }

        protected void btnUserInfoSave_Click(object sender, EventArgs e)
        {
            if (!CheckUserInfoForm())
            {
                return;
            }
            loginUser = (User)Session["LOGIN_USER"];
            User itemUser = loginUser;
            itemUser.Id = loginUser.Id;
            itemUser.FirstName = txtUserInfoFirstName.Text;
            itemUser.LastName = txtUserInfoLastName.Text;
            itemUser.Email = txtUserInfoEmail.Text;
            itemUser.BirthDate = new DateTime(DBHelper.IntValue(ddlUserInfoBirthDateYear.SelectedValue), DBHelper.IntValue(ddlUserInfoBirthDateMonth.SelectedValue), DBHelper.IntValue(ddlUserInfoBirthDateDay.SelectedValue));
            itemUser.MobilePhone = txtUserInfoMobilePhone.Text;
            itemUser.TcId = txtUserInfoTCIdentity.Text;
            int retValue = UserData.Update(itemUser);
            if (retValue > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Bilgileriniz başarıyla güncellendi.</span><br />";
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Bilgileriniz güncellenirken hata oluştu. Lütfen daha sonra tekrar deneyiniz.</span><br />";
            }
        }
    }
}