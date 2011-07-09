using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.StaticData;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class Content : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = IKSIR.ECommerce.Infrastructure.StaticData.Idevit.SiteTitle;
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cid"] != null && Request.QueryString["cid"].ToString() != "")
                {
                    int contentId;
                    if (int.TryParse(Request.QueryString["cid"].ToString(), out contentId))
                        GetContent(contentId);
                }
            }
        }

        private void GetContent(int contentId)
        {
            try
            {
                var itemasd = System.Configuration.ConfigurationSettings.AppSettings["IdevitProdConnectionString"].ToString();
                StaticPage item = StaticPageData.Get(contentId);
                Page.Title += item.Title;
                //lblTitle.Text = item.Title;
                //lblDesciption.Text = item.D
                divContent.InnerHtml = item.PageContent;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}