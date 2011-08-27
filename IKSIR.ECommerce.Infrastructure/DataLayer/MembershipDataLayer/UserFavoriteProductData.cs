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
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer
{
    public class UserFavoriteProductData
    {
        public static int Insert(UserFavoriteProduct item)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(item.Id)));
            parameters.Add(new SqlParameter("@UserId", DBHelper.StringValue(item.UserId)));
            if (item.Product != null)
                parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(item.Product.Id)));

            parameters[0].Direction = ParameterDirection.Output;
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertUserFavoriteProduct", parameters));

            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static int Delete(int id)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteUserFavoriteProduct", parameters);
            return returnValue;
        }

        public static List<UserFavoriteProduct> GetList(int userId)
        {
            List<UserFavoriteProduct> returnValue = null;
            UserFavoriteProduct item = new UserFavoriteProduct();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@UserId", userId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetUserFavoriteProducts", parameters);
            if (dr.HasRows)
            {
                returnValue = new List<UserFavoriteProduct>();
            }
            while (dr.Read())
            {
                item = new UserFavoriteProduct();
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.UserId = DBHelper.IntValue(dr["UserId"].ToString());
                item.Product = ProductDataLayer.ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                returnValue.Add(item);
            }
            dr.Close();
            return returnValue;
        }
    }
}
