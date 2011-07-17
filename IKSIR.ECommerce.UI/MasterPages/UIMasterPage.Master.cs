using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.MasterPages
{
    public partial class UIMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UCModuleBestSellingProducts.ModuleId = 1;
            UCModuleMostVisitedProducts.ModuleId = 2;
            UCModuleCampaignProducts.ModuleId = 3;
        }
    }
}