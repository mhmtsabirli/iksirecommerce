using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.Management.ProductManagement
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
            lblProductId.Text = "Yeni Kayıt";
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

        protected void btnAddDocument_Click(object sender, EventArgs e)
        {
            if ((fuSelectedDocument.PostedFile != null) && (fuSelectedDocument.PostedFile.ContentLength > 0))
            {
                try
                {
                    string fileExt = fuSelectedDocument.PostedFile.ContentType;
                    if (fileExt == ".doc" || fileExt == ".pdf" || fileExt == ".jpg")
                    {
                        string fn = System.IO.Path.GetFileName(fuSelectedDocument.PostedFile.FileName);
                        //var items = IKSIR.ECommerce.Toolkit.
                        var SaveLocation = "";
                        try
                        {
                            //System.IO.MemoryStream _MemoryStream = new MemoryStream(.CreateNewImage(SaveLocation, 25,25,fileExt));
                            //System.Drawing.Image item = System.Drawing.Image.FromStream(_MemoryStream);

                            fuSelectedDocument.PostedFile.SaveAs(SaveLocation);
                            lblDocumentAlert.Text = "Dosya Yüklendi";
                            lblDocumentAlert.Visible = true;
                            lblDocumentAlert.ForeColor = System.Drawing.Color.Green;
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Error: " + ex.Message);
                        }
                    }
                    else
                    {
                        lblDocumentAlert.Text = "Yüklemek istediğiniz dosya biçimi desteklenmiyor";
                        lblDocumentAlert.Visible = true;
                        lblDocumentAlert.ForeColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                lblDocumentAlert.Text = "Yüklemek için dosya seçininiz";
                lblDocumentAlert.Visible = true;
                lblDocumentAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnAddProperty_Click(object sender, EventArgs e)
        {

        }

        private void GetItem(int itemId)
        {
            //var item = new IKSIR.ECommerce.Model.CommonModel.Enum() { Id = Convert.ToInt32(itemId) };
            //IKSIR.ECommerce.Model.CommonModel.Enum itemEnum = EnumData.Get(item);

            //txtCategoryName.Text = itemEnum.Name.ToString();


            pnlForm.Visible = true;

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

            //ddlDocumntTypes.DataSource = IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer.EnumValueData.GetEnumValueList

        }

        private void GetList()
        {
            List<Product> itemList = ProductData.GetList();
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            if (txtFilterCategoryName.Text != "")
                itemList.Where(x => x.Title.Contains(txtFilterCategoryName.Text));
            if (ddlFilterParentCategories.SelectedValue != "-1" && ddlFilterParentCategories.SelectedValue != "")
            {
                var item = new ProductCategory() { Id = Convert.ToInt32(ddlFilterParentCategories.SelectedValue) };
                //itemList.Where(x => x.ParentCategory == item);
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

        #region ProductMain
        private bool GetProductMain(int productId)
        {
            bool retValue = false;
            return retValue;
        }

        private bool SaveProductMain()
        {
            bool retValue = false;
            try
            {

                if (btnSave.CommandArgument != "")
                {
                    //güncelle
                    int productId = DBHelper.IntValue(btnSave.CommandArgument);
                    if (UpdatePruductMain(productId))
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Ürün güncelleme başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Ürün güncellenirken hata oluştu.";
                        retValue = false;
                    }
                }
                else
                {
                    //yeni kayıt
                    if (InsertPruductMain())
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Yeni ürün kaydı başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "Yeni Ürün kaydedilirken hata oluştu.";
                        retValue = false;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            { }
            return retValue;
        }

        private bool InsertPruductMain()
        {
            bool retValue = false;
            return retValue;
        }

        private bool UpdatePruductMain(int productId)
        {
            bool retValue = false;
            return retValue;
        }
        #endregion

        #region Document
        private bool GetProductDocuments(int productId)
        {
            bool retValue = false;
            return retValue;
        }

        private bool GetProductDocument(int documentId)
        {
            bool retValue = false;
            return retValue;
        }

        private bool SaveDocument()
        {
            //Images diye bir table olması lazım cache'te.
            bool retValue = false;
            try
            {
                if (btnAddDocument.CommandArgument != "")
                {
                    //güncelle
                    int documentId = DBHelper.IntValue(btnAddDocument.CommandArgument);
                    if (UpdateDocument(documentId))
                    {
                        lblDocumentAlert.Visible = true;
                        lblDocumentAlert.ForeColor = System.Drawing.Color.Green;
                        lblDocumentAlert.Text = "Döküman güncelleme başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblDocumentAlert.Visible = true;
                        lblDocumentAlert.ForeColor = System.Drawing.Color.Red;
                        lblDocumentAlert.Text = "Döküman güncellenirken hata oluştu.";
                        retValue = false;
                    }
                }
                else
                {
                    //yeni kayıt
                    if (InsertDocument())
                    {
                        lblDocumentAlert.Visible = true;
                        lblDocumentAlert.ForeColor = System.Drawing.Color.Green;
                        lblDocumentAlert.Text = "Yeni ürün kaydı başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblDocumentAlert.Visible = true;
                        lblDocumentAlert.ForeColor = System.Drawing.Color.Red;
                        lblDocumentAlert.Text = "Yeni Ürün kaydedilirken hata oluştu.";
                        retValue = false;
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

            }
            return retValue;
        }

        private bool InsertDocument()
        {
            bool retValue = false;
            return retValue;
        }

        private bool UpdateDocument(int documentId)
        {
            bool retValue = false;
            return retValue;
        }
        #endregion

        #region Property
        private bool GetProductProperties(int productId)
        {
            bool retValue = false;
            return retValue;
        }
        private bool GetProductProperty(int propertyId)
        {
            bool retValue = false;
            return retValue;
        }
        private bool SaveProductPropertym()
        {
            bool retValue = false;
            try
            {
                if (btnAddProperty.CommandArgument != "")
                {
                    //güncelle
                    int propertyId = DBHelper.IntValue(btnAddProperty.CommandArgument);
                    if (UpdateProperty(propertyId))
                    {
                        lblPropertyAlert.Visible = true;
                        lblPropertyAlert.ForeColor = System.Drawing.Color.Green;
                        lblPropertyAlert.Text = "Özellik güncelleme başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblPropertyAlert.Visible = true;
                        lblPropertyAlert.ForeColor = System.Drawing.Color.Red;
                        lblPropertyAlert.Text = "Özellik güncellenirken hata oluştu.";
                        retValue = false;
                    }
                }
                else
                {
                    //yeni kayıt
                    if (InsertProperty())
                    {
                        lblPropertyAlert.Visible = true;
                        lblPropertyAlert.ForeColor = System.Drawing.Color.Green;
                        lblPropertyAlert.Text = "Yeni özellik kaydı başarılı.";
                        retValue = false;
                    }
                    else
                    {
                        lblPropertyAlert.Visible = true;
                        lblPropertyAlert.ForeColor = System.Drawing.Color.Red;
                        lblPropertyAlert.Text = "Yeni özellik kaydedilirken hata oluştu.";
                        retValue = false;
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {

            }
            return retValue;
        }

        private bool UpdateProperty(int propertyId)
        {
            bool retValue = false;
            return retValue;
        }

        private bool InsertProperty()
        {
            bool retValue = false;
            return retValue;
        }
        #endregion
    }
}