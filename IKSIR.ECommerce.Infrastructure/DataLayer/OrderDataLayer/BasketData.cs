using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class BasketData
    {
        public static Basket Get(int id)
        {
            var returnValue = new Basket();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasket", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.BillingAddress = BasketAddressData.Get(DBHelper.IntValue(dr["BillingAddressId"].ToString()));
                returnValue.ShippingAddress = BasketAddressData.Get(DBHelper.IntValue(dr["ShippingAddressId"].ToString()));
                returnValue.BasketItems = BasketItemData.GetList(id);
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
              
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Basket itemBasket)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasket.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasket.CreateAdminId)));
            parameters.Add(new SqlParameter("@BillingAddressId", DBHelper.IntValue(itemBasket.BillingAddress.Id)));
            parameters.Add(new SqlParameter("@ShippingAddressId", DBHelper.IntValue(itemBasket.ShippingAddress.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemBasket.Status.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasket", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(Basket itemBasket)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBasket.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemBasket.EditAdminId)));
            parameters.Add(new SqlParameter("@BillingAddressId", DBHelper.IntValue(itemBasket.BillingAddress.Id)));
            parameters.Add(new SqlParameter("@ShippingAddressId", DBHelper.IntValue(itemBasket.ShippingAddress.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemBasket.Status.Id)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasket", parameters);
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        //DB'den silmek yerine statüsünü silindi olarak update etmeliyiz.
        public static int Delete(Basket itemBasket)
        {
            var returnValue = 0;
            itemBasket.Status = EnumValueData.Get(12);//silindi statüsü olacak =>ayn
            returnValue = Update(itemBasket);
            return returnValue;
        }
    }
}

