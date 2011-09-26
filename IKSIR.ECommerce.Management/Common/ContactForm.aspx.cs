using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.AdminModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Toolkit;
using System.IO;


namespace IKSIR.ECommerce.Management.Common
{
    public partial class ContactForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["FormId"] != null)
                {
                    btnSave.CommandArgument = Request["FormId"].ToString();
                    lblId.Text = Request["FormId"].ToString();
                    GetItem(Convert.ToInt32(Request["FormId"].ToString()));
                }
                BindValues();
                GetList();
            }
        }

        private void GetItem(int itemId)
        {
            IKSIR.ECommerce.Model.SiteModel.ContactForm itemContactForm = ContactFormData.Get(new IKSIR.ECommerce.Model.SiteModel.ContactForm() { Id = itemId });

            lblId.Text = itemContactForm.Id.ToString();
            txtName.Text = itemContactForm.FirstLastName.ToString();
            txtEmail.Text = itemContactForm.Email.ToString();
            txtIp.Text = itemContactForm.Ip.ToString();
            txtMessage.Text = itemContactForm.Message.ToString();
            txtTitle.Text = itemContactForm.Title.ToString();
            txtSolution.Text = itemContactForm.Solution.ToString();

            if (itemContactForm.Status.Id == 11)
            {
                btnSave.Visible = false;
                lblError.Text = "Daha önce çözüm girlip müşteriye geri dönüş yapılmıştır.";
                lblError.Visible = true;
                    
            }
            pnlForm.Visible = true;

        }

        private void GetList()
        {


            List<IKSIR.ECommerce.Model.SiteModel.ContactForm> itemList = ContactFormData.GetContactFormList();
            if (ddlFilterStatus.SelectedValue != "-1" && ddlFilterStatus.SelectedValue != "")
            {
                int Status = DBHelper.IntValue(ddlFilterStatus.SelectedValue);
                itemList = itemList.Where(x => x.Status.Id == Status).ToList();
            }
            if (txtFilterTitle.Text != "")
            {
                string Title = txtFilterTitle.Text;
                itemList = itemList.Where(x => x.Title == Title).ToList();
            }
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.CommandArgument != "") //Kayıt güncelleme.
            {
                if (UpdateItem(Convert.ToInt32(btnSave.CommandArgument)))
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Item başarıyla güncellendi.";
                    ClearForm();
                    pnlForm.Visible = false;
                    int count = 0;
                    if (!SendMail())
                    {
                        lblError.Text = "Mail Gönderilirken Bir hata oluştu.";
                    }
                    GetList();
                }
                else
                {
                    lblError.Visible = true;
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Item güncellenirken bir hata oluştu.";
                }
            }

        }

        private bool SendMail()
        {
            string MailBody = "";
            MailBody = txtSolution.Text;

            bool retValueSendMail = Mail.sendMail(txtEmail.Text, "musterihizmetleri@senarinsaat.com.tr", "Senar İnşaat A.Ş. | İletişim Formu", MailBody);

            return retValueSendMail;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlList.Visible = true;
            pnlFilter.Visible = true;
        }

        protected void lbtnEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var itemId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            btnSave.CommandArgument = itemId.ToString();
            lblId.Text = itemId.ToString();
            GetItem(itemId);

        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            if (DeleteItem(itemId))
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Item başarıyla silindi.";
                GetList();
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Item silerken bir hata oluştu.";
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            List<EnumValue> itemListSite = EnumValueData.GetEnumValues(11);
            Utility.BindDropDownList(ddlFilterStatus, itemListSite, "Value", "Id");
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;

            try
            {
                if (ContactFormData.Update(itemId, txtSolution.Text) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update ContactForm";
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    itemSystemLog.Content = "itemId =" + itemId + " Solution= " + txtSolution;
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update ContactForm";
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                itemSystemLog.Content = "itemId =" + itemId + " Solution= " + txtSolution + " " + ex.Message.ToString();
                SystemLogData.Insert(itemSystemLog);

            }
            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new IKSIR.ECommerce.Model.SiteModel.ContactForm() { Id = itemId };
            try
            {
                if (ContactFormData.Delete(item) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete ContactForm";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ContactForm";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {

        }
    }
}
