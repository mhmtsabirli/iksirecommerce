﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductData
    {
        public static Product Get(Product itemProduct)
        {
            var returnValue = new Product();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProduct.Id));
          //  parameters.Add(new SqlParameter("@ProductCategoryId	", itemProduct.ProductCategory[0].Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProduct", parameters);
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
            returnValue.ProductCode = DBHelper.StringValue(dr["ProductCode"].ToString());
            returnValue.MinStock = DBHelper.IntValue(dr["MinStock"].ToString());
            returnValue.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
            //returnValue.ProductCategory = ProductCategoryData.GetProductCategoryById((DBHelper.IntValue(dr["ProductCategory"].ToString())));
            dr.Close();
            return returnValue;
        }

        public static int Insert(Product itemProduct)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProduct.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProduct.Description)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemProduct.ProductCode)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemProduct.MinStock)));
            parameters.Add(new SqlParameter("@CreateUserId", DBHelper.IntValue(itemProduct.CreateAdminId)));
            parameters.Add(new SqlParameter("@AlertDate", DBHelper.DateValue(itemProduct.AlertDate)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemProduct.ProductCategory.Id)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProduct", parameters));
            return returnValue;
        }

        public static int Update(Product itemProduct)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemProduct.Id));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProduct.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProduct.Description)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemProduct.ProductCode)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemProduct.MinStock)));
            parameters.Add(new SqlParameter("@AlertDate", DBHelper.DateValue(itemProduct.AlertDate)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemProduct.ProductCategory.Id)));
            parameters.Add(new SqlParameter("@EditUserId", DBHelper.IntValue(itemProduct.EditAdminId)));


            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProduct", parameters);
            return returnValue;
        }

        public static int Delete(Product itemProduct)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProduct.Id));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProduct", parameters);
            return returnValue;
        }

        public  static List<Product> GetProductList(Product itemProduct)
        {
            List<Product> itemProductList = new List<Product>();
           
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProduct.Id));
            parameters.Add(new SqlParameter("@ProductCategoryId	", itemProduct.ProductCategory.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProduct", parameters);

            var item = new Product();
            while (dr.Read())
            {
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.ProductCode = DBHelper.StringValue(dr["ProductCode"].ToString());
                item.MinStock = DBHelper.IntValue(dr["MinStock"].ToString());
                item.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
                //returnValue.ProductCategory =ProductCategory.Get(DBHelper.IntValue(dr["ProductCategory"].ToString()));
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }
    }
}
