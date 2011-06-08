using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class ProductStock : Base
    {
        public int ProductId { get; set; }
        public int Stock { get; set; }

        public ProductStock CreateProductStock(int id, int createuser, DateTime createdate, int edituser, DateTime editdate,int productid, int stock)
        {
            ProductStock Ps = new ProductStock();
            Ps.ProductId = productid;
            Ps.Stock = stock;

            Ps.CreateBase(id, createuser, createdate, edituser, editdate);

            return Ps;
        }
    }
}
