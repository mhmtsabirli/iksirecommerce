using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Model.Bank;
using IKSIR.ECommerce.Management.MasterPage;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Toolkit;

namespace IKSIR.ECommerce.Management.Bank
{
    public partial class BinNumbers : System.Web.UI.Page
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
            BinNumber itemBinNumber = BinNumberData.Get(itemId);
            txtBinNumber.Text = itemBinNumber.Number.ToString();
            ddlBanks.SelectedValue = itemBinNumber.Bank.Id.ToString();
            ddlBinNumberStatus.SelectedValue = itemBinNumber.Status.Id.ToString();

            pnlForm.Visible = true;

        }

        private void GetList()
        {

            List<BinNumber> itemList = BinNumberData.GetBinNumberList();

            if (txtFilterBinNumber.Text != "")
                itemList = itemList.Where(x => x.Number == txtFilterBinNumber.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtFilterBinNumber.Focus();
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
            List<IKSIR.ECommerce.Model.Bank.Bank> itemListBank = BankData.GetBankList();

            Utility.BindDropDownList(ddlBanks, itemListBank, "Name", "Id");

            List<EnumValue> itemBinNumberStatus = EnumValueData.GetEnumValues(17);
            Utility.BindDropDownList(ddlBinNumberStatus, itemBinNumberStatus, "Value", "Id");

        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new BinNumber();
            List<BinNumber> itemList = BinNumberData.GetBinNumberList();
            itemList = itemList.Where(x => x.Number == txtBinNumber.Text).ToList();

            if (itemList.Count > 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {

                item.Number = txtBinNumber.Text.Trim();
                item.Status = new EnumValue() { Id = Convert.ToInt32(ddlBinNumberStatus.SelectedValue) };
                item.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = Convert.ToInt32(ddlBanks.SelectedValue) };
                try
                {
                    if (BinNumberData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert Bin Number";
                        itemSystemLog.Content = "Name" + item.Number + " BankId=" + ddlBanks.SelectedValue + "Status=" + ddlBinNumberStatus.SelectedValue;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert  Bin Number";
                    itemSystemLog.Content = "Name" + item.Number + " BankId=" + ddlBanks.SelectedValue + "Status=" + ddlBinNumberStatus.SelectedValue + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var item = new BinNumber();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            item.Id = itemId;
            item.Number = txtBinNumber.Text.Trim();
            item.Status = new EnumValue() { Id = Convert.ToInt32(ddlBinNumberStatus.SelectedValue) };
            item.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = Convert.ToInt32(ddlBanks.SelectedValue) };

            try
            {
                if (BinNumberData.Update(item) < 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update Bin Number";
                    itemSystemLog.Content = "Id" + item.Id + "Name" + item.Number + " BankId=" + ddlBanks.SelectedValue + "Status=" + ddlBinNumberStatus.SelectedValue;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Bin Nubmer";
                itemSystemLog.Content = "Id" + item.Id + "Name" + item.Number + " BankId=" + ddlBanks.SelectedValue + "Status=" + ddlBinNumberStatus.SelectedValue + " " + ex.Message.ToString();
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
                if (BinNumberData.Delete(itemId) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete  Bin Nubmer";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete  Bin Nubmer";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            txtBinNumber.Text = string.Empty;
            ddlBanks.SelectedIndex = -1;
            ddlBinNumberStatus.SelectedIndex = -1;
            btnSave.CommandArgument = string.Empty;
        }
    }
}