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


namespace IKSIR.ECommerce.Management.Admin
{
    public partial class Admin : System.Web.UI.Page
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
            IKSIR.ECommerce.Model.AdminModel.Admin itemAdmin = AdminData.Get(new IKSIR.ECommerce.Model.AdminModel.Admin() { Id = itemId });

            txtName.Text = itemAdmin.Name.ToString();
            txtUserName.Text = itemAdmin.UserName.ToString();
            txtPassword.Text = itemAdmin.Password.ToString();
            txtTryCount.Text = itemAdmin.TryCount.ToString();
            txtEmail.Text = itemAdmin.Email.ToString();

            if (itemAdmin.Status != null)
                ddlStatus.SelectedValue = itemAdmin.Status.Id.ToString();
            else
                ddlStatus.SelectedValue = "-1";

            if (itemAdmin.Site != null)
                ddlSites.SelectedValue = itemAdmin.Site.Id.ToString();
            else
                ddlStatus.SelectedValue = "-1";

            pnlForm.Visible = true;

        }

        private void GetList()
        {

            List<IKSIR.ECommerce.Model.AdminModel.Admin> itemList = AdminData.GetAdminList();

            if (txtFilterUserName.Text != "")
                itemList = itemList.Where(x => x.UserName == txtFilterUserName.Text).ToList();
            if (ddlFilterSite.SelectedValue != "-1" && ddlFilterSite.SelectedValue != "")
            {
                var item = new Site() { Id = Convert.ToInt32(ddlFilterSite.SelectedValue) };
                itemList = itemList.Where(x => x.Site.Id == item.Id).ToList();
            }
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtName.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveItem())
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Item başarıyla kaydedildi.";
                ClearForm();
                pnlForm.Visible = false;
                GetList();
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Item kaydedilirken bir hata oluştu.";
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
            //Buralarda tüm kategoriler gelecek istediği kategorinin altına tanımlama yapabilecek.
            List<Site> itemListSite = SiteData.GetSiteList();
            List<EnumValue> itemListStatus = EnumValueData.GetEnumValues(3);//status alanııcın olan durumlar

            ddlSites.DataSource = itemListSite;
            ddlSites.DataTextField = "Name";
            ddlSites.DataValueField = "Id";
            ddlSites.DataBind();

            ddlStatus.DataSource = itemListStatus;
            ddlStatus.DataTextField = "Value";
            ddlStatus.DataValueField = "Id";
            ddlStatus.DataBind();

            ddlFilterSite.DataSource = itemListSite;
            ddlFilterSite.DataTextField = "Name";
            ddlFilterSite.DataValueField = "Id";
            ddlFilterSite.DataBind();

            ddlStatus.Items.Insert(0, new ListItem("Seçiniz", "-1"));
            ddlSites.Items.Insert(0, new ListItem("Seçiniz", "-1"));
            ddlFilterSite.Items.Insert(0, new ListItem("Seçiniz", "-1"));
        }

        private bool SaveItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.AdminModel.Admin();


            item.Id = DBHelper.IntValue(lblId.Text.ToString());
            item.Site = new Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
            item.Status = new EnumValue() { Id = Convert.ToInt32(ddlStatus.SelectedValue) };
            item.UserName = txtUserName.Text.Trim();
            item.Email = txtEmail.Text.Trim();
            item.Name = txtName.Text.Trim();
            item.Password = txtPassword.Text.Trim();

            try
            {
                if (AdminData.Save(item) > 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Save Admin";
                    itemSystemLog.Content = "Name=" + item.Name + "UserName =" + item.UserName + "Password=" + item.Password + "Eamil=" + item.Email + "Site=" + item.Site.Id;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Save Admin";
                itemSystemLog.Content = "Name=" + item.Name + "UserName =" + item.UserName + "Password=" + item.Password + "Eamil=" + item.Email + "Site=" + item.Site.Id + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new IKSIR.ECommerce.Model.AdminModel.Admin() { Id = itemId };
            try
            {
                if (AdminData.Delete(item) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete Admin";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Admin";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            ddlSites.SelectedIndex = -1;
            ddlStatus.SelectedIndex = -1;
            txtName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtTryCount.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}
