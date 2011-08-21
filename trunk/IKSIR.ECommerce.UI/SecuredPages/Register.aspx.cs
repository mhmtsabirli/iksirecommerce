using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.SiteModel;
using System.IO;

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
            for (int i = 1; i <= 31; i++)
            {
                ddlBirthDateDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateDay.Items.Insert(0, new ListItem("Gün", "-1"));
            for (int i = 1; i <= 12; i++)
            {
                ddlBirthDateMonth.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateMonth.Items.Insert(0, new ListItem("Ay", "-1"));
            for (int i = 2005; i > 1930; i--)
            {
                ddlBirthDateYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlBirthDateYear.Items.Insert(0, new ListItem("Yıl", "-1"));

            KeyGenerator item = new KeyGenerator();
            string key = item.GetUniqueKey(6, true, true, false);
            Session.Add("REGISTER_SECURITYCODE", key);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckForm())
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
        }

        private bool SaveForm()
        {
            bool retValue = false;
            try
            {
                var itemUser = new User();
                itemUser.BirthDate = new DateTime(DBHelper.IntValue(ddlBirthDateYear.SelectedValue), DBHelper.IntValue(ddlBirthDateMonth.SelectedValue), DBHelper.IntValue(ddlBirthDateDay.SelectedValue));
                itemUser.Email = txtEmail.Text;
                itemUser.FirstName = txtFirstName.Text;
                itemUser.LastName = txtLastName.Text;
                itemUser.Site = new Site() { Id = 1 };
                itemUser.Password = txtPassword.Text;
                int ret = UserData.Insert(itemUser);
                if (ret > 0)
                {
                    string MailBody = File.ReadAllText(HttpContext.Current.Request.MapPath("~") + "/MailTemplates/MembershipRegister.htm");
                    //string ActivationLink = System.Configuration.ConfigurationManager.AppSettings["WebAddress"] + "Membership/Activation.aspx?ActivationCode=" + strActivationCode + "&Email=" + User.Email;
                    MailBody = MailBody.Replace("%NameSurname%", txtFirstName.Text + " " + txtLastName.Text);
                    MailBody = MailBody.Replace("%ActivationLink%", "http://www.idevit.com.tr/");
                    MailBody = MailBody.Replace("%UserName%", txtEmail.Text);
                    MailBody = MailBody.Replace("%Password%", txtPassword.Text);
                    Mail.sendMail(txtEmail.Text, "helpdesk@idevit.com.tr", "İdevit A.Ş. | Üyelik Bilgileriniz", MailBody);
                    
                    string textForMessage = @"<script language='javascript'> alert('Üyelik işleminiz tamamlanmıştır. Üyelik esnasında belirtmiş olduğunuz e-mail adresinize siteye giriş bilgilerinizi yolladık.');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                }
                else
                {
                    string textForMessage = @"<script language='javascript'> alert('Üyeliğiniz kaydedilirken bir hata oluştu!');</script>";
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "UserPopup", textForMessage);
                }

                if (ret > 0)
                    retValue = true;
                else
                    retValue = false;
            }
            catch (Exception exception)
            {
                throw;
            }
            return retValue;
        }

        private bool CheckForm()
        {
            bool retValue = true;
            var item = UserData.Get(txtEmail.Text);
            if (item != null)
            {
                lblAlert.Text = "Bu email adresi kullanılıyor. Lütfen başka bir mail adresi giriniz.";
                txtEmail.Focus();
                lblAlert.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            return retValue;
        }
    }
}