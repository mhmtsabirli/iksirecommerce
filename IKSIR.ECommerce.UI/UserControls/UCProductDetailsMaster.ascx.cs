using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsMaster : System.Web.UI.UserControl
    {
        protected int productId = 0;
        public int ProductId
        {
            set { productId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}