using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer
{
    public class SiteModuleData
    {
        public static SiteModule Get(SiteModule itemSiteModule)
        {
            var returnValue = new SiteModule();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", itemSiteModule.Site.Id));
            parameters.Add(new SqlParameter("@CategoryId", itemSiteModule.Module.Id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteModule", parameters);
            while (dr.Read())
            {
                

                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Module = ModuleData.Get(new Module() { Id = DBHelper.IntValue(dr["ModuleId"].ToString()) });
            }
            dr.Close();
            return returnValue;
        }

        public static SiteModule Get(int ModuleId)
        {
            var returnValue = new SiteModule();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", 0));
            parameters.Add(new SqlParameter("@ModuleId", ModuleId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteModule", parameters);
            while (dr.Read())
            {
                

                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Module = ModuleData.Get(new Module() { Id = DBHelper.IntValue(dr["ModuleId"].ToString()) });
            }
            dr.Close();
            return returnValue;
        }
        public static SiteModule GetSiteId(int ModuleId)
        {
            var returnValue = new SiteModule();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", 0));
            parameters.Add(new SqlParameter("@ModuleId", ModuleId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteModule", parameters);
            while (dr.Read())
            {
                

                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
            }
            dr.Close();
            return returnValue;
        }
        public static int Insert(int SiteId,int ModuleId)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SiteId", SiteId));
            parameters.Add(new SqlParameter("@ModuleId", ModuleId));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(0)));


            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertSiteModule", parameters));
            return returnValue;
        }

        public static int Update(int SiteId, int ModuleId)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", SiteId));
            parameters.Add(new SqlParameter("@ModuleId", ModuleId));
            parameters.Add(new SqlParameter("@EditAdminId", 0));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateSiteModule", parameters);
            return returnValue;
        }

        public static int Delete(SiteModule itemSiteModule)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemSiteModule.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteSiteModule", parameters);
            return returnValue;
        }

        public static List<SiteModule> GetSiteModuleList(SiteModule itemSiteModule = null)
        {
            List<SiteModule> itemSiteModuleList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", itemSiteModule.Site.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteModule", parameters);
            itemSiteModuleList = new List<SiteModule>();

            while (dr.Read())
            {
                var item = new SiteModule();
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Module = ModuleData.Get(new Module() { Id = DBHelper.IntValue(dr["ModuleId"].ToString()) });


                itemSiteModuleList.Add(item);
            }

            dr.Close();
            return itemSiteModuleList;
        }

    }
}
