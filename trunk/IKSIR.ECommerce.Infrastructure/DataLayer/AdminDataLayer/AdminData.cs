using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer
{
    public class AdminData
    {
        public DataTable WebGetMembershipAdminDetails(int AdminID)
        {
            DataTable dtAdmin = new DataTable();
            SqlConnection con = new SqlConnection(StaticData.Idevit.ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText="GetAdmin";
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@Id", AdminID));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dtAdmin);
            con.Close();
            return dtAdmin;
        }
    }
}
