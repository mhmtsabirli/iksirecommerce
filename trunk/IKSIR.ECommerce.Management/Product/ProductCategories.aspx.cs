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

namespace IKSIR.ECommerce.Management.Product
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

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtCategoryName.Focus();
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

        private void GetItem(int itemId)
        {
            var item = new ProductCategory() { Id = Convert.ToInt32(itemId) };
            ProductCategory itemProduct = ProductCategoryData.Get(item);
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            txtCategoryName.Text = itemProduct.Title.ToString();
            txtDescription.Text = itemProduct.Description.ToString();
            if (itemProduct.ParentCategory != null)
                ddlParentCategories.SelectedValue = (itemProduct.ParentCategory.Id.ToString());
            else
                ddlParentCategories.SelectedValue = "";

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
            var item = new ProductCategory() { Id = itemId };
            try
            {
                if (ProductCategoryData.Delete(item) < 0)
                    returnValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ProductCategory";
                itemSystemLog.Content = "Id=" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete ProductCategory";
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
            //Buralarda tüm kategoriler gelecek istediği kategorinin altına tanımlama yapabilecek.
            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();
            ddlParentCategories.DataSource = itemList;
            ddlParentCategories.DataTextField = "Title";
            ddlParentCategories.DataValueField = "Id";
            ddlParentCategories.DataBind();

            ddlFilterParentCategories.DataSource = itemList;
            ddlFilterParentCategories.DataTextField = "Title";
            ddlFilterParentCategories.DataValueField = "Id";
            ddlFilterParentCategories.DataBind();
        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            //where kosullu kısım calısmıyor
            if (txtFilterCategoryName.Text != "")
                itemList.Where(x => x.Title.Contains(txtFilterCategoryName.Text));
            if (ddlFilterParentCategories.SelectedValue != "-1" && ddlFilterParentCategories.SelectedValue != "")
            {
                var item = new ProductCategory() { Id = Convert.ToInt32(ddlFilterParentCategories.SelectedValue) };
                itemList.Where(x => x.ParentCategory == item);
            }
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new ProductCategory();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            // a nın altında b var dıyelım kosul olmadıgı ıcın ıkıncı bır b yı atıyor
            // where kosullu kısı mcalıstırıldıgında burayada uygulanıp burasıda calıstırılacak
            if (item.Description != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {

                item.ParentCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedValue) };
                item.Title = txtCategoryName.Text.Trim();
                item.Description = txtDescription.Text.Trim();
                try
                {
                    if (ProductCategoryData.Insert(item) > 0)
                        retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert ProductCategory";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
                catch
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert ProductCategory";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
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
            if (ddlParentCategories.SelectedItem.Value != "")
                itemProduct.ParentCategory = new ProductCategory() { Id = Convert.ToInt32(ddlParentCategories.SelectedItem.Value) };

            try
            {
                if (ProductCategoryData.Update(itemProduct) < 0)
                    retValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Insert ProductCategory";
                itemSystemLog.Content = "Id=" + itemProduct.Id + "Title=" + itemProduct.Title + "Description =" + itemProduct.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Insert ProductCategory";
                itemSystemLog.Content = "Id=" + itemProduct.Id + "Title=" + itemProduct.Title + "Description =" + itemProduct.Description + "ParentCategoryId=" + Convert.ToInt32(ddlParentCategories.SelectedValue);
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
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