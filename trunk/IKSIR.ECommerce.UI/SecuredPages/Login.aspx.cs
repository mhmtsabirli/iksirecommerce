using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;

namespace IKSIR.ECommerce.UI.SecuredPages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">E-posta alanı zorunlu.</span><br />";
                return;
            }
            if (!Toolkit.Utility.isEmail(txtEmail.Text))
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Geçerli bir e-posta giriniz.</span><br />";
                return;
            }
            if (txtPassword.Text == "")
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Şifre alanı zorunlu.</span><br />";
                return;
            }

            if (LoginUser())
            {
                //Eğer sorunsuz login olursa requeste returl varsa o sayfaya yönlendir.
                if (Request.QueryString["returl"] != null && Request.QueryString["returl"].ToString() != "")
                {
                    Response.Redirect(Request.QueryString["returl"].ToString());
                }
                else
                {
                    Response.Redirect("../Pages/Default.aspx");
                }
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Kullanıcı adı ve/veya şifreniz hatalı.</span><br />";
            }
            ClientScript.GetPostBackEventReference(this, "");
        }

        private bool LoginUser()
        {
            bool retValue = false;
            var user = UserData.Get(txtEmail.Text, txtPassword.Text);
            if (user != null)
            {
                Session.Add("LOGIN_USER", user);
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Kullanıcı adı ve/veya şifreniz hatalı.</span><br />";
            }
            return retValue;
        }
    }
}