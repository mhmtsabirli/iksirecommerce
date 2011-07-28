using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IKSIR.ECommerce.Model.CommonModel;
using IKSIR.ECommerce.Model.MembershipModel;
using IKSIR.ECommerce.Model.ProductModel;

namespace IKSIR.ECommerce.Model.Order
{
    public class BasketItem : ModelBase
    {
        public Basket Basket{ get; set; }
        public Product Product { get; set; }
        public BasketItemAddres ShippingAddress { get; set; }
        public EnumValue Status { get; set; }

        public BasketItem(int id, int createUserId, DateTime createDate, int editUserId, DateTime editDate, Basket basket, Product product, BasketItemAddres shippingAddress, EnumValue status)
            : base(id, createUserId, createDate, editUserId, editDate)
        {
            this.Basket = basket;
            this.Product = product;
            this.ShippingAddress = shippingAddress;
            this.Status = status;
        }
        public BasketItem()
        {
        }
    }


}
