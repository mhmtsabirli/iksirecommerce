using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    public class ModuleData
    {
        public static Module Get(Module itemModule)
        {
            var returnValue = new Module();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemModule.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetModule", parameters);
            while (dr.Read())
            {
                //TODO => tayfun
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                SiteModule siteCategory = SiteModuleData.GetSiteId(DBHelper.IntValue(dr["Id"].ToString()));
                returnValue.Site = siteCategory.Site;
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Module itemModule)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemModule.Name)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemModule.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertModule", parameters));
            returnValue = SiteModuleData.Insert(itemModule.Site.Id, returnValue);
            return returnValue;
        }

        public static int Update(Module itemModule)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemModule.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemModule.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemModule.Name)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateModule", parameters);
            returnValue = SiteModuleData.Update(itemModule.Site.Id, itemModule.Id);
            return returnValue;
        }

        public static int Save(Module itemModule)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemModule.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemModule.CreateAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemModule.Name)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveModule", parameters));
            return returnValue;
        }

        public static int Delete(Module itemModule)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemModule.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteModule", parameters);
            return returnValue;
        }

        public static List<Module> GetModuleList(Module itemModule = null)
        {
            List<Module> itemModuleList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
           
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetModule", parameters);
            itemModuleList = new List<Module>();

            while (dr.Read())
            {
                var item = new Module();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                SiteModule siteCategory = SiteModuleData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemModuleList.Add(item);
            }

            dr.Close();
            return itemModuleList;
        }

        public static List<Module> GetModuleListBySiteId(int SiteId)
        {
            List<Module> itemModuleList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", SiteId));

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetModule", parameters);
            itemModuleList = new List<Module>();

            while (dr.Read())
            {
                var item = new Module();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                SiteModule siteCategory = SiteModuleData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemModuleList.Add(item);
            }

            dr.Close();
            return itemModuleList;
        }

    }
}
