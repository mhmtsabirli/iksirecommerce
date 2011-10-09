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
    public partial class ChangePassword : System.Web.UI.Page
    {
        public User loginUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] == null)
            {
                Response.Redirect("../Login.aspx?returl=" + Request.Url.PathAndQuery);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (!CheckChangePasswordForm())
            {
                return;
            }
            loginUser = (User)Session["LOGIN_USER"];
            User itemUser = loginUser;
            itemUser.Password = txtChangePassword_Password.Text;
            int retValue = UserData.Update(itemUser);
            if (retValue > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Şifreniz başarıyla güncellendi.</span><br />";

            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Şifreniz güncellenirken hata oluştu. Lütfen daha sonra tekrar deneyiniz.</span><br />";

            }
        }

        private bool CheckChangePasswordForm()
        {
            bool retValue = true;
            divAlert.InnerHtml = "";
            if (txtChangePassword_Password.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Şifre Değiştir/Yeni Şifre alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtChangePassword_PasswordAgain.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Şifre Değiştir/Yeni Şifre Tekrar alanı zorunlu.</span><br />";
                retValue = false;
            }
            if (txtChangePassword_Password.Text != txtChangePassword_PasswordAgain.Text)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Şifre Değiştir/Yeni Şifre ve Yeni Şifre Tekrar aynı olmalı.</span><br />";
                retValue = false;
            }
            if (txtExPassword.Text != loginUser.Password)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Şifre Değiştir/Eski parolanınızı kontrol ediniz.</span><br />";
                txtExPassword.Text = string.Empty;
                retValue = false;
            }
            if (txtChangePassword_Password.Text != txtChangePassword_PasswordAgain.Text)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Adreslerim/Soyad alanı zorunlu.</span><br />";
                retValue = false;
            }
            return retValue;
        }
    }
}