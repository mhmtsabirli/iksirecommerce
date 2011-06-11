using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonData;
using IKSIR.ECommerce.Model.CommonModel;


namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              AddressData item = new AddressData();
             List<Address> addressList = item.WebGetMembershipAddresses(1,1);
        
        }
    }
}
