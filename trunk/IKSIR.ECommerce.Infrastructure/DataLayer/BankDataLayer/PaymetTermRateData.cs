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
    public class PaymetTermRateData
    {
        public static PaymetTermRate Get(int PaymetTermRateId)
        {
            var returnValue = new PaymetTermRate();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", PaymetTermRateId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPaymetTermRate", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.CreditCard = CreditCardData.Get(DBHelper.IntValue(dr["CreditCardId"].ToString()));
                returnValue.Month = DBHelper.IntValue(dr["Month"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.Rate = DBHelper.DecValue(dr["Rate"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(PaymetTermRate itemPaymetTermRate)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Rate", DBHelper.DecValue(itemPaymetTermRate.Rate)));
            parameters.Add(new SqlParameter("@Month", DBHelper.IntValue(itemPaymetTermRate.Month)));
            parameters.Add(new SqlParameter("@CreditCardId", DBHelper.IntValue(itemPaymetTermRate.CreditCard.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemPaymetTermRate.Status.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemPaymetTermRate.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertPaymetTermRate", parameters));
            return returnValue;
        }

        public static int Update(PaymetTermRate itemPaymetTermRate)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemPaymetTermRate.Id));
            parameters.Add(new SqlParameter("@Rate", DBHelper.DecValue(itemPaymetTermRate.Rate)));
            parameters.Add(new SqlParameter("@Month", DBHelper.IntValue(itemPaymetTermRate.Month)));
            parameters.Add(new SqlParameter("@CreditCardId", DBHelper.IntValue(itemPaymetTermRate.CreditCard.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemPaymetTermRate.Status.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemPaymetTermRate.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdatePaymetTermRate", parameters);
            return returnValue;
        }

        public static int Delete(int PaymetTermRateId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", PaymetTermRateId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeletePaymetTermRate", parameters);
            return returnValue;
        }

        public static List<PaymetTermRate> GetPaymetTermRateList(int CreditCardId)
        {
            List<PaymetTermRate> itemPaymetTermRateList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CreditCardId", CreditCardId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPaymetTermRate", parameters);
            itemPaymetTermRateList = new List<PaymetTermRate>();

            while (dr.Read())
            {
                var item = new PaymetTermRate();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.CreditCard = CreditCardData.Get(DBHelper.IntValue(dr["CreditCardId"].ToString()));
                item.Month = DBHelper.IntValue(dr["Month"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Rate = DBHelper.DecValue(dr["Rate"].ToString());
                itemPaymetTermRateList.Add(item);
            }

            dr.Close();
            return itemPaymetTermRateList;
        }

        public static List<PaymetTermRate> GetAktivePaymetTermRateList(int CreditCardId)
        {
            List<PaymetTermRate> itemPaymetTermRateList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@CreditCardId", CreditCardId));
            parameters.Add(new SqlParameter("@Status", 25));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPaymetTermRate", parameters);
            itemPaymetTermRateList = new List<PaymetTermRate>();

            while (dr.Read())
            {
                var item = new PaymetTermRate();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.CreditCard = CreditCardData.Get(DBHelper.IntValue(dr["CreditCardId"].ToString()));
                item.Month = DBHelper.IntValue(dr["Month"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Rate = DBHelper.DecValue(dr["Rate"].ToString());
                itemPaymetTermRateList.Add(item);
            }

            dr.Close();
            return itemPaymetTermRateList;
        }

    }
}
