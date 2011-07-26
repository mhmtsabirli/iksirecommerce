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
    public class CityData
    {
        public static City Get(int id)
        {
            var returnValue = new City();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetCity", parameters);
            while (dr.Read())
            {
                
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Country = CountryData.Get(new Country() { Id = DBHelper.IntValue(dr["CountryId"].ToString()) });
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(City itemCity)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemCity.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemCity.Country.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemCity.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertCity", parameters));
            return returnValue;
        }

        public static int Update(City itemCity)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemCity.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemCity.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemCity.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemCity.Country.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateCity", parameters);
            return returnValue;
        }

        public static int Save(City itemCity)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemCity.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemCity.CreateAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemCity.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemCity.Country.Id)));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveCity", parameters));
            return returnValue;
        }

        public static int Delete(City itemCity)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemCity.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteCity", parameters);
            return returnValue;
        }

        public static List<City> GetCityList(int countryId = 0)
        {
            List<City> itemCityList = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            if (countryId != 0)
                parameters.Add(new SqlParameter("@CountryId", countryId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetCity", parameters);
            itemCityList = new List<City>();

            while (dr.Read())
            {
                var item = new City();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Country = CountryData.Get(new Country() { Id = DBHelper.IntValue(dr["CountryId"].ToString()) });
                itemCityList.Add(item);
            }

            dr.Close();
            return itemCityList;
        }
    }
}

