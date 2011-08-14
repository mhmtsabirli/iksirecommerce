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
                returnValue.TransferAccount = TransferAccountData.Get(DBHelper.IntValue(dr["TransferAccount"].ToString()));
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.PaymentType = EnumValueData.Get(DBHelper.IntValue(dr["PaymetType"].ToString()));
                returnValue.CreditCardNumber = DBHelper.StringValue(dr["CreditCardNumber"].ToString());
                returnValue.Cvc = DBHelper.StringValue(dr["CVC"].ToString());
                returnValue.Year = DBHelper.IntValue(dr["Year"].ToString());
                returnValue.Month = DBHelper.IntValue(dr["Month"].ToString());
                returnValue.SelectedTerm = DBHelper.IntValue(dr["SelectedTerm"].ToString());
                returnValue.Rate = DBHelper.DecValue(dr["Rate"].ToString());
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
            parameters.Add(new SqlParameter("@CreditCard", DBHelper.IntValue(itemPaymetInfo.CreditCard.Id)));
            parameters.Add(new SqlParameter("@TransferAccount", DBHelper.IntValue(itemPaymetInfo.TransferAccount.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemPaymetInfo.CreateAdminId)));
            parameters.Add(new SqlParameter("@Month", DBHelper.IntValue(itemPaymetInfo.Month)));
            parameters.Add(new SqlParameter("@Year", DBHelper.IntValue(itemPaymetInfo.Year)));
            parameters.Add(new SqlParameter("@SelectedTerm", DBHelper.IntValue(itemPaymetInfo.SelectedTerm)));
            parameters.Add(new SqlParameter("@Rate", DBHelper.DecValue(itemPaymetInfo.Rate)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertPaymetInfo", parameters));
            return returnValue;
        }

        public static int Update(PaymetInfo itemPaymetInfo)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemPaymetInfo.Name)));
            parameters.Add(new SqlParameter("@PaymentType", DBHelper.IntValue(itemPaymetInfo.PaymentType.Id)));
            parameters.Add(new SqlParameter("@CVC", DBHelper.StringValue(itemPaymetInfo.Cvc)));
            parameters.Add(new SqlParameter("@CreditCardNumber", DBHelper.StringValue(itemPaymetInfo.CreditCardNumber)));            
            parameters.Add(new SqlParameter("@CreditCard", DBHelper.IntValue(itemPaymetInfo.CreditCard.Id)));
            parameters.Add(new SqlParameter("@TransferAccount", DBHelper.IntValue(itemPaymetInfo.TransferAccount.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemPaymetInfo.CreateAdminId)));
            parameters.Add(new SqlParameter("@Month", DBHelper.IntValue(itemPaymetInfo.Month)));
            parameters.Add(new SqlParameter("@Year", DBHelper.IntValue(itemPaymetInfo.Year)));
            parameters.Add(new SqlParameter("@SelectedTerm", DBHelper.IntValue(itemPaymetInfo.SelectedTerm)));
            parameters.Add(new SqlParameter("@Rate", DBHelper.DecValue(itemPaymetInfo.Rate)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdatePaymetInfo", parameters));
            return returnValue;
        }

    }
}
