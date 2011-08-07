using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class BasketItemProductData
    {
        public static Product Get(int id)
        {
            var returnValue = new Product();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasketItemProduct", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.ProductCode = DBHelper.StringValue(dr["ProductCode"].ToString());
                returnValue.ProductCategory = ProductCategoryData.Get(DBHelper.IntValue(dr["ProductCategoryId"].ToString()));
                returnValue.Video = DBHelper.StringValue(dr["Video"].ToString());
                returnValue.Guarantee = DBHelper.IntValue(dr["Guarantee"].ToString());
                returnValue.StokStatus = EnumValueData.Get(DBHelper.IntValue(dr["StokStatus"].ToString()));
                returnValue.Stok = DBHelper.IntValue(dr["Stok"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(BasketItemProduct itemBasketItemProduct)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItemProduct.Id));
            parameters.Add(new SqlParameter("@BasketItemId", DBHelper.IntValue(itemBasketItemProduct.BasketItemId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItemProduct.CreateAdminId)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemBasketItemProduct.Product.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemBasketItemProduct.Product.Description)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemBasketItemProduct.Product.ProductCode)));
            parameters.Add(new SqlParameter("@Video", DBHelper.StringValue(itemBasketItemProduct.Product.Video)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemBasketItemProduct.Product.MinStock)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemBasketItemProduct.Product.ProductCategory.Id)));
            parameters.Add(new SqlParameter("@Guarantee", DBHelper.IntValue(itemBasketItemProduct.Product.Guarantee)));
            parameters.Add(new SqlParameter("@StokStatus", DBHelper.IntValue(itemBasketItemProduct.Product.StokStatus.Id)));
            parameters.Add(new SqlParameter("@Stok", DBHelper.IntValue(itemBasketItemProduct.Product.Stok)));
            parameters.Add(new SqlParameter("@ProductStatus", DBHelper.IntValue(itemBasketItemProduct.Product.ProductStatus.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemProduct", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(BasketItemProduct itemBasketItemProduct)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItemProduct.Id));
            parameters.Add(new SqlParameter("@BasketItemId", DBHelper.IntValue(itemBasketItemProduct.BasketItemId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItemProduct.EditAdminId)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemBasketItemProduct.Product.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemBasketItemProduct.Product.Description)));
            parameters.Add(new SqlParameter("@ProductCode", DBHelper.StringValue(itemBasketItemProduct.Product.ProductCode)));
            parameters.Add(new SqlParameter("@Video", DBHelper.StringValue(itemBasketItemProduct.Product.Video)));
            parameters.Add(new SqlParameter("@MinStock", DBHelper.IntValue(itemBasketItemProduct.Product.MinStock)));
            parameters.Add(new SqlParameter("@ProductCategoryId", DBHelper.IntValue(itemBasketItemProduct.Product.ProductCategory.Id)));
            parameters.Add(new SqlParameter("@Guarantee", DBHelper.IntValue(itemBasketItemProduct.Product.Guarantee)));
            parameters.Add(new SqlParameter("@StokStatus", DBHelper.IntValue(itemBasketItemProduct.Product.StokStatus.Id)));
            parameters.Add(new SqlParameter("@Stok", DBHelper.IntValue(itemBasketItemProduct.Product.Stok)));
            parameters.Add(new SqlParameter("@ProductStatus", DBHelper.IntValue(itemBasketItemProduct.Product.ProductStatus.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemProduct", parameters);
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        ////DB'den silmek yerine statüsünü silindi olarak update etmeliyiz.
        //public static int Delete(BasketItemProduct itemBasketItemProduct)
        //{
        //    var returnValue = 0;
        //    itemBasketItemProduct.Status = EnumValueData.Get(12);//silindi statüsü olacak =>ayn
        //    returnValue = Update(itemBasketItemProduct);
        //    return returnValue;
        //}
    }
}

