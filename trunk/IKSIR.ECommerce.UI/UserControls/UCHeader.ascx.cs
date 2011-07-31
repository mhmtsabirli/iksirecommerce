using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGIN_USER"] != null)
            {
                User loginUser = (User)Session["LOGIN_USER"];
                pnlLoginUser.Visible = true;
                lblUserTitle.Text = "Sayın " + loginUser.FirstName + " " + loginUser.LastName;
            }
            else
            {
                pnlLoginUser.Visible = false;
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("LOGIN_USER");
            Response.Redirect("Default.aspx");
        }
    }
}