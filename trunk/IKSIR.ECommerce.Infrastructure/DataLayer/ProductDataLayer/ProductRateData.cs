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
using System.Data;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer
{
    public class ProductRateData
    {
        public static int Insert(ProductRate item)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(item.Id)));
            parameters.Add(new SqlParameter("@UserId", DBHelper.StringValue(item.UserId)));
            parameters.Add(new SqlParameter("@Rate", DBHelper.StringValue(item.Rate)));
            if (item.Product != null)
                parameters.Add(new SqlParameter("@ProductId", DBHelper.IntValue(item.Product.Id)));

            parameters[0].Direction = ParameterDirection.Output;
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertProductRate", parameters));

            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }

        public static List<ProductRate> GetList(int productId)
        {
            List<ProductRate> returnValue = null;
            ProductRate item = new ProductRate();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", productId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductRates", parameters);
            if (dr.HasRows)
            {
                returnValue = new List<ProductRate>();
            }
            while (dr.Read())
            {
                item = new ProductRate();
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.UserId = DBHelper.IntValue(dr["UserId"].ToString());
                item.Product = ProductDataLayer.ProductData.Get(DBHelper.IntValue(dr["ProductId"].ToString()));
                item.Rate = DBHelper.IntValue(dr["Rate"].ToString());
                returnValue.Add(item);
            }
            dr.Close();
            return returnValue;
        }

        public static int GetProductRate(int productId)
        {
            var returnValue = 0;
            ProductRate item = new ProductRate();
            List<SqlParameter> parameters = new List<SqlParameter>();
            int rate = 0;
            parameters.Add(new SqlParameter("@AvgRate", rate));
            parameters.Add(new SqlParameter("@ProductId", productId));

            parameters[0].Direction = ParameterDirection.Output;
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductRate", parameters));

            int.TryParse(parameters[0].Value.ToString(), out returnValue);
            return returnValue;
        }
    }
}
