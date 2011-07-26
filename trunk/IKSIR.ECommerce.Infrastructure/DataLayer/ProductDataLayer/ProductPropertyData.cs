using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.ProductModel;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductPropertyData
    {
        public static ProductProperty Get(int id)
        {
            var returnValue = new ProductProperty();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductProperties", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Value = DBHelper.StringValue(dr["Value"].ToString());
                returnValue.ProductId = DBHelper.IntValue(dr["ProductId"].ToString());
                returnValue.Property = PropertyData.Get(DBHelper.IntValue(dr["PropertyId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(ProductProperty itemProductProperty)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemProductProperty.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", 1));
            parameters.Add(new SqlParameter("@PropertyId", DBHelper.IntValue(itemProductProperty.Property.Id)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemProductProperty.ProductId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemProductProperty.Value)));
            parameters[0].Direction = ParameterDirection.Output;
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductProperty", parameters));
            returnValue = Convert.ToInt32(parameters[0].Value);
            return returnValue;
        }

        public static int Update(ProductProperty itemProductProperty)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EditAdminId", 1));
            parameters.Add(new SqlParameter("@PropertyId", DBHelper.IntValue(itemProductProperty.Property.Id)));
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemProductProperty.Id)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemProductProperty.ProductId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemProductProperty.Value)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProductProperty", parameters);
            return returnValue;
        }

        public static int Delete(ProductProperty itemProduct)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemProduct.Id));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProduct", parameters);
            return returnValue;
        }

        public static int Delete(int id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProductProperties", parameters);
            return returnValue;
        }
        public static List<ProductProperty> GetProductProperties(int productId)
        {
            List<ProductProperty> itemProductList = new List<ProductProperty>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", productId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductProperties", parameters);

            while (dr.Read())
            {
                var item = new ProductProperty();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Property = PropertyData.Get(DBHelper.IntValue(dr["PropertyId"].ToString()));
                item.ProductId = DBHelper.IntValue(dr["ProductId"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }
    }
}
