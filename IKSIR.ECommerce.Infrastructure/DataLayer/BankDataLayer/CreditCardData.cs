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
    public class CreditCardData
    {
        public static CreditCard Get(int CreditCardId)
        {
            var returnValue = new CreditCard();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", CreditCardId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetCreditCard", parameters);
            while (dr.Read())
            {
                
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Image = DBHelper.StringValue(dr["Image"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(CreditCard itemCreditCard)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemCreditCard.Name)));
            parameters.Add(new SqlParameter("@Image", DBHelper.StringValue(itemCreditCard.Image)));
            parameters.Add(new SqlParameter("@BankId", DBHelper.StringValue(itemCreditCard.Bank.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemCreditCard.Status.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemCreditCard.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertCreditCard", parameters));
            return returnValue;
        }

        public static int Update(CreditCard itemCreditCard)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemCreditCard.Id));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemCreditCard.Name)));
            parameters.Add(new SqlParameter("@Image", DBHelper.StringValue(itemCreditCard.Image)));
            parameters.Add(new SqlParameter("@BankId", DBHelper.StringValue(itemCreditCard.Bank.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemCreditCard.Status.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemCreditCard.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateCreditCard", parameters);
            return returnValue;
        }

        public static int Delete(int CreditCardId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", CreditCardId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteCreditCard", parameters);
            return returnValue;
        }

        public static List<CreditCard> GetCreditCardList()
        {
            List<CreditCard> itemCreditCardList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetCreditCard", parameters);
            itemCreditCardList = new List<CreditCard>();

            while (dr.Read())
            {
                var item = new CreditCard();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Image = DBHelper.StringValue(dr["Image"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
                itemCreditCardList.Add(item);
            }

            dr.Close();
            return itemCreditCardList;
        }

        public static List<CreditCard> GetAktiveCreditCardList()
        {
            List<CreditCard> itemCreditCardList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Status", 27));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetCreditCard", parameters);
            itemCreditCardList = new List<CreditCard>();

            while (dr.Read())
            {
                var item = new CreditCard();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Image = DBHelper.StringValue(dr["Image"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
                itemCreditCardList.Add(item);
            }

            dr.Close();
            return itemCreditCardList;
        }

    }
}
