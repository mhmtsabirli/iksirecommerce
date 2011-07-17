using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Imaging;
using IKSIR.ECommerce.Toolkit;
public partial class DynamicPicture : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["REGISTER_SECURITYCODE"] != null && Session["REGISTER_SECURITYCODE"].ToString() != "")
        {
            string key = Session["REGISTER_SECURITYCODE"].ToString();
            Captcha captcha = new Captcha(key, 200, 40, "Century Schoolbook");

            this.Response.Clear();
            this.Response.ContentType = "image/jpeg";

            captcha.Image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
            captcha.Dispose();
        }
    }
    
}
