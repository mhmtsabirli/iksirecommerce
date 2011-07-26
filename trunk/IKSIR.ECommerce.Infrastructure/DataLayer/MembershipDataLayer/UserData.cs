using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.SiteModel;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer
{
    public class UserData
    {
        public static User Get(int id)
        {
            User returnValue = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetUser", parameters);
            while (dr.Read())
            {
                returnValue = new User();
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.UserName = DBHelper.StringValue(dr["UserName"].ToString());
                returnValue.SurName = DBHelper.StringValue(dr["SurName"].ToString());
                returnValue.Email = DBHelper.StringValue(dr["Email"].ToString());
                returnValue.MobilePhone = DBHelper.StringValue(dr["MobilePhone"].ToString());
                returnValue.TcId = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Password = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Status = DBHelper.IntValue(dr["Password"].ToString());
                returnValue.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.BirthDate = DBHelper.DateValue(dr["BirthDate"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static User Get(string email)
        {
            User returnValue = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(email)));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetUser", parameters);
            while (dr.Read())
            {
                returnValue = new User();
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.UserName = DBHelper.StringValue(dr["UserName"].ToString());
                returnValue.SurName = DBHelper.StringValue(dr["SurName"].ToString());
                returnValue.Email = DBHelper.StringValue(dr["Email"].ToString());
                returnValue.MobilePhone = DBHelper.StringValue(dr["MobilePhone"].ToString());
                returnValue.TcId = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Password = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Status = DBHelper.IntValue(dr["Password"].ToString());
                returnValue.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.BirthDate = DBHelper.DateValue(dr["BirthDate"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static User CheckUser(string email, string password)
        {
            User returnValue = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(email)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(password)));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "CheckUser", parameters);
            while (dr.Read())
            {
                returnValue = new User();
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.UserName = DBHelper.StringValue(dr["UserName"].ToString());
                returnValue.SurName = DBHelper.StringValue(dr["SurName"].ToString());
                returnValue.Email = DBHelper.StringValue(dr["Email"].ToString());
                returnValue.MobilePhone = DBHelper.StringValue(dr["MobilePhone"].ToString());
                returnValue.TcId = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Password = DBHelper.StringValue(dr["TcId"].ToString());
                returnValue.Status = DBHelper.IntValue(dr["Password"].ToString());
                returnValue.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.BirthDate = DBHelper.DateValue(dr["BirthDate"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(User itemUser)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemUser.Name)));
            parameters.Add(new SqlParameter("@UserName", DBHelper.StringValue(itemUser.UserName)));
            parameters.Add(new SqlParameter("@SurName", DBHelper.StringValue(itemUser.SurName)));
            parameters.Add(new SqlParameter("@EMail", DBHelper.StringValue(itemUser.Email)));
            parameters.Add(new SqlParameter("@MobilePhone", DBHelper.StringValue(itemUser.MobilePhone)));
            parameters.Add(new SqlParameter("@TcId", DBHelper.StringValue(itemUser.TcId)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemUser.Status)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(itemUser.Site.Id)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(itemUser.Password)));
            parameters.Add(new SqlParameter("@BirthDate", DBHelper.DateValue(itemUser.BirthDate)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemUser.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertUser", parameters));
            return returnValue;
        }

        public static int Update(User itemUser)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemUser.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemUser.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemUser.Name)));
            parameters.Add(new SqlParameter("@UserName", DBHelper.StringValue(itemUser.UserName)));
            parameters.Add(new SqlParameter("@SurName", DBHelper.StringValue(itemUser.SurName)));
            parameters.Add(new SqlParameter("@EMail", DBHelper.StringValue(itemUser.Email)));
            parameters.Add(new SqlParameter("@MobilePhone", DBHelper.StringValue(itemUser.MobilePhone)));
            parameters.Add(new SqlParameter("@TcId", DBHelper.StringValue(itemUser.TcId)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemUser.Status)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(itemUser.Site.Id)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(itemUser.Password)));
            parameters.Add(new SqlParameter("@BirthDate", DBHelper.DecValue(itemUser.BirthDate)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateUser", parameters);
            return returnValue;
        }

        public static int Save(User itemUser)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemUser.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemUser.CreateAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemUser.Name)));
            parameters.Add(new SqlParameter("@UserName", DBHelper.StringValue(itemUser.UserName)));
            parameters.Add(new SqlParameter("@SurName", DBHelper.StringValue(itemUser.SurName)));
            parameters.Add(new SqlParameter("@EMail", DBHelper.StringValue(itemUser.Email)));
            parameters.Add(new SqlParameter("@MobilePhone", DBHelper.StringValue(itemUser.MobilePhone)));
            parameters.Add(new SqlParameter("@TcId", DBHelper.StringValue(itemUser.TcId)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemUser.Status)));
            parameters.Add(new SqlParameter("@SiteId", DBHelper.IntValue(itemUser.Site.Id)));
            parameters.Add(new SqlParameter("@Password", DBHelper.StringValue(itemUser.Password)));
            parameters.Add(new SqlParameter("@BirthDate", DBHelper.DecValue(itemUser.BirthDate)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveUser", parameters));
            return returnValue;
        }

        public static int Delete(User itemUser)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemUser.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteUser", parameters);
            return returnValue;
        }

        public static List<User> GetUserList()
        {
            List<User> itemUserList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetUser", parameters);
            itemUserList = new List<User>();

            while (dr.Read())
            {
                var item = new User();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.UserName = DBHelper.StringValue(dr["UserName"].ToString());
                item.SurName = DBHelper.StringValue(dr["SurName"].ToString());
                item.Email = DBHelper.StringValue(dr["Email"].ToString());
                item.MobilePhone = DBHelper.StringValue(dr["MobilePhone"].ToString());
                item.TcId = DBHelper.StringValue(dr["TcId"].ToString());
                item.Password = DBHelper.StringValue(dr["TcId"].ToString());
                item.Status = DBHelper.IntValue(dr["Password"].ToString());
                item.LastLoginDate = DBHelper.DateValue(dr["LastLoginDate"].ToString());
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.BirthDate = DBHelper.DateValue(dr["BirthDate"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());

                itemUserList.Add(item);
            }

            dr.Close();
            return itemUserList;
        }
    }
}
