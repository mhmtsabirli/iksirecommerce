using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.AdminModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.Management.Admin
{
    public partial class Right : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetList();
            }
        }

        private void GetItem(int itemId)
        {
            IKSIR.ECommerce.Model.AdminModel.Right itemRight = RightData.Get(new IKSIR.ECommerce.Model.AdminModel.Right() { Id = itemId });

            txtTitle.Text = itemRight.Title.ToString();
            txtDescription.Text = itemRight.Description.ToString();


            pnlForm.Visible = true;

        }

        private void GetList()
        {

            List<IKSIR.ECommerce.Model.AdminModel.Right> itemList = RightData.GetRightList();

            if (txtFilterTitle.Text != "")
                itemList = itemList.Where(x => x.Title == txtFilterTitle.Text).ToList();

            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtTitle.Focus();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (SaveItem())
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

        private bool SaveItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.AdminModel.Right();

            item.Id = DBHelper.IntValue(lblId.Text);
            item.Title = txtTitle.Text.Trim();
            item.Description = txtDescription.Text.Trim();
            try
            {
                if (RightData.Save(item) > 0)
                {
                    retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Save Right";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            catch(Exception ex)
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Save Right";
                itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description + " " + ex.Message.ToString();
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }

            return retValue;
        }

        private bool DeleteItem(int itemId)
        {
            bool returnValue = false;
            var item = new IKSIR.ECommerce.Model.AdminModel.Right() { Id = itemId };
            try
            {
                if (RightData.Delete(item) < 0)
                    returnValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Right";
                itemSystemLog.Content = "Id=" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Delete Right";
                itemSystemLog.Content = "Id=" + itemId;
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return returnValue;
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}