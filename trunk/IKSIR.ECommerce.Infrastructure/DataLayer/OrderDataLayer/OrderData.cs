using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.Order;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class OrderData
    {
        public static Order Get(int id, int userId, EnumValue status)
        {
            var returnValue = new Order();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            parameters.Add(new SqlParameter("@UserId", userId));
            parameters.Add(new SqlParameter("@Status", status.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetOrder", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                returnValue.Basket = BasketData.Get(DBHelper.IntValue(dr["BasketId"].ToString()));
                returnValue.PaymetInfo = PaymetInfoData.Get(DBHelper.IntValue(dr["PaymentInfoId"].ToString()));
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.TotalRatedPrice = DBHelper.DecValue(dr["TotalRatedPrice"].ToString());
                returnValue.TotalPrice = DBHelper.DecValue(dr["TotalPrice"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Order itemOrder)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemOrder.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemOrder.CreateAdminId)));
            parameters.Add(new SqlParameter("@UserId", DBHelper.IntValue(itemOrder.User.Id)));
            parameters.Add(new SqlParameter("@BasketId", DBHelper.IntValue(itemOrder.Basket.Id)));
            parameters.Add(new SqlParameter("@PaymentInfoId", DBHelper.IntValue(itemOrder.PaymetInfo.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemOrder.Status.Id)));
            parameters.Add(new SqlParameter("@TotalRatedPrice", DBHelper.DecValue(itemOrder.TotalRatedPrice)));
            parameters.Add(new SqlParameter("@TotalPrice", DBHelper.DecValue(itemOrder.TotalPrice)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveOrder", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(Order itemOrder)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemOrder.Id));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemOrder.EditAdminId)));
            parameters.Add(new SqlParameter("@UserId", DBHelper.IntValue(itemOrder.User.Id)));
            parameters.Add(new SqlParameter("@BasketId", DBHelper.IntValue(itemOrder.Basket.Id)));
            parameters.Add(new SqlParameter("@PaymentInfoId", DBHelper.IntValue(itemOrder.PaymetInfo.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemOrder.Status.Id)));
            parameters.Add(new SqlParameter("@TotalRatedPrice", DBHelper.DecValue(itemOrder.TotalRatedPrice)));
            parameters.Add(new SqlParameter("@TotalPrice", DBHelper.DecValue(itemOrder.TotalPrice)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveOrder", parameters);
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }
        public static List<Order> GetList(int status)
        {
            var itemList = new List<Order>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Status", status));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetOrder", parameters);
            while (dr.Read())
            {
                Order returnValue = new Order();
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                returnValue.Basket = BasketData.Get(DBHelper.IntValue(dr["BasketId"].ToString()));
                returnValue.PaymetInfo = PaymetInfoData.Get(DBHelper.IntValue(dr["PaymentInfoId"].ToString()));
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.TotalRatedPrice = DBHelper.DecValue(dr["TotalRatedPrice"].ToString());
                returnValue.TotalPrice = DBHelper.DecValue(dr["TotalPrice"].ToString());
                itemList.Add(returnValue);
            }
            dr.Close();
            return itemList;
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

