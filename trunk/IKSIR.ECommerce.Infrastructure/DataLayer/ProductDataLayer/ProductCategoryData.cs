using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;

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
            dr.Read();
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
            parameters.Add(new SqlParameter("@ParentId", DBHelper.IntValue(itemProductCategory.ParentCategory.Id)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductCategory", parameters));
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
            parameters.Add(new SqlParameter("@ErrorCode",ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProductCategory", parameters);
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
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                //item.ParentCategory = GetProductCategoryById(DBHelper.IntValue(dr["Id"].ToString())); =>ayhant
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
    }
}
