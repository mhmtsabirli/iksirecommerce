using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer
{
    public class SiteData
    {
        public static Site Get(Site itemSite)
        {
            var returnValue = new Site();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemSite.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSite", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Site itemSite)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemSite.Name)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemSite.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertSite", parameters));
            return returnValue;
        }

        public static int Update(Site itemSite)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemSite.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemSite.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemSite.Name)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateSite", parameters);
            return returnValue;
        }

        public static int Delete(Site itemSite)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemSite.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteSite", parameters);
            return returnValue;
        }

        public static List<Site> GetSiteList(Site itemSite = null)
        {
            List<Site> itemEnumList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSite", parameters);
            itemEnumList = new List<Site>();

            while (dr.Read())
            {
                var item = new Site();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                itemEnumList.Add(item);
            }

            dr.Close();
            return itemEnumList;
        }
    }
}
