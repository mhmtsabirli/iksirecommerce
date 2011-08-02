using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.OrderDataLayer
{
    public class BasketItemAddressData
    {
        public static Address Get(int id)
        {
            var returnValue = new Address();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetBasketItemAddres", parameters);
            while (dr.Read())
            {
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Type = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["TypeId"].ToString()) });
                returnValue.FirstName = DBHelper.StringValue(dr["FirstName"].ToString());
                returnValue.LastName = DBHelper.StringValue(dr["LastName"].ToString());

                if (dr["CountryId"] != null && dr["CountryId"].ToString() != "0")
                    returnValue.Country = CountryData.Get(new Country() { Id = DBHelper.IntValue(dr["CountryId"].ToString()) });
                if (dr["CityId"] != null && dr["CityId"].ToString() != "0")
                    returnValue.City = CityData.Get(DBHelper.IntValue(dr["CityId"].ToString()));
                if (dr["DistrictId"] != null && dr["DistrictId"].ToString() != "0")
                    returnValue.District = DistrictData.Get(new District() { Id = DBHelper.IntValue(dr["DistrictId"].ToString()) });

                returnValue.CityName = DBHelper.StringValue(dr["CityName"].ToString());
                returnValue.DistrictName = DBHelper.StringValue(dr["DistrictName"].ToString());
                returnValue.AddressDetail = DBHelper.StringValue(dr["AddressDetail"].ToString());
                returnValue.PostalCode = DBHelper.StringValue(dr["PostalCode"].ToString());
                returnValue.Phone = DBHelper.StringValue(dr["Phone"].ToString());
                returnValue.GSMPhone = DBHelper.StringValue(dr["GSMPhone"].ToString());
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Address itemAddress, int basketId = 0, int basketItemId = 0)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.Id));
            parameters.Add(new SqlParameter("@BasketId", basketId));
            parameters.Add(new SqlParameter("@BasketItemId", basketItemId));
            parameters.Add(new SqlParameter("@AdminId", itemAddress.CreateAdminId));
            parameters.Add(new SqlParameter("@UserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@Title", itemAddress.Title));
            parameters.Add(new SqlParameter("@TypeId", itemAddress.Type.Id));
            parameters.Add(new SqlParameter("@FirstName", itemAddress.FirstName));
            parameters.Add(new SqlParameter("@LastName", itemAddress.LastName));
            if (itemAddress.Country != null)
                parameters.Add(new SqlParameter("@CountryId", itemAddress.Country.Id));
            if (itemAddress.City != null)
                parameters.Add(new SqlParameter("@CityId", itemAddress.City.Id));
            if (itemAddress.District != null)
                parameters.Add(new SqlParameter("@DistrictId", itemAddress.District.Id));

            parameters.Add(new SqlParameter("@CityName", itemAddress.CityName));
            parameters.Add(new SqlParameter("@DistrictName", itemAddress.DistrictName));
            parameters.Add(new SqlParameter("@AddressDetail", itemAddress.AddressDetail));
            parameters.Add(new SqlParameter("@PostalCode", itemAddress.PostalCode.ToString()));
            parameters.Add(new SqlParameter("@Phone", itemAddress.Phone));
            parameters.Add(new SqlParameter("@GSMPhone", itemAddress.GSMPhone));

            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemAddress", parameters));

            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Update(Address itemAddress, int basketId = 0, int basketItemId = 0)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemAddress.Id));
            parameters.Add(new SqlParameter("@BasketId", basketId));
            parameters.Add(new SqlParameter("@BasketItemId", basketItemId));
            parameters.Add(new SqlParameter("@AdminId", itemAddress.EditAdminId));
            parameters.Add(new SqlParameter("@UserId", itemAddress.User.Id));
            parameters.Add(new SqlParameter("@Title", itemAddress.Title));
            parameters.Add(new SqlParameter("@TypeId", itemAddress.Type.Id));
            parameters.Add(new SqlParameter("@FirstName", itemAddress.FirstName));
            parameters.Add(new SqlParameter("@LastName", itemAddress.LastName));
            if (itemAddress.Country != null)
                parameters.Add(new SqlParameter("@CountryId", itemAddress.Country.Id));
            if (itemAddress.City != null)
                parameters.Add(new SqlParameter("@CityId", itemAddress.City.Id));
            if (itemAddress.District != null)
                parameters.Add(new SqlParameter("@DistrictId", itemAddress.District.Id));

            parameters.Add(new SqlParameter("@CityName", itemAddress.CityName));
            parameters.Add(new SqlParameter("@DistrictName", itemAddress.DistrictName));
            parameters.Add(new SqlParameter("@AddressDetail", itemAddress.AddressDetail));
            parameters.Add(new SqlParameter("@PostalCode", itemAddress.PostalCode.ToString()));
            parameters.Add(new SqlParameter("@Phone", itemAddress.Phone));
            parameters.Add(new SqlParameter("@GSMPhone", itemAddress.GSMPhone));

            parameters[0].Direction = ParameterDirection.Output;

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveBasketItemAddress", parameters));

            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }
    }
}

