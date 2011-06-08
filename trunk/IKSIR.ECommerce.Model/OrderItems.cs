using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IKSIR.ECommerce.Model
{
    class OrderItems : Base
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int AddressId { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
        public int ProductId { get; set; }

        public OrderItems CreateOrderItems(int id, int createuser, DateTime createdate, int edituser, DateTime editdate, int userid, int orderid, int addressid,
            int count, decimal unitprice, int discount, int productid)
        {
            OrderItems Oi = new OrderItems();
            Oi.UserId = userid;
            Oi.OrderId = orderid;
            Oi.AddressId = addressid;
            Oi.Count = count;
            Oi.UnitPrice = unitprice;
            Oi.Discount = discount;
            Oi.ProductId = productid;

            Oi.CreateBase(id, createuser, createdate, edituser, editdate);

            return Oi;
        }
    }
}
