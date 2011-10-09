using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Toolkit;
using System.IO;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Email girmelisiniz.</span><br />";
                txtEmail.Focus();
                return;
            }

            var user = GetEmail();
            if (user != null)
            {
                //Mail gönder
                string MailBody = File.ReadAllText(HttpContext.Current.Request.MapPath("~") + "/MailTemplates/ForgotPassword.htm");
                //string ActivationLink = System.Configuration.ConfigurationManager.AppSettings["WebAddress"] + "Membership/Activation.aspx?ActivationCode=" + strActivationCode + "&Email=" + User.Email;
                MailBody = MailBody.Replace("%NameSurname%", user.FirstName + " " + user.LastName);
                MailBody = MailBody.Replace("%ActivationLink%", "http://www.senarinsaat.com.tr/");
                MailBody = MailBody.Replace("%UserName%", txtEmail.Text);
                MailBody = MailBody.Replace("%Password%", user.Password);
                bool retValue = Mail.sendMail(user.Email, "musterihizmetleri@senarinsaat.com.tr", "Senar İnşaat A.Ş. | Şifre Hatırlatma", MailBody);
                if (retValue)
                {
                    divAlert.InnerHtml += "<span style=\"color:Green\">Şifreniz mail adresinize gönderilmiştir.</span><br />";
                }
                else
                {
                    divAlert.InnerHtml += "<span style=\"color:Red\">Şifreniz mail adresinize göndeririken bir hata oluştu lütfen daha sonra tekrar deneyiniz.</span><br />";
                }
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Bu mail adresiyle kayıtlı bir üyemiz bulunmamaktadır.</span><br />";
            }
        }

        private User GetEmail()
        {
            User retValue = null;
            var user = UserData.Get(txtEmail.Text);
            if (user != null)
            {
                retValue = user;
            }
            return retValue;
        }
    }
}