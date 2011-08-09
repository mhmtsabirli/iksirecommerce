using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Management.MasterPage;

namespace IKSIR.ECommerce.Management.Common
{
    public partial class Shipment : System.Web.UI.Page
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
            IKSIR.ECommerce.Model.ProductModel.Shipment itemShipment = ShipmentData.Get(itemId);


            txtShipment.Text = itemShipment.Title.ToString();
            string[] Price = itemShipment.UnitPrice.ToString().Split(',');
            txtPriceOne.Text = Price[0].ToString();
            txtPriceTwo.Text = Price[1].ToString();

            pnlForm.Visible = true;

        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<IKSIR.ECommerce.Model.ProductModel.Shipment> itemList = ShipmentData.GetShipmentList();

            if (txtFilterShipment.Text != "")
                itemList = itemList.Where(x => x.Title == txtFilterShipment.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtFilterShipment.Focus();
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


        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.ProductModel.Shipment();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            //where kosullu kısım calıstıgında burasıdacalısacaktır
            // a nın altında b var dıyelım kosul olmadıgı ıcın ıkıncı bır b yı atıyor
            if (item.Title != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {

                item.Title = txtShipment.Text.Trim();
                item.UnitPrice = Convert.ToDecimal(txtPriceOne.Text + "," + txtPriceTwo.Text);
                try
                {
                    if (ShipmentData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert Shipment";
                        itemSystemLog.Content = "Titile" + item.Title + " Price= " + item.UnitPrice ;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Enum";
                    itemSystemLog.Content = "Titile" + item.Title + " Price= " + item.UnitPrice;
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.ProductModel.Shipment();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            item.Id = Convert.ToInt32(lblId.Text);
            item.Title = txtShipment.Text.Trim();
            item.UnitPrice = Convert.ToDecimal(txtPriceOne.Text + "," + txtPriceTwo.Text);

            try
            {
                if (ShipmentData.Update(item) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update Shipment";
                    itemSystemLog.Content = "Id" + item.Id + "Name" + item.Title+" Price ="+item.UnitPrice;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Shipment";
                itemSystemLog.Content = "Id" + item.Id + "Name" + item.Title+" Price ="+item.UnitPrice + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;

            var shipmentList = ProductShipmentPriceData.GetByShipment(itemId);
            if (shipmentList.Count > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Bu Firmaya tanımlanmış Ürünler  bulunmaktadır. Önce onları değiştirmelisiniz.</span></br>";
            }
            else
            {
                try
                {
                    if (ShipmentData.Delete(itemId) < 0)
                    {
                        returnValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Delete Shipment";
                        itemSystemLog.Content = "Id=" + itemId;
                        itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete Shipment";
                    itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return returnValue;
        }

        private void ClearForm()
        {
            
            txtShipment.Text = string.Empty;
            txtPriceOne.Text = string.Empty;
            txtPriceTwo.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}