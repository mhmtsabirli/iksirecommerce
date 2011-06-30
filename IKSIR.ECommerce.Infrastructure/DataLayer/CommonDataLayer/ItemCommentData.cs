using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using IKSIR.ECommerce.Infrastructure.DataLayer.DataBlock;
using System.Data;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Infrastructure.DataLayer.MembershipDataLayer;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    class ItemCommentData
    {
        public ItemComments Get(ItemComments itemItemComments)
        {
            var returnValue = new ItemComments();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemItemComments.Id));
            parameters.Add(new SqlParameter("@UserId", itemItemComments.User.Id));
            parameters.Add(new SqlParameter("@CommentId", itemItemComments.CommentId));
             parameters.Add(new SqlParameter("@ItemId", itemItemComments.ItemId));

            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetComment", parameters);
            dr.Read();

            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            returnValue.User = UserData.Get(new User() { Id = DBHelper.IntValue(dr["UserId"].ToString()) });
            returnValue.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
            returnValue.ItemId = DBHelper.IntValue(dr["ItemId"].ToString());
            returnValue.ItemType = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ItemType"].ToString()) });
            

            dr.Close();
            return returnValue;
        }

        public int Insert(ItemComments itemItemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();


            parameters.Add(new SqlParameter("@UserId", itemItemComment.User.Id));
            parameters.Add(new SqlParameter("@ItemTypeId", itemItemComment.ItemType.Id));
            parameters.Add(new SqlParameter("@ItemId", itemItemComment.ItemId));
            parameters.Add(new SqlParameter("@CommentId", itemItemComment.CommentId));
            parameters.Add(new SqlParameter("@IsActive", itemItemComment.IsActive));
            parameters.Add(new SqlParameter("@CreateAdminId", itemItemComment.CreateAdminId));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertItemComment", parameters));
            return returnValue;
        }

        public int Update(ItemComments itemItemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemItemComment.Id));
            parameters.Add(new SqlParameter("@UserId", itemItemComment.User.Id));
            parameters.Add(new SqlParameter("@ItemTypeId", itemItemComment.ItemType.Id));
            parameters.Add(new SqlParameter("@ItemId", itemItemComment.ItemId));
            parameters.Add(new SqlParameter("@CommentId", itemItemComment.CommentId));
            parameters.Add(new SqlParameter("@IsActive", itemItemComment.IsActive));
            parameters.Add(new SqlParameter("@EditAdminId", itemItemComment.EditAdminId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateItemComment", parameters);
            return returnValue;
        }

        public static int Save(ItemComments itemItemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemItemComment.Id)));
            parameters.Add(new SqlParameter("@UserId", itemItemComment.User.Id));
            parameters.Add(new SqlParameter("@ItemTypeId", itemItemComment.ItemType.Id));
            parameters.Add(new SqlParameter("@ItemId", itemItemComment.ItemId));
            parameters.Add(new SqlParameter("@CommentId", itemItemComment.CommentId));
            parameters.Add(new SqlParameter("@IsActive", itemItemComment.IsActive));
            parameters.Add(new SqlParameter("@AdminId", itemItemComment.CreateAdminId));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveItemComment", parameters));
            return returnValue;
        }

        public int Delete(ItemComments itemItemComment)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemItemComment.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));

            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteItemComment", parameters);
            return returnValue;
        }

        public static List<ItemComments> GetItemCommentList(ItemComments itemItemComment = null)
        {
            List<ItemComments> itemItemCommentList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetItemComment", parameters);
            itemItemCommentList = new List<ItemComments>();

            while (dr.Read())
            {
                var item = new ItemComments();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.User = UserData.Get(new User() { Id = DBHelper.IntValue(dr["UserId"].ToString()) });
                item.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                item.ItemId = DBHelper.IntValue(dr["ItemId"].ToString());
                item.ItemType = EnumValueData.Get(new EnumValue() { Id = DBHelper.IntValue(dr["ItemType"].ToString()) });

                itemItemCommentList.Add(item);
            }

            dr.Close();
            return itemItemCommentList;
        }
    }
}
