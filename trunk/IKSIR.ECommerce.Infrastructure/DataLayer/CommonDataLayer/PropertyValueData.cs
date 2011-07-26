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
   public class PropertyValueData
    {
        public static PropertyValue Get(PropertyValue itemEnumValue)
        {
            var returnValue = new PropertyValue();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnumValue.Id));
            parameters.Add(new SqlParameter("@PropertyId", itemEnumValue.PropertyId));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPropertyValue", parameters);
            while (dr.Read())
            {
                
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.PropertyId = DBHelper.IntValue(dr["PropertyId"].ToString());
                returnValue.Value = DBHelper.StringValue(dr["Value"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }

            dr.Close();
            return returnValue;
        }

        public static int Insert(PropertyValue itemPropertyValue)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@PropertyId", DBHelper.IntValue(itemPropertyValue.PropertyId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemPropertyValue.Value)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemPropertyValue.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertPropertyValue", parameters));
            return returnValue;
        }

        public static int Update(PropertyValue itemPropertyValue)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemPropertyValue.Id));
            parameters.Add(new SqlParameter("@PropertyId", DBHelper.IntValue(itemPropertyValue.PropertyId)));
            parameters.Add(new SqlParameter("@Value", DBHelper.StringValue(itemPropertyValue.Value)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdatePropertyValue", parameters);
            return returnValue;
        }

        public static int Delete(PropertyValue itemPropertyValue)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemPropertyValue.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeletePropertyValue", parameters);
            return returnValue;
        }

        public static List<PropertyValue> GetPropertyValueList(PropertyValue itemPropertyValue = null)
        {
            List<PropertyValue> itemPropertyValueList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPropertyValue", parameters);
            itemPropertyValueList = new List<PropertyValue>();

            while (dr.Read())
            {
                var item = new PropertyValue();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.PropertyId = DBHelper.IntValue(dr["PropertyId"].ToString());
                itemPropertyValueList.Add(item);
            }

            dr.Close();
            return itemPropertyValueList;
        }
        public static List<PropertyValue> GetPropertyValueListById(int itemId)
        {
            List<PropertyValue> itemPropertyValueList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetPropertyValue", parameters);
            itemPropertyValueList = new List<PropertyValue>();

            while (dr.Read())
            {
                var item = new PropertyValue();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.PropertyId = DBHelper.IntValue(dr["PropertyId"].ToString());
                itemPropertyValueList.Add(item);
            }

            dr.Close();
            return itemPropertyValueList;
        }
    }
}
