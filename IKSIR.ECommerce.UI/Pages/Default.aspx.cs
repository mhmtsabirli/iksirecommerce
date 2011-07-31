using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCShowCaseProducts1.ModuleId = 8;

        }
        protected void btnasd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}