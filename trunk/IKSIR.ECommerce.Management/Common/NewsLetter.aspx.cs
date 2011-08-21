using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Management.MasterPage;

namespace IKSIR.ECommerce.Management.Common
{
    public partial class NewsLetter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
                GetList();
            }
        }

        private void GetItem(int itemId)
        {

            IKSIR.ECommerce.Model.CommonModel.Newsletter item = NewsletterData.Get(itemId);


            lblMail.Text = item.Email.ToString();
            chAcktive.Checked = item.IsActive;


            pnlForm.Visible = true;

        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<IKSIR.ECommerce.Model.CommonModel.Newsletter> itemList = NewsletterData.GetList();

            if (txtFilterEmail.Text != "")
                itemList = itemList.Where(x => x.Email == txtFilterEmail.Text).ToList();

            
                itemList = itemList.Where(x => x.IsActive == chkFilter.Checked).ToList();

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

     

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            //Enum da buna gerek yok


        }


        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.CommonModel.Newsletter();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            item.Id = itemId;
            item.IsActive = chAcktive.Checked;
            try
            {
                if (NewsletterData.Update(itemId,item.IsActive)<0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update NewsLetter";
                    itemSystemLog.Content = "Id" + item.Id + "IsActive" + item.IsActive;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch(Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update NewsLetter";
                itemSystemLog.Content = "Id" + item.Id + "IsActive" + item.IsActive + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }


        private void ClearForm()
        {
            lblMail.Text = string.Empty;
            chAcktive.Checked = false;
            btnSave.CommandArgument = string.Empty;
        }
    }
}