using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItemProductPrice : ModelBase
    {
        public int BasketItemId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Tax { get; set; }
        public decimal Price { get; set; }

        public BasketItemProductPrice(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, int basketItemId, int productId, decimal unitPrice, int tax, decimal price)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.BasketItemId = basketItemId;
            this.ProductId = productId;
            this.UnitPrice = unitPrice;
            this.Tax = tax;
            this.Price = price;
        }
        public BasketItemProductPrice()
        {
        }
    }
}
