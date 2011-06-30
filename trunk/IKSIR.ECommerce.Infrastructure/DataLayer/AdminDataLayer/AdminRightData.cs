using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer;
using IKSIR.ECommerce.Model.AdminModel;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer
{
    public class AdminRightData
    {
        public static AdminRights Get(AdminRights itemAdminRight)
        {
            var returnValue = new AdminRights();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdminRight.Id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAdminRight", parameters);
            dr.Read();
            //TODO => tayfun
            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.Admin = AdminData.Get(new Admin() { Id = DBHelper.IntValue(dr["AdminId"].ToString()) });
            returnValue.Rights = RightData.GetRightList(new Right() { Id = DBHelper.IntValue(dr["RightId"].ToString()) });
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());

            dr.Close();
            return returnValue;
        }

        public static int Insert(AdminRights itemAdminRight)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@AdminId", DBHelper.StringValue(itemAdminRight.Admin.Id)));
            parameters.Add(new SqlParameter("@RightId", DBHelper.StringValue(itemAdminRight.Rights[0].Id)));

            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemAdminRight.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertAdminRights", parameters));
            return returnValue;
        }

        public static int Update(AdminRights itemAdminRight)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdminRight.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemAdminRight.EditAdminId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.StringValue(itemAdminRight.Admin.Id)));
            parameters.Add(new SqlParameter("@RightId", DBHelper.StringValue(itemAdminRight.Rights[0].Id)));
 
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateAdminRights", parameters);
            return returnValue;
        }

        public static int Save(AdminRights itemAdminRight)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemAdminRight.Id)));
            parameters.Add(new SqlParameter("@AdminsId", DBHelper.IntValue(itemAdminRight.CreateAdminId)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.StringValue(itemAdminRight.Admin.Id)));
            parameters.Add(new SqlParameter("@RightId", DBHelper.StringValue(itemAdminRight.Rights[0].Id)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveAdminRights", parameters));
            return returnValue;
        }

        public static int Delete(Admin itemAdmin)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdmin.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteAdminRights", parameters);
            return returnValue;
        }

        public static List<AdminRights> GetAdminRightsList(AdminRights itemAdminRights = null)
        {
            List<AdminRights> itemAdminRightsList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAdminRight", parameters);
            itemAdminRightsList = new List<AdminRights>();

            while (dr.Read())
            {
                var item = new AdminRights();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Admin = AdminData.Get(new Admin() { Id = DBHelper.IntValue(dr["AdminId"].ToString()) });
                item.Rights = RightData.GetRightList(new Right() { Id = DBHelper.IntValue(dr["RightId"].ToString()) });
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());

                itemAdminRightsList.Add(item);
            }

            dr.Close();
            return itemAdminRightsList;
        }


        public static List<AdminRights> GetAdminRightsListForAdmin(Admin itemAdmin = null)
        {
            List<AdminRights> itemAdminRightsList = null;


            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AdminId", itemAdmin.Id));


            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAdminRight", parameters);
            itemAdminRightsList = new List<AdminRights>();

            while (dr.Read())
            {
                var item = new AdminRights();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Admin = AdminData.Get(new Admin() { Id = DBHelper.IntValue(dr["AdminId"].ToString()) });
                item.Rights = RightData.GetRightList(new Right() { Id = DBHelper.IntValue(dr["RightId"].ToString()) });
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());

                itemAdminRightsList.Add(item);
            }

            dr.Close();
            return itemAdminRightsList;
        }
    }
}
