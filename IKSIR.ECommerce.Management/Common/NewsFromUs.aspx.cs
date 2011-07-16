using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Management.MasterPage;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Toolkit;

namespace IKSIR.ECommerce.Management.Common
{
    public partial class NewsFromUs : System.Web.UI.Page
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
            var item = NewsData.Get(itemId);
            if (item != null)
            {
                ddlSites.SelectedValue = item.Site.Id.ToString();
                txtTitle.Text = item.Title;
                RadEditorPageContent.Content = item.PageContent;
                pnlForm.Visible = true;
            }
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Item getirilirken bir hata oluştu.";
            }
        }

        private void GetList()
        {
            List<News> itemList = NewsData.GetList();
            if (txtFilterTitle.Text != "")
                itemList=itemList.Where(x => x.Title==txtFilterTitle.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtTitle.Focus();
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
            else //Yeni kayıt
            {
                if (InsertItem())
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
                    lblError.Text += "Item kaydedilirken bir hata oluştu.";
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
            List<Site> itemListSite = SiteData.GetSiteList();
            Utility.BindDropDownList(ddlSites, itemListSite, "Name", "Id");
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var itemList = NewsData.GetList();
            var item = itemList.Where(x => x.Title == txtTitle.Text).FirstOrDefault();
            if (item != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                item = new News();
                if (ddlSites.SelectedValue != "-1")
                    item.Site = new Model.SiteModel.Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
                item.Title = txtTitle.Text.Trim();
                item.PageContent = RadEditorPageContent.Content;
                try
                {
                    if (NewsData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Yeni statik sayfa kaydedildi.";
                        itemSystemLog.Content = "Title: " + item.Title;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception exception)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Yeni static sayfa kaydedilirken hata oluştu.";
                    itemSystemLog.Content = "Title: " + item.Title + " Hata: " + exception.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            News item = NewsData.Get(itemId);
            item.EditAdminId = 11;
            if (ddlSites.SelectedValue != "-1")
                item.Site = new Model.SiteModel.Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
            item.Title = txtTitle.Text;
            item.PageContent = RadEditorPageContent.Content;
            try
            {
                if (NewsData.Update(item) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Statik sayfa güncellendir.";
                    itemSystemLog.Content = "Id: " + item.Id + "Title: " + item.Title;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Statik sayfa güncellenirken hata oluştu!";
                itemSystemLog.Content = "Id: " + item.Id + "Title: " + item.Title + "Hata: " + exception.ToString(); ;
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            try
            {
                if (NewsData.Delete(itemId) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Statik sayfa silindi.";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Statik sayfa silerken hata oluştu!";
                itemSystemLog.Content = "Id=" + itemId + "Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            ddlSites.SelectedIndex = -1;
            txtTitle.Text = string.Empty;
            RadEditorPageContent.Content = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}