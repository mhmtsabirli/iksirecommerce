using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer;

namespace IKSIR.ECommerce.Management.Products
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string  xml = "", xsl = "";
            int ParentId = 0;

            if (Request.QueryString["ParentId"] == null)
                xsl = "tree//roottree.xsl";

            else
                ParentId = IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock.DBHelper.IntValue(Request.QueryString["ParentId"]);
            string s = Request.QueryString["ParentId"];


            try
            {

                xml += IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer.ProductCategoryData.GetProductCategory(ParentId);

                if (xml != "" && Request.QueryString["ParentId"] != null)
                    xml = "<SiteMap>" + xml + "</SiteMap>";
                else
                    xml = "<?xml:stylesheet type=\"text/xsl\" href=\"" + xsl + "\" ?>\n" + "<SiteMap>" + xml + "</SiteMap>";
                Response.Write(xml);

            }
            catch (Exception ex) { string msg = ex.Message; }

        }
    }
}