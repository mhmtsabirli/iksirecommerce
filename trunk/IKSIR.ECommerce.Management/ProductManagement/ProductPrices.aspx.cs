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
    public partial class ProductPrices : System.Web.UI.Page
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
            pnlForm.Visible = true;

            if (GetProductPricesMain(itemId))
            {
                divAlert.InnerHtml = "<span style=\"color:Green\">Ürün Fiyat bilgileri başarıyla yüklendi.</span><br />";
                retValue = true;
            }
            else
            {
                divAlert.InnerHtml = "<span style=\"color:Red\">Ürün Fiyat bilgileri yüklenirken hata oluştu.</span><br />" + divAlert.InnerHtml;
            }
            return retValue;
        }
        private void GetList()
        {
            List<ProductPrice> itemList = ProductPriceData.GetProductPriceList();

            //if (txtFilterProductCode.Text != "")
            //{
            //    string productCode = txtFilterProductCode.Text;
            //    itemList = itemList.Where(x => x.Product.ProductCode == productCode).ToList();
            //}
            gvList.DataSource = itemList;
            gvList.DataBind();
            ClearForm();
            pnlForm.Visible = false;

        }

        private bool InsertItem()
        {
            bool retValue = false;
            int ProductId = Convert.ToInt32(lblProductId.Text);
            int productPricesId = InsertPruductPrices();

            if (productPricesId > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Ürün Fiyatı başarıyla kaydedildi.</span><br />";

                retValue = true;
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Ürün  Fiyatı kaydedilirken hatalar oluştu lütfen daha sonra tekrar deneyiniz.</span><br />";
            }
            if (SaveProductPriceShipmnent(ProductId))
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Ürün Kargo Fiyatı başarıyla kaydedildi.</span><br />";
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Ürün Kargo Fiyatı kaydedilirken hatalar oluştu lütfen daha sonra tekrar deneyiniz.</span><br />";
            }

            return retValue;
        }
        private bool UpdateItem(int productId)
        {
            bool retValue = false;
            if (UpdatePruductPricesMain(productId))
                retValue = true;
            return retValue;
        }

        private void BindValues()
        {

            List<IKSIR.ECommerce.Model.ProductModel.Shipment> itemShipment = ShipmentData.GetShipmentList();
            Utility.BindDropDownList(ddlShipment, itemShipment, "Title", "Id");
            List<ProductCategory> itemList = ProductCategoryData.GetProductCategoryList();

        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblProductPriceId.Text = "Yeni Kayıt";
            lblProductShipmentPriceId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            ddlShipment.Focus();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int ProductPriceId = 0;
            if (btnSave.CommandArgument != "") //Kayıt güncelleme.
            {
                ProductPriceId = Convert.ToInt32(btnSave.CommandArgument);
                SaveProductPrices(ProductPriceId);
            }
            else
            {
                ProductPriceId = InsertPruductPrices();
            }
            int productId = Convert.ToInt32(lblProductId.Text);
            SaveProductPriceShipmnent(productId);
            GetList();
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
            GetItem(itemId);
        }
        protected void lbtnDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (DeletePruductPricesMain(itemId))
            {
                divAlert.InnerHtml += "<span style=\"color:Green\">Ürün başarıyla silindi <i>Ürün Id: " + itemId.ToString() + "</i></span><br />";
                GetList();
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Ürün silinirken hata oluştu! <i>Ürün Id: " + itemId.ToString() + "</i></span><br />";
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProductCode.Text != "")
            {
                var itemProduct = ProductData.Get(ProductData.FindProductId(txtProductCode.Text));

                txtProductName.Text = itemProduct.Title.ToString();
                lblProductId.Text = itemProduct.Id.ToString();
            }
        }
        protected void btnCal_Click(object sender, EventArgs e)
        {
            if (txtUnitPriceOne.Text != "" && txtUnitPriceTwo.Text != "" && txtTax.Text != "")
            {
                decimal UnitPrice = Convert.ToDecimal(txtUnitPriceOne.Text + "," + txtUnitPriceTwo.Text);
                decimal UnitPriceWithTax = Convert.ToDecimal(UnitPrice * Convert.ToDecimal(1 + "," + txtTax.Text));
                string[] Price = Convert.ToString(UnitPriceWithTax).Split(',');
                txtPriceOne.Text = Price[0].ToString();
                
                txtPriceTwo.Text = Price[1].ToString().Substring(0,2);
            }
           
        }
        protected void btnShCall_Click(object sender, EventArgs e)
        {
            if (txtDesi.Text != "" && txtShUnitPrice.Text != "")
            {
                decimal UnitPrice = Convert.ToDecimal(txtShUnitPrice.Text);
                decimal UnitPriceWithDesi = Convert.ToDecimal(UnitPrice * Convert.ToDecimal(txtDesi.Text));
                string[] Price = Convert.ToString(UnitPriceWithDesi).Split(',');
                txtShpriceOne.Text = Price[0].ToString();

                txtShpriceTwo.Text = Price[1].ToString().Substring(0, 2);
            }

        }

        protected void ddlShipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            IKSIR.ECommerce.Model.ProductModel.Shipment itemSh = ShipmentData.Get(Convert.ToInt32(ddlShipment.SelectedValue));
            txtShUnitPrice.Text = Convert.ToString(itemSh.UnitPrice);
            chBaz.Enabled = true;
        }

        protected void chBaz_CheckedChanged(object sender, EventArgs e)
        {
            if (chBaz.Checked == true)
            {
                divUnit.Visible = true;
                txtShpriceOne.Enabled = false;
                txtShpriceTwo.Enabled = false;
            }
            else
            {
                divUnit.Visible = false;
                txtShpriceOne.Enabled = true;
                txtShpriceTwo.Enabled = true;
            }
        }

        #region ProductPrices
        private bool GetProductPricesMain(int productPriceId)
        {
            bool retValue = false;
            try
            {

                var item = ProductPriceData.Get(productPriceId);
                lblProductPriceId.Text = item.Id.ToString();
                var itemProduct = ProductData.Get(ProductData.FindProductId(item.Product.ProductCode.ToString()));
                txtProductCode.Text = itemProduct.ProductCode.ToString();
                txtProductCode.Enabled = false;
                lblProductId.Text = itemProduct.Id.ToString();
                txtProductName.Text = itemProduct.Title.ToString();
                txtTax.Text = item.Tax.ToString();

                string[] UnitPrice = item.UnitPrice.ToString().Split(',');
                txtUnitPriceOne.Text = UnitPrice[0].ToString();
                txtUnitPriceTwo.Text = UnitPrice[1].ToString();

                string[] Price = item.Price.ToString().Split(',');
                txtPriceOne.Text = Price[0].ToString();
                txtPriceTwo.Text = Price[1].ToString();

                Session.Add("PRODUCT_SHIPMENT_LIST", item.ProductShipmentPrice);
                gvProductShipment.DataSource = item.ProductShipmentPrice;
                gvProductShipment.DataBind();

                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "GetProductPrices";
                itemSystemLog.Content = "Id=" + productPriceId.ToString() + " ile alanlar doldurulamadı. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool SaveProductPrices(int ProductPriceId)
        {
            bool retValue = false;
            try
            {
                if (btnSave.CommandArgument != "")
                {
                    //güncelle                    
                    if (UpdatePruductPricesMain(ProductPriceId))
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
                    if (InsertPruductPrices() > 0)
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

        private int InsertPruductPrices()
        {
            int retValue = 0;
            string productCode = txtProductCode.Text;
            int ProductId = Convert.ToInt32(lblProductId.Text);
            var itemProductPrice = ProductPriceData.GetByProduct(ProductId);

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyoruz.
            if (itemProductPrice.Price != 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu ürün için fiyat zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
            }
            else
            {
                itemProductPrice = new ProductPrice();
                itemProductPrice.Price = Convert.ToDecimal(txtPriceOne.Text + "," + txtPriceTwo.Text);
                itemProductPrice.Product = new Product() { Id = ProductId };
                itemProductPrice.Tax = Convert.ToInt32(txtTax.Text);
                itemProductPrice.UnitPrice = Convert.ToDecimal(txtUnitPriceOne.Text + "," + txtUnitPriceTwo.Text);
                itemProductPrice.CreateAdminId = 1;

                int result = ProductPriceData.Insert(itemProductPrice);
                if (result > 0)
                {
                    retValue = result;
                }
            }
            return retValue;
        }

        private bool UpdatePruductPricesMain(int ProductPriceId)
        {
            bool retValue = false;
            var itemProduct = ProductPriceData.Get(ProductPriceId);
            if (itemProduct != null)
            {
                itemProduct.Id = Convert.ToInt32(lblProductPriceId.Text);
                itemProduct.Price = Convert.ToDecimal(txtPriceOne.Text + "," + txtPriceTwo.Text);
                itemProduct.Product =  new Product(){Id = Convert.ToInt32(lblProductId.Text)};
                itemProduct.Tax = Convert.ToInt32(txtTax.Text);
                itemProduct.UnitPrice = Convert.ToDecimal(txtUnitPriceOne.Text + "," + txtUnitPriceTwo.Text);
                itemProduct.EditAdminId = 1;
                itemProduct.EditDate = DateTime.Now;

                int result = ProductPriceData.Update(itemProduct);
                if (result != 1)
                    retValue = true;
            }
            return retValue;
        }
        private bool DeletePruductPricesMain(int productPriceId)
        {
            bool retValue = false;

            if (ProductPriceData.Delete(productPriceId) > 0)
            {
                retValue = true;
            }
            return retValue;

        }
        #endregion

        #region productShipmentPrice

        protected void btnAddShipmentPrice_Click(object sender, EventArgs e)
        {
            SaveProductPriceShipmnentToList();

            ddlShipment.SelectedIndex = -1;
            txtShpriceTwo.Text = string.Empty;
            txtShpriceOne.Text = string.Empty;
            txtShUnitPrice.Text = string.Empty;
            btnAddShipmentPrice.CommandArgument = "";
            lblProductShipmentPriceId.Text = "Yeni Kayıt";
        }
        protected void lbtShipmentEdit_Click(object sender, EventArgs e)
        {
            ClearForm();
            var index = ((sender as LinkButton).Parent.Parent as GridViewRow).RowIndex;
            gvList.SelectedIndex = index;
            var productShipmentId = (sender as LinkButton).CommandArgument == ""
                             ? 0
                             : Convert.ToInt32((sender as LinkButton).CommandArgument);

            btnSave.CommandArgument = lblProductId.Text.ToString();
            if (!GetProductShipments(Convert.ToInt32(productShipmentId)))
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Kargo Fiyat bilgilerini getirirken hata oluştu!</span><br />";
            }
            RadTabStrip1.SelectedIndex = 1;
            RadPageView2.Selected = true;
        }
        protected void lbtnShipmentyDelete_Click(object sender, EventArgs e)
        {
            var itemId = (sender as LinkButton).CommandArgument == "" ? 0 : Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (DeleteProductShipment(itemId))
            {
                
                divAlert.InnerHtml += "<span style=\"color:Green\">Kargo Fiyatı başarıyla silindi</span><br />";
                GetItem(Convert.ToInt32(lblProductPriceId.Text));
            }
            else
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Kargo Fiyatı  silinirken hata oluştu!</span><br />";
            }
        }

        private List<ProductShipmentPrice> GetProductShipmentPriceList()
        {
            List<ProductShipmentPrice> productShipmentList;
            if (Session["PRODUCT_SHIPMENT_LIST"] != null)
            {
                productShipmentList = (List<ProductShipmentPrice>)Session["PRODUCT_SHIPMENT_LIST"];
            }
            else
            {
                productShipmentList = new List<ProductShipmentPrice>();
                Session.Add("PRODUCT_SHIPMENT_LIST", productShipmentList);
            }
            productShipmentList = (List<ProductShipmentPrice>)Session["PRODUCT_SHIPMENT_LIST"];

            return productShipmentList;
        }

        private bool GetProductShipment(int productId)
        {
            bool retValue = false;

            try
            {

                var productShipmentList = ProductShipmentPriceData.GetByProduct(productId);

                Session.Add("PRODUCT_SHIPMENT_LIST", productShipmentList);
                gvProductShipment.DataSource = productShipmentList;
                gvProductShipment.DataBind();
                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductPrice";
                itemSystemLog.Content = "Ürün fiyatı kaydedilirken hata oluştu. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
                retValue = false;
            }
            return retValue;
        }
        private bool GetProductShipment()
        {
            bool retValue = false;
            var productShipmentList = GetProductShipmentPriceList();
            gvProductShipment.DataSource = productShipmentList;
            gvProductShipment.DataBind();
            return retValue;
        }

        private bool GetProductShipments(int ShipmentPriceId)
        {
            bool retValue = false;
            var itemProductShipmentPrice = ProductShipmentPriceData.Get(ShipmentPriceId);
            lblProductShipmentPriceId.Text = itemProductShipmentPrice.Id.ToString();
            txtShUnitPrice.Text = itemProductShipmentPrice.Shipment.UnitPrice.ToString();
            string[] ShPrice = itemProductShipmentPrice.Price.ToString().Split(',');
            txtShpriceOne.Text = ShPrice[0].ToString();
            txtShpriceTwo.Text = ShPrice[1].ToString();
            ddlShipment.SelectedValue = itemProductShipmentPrice.Shipment.Id.ToString();
            chBaz.Enabled = true;
            btnAddShipmentPrice.CommandArgument = lblProductShipmentPriceId.Text.ToString();
            retValue = true;
            GetItem(Convert.ToInt32(lblProductPriceId.Text));
            return retValue;
        }

        private bool SaveProductPriceShipmnentToList()
        {
            bool retValue = false;
            try
            {

                var productShipmentPriceList = GetProductShipmentPriceList();
                if (btnAddShipmentPrice.CommandArgument != "")
                {
                    //güncelle
                    int ShipmenPriceId = DBHelper.IntValue(btnAddShipmentPrice.CommandArgument);
                    if (ShipmenPriceId != 0)
                    {
                        ProductShipmentPrice item = productShipmentPriceList.Where(x => x.Id == ShipmenPriceId).SingleOrDefault();
                        productShipmentPriceList.Remove(item);
                        var newItem = new ProductShipmentPrice();
                        newItem.Id = item.Id;

                        newItem.Price = Convert.ToDecimal(txtShpriceOne.Text.ToString() + "," + txtShpriceTwo.Text.ToString());

                        newItem.Shipment = new IKSIR.ECommerce.Model.ProductModel.Shipment() { Id = Convert.ToInt32(ddlShipment.SelectedValue.ToString()),Title=ddlShipment.SelectedItem.Text.ToString() };
                        newItem.Product = new Product() { Id = Convert.ToInt32(lblProductId.Text) };

                        productShipmentPriceList.Add(newItem);
                        divAlert.InnerHtml += "<span style=\"color:Green\">Kargo Fiyat güncelleme başarılı.</span><br />";
                        retValue = true;
                    }
                    else
                    {
                        divAlert.InnerHtml += "<span style=\"color:Red\">Kargo Fiyat güncellenirken hata oluştu!</span><br />";
                        retValue = false;
                    }
                }
                else
                {
                    try
                    {

                        var item = new ProductShipmentPrice();

                        item.Price = Convert.ToDecimal(txtShpriceOne.Text.ToString() + "," + txtShpriceTwo.Text.ToString());

                        item.Shipment = new IKSIR.ECommerce.Model.ProductModel.Shipment() { Id = Convert.ToInt32(ddlShipment.SelectedValue.ToString()), Title = Convert.ToString(ddlShipment.SelectedItem.Text) };
                        item.Product = new Product() { Id = Convert.ToInt32(lblProductId.Text) };


                        productShipmentPriceList.Add(item);
                        divAlert.InnerHtml += "<span style=\"color:Green\">Yeni özellik kaydı başarılı.</span><br />";
                        retValue = true;
                    }
                    catch (Exception)
                    {
                        divAlert.InnerHtml += "<span style=\"color:Red\">Yeni özellik kaydedilirken hata oluştu.</span><br />";
                        retValue = false;
                    }
                }
                GetProductShipment();
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductProperty";
                itemSystemLog.Content = "Ürün özelliği kaydedilirken hata oluştu. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            finally
            {

            }
            return retValue;
        }

        private bool SaveProductPriceShipmnent(int productId)
        {
            bool retValue = false;
            try
            {
                var productPropertyList = GetProductShipmentPriceList();

                foreach (ProductShipmentPrice itemProductShipmentPrice in productPropertyList)
                {
                    if (itemProductShipmentPrice.Id != 0)
                    {
                        //güncelle
                        if (ProductShipmentPriceData.Update(itemProductShipmentPrice) < 0)
                        {
                            divAlert.InnerHtml += "<span style=\"color:Green\">Kargo Fiyatı güncelleme başarılı.</span><br />";
                            retValue = true;
                        }
                        else
                        {
                            divAlert.InnerHtml += "<span style=\"color:Red\">Kargo Fiyatı  güncellenirken hata oluştu.</span><br />";
                            retValue = false;
                        }
                    }
                    else
                    {
                        //yeni kayıt
                        if (ProductShipmentPriceData.Insert(itemProductShipmentPrice) > 0)
                        {
                            divAlert.InnerHtml += "<span style=\"color:Green\">Kargo Fiyatı kaydı başarılı.</span><br />";
                            retValue = true;
                        }
                        else
                        {
                            divAlert.InnerHtml += "<span style=\"color:Red\">Kargo Fiyatı kaydedilirken hata oluştu.</span><br />";
                            retValue = false;
                        }
                    }
                }
                GetProductShipment();
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "SaveProductProperties";
                itemSystemLog.Content = productId.ToString() + " Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            finally
            {

            }
            return retValue;
        }

        private bool InsertProductShipmentToList(ProductShipmentPrice itemProductShipmentPrice)
        {
            bool retValue = false;
            try
            {
                var productShipmentPriceList = GetProductShipmentPriceList();
                productShipmentPriceList = (List<ProductShipmentPrice>)Session["PRODUCT_SHIPMENT_LIST"];
                ProductShipmentPrice item = new ProductShipmentPrice();
                item.Id = 0;//Yeni kayıt.
                item.Price = itemProductShipmentPrice.Price;
                item.CreateAdminId = itemProductShipmentPrice.CreateAdminId;
                item.Product.Id = itemProductShipmentPrice.Product.Id;
                item.Shipment.Id = itemProductShipmentPrice.Shipment.Id;

                productShipmentPriceList.Add(item);
                retValue = true;
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "InsertproductShipmentPrice";
                itemSystemLog.Content = "Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }
        private bool DeleteProductShipment(int ProductShipmentId)
        {
            bool retValue = false;
            try
            {
                if (ProductShipmentPriceData.Delete(ProductShipmentId) < 0)
                {
                    retValue = true;
                }
            }
            catch (Exception exception)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Document";
                itemSystemLog.Content = "Id=" + ProductShipmentId.ToString() + " ile Karho Kaydı silinemedi. Hata: " + exception.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }
        #endregion

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            GetList();
        }

        private void ClearForm()
        {
            txtDesi.Text = string.Empty;
            txtFilterProductCode.Text = string.Empty;
            txtPriceOne.Text = string.Empty;
            txtPriceTwo.Text = string.Empty;
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtShpriceOne.Text = string.Empty;
            txtShpriceTwo.Text = string.Empty;
            txtShUnitPrice.Text = string.Empty;
            txtTax.Text = string.Empty;
            txtUnitPriceOne.Text = string.Empty;
            txtUnitPriceTwo.Text = string.Empty;
            lblProductId.Text = string.Empty;
            ddlShipment.SelectedIndex = -1;
            chBaz.Enabled = false;
           
            Session["PRODUCT_PROPERTY_LIST"] = null;
            btnSave.CommandArgument = string.Empty;
            gvProductShipment.DataSource = null;
            gvProductShipment.DataBind();
          
            RadTabStrip1.SelectedIndex = 0;
            RadPageView1.Selected = true;
        }

    }
}