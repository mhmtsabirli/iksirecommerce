using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.AdminModel;
using System.Reflection;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonData;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddressData item = new AddressData();
            var itemlist = item.GetMembershipAddresses(1, 1);
        }
    }
}
