using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IKSIR.ECommerce.UI.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
            }
        }

        private void BindValues()
        {
            for (int i = 0; i <= 31; i++)
            {
                ddlBirthDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateDay.Items.Insert(0, new ListItem("Gün", "-1"));
            for (int i = 0; i <= 12; i++)
            {
                ddlBirthDateMount.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateMount.Items.Insert(0, new ListItem("Ay", "-1"));
            for (int i = 2005; i > 1930; i--)
            {
                ddlBirthDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateYear.Items.Insert(0, new ListItem("Yıl", "-1"));
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (SaveForm())
            {
                lblAlert.Text = "Üye kaydınız başarıyla gerçekleşmiştir.";
                lblAlert.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblAlert.Text = "Üye kaydınız gerçekleşirken hata oluştu! Lütfen daha sonra tekrar deneyiniz.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        private bool SaveForm()
        {
            //Mail adresini kontrol et bu adresle kayıtlı bir üye varsa hata döndür.

            bool retValue = false;
            return retValue;
        }
    }
}