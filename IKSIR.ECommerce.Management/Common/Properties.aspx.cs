using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Management.Common
{
    public partial class Properties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindValues();
                GetList();
            }
        }

        private void GetList()
        {
            List<Property> itemList = PropertyData.GetList();

            if (txtFilterPropertyName.Text != "")
                itemList = itemList.Where(x => x.Title == txtFilterPropertyName.Text).ToList();
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private void GetItem(int itemId)
        {
            var item = PropertyData.Get(itemId);
            if (item != null)
            {
                txtPropertyName.Text = item.Title;
                txtDescription.Text = item.Description;
                lblId.Text = item.Id.ToString();
            }
            pnlForm.Visible = true;
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtPropertyName.Focus();
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
            var item = PropertyData.GetList().Where(x => x.Title == txtPropertyName.Text).SingleOrDefault();

            if (item != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {
                item = new Property();
                item.Title = txtPropertyName.Text;
                item.Description = txtDescription.Text;
                try
                {
                    if (PropertyData.Insert(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Insert Property";
                        itemSystemLog.Content = "Name" + item.Title;
                        itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                        retValue = true;
                    }
                }
                catch (Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Property";
                    itemSystemLog.Content = "Name" + item.Title + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var item = PropertyData.GetList().Where(x => x.Id == itemId).SingleOrDefault();

            if (item != null)
            {
                //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
                //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
                //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
                item.Id = itemId;
                item.Title = txtPropertyName.Text;
                item.Description = txtDescription.Text;

                try
                {
                    if (PropertyData.Update(item) > 0)
                    {
                        retValue = true;

                        SystemLog itemSystemLog = new SystemLog();
                        itemSystemLog.Title = "Update Property";
                        itemSystemLog.Content = "Id" + item.Id + "Title" + item.Title;
                        itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                        SystemLogData.Insert(itemSystemLog);
                        retValue = true;
                    }
                }
                catch(Exception ex)
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Update Property";
                    itemSystemLog.Content = "Id" + item.Id + "Title" + item.Title + " " + ex.Message.ToString();
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new Property() { Id = itemId };
            try
            {
                if (PropertyData.Delete(item) < 0)
                {
                    returnValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Delete Property";
                    itemSystemLog.Content = "Id=" + itemId;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch(Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Property";
                itemSystemLog.Content = "Id=" + itemId + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            txtPropertyName.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}