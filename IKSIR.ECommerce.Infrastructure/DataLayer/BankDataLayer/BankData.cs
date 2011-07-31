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
    public class BankData
    {
        public static Bank Get(int BankId)
        {
            var returnValue = new Bank();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", BankId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBank", parameters);
            while (dr.Read())
            {
                
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Bank itemBank)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemBank.Name)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemBank.Status.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemBank.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertBank", parameters));
            return returnValue;
        }

        public static int Update(Bank itemBank)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemBank.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemBank.EditAdminId)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemBank.Status.Id)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemBank.Name)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateBank", parameters);
            return returnValue;
        }

        public static int Delete(int BankId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", BankId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteBank", parameters);
            return returnValue;
        }

        public static List<Bank> GetBankList(Bank itemBank = null)
        {
            List<Bank> itemBankList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBank", parameters);
            itemBankList = new List<Bank>();

            while (dr.Read())
            {
                var item = new Bank();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());                
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                itemBankList.Add(item);
            }

            dr.Close();
            return itemBankList;
        }

    }
}
