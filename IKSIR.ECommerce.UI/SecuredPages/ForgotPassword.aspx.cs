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
            txtEmail.Focus();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            var user = GetEmail();
            if (user != null)
            {
                //Mail gönder
                string MailBody = File.ReadAllText(HttpContext.Current.Request.MapPath("~") + "/MailTemplates/ForgotPassword.htm");
                //string ActivationLink = System.Configuration.ConfigurationManager.AppSettings["WebAddress"] + "Membership/Activation.aspx?ActivationCode=" + strActivationCode + "&Email=" + User.Email;
                MailBody = MailBody.Replace("%NameSurname%", user.FirstName + " " + user.LastName);
                MailBody = MailBody.Replace("%ActivationLink%", "http://www.idevit.com.tr/");
                MailBody = MailBody.Replace("%UserName%", txtEmail.Text);
                MailBody = MailBody.Replace("%Password%", user.Password);
                bool retValue = Mail.sendMail(user.Email, "helpdesk@idevit.com.tr", "İdevit A.Ş. | Üyelik Bilgileriniz", MailBody);
                if (retValue)
                {
                    lblAlert.Text = "Şifreniz mail adresinize gönderilmiştir.";
                    lblAlert.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAlert.Text = "Şifreniz mail adresinize göndeririken bir hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAlert.Text = "Bu mail adresiyle kayıtlı bir üyemiz bulunmamaktadır.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
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