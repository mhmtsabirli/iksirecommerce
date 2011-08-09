using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Management.MasterPage;

namespace IKSIR.ECommerce.Management.Logs
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }



        private void GetList()
        {
            //TODO tayfun   linq kullanılan kısımlarda filtereleme yapılamıyor where kosulu calısmıyor
            SystemLog log = new SystemLog();
            if (txtTitle.Text != "")
                log.Title = txtTitle.Text;
            else
                log.Title = " ";
            log.Type = new EnumValue() { Id = Convert.ToInt32(ddlType.SelectedValue) };
            List<SystemLog> itemList = SystemLogData.GetSystemLogs(log);

            gvList.DataSource = itemList;
            gvList.DataBind();
        }



        protected void btnFilter_Click(object sender, EventArgs e)
        {
            GetList();
        }

    }
}