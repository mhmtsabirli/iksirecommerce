using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginUser())
            {
                //Eğer sorunsuz login olursa requeste returl varsa o sayfaya yönlendir.
                if (Request.QueryString["returl"] != null && Request.QueryString["returl"].ToString() != "")
                {
                    Response.Redirect(Request.QueryString["returl"].ToString());
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                lblAlert.Text = "Kullanıcı adı ve/veya şifreniz hatalı.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
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
            return retValue;
        }
    }
}