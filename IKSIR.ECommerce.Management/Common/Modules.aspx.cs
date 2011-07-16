using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Management.MasterPage;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;

namespace IKSIR.ECommerce.Management.Common
{
    public partial class Modules : System.Web.UI.Page
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
            var item = new Module() { Id = Convert.ToInt32(itemId) };
            Module itemModule = ModuleData.Get(item);

            txtModuleName.Text = itemModule.Name.ToString();
            ddlSites.SelectedValue = itemModule.Site.Id.ToString();

            pnlForm.Visible = true;

        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor
            List<Site> itemListSite = SiteData.GetSiteList();

            Utility.BindDropDownList(ddlSites, itemListSite, "Name", "Id");
            List<Module> itemList = ModuleData.GetModuleList();

            if (txtFilterModuleName.Text != "")
                itemList = itemList.Where(x => x.Name == txtFilterModuleName.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtModuleName.Focus();
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
                    lblError.Text = "Item kaydedilirken bir hata oluştu.";
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
            //Enum da buna gerek yok


        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new Module();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            //where kosullu kısım calıstıgında burasıdacalısacaktır
            // a nın altında b var dıyelım kosul olmadıgı ıcın ıkıncı bır b yı atıyor
            if (item.Name != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {

                item.Name = txtModuleName.Text.Trim();
                item.Site = new Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
                try
                {
                    if (ModuleData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert Module";
                        itemSystemLog.Content = "Name" + item.Name;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch(Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Module";
                    itemSystemLog.Content = "Name" + item.Name + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemModule = new Module();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            itemModule.Id = itemId;
            itemModule.Name = txtModuleName.Text;
            itemModule.Site = new Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };

            try
            {
                if (ModuleData.Update(itemModule) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update Module";
                    itemSystemLog.Content = "Id" + itemModule.Id + "Name" + itemModule.Name;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch(Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Module";
                itemSystemLog.Content = "Id" + itemModule.Id + "Name" + itemModule.Name + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;


            var itemEnum = new Module() { Id = itemId };
            try
            {
                if (ModuleData.Delete(itemEnum) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete Enum";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Enum";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            txtModuleName.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}