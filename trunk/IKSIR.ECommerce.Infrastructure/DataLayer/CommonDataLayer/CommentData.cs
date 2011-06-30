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
    public class CommentData
    {
        public Comment Get(Comment itemComment)
        {
            var returnValue = new Comment();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemComment.Id));
            parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetComment", parameters);
            dr.Read();
            //TODO => ayhant
            //City,Countr,District, Type, User DB yazılınca city alnı direkt dbden çekilerek alınacak.

            returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
            returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
            returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
            returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
            returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
            returnValue.User = UserData.Get(new User() { Id = DBHelper.IntValue(dr["UserId"].ToString()) });
            returnValue.Ip = DBHelper.StringValue(dr["Ip"].ToString());
            returnValue.Value = DBHelper.StringValue(dr["Value"].ToString());
            returnValue.WebSite = DBHelper.IntValue(dr["WebSite"].ToString());

            dr.Close();
            return returnValue;
        }

        public int Insert(Comment itemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            parameters.Add(new SqlParameter("@Value", itemComment.Value.ToString()));
            parameters.Add(new SqlParameter("@Ip", itemComment.Ip));
            parameters.Add(new SqlParameter("@WebSite", itemComment.WebSite));
            parameters.Add(new SqlParameter("@CreateAdminId", itemComment.CreateAdminId));

            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "InsertComment", parameters));
            return returnValue;
        }

        public int Update(Comment itemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", itemComment.Id));
            parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            parameters.Add(new SqlParameter("@Value", itemComment.Value.ToString()));
            parameters.Add(new SqlParameter("@Ip", itemComment.Ip));
            parameters.Add(new SqlParameter("@WebSite", itemComment.WebSite));
            parameters.Add(new SqlParameter("@EditAdminId", itemComment.EditAdminId));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "UpdateComment", parameters);
            return returnValue;
        }

        public int Save(Comment itemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@Id", DBHelper.IntValue(itemComment.Id)));
            parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            parameters.Add(new SqlParameter("@Value", itemComment.Value.ToString()));
            parameters.Add(new SqlParameter("@Ip", itemComment.Ip));
            parameters.Add(new SqlParameter("@WebSite", itemComment.WebSite));
            parameters.Add(new SqlParameter("@AdminId", itemComment.CreateAdminId));
            returnValue = Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveComment", parameters));
            return returnValue;
        }

        public int Delete(Comment itemComment)
        {
            var returnValue = 0;

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemComment.Id));
            parameters.Add(new SqlParameter("@ErrorCode", ParameterDirection.Output));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteComment", parameters);
            return returnValue;
        }

        public static List<Comment> GeCommentList(Comment itemUser = null)
        {
            List<Comment> itemCommentList = null;

            List<SqlParameter> parameters = new List<SqlParameter>();

            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetComment", parameters);
            itemCommentList = new List<Comment>();

            while (dr.Read())
            {
                var item = new Comment();
                //TODO => tayfun
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.User = UserData.Get(new User() { Id = DBHelper.IntValue(dr["UserId"].ToString()) });
                item.Ip = DBHelper.StringValue(dr["Ip"].ToString());
                item.Value = DBHelper.StringValue(dr["Value"].ToString());
                item.WebSite = DBHelper.IntValue(dr["WebSite"].ToString());

                itemCommentList.Add(item);
            }

            dr.Close();
            return itemCommentList;
        }

    
    }
}

