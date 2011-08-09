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

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class BasketItemData
    {
        public static BasketItem Get(int id)
        {
            var returnValue = new BasketItem();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasketItem", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Basket = BasketData.Get(DBHelper.IntValue(dr["BasketId"].ToString()));
                returnValue.Product = BasketItemProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                returnValue.ShippingAddress = BasketAddressData.Get(DBHelper.IntValue(dr["ShippingAddressId"].ToString()));
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.ProductPrice = BasketItemProductPriceData.GetByProductId(DBHelper.IntValue(dr["ProductId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(BasketItem itemBasketItem)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItem.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItem.CreateAdminId)));
            parameters.Add(new SqlParameter("@BasketId", DBHelper.IntValue(itemBasketItem.Basket.Id)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemBasketItem.Product.Id)));
            //parameters.Add(new SqlParameter("@ShippingAddressId", DBHelper.IntValue(itemBasketItem.ShippingAddress.Id))); 
            //Basket Item Bazında kargolamayı şimdilik kaldırıyoruz. => Ayhant
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemBasketItem.Status.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItem", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(BasketItem itemBasketItem)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItem.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItem.EditAdminId)));
            parameters.Add(new SqlParameter("@BasketId", DBHelper.IntValue(itemBasketItem.Basket.Id)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemBasketItem.Product.Id)));
            parameters.Add(new SqlParameter("@ShippingAddressId", DBHelper.IntValue(itemBasketItem.ShippingAddress.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemBasketItem.Status.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItem", parameters);
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        //DB'den silmek yerine statüsünü silindi olarak update etmeliyiz.
        public static int Delete(BasketItem itemBasketItem)
        {
            var returnValue = 0;
            itemBasketItem.Status = EnumValueData.Get(12);//silindi statüsü olacak =>ayn
            returnValue = Update(itemBasketItem);
            return returnValue;
        }

        public static List<BasketItem> GetList(int basketId)
        {
            List<BasketItem> returnValue = null;
            var basketItem = new BasketItem();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@BasketId", basketId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasketItem", parameters);
            while (dr.Read())
            {
                basketItem.Id = DBHelper.IntValue(dr["Id"].ToString());
                basketItem.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                basketItem.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                basketItem.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                basketItem.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                basketItem.Basket = BasketData.Get(DBHelper.IntValue(dr["BasketId"].ToString()));
                basketItem.Product = ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                basketItem.ShippingAddress = BasketAddressData.Get(DBHelper.IntValue(dr["ShippingAddressId"].ToString()));
                basketItem.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.Add(basketItem);
            }
            dr.Close();
            return returnValue;
        }
    }
}

