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


namespace IKSIR.ECommerce.Infrastructure.DataLayer.ShowRoomDataLayer
{
    public class ShowRoomData
    {
        public static ShowRoom Get(ShowRoom itemShowRoom)
        {

            var returnValue = new ShowRoom();
            
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemShowRoom.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetShowRoom", parameters);
            dr.Read();

            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.Item = ProductData.Get(new Product() { Id = DBHelper.IntValue(dr["ItemId"].ToString()) });
            returnValue.EnumValue = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["EnumValueId"].ToString()) });
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());

            dr.Close();
            return returnValue;
        }

        public static int Insert(ShowRoom itemShowRoom)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@ItemId", DBHelper.StringValue(itemShowRoom.Item.Id)));
            parameters.Add(new SqlParameter("@EnumValueId", DBHelper.StringValue(itemShowRoom.EnumValue.Id)));
            parameters.Add(new SqlParameter("@CreateUserId", DBHelper.IntValue(itemShowRoom.CreateAdminId)));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertShowRoom", parameters));
            return returnValue;
        }

        public static int Update(ShowRoom itemShowRoom)
        {
            var returnValue = 1;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemShowRoom.Id));
            parameters.Add(new SqlParameter("@ItemId", DBHelper.StringValue(itemShowRoom.Item.Id)));
            parameters.Add(new SqlParameter("@EnumValueId", DBHelper.StringValue(itemShowRoom.EnumValue.Id)));
            parameters.Add(new SqlParameter("@EditUserId", DBHelper.IntValue(itemShowRoom.EditAdminId)));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateShowRoom", parameters);
            return returnValue;
        }

        public static int Delete(ShowRoom itemShowRoom)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemShowRoom.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteShowRoom", parameters);
            return returnValue;
        }

        public static List<ShowRoom> GetEnumList(ShowRoom itemShowRoom = null)
        {
            List<ShowRoom> itemEnumList = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemShowRoom.Id)));
            parameters.Add(new SqlParameter("@EnumValueId", DBHelper.IntValue(itemShowRoom.EnumValue.Id)));
            
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetShowRoom", parameters);
            itemEnumList = new List<ShowRoom>();

            while (dr.Read())
            {
                var item = new ShowRoom();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.Item = ProductData.Get(new Product() { Id = DBHelper.IntValue(dr["ItemId"].ToString()) });
                item.EnumValue = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["EnumValueId"].ToString()) });
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
            }

            dr.Close();
            return itemEnumList;
        }
    }
}
