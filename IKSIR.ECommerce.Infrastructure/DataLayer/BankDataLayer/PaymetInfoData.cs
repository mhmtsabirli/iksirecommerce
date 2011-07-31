using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.Bank;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.BankDataLayer
{
    public class PaymetInfoData
    {
        public static PaymetInfo Get(int PaymetInfoId)
        {
            var returnValue = new PaymetInfo();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", PaymetInfoId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPaymetInfo", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.CreditCard = CreditCardData.Get(DBHelper.IntValue(dr["CreditCard"].ToString()));
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.PaymentType = EnumValueData.Get(DBHelper.IntValue(dr["PaymentType"].ToString()));
                returnValue.CreditCardNumber = DBHelper.StringValue(dr["CreditCardNumber"].ToString());
                returnValue.Cvc = DBHelper.StringValue(dr["CVC"].ToString());
                returnValue.Date = DBHelper.DateValue(dr["Date"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(PaymetInfo itemPaymetInfo)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemPaymetInfo.Name)));
            parameters.Add(new SqlParameter("@PaymentType", DBHelper.IntValue(itemPaymetInfo.PaymentType.Id)));
            parameters.Add(new SqlParameter("@CVC", DBHelper.StringValue(itemPaymetInfo.Cvc)));
            parameters.Add(new SqlParameter("@CreditCardNumber", DBHelper.StringValue(itemPaymetInfo.CreditCardNumber)));
            parameters.Add(new SqlParameter("@Date", DBHelper.DateValue(itemPaymetInfo.Date)));
            parameters.Add(new SqlParameter("@CreditCard", DBHelper.IntValue(itemPaymetInfo.CreditCard.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemPaymetInfo.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertPaymetInfo", parameters));
            return returnValue;
        }

    }
}
