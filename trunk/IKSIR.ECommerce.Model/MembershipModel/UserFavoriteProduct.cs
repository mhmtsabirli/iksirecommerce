using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.MembershipModel
{
    public class UserFavoriteProduct : ModelBase
    {
        public int UserId { get; set; }
        public Product Product { get; set; }

        public UserFavoriteProduct(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int userId, Product product)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.UserId = userId;
            this.Product = product;
        }
        public UserFavoriteProduct()
        {
        }
    }
}
