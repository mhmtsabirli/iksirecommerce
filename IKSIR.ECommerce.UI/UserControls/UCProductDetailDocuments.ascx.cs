using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailDocuments : UCProductDetailsMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && productId != 0)
            {
                GetProductDocuments(productId);
            }
        }

        private void GetProductDocuments(int productId)
        {
            try
            { }
            catch (Exception exception)
            {
            }
        }
    }
}