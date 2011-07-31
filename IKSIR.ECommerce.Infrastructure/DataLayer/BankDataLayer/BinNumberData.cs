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
    public class BinNumberData
    {
        public static BinNumber Get(int BinNumberId)
        {
            var returnValue = new BinNumber();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", BinNumberId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBinNumber", parameters);
            while (dr.Read())
            {
                
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Number = DBHelper.StringValue(dr["Number"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                returnValue.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(BinNumber itemBinNumber)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Number", DBHelper.StringValue(itemBinNumber.Number)));
            parameters.Add(new SqlParameter("@BankId", DBHelper.StringValue(itemBinNumber.Bank.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemBinNumber.Status.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemBinNumber.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertBinNumber", parameters));
            return returnValue;
        }

        public static int Update(BinNumber itemBinNumber)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemBinNumber.Id));
            parameters.Add(new SqlParameter("@Number", DBHelper.StringValue(itemBinNumber.Number)));
            parameters.Add(new SqlParameter("@BankId", DBHelper.StringValue(itemBinNumber.Bank.Id)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemBinNumber.Status.Id)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemBinNumber.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateBinNumber", parameters);
            return returnValue;
        }

        public static int Delete(int BinNumberId)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", BinNumberId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteBinNumber", parameters);
            return returnValue;
        }

        public static List<BinNumber> GetBinNumberList(int BankId)
        {
            List<BinNumber> itemBinNumberList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@BankId", BankId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBinNumber", parameters);
            itemBinNumberList = new List<BinNumber>();

            while (dr.Read())
            {
                var item = new BinNumber();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Number = DBHelper.StringValue(dr["Number"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
                itemBinNumberList.Add(item);
            }

            dr.Close();
            return itemBinNumberList;
        }

        public static List<BinNumber> GetBinNumberList()
        {
            List<BinNumber> itemBinNumberList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBinNumber", parameters);
            itemBinNumberList = new List<BinNumber>();

            while (dr.Read())
            {
                var item = new BinNumber();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Number = DBHelper.StringValue(dr["Number"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                item.Bank = BankData.Get(DBHelper.IntValue(dr["BankId"].ToString()));
                itemBinNumberList.Add(item);
            }

            dr.Close();
            return itemBinNumberList;
        }

    }
}
