using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.ProductModel;
using IKSIR.ECommerce.Model.CommonModel;

namespace IKSIR.ECommerce.Model.ProductModel
{
    public class ProductRate : ModelBase
    {
        public int UserId { get; set; }
        public Product Product { get; set; }
        public int Rate { get; set; }

        public ProductRate(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int userId, Product product, int rate)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.UserId = userId;
            this.Product = product;
            this.Rate = rate;
        }
        public ProductRate()
        {
        }
    }
}
