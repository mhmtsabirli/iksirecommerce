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


namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class SimilarProductData
    {
        public static List<Product> GetSimilarProductList(int ProductId)
        {
            var itemList = new List<Product>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", ProductId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSimilarProduct", parameters);
            while (dr.Read())
            {
                var returnValue = new Product();
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Video = DBHelper.StringValue(dr["Video"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.ProductCode = DBHelper.StringValue(dr["ProductCode"].ToString());
                returnValue.MinStock = DBHelper.IntValue(dr["MinStock"].ToString());
                returnValue.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
                returnValue.ProductStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ProductStatus"].ToString()) });
                returnValue.Guarantee = DBHelper.IntValue(dr["Guarantee"].ToString());
                returnValue.Stok = DBHelper.IntValue(dr["Stok"].ToString());
                returnValue.MaxQuantity = DBHelper.IntValue(dr["MaxQuantity"].ToString());
                returnValue.StokStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["StokStatus"].ToString()) });
                returnValue.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["ProductCategoryId"].ToString()));
                returnValue.ProductPrice = ProductPriceData.GetByProduct(DBHelper.IntValue(dr["Id"].ToString()));
                returnValue.Multimedias = MultimediasData.GetItemMultimedias(3, DBHelper.IntValue(dr["Id"].ToString()));
                itemList.Add(returnValue);
            }
            dr.Close();
            return itemList;
        }

        public static int Insert(int ProductId, int SimilarProductId)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(ProductId)));
            parameters.Add(new SqlParameter("@SimilarProductId", DBHelper.IntValue(SimilarProductId)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(0)));


            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertSimilarProduct", parameters));
            return returnValue;
        }

        public static int Delete(int ProductId, int SimilarProductId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@SimilarProductId", SimilarProductId));
            parameters.Add(new SqlParameter("@ProductId", ProductId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteSimilarProduct", parameters);
            return returnValue;
        }

    }
}
