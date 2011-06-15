using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Management.Product
{
    public partial class Products : System.Web.UI.Page
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
            //var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            //gvList.SelectedIndex = index;
            //var itemId = (sender as LinkButton).CommandArgument == ""
            //                 ? 0
            //                 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            //if (!GetItem(itemId))
            //{
            //    lblError.Visible = true;
            //    lblError.ForeColor = System.Drawing.Color.Red;
            //    lblError.Text = "Item güncelleme işleminde bir hata oluştu.";
            //}
        }

        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);

            //if (DeleteItem(itemId))
            //{
            //    lblError.Visible = true;
            //    lblError.ForeColor = System.Drawing.Color.Green;
            //    lblError.Text = "Item başarıyla silindi.";
            //    GetList();
            //}
            //else
            //{
            //    lblError.Visible = true;
            //    lblError.ForeColor = System.Drawing.Color.Red;
            //    lblError.Text = "Item silerken bir hata oluştu.";
            //}
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            //Buralarda tüm kategoriler gelecek istediği kategorinin altına tanımlama yapabilecek.
            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();
            ddlCategories.DataSource = itemList;
            ddlCategories.DataTextField = "Title";
            ddlCategories.DataValueField = "Id";
            ddlCategories.DataBind();

            ddlFilterParentCategories.DataSource = itemList;
            ddlFilterParentCategories.DataTextField = "Title";
            ddlFilterParentCategories.DataValueField = "Id";
            ddlFilterParentCategories.DataBind();
        }

        private void GetList()
        {
            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
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
            if (item != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                item.ParentCategory = new ProductCategory() { Id = Convert.ToInt32(ddlCategories.SelectedValue) };
                item.Title = txtCategoryName.Text.Trim();
                item.Description = txtDescription.Text.Trim();
                if (ProductCategoryData.Insert(item) > 0)
                    retValue = true;
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            return retValue;
        }

        private void ClearForm()
        {
            ddlCategories.SelectedIndex = -1;
            txtCategoryName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}