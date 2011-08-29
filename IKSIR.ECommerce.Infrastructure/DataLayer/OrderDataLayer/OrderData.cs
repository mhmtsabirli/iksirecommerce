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
                returnValue.ShippingPrice = DBHelper.DecValue(dr["ShippingPrice"].ToString());
                returnValue.InvoiceNo = DBHelper.StringValue(dr["InvoiceNo"].ToString());
                returnValue.ShippmentNo = DBHelper.StringValue(dr["ShippmentNo"].ToString());
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
            parameters.Add(new SqlParameter("@ShippingPrice", DBHelper.DecValue(itemOrder.ShippingPrice)));
            parameters.Add(new SqlParameter("@TotalRatedPrice", DBHelper.DecValue(itemOrder.TotalRatedPrice)));
            parameters.Add(new SqlParameter("@TotalPrice", DBHelper.DecValue(itemOrder.TotalPrice)));
            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertOrder", parameters));
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
            parameters.Add(new SqlParameter("@InvoiceNo", DBHelper.StringValue(itemOrder.InvoiceNo)));
            parameters.Add(new SqlParameter("@ShippmentNo", DBHelper.StringValue(itemOrder.ShippmentNo)));
            parameters.Add(new SqlParameter("@TotalRatedPrice", DBHelper.DecValue(itemOrder.TotalRatedPrice)));
            parameters.Add(new SqlParameter("@TotalPrice", DBHelper.DecValue(itemOrder.TotalPrice)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateOrder", parameters);
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
                returnValue.ShippingPrice = DBHelper.DecValue(dr["ShippingPrice"].ToString());
                returnValue.TotalRatedPrice = DBHelper.DecValue(dr["TotalRatedPrice"].ToString());
                returnValue.TotalPrice = DBHelper.DecValue(dr["TotalPrice"].ToString());
                itemList.Add(returnValue);
            }
            dr.Close();
            return itemList;
        }
        public static List<Order> GetList(int status, int UserId)
        {
            var itemList = new List<Order>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Status", status));
            parameters.Add(new SqlParameter("@UserId", UserId));
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
                returnValue.ShippingPrice = DBHelper.DecValue(dr["ShippingPrice"].ToString());
                returnValue.InvoiceNo = DBHelper.StringValue(dr["InvoiceNo"].ToString());
                returnValue.ShippmentNo = DBHelper.StringValue(dr["ShippmentNo"].ToString());
                itemList.Add(returnValue);
            }
            dr.Close();
            return itemList;
        }

        public static decimal CalculateShippingPrice(decimal TotalDesi)
        {
            decimal price = 0;

            if (TotalDesi < 1)
                price = DBHelper.DecValue("3.94");
            else if (TotalDesi >= 1 && TotalDesi <= 15)
                price = DBHelper.DecValue("4.73");
            else if (TotalDesi >= 16 && TotalDesi <= 30)
                price = DBHelper.DecValue("9.46");
            else
            {
                price = DBHelper.DecValue(((TotalDesi - 30) * DBHelper.DecValue("0.272")) + DBHelper.DecValue("9.46"));
            }

            //            0-1 KG/Ds 3,94 TL
            //1-15 Ds/Kg 4,73 TL
            //16-30 Ds/Kg 9,46 TL
            //+ 30 Ds/Kg 0,272 TL ilave edilir


            return price;
        }
    }
}

