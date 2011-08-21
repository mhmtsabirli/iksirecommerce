using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.Management
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == System.Configuration.ConfigurationSettings.AppSettings["UserName"].ToString() && txtPass.Text == System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString())
            {
                Session["Login"] = "idevit";
                Response.Redirect("../Pages/Default.aspx");
            }
            else
            {
                dvalert.Visible = true;
                dvalert.InnerHtml = "<span style=\"color:Red\">Kullanıcı adı veya şifre hatalı</span><br />";
            }
                
        }
    }
}