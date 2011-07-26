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


namespace IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer
{
    public class SiteCategoryData
    {
        public static SiteCategory Get(SiteCategory itemSiteCategory)
        {
            var returnValue = new SiteCategory();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", itemSiteCategory.Site.Id));
            parameters.Add(new SqlParameter("@CategoryId", itemSiteCategory.ProductCategory.Id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteCategory", parameters);
            while (dr.Read())
            {
                

                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["CategoryId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static SiteCategory Get(int CategoryId)
        {
            var returnValue = new SiteCategory();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", 0));
            parameters.Add(new SqlParameter("@CategoryId", CategoryId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteCategory", parameters);
            while (dr.Read())
            {
                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["CategoryId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }
        public static int Insert(int SiteId, int CategoryId)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@SiteId", SiteId));
            parameters.Add(new SqlParameter("@CategoryId", CategoryId));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(0)));


            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertSiteCategory", parameters));
            return returnValue;
        }

        public static int Update(int SiteId, int CategoryId)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", SiteId));
            parameters.Add(new SqlParameter("@CategoryId", CategoryId));
            parameters.Add(new SqlParameter("@EditAdminId", 0));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateSiteCategory", parameters);
            return returnValue;
        }

        public static int Delete(SiteCategory itemSiteCategory)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemSiteCategory.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteSiteCategory", parameters);
            return returnValue;
        }

        public static List<SiteCategory> GetSiteCategoryList(SiteCategory itemSiteCategory = null)
        {
            List<SiteCategory> itemSiteCategoryList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", itemSiteCategory.Site.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSiteCategory", parameters);
            itemSiteCategoryList = new List<SiteCategory>();

            while (dr.Read())
            {
                var item = new SiteCategory();
                
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["CategoryId"].ToString()));
                //item.ParentCategory = GetProductCategoryById(DBHelper.IntValue(dr["Id"].ToString())); =>ayhant
                itemSiteCategoryList.Add(item);
            }

            dr.Close();
            return itemSiteCategoryList;
        }

    }
}
