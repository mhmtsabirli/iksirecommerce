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

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class BasketItemProductPriceData
    {
        public static BasketItemProductPrice Get(int id)
        {
            var returnValue = new BasketItemProductPrice();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasketItemProductPrice", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.BasketItemId = DBHelper.IntValue(dr["BasketItemId"].ToString());
                returnValue.ProductId = DBHelper.IntValue(dr["ProductId"].ToString());
                returnValue.UnitPrice = DBHelper.DecValue(dr["UnitPrice"].ToString());
                returnValue.Tax = DBHelper.IntValue(dr["Tax"].ToString());
                returnValue.Price = DBHelper.DecValue(dr["Price"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(BasketItemProductPrice itemBasketItemProductPrice)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItemProductPrice.Id));
            parameters.Add(new SqlParameter("@BasketItemId", DBHelper.IntValue(itemBasketItemProductPrice.BasketItemId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItemProductPrice.CreateAdminId)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemBasketItemProductPrice.ProductId)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(itemBasketItemProductPrice.UnitPrice)));
            parameters.Add(new SqlParameter("@Tax", DBHelper.IntValue(itemBasketItemProductPrice.Tax)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(itemBasketItemProductPrice.Price)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemProductPrice", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(BasketItemProductPrice itemBasketItemProductPrice)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasketItemProductPrice.Id));
            parameters.Add(new SqlParameter("@BasketItemId", DBHelper.IntValue(itemBasketItemProductPrice.BasketItemId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasketItemProductPrice.EditAdminId)));
            parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(itemBasketItemProductPrice.ProductId)));
            parameters.Add(new SqlParameter("@UnitPrice", DBHelper.DecValue(itemBasketItemProductPrice.UnitPrice)));
            parameters.Add(new SqlParameter("@Tax", DBHelper.IntValue(itemBasketItemProductPrice.Tax)));
            parameters.Add(new SqlParameter("@Price", DBHelper.DecValue(itemBasketItemProductPrice.Price)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemProductPrice", parameters);
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        ////DB'den silmek yerine statüsünü silindi olarak update etmeliyiz.
        //public static int Delete(BasketItemProductPrice itemBasketItemProductPrice)
        //{
        //    var returnValue = 0;
        //    itemBasketItemProduct.Status = EnumValueData.Get(12);//silindi statüsü olacak =>ayn
        //    returnValue = Update(itemBasketItemProduct);
        //    return returnValue;
        //}
    }
}

