using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using System.IO;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.Management.MasterPage
{
    public partial class MasterManagement : System.Web.UI.MasterPage
    {
        public string Alert
        {
            set
            {
                this.divAlert.InnerHtml += value;
            }
        }

        public string ClearAlert
        {
            set
            {
                divAlert.InnerHtml = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}