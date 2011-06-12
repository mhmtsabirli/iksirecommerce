using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonData
{
    public class AddressData
    {
        public Address GetAddress(Address itemAddress)
        {
            var returnValue = new Address();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAddress", parameters);
            dr.Read();
            //TODO => ayhant
            //City,Countr,District, Type, User DB yazılınca city alnı direkt dbden çekilerek alınacak.
            //returnValue.City = CityData.GetCity(DBHelper.IntValue(dr["CityId"].ToString()));
            //returnValue.Country = CountryData.GetCity(DBHelper.IntValue(dr["CountryId"].ToString()));
            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.Description = DBHelper.StringValue(dr["Description"].ToString());
            //item.District = DistrictData.GetDistrict(DBHelper.IntValue(dr["DistrictId"].ToString()));                
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            returnValue.Phone = DBHelper.StringValue(dr["Phone"].ToString());
            //item.PostalCode = DBHelper.StringValue(dr["Phone"].ToString());
            returnValue.PostalCode = DBHelper.StringValue(dr["PostalCode"].ToString());
            //item.Type = 
            //item.User = new Model.MembershipModel.User;
            dr.Close();
            return returnValue;
        }

        public int InsertAdress(Address itemAddress)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@Type", itemAddress.Type.Id));
            parameters.Add(new SqlParameter("@Description", itemAddress.Description.ToString()));
            parameters.Add(new SqlParameter("@DistrictId", itemAddress.District.Id));
            parameters.Add(new SqlParameter("@CityId", itemAddress.City.Id));
            parameters.Add(new SqlParameter("@CountryId", itemAddress.Country.Id));
            parameters.Add(new SqlParameter("@CreateUserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@PostalCode", itemAddress.PostalCode.ToString()));
            parameters.Add(new SqlParameter("@Phone", itemAddress.Phone));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertAddress", parameters));
            return returnValue;
        }

        public int UpdateAddress(Address itemAddress)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemAddress.Id));
            parameters.Add(new SqlParameter("@UserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@Type", itemAddress.Type.Id));
            parameters.Add(new SqlParameter("@Description", itemAddress.Description.ToString()));
            parameters.Add(new SqlParameter("@DistrictId", itemAddress.District.Id));
            parameters.Add(new SqlParameter("@CityId", itemAddress.City.Id));
            parameters.Add(new SqlParameter("@CountryId", itemAddress.Country.Id));
            parameters.Add(new SqlParameter("@EditUserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@PostalCode", itemAddress.PostalCode.ToString()));
            parameters.Add(new SqlParameter("@Phone", itemAddress.Phone));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateAddress", parameters);
            return returnValue;
        }

        public int DeleteAddress(Address itemAddress)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.Id));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteAddress", parameters);
            return returnValue;
        }

        public List<Address> GetMembershipAddresses(int userId, int addressTypeId)
        {
            List<Address> itemAddressList = new List<Address>();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));
            parameters.Add(new SqlParameter("@TypeId", addressTypeId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetMembershipAddresses", parameters);

            var item = new Address();
            while (dr.Read())
            {
                //item.City = CityData.GetCity(DBHelper.IntValue(dr["CityId"].ToString()));
                //item.Country = CountryData.GetCity(DBHelper.IntValue(dr["CountryId"].ToString()));
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Description = DBHelper.StringValue(dr["Description"].ToString());
                //item.District = DistrictData.GetDistrict(DBHelper.IntValue(dr["DistrictId"].ToString()));                
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Phone = DBHelper.StringValue(dr["Phone"].ToString());
                //item.PostalCode = DBHelper.StringValue(dr["Phone"].ToString());
                item.PostalCode = DBHelper.StringValue(dr["PostalCode"].ToString());
                //item.Type = 
                //item.User = new Model.MembershipModel.User;
                itemAddressList.Add(item);
            }

            dr.Close();
            return itemAddressList;
        }
    }
}
