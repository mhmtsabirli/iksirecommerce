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
using IKSIR.ECommerce.Infrastructure.DataLayer.ProductDataLayer;
using IKSIR.ECommerce.Infrastructure.DataLayer.SiteDataLayer;
using IKSIR.ECommerce.Model.SiteModel;

namespace IKSIR.ECommerce.Infrastructure.DataLayer.CommonDataLayer
{
    public class CommentData
    {
        public static Comment Get(int id)
        {
            var returnValue = new Comment();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", id));
            SqlDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetComment", parameters);
            while (dr.Read())
            {
                returnValue.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                returnValue.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                returnValue.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                returnValue.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                returnValue.Id = DBHelper.IntValue(dr["Id"].ToString());
                returnValue.Product = ProductData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                returnValue.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                returnValue.Title = DBHelper.StringValue(dr["Title"].ToString());
                returnValue.Content = DBHelper.StringValue(dr["Content"].ToString());
                returnValue.Ip = DBHelper.StringValue(dr["Ip"].ToString());
                returnValue.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                returnValue.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
            }
            dr.Close();
            return returnValue;
        }

        public static int Insert(Comment itemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemComment.Id));
            parameters.Add(new SqlParameter("@AdminId", itemComment.CreateAdminId));
            if (itemComment.Product != null)
                parameters.Add(new SqlParameter("@ProductId", itemComment.Product.Id));
            if (itemComment.User != null)
                parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            parameters.Add(new SqlParameter("@Title", itemComment.Title));
            parameters.Add(new SqlParameter("@Content", itemComment.Content));
            parameters.Add(new SqlParameter("@Ip", itemComment.Ip));
            if (itemComment.Site != null)
                parameters.Add(new SqlParameter("@SiteId", itemComment.Site.Id));
            parameters.Add(new SqlParameter("@Status", itemComment.Status));

            parameters[0].Direction = ParameterDirection.Output;

            Convert.ToInt32(SQLDataBlock.ExecuteScalar(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveComment", parameters));
            returnValue = DBHelper.IntValue(parameters[0].Value);
            return returnValue;
        }

        public static int Update(Comment itemComment)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", itemComment.Id));
            parameters.Add(new SqlParameter("@AdminId", itemComment.EditAdminId));
            parameters.Add(new SqlParameter("@ProductId", itemComment.Product.Id));
            parameters.Add(new SqlParameter("@UserId", itemComment.User.Id));
            parameters.Add(new SqlParameter("@Title", itemComment.Title));
            parameters.Add(new SqlParameter("@Content", itemComment.Content));
            parameters.Add(new SqlParameter("@Ip", itemComment.Ip));
            parameters.Add(new SqlParameter("@SiteId", itemComment.Site.Id));
            parameters.Add(new SqlParameter("@Status", itemComment.Status));

            parameters[0].Direction = ParameterDirection.Output;

            SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "SaveComment", parameters);
            returnValue = DBHelper.IntValue(parameters[0].Value);
            return returnValue;
        }

        public static int Delete(int commentId)
        {
            var returnValue = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", commentId));
            returnValue = SQLDataBlock.ExecuteNonQuery(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "DeleteComment", parameters);
            return returnValue;
        }

        public static List<Comment> GetCommentList()
        {
            List<Comment> itemCommentList = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetComment", parameters);
            itemCommentList = new List<Comment>();
            while (dr.Read())
            {
                var item = new Comment();
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Product = ProductData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Content = DBHelper.StringValue(dr["Content"].ToString());
                item.Ip = DBHelper.StringValue(dr["Ip"].ToString());
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                itemCommentList.Add(item);
            }
            dr.Close();
            return itemCommentList;
        }

        public static List<Comment> GetCommentList(int productId)
        {
            List<Comment> itemCommentList = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ProductId", productId));
            IDataReader dr = SQLDataBlock.ExecuteReader(StaticData.Idevit.ConnectionString, CommandType.StoredProcedure, "GetProductComments", parameters);
            itemCommentList = new List<Comment>();
            while (dr.Read())
            {
                var item = new Comment();
                item.CreateDate = DBHelper.DateValue(dr["CreateDate"].ToString());
                item.CreateAdminId = DBHelper.IntValue(dr["CreateAdminId"].ToString());
                item.EditDate = DBHelper.DateValue(dr["EditDate"].ToString());
                item.EditAdminId = DBHelper.IntValue(dr["EditAdminId"].ToString());
                item.Id = DBHelper.IntValue(dr["Id"].ToString());
                item.Product = ProductData.Get(DBHelper.IntValue(dr["Id"].ToString()));
                item.User = UserData.Get(DBHelper.IntValue(dr["UserId"].ToString()));
                item.Title = DBHelper.StringValue(dr["Title"].ToString());
                item.Content = DBHelper.StringValue(dr["Content"].ToString());
                item.Ip = DBHelper.StringValue(dr["Ip"].ToString());
                item.Site = SiteData.Get(new Site() { Id = DBHelper.IntValue(dr["SiteId"].ToString()) });
                item.Status = EnumValueData.Get(DBHelper.IntValue(dr["Status"].ToString()));
                itemCommentList.Add(item);
            }
            dr.Close();
            return itemCommentList;
        }
    }
}

