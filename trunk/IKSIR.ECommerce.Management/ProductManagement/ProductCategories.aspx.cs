using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
//using IKSIR.ECommerce.Toolkit;

namespace IKSIR.ECommerce.Management.ProductManagement
{
    public partial class ProductCategories : System.Web.UI.Page
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
            ProductCategory itemProduct = ProductCategoryData.Get(new ProductCategory() { Id = itemId });

            txtCategoryName.Text = itemProduct.Title.ToString();
            txtDescription.Text = itemProduct.Description.ToString();
            if (itemProduct.ParentCategory.Id == 0)
                ddlParentCategories.SelectedValue = "-1";
            else if (itemProduct.ParentCategory != null)
                ddlParentCategories.SelectedValue = itemProduct.ParentCategory.Id.ToString();
            else
                ddlParentCategories.SelectedValue = "-1";

            if (itemProduct.Site.Id != 0)
                ddlSites.SelectedValue = itemProduct.Site.Id.ToString();
            else
                ddlSites.SelectedValue = "-1";
            pnlForm.Visible = true;

        }

        private void BindValues()
        {
            List<ProductCategory> itemList = ProductCategoryData.GetParentProductCategoryList();
            List<Site> itemListSite = SiteData.GetSiteList();

            Utility.BindDropDownList(ddlSites, itemListSite, "Name", "Id");
            Utility.BindDropDownList(ddlParentCategories, itemList, "Title", "Id");
            Utility.BindDropDownList(ddlFilterParentCategories, itemList, "Title", "Id");


        }

        private void GetList()
        {

            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();

            string CategoryName = txtFilterCategoryName.Text;
            if (txtFilterCategoryName.Text != "")
                itemList = itemList.Where(x => x.Title == CategoryName).ToList();

            if (ddlFilterParentCategories.SelectedValue != "-1" && ddlFilterParentCategories.SelectedValue != "")
            {
                int parentCategoryId = DBHelper.IntValue(ddlFilterParentCategories.SelectedValue);
                itemList = itemList.Where(x => x.ParentCategory != null).ToList();
                itemList = itemList.Where(x => x.ParentCategory.Id == parentCategoryId).ToList();

            }

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtCategoryName.Focus();
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlList.Visible = true;
            pnlFilter.Visible = true;
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            List<IKSIR.ECommerce.Model.ProductModel.Product> productList = ProductData.GetProductCategoryList(itemId);

            if (productList.Count == 0)
            {
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
            else
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu kategori'ye bağlı bir çok ürün bulunmakta. Önce o ürünlerin kategorilerini değiştiriniz";
            }

        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            GetList();
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new ProductCategory();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            // a nın altında b var dıyelım kosul olmadıgı ıcın ıkıncı bır b yı atıyor
            // where kosullu kısı mcalıstırıldıgında burayada uygulanıp burasıda calıstırılacak

            List<ProductCategory> itemList = null;

            string CategoryName = txtCategoryName.Text;


            if (ddlParentCategories.SelectedValue != "-1")
            {
                itemList = ProductCategoryData.GetProductCategoryList();
                int parentCategoryId = DBHelper.IntValue(ddlParentCategories.SelectedValue);
                itemList = itemList.Where(x => x.ParentCategory != null).ToList();
                itemList = itemList.Where(x => x.ParentCategory.Id == parentCategoryId).ToList();
                itemList = itemList.Where(x => x.Title == CategoryName).ToList();
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
                    item.ParentCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedValue) };

                item.Title = txtCategoryName.Text.Trim();
                item.Description = txtDescription.Text.Trim();
                item.Site = new Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
                try
                {
                    if (ProductCategoryData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert ProductCategory";
                        itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
                        itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert ProductCategory";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue) + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemProduct = new ProductCategory();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            itemProduct.Id = itemId;
            itemProduct.Title = txtCategoryName.Text;
            itemProduct.Description = txtDescription.Text;
            itemProduct.Site = new Site() { Id = Convert.ToInt32(ddlSites.SelectedValue) };
            if (ddlParentCategories.SelectedItem.Value != "")
                itemProduct.ParentCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedItem.Value) };

            try
            {
                if (ProductCategoryData.Update(itemProduct) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert ProductCategory";
                    itemSystemLog.Content = "Id=" + itemProduct.Id + "Title=" + itemProduct.Title + "Description =" + itemProduct.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Insert ProductCategory";
                itemSystemLog.Content = "Id=" + itemProduct.Id + "Title=" + itemProduct.Title + "Description =" + itemProduct.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue) + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new ProductCategory() { Id = itemId };
            try
            {
                if (ProductCategoryData.Delete(item) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete ProductCategory";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ProductCategory";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            ddlParentCategories.SelectedIndex = -1;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }



    }
}