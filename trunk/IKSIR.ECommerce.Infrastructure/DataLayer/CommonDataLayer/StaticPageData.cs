using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    public class StaticPageData
    {
        public static StaticPage Get(int id)
        {
            var returnValue = new StaticPage();
            try
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetStaticPage", parameters);
                dr.Read();
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Site = SiteDataLayer.SiteData.Get(new Model.SiteModel.Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.PageContent = DBHelper.StringValue(dr["PageContent"].ToString());
                dr.Close();
            }
            catch (Exception exception)
            {
                throw;
            }
            return returnValue;
        }

        public static int Insert(StaticPage item)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(item.CreateAdminId)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(item.Site.Id)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(item.Title)));
            parameters.Add(new SqlParameter("@PageContent", DBHelper.StringValue(item.PageContent)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertStaticPage", parameters));
            return returnValue;
        }

        public static int Update(StaticPage item)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", item.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(item.EditAdminId)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(item.Site.Id)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(item.Title)));
            parameters.Add(new SqlParameter("@PageContent", DBHelper.StringValue(item.PageContent)));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateStaticPage", parameters);
            return returnValue;
        }

        public static int Save(StaticPage item)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(item.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(item.CreateAdminId)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(item.Site.Id)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(item.Title)));
            parameters.Add(new SqlParameter("@PageContent", DBHelper.StringValue(item.PageContent)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveStaticPage", parameters));
            return returnValue;
        }

        public static int Delete(int id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteStaticPage", parameters);
            return returnValue;
        }

        public static List<StaticPage> GetList()
        {
            List<StaticPage> itemList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetStaticPage", parameters);
            itemList = new List<StaticPage>();

            while (dr.Read())
            {
                var item = new StaticPage();
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Site = SiteDataLayer.SiteData.Get(new Model.SiteModel.Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.PageContent = DBHelper.StringValue(dr["PageContent"].ToString());
                itemList.Add(item);
            }
            dr.Close();
            return itemList;
        }
    }
}
