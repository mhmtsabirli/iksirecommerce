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
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Management.MasterPage
{
    public partial class MasterManagement : System.Web.UI.MasterPage
    {
        public List<IKSIR.ECommerce.Model.SiteModel.ContactForm> itemContactFormList = null;
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

            itemContactFormList = ContactFormData.GetContactFormList(10);
        }
    }
}