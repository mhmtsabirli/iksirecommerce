using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
            else
            {
                lblAlert.Text = "Kullanıcı adı ve/veya şifreniz hatalı.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool LoginUser()
        {
            bool retValu = false;

            return retValu;
        }
    }
}