using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductStock : ModelBase
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }

        public ProductStock(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate,int productId, int stock)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            
            this.ProductId = productId;
            this.Stock = stock;

        }
    }
}
