using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;

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
                lblAlert.Text = "Mesajınız gönderilmiştir.";
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
            var itemContactForm = new IKSIR.ECommerce.Model.SiteModel.ContactForm();
            itemContactForm.FirstLastName = txtName.Text;
            itemContactForm.Email = txtEmail.Text;
            itemContactForm.Title = txtTitle.Text;
            itemContactForm.Message = txtContent.Text;
            itemContactForm.Status = new Model.CommonModel.EnumValue() { Id = 1 };
            if (ContactFormData.Insert(itemContactForm) > 0)
            {
                ClearFrom();
                retValue = true;
            }
            return retValue;
        }

        private void ClearFrom()
        {
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
        }
    }
}