using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Management.Common;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;

namespace IKSIR.ECommerce.Management.ProductManagement
{
    public partial class SiteCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
                GetList();
            }
        }

        private bool GetItem(int itemId)
        {
            bool retValue = false;
            try
            {
                var item = SiteCategoryData.GetById(itemId);

                ddlSite.SelectedValue = item.Site.Id.ToString();
                ddlParentCategories.SelectedValue = item.ProductCategory.Id.ToString();
                pnlForm.Visible = true;

                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "GetSiteCategories";
                itemSystemLog.Content = "Id=" + itemId.ToString() + " ile alanlar doldurulamadı. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }

        private void GetList()
        {
            List<SiteCategory> itemList = SiteCategoryData.GetSiteCategoryList();

            if (ddlFilterSite.SelectedValue != "-1")
            {
                int SiteId = Convert.ToInt32(ddlFilterSite.SelectedValue);
                itemList = itemList.Where(x => x.Site.Id == SiteId).ToList();
            }

            gvList.DataSource = itemList;
            gvList.DataBind();
            ClearForm();
            pnlForm.Visible = false;

        }

        private void BindValues()
        {
            List<Site> itemListSite = SiteData.GetSiteList();
            List<ProductCategory> itemList = ProductCategoryData.GetParentProductCategoryList();
            Utility.BindDropDownList(ddlSite, itemListSite, "Name", "Id");
            Utility.BindDropDownList(ddlParentCategories, itemList, "Title", "Id");
            Utility.BindDropDownList(ddlFilterSite, itemListSite, "Name", "Id");


        }
        private void ClearForm()
        {
            ddlSite.SelectedValue = "-1";
            lblId.Text = "Yeni Kayıt";
            ddlParentCategories.SelectedValue = "-1";
        }
        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            ddlSite.Focus();
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
                    lblError.Text += " Item kaydedilirken bir hata oluştu.";
                }
            }
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new SiteCategory();

            List<SiteCategory> itemList = null;

            if (ddlParentCategories.SelectedValue != "-1")
            {
                if (ddlSite.SelectedValue != "-1")
                {
                    itemList = SiteCategoryData.GetSiteCategoryList();
                    int parentCategoryId = DBHelper.IntValue(ddlParentCategories.SelectedValue);
                    int SiteId = DBHelper.IntValue(ddlSite.SelectedValue);
                    itemList = itemList.Where(x => x.ProductCategory.Id == parentCategoryId).ToList();
                    itemList = itemList.Where(x => x.Site.Id == SiteId).ToList();
                }
            }
            int Count = 0;
            if (itemList == null)
                Count = 0;
            else
                Count = itemList.Count;

            if (Count > 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                if (ddlParentCategories.SelectedValue != "-1")
                    item.ProductCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedValue) };
                if (ddlSite.SelectedValue != "-1")
                    item.Site = new Site() { Id = Convert.ToInt32(ddlSite.SelectedValue) };

                try
                {
                    if (SiteCategoryData.Insert(item.Site.Id, item.ProductCategory.Id) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert SiteCategories";
                        itemSystemLog.Content = "Site=" + item.Site.Id + "Category =" + item.ProductCategory.Id;
                        itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert SiteCategories";
                    itemSystemLog.Content = "Site=" + item.Site.Id + "Category =" + item.ProductCategory.Id + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var item = new SiteCategory();

            item.Id = itemId;
            if (ddlParentCategories.SelectedValue != "-1")
                item.ProductCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedValue) };
            if (ddlSite.SelectedValue != "-1")
                item.Site = new Site() { Id = Convert.ToInt32(ddlSite.SelectedValue) };

            try
            {
                if (SiteCategoryData.Update(item) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update SiteCategories";
                    itemSystemLog.Content = "Id=" + itemId + "Site=" + item.Site.Id + "Categories =" + item.ProductCategory.Id;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update SiteCategories";
                itemSystemLog.Content = "Id=" + itemId + "Site=" + item.Site.Id + "Categories =" + item.ProductCategory.Id + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
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

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new ProductCategory() { Id = itemId };
            try
            {
                if (SiteCategoryData.Delete(itemId) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete SiteCategories";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete SiteCategories";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlList.Visible = true;
            pnlFilter.Visible = true;
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            GetList();
        }



    }
}
