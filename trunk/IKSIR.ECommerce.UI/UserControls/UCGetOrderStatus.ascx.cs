using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCGetOrderStatus : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SecuredPages/UserAccount/Orders.aspx?oid=" + txtOrderNo.Text);
        }
        protected void lbtnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SecuredPages/UserAccount/Orders.aspx?oid=" + txtOrderNo.Text);
        }
    }
}