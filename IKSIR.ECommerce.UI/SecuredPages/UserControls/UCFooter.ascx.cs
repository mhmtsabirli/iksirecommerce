using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.UI.SecuredPages.UserControls
{
    public partial class UCFooter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbtnSaveNewsletter_Click(object sender, ImageClickEventArgs e)
        {
            if (txtUserEmail.Text == "")
            {
                lblAlert.Text = "Bir e-posta adresi giriniz.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else if (!Toolkit.Utility.isEmail(txtUserEmail.Text))
            {
                lblAlert.Text = "Geçerli bir e-posta adresi giriniz.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                var item = new Newsletter();
                item.Email = txtUserEmail.Text;
                var list = NewsletterData.GetList();
                var existItem = list.Where(x => x.Email == txtUserEmail.Text).FirstOrDefault();
                if (existItem != null)
                {
                    lblAlert.Text = "Bu e-posta adresi zaten kayıtlı.";
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (NewsletterData.Insert(item) > 0)
                    {
                        lblAlert.Text = "E-posta adresi kaydınız başarıyla alınmıştır.";
                        lblAlert.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        lblAlert.Text = "E-posta adresi kaydınızı alırken bir hata oluştu lütfen daha sonra tekrar deneyiniz.";
                        lblAlert.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
}