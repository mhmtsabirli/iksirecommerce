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

        protected void lbtnSaveToList_Click(object sender, EventArgs e)
        {
            if (!Toolkit.Utility.isEmail(txtUserEmail.Text))
            {
                string error = "E-bülten aboneliği için hatalı mail adresi girdiniz.";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "err_msg", "alert('" + error + "');", true);
                txtUserEmail.Focus();
                return;
            }

            var item = new Newsletter();
            item.Email = txtUserEmail.Text;
            var list = NewsletterData.GetList();
            var existItem = list.Where(x => x.Email == txtUserEmail.Text).FirstOrDefault();
            if (existItem != null)
            {
                lblAlert.Text = "Bu mail adresi zaten kayıtlı.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (NewsletterData.Insert(item) > 0)
                {
                    lblAlert.Text = "Mail kaydınız başarıyla alınmıştır.";
                    lblAlert.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAlert.Text = "Mail kaydınızı alırken bir hata oluştu lütfen daha sonra tekrar deneyiniz.";
                    lblAlert.ForeColor = System.Drawing.Color.Red;
                }
            }
            txtUserEmail.Focus();
        }
    }
}