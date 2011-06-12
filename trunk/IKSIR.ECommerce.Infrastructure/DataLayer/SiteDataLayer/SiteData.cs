using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer
{
    public class SiteData
    {
        public DataTable GetSiteDetails(int SiteId)
        {
            DataTable dtAdmin = new DataTable();
            SqlConnection con = new SqlConnection(StaticData.Idevit.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSite";
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@Id", AdminID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtAdmin);
            con.Close();
            return dtAdmin;
        }
    }
}
