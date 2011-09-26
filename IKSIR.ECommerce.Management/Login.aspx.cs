using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer;

namespace IKSIR.ECommerce.Management
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (LoginUser())
            {
                Session["Login"] = "idevit";
               Response.Redirect("http://www.banyom.com.tr/management/Default.aspx");
              // Response.Redirect("Default.aspx");
            }
        }

        private bool LoginUser()
        {
            bool retValue = false;
            Model.AdminModel.Admin admin = AdminData.Get(txtUserName.Text, txtPass.Text);
            if (admin != null)
            {
                Session.Add("LOGIN_ADMIN", admin);
                retValue = true;
            }
            else
            {
                dvalert.Visible = false;
                dvalert.InnerHtml = "<span style=\"color:Red\">Kullanıcı adı veya şifre hatalı</span><br />";
            }
            return retValue;
        }
    }
}