using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.CommonModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    public class EnumValueData
    {
        public static IKSIR.ECommerce.Model.CommonModel.EnumValue Get(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue)
        {
            var returnValue = new IKSIR.ECommerce.Model.CommonModel.EnumValue();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnumValue.Id));
            parameters.Add(new SqlParameter("@EnumId", itemEnumValue.EnumId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetEnumValue", parameters);
            while (dr.Read())
            {
                //TODO => tayfun
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EnumId = DBHelper.IntValue(dr["EnumId"].ToString());
                returnValue.Value = DBHelper.StringValue(dr["Value"].ToString());
                returnValue.EnumName = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }

            dr.Close();
            return returnValue;
        }

        public static int Insert(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EnumId", DBHelper.IntValue(itemEnumValue.EnumId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemEnumValue.Value)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemEnumValue.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertEnumValue", parameters));
            return returnValue;
        }

        public static int Update(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnumValue.Id));
            parameters.Add(new SqlParameter("@EnumId", DBHelper.IntValue(itemEnumValue.EnumId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemEnumValue.Value)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateEnumValue", parameters);
            return returnValue;
        }

        public static int Save(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemEnumValue.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemEnumValue.CreateAdminId)));
            parameters.Add(new SqlParameter("@EnumId", DBHelper.IntValue(itemEnumValue.EnumId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemEnumValue.Value)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveEnumValue", parameters));
            return returnValue;
        }

        public static int Delete(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnumValue.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteEnumValue", parameters);
            return returnValue;
        }

        public static List<IKSIR.ECommerce.Model.CommonModel.EnumValue> GetEnumValueList(IKSIR.ECommerce.Model.CommonModel.EnumValue itemEnumValue = null)
        {
            List<IKSIR.ECommerce.Model.CommonModel.EnumValue> itemEnumValueList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetEnumValue", parameters);
            itemEnumValueList = new List<IKSIR.ECommerce.Model.CommonModel.EnumValue>();

            while (dr.Read())
            {
                var item = new IKSIR.ECommerce.Model.CommonModel.EnumValue();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.EnumName = DBHelper.StringValue(dr["Name"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.EnumId = DBHelper.IntValue(dr["EnumId"].ToString());
                itemEnumValueList.Add(item);
            }

            dr.Close();
            return itemEnumValueList;
        }
        
        public static List<EnumValue> GetEnumValues(int enumId)
        {
            List<IKSIR.ECommerce.Model.CommonModel.EnumValue> itemEnumValueList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@EnumId", enumId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetEnumValue", parameters);
            itemEnumValueList = new List<EnumValue>();

            while (dr.Read())
            {
                var item = new EnumValue();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.EnumName = DBHelper.StringValue(dr["Name"].ToString());
                item.EnumId = DBHelper.IntValue(dr["EnumId"].ToString());
                itemEnumValueList.Add(item);
            }

            dr.Close();
            return itemEnumValueList;
        }
    }
}
