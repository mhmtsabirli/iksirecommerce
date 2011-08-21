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
    public class NewsletterData
    {
        public static int Insert(Newsletter itemNewsletter)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemNewsletter.Id));
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(itemNewsletter.Email)));

            parameters[0].Direction = ParameterDirection.Output;
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertNewsletter", parameters));
            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(int ItemId,bool IsActive)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", ItemId));
            parameters.Add(new SqlParameter("@IsActive", IsActive));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateNewsletter", parameters);
            return returnValue;
        }

        public static int Delete(Newsletter itemNewsletter)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", itemNewsletter.Email));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteNewsletter", parameters);
            return returnValue;
        }

        public static List<Newsletter> GetList()
        {
            List<Newsletter> itemNewsletterList = null;

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetNewsletterEmails");
            itemNewsletterList = new List<Newsletter>();

            while (dr.Read())
            {
                var item = new Newsletter();

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Email = DBHelper.StringValue(dr["Email"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                itemNewsletterList.Add(item);
            }

            dr.Close();
            return itemNewsletterList;
        }
        public static Newsletter Get(int NewsLetterId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", NewsLetterId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetNewsletterEmails",parameters);
            var item = new Newsletter();
            while (dr.Read())
            {
               

                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Email = DBHelper.StringValue(dr["Email"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
            }

            dr.Close();
            return item;
        }
    }
}
