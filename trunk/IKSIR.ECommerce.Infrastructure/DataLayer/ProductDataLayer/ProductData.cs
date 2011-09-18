using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductData
    {
        public static Product Get(int id)
        {
            var returnValue = new Product();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProduct", parameters);
            while (dr.Read())
            {

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
                returnValue.Desi = DBHelper.StringValue(dr["Desi"].ToString());
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
                // returnValue.RelatedProduct = RelatedProductData.Get(DBHelper.IntValue(dr["Id"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int FindProductId(string ProductCode)
        {
            var returnValue = new Product();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProdCode", ProductCode));

            return DBHelper.IntValue(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductforProductCode", parameters));
        }

        public static int Insert(Product itemProduct)
        {
            var returnValue = 0;



            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemProduct.Id)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProduct.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProduct.Description)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemProduct.ProductCode)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemProduct.MinStock)));
            parameters.Add(new SqlParameter("@Video", DBHelper.StringValue(itemProduct.Video)));
            parameters.Add(new SqlParameter("@Desi", DBHelper.StringValue(itemProduct.Desi)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemProduct.CreateAdminId)));
            parameters.Add(new SqlParameter("@AlertDate", DBHelper.DateValue(itemProduct.AlertDate)));
            parameters.Add(new SqlParameter("@Guarantee", DBHelper.IntValue(itemProduct.Guarantee)));
            parameters.Add(new SqlParameter("@Stok", DBHelper.IntValue(itemProduct.Stok)));
            parameters.Add(new SqlParameter("@MaxQuantity", DBHelper.IntValue(itemProduct.MaxQuantity)));
            parameters.Add(new SqlParameter("@StokStatus", DBHelper.IntValue(itemProduct.StokStatus.Id)));
            parameters.Add(new SqlParameter("@ProductStatus", DBHelper.IntValue(itemProduct.ProductStatus.Id)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemProduct.ProductCategory.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProduct", parameters));
            //returnValue = Convert.ToInt32(parameters[0].Value);
            return returnValue;
        }

        public static int Update(Product itemProduct)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemProduct.Id));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemProduct.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemProduct.Description)));
            parameters.Add(new SqlParameter("@Video", DBHelper.StringValue(itemProduct.Video)));
            parameters.Add(new SqlParameter("@Desi", DBHelper.StringValue(itemProduct.Desi)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemProduct.ProductCode)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemProduct.MinStock)));
            parameters.Add(new SqlParameter("@AlertDate", DBHelper.DateValue(itemProduct.AlertDate)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemProduct.ProductCategory.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemProduct.EditAdminId)));
            parameters.Add(new SqlParameter("@Guarantee", DBHelper.IntValue(itemProduct.Guarantee)));
            parameters.Add(new SqlParameter("@Stok", DBHelper.IntValue(itemProduct.Stok)));
            parameters.Add(new SqlParameter("@MaxQuantity", DBHelper.IntValue(itemProduct.MaxQuantity)));
            parameters.Add(new SqlParameter("@StokStatus", DBHelper.IntValue(itemProduct.StokStatus.Id)));
            parameters.Add(new SqlParameter("@ProductStatus", DBHelper.IntValue(itemProduct.ProductStatus.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProduct", parameters);
            return returnValue;
        }

        public static int Delete(int productId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", productId));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProduct", parameters);
            returnValue = 1; //TODO: ayhant=> düzeltilecek
            return returnValue;
        }

        public static List<Product> GetList()
        {
            List<Product> itemProductList = new List<Product>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductList", parameters);

            while (dr.Read())
            {
                var item = new Product();

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
                item.Desi = DBHelper.StringValue(dr["Desi"].ToString());
                item.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
                item.ProductStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ProductStatus"].ToString()) });
                item.Guarantee = DBHelper.IntValue(dr["Guarantee"].ToString());
                item.Stok = DBHelper.IntValue(dr["Stok"].ToString());
                item.MaxQuantity = DBHelper.IntValue(dr["MaxQuantity"].ToString());
                item.StokStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["StokStatus"].ToString()) });
                item.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["ProductCategoryId"].ToString()));
                item.ProductPrice = ProductPriceData.GetByProduct(DBHelper.IntValue(dr["Id"].ToString()));
                item.Multimedias = MultimediasData.GetItemMultimedias(3, DBHelper.IntValue(dr["Id"].ToString()));
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }


        public static List<Product> CheckProductStock()
        {
            List<Product> itemProductList = new List<Product>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductStock", parameters);

            while (dr.Read())
            {
                var item = new Product();

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
                item.Desi = DBHelper.StringValue(dr["Desi"].ToString());
                item.AlertDate = DBHelper.DateValue(dr["AlertDate"].ToString());
                item.ProductStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ProductStatus"].ToString()) });
                item.Guarantee = DBHelper.IntValue(dr["Guarantee"].ToString());
                item.Stok = DBHelper.IntValue(dr["Stok"].ToString());
                item.MaxQuantity = DBHelper.IntValue(dr["MaxQuantity"].ToString());
                item.StokStatus = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["StokStatus"].ToString()) });
                //item.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["ProductCategoryId"].ToString()));
                //item.ProductPrice = ProductPriceData.GetByProduct(DBHelper.IntValue(dr["Id"].ToString()));
                //item.Multimedias = MultimediasData.GetItemMultimedias(3, DBHelper.IntValue(dr["Id"].ToString()));
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }

        public static int CheckProductStockCount()
        {
            List<Product> itemProductList = new List<Product>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductStockCount", parameters);

            int count = 0;
            while (dr.Read())
            {
                count = DBHelper.IntValue(dr["Count"].ToString());
            }
            dr.Close();
            return count;
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

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Video = DBHelper.StringValue(dr["Video"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Desi = DBHelper.StringValue(dr["Desi"].ToString());
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
                item.ProductPrice = ProductPriceData.GetByProduct(DBHelper.IntValue(dr["Id"].ToString()));
                item.Multimedias = MultimediasData.GetItemMultimedias(3, DBHelper.IntValue(dr["Id"].ToString()));
                itemProductList.Add(item);
            }

            dr.Close();
            return itemProductList;
        }
    }
}
