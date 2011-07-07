using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (SendForm())
            {
                lblAlert.Text = "Mesajınız elimize ulaşmıştır.";
                lblAlert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAlert.Text = "Mesajınız gönderilirken bir hata oluştu lütfen daha sonra tekrar deneyiniz.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool SendForm()
        {
            bool retValue = false;
            return retValue;
        }
    }
}