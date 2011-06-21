using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.AdminModel;
using IKSIR.ECommerce.Model.SiteModel;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.AdminDataLayer
{
    public class AdminData
    {
        public static Admin Get(Admin itemAdmin)
        {
            var returnValue = new Admin();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdmin.Id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAdmin", parameters);
            dr.Read();
            //TODO => tayfun
            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
            returnValue.Email = DBHelper.StringValue(dr["Email"].ToString());
            returnValue.Password = DBHelper.StringValue(dr["TcId"].ToString());
            returnValue.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            returnValue.UserName = DBHelper.StringValue(dr["UserName"].ToString());
            returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });

            dr.Close();
            return returnValue;
        }

        public static int Insert(Admin itemAdmin)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemAdmin.Name)));
            parameters.Add(new SqlParameter("@UserName", DBHelper.StringValue(itemAdmin.UserName)));
            parameters.Add(new SqlParameter("@EMail", DBHelper.StringValue(itemAdmin.Email)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(itemAdmin.Site.Id)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(itemAdmin.Password)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemAdmin.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertAdmin", parameters));
            return returnValue;
        }

        public static int Update(Admin itemAdmin)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdmin.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemAdmin.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemAdmin.Name)));
            parameters.Add(new SqlParameter("@UserName", DBHelper.StringValue(itemAdmin.UserName)));
            parameters.Add(new SqlParameter("@EMail", DBHelper.StringValue(itemAdmin.Email)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(itemAdmin.Site.Id)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(itemAdmin.Password)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateAdmin", parameters);
            return returnValue;
        }

        public static int Delete(Admin itemAdmin)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAdmin.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteAdmin", parameters);
            return returnValue;
        }

        public static List<Admin> GetAdminList(Admin itemAdmin = null)
        {
            List<Admin> itemAdminList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            //if (itemProductCategory != null)
            //    parameters.Add(new SqlParameter("@Id", itemProductCategory.Id));
            //if (itemProductCategory.ParentCategory != null)
            //    parameters.Add(new SqlParameter("@ProductCategoryId", itemProductCategory.ParentCategory.Id));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAdmin", parameters);
            itemAdminList = new List<Admin>();

            while (dr.Read())
            {
                var item = new Admin();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.Email = DBHelper.StringValue(dr["Email"].ToString());
                item.Password = DBHelper.StringValue(dr["TcId"].ToString());
                item.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.UserName = DBHelper.StringValue(dr["UserName"].ToString());
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });

                itemAdminList.Add(item);
            }

            dr.Close();
            return itemAdminList;
        }
    }
}
