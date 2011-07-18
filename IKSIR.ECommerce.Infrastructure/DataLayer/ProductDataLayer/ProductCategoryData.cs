using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductCategoryData
    {
        public static ProductCategory Get(ProductCategory itemProductCategory)
        {
            var returnValue = new ProductCategory();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            if (itemProductCategory.ParentCategory != null)
                parameters.Add(new SqlParameter("@ProductCategoryId	", itemProductCategory.ParentCategory.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductCategory", parameters);
            while (dr.Read())
            {
                //TODO => tayfun
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                if (DBHelper.IntValue(dr["ParentId"].ToString()) != 0)
                    returnValue.ParentCategory = Get(new ProductCategory() { Id = DBHelper.IntValue(dr["ParentId"].ToString()) });
                //returnValue.ParentCategory. = GetProductCategoryById(DBHelper.IntValue(dr["ParentId"].ToString()));
                SiteCategory siteCategory = SiteCategoryData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                returnValue.Site = siteCategory.Site;
            }
            dr.Close();
            return returnValue;
        }

        public static ProductCategory Get(int id)
        {
            var returnValue = new ProductCategory();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductCategory", parameters);
            while (dr.Read())
            {
                //TODO => tayfun
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                if (DBHelper.IntValue(dr["ParentId"].ToString()) != 0)
                    returnValue.ParentCategory = Get(new ProductCategory() { Id = DBHelper.IntValue(dr["ParentId"].ToString()) });
                //returnValue.ParentCategory. = GetProductCategoryById(DBHelper.IntValue(dr["ParentId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(ProductCategory itemProductCategory)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProductCategory.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProductCategory.Description)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemProductCategory.CreateAdminId)));
            if (itemProductCategory.ParentCategory != null)
                parameters.Add(new SqlParameter("@ParentId", DBHelper.IntValue(itemProductCategory.ParentCategory.Id)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductCategory", parameters));
            returnValue = SiteDataLayer.SiteCategoryData.Insert(itemProductCategory.Site.Id, returnValue);
            return returnValue;
        }

        public static int Update(ProductCategory itemProductCategory)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProductCategory.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProductCategory.Description)));
            if (itemProductCategory.ParentCategory != null)
                parameters.Add(new SqlParameter("@ParentId", DBHelper.IntValue(itemProductCategory.ParentCategory.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemProductCategory.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProductCategory", parameters);
            returnValue = SiteCategoryData.Update(itemProductCategory.Site.Id, itemProductCategory.Id);

            return returnValue;
        }

        public static int Delete(ProductCategory itemProductCategory)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProductCategory", parameters);
            return returnValue;
        }

        public static List<ProductCategory> GetProductCategoryList(ProductCategory itemProductCategory = null)
        {
            List<ProductCategory> itemProductCategoryList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            //if (itemProductCategory != null)
            //    parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            //if (itemProductCategory.ParentCategory != null)
            //    parameters.Add(new SqlParameter("@ProductCategoryId", itemProductCategory.ParentCategory.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductCategory", parameters);
            itemProductCategoryList = new List<ProductCategory>();

            while (dr.Read())
            {
                var item = new ProductCategory();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                if (DBHelper.IntValue(dr["ParentId"].ToString()) != 0)
                    item.ParentCategory = Get(DBHelper.IntValue(dr["ParentId"].ToString()));
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                SiteCategory siteCategory = SiteCategoryData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemProductCategoryList.Add(item);
            }

            dr.Close();
            return itemProductCategoryList;
        }

        public static List<ProductCategory> GetParentProductCategoryList(ProductCategory itemProductCategory = null)
        {
            List<ProductCategory> itemProductCategoryList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
           
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetParentProductCategory", parameters);
            itemProductCategoryList = new List<ProductCategory>();

            while (dr.Read())
            {
                var item = new ProductCategory();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                if (DBHelper.IntValue(dr["ParentId"].ToString()) != 0)
                    item.ParentCategory = Get(DBHelper.IntValue(dr["ParentId"].ToString()));
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                SiteCategory siteCategory = SiteCategoryData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemProductCategoryList.Add(item);
            }

            dr.Close();
            return itemProductCategoryList;
        }
        
        public static List<ProductCategory> GetGetParentProductCategoryListBySiteId(int SiteId)
        {
            List<ProductCategory> itemProductCategoryList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SiteId", SiteId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetParentProductCategory", parameters);
            itemProductCategoryList = new List<ProductCategory>();

            while (dr.Read())
            {
                var item = new ProductCategory();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                if (DBHelper.IntValue(dr["ParentId"].ToString()) != 0)
                    item.ParentCategory = Get(DBHelper.IntValue(dr["ParentId"].ToString()));
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                SiteCategory siteCategory = SiteCategoryData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemProductCategoryList.Add(item);
            }

            dr.Close();
            return itemProductCategoryList;
        }

        public static List<ProductCategory> GetProductCategoryById(int productCategoryId)
        {
            List<ProductCategory> itemProductCategoryList = new List<ProductCategory>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ParentId", productCategoryId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductCategory", parameters);


            while (dr.Read())
            {
                var item = new ProductCategory();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                //item.ParentId = GetProductCategoryById(DBHelper.IntValue(dr["Id"].ToString())); =>ayhant
                SiteCategory siteCategory = SiteCategoryData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.Site = siteCategory.Site;
                itemProductCategoryList.Add(item);
            }

            dr.Close();
            return itemProductCategoryList;


        }

        public static string GetProductCategory(int ParentId)
        {
            string Result = "";
            string XmlQuery = "";

            if (ParentId == 0)
                XmlQuery = "select Id as Value,Title as Text from ProductCategories as Item where ParentId is null  for xml auto ";
            else
                XmlQuery = "select Id as Value,Title as Text from ProductCategories as Item where ParentId=" + ParentId + "  for xml auto ";
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.Text, XmlQuery);
            dr.Read();
            Result = dr[0].ToString();

            dr.Close();
            return Result;
        }

        public static List<Product> GetProductCategoryList(int CategoryId)
        {
            List<Product> itemProductList = new List<Product>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductCategoryId", CategoryId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductList", parameters);

            while (dr.Read())
            {
                var item = new Product();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Video = DBHelper.StringValue(dr["Video"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.ProductCode = DBHelper.StringValue(dr["ProductCode"].ToString());
                item.MinStock = DBHelper.IntValue(dr["MinStock"].ToString());
                item.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
                item.ProductStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ProductStatus"].ToString()) });
                item.Guarantee = DBHelper.IntValue(dr["Guarantee"].ToString());
                item.Stok = DBHelper.IntValue(dr["Stok"].ToString());
                item.MaxQuantity = DBHelper.IntValue(dr["MaxQuantity"].ToString());
                item.StokStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["StokStatus"].ToString()) });
                item.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["ProductCategoryId"].ToString()));
                item.ProductPrice = ProductPriceData.GetByProduct(DBHelper.IntValue(dr["ProductId"].ToString()));
                item.Multimedias = MultimediasData.GetItemMultimedias(3, DBHelper.IntValue(dr["Id"].ToString()));
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }
    }
}
