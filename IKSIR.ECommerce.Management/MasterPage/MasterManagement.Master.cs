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
        public int MinStokCount = 0;
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

            if (Session["LOGIN_ADMIN"] != null)
            {
                Model.AdminModel.Admin admin = (Model.AdminModel.Admin)Session["LOGIN_ADMIN"];
                if (admin.Email != null)
                {

                    itemContactFormList = ContactFormData.GetContactFormList(10);
                    MinStokCount = ProductData.CheckProductStockCount();
                }
                else
                // Response.Redirect("Login.aspx");
                Response.Redirect("http://www.banyom.com.tr/management/Login.aspx");
            }
            else
                //Response.Redirect("Login.aspx");
                Response.Redirect("http://www.banyom.com.tr/management/Login.aspx");
        }
    }
}