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
    public partial class Banks : System.Web.UI.Page
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

            IKSIR.ECommerce.Model.Bank.Bank itemBank = BankData.Get(itemId);
            TransferAccount itemTransferAccount = TransferAccountData.GetByBankId(itemId);
            txtTransferAccDescription.Text = itemTransferAccount.Description.ToString();
            txtIban.Text = itemTransferAccount.Iban.ToString();
            lblTransferAccId.Text = itemTransferAccount.Id.ToString();
            if (itemTransferAccount.Status.Id != 0)
                ddlTransferAccStatus.SelectedValue = itemTransferAccount.Status.Id.ToString();
            txtBankName.Text = itemBank.Name.ToString();
            ddlBankStatus.SelectedValue = itemBank.Status.Id.ToString();

            pnlForm.Visible = true;

        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<IKSIR.ECommerce.Model.Bank.Bank> itemList = BankData.GetBankList();

            if (txtFilterBankName.Text != "")
                itemList = itemList.Where(x => x.Name == txtFilterBankName.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            lblTransferAccId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtBankName.Focus();
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
            List<EnumValue> itemBankStatus = EnumValueData.GetEnumValues(15);
            Utility.BindDropDownList(ddlBankStatus, itemBankStatus, "Value", "Id");


            List<EnumValue> itemTransferAccStatus = EnumValueData.GetEnumValues(16);
            Utility.BindDropDownList(ddlTransferAccStatus, itemTransferAccStatus, "Value", "Id");
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.Bank.Bank();
            var TransferAccItem = new TransferAccount();
            List<IKSIR.ECommerce.Model.Bank.Bank> itemList = BankData.GetBankList();

            if (txtBankName.Text != "")
                itemList = itemList.Where(x => x.Name == txtBankName.Text).ToList();

            if (itemList.Count > 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                TransferAccItem.Iban = txtIban.Text.Trim();
                TransferAccItem.Status = new EnumValue() { Id = Convert.ToInt32(ddlTransferAccStatus.SelectedValue) };
                TransferAccItem.Description = txtTransferAccDescription.Text.Trim();
                item.Name = txtBankName.Text.Trim();
                item.Status = new EnumValue() { Id = Convert.ToInt32(ddlBankStatus.SelectedValue) };
                try
                {
                    int BankId = BankData.Insert(item);
                    TransferAccItem.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = BankId };
                    int AccId = TransferAccountData.Insert(TransferAccItem);
                    if (AccId > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert Bank an Accoun";
                        itemSystemLog.Content = "Name" + item.Name + "Status=" + ddlBankStatus.SelectedValue.ToString() + "Iban=" + txtIban.Text + "Description=" + txtTransferAccDescription.Text;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Bank";
                    itemSystemLog.Content = "Name" + item.Name + "Status=" + ddlBankStatus.SelectedValue.ToString() + "Iban=" + txtIban.Text + "Description=" + txtTransferAccDescription.Text + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemBank = new IKSIR.ECommerce.Model.Bank.Bank();
            var TransferAccItem = new TransferAccount();

            TransferAccItem.Iban = txtIban.Text.Trim();
            TransferAccItem.Status = new EnumValue() { Id = Convert.ToInt32(ddlTransferAccStatus.SelectedValue) };
            TransferAccItem.Description = txtTransferAccDescription.Text.Trim();
            TransferAccItem.Id = Convert.ToInt32(lblTransferAccId.Text);
            TransferAccItem.Bank = new IKSIR.ECommerce.Model.Bank.Bank() { Id = itemId };
            itemBank.Id = itemId;
            itemBank.Name = txtBankName.Text;
            itemBank.Status = new EnumValue() { Id = Convert.ToInt32(ddlBankStatus.SelectedValue) };

            try
            {
                if (BankData.Update(itemBank) < 0)
                {
                    if (TransferAccountData.Update(TransferAccItem) < 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Update Bank";
                        itemSystemLog.Content = "Id" + itemBank.Id + "Name" + itemBank.Name + "Status=" + ddlBankStatus.SelectedValue.ToString() + "Iban=" + txtIban.Text + "Description=" + txtTransferAccDescription.Text;
                        itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Bank";
                itemSystemLog.Content = "Id" + itemBank.Id + "Name" + itemBank.Name + "Status=" + ddlBankStatus.SelectedValue.ToString() + "Iban=" + txtIban.Text + "Description=" + txtTransferAccDescription.Text + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;

            var BinNumbeList = BinNumberData.GetBinNumberList(itemId);
            if (BinNumbeList.Count > 0)
            {
                divAlert.InnerHtml += "<span style=\"color:Red\">Bu Bankaya tanımlanmış Bin numaraları  bulunmaktadır. Önce onları silemelisiniz.</span></br>";
            }
            else
            {
                try
                {
                    if (BankData.Delete(itemId) < 0)
                    {
                        if (TransferAccountData.DeleteByBankId(itemId) < 0)
                        {
                            returnValue = true;

                            SystemLog itemSystemLog = new SystemLog();
                            itemSystemLog.Title = "Delete Bank";
                            itemSystemLog.Content = "Id=" + itemId;
                            itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                            SystemLogData.Insert(itemSystemLog);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete Bank";
                    itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return returnValue;
        }

        private void ClearForm()
        {
            txtTransferAccDescription.Text = string.Empty;
            txtIban.Text = string.Empty;
            txtBankName.Text = string.Empty;
            ddlTransferAccStatus.SelectedIndex = -1;
            ddlBankStatus.SelectedIndex = -1;
            btnSave.CommandArgument = string.Empty;
        }
    }
}