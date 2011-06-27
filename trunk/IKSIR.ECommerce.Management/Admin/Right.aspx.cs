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

        protected void lbtnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblId.Text = "Yeni Kayıt";
            pnlForm.Visible = true;
            txtTitle.Focus();
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
            IKSIR.ECommerce.Model.AdminModel.Right itemRight = RightData.Get(new IKSIR.ECommerce.Model.AdminModel.Right() { Id = itemId });

            txtTitle.Text = itemRight.Title.ToString();
            txtDescription.Text = itemRight.Description.ToString();
            

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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor

            List<IKSIR.ECommerce.Model.AdminModel.Right> itemList = RightData.GetRightList();
            
            if (txtFilterTitle.Text != "")
                itemList.Where(x => x.Title.Contains(txtFilterTitle.Text));
          
            gvList.DataSource = itemList;
            gvList.DataBind();
        }

        private bool InsertItem()
        {
            bool retValue = false;
            var item = new IKSIR.ECommerce.Model.AdminModel.Right();

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

              
                item.Title = txtTitle.Text.Trim();
                item.Description = txtDescription.Text.Trim();
                try
                {
                    if (RightData.Insert(item) > 0)
                        retValue = true;

                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Right";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description;
                    itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
                catch
                {
                    SystemLog itemSystemLog = new SystemLog();
                    itemSystemLog.Title = "Insert Right";
                    itemSystemLog.Content = "Title=" + item.Title + "Description =" + item.Description;
                    itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                    SystemLogData.Insert(itemSystemLog);
                }
            }
            return retValue;
        }

        private bool UpdateItem(int itemId)
        {
            bool retValue = false;
            var itemRight = new IKSIR.ECommerce.Model.AdminModel.Right();

            //var itemXml = new IKSIR.ECommerce.Toolkit.Utility();
            //var serializedObject = itemXml.XMLSerialization.ToXml(itemList);
            //Yukarıdaki şekilde alabiliyor olmamız lazım ama hata veriyor. bakıacak => ayhant
            itemRight.Id = itemId;
            itemRight.Title = txtTitle.Text;
            itemRight.Description = txtDescription.Text;
           

            try
            {
                if (RightData.Update(itemRight) < 0)
                    retValue = true;

                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Right";
                itemSystemLog.Content = "Id=" + itemRight.Id + "Title=" + itemRight.Title + "Description =" + itemRight.Description;
                itemSystemLog.Type = new EnumValue() { Id = 1 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            catch
            {
                SystemLog itemSystemLog = new SystemLog();
                itemSystemLog.Title = "Update Right";
                itemSystemLog.Content = "Id=" + itemRight.Id + "Title=" + itemRight.Title + "Description =" + itemRight.Description;
                itemSystemLog.Type = new EnumValue() { Id = 0 };//olumsu sonuc 1 olumsuz 0
                SystemLogData.Insert(itemSystemLog);
            }
            return retValue;
        }

        private void ClearForm()
        {
            txtTitle.Text = string.Empty;
            txtDescription.Text = string.Empty;
            btnSave.CommandArgument = string.Empty;
        }
    }
}