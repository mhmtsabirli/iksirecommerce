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
    public partial class EnumValues : System.Web.UI.Page
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
            txtEnumValueName.Focus();
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
            var item = new IKSIR.ECommerce.Model.CommonModel.EnumValue  () { Id = Convert.ToInt32(itemId) };
            IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue = EnumValueData.Get(item);
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            txtEnumValueName.Text = itemEnumValue.Value.ToString();
            if (itemEnumValue.EnumId != null)
            {
                ddlEnums.SelectedValue = (itemEnumValue.EnumId.ToString());
                
            }
            else
                ddlEnums.SelectedValue = "";

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
            var item = new IKSIR.ECommerce.Model.CommonModel.EnumValue() { Id = itemId };
            if (EnumValueData.Delete(item) < 0)
                returnValue = true;

            return returnValue;
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void BindValues()
        {
            //Buralarda tüm kategoriler gelecek istediği kategorinin altına tanımlama yapabilecek.
            List<IKSIR.ECommerce.Model.CommonModel.Enum> itemList = EnumData.GetEnumList();
            ddlEnums.DataSource = itemList;
            ddlEnums.DataTextField = "Name";
            ddlEnums.DataValueField = "Id";
            ddlEnums.DataBind();

            ddlFilterEnums.DataSource = itemList;
            ddlFilterEnums.DataTextField = "Name";
            ddlFilterEnums.DataValueField = "Id";
            ddlFilterEnums.DataBind();
        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<IKSIR.ECommerce.Model.CommonModel.EnumValue> itemList = EnumValueData.GetEnumValueList();
            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            if (txtFilterEnumValueName.Text != "")
                itemList.Where(x => x.Value.Contains(txtFilterEnumValueName.Text));
            if (ddlFilterEnums.SelectedValue != "-1" && ddlFilterEnums.SelectedValue != "")
            {
                var item = new IKSIR.ECommerce.Model.CommonModel.Enum() { Id = Convert.ToInt32(ddlFilterEnums.SelectedValue) };
                itemList.Where(x => Convert.ToInt32(ddlFilterEnums.SelectedValue) == item.Id);
            }
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.CommonModel.EnumValue();

            //item kaydedilmeden dbde olup olmadığına dair kontroller yapıyorumz.
            if (item.Value != null)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Bu item zaten kayıtlıdır. Filtreleryerek kayda erişebilirsiniz.";
                retValue = false;
            }
            else
            {

                item.EnumId = Convert.ToInt32(ddlEnums.SelectedValue);
                item.Value = txtEnumValueName.Text.Trim();
                if (EnumValueData.Insert(item) > 0)
                    retValue = true;
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemEnumValue = new IKSIR.ECommerce.Model.CommonModel.EnumValue();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            itemEnumValue.Id = itemId;
            itemEnumValue.Value = txtEnumValueName.Text;
            if (ddlEnums.SelectedItem.Value != "")
                itemEnumValue.EnumId = Convert.ToInt32(ddlEnums.SelectedItem.Value);
            if (EnumValueData.Update(itemEnumValue) < 0)
                retValue = true;

            return retValue;
        }

        private void ClearForm()
        {
            ddlEnums.SelectedIndex = -1;
            txtEnumValueName.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }

    }
}