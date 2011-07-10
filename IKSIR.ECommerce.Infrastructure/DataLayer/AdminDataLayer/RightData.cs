using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.AdminModel;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer
{
   public class RightData
    {
        public static Right Get(Right itemRight)
        {
            var returnValue = new Right();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemRight.Id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetRight", parameters);
            while (dr.Read())
            {
                //TODO => tayfun
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Right itemRight)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemRight.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemRight.Description)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemRight.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertRight", parameters));
            return returnValue;
        }

        public static int Update(Right itemRight)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemRight.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemRight.EditAdminId)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemRight.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemRight.Description)));

            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateRight", parameters);
            return returnValue;
        }

        public static int Save(Right itemRight)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemRight.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemRight.EditAdminId)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemRight.Title)));
            parameters.Add(new SqlParameter("@Description", DBHelper.StringValue(itemRight.Description)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveRight", parameters));
            return returnValue;
        }

        public static int Delete(Right itemRight)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemRight.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteRight", parameters);
            return returnValue;
        }

        public static List<Right> GetRightList(Right itemRight = null)
        {
            List<Right> itemRightList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetRight", parameters);
            itemRightList = new List<Right>();

            while (dr.Read())
            {
                var item = new Right();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());

                itemRightList.Add(item);
            }

            dr.Close();
            return itemRightList;
        }
    }
}
