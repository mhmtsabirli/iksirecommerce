using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.UI
{
    public class Global : System.Web.HttpApplication
    {

        void Application_BeginRequest(Object sender, EventArgs e)
        {
            // stop sql injection attacks and redirect to homepage
            HttpContext context = HttpContext.Current;
            string req = string.Empty;
            string newpath = string.Empty;
            string oldpath = context.Request.Path;
            string currentpath = context.Request.Url.ToString();
            string scheme = context.Request.Url.Scheme.ToString().ToLower();

            if (currentpath.IndexOf("?") > 0)
            {
                req = currentpath.ToLower().Split('?')[1];
                if (req.IndexOf(" ") >= 0 || req.IndexOf("'") >= 0 || req.IndexOf("insert") >= 0 || req.IndexOf("(") >= 0 || req.IndexOf(")") >= 0 || req.IndexOf("update") >= 0 || req.IndexOf("table") >= 0 || req.IndexOf("delete") >= 0 || req.IndexOf("select") >= 0 || req.IndexOf("--") >= 0)
                {
                    newpath = "/pages/default.aspx";
                }
                else
                {
                    newpath = oldpath;
                }
            }
            else
            {
                newpath = oldpath;
            }

            if (currentpath.IndexOf("SecuredPages") < 0 && scheme == "https")
            {
                newpath = currentpath.Replace("https", "http");
                Response.Redirect(newpath);
            }
            else if (currentpath.IndexOf("SecuredPages") > 0 && scheme == "http")
            {
                newpath = currentpath.Replace("http", "https");
                Response.Redirect(newpath);
            }
            else
            {
                context.RewritePath(newpath);
            }
        }

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}