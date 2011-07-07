using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            Page.Title += "Title";
            lblTitle.Text = "Title";
            lblDesciption.Text = "txtDescripiton";
            divContent.InnerHtml = "GetContent" + contentId;
        }
    }
}