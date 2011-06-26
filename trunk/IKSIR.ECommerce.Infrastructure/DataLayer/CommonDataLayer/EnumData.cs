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
    public class EnumData
    {
        public static IKSIR.ECommerce.Model.CommonModel.Enum Get(IKSIR.ECommerce.Model.CommonModel.Enum itemEnum)
        {
            var returnValue = new IKSIR.ECommerce.Model.CommonModel.Enum();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnum.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetEnum", parameters);
            dr.Read();
            //TODO => tayfun
            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            returnValue.EnumValues = EnumValueData.GetEnumValues(DBHelper.IntValue(dr["Id"].ToString()));

            dr.Close();
            return returnValue;
        }

        public static int Insert(IKSIR.ECommerce.Model.CommonModel.Enum itemEnum)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemEnum.Name)));
            parameters.Add(new SqlParameter("@CreateUserId", DBHelper.IntValue(itemEnum.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertEnum", parameters));
            return returnValue;
        }

        public static int Update(IKSIR.ECommerce.Model.CommonModel.Enum itemEnum)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnum.Id));
            parameters.Add(new SqlParameter("@EditUserId", DBHelper.IntValue(itemEnum.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemEnum.Name)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateEnum", parameters);
            return returnValue;
        }

        public static int Delete(IKSIR.ECommerce.Model.CommonModel.Enum itemEnum)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemEnum.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteEnum", parameters);
            return returnValue;
        }

        public static List<IKSIR.ECommerce.Model.CommonModel.Enum> GetEnumList(IKSIR.ECommerce.Model.CommonModel.Enum itemEnum = null)
        {
            List<IKSIR.ECommerce.Model.CommonModel.Enum> itemEnumList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            //if (itemProductCategory != null)
            //    parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            //if (itemProductCategory.ParentCategory != null)
            //    parameters.Add(new SqlParameter("@ProductCategoryId", itemProductCategory.ParentCategory.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetEnum", parameters);
            itemEnumList = new List<IKSIR.ECommerce.Model.CommonModel.Enum>();

            while (dr.Read())
            {
                var item = new IKSIR.ECommerce.Model.CommonModel.Enum();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());                
                item.EnumValues = EnumValueData.GetEnumValues(DBHelper.IntValue(dr["Id"].ToString()));
                itemEnumList.Add(item);
            }

            dr.Close();
            return itemEnumList;
        }

    }
}
