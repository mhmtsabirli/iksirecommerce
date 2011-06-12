using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer;
using IKSIR.ECommerce.Infrastructure;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.AdminModel;
using System.Reflection;

using System.Data;



namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AdminData adminData = new AdminData();

            DataTable dt = adminData.WebGetMembershipAdminDetails(1);
            MapList<Admin>(dt);


        }
        public static List<T> MapList<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            PropertyInfo[] infos = typeof(T).GetProperties();
            Type type = typeof(T);

            object[] b = new object[infos.Length];

            for (int i = 0; i < infos.Length; i++)
                b[i] = null;


            T a = (T)Activator.CreateInstance(typeof(T),b);
            foreach (DataRow dr in dt.Rows)
            {
                foreach (PropertyInfo info in infos)
                {
                    switch (info.PropertyType.ToString())
                    {
                        case "System.DateTime":
                            info.SetValue(a, DBHelper.DateValue(dr[info.Name]), null);
                            break;
                        case "System.Int32":
                            info.SetValue(a, DBHelper.IntValue(dr[info.Name]), null);
                            break;
                        case "System.String":
                            info.SetValue(a, DBHelper.StrValue(dr[info.Name]), null);
                            break;
                        case "System.Decimal":
                            info.SetValue(a, DBHelper.DecValue(dr[info.Name]), null);
                            break;
                        default:
                            info.SetValue(a, dr[info.Name], null);
                            break;
                        
                    }
                }
                list.Add(a);
            } return list;
        }

    }
}
