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

        public SqlDataReader WebGetMembershipAddressDetails(int AddressID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@AddressID", AddressID));
            return SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetAddress", parameters);
        }

        //public int WebInsertMembershipAddress(Address itemAddress)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@UserID", UserID));
        //    parameters.Add(new SqlParameter("@AddressTypeID", itemAddress));
        //    parameters.Add(new SqlParameter("@AddressTitle", AddressTitle.ToString()));
        //    parameters.Add(new SqlParameter("@FirstName", FirstName.ToString()));
        //    parameters.Add(new SqlParameter("@LastName", LastName.ToString()));
        //    parameters.Add(new SqlParameter("@CompanyName", CompanyName.ToString()));
        //    parameters.Add(new SqlParameter("@IdentityNumber", IdentityNumber.ToString()));
        //    parameters.Add(new SqlParameter("@TaxOffice", TaxOffice.ToString()));
        //    parameters.Add(new SqlParameter("@TaxOfficeID", TaxOfficeID.ToString()));
        //    parameters.Add(new SqlParameter("@Telephone", Telephone.ToString()));
        //    parameters.Add(new SqlParameter("@MobilPhone", MobilPhone.ToString()));
        //    parameters.Add(new SqlParameter("@CountryID", CountryID));
        //    parameters.Add(new SqlParameter("@CityID", CityID));
        //    parameters.Add(new SqlParameter("@TownID", TownID));
        //    parameters.Add(new SqlParameter("@AddressText", AddressText.ToString()));
        //    return Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertAddress", parameters));
        //}

        //public int WebUpdateMembershipAddress(int AddressID, int UserID, int AddressTypeID, string AddressTitle, string FirstName, string LastName, string CompanyName, string IdentityNumber, string TaxOffice, string TaxOfficeID, string Telephone, string MobilPhone, int CountryID, int CityID, int TownID, string AddressText, int Status)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@AddressID", AddressID));
        //    parameters.Add(new SqlParameter("@UserID", UserID));
        //    parameters.Add(new SqlParameter("@AddressTypeID", AddressTypeID.ToString()));
        //    parameters.Add(new SqlParameter("@AddressTitle", AddressTitle.ToString()));
        //    parameters.Add(new SqlParameter("@FirstName", FirstName.ToString()));
        //    parameters.Add(new SqlParameter("@LastName", LastName.ToString()));
        //    parameters.Add(new SqlParameter("@CompanyName", CompanyName.ToString()));
        //    parameters.Add(new SqlParameter("@IdentityNumber", IdentityNumber));
        //    parameters.Add(new SqlParameter("@TaxOffice", TaxOffice.ToString()));
        //    parameters.Add(new SqlParameter("@TaxOfficeID", TaxOfficeID.ToString()));
        //    parameters.Add(new SqlParameter("@Telephone", Telephone.ToString()));
        //    parameters.Add(new SqlParameter("@MobilPhone", MobilPhone.ToString()));
        //    parameters.Add(new SqlParameter("@CountryID", CountryID));
        //    parameters.Add(new SqlParameter("@CityID", CityID));
        //    parameters.Add(new SqlParameter("@TownID", TownID));
        //    parameters.Add(new SqlParameter("@AddressText", AddressText));
        //    parameters.Add(new SqlParameter("@Status", Status));
        //    return SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "WebUpdateMembershipAddress", parameters);
        //}

        //public int WebDeleteMembershipAddress(int AddressID)
        //{
        //    List<SqlParameter> parameters = new List<SqlParameter>();
        //    parameters.Add(new SqlParameter("@AddressID", AddressID));
        //    return SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "WebDeleteMembershipAddress", parameters);
        //}
    }
}
