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

        private void GetItem(int itemId)
        {
            IKSIR.ECommerce.Model.SiteModel.ContactForm itemContactForm = ContactFormData.Get(new IKSIR.ECommerce.Model.SiteModel.ContactForm() { Id = itemId });

            lblId.Text = itemContactForm.Id.ToString();
            txtName.Text = itemContactForm.FirstLastName.ToString();
            txtEmail.Text = itemContactForm.Email.ToString();
            txtIp.Text = itemContactForm.Ip.ToString();
            txtMessage.Text = itemContactForm.Message.ToString();
            txtTitle.Text = itemContactForm.Title.ToString();

            pnlForm.Visible = true;

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

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new IKSIR.ECommerce.Model.SiteModel.ContactForm() { Id = itemId };
            try
            {
                if (ContactFormData.Delete(item) < 0)
                    returnValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ContactForm";
                itemSystemLog.Content = "Id=" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ContactForm";
                itemSystemLog.Content = "Id=" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {

        }
        private bool UpdateItem(int itemId)
        {
            bool retValue = false;

            try
            {
                if (ContactFormData.Update(itemId, txtSolution.Text) < 0)
                    retValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Insert ContactFormData";
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Insert ContactFormData";
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }
        private void GetList()
        {


            List<IKSIR.ECommerce.Model.SiteModel.ContactForm> itemContactFormList = ContactFormData.GetContactFormList();

            gvList.DataSource = itemContactFormList;
            gvList.DataBind();
        }

    

        private void ClearForm()
        {
           
        }
    }
}
