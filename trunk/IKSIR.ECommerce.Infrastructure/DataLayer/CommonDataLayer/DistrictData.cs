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
    public class DistrictData
    {
        public static District Get(District itemDistrict)
        {
            var returnValue = new District();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemDistrict.Id));
            if (itemDistrict.City != null)
                parameters.Add(new SqlParameter("@CityId", itemDistrict.City.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetDistrict", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.Name = DBHelper.StringValue(dr["Name"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.City = CityData.Get(DBHelper.IntValue(dr["CityId"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(District itemDistrict)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemDistrict.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemDistrict.City.Id)));
            parameters.Add(new SqlParameter("@CreateAdminId", DBHelper.IntValue(itemDistrict.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertDistrict", parameters));
            return returnValue;
        }

        public static int Update(District itemDistrict)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemDistrict.Id));
            parameters.Add(new SqlParameter("@EditAdminId", DBHelper.IntValue(itemDistrict.EditAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemDistrict.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemDistrict.City.Id)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateDistrict", parameters);
            return returnValue;
        }


        public static int Save(District itemDistrict)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemDistrict.Id)));
            parameters.Add(new SqlParameter("@AdminId", DBHelper.IntValue(itemDistrict.CreateAdminId)));
            parameters.Add(new SqlParameter("@Name", DBHelper.StringValue(itemDistrict.Name)));
            parameters.Add(new SqlParameter("@CountryId", DBHelper.StringValue(itemDistrict.City.Id)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveDistrict", parameters));
            return returnValue;
        }

        public static int Delete(District itemDistrict)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemDistrict.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteDistrict", parameters);
            return returnValue;
        }

        public static List<District> GetDistrictList(int cityId = 0)
        {
            List<District> itemDistrictList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();
            if (cityId != 0)
                parameters.Add(new SqlParameter("@CityId", cityId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetDistrict", parameters);
            itemDistrictList = new List<District>();

            while (dr.Read())
            {
                var item = new District();
                
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.Name = DBHelper.StringValue(dr["Name"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.City = CityData.Get(DBHelper.IntValue(dr["CityId"].ToString()));
                itemDistrictList.Add(item);
            }

            dr.Close();
            return itemDistrictList;
        }
    }
}
