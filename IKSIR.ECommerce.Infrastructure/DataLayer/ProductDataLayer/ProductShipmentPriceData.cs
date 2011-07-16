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
    public class ProductShipmentPriceData
    {
        public static ProductShipmentPrice Get(int ProductShipmentPriceId)
        {
            var returnValue = new ProductShipmentPrice();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", ProductShipmentPriceId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductShipmentPrice", parameters);
            while (dr.Read())
            {
                //TODO => tayfun

                returnValue.Shipment = ShipmentData.Get(DBHelper.IntValue(dr["ShipmentId"].ToString()));
                returnValue.Product = ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                returnValue.Price = DBHelper.DecValue(dr["Price"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static List<ProductShipmentPrice> GetByProduct(int ProductId)
        {

            List<ProductShipmentPrice> itemProductShipmentPrice = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", ProductId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductShipmentPrice", parameters);

            itemProductShipmentPrice = new List<ProductShipmentPrice>();


            while (dr.Read())
            {
                var item = new ProductShipmentPrice();
                item.Shipment = ShipmentData.Get(DBHelper.IntValue(dr["ShipmentId"].ToString()));
                item.Price = DBHelper.DecValue(dr["Price"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                itemProductShipmentPrice.Add(item);
            }

            dr.Close();
            return itemProductShipmentPrice;
        }

        public static List<ProductShipmentPrice> GetByShipment(int ShipmentId)
        {

            List<ProductShipmentPrice> itemProductShipmentPrice = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ShipmentId", ShipmentId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductShipmentPrice", parameters);

            itemProductShipmentPrice = new List<ProductShipmentPrice>();


            while (dr.Read())
            {
                var item = new ProductShipmentPrice();
                item.Shipment = ShipmentData.Get(DBHelper.IntValue(dr["ShipmentId"].ToString()));
                item.Price = DBHelper.DecValue(dr["Price"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                itemProductShipmentPrice.Add(item);
            }

            dr.Close();
            return itemProductShipmentPrice;
        }

        public static int Insert(ProductShipmentPrice productShipmentPrice)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(productShipmentPrice.Product.Id)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(productShipmentPrice.Price)));
            parameters.Add(new SqlParameter("@ShipmentId", DBHelper.IntValue(productShipmentPrice.Shipment.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(productShipmentPrice.CreateAdminId)));


            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductShipmentPrice", parameters));
            return returnValue;
        }

        public static int Update(ProductShipmentPrice productShipmentPrice)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(productShipmentPrice.Product.Id)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(productShipmentPrice.Price)));
            parameters.Add(new SqlParameter("@ShipmentId", DBHelper.IntValue(productShipmentPrice.Shipment.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(productShipmentPrice.EditAdminId)));
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(productShipmentPrice.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateProductShipmentPrice", parameters);
            return returnValue;
        }

        public static int Delete(int Id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteProductShipmentPrice", parameters);
            return returnValue;
        }



    }
}
