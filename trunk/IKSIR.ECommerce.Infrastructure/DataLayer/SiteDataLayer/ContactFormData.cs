using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;
using System.Data;
using IKSIR.ECommerce.Model.SiteModel;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.ProductModel;


namespace IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer
{
    public class ContactFormData
    {
        public static ContactForm Get(ContactForm itemContactForm)
        {

            var returnValue = new ContactForm();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemContactForm.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetContactForm", parameters);
            dr.Read();

            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.FirstLastName = DBHelper.StringValue(dr["FirstLastName"].ToString());
            returnValue.Email = DBHelper.StringValue(dr["Email"].ToString());
            returnValue.Ip = DBHelper.StringValue(dr["Ip"].ToString());
            returnValue.Message = DBHelper.StringValue(dr["Message"].ToString());
            returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
            returnValue.Status = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["Status"].ToString()) });
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());

            dr.Close();
            return returnValue;
        }

        public static int Insert(ContactForm itemContactForm)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@FirstLastName", DBHelper.StringValue(itemContactForm.FirstLastName)));
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(itemContactForm.Email)));
            parameters.Add(new SqlParameter("@Ip", DBHelper.StringValue(itemContactForm.Ip)));
            parameters.Add(new SqlParameter("@Message", DBHelper.StringValue(itemContactForm.Message)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemContactForm.Title)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemContactForm.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertContactForm", parameters));
            return returnValue;
        }

        public static int Update(ContactForm itemContactForm)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemContactForm.Id));
            parameters.Add(new SqlParameter("@FirstLastName", DBHelper.StringValue(itemContactForm.FirstLastName)));
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(itemContactForm.Email)));
            parameters.Add(new SqlParameter("@Ip", DBHelper.StringValue(itemContactForm.Ip)));
            parameters.Add(new SqlParameter("@Message", DBHelper.StringValue(itemContactForm.Message)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemContactForm.Title)));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemContactForm.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateContactForm", parameters);
            return returnValue;
        }

        public static int Save(ContactForm itemContactForm)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemContactForm.Id));
            parameters.Add(new SqlParameter("@FirstLastName", DBHelper.StringValue(itemContactForm.FirstLastName)));
            parameters.Add(new SqlParameter("@Email", DBHelper.StringValue(itemContactForm.Email)));
            parameters.Add(new SqlParameter("@Ip", DBHelper.StringValue(itemContactForm.Ip)));
            parameters.Add(new SqlParameter("@Message", DBHelper.StringValue(itemContactForm.Message)));
            parameters.Add(new SqlParameter("@Title", DBHelper.StringValue(itemContactForm.Title)));
            parameters.Add(new SqlParameter("@Status", DBHelper.StringValue(itemContactForm.Status.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemContactForm.CreateAdminId)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveContactForm", parameters));
            return returnValue;
        }


        public static int Delete(ContactForm itemContactForm)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemContactForm.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteContactForm", parameters);
            return returnValue;
        }

        public static List<ContactForm> GetContactFormist(ContactForm itemContactForm = null)
        {
            List<ContactForm> itemContactFormList = null;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Title", DBHelper.IntValue(itemContactForm.Title)));
            parameters.Add(new SqlParameter("@Status", DBHelper.IntValue(itemContactForm.Status.Id)));

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetContactForm", parameters);
            itemContactFormList = new List<ContactForm>();

            while (dr.Read())
            {
                var item = new ContactForm();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.FirstLastName = DBHelper.StringValue(dr["FirstLastName"].ToString());
                item.Email = DBHelper.StringValue(dr["Email"].ToString());
                item.Ip = DBHelper.StringValue(dr["Ip"].ToString());
                item.Message = DBHelper.StringValue(dr["Message"].ToString());
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Status = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["Status"].ToString()) });
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
            }

            dr.Close();
            return itemContactFormList;
        }
    }
}
