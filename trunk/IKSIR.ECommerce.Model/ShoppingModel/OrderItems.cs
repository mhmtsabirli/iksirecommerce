using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.ShoppingModel
{
    class OrderItems : ModelBase
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public Address Address { get; set; }
        public int Count { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }
        public Product Product { get; set; }

        public OrderItems(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int userId, int orderId, Address address,
            int count, decimal unitprice, int discount, Product product)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.UserId = userId;
            this.OrderId = orderId;
            this.Address = address;
            this.Count = count;
            this.UnitPrice = unitprice;
            this.Discount = discount;
            this.Product = product;
        }
    }
}
