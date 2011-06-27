using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using System.Data;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    public class SystemLogData
    {
        

        public static int Insert(SystemLog itemSystemLog)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Type", itemSystemLog.Type.Id));
            parameters.Add(new SqlParameter("@Content", DBHelper.StringValue(itemSystemLog.Content)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemSystemLog.Title)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.StringValue(itemSystemLog.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertSystemLog", parameters));
            return returnValue;
        }



        public static List<SystemLog> GetSystemLogs(SystemLog itemSytemLog)
        {
            List<SystemLog> itemSystemLogList = new List<SystemLog>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Title", itemSytemLog.Title));
            parameters.Add(new SqlParameter("@TypeId", itemSytemLog.Type.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetSystemLog", parameters);

            var item = new SystemLog();
            while (dr.Read())
            {
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Content = DBHelper.StringValue(dr["Content"].ToString());
                item.Type = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["Type"].ToString()) });
                itemSystemLogList.Add(item);
            }

            dr.Close();
            return itemSystemLogList;
        }
    }
}
