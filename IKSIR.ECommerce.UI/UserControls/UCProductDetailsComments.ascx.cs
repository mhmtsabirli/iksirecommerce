using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.MembershipModel;

namespace IKSIR.ECommerce.UI.UserControls
{
    public partial class UCProductDetailsComments : UCProductDetailsMaster
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack && productId != 0)
            {
                GetProductComments();
                if (Session["LOGIN_USER"] == null)
                {
                    btnAddComment.Visible = false;
                    hplLogin.Visible = true;
                    hplLogin.NavigateUrl = "../SecuredPages/Login.aspx?returl=ProductDetails.aspx?pid=" + productId.ToString();
                }
                else
                {
                    User user = (User)Session["LOGIN_USER"];
                    txtUserName.Text = user.FirstName + " " + user.LastName;
                    txtUserName.Enabled = false;
                    hplLogin.Visible = false;
                }
            }
        }

        private void GetProductComments()
        {
            try
            {
                var commentList = CommentData.GetCommentList(productId);
                gvProductComments.DataSource = commentList;
                gvProductComments.DataBind();
            }
            catch (Exception exception)
            {
            }
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {

            var item = new Comment();
            item.Title = txtTitle.Text;
            item.Content = txtContent.Text;
            item.Status = new EnumValue() { Id = 40 };
            if (Session["LOGIN_USER"] != null)
            {
                User user = (User)Session["LOGIN_USER"];
                item.User = new User() { Id = user.Id };
            }
            else
            {
                btnAddComment.Visible = false;
                hplLogin.Visible = true;
                return;
            }
            item.Product = new Product() { Id = productId };
            int retValue = CommentData.Insert(item);
            if (retValue > 0)
            {
                lblAlert.Text = "Yorumunuz başarıyla kaydedilmiştir.";
                lblAlert.ForeColor = System.Drawing.Color.Green;
                GetProductComments();
            }
            else
            {
                lblAlert.Text = "Yorumunuz kaydedilirken bir hata oluştu.";
                lblAlert.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}