using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsProductInfos : UCProductDetailsMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && productId != 0)
            {
                GetProductInfos();
            }
        }

        private void GetProductInfos()
        {
            try
            {
                var productPropertyList = ProductPropertyData.GetProductProperties(productId);
                gvProductProperties.DataSource = productPropertyList;
                gvProductProperties.DataBind();                
            }
            catch (Exception exception)
            {
            }
        }
    }
}