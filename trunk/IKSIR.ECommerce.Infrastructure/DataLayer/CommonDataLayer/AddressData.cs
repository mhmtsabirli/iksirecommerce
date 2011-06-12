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
        //public List<Address> WebGetMembershipAddresses(int UserID, int AddressTypeID)
        //{
        //    List<Address> asd = new List<IKSIR.ECommerce.Model.CommonModel.Address>();


        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@UserID", UserID));
        //    parameters.Add(new SqlParameter("@AddressTypeID", AddressTypeID));
        //    IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetUserAddresses", parameters);
        //    while (dr.NextResult())
        //    {
        //        dr.R
        //    }
        //}

        public SqlDataReader GetAddressWithId(int AddressID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", AddressID));
            return SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAddress", parameters);
        }

        public int InsertAdress(Address itemAddress)
        {
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

            return Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertAddress", parameters));

        }


        public int UpdateAddress(Address itemAddress)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@UserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@Type", itemAddress.Type.Id));
            parameters.Add(new SqlParameter("@Description", itemAddress.Description.ToString()));
            parameters.Add(new SqlParameter("@DistrictId", itemAddress.District.Id));
            parameters.Add(new SqlParameter("@CityId", itemAddress.City.Id));
            parameters.Add(new SqlParameter("@CountryId", itemAddress.Country.Id));
            parameters.Add(new SqlParameter("@EditUserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@PostalCode", itemAddress.PostalCode.ToString()));
            parameters.Add(new SqlParameter("@Phone", itemAddress.Phone));
            return SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateAddress", parameters);
        }

        public int DeleteAddress(Address itemAddress)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.User.Id));
            return SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteAddress", parameters);
        }
    }
}
