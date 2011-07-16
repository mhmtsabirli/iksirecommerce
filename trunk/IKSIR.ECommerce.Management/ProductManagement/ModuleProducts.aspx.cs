using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;

namespace IKSIR.ECommerce.Management.ProductManagement
{
    public partial class ModuleProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlModules.Enabled = false;
                BindValues();
                GetList();
            }
        }

        private void GetItem(int itemId)
        {
            var item = new ModuleProduct() { Id = Convert.ToInt32(itemId) };
            ModuleProduct itemModuleProduct = ModuleProductData.GetById(item);

            txtProdCode.Text = itemModuleProduct.Product.ProductCode.ToString();
            ddlSites.SelectedValue = itemModuleProduct.Module.Site.Id.ToString();
            ddlModules.SelectedValue = itemModuleProduct.Module.Id.ToString();

            pnlForm.Visible = true;

        }

        private void GetList()
        {

            List<ModuleProduct> itemList = ModuleProductData.GetModuleProductList();

            if (txtFilterProdCode.Text != "")
                itemList = itemList.Where(x => x.Product.ProductCode == txtFilterProdCode.Text).ToList();
            if (ddlFilterModule.SelectedValue != "-1" && ddlFilterModule.SelectedValue != "")
            {
                var item = new IKSIR.ECommerce.Model.CommonModel.Enum() { Id = Convert.ToInt32(ddlFilterModule.SelectedValue) };
                itemList = itemList.Where(x => x.Module.Id == item.Id).ToList();
            }
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtProdCode.Focus();
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
                    lblError2.Visible = false;
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
                    lblError2.Visible = false;
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

        protected void ddlSites_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Module> itemList = ModuleData.GetModuleListBySiteId(Convert.ToInt32(ddlSites.SelectedValue));
            Utility.BindDropDownList(ddlModules, itemList, "Name", "Id");
            ddlModules.Enabled = true;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            //Buralarda tüm kategoriler gelecek istediği kategorinin altına tanımlama yapabilecek.

            List<Site> itemListSite = SiteData.GetSiteList();
            List<Module> itemList = ModuleData.GetModuleList();
            Utility.BindDropDownList(ddlSites, itemListSite, "Name", "Id");
            Utility.BindDropDownList(ddlModules, itemList, "Name", "Id");
            Utility.BindDropDownList(ddlFilterModule, itemList, "Name", "Id");

        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new ModuleProduct();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            //where kosullu kısım calıstıgında burasıdacalısacaktır
            // a nın altında b var dıyelım kosul olmadıgı ıcın ıkıncı bır b yı atıyor
            if (item.Product != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                int ProductId = ProductData.FindProductId(txtProdCode.Text);
                if (ProductId > 0)
                {
                    try
                    {
                        if (ModuleProductData.Insert(ProductId, Convert.ToInt32(ddlModules.SelectedValue.ToString())) > 0)
                        {
                            retValue = true;

                            SystemLog itemSystemLog = new SystemLog();
                            itemSystemLog.Title = "Insert ModuleProduct";
                            itemSystemLog.Content = "ProductCode" + item.Product.ProductCode + "Module Id =  " + item.Module.Id;
                            itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                            SystemLogData.Insert(itemSystemLog);
                        }
                    }
                    catch (Exception ex)
                    {
                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert ModuleProduct";
                        itemSystemLog.Content = "ProductCode" + item.Product.ProductCode + "Module Id =  " + item.Module.Id + ex.Message.ToString();
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                else
                {
                    lblError2.Visible = true;
                    lblError2.ForeColor = System.Drawing.Color.Red;
                    lblError2.Text = "Bu ürün koduna kayıtlı bir ürün bulunamamıştır. Lütfen Ürün kodunu kontrol edeiniz!";
                    retValue = false;
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemModule = new Module();
            int ProductId = 0;

            try
            {
                ProductId = ProductData.FindProductId(txtProdCode.Text);
                if (ModuleProductData.Update(ProductId, Convert.ToInt32(ddlModules.SelectedValue.ToString()), Convert.ToInt32(lblId.Text)) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update ModuleProduct";
                    itemSystemLog.Content = "Product" + ProductId + "NoduleId" + Convert.ToInt32(ddlModules.SelectedValue.ToString());
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update ModuleProduct";
                itemSystemLog.Content = "Product" + ProductId + "NoduleId" + Convert.ToInt32(ddlModules.SelectedValue.ToString()) + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new ModuleProduct() { Id = itemId };
            try
            {
                if (ModuleProductData.Delete(item) < 0)
                    returnValue = true;
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ModuleProduct";
                itemSystemLog.Content = "Id" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);

            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ModuleProduct";
                itemSystemLog.Content = "Id" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return returnValue;
        }

        private void ClearForm()
        {

            ddlModules.SelectedIndex = -1;
            txtProdCode.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }


    }
}